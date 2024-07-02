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

                await uiComponent.ShowWindowAsync(WindowID.WindowID_Loading);
                uiComponent.GetDlgLogic<DlgLoading>().OnInitUI(args.LastSceneType, args.SceneType, args.ChapterId);

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
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMain);
                        break;
                    case SceneTypeEnum.LocalDungeon:
                        DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(args.LastChapterId);
                        switch (dungeonConfig.MapType)
                        {
                            case SceneSubTypeEnum.LocalDungeon_1:
                                root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonHappyMain);
                                break;
                            default:
                                break;
                        }

                        break;
                    case SceneTypeEnum.Tower:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerOpen);
                        break;
                    case SceneTypeEnum.Happy:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_HappyMain);
                        break;
                    case SceneTypeEnum.Battle:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_BattleMain);
                        break;
                    case SceneTypeEnum.Arena:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ArenaMain);
                        break;
                    case SceneTypeEnum.TeamDungeon:
                        // UIHelper.Remove(args.ZoneScene, UIType.UITeamMain);
                        break;
                    case SceneTypeEnum.TrialDungeon:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TrialMain);
                        break;
                    // case SceneTypeEnum.TowerOfSeal:
                    //     UIHelper.Remove(args.ZoneScene, UIType.UITowerOfSealMain);
                    //     break;
                    case SceneTypeEnum.JiaYuan:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMain);
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

                await root.GetComponent<SceneManagerComponent>().ChangeScene(args.SceneType, args.LastSceneType, args.ChapterId);

                currentScene.AddComponent<OperaComponent>();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}