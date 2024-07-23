namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_RunRaceItem))]
    public static partial class Scroll_Item_RunRaceItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RunRaceItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RunRaceItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdate(this Scroll_Item_RunRaceItem self, RankRewardConfig rewardConfig)
        {
            using (zstring.Block())
            {
                if (rewardConfig.NeedPoint[0] == rewardConfig.NeedPoint[1])
                {
                    self.E_TextTipText.text = zstring.Format("第{0}名奖励", rewardConfig.NeedPoint[0]);
                }
                else
                {
                    self.E_TextTipText.text = zstring.Format("第{0}-{1}名奖励", rewardConfig.NeedPoint[0], rewardConfig.NeedPoint[1]);
                }
            }

            self.ES_RewardList.Refresh(rewardConfig.RewardItems, 0.9f);
        }
    }
}