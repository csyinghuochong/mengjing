namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Union_OnUnionRaceInfo : AEvent<Scene, UnionRaceInfo>
    {
        protected override async ETTask Run(Scene scene, UnionRaceInfo args)
        {
            PopupTipHelp.OpenPopupTip_2(scene, "争霸赛结束", "争霸赛已结束，请及时退出结算奖励!", () => { EnterMapHelper.RequestQuitFuben(scene); })
                    .Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
