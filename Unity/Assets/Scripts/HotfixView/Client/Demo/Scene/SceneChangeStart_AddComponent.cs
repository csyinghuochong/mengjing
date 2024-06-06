using System;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class SceneChangeStart_AddComponent: AEvent<Scene, SceneChangeStart>
    {
        protected override async ETTask Run(Scene root, SceneChangeStart args)
        {
            try
            {
                Scene currentScene = root.CurrentScene();

                ResourcesLoaderComponent resourcesLoaderComponent = currentScene.GetComponent<ResourcesLoaderComponent>();

                string sceneName = currentScene.Name;
                MapComponent mapComponent = root.GetComponent<MapComponent>();
                if (SceneConfigHelper.UseSceneConfig( args.SceneType ))
                {
                    sceneName = SceneConfigCategory.Instance.Get(mapComponent.SceneId).MapID.ToString();
                }

                // 加载场景资源
                await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/{sceneName}.unity", LoadSceneMode.Single);
                // 切换到map场景

                //await SceneManager.LoadSceneAsync(currentScene.Name);
                root.GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.BeginEnterScene(args.LastSceneType);

                currentScene.AddComponent<OperaComponent>();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
    }
}