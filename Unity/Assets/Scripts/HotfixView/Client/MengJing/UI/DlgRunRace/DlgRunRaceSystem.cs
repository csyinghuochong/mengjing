using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgRunRace))]
    public static class DlgRunRaceSystem
    {
        public static void RegisterUIEvent(this DlgRunRace self)
        {
            self.View.E_EnterBtnButton.AddListenerAsync(self.OnEnterBtn);

            self.View.E_RunRaceItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRunRaceItemsRefresh);
        }

        public static void ShowWindow(this DlgRunRace self, Entity contextData = null)
        {
            self.ShowHuntRewards();
        }

        private static void OnRunRaceItemsRefresh(this DlgRunRace self, Transform transform, int index)
        {
            Scroll_Item_RunRaceItem scrollItemRunRaceItem = self.ScrollItemRunRaceItems[index].BindTrans(transform);
            scrollItemRunRaceItem.OnUpdate(self.ShowRankRewardConfigs[index]);
        }

        public static void ShowHuntRewards(this DlgRunRace self)
        {
            self.ShowRankRewardConfigs = RankHelper.GetTypeRankRewards(5);

            self.AddUIScrollItems(ref self.ScrollItemRunRaceItems, self.ShowRankRewardConfigs.Count);
            self.View.E_RunRaceItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankRewardConfigs.Count);
        }

        public static async ETTask OnEnterBtn(this DlgRunRace self)
        {
            int errorCode =
                    await EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.RunRace, BattleHelper.GetSceneIdByType(SceneTypeEnum.RunRace));
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RunRace);
        }
    }
}