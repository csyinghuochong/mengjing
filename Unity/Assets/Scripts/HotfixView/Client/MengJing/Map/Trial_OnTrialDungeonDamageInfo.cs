namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Trial_OnTrialDungeonDamageInfo: AEvent<Scene, TrialDungeonDamageInfo>
    {
        protected override async ETTask Run(Scene scene, TrialDungeonDamageInfo args)
        {
            
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTrialMain>()?.OnUpdateHurt(args.M2CTrialDungeonDamage);

            await ETTask.CompletedTask;
        }
    }
}