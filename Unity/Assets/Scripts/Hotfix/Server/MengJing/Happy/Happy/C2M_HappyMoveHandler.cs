using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_HappyMoveHandler : MessageLocationHandler<Unit, C2M_HappyMoveRequest, M2C_HappyMoveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_HappyMoveRequest request, M2C_HappyMoveResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();

            if (request.OperatateType != 1 && request.OperatateType != 3)
            {
                Log.Error($"C2M_HappyMoveRequest.1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (request.OperatateType == 1)
            {
                //非免费时间则返回
                long happmoveTime = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.HappyMoveTime);
                if (TimeHelper.ServerNow()  < happmoveTime)
                {
                    response.Error = ErrorCode.ERR_HappyMove_CD;
                    return;
                }

                long mianfeicd = GlobalValueConfigCategory.Instance.HappyMoveFreeRefreshTime * 1000;
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HappyMoveTime, TimeHelper.ServerNow() + mianfeicd);
            }
            if (request.OperatateType == 2)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(94);
                if (userInfoComponent.UserInfo.Gold < int.Parse(globalValueConfig.Value))
                {
                    response.Error = ErrorCode.ERR_GoldNotEnoughError;
                    return;
                }
                userInfoComponent.UpdateRoleMoneySub( UserDataType.Gold, (int.Parse(globalValueConfig.Value) * -1).ToString(), true, ItemGetWay.HappyMove);
            }
            if (request.OperatateType  == 3)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(95);
                if (userInfoComponent.UserInfo.Diamond < int.Parse(globalValueConfig.Value))
                {
                    response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                    return;
                }
                userInfoComponent.UpdateRoleMoneySub(UserDataType.Diamond, (int.Parse(globalValueConfig.Value)* -1).ToString(), true, ItemGetWay.HappyMove);
            }

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

                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HappyCellIndex, newCell + 1);
                float3 vector3 = HappyData.PositionList[newCell];
                unit.Position = vector3;
                break;
            }

            unit.Stop(-2);

            await ETTask.CompletedTask;
        }
    }
}