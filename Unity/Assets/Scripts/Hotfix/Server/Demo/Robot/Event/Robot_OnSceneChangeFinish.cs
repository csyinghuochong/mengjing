using System;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class Robot_OnSceneChangeFinish : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            TimerComponent timerComponent = scene.Root().GetComponent<TimerComponent>();

            Unit unit = UnitHelper.GetMyUnitFromClientScene(scene.Root());
            int battlecamp = unit.GetBattleCamp();

            switch (args.SceneType)
            {
                case MapTypeEnum.Arena:
                case MapTypeEnum.Battle:
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.LocalDungeon:
                case MapTypeEnum.DragonDungeon:
                    await timerComponent.WaitAsync(TimeHelper.Second * 5);
                    scene.Root().GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_Target);
                    break;
                case MapTypeEnum.PetMatch:
                    await timerComponent.WaitAsync(TimeHelper.Second * 10);
                    scene.Root().GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_PetMatchFight);
                    break;
                default:
                    break;
            }
            
            await ETTask.CompletedTask;
        }
    }
}