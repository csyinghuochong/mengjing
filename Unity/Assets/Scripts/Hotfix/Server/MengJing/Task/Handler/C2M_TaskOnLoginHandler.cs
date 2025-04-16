namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskOnLoginHandler : MessageLocationHandler<Unit, C2M_TaskOnLoginRequest, M2C_TaskOnLoginResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskOnLoginRequest request, M2C_TaskOnLoginResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            taskComponent.OnLogin(unit.GetComponent<UserInfoComponentS>().UserInfo.RobotId);
            await ETTask.CompletedTask;
        }
    }
}
