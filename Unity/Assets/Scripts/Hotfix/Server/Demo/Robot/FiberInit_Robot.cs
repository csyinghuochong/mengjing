using System;
using ET.Server;

namespace ET.Client
{
    [Invoke((long)SceneType.Robot)]
    public class FiberInit_Robot: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<PlayerInfoComponent>();
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
            root.AddComponent<CellDungeonComponentC>();
            
            root.SceneType = SceneType.Demo;
            
            //1_1001_0    区_robotid_index
            int zone = int.Parse( root.Name.Split('_')[0]);
            int robotid = int.Parse( root.Name.Split('_')[1]);
            
            PlayerInfoComponent playerInfoComponent = root.GetComponent<PlayerInfoComponent>();
            int versionMode =  CommonHelperS.IsInnerNet() ? VersionMode.Alpha: VersionMode.Beta;
            playerInfoComponent.ServerItem = ServerHelper.GetServerItemByZone(versionMode, zone);
            
            await EventSystem.Instance.PublishAsync(root, new AppStartInitFinish());
            
            Console.WriteLine($"FiberInit_Robot. root.Name:  {root.Name}");
            await LoginHelper.Login(root, root.Name, ConfigData.RobotPassWord, 0,versionMode );
            //await LoginHelper.Login(root, "1001_ET" + root.Name, ConfigData.RobotPassWord);

            int errorcode = ErrorCode.ERR_Success;
            if (playerInfoComponent.CreateRoleList.Count == 0)
            {
                errorcode = await LoginHelper.RequestCreateRole(root, playerInfoComponent.AccountId, 1, RandNameComponent.Instance.GetRandomName());
            }

            if (errorcode != ErrorCode.ERR_Success)
            {
                Console.WriteLine("FiberInit_Robot.Error  应该销毁！");
                return;
            }

            playerInfoComponent.Account = root.Name;
            playerInfoComponent.CurrentRoleId = playerInfoComponent.CreateRoleList[0].UnitId;

            await LoginHelper.LoginGameAsync(root, 0);
            root.AddComponent<BehaviourComponent, int>(robotid);
            // string account = $"{zone}_{robotid}_{robotNumber}_0001";   //服务器
        }
    }
}