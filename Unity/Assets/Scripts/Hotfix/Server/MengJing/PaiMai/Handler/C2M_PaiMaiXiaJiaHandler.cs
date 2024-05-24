using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_PaiMaiXiaJiaHandler : MessageLocationHandler<Unit, C2M_PaiMaiXiaJiaRequest, M2C_PaiMaiXiaJiaResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PaiMaiXiaJiaRequest request, M2C_PaiMaiXiaJiaResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.XiaJia, unit.Id))
            {
                if (unit.GetComponent<BagComponentS>().GetBagLeftCell() < 1)
                {
                    return;
                }

                ActorId chargeServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "PaiMai").ActorId;
                P2M_PaiMaiXiaJiaResponse r_GameStatusResponse = (P2M_PaiMaiXiaJiaResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (chargeServerId, new M2P_PaiMaiXiaJiaRequest()
                    {
                        ItemType = request.ItemType,    
                        PaiMaiItemInfoId = request.PaiMaiItemInfoId
                    });

                if (r_GameStatusResponse.Error == ErrorCode.ERR_Success && r_GameStatusResponse.PaiMaiItemInfo != null)
                {
                    unit.GetComponent<BagComponentS>().OnAddItemData(r_GameStatusResponse.PaiMaiItemInfo.BagInfo, $"{ItemGetWay.XiaJia}_{TimeHelper.ServerNow()}");
                }
                else
                {
                    LogHelper.LogWarning($"C2M_PaiMaiXiaJiaHandler==null  {unit.Id} {request.PaiMaiItemInfoId}");
                }
                
                await ETTask.CompletedTask;
            }
        }
    }
}
