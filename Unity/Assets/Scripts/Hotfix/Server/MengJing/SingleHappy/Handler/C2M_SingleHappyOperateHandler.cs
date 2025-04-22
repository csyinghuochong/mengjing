using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SingleHappyOperateHandler : MessageLocationHandler<Unit, C2M_SingleHappyOperateRequest, M2C_SingleHappyOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SingleHappyOperateRequest request, M2C_SingleHappyOperateResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            NumericComponentS numericComponentS = unit.GetComponent<NumericComponentS>();

            int mianfeitimes = int.Parse(GlobalValueConfigCategory.Instance.Get(130).Value);
            int extendTimes =  int.Parse(GlobalValueConfigCategory.Instance.Get(131).Value);
            int buyTimes = numericComponentS.GetAsInt(NumericType.SingleBuyTimes);

            int moveTimes = numericComponentS.GetAsInt(NumericType.SingleHappyMoveTimes);
            int recoverTimes = CommonHelp.GetHappyRecoverTimes(TimeHelper.ServerNow(), extendTimes);

            int canmoveTimes = mianfeitimes + recoverTimes + buyTimes - moveTimes;
            
            ////1免费移动 2刷新奖励 3购买次数
            if (request.OperatateType == 1)
            {
                //非免费时间则返回
                if (canmoveTimes <= 0)
                {
                    response.Error = ErrorCode.ERR_HappyMove_CD;
                    return;
                }

                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.SingleHappyMoveTimes, moveTimes + 1);
            }
            if (request.OperatateType == 2)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(132);
                if (userInfoComponent.UserInfo.Diamond < int.Parse(globalValueConfig.Value))
                {
                    response.Error = ErrorCode.ERR_GoldNotEnoughError;
                    return;
                }
                userInfoComponent.UpdateRoleMoneySub( UserDataType.Diamond, (int.Parse(globalValueConfig.Value) * -1).ToString(), true, ItemGetWay.HappyMove);
                
                unit.Scene().GetComponent<SingleHappyDungeonComponent>()?.OnTimer();
            }
            if (request.OperatateType  == 3)
            {
                int buycost = GlobalValueConfigCategory.Instance.SingleHappyBuyCost;
                if (userInfoComponent.UserInfo.Diamond < buycost)
                {
                    response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                    return;
                }
                userInfoComponent.UpdateRoleMoneySub(UserDataType.Diamond, (buycost* -1).ToString(), true, ItemGetWay.HappyMove);
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.SingleBuyTimes, buyTimes + 1);
            }

            if (request.OperatateType == 1)
            {
                for (int r = 10; r > 0; r--)
                {
                    int newCell = RandomHelper.RandomNumber(0, HappyData.PositionList.Count);

                    bool haveorange = false;
                    List<Unit> droplist = UnitHelper.GetUnitList(unit.Scene(), UnitType.DropItem);
                    for (int i = 0; i < droplist.Count; i++)
                    {
                        int itemid = droplist[i].GetComponent<NumericComponentS>().GetAsInt(NumericType.DropItemId);
                        if (ItemConfigCategory.Instance.Get(itemid).ItemQuality >= 5)
                        {
                            haveorange = true;
                            break;
                        }
                    }

                    //遇到橙色道具真实随机率 30%在当前橙色格子
                    if (haveorange && r > 1 && RandomHelper.RandFloat01() > 0.3f)
                    {
                        continue;
                    }

                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.SingleHappyCellIndex, newCell + 1);
                    float3 vector3 = HappyData.PositionList[newCell];
                    unit.Position = vector3;
                    break;
                }
            }

            unit.Stop(-2);
            await ETTask.CompletedTask;
        }
    }
}