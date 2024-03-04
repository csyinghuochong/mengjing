using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_EquipTips))]
    [FriendOfAttribute(typeof (ES_EquipTips))]
    public static partial class ES_EquipTipsSystem
    {
        [EntitySystem]
        private static void Awake(this ES_EquipTips self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_UseButton.AddListenerAsync(self.OnUseButton);
            self.E_TakeoffButton.AddListenerAsync(self.OnTakeoffButton);
            self.E_SellButton.AddListenerAsync(self.OnSellButton);

            self.E_SaveStoreHouseButton.AddListenerAsync(self.OnSaveStoreHouseButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipTips self)
        {
            self.DestroyWidget();
        }

        private static async ETTask OnUseButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTakeoffButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSellButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSaveStoreHouseButton(this ES_EquipTips self)
        {
            await ETTask.CompletedTask;
        }
    }
}