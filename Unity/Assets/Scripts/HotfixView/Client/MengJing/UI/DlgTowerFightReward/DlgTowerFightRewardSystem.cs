using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgTowerFightReward))]
    public static class DlgTowerFightRewardSystem
    {
        public static void RegisterUIEvent(this DlgTowerFightReward self)
        {
            self.View.E_Btn_ReturnButton.AddListener(self.OnBtn_Return);
        }

        public static void ShowWindow(this DlgTowerFightReward self, Entity contextData = null)
        {
        }

        public static void OnUpdateUI(this DlgTowerFightReward self, M2C_FubenSettlement message)
        {
            if (self.View.E_Text_ResultText == null)
            {
                return;
            }

            if (self.Root() == null || self.Root().CurrentScene() == null)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit == null)
            {
                return;
            }

            int towerId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.TowerId);
            if (!TowerConfigCategory.Instance.Contain(towerId))
            {
                return;
            }

            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(towerId);
            if (message.BattleResult == CombatResultEnum.Fail)
            {
                self.View.E_Text_ResultText.text = $"挑战失败";
            }
            else
            {
                self.View.E_Text_ResultText.text = $"你当前成功完成挑战{towerConfig.CengNum}波,获得奖励如下:";
            }

            string rewardList = $"1;{message.RewardGold}@2;{message.RewardExp}";
            self.View.ES_RewardList.Refresh(rewardList);
        }

        public static void OnBtn_Return(this DlgTowerFightReward self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerFightReward);
        }
    }
}