using UnityEngine;

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

            switch (args.ErrorCode)
            {
                case ErrorCode.ERR_OtherAccountLogin:
                    FlyTipComponent.Instance.ShowFlyTip("账号异地登录");
                    RunAsync2(scene, args, 100).Coroutine();
                    break;
                case ErrorCode.ERR_KickOutPlayer:
                    PopupTipHelp.OpenPopupTip(scene, "重新登录", "由于您长时间未操作，请重新登录！", () => { RunAsync2(scene, args, 100).Coroutine(); }).Coroutine(); 
                    break;
                case ErrorCode.ERR_PackageFrequent:
                    PopupTipHelp.OpenPopupTip(scene, "消息异常", "请重新登录", () => { RunAsync2(scene, args, 100).Coroutine(); }).Coroutine();
                    break;
                default:
                    RunAsync2(scene, args, 100).Coroutine();
                    break;
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

            Scene oldroot = scene.Root();
            scene.Root().RemoveComponent<ClientSenderCompnent>();
            oldroot.CurrentScene().Dispose();
            oldroot.GetComponent<UIComponent>().CloseAllWindow();
            GameObject.Find("Global").GetComponent<Init>().TogglePatchWindow(true);
            await FiberManager.Instance.Remove(oldroot.Fiber.Id);
            await FiberManager.Instance.Create(SchedulerType.Main, ConstFiberId.Main, 0, SceneType.Main, "");
            GameObject.Find("Global").GetComponent<Init>().TogglePatchWindow(false);
        }
    }
}