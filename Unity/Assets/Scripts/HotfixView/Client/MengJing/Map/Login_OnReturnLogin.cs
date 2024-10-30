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
            // 这里发现个问题，当从游戏中返回登录界面从新登录游戏后。IUpdate和ILateUpdate会多调用一次
            // 定位到 Create时 this.schedulers[(int) schedulerType].Add(fiberId); 会添加重复的fiberId
            // Scheduler执行Update()时会重复调用相同的Fiber
            await FiberManager.Instance.Create(SchedulerType.Main, ConstFiberId.Main, 0, SceneType.Main, ""); 
            GameObject.Find("Global").GetComponent<Init>().TogglePatchWindow(false);
        }
    }
}