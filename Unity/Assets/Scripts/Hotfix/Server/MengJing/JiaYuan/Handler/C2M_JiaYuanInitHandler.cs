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
                
                JiaYuanOperate jiaYuanOperate = JiaYuanOperate.Create();
                jiaYuanOperate = JiaYuanOperate.Create();
                jiaYuanOperate.OperateType = JiaYuanOperateType.Visit;
                jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                J2M_JiaYuanOperateRequest opmessage = J2M_JiaYuanOperateRequest.Create();
                opmessage.JiaYuanOperate = jiaYuanOperate;
                M2J_JiaYuanOperateResponse m2JJiaYuanOperateResponse = (M2J_JiaYuanOperateResponse) await unit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(request.MasterId, opmessage);
                //玩家在线
                if (m2JJiaYuanOperateResponse.Error != ErrorCode.ERR_Success)
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
