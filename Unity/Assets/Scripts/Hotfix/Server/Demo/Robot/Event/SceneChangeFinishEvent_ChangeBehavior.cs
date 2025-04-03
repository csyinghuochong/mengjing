using System;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_ChangeBehavior : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            TimerComponent timerComponent = scene.Root().GetComponent<TimerComponent>();
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
                default:
                    break;
            }
            
            await ETTask.CompletedTask;
        }
    }
}