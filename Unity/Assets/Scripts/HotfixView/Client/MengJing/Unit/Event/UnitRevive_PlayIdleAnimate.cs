namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UnitRevive_PlayIdleAnimate: AEvent<Scene, UnitRevive>
    {
        protected override async ETTask Run(Scene root, UnitRevive args)
        {
            Unit unit = args.Unit;
            unit.GetComponent<FsmComponent>()?.ChangeState(FsmStateEnum.FsmIdleState);
            unit.GetComponent<UIPlayerHpComponent>()?.OnRevive();
            unit.GetComponent<GameObjectComponent>()?.OnRevive();
            await ETTask.CompletedTask;
        }
    }
}