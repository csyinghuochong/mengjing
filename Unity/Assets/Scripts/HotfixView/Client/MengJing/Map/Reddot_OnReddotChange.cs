namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Reddot_OnReddotChange: AEvent<Scene, ReddotChange>
    {
        protected override async ETTask Run(Scene scene, ReddotChange args)
        {
            ReddotViewComponent reddotComponent = scene.GetComponent<ReddotViewComponent>();
            reddotComponent.ChangeCountReddot(args.ReddotType, args.Number);
            await ETTask.CompletedTask;
        }
    }
}