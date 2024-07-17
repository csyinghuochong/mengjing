using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_XiuLianCenterHandler : MessageLocationHandler<Unit, C2M_XiuLianCenterRequest, M2C_XiuLianCenterResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_XiuLianCenterRequest request, M2C_XiuLianCenterResponse response)
        {

            int level = unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
            //1 经验  2金币
            if (request.XiuLianType == 1)
            {
                int xiulianNumber = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.XiuLian_ExpNumber);
                if (xiulianNumber >= 3)
                {
                    return;
                }
            
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.XiuLian_ExpNumber, xiulianNumber+1);
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.XiuLian_ExpTime, TimeHelper.ServerNow());
                float coefficient = float.Parse(GlobalValueConfigCategory.Instance.Get(29).Value);
                int addValue = (int)math.ceil(coefficient * level);
                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd( UserDataType.Exp, addValue.ToString(), true, ItemGetWay.XiuLian);
            }
            if (request.XiuLianType == 2)
            {
                int xiulianNumber = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.XiuLian_CoinNumber);
                if (xiulianNumber >= 3)
                {
                    return;
                }
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.XiuLian_CoinNumber, xiulianNumber + 1);
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.XiuLian_CoinTime, TimeHelper.ServerNow());
                float coefficient = float.Parse(GlobalValueConfigCategory.Instance.Get(30).Value);
                int addValue = (int)math.ceil(coefficient * level);
                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(UserDataType.Gold, addValue.ToString(), true, 37);// ItemGetWay.XiuLian);
            }

            await ETTask.CompletedTask;
        }
    }
}
