using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Fuben_OnFubenSettlement: AEvent<Scene, FubenSettlement>
    {
        protected override async ETTask Run(Scene scene, FubenSettlement args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            DlgMain dlgMain = uiComponent.GetDlgLogic<DlgMain>();
            Button buttonReturn = dlgMain.View.E_Btn_RerurnBuildingButton;
            buttonReturn.enabled = false;

            await scene.GetComponent<TimerComponent>().WaitAsync(1000);
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            int sceneTypeEnum = mapComponent.SceneType;
            if (sceneTypeEnum == (int)SceneTypeEnum.MainCityScene)
            {
                return;
            }

            switch (sceneTypeEnum)
            {
                case SceneTypeEnum.PetDungeon:
                    int star = 0;
                    for (int i = 0; i < args.m2C_FubenSettlement.StarInfos.Count; i++)
                    {
                        star += args.m2C_FubenSettlement.StarInfos[i];
                    }

                    if (args.m2C_FubenSettlement.BattleResult == 1)
                    {
                        scene.GetComponent<PetComponentC>().OnPassPetFuben(mapComponent.SonSceneId, star);
                    }

                    // UIHelper.GetUI(args.Scene, UIType.UIPetMain).GetComponent<DlgPetMain>().OnFubenResult(args.m2C_FubenSettlement);
                    // UI ui = await UIHelper.Create(args.Scene, UIType.UIPetFubenResult);
                    // ui.GetComponent<UIPetFubenResultComponent>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case SceneTypeEnum.Tower:
                    // ui = UIHelper.GetUI(args.Scene, UIType.UITowerOpen);
                    // if (ui != null)
                    // {
                    //     ui.GetComponent<UITowerOpenComponent>()?.OnFubenResult(args.m2C_FubenSettlement).Coroutine();
                    // }

                    break;
                case SceneTypeEnum.PetMing:
                    // ui = await UIHelper.Create(args.Scene, UIType.UIPetFubenResult);
                    // ui.GetComponent<UIPetFubenResultComponent>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case SceneTypeEnum.PetTianTi:
                    FlyTipComponent.Instance.ShowFlyTip("宠物天梯对战结束！！！");

                    // UIHelper.GetUI(args.Scene, UIType.UIPetMain).GetComponent<UIPetMainComponent>().OnFubenResult(args.m2C_FubenSettlement);
                    // ui = await UIHelper.Create(args.Scene, UIType.UIPetFubenResult);
                    // ui.GetComponent<UIPetFubenResultComponent>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case SceneTypeEnum.RandomTower:
                    // ui = await UIHelper.Create(args.Scene, UIType.UIRandomTowerResult);
                    // ui.GetComponent<UIRandomTowerResultComponent>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case SceneTypeEnum.TrialDungeon:
                    scene.GetComponent<UIComponent>().GetDlgLogic<DlgTrialMain>().StopTimer();
                    PopupTipHelp.OpenPopupTip_2(scene, args.m2C_FubenSettlement.BattleResult == CombatResultEnum.Win? "胜利" : "失败",
                        "恭喜你赢得了本场试炼的胜利！",
                        () => { EnterMapHelper.RequestQuitFuben(scene); }).Coroutine();
                    break;
                // case SceneTypeEnum.TowerOfSeal:
                //     UI uITowerOfSealMain = UIHelper.GetUI(args.Scene, UIType.UITowerOfSealMain);
                //     uITowerOfSealMain.GetComponent<UITowerOfSealMainComponent>().StartBtn.SetActive(true);
                //     Unit myUnit = UnitHelper.GetMyUnitFromZoneScene(args.Scene);
                //     myUnit.GetComponent<SkillManagerComponent>().ClearSkillAndCd();
                //     UI uiMain = UIHelper.GetUI(args.Scene, UIType.UIMain);
                //     uimain.GetComponent<UIMainComponent>().BeginEnterScene(sceneTypeEnum);
                //     break;
                case SceneTypeEnum.SeasonTower:
                    // ui = await UIHelper.Create(args.Scene, UIType.UIPetFubenResult);
                    // ui.GetComponent<UIPetFubenResultComponent>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                default:
                    // ui = await UIHelper.Create(args.Scene, UIType.UICellDungeonSettlement);
                    // ui.GetComponent<UICellDungeonSettlementComponent>().OnUpdateUI(args.m2C_FubenSettlement).Coroutine();
                    break;
            }

            buttonReturn.enabled = true;
            await ETTask.CompletedTask;
        }
    }
}