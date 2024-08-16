using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(ES_RewardList))]
    [EntitySystemOf(typeof(Scroll_Item_TeamDungeonSettlementPlayer))]
    public static partial class Scroll_Item_TeamDungeonSettlementPlayerSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_TeamDungeonSettlementPlayer self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_TeamDungeonSettlementPlayer self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_TeamDungeonSettlementPlayer self, TeamPlayerInfo teamPlayerInfo, List<RewardItem> rewardItems)
        {
            self.ES_RewardList.uiTransform.gameObject.SetActive(false);

            self.E_Text_NameText.text = teamPlayerInfo.PlayerName;
            using (zstring.Block())
            {
                self.E_Text_LevelText.text = zstring.Format("等级：{0}", teamPlayerInfo.PlayerLv);
                self.E_Text_DamageText.text = zstring.Format("伤害：{0}", teamPlayerInfo.Damage);
                CommonViewHelper.ShowOccIcon(self.Root(), self.E_ImageIconImage.gameObject, teamPlayerInfo.Occ);

                self.ES_RewardList.uiTransform.gameObject.SetActive(rewardItems != null);
                if (rewardItems != null)
                {
                    string itemList = zstring.Format("{0};{1}", rewardItems[0].ItemID, rewardItems[0].ItemNum);
                    self.ES_RewardList.Refresh(itemList, 0.6f);
                }
            }
        }
    }
}