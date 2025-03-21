namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionOrderOperateHandler : MessageLocationHandler<Unit, C2M_UnionOrderOperateRequest, M2C_UnionOrderOperateResponse>
    {
        
        protected override async ETTask Run(Unit unit, C2M_UnionOrderOperateRequest request, M2C_UnionOrderOperateResponse response)
        {

            long serverTime = TimeHelper.ServerNow();
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            TaskComponentS taskComponentS      =    unit.GetComponent<TaskComponentS>();
            
            switch (request.OperateType)
            {
                case 1:
                    if (serverTime - numericComponent.GetAsLong(NumericType.OrderTaskRefrehTime) >= TimeHelper.Hour * 2)
                    {
                        //刷新订单
                        taskComponentS.UpdateOrderTask();
                        numericComponent.ApplyValue(NumericType.OrderTaskRefrehTime, TimeHelper.ServerNow());
                    }
                    break;
                case 2:
                    UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
                    userInfoComponentS.UpdateRoleMoneySub( UserDataType.Diamond, "-200", true, ItemGetWay.UnionOrder );
                    taskComponentS.UpdateOrderTask();
                    break;
            }
            
            await ETTask.CompletedTask;
        }

    }
}
