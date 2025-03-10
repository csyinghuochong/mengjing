namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UnitRemove_OnUnitRemove: AEvent<Scene, UnitRemove>
    {
        protected override async ETTask Run(Scene root, UnitRemove args)
        {
            root.GetComponent<LockTargetComponent>().OnUnitRemove(args.RemoveIds);
            
            root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnUnitUnitRemove(args.RemoveIds);
            await ETTask.CompletedTask;
        }
    }
}