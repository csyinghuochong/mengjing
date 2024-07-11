namespace ET.Server
{
    public static class RechargeHelp
    { 
        
        public static void  SendDiamondToUnit(Unit unit, int rechargeNumber, string orderInfo)
        {
            //Log.Warning($"RechargeHelp.SendDiamond {unit.Id} {rechargeNumber} {orderInfo}");
            OnRechage(unit, rechargeNumber, true);
            long accountId = unit.GetComponent<UserInfoComponentS>().UserInfo.AccInfoID;
            long userId = unit.GetComponent<UserInfoComponentS>().UserInfo.UserId;
            SendToAccountCenter(unit.Root(), accountId, userId, rechargeNumber, orderInfo).Coroutine();
            unit.GetComponent<DBSaveComponent>().UpdateCacheDB();
        }

        public static void OnRechage(Unit unit, int rechargeNumber, bool notice)
        {
            if (rechargeNumber <= 0)
            {
                return;
            }

            int number = ConfigHelper.GetDiamondNumber(rechargeNumber);
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.Diamond, number.ToString(), notice, ItemGetWay.Recharge);
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();

            numericComponent.ApplyChange(null, NumericType.RechargeNumber, rechargeNumber, 1, notice);
            numericComponent.ApplyChange(null, NumericType.V1RechageNumber, rechargeNumber, 0, notice);
            //已经领取的不充值
            if (numericComponent.GetAsInt(NumericType.RechargeSign) != 2)
            {
                numericComponent.ApplyValue(NumericType.RechargeSign, 1, notice);
            }

            // 单笔充值奖励记录
            if (!unit.GetComponent<UserInfoComponentS>().UserInfo.SingleRechargeIds.Contains(rechargeNumber))
            {
                unit.GetComponent<UserInfoComponentS>().UserInfo.SingleRechargeIds.Add(rechargeNumber);
            }
        }

        public static async ETTask SendToAccountCenter(Scene root, long accountId, long userId, int rechargeNumber, string ordinfo)
        {
            A2Center_RechargeRequest rechargeRequest = A2Center_RechargeRequest.Create();
            rechargeRequest.AccountId = accountId;
            rechargeRequest.RechargeInfo = RechargeInfo.Create();
            rechargeRequest.RechargeInfo.Amount = rechargeNumber;
            rechargeRequest.RechargeInfo.Time = TimeHelper.ServerNow();
            rechargeRequest.RechargeInfo.UnitId = userId; 
            rechargeRequest.RechargeInfo.OrderInfo = ordinfo;
            
            ActorId accountZone = UnitCacheHelper.GetLoginCenterId();
            Center2A_RechargeResponse saveAccount =
                    (Center2A_RechargeResponse)await root.GetComponent<MessageSender>().Call(accountZone, rechargeRequest);
        }

        public static async ETTask OnPaySucessToUnit(Scene scene, long userId, int rechargeNumber, string orderInfo)
        {
            Player gateUnitInfo = scene.GetComponent<PlayerComponent>().GetByUserId(userId);
            //&& gateUnitInfo.ClientSession!=null
            if (gateUnitInfo != null && gateUnitInfo.PlayerState == PlayerState.Game && gateUnitInfo.InstanceId > 0)
            {
                Log.Warning($"充值OnPaySucess PlayerState.Game: {scene.Zone()}   {userId}  rechargeNumber:{rechargeNumber}");
                G2M_RechargeResultRequest G2M_RechargeResultRequest = G2M_RechargeResultRequest.Create();
                G2M_RechargeResultRequest.RechargeNumber = rechargeNumber;
                G2M_RechargeResultRequest.OrderInfo = orderInfo;
                M2G_RechargeResultResponse m2G_RechargeResponse =
                        (M2G_RechargeResultResponse)await scene.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(gateUnitInfo.UnitId, G2M_RechargeResultRequest);
            }
            else
            {
                Log.Warning($"充值OnPaySucess PlayerState.None: {scene.Zone()}   {userId}  rechargeNumber:{rechargeNumber}");
                //直接存数据库
                //int number = ComHelp.GetDiamondNumber(rechargeNumber);
                NumericComponentS numericComponent = await UnitCacheHelper.GetComponentCache<NumericComponentS>(scene, userId);
                numericComponent.ApplyChange(null, NumericType.RechargeBuChang, rechargeNumber, 1, false);
                await UnitCacheHelper.SaveComponentCache(scene, numericComponent);
                
                UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene, userId);

                long accountId = userInfoComponent.UserInfo.AccInfoID;
                SendToAccountCenter(scene, accountId, userId, rechargeNumber, orderInfo).Coroutine();
                await ETTask.CompletedTask;
            }
        }

        public static async ETTask OnPaySucessToGate(Scene scene, int zone, long userId, int rechargeNumber, string orderInfo, int rechargeType)
        {
            ActorId gateServerId = UnitCacheHelper.GetGateServerId(zone);

            R2G_RechargeResultRequest r2M_RechargeRequest = R2G_RechargeResultRequest.Create();
            r2M_RechargeRequest.RechargeNumber = rechargeNumber;
            r2M_RechargeRequest.UserID = userId;
            r2M_RechargeRequest.OrderInfo = orderInfo;
            G2R_RechargeResultResponse m2G_RechargeResponse =
                    (G2R_RechargeResultResponse)await scene.GetComponent<MessageSender>().Call(gateServerId, r2M_RechargeRequest);
        }
    }
}