using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_BattleRecruitItem))]
    [FriendOf(typeof(DlgBattleRecruit))]
    public static class DlgBattleRecruitSystem
    {
        public static void RegisterUIEvent(this DlgBattleRecruit self)
        {
            self.View.E_Img_buttonButton.AddListener(self.OnClose);
            self.View.E_BattleRecruitItemsLoopHorizontalScrollRect.AddItemRefreshListener(self.OnBattleRecruitItemsRefresh);
            self.InitUI().Coroutine();
        }

        public static void ShowWindow(this DlgBattleRecruit self, Entity contextData = null)
        {
        }

        private static void OnClose(this DlgBattleRecruit self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_BattleRecruit);
        }

        private static void OnBattleRecruitItemsRefresh(this DlgBattleRecruit self, Transform transform, int index)
        {
            foreach (Scroll_Item_BattleRecruitItem item in self.ScrollItemBattleRecruitItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_BattleRecruitItem scrollItemBattleRecruitItem = self.ScrollItemBattleRecruitItems[index].BindTrans(transform);
            scrollItemBattleRecruitItem.OnRecruitAction = (i1, i2) => { self.OnRecruit(i1, i2).Coroutine(); };
            scrollItemBattleRecruitItem.InitUI(self.ShowBattleSummonInfos[index]);
        }

        public static async ETTask InitUI(this DlgBattleRecruit self)
        {
            // 向服务端获取目前的招募数据
            long instanceId = self.InstanceId;

            M2C_BattleSummonRecord response = await ActivityNetHelper.BattleSummonRecord(self.Root());
            if (response.BattleSummonList == null)
            {
                return;
            }

            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.BattleSummonInfos = response.BattleSummonList;
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            int sceneId = mapComponent.SceneId;

            // 读取配置表，生成招募列表
            self.ShowBattleSummonInfos.Clear();
            List<BattleSummonConfig> battleSummonInfos = BattleSummonConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < battleSummonInfos.Count; i++)
            {
                if (sceneId != battleSummonInfos[i].SceneId)
                {
                    continue;
                }

                self.ShowBattleSummonInfos.Add(battleSummonInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemBattleRecruitItems, self.ShowBattleSummonInfos.Count);
            self.View.E_BattleRecruitItemsLoopHorizontalScrollRect.SetVisible(true, self.ShowBattleSummonInfos.Count);

            // 根据招募数据更新一下列表
            for (int i = 0; i < response.BattleSummonList.Count; i++)
            {
                foreach (Scroll_Item_BattleRecruitItem item in self.ScrollItemBattleRecruitItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    if (item.BattleSummonConfig.Id == response.BattleSummonList[i].SummonId)
                    {
                        item.UpdateDate(response.BattleSummonList[i].SummonTime);
                    }
                }
            }

            using (zstring.Block())
            {
                self.View.E_CurrentNumberTextText.text = zstring.Format("当前召唤人口:{0}/{1}", BattleHelper.GetSummonNumber(response.BattleSummonList),
                    GlobalValueConfigCategory.Instance.BattlefieldSummonLimit);
            }

            // 开启定时刷新
            self.UpdateUI().Coroutine();

            await ETTask.CompletedTask;
        }

        /// <summary>
        /// 刷新UI
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask UpdateUI(this DlgBattleRecruit self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                long nowTime = TimeHelper.ClientNow();
                foreach (Scroll_Item_BattleRecruitItem item in self.ScrollItemBattleRecruitItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.UpdateUI(nowTime);
                }

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }

            await ETTask.CompletedTask;
        }

        /// <summary>
        /// 发送招募请求
        /// </summary>
        /// <param name="self"></param>
        /// <param name="battleSummonConfigId"></param>
        /// <param name="costgold"></param>
        public static async ETTask OnRecruit(this DlgBattleRecruit self, int battleSummonConfigId, int costgold)
        {
            // 判断人口是否足够
            int cursummonnumber = BattleHelper.GetSummonNumber(self.BattleSummonInfos);
            BattleSummonConfig battleSummonConfig = BattleSummonConfigCategory.Instance.Get(battleSummonConfigId);
            if (cursummonnumber + battleSummonConfig.MonsterNumber > GlobalValueConfigCategory.Instance.BattlefieldSummonLimit)
            {
                FlyTipComponent.Instance.ShowFlyTip("人口不足！");
                return;
            }

            // 判断道具是否足够
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Gold < costgold)
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足！");
                return;
            }

            M2C_BattleSummonResponse response = await ActivityNetHelper.BattleSummonRequest(self.Root(), battleSummonConfigId);

            if (response.Error == ErrorCode.ERR_Success)
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("召唤{0}成功!", battleSummonConfig.ItemName));
                }
            }

            using (zstring.Block())
            {
                self.View.E_CurrentNumberTextText.text = zstring.Format("当前召唤人口:{0}/{1}", BattleHelper.GetSummonNumber(response.BattleSummonList),
                    GlobalValueConfigCategory.Instance.BattlefieldSummonLimit);
            }

            for (int i = 0; i < response.BattleSummonList.Count; i++)
            {
                foreach (Scroll_Item_BattleRecruitItem item in self.ScrollItemBattleRecruitItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    if (item.BattleSummonConfig.Id == response.BattleSummonList[i].SummonId)
                    {
                        item.UpdateDate(response.BattleSummonList[i].SummonTime);
                    }
                }
            }

            await ETTask.CompletedTask;
        }
    }
}