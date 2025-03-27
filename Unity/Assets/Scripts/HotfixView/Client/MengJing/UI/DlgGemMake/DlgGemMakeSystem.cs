using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.GemMakeCDTimer)]
    public class GemMakeCDTimer : ATimer<DlgGemMake>
    {
        protected override void Run(DlgGemMake self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [FriendOf(typeof(Scroll_Item_MakeItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(DlgGemMake))]
    public static class DlgGemMakeSystem
    {
        public static void RegisterUIEvent(this DlgGemMake self)
        {
            self.View.E_Btn_MakeButton.AddListenerAsync(self.OnBtn_MakeButton);
            self.View.E_MakeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMakeItemsRefresh);
            
            self.OnInitUI();
            int showValue = NpcConfigCategory.Instance.Get(self.Root().GetComponent<UIComponent>().CurrentNpcId).ShopValue;
            self.UpdateMakeList(showValue);
        }

        public static void ShowWindow(this DlgGemMake self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgGemMake self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void OnInitUI(this DlgGemMake self)
        {
            self.UpateMakeItemUI();
        }

        public static async ETTask OnBtn_MakeButton(this DlgGemMake self)
        {
            if (self.MakeId == 0)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(self.MakeId);
            if (cdEndTime > TimeHelper.ServerNow())
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_InMakeCD);
                return;
            }

            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Gold < equipMakeConfig.MakeNeedGold)
            {
                FlyTipComponent.Instance.ShowFlyTip("金币不足！");
                return;
            }

            bool success = self.Root().GetComponent<BagComponentC>().CheckNeedItem(equipMakeConfig.NeedItems);
            if (!success)
            {
                FlyTipComponent.Instance.ShowFlyTip("材料不足！");
                return;
            }

            await BagClientNetHelper.RequestEquipMake(self.Root(), 0, self.MakeId, 1);
            self.OnCostItemUpdate();
        }

        public static void UpateMakeItemUI(this DlgGemMake self)
        {
            if (self.MakeId == 0)
            {
                self.View.ES_CommonItem.uiTransform.gameObject.SetActive(false);
                return;
            }

            self.View.ES_CommonItem.uiTransform.gameObject.SetActive(true);
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);
            if (self.View.ES_CommonItem.uiTransform.gameObject != null)
            {
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = equipMakeConfig.MakeItemID;
                self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.MakeItem);
                self.View.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            }
        }

        public static void OnCostItemUpdate(this DlgGemMake self)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);

            string needItems = equipMakeConfig.NeedItems;
            self.View.ES_CostList.Refresh(needItems);

            //显示名称
            self.View.E_Lab_MakeNameText.text = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID).ItemName;
            self.View.E_Lab_MakeNameText.color =
                    CommonViewHelper.QualityReturnColor(ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID).ItemQuality);
            self.View.E_Lab_MakeNumText.text = equipMakeConfig.MakeEquipNum.ToString();

            //显示消耗活力
            self.View.E_TextVitalityText.text = equipMakeConfig.MakeNeedGold.ToString();
            using (zstring.Block())
            {
                self.View.E_Text_CurrentText.text = zstring.Format("当前金币:  {0}", self.Root().GetComponent<UserInfoComponentC>().UserInfo.Gold);
            }
        }

        public static void OnUpdate(this DlgGemMake self)
        {
            int makeId = self.MakeId;
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(makeId);
            if (cdEndTime <= TimeHelper.ServerNow())
            {
                self.View.E_Lab_MakeCDTimeText.gameObject.SetActive(false);
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                return;
            }

            self.View.E_Lab_MakeCDTimeText.text = TimeHelper.ShowLeftTime(cdEndTime - TimeHelper.ServerNow());
        }

        public static void ShowCDTime(this DlgGemMake self)
        {
            self.View.E_Lab_MakeCDTimeText.gameObject.SetActive(false);
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            int makeId = self.MakeId;
            if (makeId == 0)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            long cdEndTime = userInfoComponent.GetMakeTime(makeId);
            if (cdEndTime <= TimeHelper.ServerNow())
            {
                return;
            }

            self.View.E_Lab_MakeCDTimeText.gameObject.SetActive(true);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.GemMakeCDTimer, self);
            self.OnUpdate();
        }

        public static void OnSelectMakeItem(this DlgGemMake self, int makeid)
        {
            self.MakeId = makeid;
            self.View.EG_MakeINeedNodeRectTransform.gameObject.SetActive(makeid != 0);
            self.ShowCDTime();
            self.UpateMakeItemUI();
            self.OnCostItemUpdate();

            //设置选中框
            self.View.E_ImageSelectImage.gameObject.SetActive(false);
            if (self.ScrollItemMakeItems != null)
            {
                for (int k = 0; k < self.ScrollItemMakeItems.Count; k++)
                {
                    Scroll_Item_MakeItem scrollItemMakeItem = self.ScrollItemMakeItems[k];
                    if (scrollItemMakeItem.uiTransform == null)
                    {
                        continue;
                    }
                    // if (scrollItemMakeItem.MakeID == makeid)
                    // {
                    //     self.View.E_ImageSelectImage.gameObject.SetActive(true);
                    //     CommonViewHelper.SetParent(self.View.E_ImageSelectImage.gameObject, scrollItemMakeItem.uiTransform.gameObject);
                    //     self.View.E_ImageSelectImage.transform.localPosition = new Vector3(0f, 12f, 0f);
                    // }
                    // else
                    // {
                    //    
                    // }
                    scrollItemMakeItem.OnSelectMakeItem(scrollItemMakeItem.MakeID == makeid);
                }
            }
        }

        public static void UpdateMakeList(this DlgGemMake self, int makeType)
        {
            List<EquipMakeConfig> makeList = EquipMakeConfigCategory.Instance.GetAll().Values.ToList();
            self.ShowMake.Clear();
            for (int i = 0; i < makeList.Count; i++)
            {
                EquipMakeConfig equipMakeConfig = makeList[i];
                if (equipMakeConfig.ProficiencyType != makeType)
                {
                    continue;
                }

                self.ShowMake.Add(equipMakeConfig.Id);
            }

            self.AddUIScrollItems(ref self.ScrollItemMakeItems, self.ShowMake.Count);
            self.View.E_MakeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMake.Count);

            self.OnSelectMakeItem(self.ShowMake.Count == 0 ? 0 : self.ShowMake[0]);
        }

        private static void OnMakeItemsRefresh(this DlgGemMake self, Transform transform, int index)
        {
            Scroll_Item_MakeItem scrollItemMakeItem = self.ScrollItemMakeItems[index].BindTrans(transform);
            scrollItemMakeItem.SetClickAction((itemid) => { self.OnSelectMakeItem(itemid); });
            scrollItemMakeItem.OnUpdateUI(self.ShowMake[index]);
        }
    }
}
