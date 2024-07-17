namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_StallOperationHandler : MessageLocationHandler<Unit, C2M_StallOperationRequest, M2C_StallOperationResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_StallOperationRequest request, M2C_StallOperationResponse response)
        {
            if (request.StallType == 0) //收摊
            {
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Stall, 0);

                TransferHelper.RemoveStall(unit );
            }
            if (request.StallType == 1) //摆摊
            {
                UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
                if (string.IsNullOrEmpty(userInfo.StallName))
                {
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.StallName, $"{userInfo.Name}的摊位");
                }
       
                TransferHelper.RemovePetAndJingLing(unit );
                long stallId = UnitFactory.CreateStall( unit.Scene(), unit ).Id;

                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HorseRide, 0);
                unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Stall, stallId);
            }
            if (request.StallType == 2 && request.Value != "" && StringHelper.IsSafeSqlString(request.Value)) //修改名字
            {
                unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.StallName, request.Value);

                long stallId = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.Now_Stall);
                Unit unitstall = unit.GetParent<UnitComponent>().Get(stallId);
                unitstall.GetComponent<UnitInfoComponent>().UnitName = request.Value;
                M2C_RoleDataBroadcast m2C_BroadcastRoleData = M2C_RoleDataBroadcast.Create();
                m2C_BroadcastRoleData.UnitId = stallId;
                m2C_BroadcastRoleData.UpdateType = UserDataType.Name;
                m2C_BroadcastRoleData.UpdateTypeValue = request.Value;
                MapMessageHelper.Broadcast(unit, m2C_BroadcastRoleData);
            }

            await ETTask.CompletedTask;
        }
    }
}
