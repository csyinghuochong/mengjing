
using System;
using MongoDB.Bson;

namespace ET.Server
{
    [MessageHandler(SceneType.RobotManager)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class G2Robot_MessageHandler : MessageHandler<Scene, G2Robot_MessageRequest>
    {
        protected override async ETTask Run(Scene scene, G2Robot_MessageRequest message)
        {
            Console.WriteLine($"G2Robot_MessageHandler:  {message}");
            RobotManagerComponent robotManagerComponent = scene.Root().GetComponent<RobotManagerComponent>();
            switch (message.MessageType)
            {
                case NoticeType.TeamDungeon:
                case NoticeType.DragonDungeon:
                    int robotnumber = 0;
                    long lastteamtime = 0;
                    string[] teamInfo = message.Message.Split('_');
                    int fubenId = int.Parse(teamInfo[0]);
                    long teamId = long.Parse(teamInfo[1]);
                    robotManagerComponent.TeamRobot.TryGetValue(teamId, out lastteamtime);
                    if(TimeHelper.ServerNow() - lastteamtime < 10000)
                    {
                        return;
                    }
                    robotManagerComponent.TeamRobot[teamId] = TimeHelper.ServerNow();

                    int totalnumber = 0;
                    while (robotnumber < 1)
                    {
                        totalnumber++ ;
                        if (totalnumber >= 2)
                        {
                            break;
                        }

                        //message.Message   sceneid_teamid
                        int  robotId = BattleHelper.GetBattleRobotId(11, fubenId);
                        Console.WriteLine($"GetBattleRobotId: {robotId}");
                        int fiberId= await robotManagerComponent.NewRobot(message.Zone, robotId);
                        ActorId roborActorId = new ActorId(scene.Fiber().Process, fiberId);  // this.Root = new Scene(this, id, 1, sceneType, name); / this.InstanceId = 1;
                        Main2RobotClient_Message main2RobotClientMessage = Main2RobotClient_Message.Create();
                        main2RobotClientMessage.Message = message.Message;
                        RobotClient2Main_Message respone =
                                await scene.Root().GetComponent<ProcessInnerSender>().Call(roborActorId, main2RobotClientMessage) as
                                        RobotClient2Main_Message;
                        
                        robotnumber++;
                    }
                    break;
                case NoticeType.PetMatchOpen:
                    robotnumber = 0;
                    lastteamtime = 0;
                    fubenId = BattleHelper.GetSceneIdByType(MapTypeEnum.PetMatch);
        
                    totalnumber = 0;
                    while (robotnumber < 1)
                    {
                        totalnumber++ ;
                        if (totalnumber >= 20)
                        {
                            break;
                        }
                        
                        //message.Message   sceneid_teamid
                        int  robotId = BattleHelper.GetBattleRobotId(2, fubenId);
                        Console.WriteLine($"GetBattleRobotId: {robotId}");
                        await robotManagerComponent.NewRobot(message.Zone, robotId);
                        robotnumber++;
                    }
                    break;
                case NoticeType.BattleOpen:
                    using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.NewRobot, 1))
                    {
                        int robotNumber = 0;
                        while (robotNumber < 10)
                        {
                            int robotId = BattleHelper.GetBattleRobotId(3, 0);

                            await robotManagerComponent.NewRobot(message.Zone, robotId);
                            await scene.Root().GetComponent<TimerComponent>().WaitAsync(500);
                            robotNumber++;
                        }
                    }
                    break;
                case NoticeType.BattleOver:
                    using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.NewRobot, 1))
                    {
                       await  robotManagerComponent.RemoveBattleRobot(message.Zone);
                    }
                    break;
                default:
                    break;
            }
            
            
            await ETTask.CompletedTask;
        }
    }
}
