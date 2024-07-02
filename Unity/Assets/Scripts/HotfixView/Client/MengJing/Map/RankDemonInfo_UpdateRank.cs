namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class RankDemonInfo_UpdateRank: AEvent<Scene, RankDemonInfo>
    {
        protected override async ETTask Run(Scene scene, RankDemonInfo args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgDemonMain>()?.UpdateRanking(args.M2CRankDemonMessage);

            await ETTask.CompletedTask;
        }
    }
}