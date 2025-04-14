using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RunRaceItem))]
    [FriendOf(typeof (DlgRunRace))]
    public static class DlgRunRaceSystem
    {
        public static void RegisterUIEvent(this DlgRunRace self)
        {
            self.View.E_EnterBtnButton.AddListenerAsync(self.OnEnterBtnButton);

            self.View.E_RunRaceItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRunRaceItemsRefresh);
            
            self.ShowHuntRewards();
        }

        public static void ShowWindow(this DlgRunRace self, Entity contextData = null)
        {
        }

        private static void OnRunRaceItemsRefresh(this DlgRunRace self, Transform transform, int index)
        {
            foreach (Scroll_Item_RunRaceItem item in self.ScrollItemRunRaceItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RunRaceItem scrollItemRunRaceItem = self.ScrollItemRunRaceItems[index].BindTrans(transform);
            scrollItemRunRaceItem.OnUpdate(self.ShowRankRewardConfigs[index]);
        }

        public static void ShowHuntRewards(this DlgRunRace self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(5);

            self.AddUIScrollItems(ref self.ScrollItemRunRaceItems, self.ShowRankRewardConfigs.Count);
            self.View.E_RunRaceItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        public static async ETTask OnEnterBtnButton(this DlgRunRace self)
        {
            int errorCode =
                    await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.RunRace, BattleHelper.GetSceneIdByType(MapTypeEnum.RunRace));
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RunRace);
        }
    }
}
