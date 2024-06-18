using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_SeasonTower))]
    [FriendOfAttribute(typeof (ES_SeasonTower))]
    public static partial class ES_SeasonTowerSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SeasonTower self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_SeasonTowerRankItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSeasonTowerRankItemsRefresh);
            self.E_RewardShowBtnButton.AddListenerAsync(self.OnRewardShowBtn);
            self.E_EnterBtnButton.AddListener(self.OnEnterBtn);

            self.UpdateInfo().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_SeasonTower self)
        {
            self.DestroyWidget();
        }

        private static void OnSeasonTowerRankItemsRefresh(this ES_SeasonTower self, Transform transform, int index)
        {
            Scroll_Item_SeasonTowerRankItem scrollItemSeasonTowerRankItem = self.ScrollItemSeasonTowerRankItems[index].BindTrans(transform);
            scrollItemSeasonTowerRankItem.UpdateInfo(index + 1, self.ShowRankSeasonTowerInfos[index]);
        }

        public static async ETTask OnRewardShowBtn(this ES_SeasonTower self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SeasonTowerReward);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSeasonTowerReward>().OnInitUI(7);
        }

        public static void OnEnterBtn(this ES_SeasonTower self)
        {
            int sceneId = BattleHelper.GetSceneIdByType(SceneTypeEnum.SeasonTower);
            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.SeasonTower, sceneId, 0, "0").Coroutine();
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

            self.E_LayerTextText.text = $"{cengshu}/10";
            self.E_Text_CengText.text = $"{cengshu}层";
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
                    self.E_TimeTextText.text =
                            $"{self.ShowRankSeasonTowerInfos[i].TotalTime / 3600000}小时{self.ShowRankSeasonTowerInfos[i].TotalTime % 3600000 / 60000}分{self.ShowRankSeasonTowerInfos[i].TotalTime % 3600000 % 60000 / 1000}秒";
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemSeasonTowerRankItems, self.ShowRankSeasonTowerInfos.Count);
            self.E_SeasonTowerRankItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRankSeasonTowerInfos.Count);
        }
    }
}