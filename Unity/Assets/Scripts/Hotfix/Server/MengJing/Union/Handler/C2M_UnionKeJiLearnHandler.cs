using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionKeJiLearnHandler : MessageLocationHandler<Unit, C2M_UnionKeJiLearnRequest, M2C_UnionKeJiLearnResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionKeJiLearnRequest request, M2C_UnionKeJiLearnResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();   
            int kejiid = userInfoComponent.UserInfo.UnionKeJiList[request.Position];

            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(kejiid);
            if (unionKeJiConfig.NextID == 0)
            {
                response.UnionKeJiList = userInfoComponent.UserInfo.UnionKeJiList;
                response.Error = ErrorCode.ERR_UnionXiuLianMax;
                return;
            }

            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (!bagComponent.CheckCostItem( unionKeJiConfig.LearnCost ))
            {
                response.UnionKeJiList = userInfoComponent.UserInfo.UnionKeJiList;
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }

            ActorId dbCacheId = UnitCacheHelper.GetUnionServerId(unit.Zone());
            U2M_UnionKeJiLearnResponse d2GGetUnit = (U2M_UnionKeJiLearnResponse)await unit.Root().GetComponent<MessageSender>().Call(dbCacheId, new M2U_UnionKeJiLearnRequest()
            {
                UnionId = unit.GetUnionId(),    
                KeJiId = unionKeJiConfig.NextID,
                Position = request.Position,    
            });

            if(d2GGetUnit.Error != ErrorCode.ERR_Success)
            {
                response.UnionKeJiList = userInfoComponent.UserInfo.UnionKeJiList;
                response.Error = d2GGetUnit.Error;
                return;
            }

            bagComponent.OnCostItemData(unionKeJiConfig.LearnCost);
            userInfoComponent.UserInfo.UnionKeJiList[request.Position] = unionKeJiConfig.NextID;
            response.UnionKeJiList = userInfoComponent.UserInfo.UnionKeJiList;

            await ETTask.CompletedTask;
        }
    }
}
