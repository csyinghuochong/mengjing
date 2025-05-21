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
    [FriendOf(typeof(DlgDungeonMapViewComponent))]
    public static class DlgDungeonMapSystem
    {
        public static void RegisterUIEvent(this DlgDungeonMap self)
        {
            // UI中的地图块Id 对应的 ChapterId
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(0, 9);
            dic.Add(1, 1);
            dic.Add(2, 2);
            dic.Add(3, 3);
            dic.Add(4, 4);
            dic.Add(5, 5);
            dic.Add(6, 6);
            dic.Add(7, 7);
            dic.Add(8, 8);

            self.MapGameObjects = new GameObject[dic.Count];
            for (int i = 0; i < self.MapGameObjects.Length; i++)
            {
                GameObject go = self.View.EG_MapPanelRectTransform.Find("Map" + i).gameObject;
                self.MapGameObjects[i] = go;

                int i1 = i;
                go.GetComponent<Button>().AddListener(() => { self.Enlarge(i1, dic[i1]); });
                CommonViewHelper.SetImageGray(self.Root(), go, !self.CanOpen(dic[i]));

                // alphaHitTestMinimumThreshold 属性用于指定 Image 组件在进行 alpha 值命中测试时的透明度阈值。
                // 默认情况下，该属性值为 0，表示所有不透明像素都可以通过 alpha 值命中测试。
                // 如果将该属性设置为大于 0 的值，则只有当图像中的像素透明度大于等于该阈值时，该像素才会被视为不透明像素，并且图像才会通过 alpha 值命中测试。
                go.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;

                self.ResetLevelsInfo( i1, dic[i1] );
            }

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
                self.CurrentMap.gameObject.SetActive(false);
            });
            self.View.E_BossRefreshCloseButton.AddListener(self.OnBoosRefreshClose);
            self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnDungeonMapLevelItemsRefresh);
            // self.View.E_MapPanelDiButton.AddListener(() =>
            // {
            //     UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            //     uiComponent.CloseWindow(WindowID.WindowID_DungeonMap);
            // });
            //
            self.View.E_RefreshTimeText.text = string.Empty;
            self.View.EG_LevelPanelRectTransform.gameObject.SetActive(false);
            self.OnBoosRefresh().Coroutine();
            self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Main);
        }

        public static void ShowWindow(this DlgDungeonMap self, Entity contextData = null)
        {
            self.ShowGuide().Coroutine();
        }

        public static void BeforeUnload(this DlgDungeonMap self)
        {
            self.View.EG_MapPanelRectTransform.DOKill();
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
        }

        public static async ETTask ShowGuide(this DlgDungeonMap self)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIDungeonMap");
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
            foreach (Scroll_Item_DungeonMapLevelItem item in self.ScrollItemDungeonMapLevelItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_DungeonMapLevelItem scrollItemDungeonMapLevelItem = self.ScrollItemDungeonMapLevelItems[index].BindTrans(transform);
            scrollItemDungeonMapLevelItem.Refresh(self.ShowBoosRefreshTime[index].KeyId, long.Parse(self.ShowBoosRefreshTime[index].Value));
        }

        private static void OnBoosRefreshClose(this DlgDungeonMap self)
        {
            self.View.E_BossRefreshButton.gameObject.SetActive(true);
            self.View.E_BossRefreshCloseButton.gameObject.SetActive(false);
            self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.gameObject.SetActive(false);
            self.CurrentMap.gameObject.SetActive(true);
        }

        private static bool CanOpen(this DlgDungeonMap self, int chapterId)
        {
            if (chapterId == 9)
            {
                return true;
            }

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
            foreach (GameObject go in self.MapGameObjects)
            {
                go.GetComponent<Button>().enabled = enable;
            }
        }

        private static void SetTitle(this DlgDungeonMap self, bool enable)
        {
            foreach (GameObject go in self.MapGameObjects)
            {
                go.transform.Find("Title")?.gameObject.SetActive(enable);
            }
        }

        private static void ResetLevelsInfo(this DlgDungeonMap self , int map, int chapterId)
        {
            if (map == 0) //返回天空之城
            {
                return;
            }
            GameObject currentMap = self.MapGameObjects[map];
            Transform transform = currentMap.transform.Find("Levels");
            if (transform == null)
            {
                return;
            }
            GameObject Levels = transform.gameObject;
            Levels.SetActive(false);
            //DungeonSectionConfigCategory.Instance.Get(chapterId);
        }
        
        private static void Enlarge(this DlgDungeonMap self, int map, int chapterId)
        {
            if (map == 0)  //返回天空之城
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", "是否返回主城出生点？", () =>
                {
                    EnterMapHelper.RequestTransfer( self.Root(), MapTypeEnum.MainCityScene, GlobalValueConfigCategory.Instance.MainCityID, 0, "0"  ).Coroutine();
                
                    UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                    uiComponent.CloseWindow(WindowID.WindowID_DungeonMap);

                }, null).Coroutine();
                return;
            }

            if (!self.CanOpen(chapterId))
            {
                FlyTipComponent.Instance.ShowFlyTip("未开启");
                return;
            }


            self.ChapterId = chapterId;
            self.EnableBtns(false);

            self.CurrentMap = self.MapGameObjects[map];
            self.OriginalIndex = self.CurrentMap.transform.GetSiblingIndex();
            RectTransform rectTransform = self.View.EG_MapPanelRectTransform;
            RectTransform buttonRectTransform = self.CurrentMap.GetComponent<RectTransform>();

            DungeonSectionConfig dungeonSectionConfig = DungeonSectionConfigCategory.Instance.Get(chapterId);
            
            float ScaleFactor = (float)dungeonSectionConfig.Size[0] / 0.32f;
            Vector3 targetScale = Vector3.one * ScaleFactor;
            
            rectTransform.DOScale(targetScale, self.Duration).SetEase(Ease.Linear);

            Vector3 buttonLocalPosition = self.View.uiTransform.InverseTransformPoint(buttonRectTransform.position);
            Vector3 targetPosition = rectTransform.localPosition - buttonLocalPosition;
            targetPosition *= ScaleFactor;
            
            targetPosition.x += dungeonSectionConfig.Offset[0];
            targetPosition.y += dungeonSectionConfig.Offset[1];
            
            self.View.E_MapPanelDiButtonButton.gameObject.SetActive(false);
            rectTransform.DOLocalMove(targetPosition, self.Duration).SetEase(Ease.Linear).onComplete = () =>
            {
                UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                
                List<KeyValuePair> bossRevivesTime = self.Root().GetComponent<UserInfoComponentC>().UserInfo.MonsterRevives;
                self.SetTitle(false);
                
                List<Transform> levels = new();
                for (int i = 0; i < dungeonSectionConfig.RandomArea.Length; i++)
                {
                    Transform transform = self.CurrentMap.transform.Find("Levels/Level_" + i);
                    if (transform != null)
                    {
                        levels.Add(transform);
                    }
                    else
                    {
                        Log.Error($"地图图片上没有添加关卡 Levels/Level_{i}");
                        return;
                    }
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
                            self.OnSelect(dungeonConfig.Id, levels[i1], level.Find("SelectPosition"));
                        });

                        bool bossRevive = true;
                        long nowTime = TimeHelper.ServerNow();
                        foreach (int bossId in bossIds)
                        {
                            foreach (KeyValuePair pair in bossRevivesTime)
                            {
                                if (pair.KeyId == bossId && long.Parse(pair.Value) > nowTime)
                                {
                                    bossRevive = false;
                                    break;
                                }
                            }
                        }

                        self.View.E_Type2Image.gameObject.SetActive(bossRevive);
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
                self.OnSelect(dungeonSectionConfig.RandomArea[0], levels[0], levels[0].Find("SelectPosition"));
                self.CurrentMap.transform.SetParent(self.View.E_BlackBGImage.transform);
                self.CurrentMap.transform.Find("Levels").gameObject.SetActive(true);

                UserInfo userinfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                using (zstring.Block())
                {
                    self.OnNanDu_Button(PlayerPrefsHelp.GetChapterDifficulty(zstring.Format("{0}{1}", userinfo.UserId, self.ChapterId)));
                }
                
                self.View.EG_MapPanelRectTransform.gameObject.SetActive(false);
                self.View.EG_LevelPanelRectTransform.gameObject.SetActive(true);
                self.View.E_CloseButton.gameObject.SetActive(false);
                self.View.E_BossRefreshButton.gameObject.SetActive(true);
                self.View.E_BossRefreshCloseButton.gameObject.SetActive(false);
                self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.gameObject.SetActive(false);
                
                self.ShowGuide().Coroutine();
            };
        }

        private static void OnSelect(this DlgDungeonMap self, int dungeonConfigId, Transform transform, Transform parent_1)
        {
            self.LevelId = dungeonConfigId;
            self.ShowSelect(transform, parent_1);

            DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(dungeonConfigId);
            self.View.E_LevelNameText.text = dungeonConfig.ChapterName;
            self.View.E_LevelDesText.text = dungeonConfig.ChapterDes;
            
            using (zstring.Block())
            {
                self.View.E_EnterLevelText.text = zstring.Format("进入等级：{0}", dungeonConfig.EnterLv);
            }

        }

        private static void ShowSelect(this DlgDungeonMap self, Transform transform, Transform parent_1)
        {
            self.View.E_SelectImage.gameObject.SetActive(true);
            RectTransform rectTransform = self.View.EG_LevelPanelRectTransform;
            Vector3 position = rectTransform.InverseTransformPoint(transform.position);
            position.y += 40;

            self.View.EG_SelectEffectRectTransform.gameObject.SetActive(false);
            self.View.EG_SelectEffectRectTransform.gameObject.SetActive(true);
            CommonViewHelper.SetParent(self.View.E_SelectImage.gameObject, parent_1.gameObject);
            CommonViewHelper.SetParent(self.View.EG_SelectEffectRectTransform.gameObject, transform.gameObject);
            //self.View.E_SelectImage.GetComponent<RectTransform>().localPosition = position;
        }

        public static void ReEnlarge(this DlgDungeonMap self)
        {
            RectTransform rectTransform = self.View.EG_MapPanelRectTransform;
            rectTransform.DOScale(Vector3.one, self.Duration).SetEase(Ease.Linear);
           
            self.CurrentMap.gameObject.SetActive(true);
            self.View.E_SelectImage.gameObject.SetActive(false);
            self.View.EG_LevelPanelRectTransform.gameObject.SetActive(false);
            self.View.E_CloseButton.gameObject.SetActive(true);
            self.View.EG_MapPanelRectTransform.gameObject.SetActive(true);
            self.CurrentMap.transform.SetParent(self.View.EG_MapPanelRectTransform);
            self.CurrentMap.transform.localScale = Vector3.one * 0.32f;
            self.CurrentMap.transform.SetSiblingIndex(self.OriginalIndex);
            self.SetTitle(true);
            self.CurrentMap.transform.Find("Levels").gameObject.SetActive(false);

            rectTransform.DOLocalMove(Vector3.zero, self.Duration).SetEase(Ease.Linear).onComplete = () =>
            {
                self.View.E_MapPanelDiButtonButton.gameObject.SetActive(true);
                self.EnableBtns(true);
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

            switch (diff)
            {
                case 1:
                    self.View.E_NanDuTipText.text = "适合刚进入的探险者";
                    self.View.E_AdditionText.text = "正常爆率";
                    break;
                case 2:
                    self.View.E_NanDuTipText.text = "适合经常冒险";
                    self.View.E_AdditionText.text = "爆率提升20%";
                    break;
                case 3:
                    self.View.E_NanDuTipText.text = "不容一丝懈怠爆率提升50%";
                    self.View.E_AdditionText.text = "爆率提升50%";
                    break;
            }

            UserInfo userinfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            using (zstring.Block())
            {
                PlayerPrefsHelp.SetChapterDifficulty(zstring.Format("{0}{1}", userinfo.UserId, self.ChapterId), diff);
            }
        }

        public static async ETTask OnEnterMapButtonClick(this DlgDungeonMap self)
        {
            // using (zstring.Block())
            // {
            //     FlyTipComponent.Instance.ShowFlyTip(zstring.Format("请求传送 副本Id:{0} 副本难度：{1}", self.LevelId, self.Difficulty));
            // }

            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.LocalDungeon, self.LevelId, self.Difficulty);

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