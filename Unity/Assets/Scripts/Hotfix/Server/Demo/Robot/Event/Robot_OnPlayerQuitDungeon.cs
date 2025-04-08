using System;
namespace ET.Client;

[Event(SceneType.Demo)]
public class Robot_OnPlayerQuitDungeon : AEvent<Scene, PlayerQuitDungeon>
{
    protected override async ETTask Run(Scene scene, PlayerQuitDungeon args)
    {
        Console.WriteLine("Team_OnRecvTeamDungeonOpen");
        await scene.Root().GetComponent<TimerComponent>().WaitAsync(2000);
       
        Scene zoneScene = scene.Root();
        MapComponent mapComponent = zoneScene.GetComponent<MapComponent>();
        switch (mapComponent.MapType)
        {
            case MapTypeEnum.TeamDungeon:
                EnterMapHelper.RequestQuitFuben(zoneScene);
                zoneScene.GetComponent<BehaviourComponent>().TargetID = 0;
                zoneScene.GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_TeamDungeon);
                break;
            case MapTypeEnum.DragonDungeon:
                EnterMapHelper.RequestQuitFuben(zoneScene);
                zoneScene.GetComponent<BehaviourComponent>().TargetID = 0;
                zoneScene.GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_DragonDungeon);
                break;
            case MapTypeEnum.PetMatch:
                EnterMapHelper.RequestQuitFuben(zoneScene);
                zoneScene.GetComponent<BehaviourComponent>().TargetID = 0;
                zoneScene.GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_PetMatch);
                break;
        }
        
        await ETTask.CompletedTask;
    }
}