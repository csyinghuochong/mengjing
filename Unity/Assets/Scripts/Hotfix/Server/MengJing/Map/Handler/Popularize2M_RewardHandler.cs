namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class Popularize2M_RewardHandler : MessageHandler<Unit, Popularize2M_RewardRequest, M2Popularize_RewardResponse>
    {
        protected override async ETTask Run(Unit unit, Popularize2M_RewardRequest request, M2Popularize_RewardResponse response)
        {
            unit.GetComponent<BagComponentS>().OnAddItemData( request.ReardList, string.Empty, $"{ItemGetWay.Popularize}_{TimeHelper.ServerNow()}" );
            
            await ETTask.CompletedTask;
        }
    }
}
