namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_StallXiaJiaHandler: MessageLocationHandler<Unit, C2M_StallXiaJiaRequest, M2C_StallXiaJiaResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_StallXiaJiaRequest request, M2C_StallXiaJiaResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.XiaJia, unit.Id))
            {
                if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
                {
                    return;
                }

                ActorId chargeServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "PaiMai").ActorId;
                M2P_StallXiaJiaRequest M2P_StallXiaJiaRequest = M2P_StallXiaJiaRequest.Create();
                M2P_StallXiaJiaRequest.PaiMaiItemInfoId = request.PaiMaiItemInfoId;
                P2M_StallXiaJiaResponse p2MStallXiaJiaResponse =
                        (P2M_StallXiaJiaResponse)await unit.Root().GetComponent<MessageSender>().Call(chargeServerId,M2P_StallXiaJiaRequest);

                if (p2MStallXiaJiaResponse.Error == ErrorCode.ERR_Success && p2MStallXiaJiaResponse.PaiMaiItemInfo != null)
                {
                    unit.GetComponent<BagComponentS>().OnAddItemData(p2MStallXiaJiaResponse.PaiMaiItemInfo.BagInfo,
                        $"{ItemGetWay.XiaJia}_{TimeHelper.ServerNow()}");
                }
                else
                {
                    ServerLogHelper.LogWarning($"C2M_PaiMaiXiaJiaHandler==null  {unit.Id} {request.PaiMaiItemInfoId}");
                }
                
                await ETTask.CompletedTask;
            }
        }
    }
}