using System;
using ET.Server;

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
            root.AddComponent<BagComponentC>();
            root.AddComponent<UserInfoComponentC>();
            root.AddComponent<ChatComponent>();
            root.AddComponent<FriendComponent>();
            root.AddComponent<TaskComponentC>();
            root.AddComponent<BattleMessageComponent>();
            root.AddComponent<MapComponent>();
            root.AddComponent<PetComponentC>();
            root.AddComponent<SkillSetComponentC>();
            root.AddComponent<ChengJiuComponentC>();
            root.AddComponent<MailComponentC>();
            root.AddComponent<ShoujiComponentC>();
            root.AddComponent<TitleComponentC>();
            root.AddComponent<ReddotComponentC>();
            root.AddComponent<AttackComponent>();
            root.AddComponent<ActivityComponentC>();
            root.AddComponent<JiaYuanComponentC>();
            root.AddComponent<TeamComponentC>();
            
            root.SceneType = SceneType.Demo;
            
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            int versionMode =  ComHelperS.IsInnerNet() ? VersionMode.Alpha: VersionMode.Beta;
            playerComponent.ServerItem = ServerHelper.GetServerList(versionMode)[0];
            
            await EventSystem.Instance.PublishAsync(root, new AppStartInitFinish());
            
            Console.WriteLine($"root.Name:  {root.Name}");
            await LoginHelper.Login(root, root.Name, ConfigData.RobotPassWord, 0,versionMode );
            //await LoginHelper.Login(root, "1001_ET" + root.Name, ConfigData.RobotPassWord);
            
            if (playerComponent.CreateRoleList.Count == 0)
            {
                await LoginHelper.RequestCreateRole(root, playerComponent.AccountId, 1,  playerComponent.Account);
            }

            playerComponent.Account = root.Name;
            playerComponent.CurrentRoleId = playerComponent.CreateRoleList[0].UnitId;
            await LoginHelper.LoginGameAsync(root, 0);

            int robotid = int.Parse( root.Name.Split('_')[0]);
            root.AddComponent<BehaviourComponent, int>(robotid);
            //root.AddComponent<AIComponent, int>(1);
        }
    }
}