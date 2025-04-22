using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ZuoQiShowItem))]
    [EntitySystemOf(typeof(Scroll_Item_ZuoQiShowItem))]
    public static partial class Scroll_Item_ZuoQiShowItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ZuoQiShowItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ZuoQiShowItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClick(this Scroll_Item_ZuoQiShowItem self)
        {
            self.GetParent<ES_ZuoQiShow>().UpdateInfo(self.ZuoQiConfig);
        }

        public static void OnInitUI(this Scroll_Item_ZuoQiShowItem self, ZuoQiShowConfig zuoQiConfig)
        {
            self.E_ClickButton.AddListener(self.OnClick);

            self.ZuoQiConfig = zuoQiConfig;

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ZuoQiIcon, zuoQiConfig.Icon);
            self.E_IconImage.sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);
            CommonViewHelper.SetImageGray(self.Root(), self.E_IconImage.gameObject, !self.IsHaveZuoQi(zuoQiConfig.Id));
            
            self.E_TextNameText.text = zuoQiConfig.Name;

            int quility = zuoQiConfig.Quality;
            for (int i = 0; i < self.EG_StarListRectTransform.childCount; i++)
            {
                self.EG_StarListRectTransform.GetChild(i).gameObject.SetActive(quility > i);
            }
            self.E_TextNameText.color = FunctionUI.QualityReturnColor(quility);
        }

        private static bool IsHaveZuoQi(this Scroll_Item_ZuoQiShowItem self, int zuoqiId)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            return userInfo.HorseIds.Contains(zuoqiId);
        }

        public static void SetSelected(this Scroll_Item_ZuoQiShowItem self, int zuoqiId)
        {
            self.E_SelectedImage.gameObject.SetActive(self.ZuoQiConfig.Id == zuoqiId);
        }
    }
}