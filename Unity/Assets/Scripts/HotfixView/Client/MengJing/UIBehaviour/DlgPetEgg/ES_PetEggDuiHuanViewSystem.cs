using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_PetEggDuiHuan))]
    [FriendOfAttribute(typeof (ES_PetEggDuiHuan))]
    public static partial class ES_PetEggDuiHuanSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetEggDuiHuan self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_ChouKaCoin2Button.AddListener(() => { self.OnBtn_ChouKaCoin(3).Coroutine(); });
            self.E_Btn_ChouKaCoin1Button.AddListener(() => { self.OnBtn_ChouKaCoin(2).Coroutine(); });
            self.E_Btn_ChouKaCoin0Button.AddListener(() => { self.OnBtn_ChouKaCoin(1).Coroutine(); });
        }

        [EntitySystem]
        private static void Destroy(this ES_PetEggDuiHuan self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_PetEggDuiHuan self)
        {
            PetEggDuiHuanConfig cofig0 = PetEggDuiHuanConfigCategory.Instance.Get(1);
            string[] itemcost0 = cofig0.CostItems.Split(';');
            self.ES_CostItem_0.UpdateItem(int.Parse(itemcost0[0]), int.Parse(itemcost0[1]));

            PetEggDuiHuanConfig cofig1 = PetEggDuiHuanConfigCategory.Instance.Get(2);
            string[] itemcost1 = cofig1.CostItems.Split(';');
            self.ES_CostItem_1.UpdateItem(int.Parse(itemcost1[0]), int.Parse(itemcost1[1]));

            PetEggDuiHuanConfig cofig2 = PetEggDuiHuanConfigCategory.Instance.Get(3);
            string[] itemcost2 = cofig2.CostItems.Split(';');
            self.ES_CostItem_2.UpdateItem(int.Parse(itemcost2[0]), int.Parse(itemcost2[1]));
        }

        public static async ETTask OnBtn_ChouKaCoin(this ES_PetEggDuiHuan self, int index)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            PetEggDuiHuanConfig cofig0 = PetEggDuiHuanConfigCategory.Instance.Get(index);
            if (!bagComponent.CheckNeedItem(cofig0.CostItems))
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足！");
                return;
            }

            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) <= 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足！");
                return;
            }

            M2C_PetEggDuiHuanResponse response = await PetNetHelper.RequestPetEggDuiHuan(self.Root(), index);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonReward);
            DlgCommonReward dlgCommonReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>();
            dlgCommonReward.OnUpdateUI(response.RewardList);

            self.OnUpdateUI();
        }
    }
}
