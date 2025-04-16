namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_PaiMaiDuiHuanHandler : MessageLocationHandler<Unit, C2M_PaiMaiDuiHuanRequest, M2C_PaiMaiDuiHuanResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_PaiMaiDuiHuanRequest request, M2C_PaiMaiDuiHuanResponse response)
        {
            ActorId dbCacheId = UnitCacheHelper.GetRankServerId(unit.Zone());
            M2R_DBServerInfoRequest M2R_DBServerInfoRequest = M2R_DBServerInfoRequest.Create();
            R2M_DBServerInfoResponse d2GGetUnit = (R2M_DBServerInfoResponse)await unit.Root().GetComponent<MessageSender>().Call(dbCacheId, M2R_DBServerInfoRequest);
            long diamond = request.DiamondsNumber;
            if (request.DiamondsNumber <= 0)
            {
                return;
            }

            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.RechargeNumber) <= 0)
            {
                return;
            }

            //服务器限制,单次最多兑换100000钻石
            if (request.DiamondsNumber > 100000)
            {
                return;
            }
       
            //判断钻石是否足够
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Diamond >= diamond)
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, (diamond * -1).ToString(), true, ItemGetWay.DuiHuan);
                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.Gold, (diamond * d2GGetUnit.ServerInfo.ExChangeGold).ToString(), true, ItemGetWay.DuiHuan);
                //unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.WeiJingGold,( (int)(diamond / 100) ).ToString(), true, ItemGetWay.DuiHuan);
                unit.GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.DuiHuanGold_15, 0, (int)(diamond / 100));
            }
            else 
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
            }
            
            await ETTask.CompletedTask;
        }
    }
}
