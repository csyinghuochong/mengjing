using System;
namespace ET.Client;

[Event(SceneType.Demo)]
public class Robot_OnRecvTeamDungeonOpen : AEvent<Scene, RecvTeamDungeonOpen>
{
    protected override async ETTask Run(Scene scene, RecvTeamDungeonOpen args)
    {
        Console.WriteLine("Team_OnRecvTeamDungeonOpen");
        await scene.Root().GetComponent<TimerComponent>().WaitAsync(2000);
        TeamNetHelper.TeamDungeonPrepareRequest( scene.Root(), args.TeamInfo, 1 ).Coroutine();
        await ETTask.CompletedTask;
    }
}