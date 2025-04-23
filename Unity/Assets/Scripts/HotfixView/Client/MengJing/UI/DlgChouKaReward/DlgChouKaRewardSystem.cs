using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChouKaRewardItem))]
    [FriendOf(typeof(DlgChouKaReward))]
    public static class DlgChouKaRewardSystem
    {
        public static void RegisterUIEvent(this DlgChouKaReward self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgChouKaReward self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgChouKaReward self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
        }

        public static void OnInitUI(this DlgChouKaReward self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            using (zstring.Block())
            {
                self.View.E_TextTitleText.text = zstring.Format("今日探宝次数:{0}", unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ChouKa));
            }

            self.TakeCardRewardConfigs = TakeCardRewardConfigCategory.Instance.GetAll().Values.ToList();

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.TakeCardRewardConfigs.Count; i++)
            {
                if (!self.ScrollItemChouKaRewardItems.ContainsKey(i))
                {
                    Scroll_Item_ChouKaRewardItem item = self.AddChild<Scroll_Item_ChouKaRewardItem>();
                    string path = "Assets/Bundles/UI/Item/Item_ChouKaRewardItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.View.E_ChouKaRewardItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemChouKaRewardItems.Add(i, item);
                }

                Scroll_Item_ChouKaRewardItem scrollItemChouKaRewardItem = self.ScrollItemChouKaRewardItems[i];
                scrollItemChouKaRewardItem.uiTransform.gameObject.SetActive(true);
                scrollItemChouKaRewardItem.OnUpdateUI(self.TakeCardRewardConfigs[i]);
            }

            if (self.ScrollItemChouKaRewardItems.Count > self.TakeCardRewardConfigs.Count)
            {
                for (int i = self.TakeCardRewardConfigs.Count; i < self.ScrollItemChouKaRewardItems.Count; i++)
                {
                    Scroll_Item_ChouKaRewardItem scrollItemChouKaRewardItem = self.ScrollItemChouKaRewardItems[i];
                    scrollItemChouKaRewardItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }

        private static void OnBtn_CloseButton(this DlgChouKaReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ChouKaReward);
        }
    }
}
