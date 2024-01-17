using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.UILogin)]
    public class UILoginEvent: AUIEvent
    {
        public override async ETTask<UI> OnCreate(MJUIComponent uiComponent)
        {
            try
            {
                var path = ABPathHelper.GetUGUIPath(UIType.UILogin);
                GameObject bundleGameObject =
                        await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
                UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.UILogin, gameObject);
                ui.AddComponent<UILoginComponent>();
                return ui;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }

        public override void OnRemove(MJUIComponent uiComponent)
        {
        }
    }
}