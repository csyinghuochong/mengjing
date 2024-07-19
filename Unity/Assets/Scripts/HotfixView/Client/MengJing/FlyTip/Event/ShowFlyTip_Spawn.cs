namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class ShowFlyTip_Spawn : AEvent<Scene, ShowFlyTip>
    {
        protected override async ETTask Run(Scene scene, ShowFlyTip args)
        {
            if (args.Type == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip(args.Str);
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTipDi(args.Str);
            }

            await ETTask.CompletedTask;
        }
    }
}