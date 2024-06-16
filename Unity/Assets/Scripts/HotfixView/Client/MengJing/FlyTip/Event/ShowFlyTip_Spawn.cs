namespace ET.Client
{

    [Event(SceneType.Demo)]
    public class ShowFlyTip_Spawn : AEvent<Scene, ShowFlyTip>
    {
        protected override async ETTask Run(Scene scene, ShowFlyTip args)
        {
            if (args.Type == 0)
            {
                scene.GetComponent<FlyTipComponent>().SpawnFlyTip(args.Str);
            }
            else
            {
                scene.GetComponent<FlyTipComponent>().SpawnFlyTipDi(args.Str);
            }

            await ETTask.CompletedTask;
        }
    }
}