using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.HighLightTimer)]
    public class HighLightTimer : ATimer<GameObjectComponent>
    {
        protected override void Run(GameObjectComponent self)
        {
            try
            {
                self.OnResetShader();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [Invoke(TimerInvokeType.DelayShowTimer)]
    public class DelayShowTimer : ATimer<GameObjectComponent>
    {
        protected override void Run(GameObjectComponent self)
        {
            try
            {
                if (self.IsDisposed)
                {
                    return;
                }

                self.ShowGameObject();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof(GameObjectComponent))]
    [EntitySystemOf(typeof(GameObjectComponent))]
    public static partial class GameObjectComponentSystem
    {
        [EntitySystem]
        private static void Destroy(this GameObjectComponent self)
        {
            self.OnResetShader();
            self.RecoverHorse();
            self.RecoverGameObject();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.HighLightTimer);
            self.Root().GetComponent<TimerComponent>().Remove(ref self.DelayShowTimer);
        }

        [EntitySystem]
        private static void Awake(this GameObjectComponent self)
        {
            self.GameObject = null;
            self.Material = null;
            self.OldShader = null;
            self.UnitAssetsPath = string.Empty;
            self.DelayShow = 0;
            self.BianShenEffect = false;
            self.LoadGameObject();
        }

        public static void RecoverGameObject(this GameObjectComponent self)
        {
            if (self.GameObject != null)
            {
                self.GameObject.transform.localScale = Vector3.one;
            }

            if (string.IsNullOrEmpty(self.UnitAssetsPath) && self.GameObject != null)
            {
                UnityEngine.Object.Destroy(self.GameObject);
            }

            if (!string.IsNullOrEmpty(self.UnitAssetsPath))
            {
                if (self.Dissolve)
                {
                    self.ShowDissolve(true).Coroutine();
                }
                else
                {
                    self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.UnitAssetsPath, self.GameObject);
                }
            }

            self.GameObject = null;
        }

        public static async ETTask ShowDissolve(this GameObjectComponent self, bool recover)
        {
            Scene root = self.Root();
            self.Dissolve = false;
            string unitAssetsPath = self.UnitAssetsPath;
            GameObject gameObject = self.GameObject;

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(1000); // 延迟1秒播放
            if (gameObject == null)
            {
                return;
            }

            MaterialManager[] materialManagers = gameObject.transform.GetComponentsInChildren<MaterialManager>();
            foreach (MaterialManager materialManager in materialManagers)
            {
                materialManager.Switch("Dissolve");
            }

            long duration = 1500; // 持续时间
            List<SkinnedMeshRenderer> renderers = new List<SkinnedMeshRenderer>(gameObject.GetComponentsInChildren<SkinnedMeshRenderer>());
            List<Material> materials = new List<Material>();
            foreach (var renderer in renderers)
            {
                materials.AddRange(renderer.materials);
            }

            long elapsedTime = 0;
            long interval = 30;
            while (elapsedTime < duration)
            {
                elapsedTime += interval;
                float m_DissolveAmount = elapsedTime * 1f / duration;
                foreach (var mat in materials)
                {
                    mat.SetFloat("_DissolveAmount", m_DissolveAmount);
                }

                await timerComponent.WaitAsync(interval);
            }

            foreach (MaterialManager materialManager in materialManagers)
            {
                materialManager.RestoreOriginalMaterials();
            }

            if (recover)
            {
                root.GetComponent<GameObjectLoadComponent>().RecoverGameObject(unitAssetsPath, gameObject);
            }
        }

        public static void LoadGameObject(this GameObjectComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            int unitType = unit.Type;

            switch (unitType)
            {
                case UnitType.Player:
                    MapComponent mapComponent = unit.Root().GetComponent<MapComponent>();
                    //宠物副本不显示玩家
                    if (mapComponent.MapType == MapTypeEnum.PetDungeon
                            || mapComponent.MapType == MapTypeEnum.PetTianTi
                            || mapComponent.MapType == MapTypeEnum.PetMing)
                    {
                        return;
                    }

                    NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
                    int runmonsterId = numericComponent.GetAsInt(NumericType.RunRaceTransform);
                    int cardtransform = numericComponent.GetAsInt(NumericType.CardTransform);
                    int showmonsterId = cardtransform > 0 ? cardtransform : runmonsterId;
                    if (showmonsterId > 0)
                    {
                        MonsterConfig runmonsterCof = MonsterConfigCategory.Instance.Get(showmonsterId);
                        self.UnitAssetsPath =  ABPathHelper.GetUnitPath("Monster/" + runmonsterCof.MonsterModelID);;
                    }
                    
                    if (string.IsNullOrEmpty(self.UnitAssetsPath))
                    {
                        self.UnitAssetsPath = ABPathHelper.GetUnitPath($"Player/{OccupationConfigCategory.Instance.Get(unit.ConfigId).ModelAsset}");
                    }
                    break;
                case UnitType.Stall:
                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Player/BaiTan");
                    break;
                case UnitType.Monster:
                    int monsterId = unit.ConfigId;
                    MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(monsterId);
                    int userMaterModel = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.UseMasterModel);
                    long masterId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.MasterId);
                    Unit master = unit.GetParent<UnitComponent>().Get(masterId);
                    numericComponent = unit.GetComponent<NumericComponentC>();
                    self.UnitAssetsPath = string.Empty;
                    int nowdead = numericComponent.GetAsInt(NumericType.Now_Dead);
                    if (nowdead == 1)
                    {
                        showmonsterId = 800001;
                    }
                    else
                    {
                        showmonsterId = numericComponent.GetAsInt(NumericType.CardTransform);
                    }
                    if (showmonsterId > 0)
                    {
                        MonsterConfig runmonsterCof = MonsterConfigCategory.Instance.Get(showmonsterId);
                        self.UnitAssetsPath =  ABPathHelper.GetUnitPath("Monster/" + runmonsterCof.MonsterModelID);;
                    }

                    if (string.IsNullOrEmpty(self.UnitAssetsPath))
                    {
                        if (userMaterModel == 1 && master != null
                            && master.GetComponent<GameObjectComponent>() != null
                            && master.GetComponent<GameObjectComponent>().GameObject != null)
                        {
                            //GameObject gameObject = GameObject.Instantiate(master.GetComponent<GameObjectComponent>().GameObject);
                            //self.OnLoadGameObject(gameObject, self.InstanceId);
                        }
                        else if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_58)
                        {
                            //path = ABPathHelper.GetUnitPath("Pet/" + monsterCof.MonsterModelID);
                            int itemid = monsterCof.Parameter[1];
                            int petskinId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetSkin);
                            self.UnitAssetsPath = ABPathHelper.GetUnitPath("Pet/" + PetSkinConfigCategory.Instance.Get(petskinId).SkinID);
                        }
                        else if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_59)
                        {
                            self.UnitAssetsPath = ABPathHelper.GetUnitPath("JingLing/" + monsterCof.MonsterModelID);
                        }
                        else
                        {
                            self.UnitAssetsPath = StringBuilderHelper.GetMonsterUnitPath(monsterCof.MonsterModelID);
                        }
                    }

                    Log.Debug($"monster: id:{unit.Id}   instanceid:{self.InstanceId}   UnitAssetsPath：{self.UnitAssetsPath}");
                    break;
                case UnitType.Pet:
                    int skinId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetSkin);
                    int configId = unit.ConfigId;
                    PetConfig petConfig = PetConfigCategory.Instance.Get(configId);
                    if (skinId == 0)
                    {
                        skinId = petConfig.Skin[0];
                    }

                    PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(skinId);
                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Pet/" + petSkinConfig.SkinID.ToString());
                    ;
                    break;
                case UnitType.Bullet: //从特效里面加载
                    int skillid = unit.ConfigId;
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
                    EffectConfig effectConfig = EffectConfigCategory.Instance.Get(skillConfig.SkillEffectID[0]);
                    self.DelayShow = (long)(1000 * effectConfig.SkillEffectDelayTime);
                    self.UnitAssetsPath = ABPathHelper.GetEffetPath("SkillEffect/" + effectConfig.EffectName);
                    break;
                case UnitType.Npc:
                    int npcId = unit.ConfigId;
                    NpcConfig config = NpcConfigCategory.Instance.Get(npcId);
                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Npc/" + config.Asset);
                    break;
                case UnitType.DropItem:
                    DropComponentC dropComponent = unit.GetComponent<DropComponentC>();
                    string assetPath = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DropItemId) == 1 ? "DropICoin" : "DropItem";
                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Player/" + assetPath);
                    break;
                case UnitType.Transfers:
                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Monster/DorrWay_1");
                    break;
                case UnitType.CellTransfers:
                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Monster/DorrWay_1");
                    break;
                case UnitType.JingLing:
                    JingLingConfig jingLing = JingLingConfigCategory.Instance.Get(unit.ConfigId);
                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("JingLing/" + jingLing.Assets);
                    break;
                case UnitType.Plant:
                    self.OnUpdatePlan();
                    break;
                case UnitType.Pasture:
                    JiaYuanPastureConfig jiaYuanPastureConfig = JiaYuanPastureConfigCategory.Instance.Get(unit.ConfigId);
                    self.UnitAssetsPath = ABPathHelper.GetUnitPath("Pasture/" + jiaYuanPastureConfig.Assets);
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(self.UnitAssetsPath))
            {
                self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( self.UnitAssetsPath, self.InstanceId, false, self.OnLoadGameObject);
            }
        }

        public static void OnUpdatePlan(this GameObjectComponent self)
        {
            self.RecoverGameObject();
            Unit unit = self.GetParent<Unit>();
            JiaYuanFarmConfig jiaYuanFarmConfig = JiaYuanFarmConfigCategory.Instance.Get(unit.ConfigId);
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long startTime = numericComponent.GetAsLong(NumericType.StartTime);
            int gatherNumber = numericComponent.GetAsInt(NumericType.GatherNumber);
            int planStage = ET.JiaYuanHelper.GetPlanStage(unit.ConfigId, startTime, gatherNumber);
            // string path = ABPathHelper.GetUnitPath($"JiaYuan/{jiaYuanFarmConfig.ModelID + planStage}");
            string path = ABPathHelper.GetUnitPath($"JiaYuan/100101");
            unit.RemoveComponent<UIJiaYuanPlanComponent>();
            unit.RemoveComponent<JiaYuanPlanEffectComponent>();
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( path, self.InstanceId, true, self.OnLoadGameObject);
        }

        public static void RecoverHorse(this GameObjectComponent self)
        {
            if (self.ObjectHorse != null)
            {
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.HorseAssetsPath, self.ObjectHorse);
                self.ObjectHorse = null;
            }
        }

        public static void UpdateRotation(this GameObjectComponent self, Quaternion quaternion)
        {
            if (self.ObjectHorse != null)
            {
                self.ObjectHorse.transform.rotation = quaternion;
                return;
            }

            if (self.GameObject != null)
            {
                self.GameObject.transform.rotation = quaternion;
            }
        }

        public static void UpdatePositon(this GameObjectComponent self, Vector3 vector)
        {
            if (self.ObjectHorse != null)
            {
                self.ObjectHorse.transform.position = vector;
                return;
            }

            if (self.GameObject != null)
            {
                self.GameObject.transform.position = vector;
            }
        }

        public static void OnLoadHorse(this GameObjectComponent self, GameObject go, long formId)
        {
            if (self.IsDisposed || self.InstanceId != formId)
            {
                GameObject.Destroy(go);
                return;
            }

            if (go == null)
            {
                return;
            }

            self.ObjectHorse = go;
            Unit unit = self.GetParent<Unit>();
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            if (numericComponent.GetAsInt(NumericType.RunRaceTransform) > 0
                || numericComponent.GetAsInt(NumericType.CardTransform) > 0)
            {
                return;
            }

            int horseRide = numericComponent.GetAsInt(NumericType.HorseRide);
            if (horseRide != 0)
            {
                self.OnShangMa(go, horseRide);
            }
            else
            {
                self.OnXiaMa();
            }
        }

        public static void ShowRoleDi(this GameObjectComponent self, bool show)
        {
            //GameObject di = self.GameObject.transform.Find("fake shadow (5)").gameObject;
            //di.SetActive(show);
        }

        public static void CheckRunState(this GameObjectComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            bool run = moveComponent != null && !moveComponent.IsArrived();
            if (run)
            {
                unit.GetComponent<FsmComponent>().OnEnterFsmRunState();
            }
        }

        public static void OnShangMa(this GameObjectComponent self, GameObject go, int horseId)
        {
            if (self.GameObject == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            CommonViewHelper.SetParent(go, self.Root().GetComponent<GlobalComponent>().Unit.gameObject);
            go.SetActive(true);
            go.transform.localPosition = unit.Position;
            go.transform.rotation = unit.Rotation;


            unit.GetComponent<FsmComponent>()?.SetHorseState();
            try
            {
                unit.GetComponent<AnimatorComponent>()?.UpdateAnimator(go);
                unit.GetComponent<AnimationComponent>()?.UpdateAnimData(go);
            }
            catch (Exception ex)
            {
                Log.Error($"OnShangMaError:  {ex.ToString()}");
            }
            CommonViewHelper.SetParent(self.GameObject, HoreseHelper.GetHorseNode(self.ObjectHorse));
            self.GameObject.transform.localScale = HoreseHelper.GetRoleScale(go, horseId) * Vector3.one;
            //特殊处理
            if (horseId == 10008)
            {
                self.GameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
            }

            
            self.ShowRoleDi(false);
            self.CheckRunState();
        }

        public static void OnXiaMa(this GameObjectComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            self.RecoverHorse();
            Unit unit = self.GetParent<Unit>();
            CommonViewHelper.SetParent(self.GameObject, self.Root().GetComponent<GlobalComponent>().Unit.gameObject);
            self.UpdatePositon(self.GetParent<Unit>().Position);
            unit.GetComponent<AnimatorComponent>()?.UpdateAnimator(self.GameObject);
            unit.GetComponent<AnimationComponent>()?.UpdateAnimData(self.GameObject);
            self.ShowRoleDi(true);
            self.CheckRunState();
        }

        public static void OnUpdateHorse(this GameObjectComponent self)
        {
            if (self.GameObject == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            if (numericComponent.GetAsInt(NumericType.RunRaceTransform) > 0
                || numericComponent.GetAsInt(NumericType.CardTransform) > 0)
            {
                return;
            }

            int horseRide = numericComponent.GetAsInt(NumericType.HorseRide);
            if (horseRide != 0)
            {
                MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
                if (SceneConfigHelper.UseSceneConfig(mapComponent.MapType))
                {
                    int sceneid = mapComponent.SceneId;
                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);
                    if (sceneConfig.IfMount == 1)
                    {
                        return;
                    }
                }

                ZuoQiShowConfig zuoQiShowConfig = ZuoQiShowConfigCategory.Instance.Get(horseRide);
                self.HorseAssetsPath = ABPathHelper.GetUnitPath($"ZuoQi/{zuoQiShowConfig.ModelID}");
                self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.HorseAssetsPath, self.InstanceId, true, self.OnLoadHorse);
            }
            else
            {
                self.OnXiaMa();
            }
        }

        public static void OnAddCollider(this GameObjectComponent self, GameObject go)
        {
            if (go.GetComponent<Collider>() == null)
            {
                BoxCollider box = go.AddComponent<BoxCollider>();
                box.size = new Vector3(1f, 2f, 1f);
                box.center = new Vector3(0f, 1f, 0f);
            }
        }

        public static void ShowGameObject(this GameObjectComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            if (unit.Type != UnitType.Monster)
            {
                self.GameObject.SetActive(true);
                return;
            }

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
            if (monsterConfig.IfHide != 1)
            {
                self.GameObject.SetActive(true);
                return;
            }
            // long masterId = unit.GetMasterId();
            // Unit mainUnit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            // self.GameObject.SetActive(masterId == mainUnit.Id || unit.IsSameTeam(mainUnit) );
        }

        public static void OnLoadGameObject(this GameObjectComponent self, GameObject go, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.Destroy(go);
                return;
            }

            if (self.GameObject != null)
            {
                Log.Error($" self.GameObject !=null:   {self.GameObject.name}    {go.name}   {self.InstanceId}   {formId}");
                return;
            }

            self.GameObject = go;
            self.InitMaterial();
            if (self.DelayShow > 0)
            {
                go.SetActive(false);
                self.Root().GetComponent<TimerComponent>().Remove(ref self.DelayShowTimer);
                self.DelayShowTimer = self.Root().GetComponent<TimerComponent>()
                        .NewOnceTimer(TimeHelper.ServerNow() + self.DelayShow, TimerInvokeType.DelayShowTimer, self);
            }
            else
            {
                self.ShowGameObject();
            }

            Unit unit = self.GetParent<Unit>();
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            switch (unit.Type)
            {
                case UnitType.Player:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    
                    LayerHelp.ChangeLayer(go.transform, LayerEnum.Player);
                    self.OnAddCollider(go);
                    NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
                    int weaponid = numericComponent.GetAsInt(NumericType.Now_Weapon);
                    List<int> fashionids = unit.GetComponent<UnitInfoComponent>().FashionEquipList;
                    go.transform.name = unit.Id.ToString();
                    
                    if (SettingData.AnimController == 0)
                    {
                        unit.AddComponent<AnimatorComponent>();
                    }
                    else
                    {
                        unit.AddComponent<AnimationComponent>();
                    }
                    
                    // 客户端寻路组件
                    unit.OnMainHeroPath(mapComponent);
                    
                    unit.AddComponent<FsmComponent>(); //当前状态组建
                    unit.AddComponent<HeroTransformComponent>(); //获取角色绑点组件
                    unit.AddComponent<EffectViewComponent>(); //添加特效组建
                    unit.AddComponent<SkillYujingComponent>();
                    unit.AddComponent<UIPlayerHpComponent>();
                    unit.GetComponent<BuffManagerComponentC>()?.InitBuff();
                    unit.GetComponent<SkillManagerComponentC>()?.InitSkill();

                    if (SceneConfigHelper.IsCanRideHorse(mapComponent.MapType))
                    {
                        self.OnUpdateHorse();
                    }

                    int cardtransform = numericComponent.GetAsInt(NumericType.CardTransform);
                    int runmonsterId = numericComponent.GetAsInt(NumericType.RunRaceTransform); 
                    if (cardtransform == 0 && runmonsterId == 0)
                    {
                        unit.AddComponent<ChangeEquipComponent>().InitWeapon(fashionids, unit.ConfigId, weaponid);
                        unit.OnUnitStallUpdate(numericComponent.GetAsLong(NumericType.Now_Stall));
                    }
                    if (unit.MainHero && cardtransform > 0)
                    {
                        self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnCardTranfer(cardtransform);
                    }
                    if (unit.MainHero&& runmonsterId > 0)
                    {
                        self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.View.ES_MainSkill.OnRunRaceTranfer(runmonsterId);
                    }
                    
                    StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
                    if (stateComponent.StateTypeGet(StateTypeEnum.Stealth))
                    {
                        self.EnterStealth();
                    }
                    
                    if (stateComponent.StateTypeGet(StateTypeEnum.Hide)
                        || mapComponent.MapType == MapTypeEnum.PetMelee
                        || mapComponent.MapType == MapTypeEnum.PetMatch)
                    {
                        unit.EnterHide();
                    }

                    if (numericComponent.GetAsInt(NumericType.Now_Dead) == 1)
                    {
                        EventSystem.Instance.Publish(self.Root(), new UnitDead() { Unit = unit, Wait = false});
                    }
                    
                    if (self.BianShenEffect)
                    {
                        self.BianShenEffect = false;
                        FunctionEffect.PlaySelfEffect(unit, 30000002);
                    }

                    break;
                case UnitType.Stall:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    LayerHelp.ChangeLayer(go.transform, LayerEnum.Player);
                    self.OnAddCollider(go);
                    go.name = unit.Id.ToString();
                    if (SettingData.AnimController == 0)
                    {
                        unit.AddComponent<AnimatorComponent>();
                    }
                    else
                    {
                        unit.AddComponent<AnimationComponent>().UpdateAnimData(go);
                    }

                    unit.AddComponent<HeroTransformComponent>();
                    unit.AddComponent<UIStallHpComponent>(true);
                    break;
                case UnitType.Monster:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    go.transform.name = unit.Id.ToString();
                    MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                    unit.AddComponent<EffectViewComponent>(true); //添加特效组建
                    if (monsterCof.AI != 0)
                    {
                        LayerHelp.ChangeLayer(go.transform, LayerEnum.Monster);
                        self.OnAddCollider(go);

                        if (SettingData.AnimController == 0)
                        {
                            unit.AddComponent<AnimatorComponent>();
                        }
                        else
                        {
                            unit.AddComponent<AnimationComponent>();
                        }

                        unit.AddComponent<FsmComponent>(true); //当前状态组建
                        unit.AddComponent<SkillYujingComponent>(true);
                    }

                    if (monsterCof.MonsterType == (int)MonsterTypeEnum.Boss)
                    {
                        unit.AddComponent<MonsterActRangeComponent, int>(monsterCof.Id, true); //血条UI组件

                        mapComponent = self.Root().GetComponent<MapComponent>();
                        bool shenYuan = mapComponent.MapType == MapTypeEnum.TeamDungeon && mapComponent.FubenDifficulty == TeamFubenType.ShenYuan;
                        go.transform.localScale = shenYuan ? Vector3.one * 1.3f : Vector3.one;
                    }
                    
                    if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_51)
                    {
                    }
                    else if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_52 || monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_54)
                    {
                        self.OnAddCollider(go);
                        unit.AddComponent<HeroTransformComponent>(true); //获取角色绑点组件
                        unit.AddComponent<UISceneItemComponent>(true).OnInitUI(); //血条UI组件
                    }
                    else if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_58 || monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_59)
                    {
                        self.OnAddCollider(go);
                        unit.AddComponent<UISceneItemComponent>(true).OnInitUI(); //血条UI组件
                        LayerHelp.ChangeLayer(go.transform, LayerEnum.Monster);

                        if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_58)
                        {
                            //实例化特效
                            FunctionEffect.PlaySelfEffect(unit, 91000106);
                        }

                        if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_59)
                        {
                            //实例化特效
                            FunctionEffect.PlaySelfEffect(unit, 91000107);
                        }
                    }
                    else if (unit.IsChest() || monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_60)
                    {
                        self.OnAddCollider(go);
                        unit.AddComponent<UISceneItemComponent>(true).OnInitUI(); //血条UI组件
                        LayerHelp.ChangeLayer(go.transform, LayerEnum.Box);
                    }
                    else if (monsterCof.MonsterSonType == MonsterSonTypeEnum.Type_61)
                    {
                        self.OnAddCollider(go);
                        unit.AddComponent<UISceneItemComponent>(true).OnInitUI(); //血条UI组件
                        LayerHelp.ChangeLayer(go.transform, LayerEnum.Monster);
                    }
                    else if (monsterCof.MonsterType != MonsterTypeEnum.SceneItem)
                    {
                        unit.AddComponent<HeroTransformComponent>(true); //获取角色绑点组件
                        unit.AddComponent<UIMonsterHpComponent>(true); //血条UI组件
                    }
                    
                    unit.GetComponent<BuffManagerComponentC>()?.InitBuff();
                    unit.GetComponent<SkillManagerComponentC>()?.InitSkill();
                    numericComponent = unit.GetComponent<NumericComponentC>();
                    // if (numericComponent.GetAsInt(NumericType.Now_Dead) == 1)
                    // {
                    //     EventSystem.Instance.Publish(self.Root(), new UnitDead() { Unit = unit});
                    // }
                    // else
                    // {
                    //    
                    // }
                    break;
                case UnitType.Pet:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    go.transform.name = unit.Id.ToString();
                    unit.AddComponent<EffectViewComponent>(); //添加特效组建
                    if (SettingData.AnimController == 0)
                    {
                        unit.AddComponent<AnimatorComponent>();
                    }
                    else
                    {
                        unit.AddComponent<AnimationComponent>();
                    }

                    unit.AddComponent<HeroTransformComponent>(); //获取角色绑点组件
                    unit.AddComponent<FsmComponent>(); //当前状态组建
                    unit.AddComponent<UIPetHpComponent>(); //血条UI组件
                    self.OnAddCollider(go);
                    LayerHelp.ChangeLayer(go.transform, LayerEnum.Monster);
                    
                    if (mapComponent.MapType == MapTypeEnum.PetMelee)
                    {
                        FunctionEffect.PlaySelfEffect(unit, 200004);
                    }
                    break;
                case UnitType.Npc:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    LayerHelp.ChangeLayer(go.transform, LayerEnum.NPC);
                    self.OnAddCollider(go);
                    go.name = unit.ConfigId.ToString();
                    if (SettingData.AnimController == 0)
                    {
                        unit.AddComponent<AnimatorComponent>();
                    }
                    else
                    {
                        unit.AddComponent<AnimationComponent>();
                    }

                    unit.AddComponent<HeroTransformComponent>();
                    unit.AddComponent<UINpcHpComponent>();
                    unit.AddComponent<FsmComponent>();
                    unit.AddComponent<EffectViewComponent>();
                    break;
                case UnitType.DropItem:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    go.name = unit.Id.ToString();
                    unit.AddComponent<EffectViewComponent>();
                    unit.AddComponent<UIDropComponent>().InitData();
                    break;
                case UnitType.Transfers:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    go.name = unit.Id.ToString();
                    unit.AddComponent<UITransferHpComponent>().OnInitUI(unit.ConfigId).Coroutine();
                    break;
                case UnitType.CellTransfers:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    go.name = unit.Id.ToString();
                    // switch (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.DirectionType))
                    // {
                    //     case 1: //上
                    //         go.transform.localRotation = Quaternion.Euler(-90, 0, 180); //设置旋转
                    //         break;
                    //     case 2: //左
                    //         go.transform.localRotation = Quaternion.Euler(-90, 0, 90); //设置旋转
                    //         break;
                    //     case 3: //下
                    //         go.transform.localRotation = Quaternion.Euler(-90, 0, 0); //设置旋转
                    //         break;
                    //     case 4: //右
                    //         go.transform.localRotation = Quaternion.Euler(-90, 0, -90); //设置旋转
                    //         break;
                    //     default:
                    //         break;
                    // }
                    unit.AddComponent<UICellTransferHpComponent>().OnInitUI(mapComponent.MapType);
                    break;
                case UnitType.JingLing:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    go.transform.name = unit.Id.ToString();
                    unit.AddComponent<EffectViewComponent>(); //添加特效组建
                    if (SettingData.AnimController == 0)
                    {
                        unit.AddComponent<AnimatorComponent>();
                    }
                    else
                    {
                        unit.AddComponent<AnimationComponent>();
                    }

                    unit.AddComponent<HeroTransformComponent>(); //获取角色绑点组件
                    unit.AddComponent<FsmComponent>(); //当前状态组建
                    unit.AddComponent<UIJingLingHpComponent>(); //血条UI组件
                    break;
                case UnitType.Pasture:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    LayerHelp.ChangeLayer(go.transform, LayerEnum.Monster);
                    self.OnAddCollider(go);
                    go.transform.name = unit.Id.ToString();
                    unit.AddComponent<EffectViewComponent>(); //添加特效组建
                    if (SettingData.AnimController == 0)
                    {
                        unit.AddComponent<AnimatorComponent>();
                    }
                    else
                    {
                        unit.AddComponent<AnimationComponent>();
                    }

                    unit.AddComponent<HeroTransformComponent>(); //获取角色绑点组件
                    unit.AddComponent<FsmComponent>(); //当前状态组建
                    unit.AddComponent<UIJiaYuanPastureComponent>(); //血条UI组件
                    break;
                case UnitType.Plant:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    go.transform.name = unit.Id.ToString();
                    go.transform.localScale = Vector3.one * 10f;
                    unit.AddComponent<UIJiaYuanPlanComponent>();
                    unit.AddComponent<JiaYuanPlanEffectComponent>();
                    break;
                case UnitType.Bullet:
                    CommonViewHelper.SetParent(go, globalComponent.Unit.gameObject);
                    go.name = unit.Id.ToString();
                    go.transform.localPosition = unit.Position;
                    go.transform.rotation = unit.Rotation;
                    break;
                default:
                    break;
            }

            if (unit.Type == UnitType.Bullet)
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(unit.ConfigId);
                if (skillConfig.GameObjectName.Equals(ConfigData.Skill_ComTargetMove_RangDamge_7))
                {
                    long masterid = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.MasterId);
                    unit.AddComponent<RoleBullet7Componnet>().OnBaseBulletInit(masterid);
                }
            }
        }

        public static void InitMaterial(this GameObjectComponent self)
        {
            if (self.Material == null)
            {
                SkinnedMeshRenderer skinnedMeshRenderer = self.GameObject.GetComponentInChildren<SkinnedMeshRenderer>();
                if (skinnedMeshRenderer == null)
                {
                    return;
                }

                Material[] materials = skinnedMeshRenderer.materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    if (materials[i].shader == null)
                    {
                        continue;
                    }

                    if (materials[i].shader.name.Equals(StringBuilderData.ToonBasic))
                    {
                        self.Material = materials[i];
                        self.OldShader = StringBuilderData.ToonBasic;
                        break;
                    }

                    //     // if (materials[i].shader.name.Equals("Toon/BasicOutlineNew"))
                    //     // {
                    //     //     self.Material = materials[i];
                    //     //     break;
                    //     // }
                    // }
                }
            }
        }

        public static void ShowWeapon(this GameObjectComponent self)
        {
            //GameObject xxxxx = null;
            //if (self.GameObject.GetComponent<ReferenceCollector>() != null)
            //{
            //    xxxxx = self.GameObject.Get<GameObject>("xxxxx");
            //}
            //if (xxxxx != null)
            //{
            //    // 武器隐形
            //    MeshRenderer[] meshRenderers = xxxxx.GetComponentsInChildren<MeshRenderer>();

            //    foreach (MeshRenderer meshRenderer in meshRenderers)
            //    {
            //        meshRenderer.material.shader = GlobalHelp.Find(StringBuilderHelper.SimpleAlpha);
            //        meshRenderer.material.SetFloat("_Alpha", alpha);
            //    }
            //}
        }

        /// <summary>
        /// public static string ToonBasic = "Toon/Basic";  
        /// public static string ToonBasicOutline = "Toon/BasicOutline";
        /// </summary>
        /// <param name="self"></param>
        public static void OnHighLight(this GameObjectComponent self)
        {
            if (GlobalHelp.GetBigVersion() < 15)
            {
                return;
            }

            if (self.Material != null)
            {
                self.Material.shader = GlobalHelp.Find(StringBuilderData.Ill_HighLight);
                // self.Material.SetInt("_Type", 1);
                //self.Material.shader = GlobalHelp.Find(StringBuilderHelper.Ill_RimLight);     //第二种效果  高亮
                TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
                timerComponent.Remove(ref self.HighLightTimer);
                self.HighLightTimer = timerComponent.NewOnceTimer(TimeHelper.ServerNow() + 120, TimerInvokeType.HighLightTimer, self);
            }
        }

        public static void OnResetShader(this GameObjectComponent self)
        {
            if (GlobalHelp.GetBigVersion() < 15)
            {
                return;
            }

            if (self.Material != null)
            {
                self.Material.shader = GlobalHelp.Find(self.OldShader);
                // self.Material.SetInt("_Type", 0);
            }
        }

        public static void EnterHide(this GameObjectComponent self)
        {
            if (self.GameObject != null)
            {
                self.GameObject.SetActive(false);
            }

            if (self.ObjectHorse != null)
            {
                self.ObjectHorse.SetActive(false);
            }
            
        }

        public static void EnterBaTi(this GameObjectComponent self)
        {
            if (self.GameObject == null || self.Material == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            // OutlineComponent outlineComponent = unit.GetComponent<OutlineComponent>();
            // if (outlineComponent != null)
            // {
            //     outlineComponent.OnEnable();
            // }
            // else
            // {
            //     outlineComponent = unit.AddComponent<OutlineComponent>();
            // }
        }

        public static void ExitBaTi(this GameObjectComponent self)
        {
            if (self.GameObject == null || self.Material == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            // OutlineComponent outlineComponent = unit.GetComponent<OutlineComponent>();
            // if (outlineComponent != null)
            // {
            //     outlineComponent.OnDisable();
            // }
        }

        public static void ExitHide(this GameObjectComponent self)
        {
            if (self.GameObject != null)
            {
                self.GameObject.SetActive(true);
            }

            if (self.ObjectHorse != null)
            {
                self.ObjectHorse.SetActive(true);
            }

            self.CheckRunState();
        }

        /// <summary>
        /// 进入隐身
        /// </summary>
        /// <param name="self"></param>
        public static void EnterStealth(this GameObjectComponent self)
        {
            Shader shader = GlobalHelp.Find(StringBuilderData.SimpleAlpha);
            if (shader == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            float alpha = 1f;
            // 对自己半透明
            if (unit.Id == UnitHelper.GetMyUnitId(unit.Root()))
            {
                alpha = 0.3f;
            }
            // 对别人透明
            else
            {
                alpha = 0f;
            }

            // 身体隐形
            self.Material.shader = shader;
            self.Material.SetFloat("_Alpha", alpha);

            // 脚底阴影隐形
            // if (self.GameObject.transform.Find("fake shadow (5)") != null)
            // {
            //     GameObject di = self.GameObject.transform.Find("fake shadow (5)").gameObject;
            //     Color oldColorDi = di.GetComponent<MeshRenderer>().material.color;
            //     di.GetComponent<MeshRenderer>().material.color = new Color(oldColorDi.r, oldColorDi.g, oldColorDi.b, alpha);
            // }

            // 脚底Buff隐形
            foreach (Effect aEffectHandler in unit.GetComponent<EffectViewComponent>().Effects)
            {
                if (aEffectHandler.EffectConfig.Id >= 80000001 && aEffectHandler.EffectConfig.Id <= 80000006)
                {
                    ParticleSystem particleSystem = aEffectHandler.EffectObj.GetComponentInChildren<ParticleSystem>();
                    if (particleSystem != null)
                    {
                        Material material = particleSystem.GetComponent<Renderer>().material;
                        if (material.HasProperty("_TintColor"))
                        {
                            Color oldColor = material.GetColor("_TintColor");
                            oldColor.a = alpha;
                            material.SetColor("_TintColor", oldColor);
                        }
                    }
                }
            }

            unit.GetComponent<UIPlayerHpComponent>().EnterStealth(alpha);
        }

        /// <summary>
        /// 退出隐身
        /// </summary>
        /// <param name="self"></param>
        public static void ExitStealth(this GameObjectComponent self)
        {
            Unit unit = self.GetParent<Unit>();

            Log.Debug($"ExitStealth: {unit.Id}");

            //退出隐身
            self.Material.shader = GlobalHelp.Find(self.OldShader);

            // 脚底阴影恢复
            //GameObject di = null;
            // if (self.GameObject.transform.Find("fake shadow (5)") != null)
            // {
            //     di = self.GameObject.transform.Find("fake shadow (5)").gameObject;
            //     Color oldColorDi = di.GetComponent<MeshRenderer>().material.color;
            //     di.GetComponent<MeshRenderer>().material.color = new Color(oldColorDi.r, oldColorDi.g, oldColorDi.b, 0.5f);
            // }

            // 脚底Buff恢复
            foreach (var entity in unit.GetComponent<EffectViewComponent>().Children)
            {
                Effect aEffectHandler = (Effect)entity.Value;
                if (aEffectHandler.EffectConfig.Id >= 80000001 && aEffectHandler.EffectConfig.Id <= 80000006)
                {
                    ParticleSystem particleSystem = aEffectHandler.EffectObj.GetComponentInChildren<ParticleSystem>();
                    if (particleSystem != null)
                    {
                        Material material = particleSystem.GetComponent<Renderer>().material;
                        if (material.HasProperty("_TintColor"))
                        {
                            Color oldColor = material.GetColor("_TintColor");
                            oldColor.a = 0.5f;
                            material.SetColor("_TintColor", oldColor);
                        }
                    }
                }
            }

            // 血条恢复
            unit.GetComponent<UIPlayerHpComponent>().ExitStealth();
        }

        public static void OnRevive(this GameObjectComponent self)
        {
            
            self.OnTranferHandler(0, true);
            
            self.LoadGameObject();
        }

        
        public static void OnDead(this GameObjectComponent self)
        {
            self.OnTranferHandler(0, true);
            
            self.LoadGameObject();
        }

        
        /// <summary>
        /// 变身卡
        /// </summary>
        /// <param name="self"></param>
        /// <param name="monsterid"></param>
        /// <param name="remove"></param>
        public static void OnCardTranfer(this GameObjectComponent self, int monsterid)
        {
            Unit unit = self.GetParent<Unit>();

            self.BianShenEffect = unit.MainHero;
            self.OnTranferHandler(monsterid, true);
            
            self.LoadGameObject();
        }

        /// <summary>
        /// 奔跑大赛变身
        /// </summary>
        public static void OnRunRaceTranfer(this GameObjectComponent self, int monsterid)
        {
            Unit unit = self.GetParent<Unit>();
            self.BianShenEffect = unit.MainHero;
            self.OnTranferHandler(monsterid, true);
            
            self.LoadGameObject();
        }

        public static void OnTranferHandler(this GameObjectComponent self, int monsterid, bool remove)
        {
            self.RecoverGameObject();
            self.Material = null;
            Unit unit = self.GetParent<Unit>();
            if (remove)
            {
                unit.RemoveComponent<ChangeEquipHelper>();
                unit.RemoveComponent<HeroTransformComponent>(); //获取角色绑点组件
                unit.RemoveComponent<AnimatorComponent>();
                unit.RemoveComponent<AnimationComponent>();
                unit.RemoveComponent<FsmComponent>(); //当前状态组建
                unit.RemoveComponent<EffectViewComponent>(); //添加特效组建
                unit.RemoveComponent<SkillYujingComponent>();
                unit.RemoveComponent<UIPlayerHpComponent>();
                unit.RemoveComponent<UIMonsterHpComponent>();
                unit.RemoveComponent<MonsterActRangeComponent>();   
            }
        }
        
    }
}