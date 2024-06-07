using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_TrialDungeonItem))]
    [EntitySystemOf(typeof (ES_TrialDungeon))]
    [FriendOfAttribute(typeof (ES_TrialDungeon))]
    public static partial class ES_TrialDungeonSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TrialDungeon self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_TrialDungeonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnTrialDungeonItemsRefresh);
            self.E_Btn_EnterButton.AddListenerAsync(self.OnBtn_Enter);
            self.E_Btn_ReceiveButton.AddListenerAsync(self.OnBtn_Receive);
            self.E_Btn_AddButton.AddListener(self.OnBtn_Add);
            self.E_Btn_SubButton.AddListener(self.OnBtn_Sub);

            self.OnUpdateUI(self.GetShowCengNum());
        }

        [EntitySystem]
        private static void Destroy(this ES_TrialDungeon self)
        {
            self.DestroyWidget();
        }

        private static void OnTrialDungeonItemsRefresh(this ES_TrialDungeon self, Transform transform, int index)
        {
            Scroll_Item_TrialDungeonItem scrollItemTrialDungeonItem = self.ScrollItemTrialDungeonItems[index].BindTrans(transform);
            scrollItemTrialDungeonItem.OnInitUI(self.ShowTowerConfigs[index], self.OnSelectDungeonItem);
        }

        public static int GetShowCengNum(this ES_TrialDungeon self)
        {
            int towerId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            int nextId = TowerHelper.GetNextTowerIdByScene(SceneTypeEnum.TrialDungeon, towerId);
            //nextId == 0通关了

            //第一个可以领取奖励的
            List<TowerConfig> idlist = TowerHelper.GetTowerListByScene(SceneTypeEnum.TrialDungeon);
            for (int i = 0; i < idlist.Count; i++)
            {
                if (self.IsHaveReward(idlist[i].Id))
                {
                    nextId = idlist[i].Id;
                    break;
                }
            }

            return TowerConfigCategory.Instance.Get(nextId == 0? towerId : nextId).CengNum;
        }

        public static int GetMaxCengNum(this ES_TrialDungeon self)
        {
            int maxCeng = 0;
            List<TowerConfig> towerConfigs = TowerConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < towerConfigs.Count; i++)
            {
                TowerConfig towerConfig = towerConfigs[i];
                if (towerConfig.MapType != SceneTypeEnum.TrialDungeon)
                {
                    continue;
                }

                if (maxCeng < towerConfig.CengNum)
                {
                    maxCeng = towerConfig.CengNum;
                }
            }

            return maxCeng;
        }

        public static void OnBtn_Add(this ES_TrialDungeon self)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(self.TowerId);
            if (towerConfig.CengNum >= self.GetMaxCengNum())
            {
                return;
            }

            self.OnUpdateUI(towerConfig.CengNum + 1);
        }

        public static void OnBtn_Sub(this ES_TrialDungeon self)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(self.TowerId);
            if (towerConfig.CengNum == 1)
            {
                return;
            }

            self.OnUpdateUI(towerConfig.CengNum - 1);
        }

        public static void OnUpdateUI(this ES_TrialDungeon self, int cengNum)
        {
            List<TowerConfig> towerConfigs = TowerConfigCategory.Instance.GetAll().Values.ToList();
            int towerId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            int nextId = TowerHelper.GetNextTowerIdByScene(SceneTypeEnum.TrialDungeon, towerId);

            int showNum = 0;
            int showIndex = 0;
            bool haveReward = false;
            self.ShowTowerConfigs.Clear();
            for (int i = 0; i < towerConfigs.Count; i++)
            {
                TowerConfig towerConfig = towerConfigs[i];
                if (towerConfig.MapType != SceneTypeEnum.TrialDungeon)
                {
                    continue;
                }

                if (cengNum != towerConfig.CengNum)
                {
                    continue;
                }

                if (self.IsHaveReward(towerConfig.Id))
                {
                    haveReward = true;
                    showIndex = showNum;
                }

                if (!haveReward && towerConfig.Id == nextId)
                {
                    haveReward = true;
                    showIndex = showNum;
                }

                self.ShowTowerConfigs.Add(towerConfig);

                showNum++;
            }

            self.AddUIScrollItems(ref self.ScrollItemTrialDungeonItems, self.ShowTowerConfigs.Count);
            self.E_TrialDungeonItemsLoopVerticalScrollRect.SetVisible(true, self.ShowTowerConfigs.Count);

            showIndex = showIndex == -1? 0 : showIndex;
            self.E_TextLayerText.text = $"第{cengNum}层";
            int moveIndex = Mathf.Max(showIndex, showNum - 5);
            self.ScrollItemTrialDungeonItems[showIndex].OnBtn_XuanZhong();
            self.MoveToIndex(showIndex);
        }

        public static void MoveToIndex(this ES_TrialDungeon self, int showIndex)
        {
            self.E_TrialDungeonItemsLoopVerticalScrollRect.transform.Find("Content").GetComponent<RectTransform>().localPosition =
                    new Vector2(0, showIndex * 180);
        }

        public static void OnSelectDungeonItem(this ES_TrialDungeon self, int towerId)
        {
            self.TowerId = towerId;
            if (self.ScrollItemTrialDungeonItems != null)
            {
                foreach (Scroll_Item_TrialDungeonItem item in self.ScrollItemTrialDungeonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.OnSelected(towerId);
                }
            }

            self.UpdateButtons();
            self.ShowRewardList();
        }

        public static bool IsHaveReward(this ES_TrialDungeon self, int towerId)
        {
            int curId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            return towerId <= curId && !userInfo.TowerRewardIds.Contains(towerId);
        }

        public static void UpdateButtons(this ES_TrialDungeon self)
        {
            int curId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.E_Btn_EnterButton.gameObject.SetActive(self.TowerId > curId);
            self.E_Btn_ReceiveButton.gameObject.SetActive(self.TowerId <= curId && !userInfo.TowerRewardIds.Contains(self.TowerId));

            if (!self.E_Btn_ReceiveButton.gameObject.activeSelf)
            {
                self.E_Btn_EnterButton.gameObject.SetActive(true);
            }
        }

        public static void ShowRewardList(this ES_TrialDungeon self)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(self.TowerId);
            self.ES_RewardList.Refresh(towerConfig.DropShow);
        }

        public static async ETTask OnBtn_Receive(this ES_TrialDungeon self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell() < 2)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请清理一下背包！");
                return;
            }

            //试炼之地
            await MapHelper.RequestTowerReward(self.Root(), self.TowerId, SceneTypeEnum.TrialDungeon);
            self.UpdateButtons();
        }

        public static async ETTask OnBtn_Enter(this ES_TrialDungeon self)
        {
            if (self.TowerId == 0)
            {
                return;
            }

            int towerId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            int nextId = TowerHelper.GetNextTowerIdByScene(SceneTypeEnum.TrialDungeon, towerId);

            if (self.TowerId > nextId && nextId != 0)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请激活前置关卡！");
                return;
            }

            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.TrialDungeon,
                BattleHelper.GetSceneIdByType(SceneTypeEnum.TrialDungeon), 0, self.TowerId.ToString());
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Trial);
            }
        }
    }
}