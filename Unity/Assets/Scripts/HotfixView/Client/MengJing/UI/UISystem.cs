using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (UI))]
    [EntitySystemOf(typeof (UI))]
    public static partial class UISystem
    {
        [EntitySystem]
        private static void Awake(this UI self, string name, GameObject gameObject)
        {
            self.nameChildren.Clear();
            gameObject.AddComponent<ComponentView>().Component = self;
            gameObject.layer = LayerMask.NameToLayer(LayerNames.UI);
            self.Name = name;
            self.GameObject = gameObject;
        }

        [EntitySystem]
        private static void Destroy(this UI self)
        {
            foreach (UI ui in self.nameChildren.Values)
            {
                ui.Dispose();
            }

            UnityEngine.Object.Destroy(self.GameObject);
            self.nameChildren.Clear();
            // self.OnUpdateUI = null;
            // self.OnShowUI = null;
        }
    }
}