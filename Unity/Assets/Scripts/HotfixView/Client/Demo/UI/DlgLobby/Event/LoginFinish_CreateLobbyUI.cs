using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class LoginFinish_CreateLobbyUI : AEvent<Scene, LoginFinish>
    {
        protected override async ETTask Run(Scene scene, LoginFinish args)
        {
            FangChenMiComponentC fangChenMiComponent = scene.GetComponent<FangChenMiComponentC>();
            if (fangChenMiComponent.GetPlayerAge() < 18)
            {
                DateTime dateTime = TimeHelper.DateTimeNow();
                string minute = (60 - dateTime.Minute).ToString();
                string content = HintHelp.GetErrorHint(ErrorCode.ERR_FangChengMi_Tip1);
                content = content.Replace("{0}", minute);
                
                await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_FangChengMiTip);
                DlgFangChengMiTip dlgFangChengMiTip = scene.GetComponent<UIComponent>().GetDlgLogic<DlgFangChengMiTip>();
                dlgFangChengMiTip.InitData("防沉迷提示", content, () => { OnLoginSucess(scene, args).Coroutine(); });
            }
            else
            {
                OnLoginSucess(scene, args).Coroutine();
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask OnLoginSucess(Scene scene, LoginFinish args)
        {
            // FlyTipComponent.Instance.ShowFlyTip("登录成功!");
            var path = ABPathHelper.GetScenePath("CreateRole");
            await scene.GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(path, LoadSceneMode.Single);
            // await scene.GetComponent<TimerComponent>().WaitAsync(500);

            GlobalComponent.Instance.MainCamera.transform.localPosition = new Vector3(23f, 2f, 13f);
            GlobalComponent.Instance.MainCamera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            FlyTipComponent.Instance.ShowFlyTip("账号已完成实名认证!");
            // await scene.GetComponent<TimerComponent>().WaitAsync(500);

            PlayerInfoComponent playerInfoComponent = scene.GetComponent<PlayerInfoComponent>();
            await scene.GetComponent<UIComponent>()
                    .ShowWindowAsync(playerInfoComponent.CreateRoleList.Count > 0 ? WindowID.WindowID_MJLobby : WindowID.WindowID_CreateRole);
            scene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MJLogin);
        }
    }
}