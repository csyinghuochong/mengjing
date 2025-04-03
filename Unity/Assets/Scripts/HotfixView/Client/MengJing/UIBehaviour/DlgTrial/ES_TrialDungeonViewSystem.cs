using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TrialDungeonItem))]
    [EntitySystemOf(typeof(ES_TrialDungeon))]
    [FriendOfAttribute(typeof(ES_TrialDungeon))]
    public static partial class ES_TrialDungeonSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TrialDungeon self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_Btn_EnterButton.AddListenerAsync(self.OnBtn_EnterButton);
            self.E_Btn_ReceiveButton.AddListenerAsync(self.OnBtn_ReceiveButton);
            self.E_Btn_AddButton.AddListener(self.OnBtn_AddButton);
            self.E_Btn_SubButton.AddListener(self.OnBtn_SubButton);

            self.OnUpdateUI(self.GetShowCengNum());
        }

        [EntitySystem]
        private static void Destroy(this ES_TrialDungeon self)
        {
            self.DestroyWidget();
        }

        public static int GetShowCengNum(this ES_TrialDungeon self)
        {
            int towerId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            int nextId = TowerHelper.GetNextTowerIdByScene(MapTypeEnum.TrialDungeon, towerId);
            //nextId == 0通关了

            //第一个可以领取奖励的
            List<TowerConfig> idlist = TowerHelper.GetTowerListByScene(MapTypeEnum.TrialDungeon);
            for (int i = 0; i < idlist.Count; i++)
            {
                if (self.IsHaveReward(idlist[i].Id))
                {
                    nextId = idlist[i].Id;
                    break;
                }
            }

            return nextId == 0 ? towerId : nextId;
        }

        public static int GetMaxCengNum(this ES_TrialDungeon self)
        {
            int maxCeng = 0;
            List<TowerConfig> towerConfigs = TowerConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < towerConfigs.Count; i++)
            {
                TowerConfig towerConfig = towerConfigs[i];
                if (towerConfig.MapType != MapTypeEnum.TrialDungeon)
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

        public static void OnBtn_AddButton(this ES_TrialDungeon self)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(self.TowerId);
            if (towerConfig.CengNum >= self.GetMaxCengNum())
            {
                return;
            }

            self.OnUpdateUI(self.TowerId + 1);
        }

        public static void OnBtn_SubButton(this ES_TrialDungeon self)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(self.TowerId);
            if (towerConfig.CengNum == 1)
            {
                return;
            }

            self.OnUpdateUI(self.TowerId - 1);
        }

        public static void OnUpdateUI(this ES_TrialDungeon self, int towerId)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(towerId);

            self.TowerId = towerId;

            int monsterId = int.Parse(towerConfig.MonsterSet.Split(';')[2]);
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
            using (zstring.Block())
            {
                self.E_TextLayerText.text = zstring.Format("第{0}层", towerConfig.CengNum);
                self.E_TextMonsterHPText.text = zstring.Format("怪物生命：{0}", monsterConfig.Hp);
            }

            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 115, 380f));
            using (zstring.Block())
            {
                self.ES_ModelShow.ShowOtherModel(zstring.Format("Monster/{0}", monsterConfig.MonsterModelID)).Coroutine();
            }

            self.UpdateButtons();
            self.ShowRewardList();
        }

        private static bool IsHaveReward(this ES_TrialDungeon self, int towerId)
        {
            int curId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            return towerId <= curId && !userInfo.TowerRewardIds.Contains(towerId);
        }

        private static void UpdateButtons(this ES_TrialDungeon self)
        {
            int curId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.E_Btn_EnterButton.gameObject.SetActive(self.TowerId > curId);
            self.E_Btn_ReceiveButton.gameObject.SetActive(self.TowerId <= curId && !userInfo.TowerRewardIds.Contains(self.TowerId));

            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(self.TowerId);

            self.E_Hint_1Image.gameObject.SetActive(false);
            self.E_Hint_2Image.gameObject.SetActive(false);
            self.E_Hint_3Image.gameObject.SetActive(false);
            // 已经打完
            if (curId >= towerConfig.Id)
            {
                //是否领取
                if (userInfo.TowerRewardIds.Contains(towerConfig.Id))
                {
                    //包含
                    self.E_Hint_2Image.gameObject.SetActive(true);
                }
                else
                {
                    //不包含
                    self.E_Hint_3Image.gameObject.SetActive(true);
                }
            }
            else
            {
                if (curId + 1 == towerConfig.Id)
                {
                    self.E_Hint_1Image.gameObject.SetActive(true);
                }
            }

            if (!self.E_Btn_ReceiveButton.gameObject.activeSelf)
            {
                self.E_Btn_EnterButton.gameObject.SetActive(true);
            }
        }

        private static void ShowRewardList(this ES_TrialDungeon self)
        {
            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(self.TowerId);
            self.ES_RewardList.Refresh(towerConfig.DropShow);
        }

        private static async ETTask OnBtn_ReceiveButton(this ES_TrialDungeon self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 2)
            {
                FlyTipComponent.Instance.ShowFlyTip("请清理一下背包！");
                return;
            }

            //试炼之地
            await MapHelper.RequestTowerReward(self.Root(), self.TowerId, MapTypeEnum.TrialDungeon);
            self.UpdateButtons();
        }

        private static async ETTask OnBtn_EnterButton(this ES_TrialDungeon self)
        {
            if (self.TowerId == 0)
            {
                return;
            }

            int towerId = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.TrialDungeonId);
            int nextId = TowerHelper.GetNextTowerIdByScene(MapTypeEnum.TrialDungeon, towerId);

            if (self.TowerId > nextId && nextId != 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请激活前置关卡！");
                return;
            }

            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.TrialDungeon,
                BattleHelper.GetSceneIdByType(MapTypeEnum.TrialDungeon), 0, self.TowerId.ToString());
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Trial, false);
            }
        }
    }
}