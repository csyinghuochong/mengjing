using System;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_FriendBlackItem))]
    [EntitySystemOf(typeof (Scroll_Item_FriendBlackItem))]
    public static partial class Scroll_Item_FriendBlackItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_FriendBlackItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_FriendBlackItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_FriendBlackItem self, FriendInfo friendInfo, Action removeAction)
        {
            self.FriendInfo = friendInfo;

            self.E_HeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, friendInfo.Occ.ToString()));
            self.E_OnLineTimeText.text = friendInfo.OnLineTime == 1? "状态:在线" : "状态:离线";
            self.E_PlayerLevelText.text = $"等级: {friendInfo.PlayerLevel}级";
            self.E_PlayerNameText.text = friendInfo.PlayerName;
            self.E_OccNameText.text = "职业:" + OccupationConfigCategory.Instance.Get(friendInfo.Occ).OccupationName;

            self.E_WatchButton.AddListenerAsync(async () =>
            {
                FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
                flyTipComponent.SpawnFlyTipDi("功能暂未开放");
                // F2C_FriendDeleteResponse response = await FriendNetHelper.RequestWatchPlayer(self.Root(), self.FriendInfo.UserId);
                // UI uI = await UIHelper.Create(self.DomainScene(), UIType.UIWatch);
                // uI.GetComponent<UIWatchComponent>().OnUpdateUI(m2C_SkillSet);
                await ETTask.CompletedTask;
            });

            self.E_RemoveButton.AddListenerAsync(async () =>
            {
                await FriendNetHelper.RequestRemoveBlack(self.Root(), self.FriendInfo.UserId);
                await FriendNetHelper.RequestFriendInfo(self.Root());
                removeAction?.Invoke();
            });
        }
    }
}