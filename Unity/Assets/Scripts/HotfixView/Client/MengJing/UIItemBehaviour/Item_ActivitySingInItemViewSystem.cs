using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivitySingInItem))]
    [EntitySystemOf(typeof(Scroll_Item_ActivitySingInItem))]
    public static partial class Scroll_Item_ActivitySingInItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ActivitySingInItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ActivitySingInItem self)
        {
            self.DestroyWidget();
        }

        public static void OnItemButton(this Scroll_Item_ActivitySingInItem self)
        {
            self.ClickHandler(self.ActivityConfig.Id);
        }

        public static void OnUpdateUI(this Scroll_Item_ActivitySingInItem self, ActivityConfig activityConfig, Action<int> action)
        {
            self.E_ItemButtonButton.AddListener(self.OnItemButton);
            self.E_XuanZhongImage.gameObject.SetActive(false);

            self.ActivityConfig = activityConfig;
            self.ClickHandler = action;

            using (zstring.Block())
            {
                int index = int.Parse(activityConfig.Par_1);
                self.E_DayText.text = zstring.Format("第{0}天", index);
            }

            string[] itemInfo = activityConfig.Par_2.Split(';');
            int itemid = int.Parse(itemInfo[0]);    
            ItemConfig itemConfig= ItemConfigCategory.Instance.Get(itemid);     
            self.E_ItemIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
            self.E_ItemNumText.text = itemInfo[1];

            self.UpdateLingQu();
        }

        public static void UpdateLingQu(this Scroll_Item_ActivitySingInItem self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            self.E_LingQuImage.gameObject.SetActive(activityComponent.ActivityReceiveIds.Contains(self.ActivityConfig.Id));
        }

        public static void SetSignState(this Scroll_Item_ActivitySingInItem self, int curDay)
        {
            self.E_XuanZhongImage.gameObject.SetActive(int.Parse(self.ActivityConfig.Par_1) == curDay);
        }

        public static void SetSelected(this Scroll_Item_ActivitySingInItem self, int activityId)
        {
            self.E_XuanZhongImage.gameObject.SetActive(self.ActivityConfig.Id == activityId);
        }
    }
}