using System;

namespace ET.Server
{
    
    [MessageHandler(SceneType.Map)]
    public class C2M_HongBaoOpenRequestHandler: MessageLocationHandler<Unit, C2M_HongBaoOpenRequest, M2C_HongBaoOpenResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_HongBaoOpenRequest request, M2C_HongBaoOpenResponse response)
        {
            int functionId = 1023;
            
            if (FuntionConfigCategory.Instance.Get(functionId).IfOpen !="0")
            {
                response.Error = ErrorCode.ERR_ModifyData;

                return;
            }

            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Lv < 12)
            {
                response.Error = ErrorCode.ERR_HongBaoLevel;

                return;
            }

            long serverTime = TimeHelper.ServerNow();
            long lastTime = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.HongBaoLastTime);
            if (serverTime - lastTime < TimeHelper.Minute * 30)
            {
                response.Error = ErrorCode.ERR_HongBaoTime;

                return;
            }
            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.HongBao) != 0)
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }
            
            if (!FunctionHelp.IsFunctionTimeOpen(functionId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            //获取当前玩家等级
            int playerLv = unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
            int minGold = 2000;
            int maxGold = 10000;

            if (playerLv >= 1 && playerLv <= 19)
            {
                minGold = 10000;
                maxGold = 50000;
            }


            if (playerLv >= 20 && playerLv <= 29)
            {
                minGold = 20000;
                maxGold = 75000;
            }


            if (playerLv >= 30 && playerLv <= 39)
            {
                minGold = 30000;
                maxGold = 100000;
            }


            if (playerLv >= 40 && playerLv <= 49)
            {
                minGold = 40000;
                maxGold = 125000;
            }

            if (playerLv >= 50)
            {
                minGold = 50000;
                maxGold = 150000;
            }

            int hongbaoAmount = RandomHelper.RandomNumber(minGold, maxGold);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HongBao, 1);
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HongBaoLastTime, TimeHelper.ServerNow());
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.Gold, hongbaoAmount.ToString(), true, 33);// ItemGetWay.HongBao);
            response.HongbaoAmount = hongbaoAmount;
            
            await ETTask.CompletedTask;
        }
    }
}