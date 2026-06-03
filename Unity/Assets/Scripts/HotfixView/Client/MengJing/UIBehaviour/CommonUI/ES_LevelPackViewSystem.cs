using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_LevelPackItem))]
    [EntitySystemOf(typeof(ES_LevelPack))]
    [FriendOfAttribute(typeof(ES_LevelPack))]
    public static partial class ES_LevelPackSystem
    {
        [EntitySystem]
        private static void Awake(this ES_LevelPack self, Transform transform)
        {
            self.uiTransform = transform;
            
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_LevelPack self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this ES_LevelPack self)
        {
            self.ShowActivityConfigs.Clear();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != ActivityEnum.Type_3)
                {
                    continue;
                }

                self.ShowActivityConfigs.Add(activityConfigs[i]);
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            string prefabPath = "Assets/Bundles/UI/Item/Item_LevelPackItem.prefab";
            for (int i = 0; i < self.ShowActivityConfigs.Count; i++)
            {
                if (!self.ScrollItemLevelPackItems.ContainsKey(i))
                {
                    Scroll_Item_LevelPackItem item = self.AddChild<Scroll_Item_LevelPackItem>();

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(prefabPath);
                    GameObject gameObject = UnityEngine.Object.Instantiate(prefab, self.E_LevelPackItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(gameObject.transform);
                    self.ScrollItemLevelPackItems.Add(i, item);
                }

                Scroll_Item_LevelPackItem scrollItemLevelPackItem = self.ScrollItemLevelPackItems[i];
                scrollItemLevelPackItem.uiTransform.gameObject.SetActive(true);
                scrollItemLevelPackItem.OnInitUI(self.ShowActivityConfigs[i]);
            }

            if (self.ScrollItemLevelPackItems.Count > self.ShowActivityConfigs.Count)
            {
                for (int i = self.ShowActivityConfigs.Count; i < self.ScrollItemLevelPackItems.Count; i++)
                {
                    Scroll_Item_LevelPackItem scrollItemLevelPackItem = self.ScrollItemLevelPackItems[i];
                    scrollItemLevelPackItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }
    }
}