using System;

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

        public static void OnImage_ItemButton(this Scroll_Item_ActivitySingInItem self)
        {
            self.ClickHandler(self.ActivityConfig.Id);
        }

        public static void OnUpdateUI(this Scroll_Item_ActivitySingInItem self, ActivityConfig activityConfig, Action<int> action)
        {
            self.E_Image_ItemButtonButton.AddListener(self.OnImage_ItemButton);
            self.E_Image_XuanZhongImage.gameObject.SetActive(false);
            self.Image_ItemIconList[0] = self.E_Image_ItemIcon1Image.gameObject;
            self.Image_ItemIconList[1] = self.E_Image_ItemIcon2Image.gameObject;
            for (int i = 0; i < self.Image_ItemIconList.Length; i++)
            {
                self.Image_ItemIconList[i].SetActive(false);
            }

            int index = int.Parse(activityConfig.Par_1);
            self.ActivityConfig = activityConfig;

            using (zstring.Block())
            {
                self.E_Label_ItemNameText.text = zstring.Format("第{0}天", index);
            }

            int current = index % 2;
            self.Image_ItemIconList[current].SetActive(true);
            self.CurrentImage_ItemIcon = self.Image_ItemIconList[current];

            self.ClickHandler = action;
        }

        public static void SetSignState(this Scroll_Item_ActivitySingInItem self, int curDay, bool isSign)
        {
            CommonViewHelper.SetImageGray(self.Root(), self.CurrentImage_ItemIcon, int.Parse(self.ActivityConfig.Par_1) > curDay);
        }

        public static void SetSelected(this Scroll_Item_ActivitySingInItem self, int activityId)
        {
            self.E_Image_XuanZhongImage.gameObject.SetActive(self.ActivityConfig.Id == activityId);
        }
    }
}