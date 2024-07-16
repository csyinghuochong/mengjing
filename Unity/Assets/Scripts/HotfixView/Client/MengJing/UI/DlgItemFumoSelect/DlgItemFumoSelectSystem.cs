using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(DlgItemFumoSelect))]
    public static class DlgItemFumoSelectSystem
    {
        public static void RegisterUIEvent(this DlgItemFumoSelect self)
        {
            self.View.E_BtnCloseButton.AddListener(self.OnCloseTips);
        }

        public static void ShowWindow(this DlgItemFumoSelect self, Entity contextData = null)
        {
            self.ItemList.Add(self.View.ES_CommonItem_0);
            self.ItemList.Add(self.View.ES_CommonItem_1);
            self.ItemList.Add(self.View.ES_CommonItem_2);

            ES_CommonItem item = self.View.ES_CommonItem_0;
            item.uiTransform.gameObject.SetActive(false);
            item.SetClickHandler((BagInfo bagInfo) => { self.OnSetClickHandler(bagInfo).Coroutine(); });

            item = self.View.ES_CommonItem_1;
            item.uiTransform.gameObject.SetActive(false);
            item.SetClickHandler((BagInfo bagInfo) => { self.OnSetClickHandler(bagInfo).Coroutine(); });

            item = self.View.ES_CommonItem_2;
            item.uiTransform.gameObject.SetActive(false);
            item.SetClickHandler((BagInfo bagInfo) => { self.OnSetClickHandler(bagInfo).Coroutine(); });

            Text text = self.View.E_Label_ItemFumo_0Text;
            text.text = string.Empty;
            self.TextFomoPro.Add(text);

            text = self.View.E_Label_ItemFumo_1Text;
            text.text = string.Empty;
            self.TextFomoPro.Add(text);

            text = self.View.E_Label_ItemFumo_2Text;
            text.text = string.Empty;
            self.TextFomoPro.Add(text);
        }

        public static void OnInitUI(this DlgItemFumoSelect self, BagInfo fumoitem)
        {
            self.FumoItemInfo = fumoitem;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(fumoitem.ItemID);
            string[] itemparams = itemConfig.ItemUsePar.Split('@');
            int weizhi = int.Parse(itemparams[0]);
            List<BagInfo> equipinfos = self.Root().GetComponent<BagComponentC>().GetEquipListByWeizhi(weizhi);

            for (int i = 0; i < equipinfos.Count; i++)
            {
                ES_CommonItem item = self.ItemList[i];
                item.uiTransform.gameObject.SetActive(true);
                item.UpdateItem(equipinfos[i], ItemOperateEnum.None);
                item.ShowTip = false;

                self.TextFomoPro[i].text = ItemViewHelp.GetFumpProDesc(equipinfos[i].FumoProLists);
            }

            self.BagInfos = equipinfos;
        }

        public static void OnCloseTips(this DlgItemFumoSelect self)
        {
            if (self.IsDisposed)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemFumoSelect);
        }

        public static async ETTask OnSetClickHandler(this DlgItemFumoSelect self, BagInfo bagInfo)
        {
            int index = self.BagInfos.IndexOf(bagInfo);
            if (index == -1)
            {
                index = 0;
            }

            BagInfo equipinfo = self.BagInfos[index];
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.FumoItemInfo.ItemID);
            List<HideProList> hideProLists = XiLianHelper.GetItemFumoPro(itemConfig.Id);
            string itemfumo = ItemViewHelp.GetFumpProDesc(hideProLists);
            if (equipinfo.FumoProLists.Count > 0)
            {
                string equipfumo = ItemViewHelp.GetFumpProDesc(equipinfo.FumoProLists);
                string fumopro = $"当前附魔属性<color=#BEFF34>{equipfumo}</color> \n是否覆盖已有属性\n{itemfumo}\n此附魔道具已消耗";
                BagClientNetHelper.SendFumoUse(self.Root(), self.FumoItemInfo, hideProLists).Coroutine();
                PopupTipHelp.OpenPopupTip(self.Root(), "装备附魔", fumopro, async () =>
                {
                    await BagClientNetHelper.SendFumoPro(self.Root(), index);
                    FlyTipComponent.Instance.ShowFlyTip($"附魔属性 {itemfumo}");

                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemFumoSelect);
                }, () => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemFumoSelect); }).Coroutine();
            }
            else
            {
                await BagClientNetHelper.SendFumoUse(self.Root(), self.FumoItemInfo, hideProLists);
                await BagClientNetHelper.SendFumoPro(self.Root(), index);
                FlyTipComponent.Instance.ShowFlyTip($"附魔属性 {itemfumo}");

                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemFumoSelect);
            }

            await ETTask.CompletedTask;
        }
    }
}