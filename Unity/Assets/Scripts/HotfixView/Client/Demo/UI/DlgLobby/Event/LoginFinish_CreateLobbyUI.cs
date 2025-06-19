using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using static UnityEngine.ShaderVariantCollection;

namespace ET.Client
{

    public static class ShaderWarmupHelper
    {
        public static void WarmupShader(Shader shader)
        {
            if (shader == null) return;

            // 使用反射调用内部方法
            MethodInfo warmupMethod = typeof(Shader).GetMethod(
                "WarmupAllShadersFor",
                BindingFlags.NonPublic | BindingFlags.Static
            );

            if (warmupMethod != null)
            {
                warmupMethod.Invoke(null, new object[] { new Shader[] { shader } });
                Debug.Log($"成功预热 Shader: {shader.name}");
            }
            else
            {
                Debug.LogError("无法找到 Shader 预热方法");
            }
        }


        public static void WarmupShader2(Scene scene, Shader problematicShader)
        {
            var path = ("Assets/Bundles/Material/MyShaderVariants2.shadervariants");
            ShaderVariantCollection shaderVariants =  scene.GetComponent<ResourcesLoaderComponent>().LoadAssetSync<ShaderVariantCollection>(path);

            // 创建临时多重采样纹理
            RenderTexture msaaTexture = new RenderTexture(1024, 1024, 24);
            msaaTexture.antiAliasing = 4; // 4x MSAA
            msaaTexture.Create();

            // 为材质设置正确的纹理
            Material tempMaterial = new Material(problematicShader);
            tempMaterial.mainTexture = msaaTexture;

            // 将材质添加到变体集合（确保使用正确纹理）
            // 注意：需要在编辑器中手动配置 ShaderVariantCollection

            // 预热
            if (shaderVariants != null)
            {
                shaderVariants.WarmUp();
            }

            // 清理资源
            GameObject.Destroy(tempMaterial);
            GameObject.Destroy(msaaTexture);
        }
    }


    [Event(SceneType.Demo)]
    public class LoginFinish_CreateLobbyUI : AEvent<Scene, LoginFinish>
    {
        protected override async ETTask Run(Scene scene, LoginFinish args)
        {
            FangChenMiComponentC fangChenMiComponent = scene.GetComponent<FangChenMiComponentC>();
            if (fangChenMiComponent.GetPlayerAge() < 18)
            {
                DateTime dateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ServerNow());
                //if (dateTime.Hour !=20 )
                //{
                //    string content = HintHelp.GetErrorHint(ErrorCode.ERR_FangChengMi_Tip1);
                //    content = content.Replace("{0}", "0");
                //    PopupTipHelp.OpenPopupTip_2(scene, "防沉迷提示",
                //        content,
                //        () =>
                //        {
                //            //EventSystem.Instance.Publish(scene.Root(), new ReturnLogin());
                //            DlgMJLogin dlg =  scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMJLogin>();
                //            dlg?.HideLoadingView();
                //        }).Coroutine();
                //}
                //else
                {
                    string minute = (60 - dateTime.Minute).ToString();
                    string content = HintHelp.GetErrorHint(ErrorCode.ERR_FangChengMi_Tip1);
                    content = content.Replace("{0}", minute);
                
                    await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_FangChengMiTip);
                    DlgFangChengMiTip dlgFangChengMiTip = scene.GetComponent<UIComponent>().GetDlgLogic<DlgFangChengMiTip>();
                    dlgFangChengMiTip.InitData("防沉迷提示", content, () => { OnLoginSucess(scene, args).Coroutine(); });
                }
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
            //scene.GetComponent<MapComponent>().MapType = MapTypeEnum.CreateRole;
            var path = ABPathHelper.GetScenePath("CreateRole");
            await scene.GetComponent<ResourcesLoaderComponent>().LoadSceneAsync(path, LoadSceneMode.Single);
            // await scene.GetComponent<TimerComponent>().WaitAsync(500);
            
            GlobalComponent.Instance.MainCamera.transform.localPosition = new Vector3(23f, 2f, 13f);
            GlobalComponent.Instance.MainCamera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            FlyTipComponent.Instance.ShowFlyTip("账号已完成实名认证!");
            // await scene.GetComponent<TimerComponent>().WaitAsync(500);
            
            await scene.GetComponent<TimerComponent>().WaitAsync(2000);

            PlayerInfoComponent playerInfoComponent = scene.GetComponent<PlayerInfoComponent>();
            await scene.GetComponent<UIComponent>()
                    .ShowWindowAsync(playerInfoComponent.CreateRoleList.Count > 0 ? WindowID.WindowID_MJLobby : WindowID.WindowID_CreateRole);
            scene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_MJLogin);

        }
    }
}