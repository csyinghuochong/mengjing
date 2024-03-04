using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ItemAppraisalTips))]
    [FriendOfAttribute(typeof (ES_ItemAppraisalTips))]
    public static partial class ES_ItemAppraisalTipsSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ItemAppraisalTips self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SellButton.AddListenerAsync(self.OnSellButton);
            self.E_UseButton.AddListenerAsync(self.OnUseButton);
            self.E_HuiShouButton.AddListenerAsync(self.OnHuiShouButton);
            self.E_HuiShouCancleButton.AddListenerAsync(self.OnHuiShouCancleButton);
            self.E_JingHeAddQualityButton.AddListenerAsync(self.OnJingHeAddQualityButton);
            self.E_JingHeActivateButton.AddListenerAsync(self.OnJingHeActivateButton);
            self.E_SaveStoreHouseButton.AddListenerAsync(self.OnSaveStoreHouseButton);
            self.E_TakeStoreHouseButton.AddListenerAsync(self.OnTakeStoreHouseButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_ItemAppraisalTips self)
        {
            self.DestroyWidget();
        }

        public static void RefreshInfo(this ES_ItemAppraisalTips self, BagInfo bagInfo, ItemOperateEnum itemOperateEnum)
        {
            
        }

        private static async ETTask OnSellButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnUseButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnHuiShouButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnHuiShouCancleButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnJingHeAddQualityButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnJingHeActivateButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnSaveStoreHouseButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnTakeStoreHouseButton(this ES_ItemAppraisalTips self)
        {
            await ETTask.CompletedTask;
        }
    }
}