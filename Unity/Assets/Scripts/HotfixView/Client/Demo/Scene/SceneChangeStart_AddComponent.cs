using System;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class SceneChangeStart_AddComponent: AEvent<Scene, SceneChangeStart>
    {
        protected override async ETTask Run(Scene root, SceneChangeStart args)
        {
            try
            {
                Scene currentScene = root.CurrentScene();

                UIComponent uiComponent = root.GetComponent<UIComponent>();
                DlgMain dlgMain = uiComponent.GetDlgLogic<DlgMain>();
                if (dlgMain != null)
                {
                    uiComponent.CloseWindow(WindowID.WindowID_MapBig);
                    dlgMain.BeginEnterScene(args.LastSceneType);
                }

                switch (args.LastSceneType)
                {
                    case SceneTypeEnum.PetTianTi:
                    case SceneTypeEnum.PetDungeon:
                    case SceneTypeEnum.PetMing:
                        // UIHelper.Remove(args.ZoneScene, UIType.UIPetMain);
                        break;
                    case SceneTypeEnum.LocalDungeon:
                        DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(args.LastChapterId);
                        switch (dungeonConfig.MapType)
                        {
                            case SceneSubTypeEnum.LocalDungeon_1:
                                // UIHelper.Remove(args.ZoneScene, UIType.UIDungeonHappyMain);
                                break;
                            default:
                                break;
                        }

                        break;
                    case SceneTypeEnum.Tower:
                        // UIHelper.Remove(args.ZoneScene, UIType.UITowerOpen);
                        break;
                    case SceneTypeEnum.Happy:
                        // UIHelper.Remove(args.ZoneScene, UIType.UIHappyMain);
                        break;
                    case SceneTypeEnum.Battle:
                        // UIHelper.Remove(args.ZoneScene, UIType.UIBattleMain);
                        break;
                    case SceneTypeEnum.Arena:
                        // UIHelper.Remove(args.ZoneScene, UIType.UIArenaMain);
                        break;
                    case SceneTypeEnum.TeamDungeon:
                        // UIHelper.Remove(args.ZoneScene, UIType.UITeamMain);
                        break;
                    case SceneTypeEnum.TrialDungeon:
                        // UIHelper.Remove(args.ZoneScene, UIType.UITrialMain);
                        break;
                    // case SceneTypeEnum.TowerOfSeal:
                    //     UIHelper.Remove(args.ZoneScene, UIType.UITowerOfSealMain);
                    //     break;
                    case SceneTypeEnum.JiaYuan:
                        // UIHelper.Remove(args.ZoneScene, UIType.UIJiaYuanMain);
                        break;
                    case SceneTypeEnum.RunRace:
                        // UIHelper.Remove(args.ZoneScene, UIType.UIRunRaceMain);
                        break;
                    case SceneTypeEnum.Demon:
                        // UIHelper.Remove(args.ZoneScene, UIType.UIDemonMain);
                        break;
                    case SceneTypeEnum.MiJing:
                        // UIHelper.Remove(args.ZoneScene, UIType.UIMiJingMain);
                        break;
                    case SceneTypeEnum.SeasonTower:
                        // UIHelper.Remove(args.ZoneScene, UIType.UISeasonMain);
                        break;
                    default:
                        break;
                }

                ResourcesLoaderComponent resourcesLoaderComponent = currentScene.GetComponent<ResourcesLoaderComponent>();

                string sceneName = currentScene.Name;
                MapComponent mapComponent = root.GetComponent<MapComponent>();
                if (SceneConfigHelper.UseSceneConfig(args.SceneType))
                {
                    sceneName = SceneConfigCategory.Instance.Get(mapComponent.SceneId).MapID.ToString();
                }

                // 加载场景资源
                await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/{sceneName}.unity", LoadSceneMode.Single);
                // 切换到map场景

                //await SceneManager.LoadSceneAsync(currentScene.Name);

                currentScene.AddComponent<OperaComponent>();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}