using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_FriendListItem))]
    [EntitySystemOf(typeof (Scroll_Item_FriendListItem))]
    public static partial class Scroll_Item_FriendListItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_FriendListItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_FriendListItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_FriendListItem self, FriendInfo friendInfo, Action deleteAction, Action<FriendInfo> chatAction)
        {
            self.FriendInfo = friendInfo;
            self.E_HeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, friendInfo.Occ.ToString()));
            self.E_OnLineTimeText.text = friendInfo.OnLineTime == 1? "状态:在线" : "状态:离线";
            self.E_PlayerLevelText.text = $"等级: {friendInfo.PlayerLevel}级";
            self.E_PlayerNameText.text = friendInfo.PlayerName;
            self.E_OccNameText.text = "职业:" + OccupationConfigCategory.Instance.Get(friendInfo.Occ).OccupationName;

            self.E_DeleteButton.AddListenerAsync(async () =>
            {
                await FriendNetHelper.RequestFriendDelete(self.Root(), self.FriendInfo.UserId);
                deleteAction?.Invoke();
            });
            self.E_WatchButton.AddListener( () =>
            {
                FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
                flyTipComponent.SpawnFlyTipDi("功能暂未开放");
                // F2C_FriendDeleteResponse response = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.FriendInfo.UserId);
                // UI uI = await UIHelper.Create(self.DomainScene(), UIType.UIWatch);
                // uI.GetComponent<UIWatchComponent>().OnUpdateUI(m2C_SkillSet);
            });
            self.E_ChatButton.AddListener(() => { chatAction.Invoke(self.FriendInfo); });
        }
    }
}