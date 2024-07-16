using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgItemFumoSelect))]
    public static class DlgItemFumoSelectSystem
    {
        public static void RegisterUIEvent(this DlgItemFumoSelect self)
        {
        }

        public static void ShowWindow(this DlgItemFumoSelect self, Entity contextData = null)
        {
        }

        public static void OnInitUI(this DlgItemFumoSelect self, BagInfo fumoitem)
        {
            // self.FumoItemInfo = fumoitem;
            // ItemConfig itemConfig = ItemConfigCategory.Instance.Get(fumoitem.ItemID);
            // string[] itemparams = itemConfig.ItemUsePar.Split('@');
            // int weizhi = int.Parse(itemparams[0]);
            // List<BagInfo> equipinfos = self.ZoneScene().GetComponent<BagComponent>().GetEquipListByWeizhi(weizhi);
            //
            // for (int i = 0; i < equipinfos.Count; i++)
            // {
            //     self.ItemList[i].GameObject.SetActive(true);
            //     self.ItemList[i].UpdateItem(equipinfos[i], ItemOperateEnum.None);
            //     self.ItemList[i].ShowTip = false;
            //
            //     self.TextFomoPro[i].text = ItemViewHelp.GetFumpProDesc(equipinfos[i].FumoProLists);
            // }
            //
            // self.BagInfos = equipinfos;
        }

        public static void OnCloseTips(this DlgItemFumoSelect self)
        {
            // if (self.IsDisposed)
            // {
            //     return;
            // }
            //
            // UIHelper.Remove(self.DomainScene(), UIType.UIItemFumoSelect);
        }

        public static async ETTask OnSetClickHandler(this DlgItemFumoSelect self, BagInfo bagInfo)
        {
            // int index = self.BagInfos.IndexOf(bagInfo);
            // if (index == -1)
            // {
            //     index = 0;
            // }
            //
            // BagInfo equipinfo = self.BagInfos[index];
            // ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.FumoItemInfo.ItemID);
            // List<HideProList> hideProLists = XiLianHelper.GetItemFumoPro(itemConfig.Id);
            // string itemfumo = ItemViewHelp.GetFumpProDesc(hideProLists);
            // if (equipinfo.FumoProLists.Count > 0)
            // {
            //     string equipfumo = ItemViewHelp.GetFumpProDesc(equipinfo.FumoProLists);
            //     string fumopro = $"当前附魔属性<color=#BEFF34>{equipfumo}</color> \n是否覆盖已有属性\n{itemfumo}\n此附魔道具已消耗";
            //     self.ZoneScene().GetComponent<BagComponent>().SendFumoUse(self.FumoItemInfo, hideProLists).Coroutine();
            //     PopupTipHelp.OpenPopupTip(self.ZoneScene(), "装备附魔", fumopro, async () =>
            //     {
            //         await self.ZoneScene().GetComponent<BagComponent>().SendFumoPro(index);
            //         FloatTipManager.Instance.ShowFloatTip($"附魔属性 {itemfumo}");
            //
            //         UIHelper.Remove(self.ZoneScene(), UIType.UIItemFumoSelect);
            //     }, () => { UIHelper.Remove(self.ZoneScene(), UIType.UIItemFumoSelect); }).Coroutine();
            // }
            // else
            // {
            //     //await self.ZoneScene().GetComponent<BagComponent>().SendUseItem(self.FumoItemInfo, index.ToString());
            //     await self.ZoneScene().GetComponent<BagComponent>().SendFumoUse(self.FumoItemInfo, hideProLists);
            //     await self.ZoneScene().GetComponent<BagComponent>().SendFumoPro(index);
            //     FloatTipManager.Instance.ShowFloatTip($"附魔属性 {itemfumo}");
            //
            //     UIHelper.Remove(self.ZoneScene(), UIType.UIItemFumoSelect);
            // }
            await ETTask.CompletedTask;
        }
    }
}