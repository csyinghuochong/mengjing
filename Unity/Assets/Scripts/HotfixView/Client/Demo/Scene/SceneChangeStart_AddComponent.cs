using System;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class SceneChangeStart_AddComponent: AEvent<Scene, SceneChangeStart>
    {
        protected override async ETTask Run(Scene root, SceneChangeStart args)
        {
            try
            {
                root.GetComponent<SceneManagerComponent>().BeforeChangeScene();
                        
                UIComponent uiComponent = root.GetComponent<UIComponent>();
                await uiComponent.ShowWindowAsync(WindowID.WindowID_Loading);
                uiComponent.GetDlgLogic<DlgLoading>().OnInitUI(args.LastSceneType, args.SceneType, args. ChapterId);

                DlgMain dlgMain = uiComponent.GetDlgLogic<DlgMain>();
                if (dlgMain != null)
                {
                    uiComponent.CloseWindow(WindowID.WindowID_MapBig);
                    dlgMain.BeforeEnterScene(args.LastSceneType);
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
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamMain);
                        break;
                    case SceneTypeEnum.DragonDungeon:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamMain);
                        break;
                    case SceneTypeEnum.TrialDungeon:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TrialMain);
                        break;
                    case SceneTypeEnum.SealTower:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerOfSealMain);
                        break;
                    case SceneTypeEnum.JiaYuan:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMain);
                        break;
                    case SceneTypeEnum.RunRace:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RunRaceMain);
                        break;
                    case SceneTypeEnum.Demon:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DemonMain);
                        break;
                    case SceneTypeEnum.MiJing:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MiJingMain);
                        break;
                    case SceneTypeEnum.SeasonTower:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SeasonMain);
                        break;
                    case SceneTypeEnum.PetMelee:
                    case SceneTypeEnum.PetMatch:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMeleeMain);
                        break;
                    default:
                        break;
                }

                root.GetComponent<SceneUnitManagerComponent>().BeginEnterScene();
                await root.GetComponent<SceneManagerComponent>().ChangeScene(args.SceneType, args.LastSceneType, args.ChapterId);

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}