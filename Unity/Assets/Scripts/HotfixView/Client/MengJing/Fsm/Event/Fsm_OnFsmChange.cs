namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Fsm_OnFsmChange: AEvent<Scene, FsmChange>
    {
        protected override async ETTask Run(Scene scene, FsmChange args)
        {

            args.Unit.GetComponent<FsmComponent>()?.ChangeState(args.FsmHandlerType, args.SkillId);
            await ETTask.CompletedTask;
        }
    }
}
