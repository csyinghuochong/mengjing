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
            
            if (serverTime - numericComponent.GetAsLong(NumericType.OrderTaskRefrehTime) >= TimeHelper.Minute)
            {
                //刷新订单
                taskComponentS.UpdateOrderTask();
            }
            
            
            await ETTask.CompletedTask;
        }

    }
}
