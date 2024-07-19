namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Login_OnReturnLogin: AEvent<Scene, ReturnLogin>
    {
        protected override async ETTask Run(Scene scene, ReturnLogin args)
        {
            // scene.GetComponent<UIComponent>().Clear();
            // UnitFactory.LoadingScene = false;
            MapComponent mapComponent = scene.GetComponent<MapComponent>();
            mapComponent.SceneType = SceneTypeEnum.LoginScene;

            if (args.ErrorCode == ErrorCode.ERR_OtherAccountLogin)
            {
                FlyTipComponent.Instance.ShowFlyTip("账号异地登录");
                RunAsync2(scene, args, 100).Coroutine();
            }
            else if (args.ErrorCode == ErrorCode.ERR_KickOutPlayer)
            {
                PopupTipHelp.OpenPopupTip(scene, "重新登录", "由于您长时间未操作，请重新登录！", () => { RunAsync2(scene, args, 100).Coroutine(); }).Coroutine();
            }
            else if (args.ErrorCode == ErrorCode.ERR_PackageFrequent)
            {
                PopupTipHelp.OpenPopupTip(scene, "消息异常", "请重新登录", () => { RunAsync2(scene, args, 100).Coroutine(); }).Coroutine();
            }
            else
            {
                RunAsync2(scene, args, 100).Coroutine();
            }

            await ETTask.CompletedTask;
        }

        private async ETTask RunAsync2(Scene scene, ReturnLogin args, long waitTime)
        {
            long instanceId = scene.InstanceId;

            TimerComponent timerComponent = scene.GetComponent<TimerComponent>();

            await timerComponent.WaitAsync(waitTime);
            if (instanceId != scene.InstanceId)
            {
                return;
            }

            // Scene oldroot = scene.Root();
            // scene.Root().RemoveComponent<ClientSenderCompnent>();
            // SceneManager.MoveGameObjectToScene(GameObject.Find("Global"), SceneManager.GetActiveScene());
            // GameObject.DestroyImmediate(GameObject.Find("Global"));
            // //await scene.Root().GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(ABPathHelper.GetScenePath("Init"), LoadSceneMode.Single);   
            // oldroot.Dispose();
            // World.Instance.Dispose();
            // SceneManager.LoadScene("Init");

            // Camera camera = UIComponent.Instance.MainCamera.gameObject.GetComponent<Camera>();
            // camera.GetComponent<MyCamera_1>().enabled = false;
            // Session session = scene.GetComponent<SessionComponent>().Session;
            // if (session != null && !session.IsDisposed)
            // {
            //     session.GetComponent<PingComponent>().DisconnectType = -1;
            // }
            //
            // Game.Scene.GetComponent<SceneManagerComponent>().ChangeScene(args.ZoneScene, (int)SceneTypeEnum.LoginScene, SceneTypeEnum.NONE, 1)
            //         .Coroutine();
            // args.ZoneScene.Dispose();
            // Scene zoneScene = SceneFactory.CreateZoneScene(1, "Game", Game.Scene);
            //
            // EventType.AppStartInitFinish.Instance.ZoneScene = zoneScene;
            // Game.EventSystem.PublishClass(EventType.AppStartInitFinish.Instance);
        }
    }
}