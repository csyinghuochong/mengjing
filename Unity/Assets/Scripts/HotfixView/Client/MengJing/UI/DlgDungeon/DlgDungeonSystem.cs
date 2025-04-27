using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UIDungenBossRefreshTimer)]
    public class UIDungenBossRefreshTimer : ATimer<DlgDungeon>
    {
        protected override void Run(DlgDungeon self)
        {
            try
            {
                self.UpdateBossRefreshTimer();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof(Scroll_Item_BossRefreshSettingItem))]
    [FriendOf(typeof(Scroll_Item_DungeonItem))]
    [FriendOf(typeof(Scroll_Item_BossRefreshTimeItem))]
    [FriendOf(typeof(DlgDungeon))]
    public static class DlgDungeonSystem
    {
        public static void RegisterUIEvent(this DlgDungeon self)
        {
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonCloseButton);
            self.View.E_BossRefreshSettingBtnButton.AddListener(self.OnBossRefreshSettingBtnButton);
            self.View.E_CloseBossRefreshSettingBtnButton.AddListener(self.OnCloseBossRefreshSettingBtnButton);

            self.View.E_DungeonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnDungeonItemsRefresh);
            self.View.E_BossRefreshTimeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBossRefreshTimeItemsRefresh);
            self.View.E_BossRefreshSettingItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBossRefreshSettingItemsRefresh);

            self.View.EG_BossRefreshSettingPanelRectTransform.gameObject.SetActive(false);
            self.UpdateChapterList().Coroutine();
            self.UpdateBossRefreshTimeList().Coroutine();
        }

        public static void ShowWindow(this DlgDungeon self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgDungeon self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        private static void OnDungeonItemsRefresh(this DlgDungeon self, Transform transform, int index)
        {
            foreach (Scroll_Item_DungeonItem item in self.ScrollItemDungeonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_DungeonItem scrollItemDungeonItem = self.ScrollItemDungeonItems[index].BindTrans(transform);
            scrollItemDungeonItem.OnInitData(index, self.ShowChapter[index]).Coroutine();
        }

        public static async ETTask UpdateChapterList(this DlgDungeon self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            self.ShowChapter.Clear();
            List<DungeonSectionConfig> dungeonConfigs = DungeonSectionConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < dungeonConfigs.Count; i++)
            {
                int chapterid = dungeonConfigs[i].Id;
                self.ShowChapter.Add(chapterid);
            }

            self.AddUIScrollItems(ref self.ScrollItemDungeonItems, self.ShowChapter.Count);
            self.View.E_DungeonItemsLoopVerticalScrollRect.SetVisible(true, self.ShowChapter.Count);

            if (userInfoComponent.UserInfo.Lv > 50)
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
                self.View.E_DungeonItemsLoopVerticalScrollRect.verticalNormalizedPosition = 0f;
            }

            // await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
            // self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIDungeon");
        }

        private static void OnBossRefreshTimeItemsRefresh(this DlgDungeon self, Transform transform, int index)
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

        private static async ETTask UpdateBossRefreshTimeList(this DlgDungeon self)
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

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UIDungenBossRefreshTimer, self);
        }

        public static void UpdateBossRefreshTimer(this DlgDungeon self)
        {
            for (int i = 0; i < self.ScrollItemBossRefreshTimeItems.Count; i++)
            {
                Scroll_Item_BossRefreshTimeItem scrollItemBossRefreshTimeItem = self.ScrollItemBossRefreshTimeItems[i];
                if (scrollItemBossRefreshTimeItem.uiTransform != null)
                {
                    scrollItemBossRefreshTimeItem.RefreshTime();
                }
            }
        }

        private static void OnButtonCloseButton(this DlgDungeon self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Dungeon);
        }

        private static void OnBossRefreshSettingItemsRefresh(this DlgDungeon self, Transform transform, int index)
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

        public static void OnBossRefreshSettingBtnButton(this DlgDungeon self)
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

        public static void OnSettingChanged(this DlgDungeon self, string key, GameObject obj)
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

        private static void OnCloseBossRefreshSettingBtnButton(this DlgDungeon self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            self.UpdateBossRefreshTimeList().Coroutine();
            self.View.EG_BossRefreshSettingPanelRectTransform.gameObject.SetActive(false);
        }
    }
}