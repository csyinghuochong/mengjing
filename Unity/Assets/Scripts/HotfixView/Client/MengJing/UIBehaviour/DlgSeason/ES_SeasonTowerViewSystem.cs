using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SeasonTowerRankItem))]
    [EntitySystemOf(typeof(ES_SeasonTower))]
    [FriendOfAttribute(typeof(ES_SeasonTower))]
    public static partial class ES_SeasonTowerSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SeasonTower self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SeasonTowerRankItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSeasonTowerRankItemsRefresh);
            self.E_RewardShowBtnButton.AddListenerAsync(self.OnRewardShowBtnButton);
            self.E_EnterBtnButton.AddListener(self.OnEnterBtnButton);

            self.UpdateInfo().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_SeasonTower self)
        {
            self.DestroyWidget();
        }

        private static void OnSeasonTowerRankItemsRefresh(this ES_SeasonTower self, Transform transform, int index)
        {
            foreach (Scroll_Item_SeasonTowerRankItem item in self.ScrollItemSeasonTowerRankItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_SeasonTowerRankItem scrollItemSeasonTowerRankItem = self.ScrollItemSeasonTowerRankItems[index].BindTrans(transform);
            scrollItemSeasonTowerRankItem.UpdateInfo(index + 1, self.ShowRankSeasonTowerInfos[index]);
        }

        public static async ETTask OnRewardShowBtnButton(this ES_SeasonTower self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SeasonTowerReward);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSeasonTowerReward>().OnInitUI(7);
        }

        public static void OnEnterBtnButton(this ES_SeasonTower self)
        {
            int sceneId = BattleHelper.GetSceneIdByType(MapTypeEnum.SeasonTower);
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.SeasonTower, sceneId, 0, "0").Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Season);
        }

        public static async ETTask UpdateInfo(this ES_SeasonTower self)
        {
            long instanceid = self.InstanceId;
            C2R_RankSeasonTowerRequest request = new();
            R2C_RankSeasonTowerResponse response = (R2C_RankSeasonTowerResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            int cengshu = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.SeasonTowerId) %
                    250000;

            using (zstring.Block())
            {
                self.E_LayerTextText.text = zstring.Format("{0}/10", cengshu);
                self.E_Text_CengText.text = zstring.Format("{0}层", cengshu);
            }

            long selfId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            self.ShowRankSeasonTowerInfos = response.RankList;

            for (int i = 0; i < self.ShowRankSeasonTowerInfos.Count; i++)
            {
                if (instanceid != self.InstanceId)
                {
                    return;
                }

                if (self.ShowRankSeasonTowerInfos[i].UserId == selfId)
                {
                    //NumericType.SeasonTowerId 当前通关的塔ID
                    using (zstring.Block())
                    {
                        self.E_TimeTextText.text =
                                zstring.Format("{0}小时{1}分{2}秒",
                                    self.ShowRankSeasonTowerInfos[i].TotalTime / 3600000,
                                    self.ShowRankSeasonTowerInfos[i].TotalTime % 3600000 / 60000,
                                    self.ShowRankSeasonTowerInfos[i].TotalTime % 3600000 % 60000 / 1000);
                    }
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemSeasonTowerRankItems, self.ShowRankSeasonTowerInfos.Count);
            self.E_SeasonTowerRankItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankSeasonTowerInfos.Count);
        }
    }
}
