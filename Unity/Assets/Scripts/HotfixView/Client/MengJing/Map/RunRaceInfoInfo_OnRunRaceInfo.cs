namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class RunRaceInfoInfo_OnRunRaceInfo: AEvent<Scene, RunRaceInfo>
    {
        protected override async ETTask Run(Scene scene, RunRaceInfo args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgRunRaceMain>()?.UpdateRanking(args.M2CRankRunRaceMessage.RankList);

            await ETTask.CompletedTask;
        }
    }
}