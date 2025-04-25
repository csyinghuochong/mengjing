using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivitySingleRechargeItem))]
    [EntitySystemOf(typeof(ES_ActivitySingleRecharge))]
    [FriendOfAttribute(typeof(ES_ActivitySingleRecharge))]
    public static partial class ES_ActivitySingleRechargeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivitySingleRecharge self, Transform transform)
        {
            self.uiTransform = transform;

            self.InitInfo();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivitySingleRecharge self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;

            self.DestroyWidget();
        }

        public static void InitInfo(this ES_ActivitySingleRecharge self)
        {
            self.ShowItem.Clear();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != ActivityEnum.Type_35)
                {
                    continue;
                }

                self.ShowItem.Add(activityConfigs[i]);
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowItem.Count; i++)
            {
                if (!self.ScrollItemActivitySingleRechargeItems.ContainsKey(i))
                {
                    Scroll_Item_ActivitySingleRechargeItem item = self.AddChild<Scroll_Item_ActivitySingleRechargeItem>();
                    string path = "Assets/Bundles/UI/Item/Item_ActivitySingleRechargeItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_ActivitySingleRechargeItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemActivitySingleRechargeItems.Add(i, item);
                }

                Scroll_Item_ActivitySingleRechargeItem scrollItemActivitySingleRechargeItem = self.ScrollItemActivitySingleRechargeItems[i];
                scrollItemActivitySingleRechargeItem.uiTransform.gameObject.SetActive(true);
                scrollItemActivitySingleRechargeItem.OnUpdateData(self.ShowItem[i]);
            }

            if (self.ScrollItemActivitySingleRechargeItems.Count > self.ShowItem.Count)
            {
                for (int i = self.ShowItem.Count; i < self.ScrollItemActivitySingleRechargeItems.Count; i++)
                {
                    Scroll_Item_ActivitySingleRechargeItem scrollItemActivitySingleRechargeItem = self.ScrollItemActivitySingleRechargeItems[i];
                    scrollItemActivitySingleRechargeItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }
    }
}