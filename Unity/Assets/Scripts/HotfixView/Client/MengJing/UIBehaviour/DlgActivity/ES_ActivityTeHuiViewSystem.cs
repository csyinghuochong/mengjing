using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivityTeHuiItem))]
    [EntitySystemOf(typeof(ES_ActivityTeHui))]
    [FriendOfAttribute(typeof(ES_ActivityTeHui))]
    public static partial class ES_ActivityTeHuiSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityTeHui self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivityTeHui self)
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

        public static void OnUpdateUI(this ES_ActivityTeHui self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < activityComponent.DayTeHui.Count; i++)
            {
                if (!self.ScrollItemActivityTeHuiItems.ContainsKey(i))
                {
                    Scroll_Item_ActivityTeHuiItem item = self.AddChild<Scroll_Item_ActivityTeHuiItem>();
                    string path = "Assets/Bundles/UI/Item/Item_ActivityTeHuiItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_ActivityTeHuiItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemActivityTeHuiItems.Add(i, item);
                }

                Scroll_Item_ActivityTeHuiItem scrollItemActivityTeHuiItem = self.ScrollItemActivityTeHuiItems[i];
                scrollItemActivityTeHuiItem.uiTransform.gameObject.SetActive(true);
                int activityId = activityComponent.DayTeHui[i];
                scrollItemActivityTeHuiItem.OnUpdateUI(activityId, activityComponent.ActivityReceiveIds.Contains(activityId));
            }

            if (self.ScrollItemActivityTeHuiItems.Count > activityComponent.DayTeHui.Count)
            {
                for (int i = self.ScrollItemActivityTeHuiItems.Count; i < self.ScrollItemActivityTeHuiItems.Count; i++)
                {
                    Scroll_Item_ActivityTeHuiItem scrollItemActivityTeHuiItem = self.ScrollItemActivityTeHuiItems[i];
                    scrollItemActivityTeHuiItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }
    }
}