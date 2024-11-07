using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UILoadingTimer)]
    public class UILoadingTimer : ATimer<DlgLoading>
    {
        protected override void Run(DlgLoading self)
        {
            try
            {
                self.Update();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }


    [FriendOf(typeof(DlgMainViewComponent))]
    [FriendOf(typeof(DlgLoading))]
    public static class DlgLoadingSystem
    {
        public static void RegisterUIEvent(this DlgLoading self)
        {
            ConfigData.LoadSceneFinished = false;
        }

        public static void ShowWindow(this DlgLoading self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgLoading self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnInitUI(this DlgLoading self, int lastScene, int sceneTypeEnum, int chapterId)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UILoadingTimer, self);

            // UnitFactory.LoadingScene = true;
            string loadResName = "MainCity";
            List<string> backpngs = new List<string>()
            {
                "Back_6",
                "Back_7",
                "Back_11",
                "Back_13",
                "Back_14",
                "Back_15"
            };
            int index = RandomHelper.RandomNumber(0, backpngs.Count);
            self.StartLoadAssets = false;
            switch (sceneTypeEnum)
            {
                case (int)SceneTypeEnum.MainCityScene:
                    // if (!ResourcesComponent.Instance.LoadCommonAsset)
                    // {
                    //     ResourcesComponent.Instance.LoadCommonAsset = true;
                    //     self.PreLoadAssets.AddRange(self.GetCommonAssets());
                    // }

                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(chapterId);
                    loadResName = !CommonHelp.IfNull(sceneConfig.LoadingRes) ? sceneConfig.LoadingRes : "MainCity";
                    break;
                case (int)SceneTypeEnum.CellDungeon:
                    loadResName = backpngs[index];
                    self.PreLoadAssets.AddRange(self.GetRoleSkillEffect());
                    self.PreLoadAssets.AddRange(self.GetCommonAssets());
                    break;
                case (int)SceneTypeEnum.TeamDungeon:
                case (int)SceneTypeEnum.BaoZang:
                case (int)SceneTypeEnum.MiJing:
                case (int)SceneTypeEnum.Tower:
                case (int)SceneTypeEnum.RandomTower:
                case (int)SceneTypeEnum.TrialDungeon:
                case (int)SceneTypeEnum.PetDungeon:
                case (int)SceneTypeEnum.PetTianTi:
                case (int)SceneTypeEnum.PetMing:
                case (int)SceneTypeEnum.Battle:
                case (int)SceneTypeEnum.Arena:
                    loadResName = backpngs[index];
                    sceneConfig = SceneConfigCategory.Instance.Get(chapterId);
                    loadResName = !CommonHelp.IfNull(sceneConfig.LoadingRes) ? sceneConfig.LoadingRes : "MainCity";
                    self.PreLoadAssets.AddRange(self.GetRoleSkillEffect());
                    self.PreLoadAssets.AddRange(self.GetSceneDungeonMonsters());
                    break;
                case (int)SceneTypeEnum.LocalDungeon:
                    loadResName = backpngs[index];
                    self.PreLoadAssets.AddRange(self.GetRoleSkillEffect());
                    self.PreLoadAssets.AddRange(self.GetLocalDungeonMonsters());
                    break;
                default:
                    loadResName = backpngs[index];
                    break;
            }

            if (!loadResName.Equals("MainCity"))
            {
                // var path = ABPathHelper.GetJpgPath(loadResName);
                // Sprite atlas = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                // self.View.E_Back_1Image.sprite = atlas;
                // self.View.E_Back_1Image.gameObject.SetActive(true);
                // self.AssetPath = path;
            }

            self.PassTime = 0f;
            self.ChapterId = sceneTypeEnum == (int)SceneTypeEnum.CellDungeon ? chapterId : 0;
        }

        public static List<string> GetMonstersModelAndEffect(this DlgLoading self, List<int> monsterIds)
        {
            List<string> assets = new List<string>();

            for (int i = 0; i < monsterIds.Count; i++)
            {
                int monsterId = monsterIds[i];

                MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(monsterId);
                var path = ABPathHelper.GetUnitPath("Monster/" + monsterCof.MonsterModelID);
                if (!assets.Contains(path))
                {
                    assets.Add(path);
                }

                if (monsterCof.MonsterType != MonsterTypeEnum.Boss)
                {
                    continue;
                }

                int[] aiSkillIDList = monsterCof.SkillID;
                if (aiSkillIDList == null)
                {
                    continue;
                }

                for (int s = 0; s < aiSkillIDList.Length; s++)
                {
                    if (aiSkillIDList[s] == 0)
                    {
                        continue;
                    }

                    if (!SkillConfigCategory.Instance.Contain(aiSkillIDList[s]))
                    {
                        continue;
                    }

                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(aiSkillIDList[s]);
                    int effectId = skillConfig.SkillEffectID[0];
                    if (effectId == 0)
                    {
                        continue;
                    }

                    string effectName = $"SkillEffect/{EffectConfigCategory.Instance.Get(effectId).EffectName}";
                    effectName = ABPathHelper.GetEffetPath(effectName);
                    if (!assets.Contains(effectName))
                    {
                        assets.Add(effectName);
                    }
                }
            }

            return assets;
        }

        public static List<string> GetLocalDungeonMonsters(this DlgLoading self)
        {
            int mapid = self.Root().GetComponent<MapComponent>().SceneId;
            List<int> monsterIds = SceneConfigHelper.GetLocalDungeonMonsters(mapid);
            return self.GetMonstersModelAndEffect(monsterIds);
        }

        public static List<string> GetSceneDungeonMonsters(this DlgLoading self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (!SceneConfigHelper.UseSceneConfig(mapComponent.SceneType) || mapComponent.SceneType != SceneTypeEnum.TeamDungeon)
            {
                return new List<string>();
            }

            int mapid = mapComponent.SceneId;
            List<int> monsterIds = SceneConfigHelper.GetSceneMonsterList(mapid);
            return self.GetMonstersModelAndEffect(monsterIds);
        }

        public static List<string> GetRoleSkillEffect(this DlgLoading self)
        {
            List<string> effects = new List<string>();
            int fangunSkill = int.Parse(GlobalValueConfigCategory.Instance.Get(2).Value);
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            List<SkillPro> allskills = new List<SkillPro>();
            allskills.AddRange(skillSetComponent.SkillList);
            SkillPro skillProNew = SkillPro.Create();
            skillProNew.SkillID = fangunSkill;
            skillProNew.SkillPosition = 100;
            skillProNew.SkillSetType = (int)SkillSetEnum.Skill;
            allskills.Add(skillProNew);

            for (int i = 0; i < allskills.Count; i++)
            {
                SkillPro skillPro = allskills[i];
                if (skillPro.SkillPosition == 0)
                {
                    continue;
                }

                if (skillPro.SkillSetType != (int)SkillSetEnum.Skill)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillPro.SkillID);
                if (skillConfig.SkillEffectID.Length > 0 && skillConfig.SkillEffectID[0] != 0)
                {
                    if (!EffectConfigCategory.Instance.Contain(skillConfig.SkillEffectID[0]))
                    {
                        continue;
                    }

                    EffectConfig effectConfig = EffectConfigCategory.Instance.Get(skillConfig.SkillEffectID[0]);
                    effects.Add(ABPathHelper.GetEffetPath("SkillEffect/" + effectConfig.EffectName));
                }

                if (skillConfig.SkillHitEffectID != 0)
                {
                    EffectConfig effectConfig = EffectConfigCategory.Instance.Get(skillConfig.SkillHitEffectID);
                    effects.Add(ABPathHelper.GetEffetPath("SkillHitEffect/" + effectConfig.EffectName));
                }
            }

            return effects;
        }

        public static List<string> GetCommonAssets(this DlgLoading self)
        {
            List<string> effects = new List<string>()
            {
                // ABPathHelper.GetUGUIPath(UIType.UIRole),
                // ABPathHelper.GetUGUIPath(UIType.UIPet),
                // ABPathHelper.GetUGUIPath("Blood/UIDropItem"),
                // ABPathHelper.GetUGUIPath("Blood/UIBattleFly"),
                // ABPathHelper.GetUGUIPath("Blood/UIMonsterHp"),
                // ABPathHelper.GetUGUIPath("Main/Role/UIRoleBag"),
                // ABPathHelper.GetUGUIPath("Common/UIModelShow1"),
                // ABPathHelper.GetUGUIPath("Main/Common/UICommonItem"),
                // ABPathHelper.GetUGUIPath("Main/Pet/UIPetList"),
                // ABPathHelper.GetUGUIPath("Main/Pet/UIPetListItem"),
            };
            return effects;
        }

        public static async ETTask StartPreLoadAssets(this DlgLoading self)
        {
            for (int i = self.PreLoadAssets.Count - 1; i >= 0; i--)
            {
                await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(self.PreLoadAssets[i]);
                self.PreLoadAssets.RemoveAt(i);
            }

            List<string> commonassets = self.GetCommonAssets();
            for (int i = 0; i < self.ReleaseAssets.Count; i++)
            {
                if (commonassets.Contains(self.ReleaseAssets[i]))
                {
                    continue;
                }

                self.Root().GetComponent<ResourcesLoaderComponent>().UnLoadAsset(self.ReleaseAssets[i]);
            }
        }

        public static void ShowProgress(this DlgLoading self, float progress)
        {
            progress = Mathf.Min(1f, Mathf.Max(progress, 0f));
            self.View.E_Img_LodingValueImage.fillAmount = progress;
            using (zstring.Block())
            {
                self.View.E_Lab_TextText.text = zstring.Format("{0}%", (int)(progress * 100));
            }
        }

        public static void UpdateMainUI(this DlgLoading self, int sceneTypeEnum)
        {
            DlgMain dlgMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
            dlgMain.AfterEnterScene(sceneTypeEnum);
            switch (sceneTypeEnum)
            {
                case SceneTypeEnum.LocalDungeon:
                    int mapid = self.Root().GetComponent<MapComponent>().SceneId;
                    int subType = DungeonConfigCategory.Instance.Get(mapid).MapType;
                    switch (subType)
                    {
                        case SceneSubTypeEnum.LocalDungeon_1:
                            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DungeonHappyMain).Coroutine();
                            dlgMain.View.uiTransform.localScale = Vector3.one;
                            break;
                        default:
                            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_EnterMapHint).Coroutine();
                            break;
                    }

                    break;
                case SceneTypeEnum.CellDungeon:
                    dlgMain.OnCellDungeonEnterShow(self.ChapterId);
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.PetDungeon:
                case SceneTypeEnum.PetTianTi:
                case SceneTypeEnum.PetMing:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.zero;
                    break;
                case SceneTypeEnum.Tower:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TowerOpen).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.RandomTower:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RandomOpen).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.Happy:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_HappyMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.Battle:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_BattleMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.Arena:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ArenaMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.TeamDungeon:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_EnterMapHint).Coroutine();
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.TrialDungeon:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TrialMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.SealTower:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TowerOfSealMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.JiaYuan:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.RunRace:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RunRaceMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.Demon:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DemonMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.MiJing:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_MiJingMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.SeasonTower:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SeasonMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case SceneTypeEnum.PetMelee:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMeleeMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                default:
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
            }
        }

        public static void Update(this DlgLoading self)
        {
            try
            {
                if (self.Program < 0.3)
                {
                    self.Program += Time.deltaTime * 0.1f;
                }

                if (!ConfigData.LoadSceneFinished)
                {
                    self.ShowProgress(self.Program);
                    return;
                }

                if (!self.StartLoadAssets)
                {
                    self.StartLoadAssets = true;
                    self.StartPreLoadAssets().Coroutine();
                    UnitFactory.ShowAllUnit(self.Root()).Coroutine();
                }

                if (self.PreLoadAssets.Count > 0)
                {
                    self.ShowProgress(0.8f);
                    return;
                }
                else
                {
                    self.View.E_Img_LodingValueImage.fillAmount = 1f;
                    self.View.E_Lab_TextText.text = "100%";
                }

                self.PassTime += Time.deltaTime;
                self.ShowProgress(0.9f + self.PassTime * 0.1f);

                if (self.PassTime < 1.5f)
                {
                    return;
                }

                Unit main = UnitHelper.GetMyUnitFromClientScene(self.Root());
                if (main == null)
                {
                    return;
                }

                DlgMain uimain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>();
                if (uimain == null)
                {
                    return;
                }

                int sceneType = self.Root().GetComponent<MapComponent>().SceneType;
                self.UpdateMainUI(sceneType);

                Camera camera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
                camera.GetComponent<Camera>().fieldOfView = 50;

                //播放传送特效
                if (sceneType != SceneTypeEnum.MainCityScene)
                {
                    FunctionEffect.PlaySelfEffect(UnitHelper.GetMyUnitFromClientScene(self.Root()), 200004);
                }

                GameObjectComponent gameObjectComponent = main.GetComponent<GameObjectComponent>();
                Transform topTf = main.GetComponent<HeroTransformComponent>().GetTranform(PosType.Head).transform;
                main.Root().GetComponent<SceneUnitManagerComponent>().InitMainHero(main.Id);
                MapViewHelper.OnMainHeroInit(main.Root(), topTf, gameObjectComponent.GameObject.transform, sceneType);

                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Loading);
            }
            catch (Exception ex)
            {
                Log.Error("UILoading1: " + ex.ToString());
            }
        }
    }
}