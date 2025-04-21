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
                
                Log.Debug($"SceneChangeStart:  {args.LastSceneType}");

                switch (args.LastSceneType)
                {
                    case MapTypeEnum.PetTianTi:
                    case MapTypeEnum.PetDungeon:
                    case MapTypeEnum.PetMing:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMain);
                        break;
                    case MapTypeEnum.LocalDungeon:
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
                    case MapTypeEnum.Tower:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerOpen);
                        break;
                    case MapTypeEnum.Happy:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_HappyMain);
                        break;
                    case MapTypeEnum.SingleHappy:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SingleHappyMain);
                        break;
                    case MapTypeEnum.Battle:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_BattleMain);
                        break;
                    case MapTypeEnum.Arena:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ArenaMain);
                        break;
                    case MapTypeEnum.TeamDungeon:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamMain);
                        break;
                    case MapTypeEnum.DragonDungeon:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamMain);
                        break;
                    case MapTypeEnum.TrialDungeon:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TrialMain);
                        break;
                    case MapTypeEnum.SealTower:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerOfSealMain);
                        break;
                    case MapTypeEnum.JiaYuan:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMain);
                        break;
                    case MapTypeEnum.RunRace:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RunRaceMain);
                        break;
                    case MapTypeEnum.Demon:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DemonMain);
                        break;
                    case MapTypeEnum.MiJing:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MiJingMain);
                        break;
                    case MapTypeEnum.SeasonTower:
                        root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SeasonMain);
                        break;
                    case MapTypeEnum.PetMelee:
                    case MapTypeEnum.PetMatch:
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