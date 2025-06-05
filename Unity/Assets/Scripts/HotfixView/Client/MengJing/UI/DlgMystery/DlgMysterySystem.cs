using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MysteryItem))]
    [FriendOf(typeof (DlgMystery))]
    public static class DlgMysterySystem
    {
        public static void RegisterUIEvent(this DlgMystery self)
        {
            self.View.E_MysteryItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMysteryItemsRefresh);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
            
            self.InitModelShowView();
            self.RequestMystery().Coroutine();
        }

        public static void ShowWindow(this DlgMystery self, Entity contextData = null)
        {
        }

        private static void OnMysteryItemsRefresh(this DlgMystery self, Transform transform, int index)
        {
            foreach (Scroll_Item_MysteryItem item in self.ScrollItemMysteryItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_MysteryItem scrollItemMysteryItem = self.ScrollItemMysteryItems[index].BindTrans(transform);
            scrollItemMysteryItem.OnUpdateUI(self.MysteryItemInfos[index], self.Root().GetComponent<UIComponent>().CurrentNpcId);
        }

        private static void InitModelShowView(this DlgMystery self)
        {
            //配置摄像机位置[0,115,257]
            //self.View.ES_ModelShow.SetCameraPosition(new Vector3(0f, 115, 257f));
            //NpcConfig npcConfig = NpcConfigCategory.Instance.Get(self.Root().GetComponent<UIComponent>().CurrentNpcId);
            //self.View.ES_ModelShow.ShowOtherModel("Npc/" + npcConfig.Asset).Coroutine();
        }

        private static List<int> GetMysteryList(this DlgMystery self, int npcid)
        {
            List<int> itemList = new List<int>();

            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            int shopValue = npcConfig.ShopValue;
            while (shopValue != 0)
            {
                itemList.Add(shopValue);

                MysteryConfig mysteryConfig = MysteryConfigCategory.Instance.Get(shopValue);
                shopValue = mysteryConfig.NextId;
            }

            return itemList;
        }

        public static void UpdateMysteryItem(this DlgMystery self, int npcid, List<MysteryItemInfo> mysteryItemInfos)
        {
            List<int> itemList = self.GetMysteryList(npcid);

            self.MysteryItemInfos.Clear();
            for (int i = 0; i < mysteryItemInfos.Count; i++)
            {
                if (npcid!=1020 &&  !itemList.Contains(mysteryItemInfos[i].MysteryId))
                {
                    continue;
                }

                self.MysteryItemInfos.Add(mysteryItemInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemMysteryItems, self.MysteryItemInfos.Count);
            self.View.E_MysteryItemsLoopVerticalScrollRect.SetVisible(true, self.MysteryItemInfos.Count);
        }

        public static async ETTask RequestMystery(this DlgMystery self)
        {
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(self.Root().GetComponent<UIComponent>().CurrentNpcId);
            if (npcConfig.NpcType == 1012)
            {
                A2C_MysteryListResponse response =
                        await BagClientNetHelper.RquestMysteryList(self.Root(), self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId);

                self.UpdateMysteryItem(npcConfig.Id, response.MysteryItemInfos);
            }
            else
            {
                Actor_FubenMoNengResponse response = await BagClientNetHelper.RquestFubenMoNeng(self.Root());
                self.UpdateMysteryItem(npcConfig.Id, response.MysteryItemInfos);
            }
        }
    }
}
