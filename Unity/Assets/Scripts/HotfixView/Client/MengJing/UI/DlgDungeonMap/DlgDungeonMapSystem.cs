using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.DungeonMapTimer)]
    public class DungeonMapTimer : ATimer<DlgDungeonMap>
    {
        protected override void Run(DlgDungeonMap self)
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

    [FriendOf(typeof(Scroll_Item_DungeonMapLevelItem))]
    [FriendOf(typeof(DlgDungeonMap))]
    public static class DlgDungeonMapSystem
    {
        public static void RegisterUIEvent(this DlgDungeonMap self)
        {
            // UI中的地图块Id 对应的 ChapterId
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(0, 2);
            dic.Add(1, 1);
            dic.Add(2, 3);
            dic.Add(3, 4);
            dic.Add(4, 5);
            dic.Add(5, 6);
            dic.Add(6, 7);
            dic.Add(7, 8);
            dic.Add(8, 9);

            self.View.E_Map0Button.AddListener(() => { self.Enlarge(self.View.E_Map0Button, dic[0]); });
            self.View.E_Map1Button.AddListener(() => { self.Enlarge(self.View.E_Map1Button, dic[1]); });
            self.View.E_Map2Button.AddListener(() => { self.Enlarge(self.View.E_Map2Button, dic[2]); });
            self.View.E_Map3Button.AddListener(() => { self.Enlarge(self.View.E_Map3Button, dic[3]); });
            self.View.E_Map4Button.AddListener(() => { self.Enlarge(self.View.E_Map4Button, dic[4]); });
            self.View.E_Map5Button.AddListener(() => { self.Enlarge(self.View.E_Map5Button, dic[5]); });
            self.View.E_Map6Button.AddListener(() => { self.Enlarge(self.View.E_Map6Button, dic[6]); });
            self.View.E_Map7Button.AddListener(() => { self.Enlarge(self.View.E_Map7Button, dic[7]); });
            self.View.E_Map8Button.AddListener(() => { self.Enlarge(self.View.E_Map8Button, dic[8]); });

            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map0Button.gameObject, !self.CanOpen(dic[0]));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map1Button.gameObject, !self.CanOpen(dic[1]));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map2Button.gameObject, !self.CanOpen(dic[2]));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map3Button.gameObject, !self.CanOpen(dic[3]));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map4Button.gameObject, !self.CanOpen(dic[4]));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map5Button.gameObject, !self.CanOpen(dic[5]));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map6Button.gameObject, !self.CanOpen(dic[6]));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map7Button.gameObject, !self.CanOpen(dic[7]));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map8Button.gameObject, !self.CanOpen(dic[8]));

            // alphaHitTestMinimumThreshold 属性用于指定 Image 组件在进行 alpha 值命中测试时的透明度阈值。
            // 默认情况下，该属性值为 0，表示所有不透明像素都可以通过 alpha 值命中测试。
            // 如果将该属性设置为大于 0 的值，则只有当图像中的像素透明度大于等于该阈值时，该像素才会被视为不透明像素，并且图像才会通过 alpha 值命中测试。
            self.View.E_Map0Image.alphaHitTestMinimumThreshold = 0.5f;
            self.View.E_Map1Image.alphaHitTestMinimumThreshold = 0.5f;
            self.View.E_Map2Image.alphaHitTestMinimumThreshold = 0.5f;
            self.View.E_Map3Image.alphaHitTestMinimumThreshold = 0.5f;
            self.View.E_Map4Image.alphaHitTestMinimumThreshold = 0.5f;
            self.View.E_Map5Image.alphaHitTestMinimumThreshold = 0.5f;
            self.View.E_Map6Image.alphaHitTestMinimumThreshold = 0.5f;
            self.View.E_Map7Image.alphaHitTestMinimumThreshold = 0.5f;
            self.View.E_Map8Image.alphaHitTestMinimumThreshold = 0.5f;

            self.View.E_NanDu_1_ButtonButton.AddListener(() => { self.OnNanDu_Button(1); });
            self.View.E_NanDu_2_ButtonButton.AddListener(() => { self.OnNanDu_Button(2); });
            self.View.E_NanDu_3_ButtonButton.AddListener(() => { self.OnNanDu_Button(3); });

            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMap); });
            self.View.E_LevelReturnButton.AddListener(self.ReEnlarge);
            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMapButtonClick);
            self.View.E_BossRefreshButton.AddListener(() =>
            {
                self.View.E_BossRefreshButton.gameObject.SetActive(false);
                self.View.E_BossRefreshCloseButton.gameObject.SetActive(true);
                self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.gameObject.SetActive(true);
            });
            self.View.E_BossRefreshCloseButton.AddListener(self.OnBoosRefreshClose);
            self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnDungeonMapLevelItemsRefresh);
        }

        public static void ShowWindow(this DlgDungeonMap self, Entity contextData = null)
        {
            self.View.E_RefreshTimeText.text = string.Empty;
            self.View.EG_LevelPanelRectTransform.gameObject.SetActive(false);
            self.OnBoosRefresh().Coroutine();
        }

        public static void BeforeUnload(this DlgDungeonMap self)
        {
            self.View.E_MapPanelImage.GetComponent<RectTransform>().DOKill();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        private static async ETTask OnBoosRefresh(this DlgDungeonMap self)
        {
            await UserInfoNetHelper.RequestUserInfoInit(self.Root());

            var bossRevivesTime = self.Root().GetComponent<UserInfoComponentC>().UserInfo.MonsterRevives;

            bossRevivesTime.Sort((s1, s2) => long.Parse(s1.Value).CompareTo(long.Parse(s2.Value)));
            self.ShowBoosRefreshTime.Clear();
            self.ShowBoosRefreshTime.AddRange(bossRevivesTime);

            self.AddUIScrollItems(ref self.ScrollItemDungeonMapLevelItems, self.ShowBoosRefreshTime.Count);
            self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBoosRefreshTime.Count);

            if (self.Timer != 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }

            if (self.ShowBoosRefreshTime.Count > 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.DungeonMapTimer, self);
            }
        }

        public static void UpdateBossRefreshTimer(this DlgDungeonMap self)
        {
            long time = long.Parse(self.ShowBoosRefreshTime[0].Value);
            if (time > TimeHelper.ServerNow())
            {
                time -= TimeHelper.ServerNow();
                time /= 1000;
                int hour = (int)time / 3600;
                int min = (int)((time - (hour * 3600)) / 60);
                int sec = (int)(time - (hour * 3600) - (min * 60));
                using (zstring.Block())
                {
                    self.View.E_RefreshTimeText.text = zstring.Format("最近领主刷新：{0}时{1}分", hour, min);
                }
            }
            else
            {
                self.View.E_RefreshTimeText.text = "最近领主刷新：已刷新";
            }

            if (self.ScrollItemDungeonMapLevelItems != null)
            {
                foreach (Scroll_Item_DungeonMapLevelItem item in self.ScrollItemDungeonMapLevelItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.RefreshTime();
                }
            }
        }

        private static void OnDungeonMapLevelItemsRefresh(this DlgDungeonMap self, Transform transform, int index)
        {
            Scroll_Item_DungeonMapLevelItem scrollItemDungeonMapLevelItem = self.ScrollItemDungeonMapLevelItems[index].BindTrans(transform);
            scrollItemDungeonMapLevelItem.Refresh(self.ShowBoosRefreshTime[index].KeyId, long.Parse(self.ShowBoosRefreshTime[index].Value));
        }

        private static void OnBoosRefreshClose(this DlgDungeonMap self)
        {
            self.View.E_BossRefreshButton.gameObject.SetActive(true);
            self.View.E_BossRefreshCloseButton.gameObject.SetActive(false);
            self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.gameObject.SetActive(false);
        }

        private static bool CanOpen(this DlgDungeonMap self, int chapterId)
        {
            if (!DungeonSectionConfigCategory.Instance.Contain(chapterId))
            {
                return false;
            }

            int selfLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;

            int level = 100;
            int[] chapters = DungeonSectionConfigCategory.Instance.Get(chapterId).RandomArea;
            for (int i = 0; i < chapters.Length; i++)
            {
                DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(chapters[i]);
                if (dungeonConfig.EnterLv < level)
                {
                    level = dungeonConfig.EnterLv;
                }
            }

            return selfLv >= level;
        }

        private static void EnableBtns(this DlgDungeonMap self, bool enable)
        {
            self.View.E_Map0Button.enabled = enable;
            self.View.E_Map1Button.enabled = enable;
            self.View.E_Map2Button.enabled = enable;
            self.View.E_Map3Button.enabled = enable;
            self.View.E_Map4Button.enabled = enable;
            self.View.E_Map5Button.enabled = enable;
            self.View.E_Map6Button.enabled = enable;
            self.View.E_Map7Button.enabled = enable;
            self.View.E_Map8Button.enabled = enable;
        }

        private static void Enlarge(this DlgDungeonMap self, Button clickedButton, int chapterId)
        {
            if (!self.CanOpen(chapterId))
            {
                FlyTipComponent.Instance.ShowFlyTip("未开启");
                return;
            }

            self.ChapterId = chapterId;

            self.EnableBtns(false);

            self.CurrentMap = clickedButton.gameObject;
            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            RectTransform buttonRectTransform = clickedButton.GetComponent<RectTransform>();

            Vector3 targetScale = Vector3.one * self.ScaleFactor;
            rectTransform.DOScale(targetScale, self.Duration).SetEase(Ease.Linear);

            Vector3 buttonLocalPosition = rectTransform.InverseTransformPoint(buttonRectTransform.position);
            Vector3 targetPosition = rectTransform.localPosition - buttonLocalPosition;
            rectTransform.DOLocalMove(targetPosition, self.Duration).SetEase(Ease.Linear).onComplete = () =>
            {
                UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                DungeonSectionConfig dungeonSectionConfig = DungeonSectionConfigCategory.Instance.Get(chapterId);
                List<KeyValuePair> bossRevivesTime = self.Root().GetComponent<UserInfoComponentC>().UserInfo.MonsterRevives;
                self.CurrentMap.transform.Find("Title").gameObject.SetActive(false);

                Transform[] levels = new Transform[dungeonSectionConfig.RandomArea.Length];
                for (int i = 0; i < levels.Length; i++)
                {
                    levels[i] = self.CurrentMap.transform.Find("Levels/Level_" + i);
                }

                for (int i = 0; i < dungeonSectionConfig.RandomArea.Length; i++)
                {
                    DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(dungeonSectionConfig.RandomArea[i]);

                    List<int> bossIds = SceneConfigHelper.GetLocalDungeonMonsters(dungeonConfig.Id);
                    for (int j = bossIds.Count - 1; j >= 0; j--)
                    {
                        MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossIds[j]);
                        if (monsterConfig.MonsterType != MonsterTypeEnum.Boss)
                        {
                            bossIds.RemoveAt(j);
                        }
                    }

                    Transform level = levels[i].transform;
                    level.Find("Text").GetComponent<Text>().text = dungeonConfig.ChapterName;

                    if (userInfo.Lv < dungeonConfig.EnterLv)
                    {
                        // 等级不足 灰色 不可选择
                        level.GetComponent<Image>().color = self.View.E_Type0Image.color;
                        for (int j = 0; j < level.childCount; j++)
                        {
                            Image image = level.GetChild(j).GetComponent<Image>();
                            if (image != null)
                            {
                                image.color = self.View.E_Type0Image.color;
                            }
                        }

                        levels[i].GetComponent<Button>().AddListener(() => { FlyTipComponent.Instance.ShowFlyTip("等级不足"); });
                    }
                    else
                    {
                        int i1 = i;
                        levels[i].GetComponent<Button>().AddListener(() =>
                        {
                            // 选择关卡
                            self.OnSelect(dungeonConfig.Id, levels[i1]);
                        });

                        bool bossRevive = false;
                        long nowTime = TimeHelper.ServerNow();
                        foreach (int bossId in bossIds)
                        {
                            foreach (KeyValuePair pair in bossRevivesTime)
                            {
                                if (pair.KeyId == bossId || long.Parse(pair.Value) > nowTime)
                                {
                                    bossRevive = true;
                                    break;
                                }
                            }
                        }

                        if (bossRevive)
                        {
                            // boss刷新 绿色 可以选择
                            level.GetComponent<Image>().color = self.View.E_Type2Image.color;
                            for (int j = 0; j < level.childCount; j++)
                            {
                                Image image = level.GetChild(j).GetComponent<Image>();
                                if (image != null)
                                {
                                    image.color = Color.white;
                                }
                            }
                        }
                        else
                        {
                            bool compele = true;
                            foreach (int bossId in bossIds)
                            {
                                bool contain = false;
                                foreach (KeyValuePair pair in bossRevivesTime)
                                {
                                    if (pair.KeyId == bossId)
                                    {
                                        contain = true;
                                        break;
                                    }
                                }

                                if (!contain)
                                {
                                    compele = false;
                                    break;
                                }
                            }

                            if (compele)
                            {
                                // 已通关 黄色 可以选择
                                level.GetComponent<Image>().color = self.View.E_Type1Image.color;
                                for (int j = 0; j < level.childCount; j++)
                                {
                                    Image image = level.GetChild(j).GetComponent<Image>();
                                    if (image != null)
                                    {
                                        image.color = Color.white;
                                    }
                                }
                            }
                            else
                            {
                                // 未通关 灰色 可以选择
                                level.GetComponent<Image>().color = self.View.E_Type0Image.color;
                                for (int j = 0; j < level.childCount; j++)
                                {
                                    Image image = level.GetChild(j).GetComponent<Image>();
                                    if (image != null)
                                    {
                                        image.color = self.View.E_Type0Image.color;
                                    }
                                }
                            }
                        }
                    }
                }

                // 默认选第一个
                self.OnSelect(dungeonSectionConfig.RandomArea[0], levels[0]);

                self.CurrentMap.transform.Find("Levels").gameObject.SetActive(true);

                UserInfo userinfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                using (zstring.Block())
                {
                    self.OnNanDu_Button(PlayerPrefsHelp.GetChapterDifficulty(zstring.Format("{0}{1}", userinfo.UserId, self.ChapterId)));
                }

                self.View.EG_LevelPanelRectTransform.gameObject.SetActive(true);
                self.View.E_CloseButton.gameObject.SetActive(false);
                self.View.E_BossRefreshButton.gameObject.SetActive(true);
                self.View.E_BossRefreshCloseButton.gameObject.SetActive(false);
                self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.gameObject.SetActive(false);
            };
        }

        private static void OnSelect(this DlgDungeonMap self, int dungeonConfigId, Transform transform)
        {
            self.LevelId = dungeonConfigId;
            self.ShowSelect(transform);

            DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(dungeonConfigId);
            self.View.E_LevelNameText.text = dungeonConfig.ChapterName;
            self.View.E_LevelDesText.text = dungeonConfig.ChapterDes;
            using (zstring.Block())
            {
                self.View.E_EnterLevelText.text = zstring.Format("进入等级：{0}", dungeonConfig.EnterLv);
            }
        }

        private static void ShowSelect(this DlgDungeonMap self, Transform transform)
        {
            self.View.E_SelectImage.gameObject.SetActive(true);
            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            Vector3 position = rectTransform.InverseTransformPoint(transform.position);
            position.y += 40;
            self.View.E_SelectImage.GetComponent<RectTransform>().localPosition = position;
        }

        public static void ReEnlarge(this DlgDungeonMap self)
        {
            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            rectTransform.DOScale(Vector3.one, self.Duration).SetEase(Ease.Linear);

            self.View.E_SelectImage.gameObject.SetActive(false);
            self.View.EG_LevelPanelRectTransform.gameObject.SetActive(false);
            self.View.E_CloseButton.gameObject.SetActive(true);

            rectTransform.DOLocalMove(Vector3.zero, self.Duration).SetEase(Ease.Linear).onComplete = () =>
            {
                self.EnableBtns(true);

                self.CurrentMap.transform.Find("Title").gameObject.SetActive(true);
                self.CurrentMap.transform.Find("Levels").gameObject.SetActive(false);
            };
        }

        private static void OnNanDu_Button(this DlgDungeonMap self, int diff)
        {
            int openLv = DungeonSectionConfigCategory.Instance.Get(self.ChapterId).OpenLevel[diff - 1];
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (userInfo.Lv < openLv)
            {
                self.Difficulty = 1;
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0}级开启", openLv));
                }

                return;
            }

            self.Difficulty = diff;
            self.View.E_NanDu_1_SelectImage.gameObject.SetActive(diff == 1);
            self.View.E_NanDu_2_SelectImage.gameObject.SetActive(diff == 2);
            self.View.E_NanDu_3_SelectImage.gameObject.SetActive(diff == 3);

            UserInfo userinfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            using (zstring.Block())
            {
                PlayerPrefsHelp.SetChapterDifficulty(zstring.Format("{0}{1}", userinfo.UserId, self.ChapterId), diff);
            }
        }

        public static async ETTask OnEnterMapButtonClick(this DlgDungeonMap self)
        {
            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("请求传送 副本Id:{0} 副本难度：{1}", self.LevelId, self.Difficulty));
            }

            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.LocalDungeon, self.LevelId, self.Difficulty);

            if (errorCode != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), errorCode);
                return;
            }

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.CloseWindow(WindowID.WindowID_DungeonMap);
        }
    }
}