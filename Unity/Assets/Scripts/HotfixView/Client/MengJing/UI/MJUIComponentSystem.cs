using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (MJUIComponent))]
    [FriendOf(typeof (MJUIComponent))]
    public static partial class MJUIComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MJUIComponent self)
        {
            MJUIComponent.Instance = self;

            self.UICamera = GameObject.Find("Global/UI/UICamera").GetComponent<Camera>();
            self.MainCamera = GameObject.Find("Global/MainCamera").GetComponent<Camera>();
            self.ResolutionWidth = (int)(Screen.currentResolution.width);
            self.ResolutionHeight = (int)(Screen.currentResolution.height);
        }

        [EntitySystem]
        private static void Destroy(this MJUIComponent self)
        {
            foreach (var field in self.UIs.Values)
            {
                field.Dispose();
            }

            self.UIs = new Dictionary<string, UI>();
        }

        public static async ETTask<UI> Create(this MJUIComponent self, string uiType)
        {
            UI ui;
            self.UIs.TryGetValue(uiType, out ui);
            if (ui != null)
                return ui;
            ui = await MJUIEventComponent.Instance.OnCreate(self, uiType);
            self.UIs.Add(uiType, ui);
            return ui;
        }

        public static void Remove(this MJUIComponent self, string uiType)
        {
            if (!self.UIs.TryGetValue(uiType, out UI ui))
            {
                return;
            }

            MJUIEventComponent.Instance.OnRemove(self, uiType);
            self.UIs.Remove(uiType);
            ui.Dispose();
        }

        public static UI Get(this MJUIComponent self, string name)
        {
            UI ui = null;
            self.UIs.TryGetValue(name, out ui);
            return ui;
        }
    }
}