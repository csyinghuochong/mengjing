using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_ChengJiuRewardItem))]
    [EntitySystemOf(typeof (Scroll_Item_ChengJiuRewardItem))]
    public static partial class Scroll_Item_ChengJiuRewardItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_ChengJiuRewardItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_ChengJiuRewardItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClick_DiButton(this Scroll_Item_ChengJiuRewardItem self)
        {
            self.ClickHandler(self.ChengJiuRewardId);
        }

        public static void SetSelected(this Scroll_Item_ChengJiuRewardItem self, int rewardId)
        {
            self.E_XuanZhongImage.gameObject.SetActive(rewardId == self.ChengJiuRewardId);
        }

        public static void SetClickHanlder(this Scroll_Item_ChengJiuRewardItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnInitData(this Scroll_Item_ChengJiuRewardItem self, ChengJiuRewardConfig chengJiuRewardConfig, bool received)
        {
            self.ChengJiuRewardId = chengJiuRewardConfig.Id;

            self.E_ChengJiuNumText.text = chengJiuRewardConfig.NeedPoint.ToString();
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ChengJiuIcon, chengJiuRewardConfig.Icon.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ChengJiuIconImage.sprite = sp;

            self.E_ReceivedButton.gameObject.SetActive(received);

            //self.E_DiButtonButton.AddListener(self.OnClick_DiButton);
            self.E_ChengJiuIconImage.gameObject.GetComponent<Button>().AddListener(self.OnClick_DiButton);
        }
    }
}