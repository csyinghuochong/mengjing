using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_StoreItem))]
    [FriendOf(typeof(DlgStore))]
    public static class DlgStoreSystem
    {
        public static void RegisterUIEvent(this DlgStore self)
        {
            // self.View.E_closeButtonButton.AddListener(self.OncloseButtonButton);
            self.View.E_StoreItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnStoreItemsRefresh);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
            
            self.InitModelShowView();
            self.InitData(self.Root().GetComponent<UIComponent>().CurrentNpcId);
        }

        public static void ShowWindow(this DlgStore self, Entity contextData = null)
        {
        }

        private static void InitModelShowView(this DlgStore self)
        {
            //配置摄像机位置[0,115,257]
            self.View.ES_ModelShow.SetCameraPosition(new Vector3(0f, 100, 257f));
            self.View.ES_ModelShow.Camera.fieldOfView = 50;
        }

        public static void OncloseButtonButton(this DlgStore self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Store);
        }

        public static void InitData(this DlgStore self, int npcid)
        {
            NpcConfig npcConfig = NpcConfigCategory.Instance.Get(npcid);
            int shopSellid = npcConfig.ShopValue;

            int playLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;

            self.ShowStores.Clear();
            while (shopSellid != 0)
            {
                StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(shopSellid);

                if (playLv < storeSellConfig.ShowRoleLvMin || playLv > storeSellConfig.ShowRoleLvMax)
                {
                    continue;
                }

                self.ShowStores.Add(shopSellid);
                shopSellid = storeSellConfig.NextID;
            }

            self.AddUIScrollItems(ref self.ScrollItemStoreItems, self.ShowStores.Count);
            self.View.E_StoreItemsLoopVerticalScrollRect.SetVisible(true, self.ShowStores.Count);

            using (zstring.Block())
            {
                self.View.ES_ModelShow.ShowOtherModel(zstring.Format("Npc/{0}", npcConfig.Asset)).Coroutine();
            }
        }

        private static void OnStoreItemsRefresh(this DlgStore self, Transform transform, int index)
        {
            foreach (Scroll_Item_StoreItem item in self.ScrollItemStoreItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_StoreItem scrollItemStoreItem = self.ScrollItemStoreItems[index].BindTrans(transform);
            StoreSellConfig storeSellConfig = StoreSellConfigCategory.Instance.Get(self.ShowStores[index]);
            scrollItemStoreItem.OnUpdateData(storeSellConfig);
        }
    }
}
