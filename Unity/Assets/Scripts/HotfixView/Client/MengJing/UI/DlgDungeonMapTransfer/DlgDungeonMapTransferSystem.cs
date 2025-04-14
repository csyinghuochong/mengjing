using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.MapTransferBossRefreshTimer)]
    public class MapTransferBossRefreshTimer : ATimer<DlgDungeonMapTransfer>
    {
        protected override void Run(DlgDungeonMapTransfer self)
        {
            try
            {
                self.UpdateBossRefreshTimer();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [FriendOf(typeof(Scroll_Item_BossRefreshSettingItem))]
    [FriendOf(typeof(Scroll_Item_BossRefreshTimeItem))]
    [FriendOf(typeof(Scroll_Item_DungeonLevelItem))]
    [FriendOf(typeof(DlgDungeonMapTransfer))]
    public static class DlgDungeonMapTransferSystem
    {
        public static void RegisterUIEvent(this DlgDungeonMapTransfer self)
        {
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);
            self.View.E_BossRefreshSettingBtnButton.AddListener(self.OnBossRefreshSettingBtnButton);
            self.View.E_CloseBossRefreshSettingBtnButton.AddListener(self.OnCloseBossRefreshSettingBtnButton);

            self.View.E_DungeonLevelItemLoopVerticalScrollRect.AddItemRefreshListener(self.OnDungeonLevelItemsRefresh);
            self.View.E_BossRefreshTimeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBossRefreshTimeItemsRefresh);
            self.View.E_BossRefreshSettingItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBossRefreshSettingItemsRefresh);
            
            self.View.EG_BossRefreshSettingPanelRectTransform.gameObject.SetActive(false);
            self.UpdateChapterList();
            self.UpdateBossRefreshTimeList().Coroutine();
        }

        public static void ShowWindow(this DlgDungeonMapTransfer self, Entity contextData = null)
        {
        }

        private static void OnDungeonLevelItemsRefresh(this DlgDungeonMapTransfer self, Transform transform, int index)
        {
            foreach (Scroll_Item_DungeonLevelItem item in self.ScrollItemDungeonLevelItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_DungeonLevelItem scrollItemDungeonLevelItem = self.ScrollItemDungeonLevelItems[index].BindTrans(transform);
            scrollItemDungeonLevelItem.OnInitData(1, self.ShowLevel[index], self.DungeonSectionConfig.RandomArea[self.ShowLevel[index]]);
        }

        private static void OnBossRefreshTimeItemsRefresh(this DlgDungeonMapTransfer self, Transform transform, int index)
        {
            foreach (Scroll_Item_BossRefreshTimeItem item in self.ScrollItemBossRefreshTimeItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_BossRefreshTimeItem scrollItemBossRefreshTimeItem = self.ScrollItemBossRefreshTimeItems[index].BindTrans(transform);
            scrollItemBossRefreshTimeItem.Refresh(self.ShowBoosRefreshTime[index].KeyId, long.Parse(self.ShowBoosRefreshTime[index].Value));
        }

        private static void OnBossRefreshSettingItemsRefresh(this DlgDungeonMapTransfer self, Transform transform, int index)
        {
            foreach (Scroll_Item_BossRefreshSettingItem item in self.ScrollItemBossRefreshSettingItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_BossRefreshSettingItem scrollItemBossRefreshSettingItem = self.ScrollItemBossRefreshSettingItems[index].BindTrans(transform);
            scrollItemBossRefreshSettingItem.Refresh(self.ShowBossSetting[index]);
            scrollItemBossRefreshSettingItem.E_ToggleBtnButton.AddListener(() =>
            {
                self.OnSettingChanged(self.ShowBossSetting[index].ToString(), scrollItemBossRefreshSettingItem.E_ShowTextImage.gameObject);
            });
        }

        public static void UpdateChapterList(this DlgDungeonMapTransfer self)
        {
            int sceneId = self.Root().GetComponent<MapComponent>().SceneId;
            DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(sceneId);
            self.ChapterId = dungeonConfig.ChapterId;

            DungeonSectionConfig dungeonSectionConfig = DungeonSectionConfigCategory.Instance.Get(self.ChapterId);
            self.DungeonSectionConfig = dungeonSectionConfig;
            self.View.E_ChapterTextText.text = dungeonSectionConfig.ChapterName;
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;

            self.ShowLevel.Clear();

            for (int i = 0; i < dungeonSectionConfig.RandomArea.Length; i++)
            {
                DungeonConfig chapterCof = DungeonConfigCategory.Instance.Get(dungeonSectionConfig.RandomArea[i]);
                if (userInfo.Lv < chapterCof.EnterLv)
                {
                    break;
                }

                if (chapterCof.Id >= ConfigData.GMDungeonId)
                {
                    break;
                }

                self.ShowLevel.Add(i);
            }

            self.AddUIScrollItems(ref self.ScrollItemDungeonLevelItems, self.ShowLevel.Count);
            self.View.E_DungeonLevelItemLoopVerticalScrollRect.SetVisible(true, self.ShowLevel.Count);
        }

        public static async ETTask UpdateBossRefreshTimeList(this DlgDungeonMapTransfer self)
        {
            long instance = self.InstanceId;
            await UserInfoNetHelper.RequestUserInfoInit(self.Root());
            if (instance != self.InstanceId)
            {
                return;
            }

            var bossRevivesTime = self.Root().GetComponent<UserInfoComponentC>().UserInfo.MonsterRevives;

            bossRevivesTime.Sort((s1, s2) => long.Parse(s1.Value).CompareTo(long.Parse(s2.Value)));

            self.ShowBoosRefreshTime.Clear();

            for (int i = 0; i < bossRevivesTime.Count; i++)
            {
                var bossConfId = bossRevivesTime[i].KeyId;

                if (PlayerPrefs.HasKey(bossConfId.ToString()))
                {
                    if (PlayerPrefs.GetString(bossConfId.ToString()) == "0")
                    {
                        continue;
                    }
                }
                else
                {
                    PlayerPrefs.SetString(bossConfId.ToString(), "1");
                }

                self.ShowBoosRefreshTime.Add(bossRevivesTime[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemBossRefreshTimeItems, self.ShowBoosRefreshTime.Count);
            self.View.E_BossRefreshTimeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBoosRefreshTime.Count);

            if (self.Timer != 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.MapTransferBossRefreshTimer, self);
        }

        public static void UpdateBossRefreshTimer(this DlgDungeonMapTransfer self)
        {
            foreach (KeyValuePair<int, long> it in self.BossRefreshTime)
            {
                long time = it.Value;
                if (time > TimeHelper.ServerNow())
                {
                    time -= TimeHelper.ClientNow();
                    time /= 1000;
                    int hour = (int)time / 3600;
                    int min = (int)((time - (hour * 3600)) / 60);
                    int sec = (int)(time - (hour * 3600) - (min * 60));
                    using (zstring.Block())
                    {
                        string showStr = zstring.Format("{0}时{1}分{2}秒", hour, min, sec);
                        self.BossRefreshObjs[it.Key].text = zstring.Format("刷新时间:{0}", showStr);
                    }
                }
                else
                {
                    self.BossRefreshObjs[it.Key].text = "已刷新";
                }
            }
        }

        public static void OnButtonCloseButton(this DlgDungeonMapTransfer self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMapTransfer);
        }

        public static void OnBossRefreshSettingBtnButton(this DlgDungeonMapTransfer self)
        {
            self.View.EG_BossRefreshSettingPanelRectTransform.gameObject.SetActive(true);

            self.ShowBossSetting.Clear();
            foreach (int bossConfigId in ConfigData.BossShowTimeList)
            {
                self.ShowBossSetting.Add(bossConfigId);
            }

            self.AddUIScrollItems(ref self.ScrollItemBossRefreshSettingItems, self.ShowBossSetting.Count);
            self.View.E_BossRefreshSettingItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBossSetting.Count);
        }

        public static void OnSettingChanged(this DlgDungeonMapTransfer self, string key, GameObject obj)
        {
            if (PlayerPrefs.GetString(key) == "0")
            {
                PlayerPrefs.SetString(key, "1");
                obj.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetString(key, "0");
                obj.SetActive(false);
            }
        }

        public static void OnCloseBossRefreshSettingBtnButton(this DlgDungeonMapTransfer self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            self.UpdateBossRefreshTimeList().Coroutine();
            self.View.EG_BossRefreshSettingPanelRectTransform.gameObject.SetActive(false);
        }
    }
}
