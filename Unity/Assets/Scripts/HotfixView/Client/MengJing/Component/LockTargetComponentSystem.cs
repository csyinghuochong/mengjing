using System.Collections.Generic;
using System.Linq;
using EPOOutline;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(LockTargetComponent))]
    [EntitySystemOf(typeof(LockTargetComponent))]
    public static partial class LockTargetComponentSystem
    {
        [EntitySystem]
        private static void Awake(this LockTargetComponent self)
        {
            Camera camera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            self.MyCamera_1 = camera.GetComponent<MyCamera_1>();
        }

        [EntitySystem]
        private static void Update(this LockTargetComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this LockTargetComponent self)
        {
            foreach (GameObject go in self.EffectMap.Values)
            {
                UnityEngine.Object.Destroy(go);
            }

            self.EffectMap.Clear();
            self.LockUnitEffect = null;
        }

        private static Unit GetMainUnit(this LockTargetComponent self)
        {
            Unit unit = self.MainUnit;
            if (unit == null || unit.IsDisposed)
            {
                unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            }

            return unit;
        }
        
        public static void OnMainHeroMove(this LockTargetComponent self)
        {
            Unit haveBoss = null;
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.MainCityScene)
            {
                Unit main = self.GetMainUnit();
                List<EntityRef<Unit>> allUnit = main.GetParent<UnitComponent>().GetAll();
                for (int i = 0; i < allUnit.Count; i++)
                {
                    Unit unit = allUnit[i];
                    if (unit.Type != UnitType.Monster)
                    {
                        continue;
                    }

                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                    if (monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss && PositionHelper.Distance2D(unit.Position, main.Position) < 20f)
                    {
                        haveBoss = unit;
                        break;
                    }
                }

                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainHpBar.ShowBossHPBar(haveBoss);
            }
            else
            {
                self.MyCamera_1.OnUpdate();
            }
        }

        public static void BeforeEnterScene(this LockTargetComponent self)
        {
            self.HideLockEffect();
        }

        public static void HideLockEffect(this LockTargetComponent self)
        {
            if (self.LockUnitEffect != null)
            {
                self.LockUnitEffect.SetActive(false);
            }

            self.LastLockId = 0;
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>().View.ES_MainHpBar.OnCancelLock();
            self.SetHighlight(self.LastHighlightGameObject, false);
        }

        public static void OnSelfDead(this LockTargetComponent self)
        {
            self.HideLockEffect();
        }

        public static void OnUnitDead(this LockTargetComponent self, Unit unit)
        {
            if (unit.Id == self.LastLockId)
            {
                self.LastLockId = 0;
                self.HideLockEffect();
            }
        }

        public static void OnUnitRemove(this LockTargetComponent self, List<long> ids)
        {
            if (ids.Contains(self.LastLockId))
            {
                self.LastLockId = 0;
                self.HideLockEffect();
            }
        }

        public static void CheckLockEffect(this LockTargetComponent self, int type = 0)
        {
            if (self.LockUnitEffect != null)
            {
                self.LockUnitEffect.gameObject.SetActive(false);
            }
            
            self.Type = type;

            if (self.EffectMap.ContainsKey(type) && self.EffectMap[type] == null)
            {
                self.EffectMap.Remove(type);
            }

            if (!self.EffectMap.ContainsKey(type))
            {
                ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
                string path = "";
                if (type == 0)
                {
                    path = ABPathHelper.GetEffetPath("ScenceEffect/RoseSelectTarget");
                }
                else if (type == 1)
                {
                    path = ABPathHelper.GetEffetPath("ScenceEffect/SceneEffect_Npc_Select");
                }

                GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                self.EffectMap.Add(type, UnityEngine.Object.Instantiate(prefab));
            }

            self.LockUnitEffect = self.EffectMap[type];
        }

        public static void LockTargetUnitId(this LockTargetComponent self, long unitId)
        {
            Unit unitTarget = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(unitId);
            if (unitTarget == null)
            {
                return;
            }

            self.LastLockId = unitId;
            
            self.CheckLockEffect();

            if (self.LockUnitEffect != null)
            {
                CommonViewHelper.SetParent(self.LockUnitEffect, unitTarget.GetComponent<GameObjectComponent>().GameObject);
                self.LockUnitEffect.SetActive(true);
            }

            if (unitTarget.Type == UnitType.Monster)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unitTarget.ConfigId);

                DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
                dlgMain.View.ES_MainHpBar.OnLockUnit(unitTarget);
                dlgMain.View.ES_MainSkill.OnLockUnit(unitTarget);

                self.SetEffectSize((float)monsterConfig.SelectSize);
            }
            
            self.SetHighlight(self.LastHighlightGameObject, false);
            self.LastHighlightGameObject = unitTarget.GetComponent<GameObjectComponent>().GameObject;
            self.SetHighlight(self.LastHighlightGameObject, true);
        }

        public static void SetHighlight(this LockTargetComponent self, GameObject gameObject, bool isHighlight)
        {
            if (gameObject == null)
            {
                return;
            }
            
            Outlinable outlinable = gameObject.GetComponent<Outlinable>();
            if (outlinable == null)
            {
                outlinable = gameObject.AddComponent<Outlinable>();
                
                MeshRenderer[] meshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
                SkinnedMeshRenderer[] skinnedMeshRenderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
                
                string[] excludeNameFilter = new[] { "BackDi", "fake shadow (5)", "Rose_BackDi" };
            
                foreach (var mr in meshRenderers)
                {
                    if (excludeNameFilter.Contains(mr.gameObject.name))
                    {
                        continue;
                    }
            
                    outlinable.AddRenderer(mr);
                }
            
                foreach (var smr in skinnedMeshRenderers)
                {
                    if (excludeNameFilter.Contains(smr.gameObject.name))
                    {
                        continue;
                    }
            
                    outlinable.AddRenderer(smr);
                }
            }
            outlinable.OutlineParameters.Color = new Color(181 / 255f, 250 / 255f, 130 / 255f, 255 / 255f);
            outlinable.OutlineParameters.BlurShift = 0.2f;
            outlinable.OutlineParameters.DilateShift = 0.2f;
            
            outlinable.OutlineParameters.Enabled = isHighlight;
        }

        public static void SkillLock(this LockTargetComponent self, Unit main, SkillConfig skillConfig)
        {
            //没有技能指示器，并且不是强击类型的技能
            if (skillConfig.SkillZhishiType == 0 && skillConfig.SkillTargetType != SkillTargetType.TargetOnly)
            {
                return;
            }

            if (self.AttackTarget == 0)
            {
                //选择最近的
                self.LockTargetUnit();
            }
            else
            {
                //获取当前目标和自身目标的距离
                long targetId = self.LastLockId;
                UnitComponent unitComponent = main.GetParent<UnitComponent>();
                Unit targetUnit = unitComponent.Get(targetId);
                if (targetUnit == null || (PositionHelper.Distance2D(targetUnit.Position, main.Position) + 4) > skillConfig.SkillRangeSize)
                {
                    //获取当前最近的单位
                    Unit enemy = GetTargetHelperc.GetNearestEnemy(main, (float)skillConfig.SkillRangeSize + 4);
                    //设置目标
                    if (targetUnit == null && enemy != null)
                    {
                        self.LockTargetUnitId(enemy.Id);
                    }
                }
            }
        }
        
         public static long ChangeTargetUnit(this LockTargetComponent self)
        {
            Unit main = self.GetMainUnit();
           
            float distance = 10f;
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            ListComponent<UnitLockRange> UnitLockRanges = new ListComponent<UnitLockRange>();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];

                if (self.IsGuaJi)
                {
                    if (!main.IsCanAttackUnit(unit))
                    {
                        continue;
                    }
                }
                else
                {
                    ///非挂机状态下可以选中精灵
                    if (!main.IsCanAttackUnit(unit) && !unit.IsJingLingMonster())
                    {
                        continue;
                    }
                }

                Unit unit1 = units[i];
                StateComponentC stateComponent = unit1.GetComponent<StateComponentC>();
                if (stateComponent.StateTypeGet(StateTypeEnum.Stealth) || stateComponent.StateTypeGet(StateTypeEnum.Hide))
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd < distance)
                {
                    UnitLockRanges.Add(new UnitLockRange() { Id = unit.Id, Range = (int)(dd * 100), Type = unit.Type });
                }
            }

            UnitLockRanges.Sort((a, b) => a.Range - b.Range);

            if (UnitLockRanges.Count == 0)
            {
                //取消锁定
                self.LastLockIndex = -1;
                self.LastLockId = 0;
            }
            else
            {
                bool attackedPlayer = false; // 是否锁定了玩家
                if (self.SkillAttackPlayerFirst == 1)
                {
                    self.LastLockIndex++;

                    for (int i = self.LastLockIndex; i < UnitLockRanges.Count; i++)
                    {
                        if (UnitLockRanges[i].Type != UnitType.Player)
                        {
                            continue;
                        }

                        attackedPlayer = true;
                        self.LastLockIndex = i;
                        self.LastLockId = UnitLockRanges[i].Id;
                        break;
                    }
                }

                if (!attackedPlayer)
                {
                    //锁定最近目标
                    self.LastLockIndex++;
                    if (self.LastLockIndex >= UnitLockRanges.Count)
                    {
                        self.LastLockIndex = 0;
                    }

                    if (self.LastLockId != 0 && UnitLockRanges[self.LastLockIndex].Id == self.LastLockId)
                    {
                        self.LastLockIndex++;
                    }

                    if (self.LastLockIndex >= UnitLockRanges.Count)
                    {
                        self.LastLockIndex = 0;
                    }

                    self.LastLockId = UnitLockRanges[self.LastLockIndex].Id;
                }
            }

            self.LockTargetUnitId(self.LastLockId);
            return self.LastLockId;
        }

        /// <summary>
        /// nearest 最近
        /// </summary>
        /// <param name="self"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static long LockTargetUnit(this LockTargetComponent self, bool random = false)
        {
            Unit main = self.GetMainUnit();
            if (!random && self.AttackTarget == 1)
            {
                Unit unitTarget = main.GetParent<UnitComponent>().Get(self.LastLockId);
                if (unitTarget != null && PositionHelper.Distance2D(main.Position, unitTarget.Position) < 10f && unitTarget.IsCanBeAttack())
                {
                    return self.LastLockId;
                }
            }

            float distance = 10f;
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            ListComponent<UnitLockRange> UnitLockRanges = new ListComponent<UnitLockRange>();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];

                if (self.IsGuaJi)
                {
                    if (!main.IsCanAttackUnit(unit))
                    {
                        continue;
                    }
                }
                else
                {
                    ///非挂机状态下可以选中精灵
                    if (!main.IsCanAttackUnit(unit) && !unit.IsJingLingMonster())
                    {
                        continue;
                    }
                }

                Unit unit1 = units[i];
                StateComponentC stateComponent = unit1.GetComponent<StateComponentC>();
                if (stateComponent.StateTypeGet(StateTypeEnum.Stealth) || stateComponent.StateTypeGet(StateTypeEnum.Hide))
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd < distance)
                {
                    UnitLockRanges.Add(new UnitLockRange() { Id = unit.Id, Range = (int)(dd * 100), Type = unit.Type });
                }
            }

            UnitLockRanges.Sort((a, b) => a.Range - b.Range);

            if (UnitLockRanges.Count == 0)
            {
                //取消锁定
                self.LastLockIndex = -1;
                self.LastLockId = 0;
            }
            else
            {
                bool attackedPlayer = false; // 是否锁定了玩家
                if (self.SkillAttackPlayerFirst == 1)
                {
                    if (self.AttackTarget == 0)
                    {
                        self.LastLockIndex = 0;
                    }
                    else
                    {
                        self.LastLockIndex++;
                    }

                    for (int i = self.LastLockIndex; i < UnitLockRanges.Count; i++)
                    {
                        if (UnitLockRanges[i].Type != UnitType.Player)
                        {
                            continue;
                        }

                        attackedPlayer = true;
                        self.LastLockIndex = i;
                        self.LastLockId = UnitLockRanges[i].Id;
                        break;
                    }
                }

                if (!attackedPlayer)
                {
                    //锁定最近目标
                    if (self.AttackTarget == 0)
                    {
                        self.LastLockIndex = 0;
                        self.LastLockId = UnitLockRanges[self.LastLockIndex].Id;
                    }
                    else
                    {
                        self.LastLockIndex++;
                        if (self.LastLockIndex >= UnitLockRanges.Count)
                        {
                            self.LastLockIndex = 0;
                        }

                        if (self.LastLockId != 0 && UnitLockRanges[self.LastLockIndex].Id == self.LastLockId)
                        {
                            self.LastLockIndex++;
                        }

                        if (self.LastLockIndex >= UnitLockRanges.Count)
                        {
                            self.LastLockIndex = 0;
                        }

                        self.LastLockId = UnitLockRanges[self.LastLockIndex].Id;
                    }
                }
            }

            self.LockTargetUnitId(self.LastLockId);
            return self.LastLockId;
        }

        public static void SetEffectSize(this LockTargetComponent self, float size)
        {
            GameObject go = null;
            if (self.Type == 0)
            {
                self.LockUnitEffect.transform.localScale = Vector3.one * size;
            }
            if (self.Type == 1)
            {
                go = self.LockUnitEffect.GetComponent<ReferenceCollector>().Get<GameObject>("circle_floor");
                ParticleSystem ps = go.GetComponent<ParticleSystem>();
                var main = ps.main;
                main.startSize = new ParticleSystem.MinMaxCurve(3 * size);
            }
        }

        public static void OnLockNpc(this LockTargetComponent self, Unit unitTarget)
        {
            self.CheckLockEffect(1);
            if (unitTarget != null)
            {
                CommonViewHelper.SetParent(self.LockUnitEffect, unitTarget.GetComponent<GameObjectComponent>().GameObject);
                self.LockUnitEffect.SetActive(true);
                self.SetEffectSize(1f);
                
                self.SetHighlight(self.LastHighlightGameObject, false);
                self.LastHighlightGameObject = unitTarget.GetComponent<GameObjectComponent>().GameObject;
                self.SetHighlight(self.LastHighlightGameObject, true);
            }
        }
    }
}