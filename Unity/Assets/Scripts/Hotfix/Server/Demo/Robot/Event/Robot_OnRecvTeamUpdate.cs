using System;
using ET.Server;
namespace ET.Client;

[Event(SceneType.Demo)]
public class Robot_OnRecvTeamUpdate : AEvent<Scene, RecvTeamUpdate>
{
    protected override async ETTask Run(Scene scene, RecvTeamUpdate args)
    {
        TeamInfo selfinfo = scene.GetComponent<TeamComponentC>().GetSelfTeam();
        Console.WriteLine($"Robot_OnRecvTeamUpdate:  {selfinfo}");

        if (selfinfo == null)
        {
            ActorId roborActorId = UnitCacheHelper.GetRobotServerId();
            Main2RobotManager_Message main2RobotClientMessage = Main2RobotManager_Message.Create();
            main2RobotClientMessage.OpType = 1;
            main2RobotClientMessage.OpParam = scene.Fiber.Id.ToString();
            RobotManager2Main_Message respone =
                    await scene.Root().GetComponent<ProcessInnerSender>().Call(roborActorId, main2RobotClientMessage) as
                            RobotManager2Main_Message;
        }
        
        await ETTask.CompletedTask;
    }
}