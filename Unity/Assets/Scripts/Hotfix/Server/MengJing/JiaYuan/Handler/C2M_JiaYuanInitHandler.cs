using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanInitHandler : MessageLocationHandler<Unit, C2M_JiaYuanInitRequest, M2C_JiaYuanInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanInitRequest request, M2C_JiaYuanInitResponse response)
        {
            JiaYuanComponentS jiaYuanComponent = await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(unit.Root(), request.MasterId);
            UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(unit.Root(), request.MasterId);
            if (unit.Id != request.MasterId)
            {
                ActorId gateServerId = UnitCacheHelper.GetGateServerId(unit.Zone());
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (gateServerId, new T2G_GateUnitInfoRequest()
                    {
                        UserID = request.MasterId
                    });

                //玩家在线
                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    JiaYuanOperate jiaYuanOperate = new JiaYuanOperate();
                    jiaYuanOperate = new JiaYuanOperate();
                    jiaYuanOperate.OperateType = JiaYuanOperateType.Visit;
                    jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    M2M_JiaYuanOperateMessage opmessage = new M2M_JiaYuanOperateMessage()
                    {
                        JiaYuanOperate = jiaYuanOperate,
                    };
                    unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(request.MasterId, opmessage);
                }
                else
                {
                    jiaYuanComponent.AddJiaYuanRecord(new JiaYuanRecord()
                    {
                        OperateType = JiaYuanOperateType.Visit,
                        OperateId = 0,
                        PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name,
                        Time = TimeHelper.ServerNow(),
                    });
                    await UnitCacheHelper.SaveComponentCache(unit.Root(),  jiaYuanComponent);
                }
            }

            response.PlanOpenList = jiaYuanComponent.InitOpenList();
            response.PurchaseItemList = jiaYuanComponent.PurchaseItemList_7;
            response.LearnMakeIds = jiaYuanComponent.LearnMakeIds_7;
            response.JiaYuanPastureList = jiaYuanComponent.JiaYuanPastureList_7;
            response.JiaYuanProList = jiaYuanComponent.JiaYuanProList_7;
            response.JiaYuanDaShiTime = jiaYuanComponent.JiaYuanDaShiTime_1;
            response.JiaYuanPetList = jiaYuanComponent.JiaYuanPetList_2;

            response.JiaYuanLv = userInfoComponent.UserInfo.JiaYuanLv;
            response.MasterName = userInfoComponent.UserInfo.Name;
        }
    }
}
