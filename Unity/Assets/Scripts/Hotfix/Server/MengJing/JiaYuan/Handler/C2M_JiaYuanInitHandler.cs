using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanInitHandler : MessageLocationHandler<Unit, C2M_JiaYuanInitRequest, M2C_JiaYuanInitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanInitRequest request, M2C_JiaYuanInitResponse response)
        {
            JiaYuanComponentS jiaYuanComponent = await UnitCacheHelper.GetComponentCache<JiaYuanComponentS>(unit.Root(), request.MasterId);
            UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(unit.Root(), request.MasterId);
            UserInfo unionInfoCache = userInfoComponent.ChildrenDB[0] as UserInfo;
            if (unit.Id != request.MasterId)
            {
                JiaYuanOperate jiaYuanOperate = JiaYuanOperate.Create();
                jiaYuanOperate = JiaYuanOperate.Create();
                jiaYuanOperate.OperateType = JiaYuanOperateType.Visit;
                jiaYuanOperate.PlayerName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
                jiaYuanOperate.UnitId = unit.Id;
                jiaYuanOperate.MasterId = request.MasterId;
                M2J_JiaYuanOperateRequest opmessage = M2J_JiaYuanOperateRequest.Create();
                opmessage.JiaYuanOperate = jiaYuanOperate;

                ActorId jiayuanactorid = UnitCacheHelper.GetJiaYuanServerId(unit.Zone());
                J2M_JiaYuanOperateResponse m2JJiaYuanOperateResponse = (J2M_JiaYuanOperateResponse) await unit.Root().GetComponent<MessageSender>().Call(jiayuanactorid, opmessage);
            }
            jiaYuanComponent.InitOpenList();
            response.PlanOpenList .AddRange(jiaYuanComponent.PlanOpenList_7);
            response.PurchaseItemList .AddRange(jiaYuanComponent.PurchaseItemList_7); 
            response.LearnMakeIds .AddRange(jiaYuanComponent.LearnMakeIds_7); 
            response.JiaYuanPastureList .AddRange(jiaYuanComponent.JiaYuanPastureList_7); 
            response.JiaYuanProList .AddRange(jiaYuanComponent.JiaYuanProList_7); 
            response.JiaYuanPetList .AddRange(jiaYuanComponent.JiaYuanPetList_2); 
            response.JiaYuanDaShiTime = jiaYuanComponent.JiaYuanDaShiTime_1;
            response.JiaYuanLv = unionInfoCache.JiaYuanLv;
            response.MasterName = unionInfoCache.Name;
        }
    }
}
