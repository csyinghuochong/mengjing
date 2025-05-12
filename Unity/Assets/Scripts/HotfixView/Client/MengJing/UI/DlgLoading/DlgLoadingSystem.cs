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
            Log.Debug("DlgLoading   egisterUIEvent");
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
                "Back_5",
                // "Back_7",
                // "Back_11",
                // "Back_13",
                // "Back_14",
                // "Back_15"
            };
            int index = RandomHelper.RandomNumber(0, backpngs.Count);
            self.StartLoadAssets = false;
            switch (sceneTypeEnum)
            {
                case MapTypeEnum.MainCityScene:
                    // if (!ResourcesComponent.Instance.LoadCommonAsset)
                    // {
                    //     ResourcesComponent.Instance.LoadCommonAsset = true;
                    //     self.PreLoadAssets.AddRange(self.GetCommonAssets());
                    // }

                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(chapterId);
                    loadResName = !CommonHelp.IfNull(sceneConfig.LoadingRes) ? sceneConfig.LoadingRes : "Back_5";
                    break;
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.BaoZang:
                case MapTypeEnum.MiJing:
                case MapTypeEnum.Tower:
                case MapTypeEnum.RandomTower:
                case MapTypeEnum.TrialDungeon:
                case MapTypeEnum.PetDungeon:
                case MapTypeEnum.PetTianTi:
                case MapTypeEnum.PetMing:
                case MapTypeEnum.Battle:
                case MapTypeEnum.Arena: 
                case MapTypeEnum.SealTower:
                case MapTypeEnum.PetMelee:
                case MapTypeEnum.PetMatch:
                    sceneConfig = SceneConfigCategory.Instance.Get(chapterId);
                    loadResName = !CommonHelp.IfNull(sceneConfig.LoadingRes) ? sceneConfig.LoadingRes : backpngs[index];
                    self.PreLoadAssets.AddRange(self.GetRoleSkillEffect());
                    self.PreLoadAssets.AddRange(self.GetSceneDungeonMonsters());
                    break;
                case MapTypeEnum.LocalDungeon:
                    DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(chapterId);
                    loadResName = !CommonHelp.IfNull(dungeonConfig.LoadingRes) ? dungeonConfig.LoadingRes : backpngs[index];
                    
                    self.PreLoadAssets.AddRange(self.GetRoleSkillEffect());
                    self.PreLoadAssets.AddRange(self.GetLocalDungeonMonsters());
                    break;
                case MapTypeEnum.CellDungeon:
                    CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(chapterId);
                    loadResName = !CommonHelp.IfNull(cellGenerateConfig.LoadingRes) ? cellGenerateConfig.LoadingRes : backpngs[index];
                    self.PreLoadAssets.AddRange(self.GetRoleSkillEffect());
                    self.PreLoadAssets.AddRange(self.GetCommonAssets());
                    break;
                case MapTypeEnum.DragonDungeon:
                    cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(chapterId);
                    loadResName = !CommonHelp.IfNull(cellGenerateConfig.LoadingRes) ? cellGenerateConfig.LoadingRes : backpngs[index];
                    break;
                default:
                    loadResName = backpngs[index];
                    break;
            }

            var path = ABPathHelper.GetJpgPath(loadResName);
            Sprite atlas = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            if (atlas == null)
            {
                path = ABPathHelper.GetJpgPath(backpngs[0]);
                atlas = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            }

            self.View.E_Back_1Image.sprite = atlas;
            self.View.E_Back_1Image.gameObject.SetActive(true);
            self.AssetPath = path;

            self.PassTime = 0f;
            self.ChapterId = sceneTypeEnum == (int)MapTypeEnum.CellDungeon ? chapterId : 0;
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
            if (!SceneConfigHelper.UseSceneConfig(mapComponent.MapType) || mapComponent.MapType != MapTypeEnum.TeamDungeon)
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
            int fangunSkill = GlobalValueConfigCategory.Instance.FangunSkillId;
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
                await self.Root().GetComponent<GameObjectLoadComponent>().PreLoadQueue(self.PreLoadAssets[i]);
                self.PreLoadAssets.RemoveAt(i);
            }
        }

        public static void ShowProgress(this DlgLoading self, float progress)
        {
            progress = Mathf.Min(1f, Mathf.Max(progress, 0f));
            self.View.E_Img_LodingValueImage.fillAmount = progress;
            self.View.E_ImageEffect.localPosition = new Vector3(-750+ 1500 *progress, 89.4f, 0f );
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
                case MapTypeEnum.LocalDungeon:
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
                case MapTypeEnum.CellDungeon:
                    dlgMain.OnCellDungeonEnterShow(self.ChapterId);
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.PetDungeon:
                case MapTypeEnum.PetTianTi:
                case MapTypeEnum.PetMing:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.zero;
                    break;
                case MapTypeEnum.Tower:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TowerOpen).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.RandomTower:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RandomOpen).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.Happy:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_HappyMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.SingleHappy:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SingleHappyMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.Battle:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_BattleMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.Arena:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ArenaMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.DragonDungeon:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_EnterMapHint).Coroutine();
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.TeamDungeon:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_EnterMapHint).Coroutine();
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.TrialDungeon:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TrialMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.SealTower:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TowerOfSealMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.JiaYuan:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_JiaYuanMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.RunRace:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RunRaceMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.Demon:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DemonMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.MiJing:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_MiJingMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.SeasonTower:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SeasonMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.one;
                    break;
                case MapTypeEnum.PetMatch:
                case MapTypeEnum.PetMelee:
                    self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMeleeMain).Coroutine();
                    dlgMain.View.uiTransform.localScale = Vector3.zero;
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

                int sceneType = self.Root().GetComponent<MapComponent>().MapType;
                self.UpdateMainUI(sceneType);

                Camera camera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
                camera.GetComponent<Camera>().fieldOfView = 50;

                //播放传送特效
                if (sceneType != MapTypeEnum.MainCityScene
                    && sceneType != MapTypeEnum.PetMelee
                    && sceneType != MapTypeEnum.PetMatch)
                {
                    FunctionEffect.PlaySelfEffect(UnitHelper.GetMyUnitFromClientScene(self.Root()), 200004);
                }

                Transform topTf = main.GetComponent<HeroTransformComponent>()?.GetTranform(PosType.Head)?.transform;
                Transform mainTf = main.GetComponent<GameObjectComponent>()?.GameObject?.transform;
                main.Root().GetComponent<SceneUnitManagerComponent>().InitMainHero(main.Position, main.Id);
                MapViewHelper.OnMainHeroInit(main.Root(), topTf, mainTf, sceneType);

                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Loading);
            }
            catch (Exception ex)
            {
                Log.Error("UILoading1: " + ex.ToString());
            }
        }
    }
}