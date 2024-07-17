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
                T2G_GateUnitInfoRequest t2GGateUnitInfoRequest = T2G_GateUnitInfoRequest.Create();
                t2GGateUnitInfoRequest.UserID = request.MasterId;
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (gateServerId, t2GGateUnitInfoRequest);

                //玩家在线
                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    JiaYuanOperate jiaYuanOperate = JiaYuanOperate.Create();
                    jiaYuanOperate = JiaYuanOperate.Create();
                    jiaYuanOperate.OperateType = JiaYuanOperateType.Visit;
                    jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    M2M_JiaYuanOperateMessage opmessage = M2M_JiaYuanOperateMessage.Create();
                    opmessage.JiaYuanOperate = jiaYuanOperate;
                    unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(request.MasterId, opmessage);
                }
                else
                {
                    JiaYuanRecord JiaYuanRecord = JiaYuanRecord.Create();
                    JiaYuanRecord.OperateType = JiaYuanOperateType.Visit;
                    JiaYuanRecord.OperateId = 0;
                    JiaYuanRecord.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    JiaYuanRecord.Time = TimeHelper.ServerNow();
                    jiaYuanComponent.AddJiaYuanRecord(JiaYuanRecord);
                    await UnitCacheHelper.SaveComponentCache(unit.Root(),  jiaYuanComponent);
                }
            }
            jiaYuanComponent.InitOpenList();
            response.PlanOpenList .AddRange(jiaYuanComponent.PlanOpenList_7);
            response.PurchaseItemList .AddRange(jiaYuanComponent.PurchaseItemList_7); 
            response.LearnMakeIds .AddRange(jiaYuanComponent.LearnMakeIds_7); 
            response.JiaYuanPastureList .AddRange(jiaYuanComponent.JiaYuanPastureList_7); 
            response.JiaYuanProList .AddRange(jiaYuanComponent.JiaYuanProList_7); 
            response.JiaYuanPetList .AddRange(jiaYuanComponent.JiaYuanPetList_2); 
            response.JiaYuanDaShiTime = jiaYuanComponent.JiaYuanDaShiTime_1;
            response.JiaYuanLv = userInfoComponent.UserInfo.JiaYuanLv;
            response.MasterName = userInfoComponent.UserInfo.Name;
        }
    }
}
