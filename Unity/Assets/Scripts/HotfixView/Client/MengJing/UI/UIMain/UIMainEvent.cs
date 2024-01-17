using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.UIMain)]
    public class UIMainEvent: AUIEvent
    {
        public override async ETTask<UI> OnCreate(MJUIComponent uiComponent)
        {
            try
            {
                var path = ABPathHelper.GetUGUIPath(UIType.UIMain);
                GameObject bundleGameObject =
                        await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
                UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.UIMain, gameObject);
                ui.AddComponent<UIMainComponent>();
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