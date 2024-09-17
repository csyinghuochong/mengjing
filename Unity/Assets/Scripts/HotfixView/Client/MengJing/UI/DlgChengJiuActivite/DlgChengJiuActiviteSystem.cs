using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgChengJiuActivite))]
    public static class DlgChengJiuActiviteSystem
    {
        public static void RegisterUIEvent(this DlgChengJiuActivite self)
        {
        }

        public static void ShowWindow(this DlgChengJiuActivite self, Entity contextData = null)
        {
        }

        public static async ETTask OnInitUI(this DlgChengJiuActivite self, int chengjiuId)
        {
            ChengJiuConfig chengJiuConfig = ChengJiuConfigCategory.Instance.Get(chengjiuId);
            self.View.E_Text_ChengJiuDescText.text = chengJiuConfig.Des;
            self.View.E_Text_ChengJiuPointText.text = chengJiuConfig.RewardNum.ToString();
            self.View.E_Text_ChengJiuNameText.text = chengJiuConfig.Name;
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ChengJiuIcon, chengJiuConfig.Icon.ToString());
            Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_ChengJiuIconImage.sprite = sprite;

            long instanceId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(3000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ChengJiuActivite);
        }
    }
}