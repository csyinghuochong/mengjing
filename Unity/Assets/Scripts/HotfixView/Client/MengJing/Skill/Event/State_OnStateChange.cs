namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class State_OnStateChange: AEvent<Scene, StateChange>
    {
        protected override async ETTask Run(Scene scene, StateChange args)
        {
            M2C_UnitStateUpdate message = args.m2C_UnitStateUpdate;

            FsmComponent fsmComponent = args.Unit.GetComponent<FsmComponent>();
            if (fsmComponent == null)
            {
                return;
            }
            
            // 隐藏状态
            if (message.StateType == StateTypeEnum.Hide && message.StateOperateType == 1)
            {
                args.Unit.EnterHide();
            }
            if (message.StateType == StateTypeEnum.Hide && message.StateOperateType == 2)
            {
                args.Unit.ExitHide();
            }
            
            await ETTask.CompletedTask;
        }
    }
}
