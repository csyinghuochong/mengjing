namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UnitRevive_PlayIdleAnimate : AEvent<Scene, UnitRevive>
    {
        protected override async ETTask Run(Scene root, UnitRevive args)
        {
            Unit unit = args.Unit;
            
            switch (unit.Type)
            {
                case UnitType.Player:
                    unit.GetComponent<UIPlayerHpComponent>()?.OnRevive();
                    break;
                case UnitType.Monster:
                    unit.GetComponent<UIMonsterHpComponent>()?.OnRevive();
                    break;
            }

            if (unit.Type == UnitType.Monster)
            {
                unit.GetComponent<GameObjectComponent>()?.OnRevive();
            }
            if (unit.MainHero)
            {
                root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>().OnSelfRevive();
            }
            
            unit.GetComponent<FsmComponent>()?.ChangeState(FsmStateEnum.FsmIdleState);
            await ETTask.CompletedTask;
        }
    }
}