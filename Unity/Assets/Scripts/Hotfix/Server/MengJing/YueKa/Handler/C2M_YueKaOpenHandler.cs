namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_YueKaOpenHandler : MessageLocationHandler<Unit, C2M_YueKaOpenRequest, M2C_YueKaOpenResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_YueKaOpenRequest request, M2C_YueKaOpenResponse response)
        {
            int cost = int.Parse( GlobalValueConfigCategory.Instance.Get(37).Value );
            //判定是否是月卡用户
            if (unit.IsYueKaStates())
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                return;
            }
            //判定是否钻石足够
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Diamond < cost)
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                return;
            }

            //开启月卡
            unit.UpdateYueKaTimes();

            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, (cost * -1).ToString(), true, ItemGetWay.CostItem);

            long addPilao = GlobalValueConfigCategory.Instance.MaxPiLaoYuKaUser - GlobalValueConfigCategory.Instance.MaxPiLao;
            unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.PiLao, addPilao.ToString());
            //Log.Warning($"[增加疲劳] {unit.DomainZone()}  {unit.Id}   {0}  {addPilao}");
            await ETTask.CompletedTask;
        }

    }
}
