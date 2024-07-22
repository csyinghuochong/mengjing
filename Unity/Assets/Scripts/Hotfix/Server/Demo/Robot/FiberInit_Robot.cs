using System;

namespace ET.Client
{
    [Invoke((long)SceneType.Robot)]
    public class FiberInit_Robot: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Console.WriteLine("FiberInit_Robot");
            
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<PlayerComponent>();
            root.AddComponent<CurrentScenesComponent>();
            root.AddComponent<ObjectWait>();
            
            root.SceneType = SceneType.Demo;

            await EventSystem.Instance.PublishAsync(root, new AppStartInitFinish());
            

            await LoginHelper.Login(root, root.Name, ConfigData.RobotPassWord);
            
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            if (playerComponent.CreateRoleList.Count == 0)
            {
                await LoginHelper.RequestCreateRole(root, playerComponent.AccountId, 1, "机器人" + playerComponent.Account);
            }
            
            await LoginHelper.LoginGameAsync(root);

            //root.AddComponent<AIComponent, int>(1);
        }
    }
}