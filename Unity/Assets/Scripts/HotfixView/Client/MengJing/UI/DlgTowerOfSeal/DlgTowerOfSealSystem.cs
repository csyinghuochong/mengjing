using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (DlgTowerOfSeal))]
    public static class DlgTowerOfSealSystem
    {
        public static void RegisterUIEvent(this DlgTowerOfSeal self)
        {
            self.View.E_Btn_EnterButton.AddListenerAsync(self.OnBtn_Enter);
        }

        public static void ShowWindow(this DlgTowerOfSeal self, Entity contextData = null)
        {
            self.UpdateRewardShowList();
        }
        
        public static void UpdateRewardShowList(this DlgTowerOfSeal self)
        {
            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
            int playerlv = userInfoComponentC.UserInfo.Lv;
            int bossid = TowerHelper.GetSealTowerBoss(playerlv);
            
            List<RewardItem> droplist = DropHelper.Show_MonsterDropNoRepeat(bossid, 1f, true);
            self.View.ES_RewardList.Refresh(droplist, 1f, false);
        }

        public static async ETTask OnBtn_Enter(this DlgTowerOfSeal self)
        {
            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            // 获取今日已经到达的封印之地的层数，如果没有则重置为0
            int finished = myUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.SealTowerFinished);
            // 判断是否到达100层
            if (finished >= 100)
            {
                FlyTipComponent.Instance.ShowFlyTip("今日已经达到塔顶，请明天再来挑战哦!");
                return;
            }

            // 还未到达100层，可以继续闯塔
            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.SealTower,
                BattleHelper.GetSceneIdByType(MapTypeEnum.SealTower), 0, "0");
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerOfSeal, false);
            }
        }
    }
}
