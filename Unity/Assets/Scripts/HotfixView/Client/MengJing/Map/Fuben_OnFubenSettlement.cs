using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Fuben_OnFubenSettlement : AEvent<Scene, FubenSettlement>
    {
        protected override async ETTask Run(Scene scene, FubenSettlement args)
        {
            UIComponent uiComponent = scene.GetComponent<UIComponent>();
            DlgMain dlgMain = uiComponent.GetDlgLogic<DlgMain>();
            Button buttonReturn = dlgMain.View.E_Btn_RerurnBuildingButton;
            buttonReturn.enabled = false;

            await scene.GetComponent<TimerComponent>().WaitAsync(1000);
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            int sceneTypeEnum = mapComponent.MapType;
            if (sceneTypeEnum == (int)MapTypeEnum.MainCityScene)
            {
                return;
            }

            switch (sceneTypeEnum)
            {
                case MapTypeEnum.PetDungeon:
                    int star = 0;
                    for (int i = 0; i < args.m2C_FubenSettlement.StarInfos.Count; i++)
                    {
                        star += args.m2C_FubenSettlement.StarInfos[i];
                    }

                    if (args.m2C_FubenSettlement.BattleResult == 1)
                    {
                        scene.GetComponent<PetComponentC>().OnPassPetFuben(mapComponent.SonSceneId, star);
                    }

                    uiComponent.GetDlgLogic<DlgPetMain>().OnFubenResult(args.m2C_FubenSettlement);
                    await uiComponent.ShowWindowAsync(WindowID.WindowID_PetFubenResult);
                    uiComponent.GetDlgLogic<DlgPetFubenResult>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case MapTypeEnum.Tower:
                    DlgTowerOpen dlgTowerOpen = uiComponent.GetDlgLogic<DlgTowerOpen>();
                    if (dlgTowerOpen != null)
                    {
                        dlgTowerOpen.OnFubenResult(args.m2C_FubenSettlement).Coroutine();
                    }

                    break;
                case MapTypeEnum.PetMing:
                    await uiComponent.ShowWindowAsync(WindowID.WindowID_PetFubenResult);
                    uiComponent.GetDlgLogic<DlgPetFubenResult>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case MapTypeEnum.PetTianTi:
                    FlyTipComponent.Instance.ShowFlyTip("宠物天梯对战结束！！！");

                    uiComponent.GetDlgLogic<DlgPetMain>().OnFubenResult(args.m2C_FubenSettlement);
                    await uiComponent.ShowWindowAsync(WindowID.WindowID_PetFubenResult);
                    uiComponent.GetDlgLogic<DlgPetFubenResult>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case MapTypeEnum.RandomTower:
                    // ui = await UIHelper.Create(args.Scene, UIType.UIRandomTowerResult);
                    // ui.GetComponent<UIRandomTowerResultComponent>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case MapTypeEnum.TrialDungeon:
                    scene.GetComponent<UIComponent>().GetDlgLogic<DlgTrialMain>().StopTimer();
                    PopupTipHelp.OpenPopupTip_2(scene, args.m2C_FubenSettlement.BattleResult == CombatResultEnum.Win ? "胜利" : "失败",
                        "恭喜你赢得了本场试炼的胜利！",
                        () => { EnterMapHelper.RequestQuitFuben(scene); }).Coroutine();
                    break;
                case MapTypeEnum.SealTower:
                    DlgTowerOfSealMain dlgTowerOfSealMain = scene.GetComponent<UIComponent>().GetDlgLogic<DlgTowerOfSealMain>();
                    dlgTowerOfSealMain.ShowStartBtn();
                    Unit myUnit = UnitHelper.GetMyUnitFromClientScene(scene);
                    myUnit.GetComponent<SkillManagerComponentC>().ClearSkillAndCd();
                    dlgMain.DlgMainReset(sceneTypeEnum);
                    break;
                case MapTypeEnum.SeasonTower:
                    await uiComponent.ShowWindowAsync(WindowID.WindowID_PetFubenResult);
                    uiComponent.GetDlgLogic<DlgPetFubenResult>().OnUpdateUI(args.m2C_FubenSettlement);
                    break;
                case MapTypeEnum.CellDungeon:
                case MapTypeEnum.DragonDungeon:
                    await uiComponent.ShowWindowAsync(WindowID.WindowID_CellDungeonSettlement);
                    uiComponent.GetDlgLogic<DlgCellDungeonSettlement>().OnUpdateUI(args.m2C_FubenSettlement, sceneTypeEnum).Coroutine();
                    break;
                case MapTypeEnum.PetMelee:
                    star = 0;
                    for (int i = 0; i < args.m2C_FubenSettlement.StarInfos.Count; i++)
                    {
                        star += args.m2C_FubenSettlement.StarInfos[i];
                    }

                    if (args.m2C_FubenSettlement.BattleResult == 1)
                    {
                        scene.GetComponent<PetComponentC>().OnPassPetMeleeFuben(mapComponent.SceneId, star);
                    }
                    
                    scene.GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>().Stop();
                    PopupTipHelp.OpenPopupTip_2(scene, args.m2C_FubenSettlement.BattleResult == CombatResultEnum.Win ? "胜利" : "失败",
                        args.m2C_FubenSettlement.BattleResult == CombatResultEnum.Win ? "宠物乱斗胜利" : "宠物乱斗失败",
                        () => { EnterMapHelper.RequestQuitFuben(scene); }).Coroutine();
                    break;
                case MapTypeEnum.PetMatch:
                    star = 0;
                    for (int i = 0; i < args.m2C_FubenSettlement.StarInfos.Count; i++)
                    {
                        star += args.m2C_FubenSettlement.StarInfos[i];
                    }
                    scene.GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>().Stop();
                    PopupTipHelp.OpenPopupTip_2(scene, args.m2C_FubenSettlement.BattleResult == CombatResultEnum.Win ? "胜利" : "失败",
                        args.m2C_FubenSettlement.BattleResult == CombatResultEnum.Win ? "宠物决战胜利" : "宠物决战失败",
                        () => { EnterMapHelper.RequestQuitFuben(scene); }).Coroutine();
                    break;
                default:
                    break;
            }

            buttonReturn.enabled = true;
            await ETTask.CompletedTask;
        }
    }
}