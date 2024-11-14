namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_UnitStateUpdateHandler: MessageHandler<Scene, M2C_UnitStateUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_UnitStateUpdate message)
        {
           
            Unit nowNunt = root.CurrentScene().GetComponent<UnitComponent>().Get(message.UnitId);
            if (nowNunt == null)
            {
                return;
            }

            // 添加状态
            if (message.StateOperateType == 1)
            {
                nowNunt.GetComponent<StateComponentC>().StateTypeAdd(message.StateType, message.StateValue);
            }

            //移除状态
            if (message.StateOperateType == 2)
            {
                nowNunt.GetComponent<StateComponentC>().StateTypeRemove(message.StateType);
            }

            EventSystem.Instance.Publish(root, new StateChange()  { Unit =nowNunt, m2C_UnitStateUpdate = message});
            
            await ETTask.CompletedTask;
        }
    }
}