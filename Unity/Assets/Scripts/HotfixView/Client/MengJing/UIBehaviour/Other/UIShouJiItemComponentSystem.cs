using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UIShouJiItemComponent))]
    [EntitySystemOf(typeof (UIShouJiItemComponent))]
    public static partial class UIShouJiItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIShouJiItemComponent self, GameObject go)
        {
            self.GameObject = go;
            self.Label_ItemName = go.Get<GameObject>("Label_ItemName");
            self.Image_ItemIcon = go.Get<GameObject>("Image_ItemIcon");
            self.Image_ItemQuality = go.Get<GameObject>("Image_ItemQuality");
            self.Label_HaveTag = go.Get<GameObject>("Label_HaveTag");
            self.Label_StarNum = go.Get<GameObject>("Label_StarNum");
        }

        public static void OnUpdateUI(this UIShouJiItemComponent self, int chapterId, ShouJiItemConfig shouJiItemConfig)
        {
            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(shouJiItemConfig.ItemID);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            self.Image_ItemIcon.GetComponent<Image>().sprite = sp;
            string qualityiconStr = FunctionUI.ItemQualiytoPath(itemconfig.ItemQuality);
            string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, qualityiconStr);
            Sprite sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);

            self.Image_ItemQuality.GetComponent<Image>().sprite = sp1;

            self.Label_ItemName.GetComponent<Text>().text = itemconfig.ItemName;
            self.Label_ItemName.GetComponent<Text>().color = FunctionUI.QualityReturnColor(itemconfig.ItemQuality);

            self.Label_StarNum.GetComponent<Text>().text = shouJiItemConfig.StartNum.ToString();
            ShoujiComponentC shoujiComponent = self.Root().GetComponent<ShoujiComponentC>();
            bool have = shoujiComponent.HaveShouJiItem(chapterId, shouJiItemConfig.ItemID);
            self.Label_HaveTag.GetComponent<Text>().text = have? "已拥有" : "未拥有";
            self.Label_HaveTag.GetComponent<Text>().color = have? Color.green : Color.white;
            CommonViewHelper.SetImageGray(self.Root(), self.Image_ItemIcon, !have);
            CommonViewHelper.SetImageGray(self.Root(), self.Image_ItemQuality, !have);
        }
    }
}