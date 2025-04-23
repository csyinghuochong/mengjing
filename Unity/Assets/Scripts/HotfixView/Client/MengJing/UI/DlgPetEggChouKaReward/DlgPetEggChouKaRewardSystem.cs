using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetEggChouKaRewardItem))]
    [FriendOf(typeof(DlgPetEggChouKaReward))]
    public static class DlgPetEggChouKaRewardSystem
    {
        public static void RegisterUIEvent(this DlgPetEggChouKaReward self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgPetEggChouKaReward self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgPetEggChouKaReward self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
        }
        
        private static void OnInitUI(this DlgPetEggChouKaReward self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            using (zstring.Block())
            {
                self.View.E_TextTitleText.text =
                        zstring.Format("今日探索次数:{0}", unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExploreNumber));
            }

            self.ShowInfo.Clear();
            foreach (KeyValuePair<int, string> keyValuePair in ConfigData.PetExploreReward)
            {
                self.ShowInfo.Add(keyValuePair.Key);
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowInfo.Count; i++)
            {
                if (!self.ScrollItemPetEggChouKaRewardItems.ContainsKey(i))
                {
                    Scroll_Item_PetEggChouKaRewardItem item = self.AddChild<Scroll_Item_PetEggChouKaRewardItem>();
                    string path = "Assets/Bundles/UI/Item/Item_PetEggChouKaRewardItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.View.E_PetEggChouKaRewardItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemPetEggChouKaRewardItems.Add(i, item);
                }

                Scroll_Item_PetEggChouKaRewardItem scrollItemPetEggChouKaRewardItem = self.ScrollItemPetEggChouKaRewardItems[i];
                scrollItemPetEggChouKaRewardItem.uiTransform.gameObject.SetActive(true);
                scrollItemPetEggChouKaRewardItem.OnUpdateUI(self.ShowInfo[i]);
            }

            if (self.ScrollItemPetEggChouKaRewardItems.Count > self.ShowInfo.Count)
            {
                for (int i = self.ShowInfo.Count; i < self.ScrollItemPetEggChouKaRewardItems.Count; i++)
                {
                    Scroll_Item_PetEggChouKaRewardItem scrollItemPetEggChouKaRewardItem = self.ScrollItemPetEggChouKaRewardItems[i];
                    scrollItemPetEggChouKaRewardItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }

        private static void OnBtn_CloseButton(this DlgPetEggChouKaReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetEggChouKaReward);
        }
    }
}
