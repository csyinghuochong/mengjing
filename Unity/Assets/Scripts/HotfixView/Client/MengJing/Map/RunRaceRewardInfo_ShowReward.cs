namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class RunRaceRewardInfo_ShowReward: AEvent<Scene, RunRaceRewardInfo>
    {
        protected override async ETTask Run(Scene scene, RunRaceRewardInfo args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>()?.OnUpdateUI(args.M2CRankRunRaceReward.RewardList);
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRunRaceMain>()?.WaitExitFuben();

            await ETTask.CompletedTask;
        }
    }
}