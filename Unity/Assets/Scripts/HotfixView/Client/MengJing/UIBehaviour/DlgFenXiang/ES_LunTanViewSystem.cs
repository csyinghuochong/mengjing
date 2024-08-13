using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_LunTan))]
    [FriendOfAttribute(typeof (ES_LunTan))]
    public static partial class ES_LunTanSystem
    {
        [EntitySystem]
        private static void Awake(this ES_LunTan self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonGetButton.AddListener(self.OnButtonGetButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_LunTan self)
        {
            self.DestroyWidget();
        }

        public static void OnButtonGetButton(this ES_LunTan self)
        {
            Application.OpenURL("https://l.tapdb.net/jYTd08hD?channel=rep-rep_6t3lta8ujdb_h5url65");
        }
    }
}
