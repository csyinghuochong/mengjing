using System;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_ChangeBehavior : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            Log.Debug($"SceneChangeFinishEvent_ChangeBehavior:  {args.SceneType}");
            Console.WriteLine($"SceneChangeFinishEvent_ChangeBehavior:  {args.SceneType}");

            TimerComponent timerComponent = scene.Root().GetComponent<TimerComponent>();
            switch (args.SceneType)
            {
                case SceneTypeEnum.Battle:
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