using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_DungeonMapLevelItem))]
    [FriendOf(typeof(DlgDungeonMapLevel))]
    public static class DlgDungeonMapLevelSystem
    {
        public static void RegisterUIEvent(this DlgDungeonMapLevel self)
        {
            self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnDungeonMapLevelItemsRefresh);

            self.View.E_NanDu_1_ButtonButton.AddListener(() => { self.OnNanDu_Button(1); });
            self.View.E_NanDu_2_ButtonButton.AddListener(() => { self.OnNanDu_Button(2); });
            self.View.E_NanDu_3_ButtonButton.AddListener(() => { self.OnNanDu_Button(3); });

            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMapButtonClick);
            self.View.E_ReturnButton.AddListener(self.OnReturnButtonClick);
        }

        public static void ShowWindow(this DlgDungeonMapLevel self, Entity contextData = null)
        {
            self.View.E_RightBGImage.gameObject.SetActive(false);
        }

        public static void Init(this DlgDungeonMapLevel self, int chapterId)
        {
            self.ChapterId = chapterId;

            int[] openLv = DungeonSectionConfigCategory.Instance.Get(self.ChapterId).OpenLevel;
            using (zstring.Block())
            {
                UserInfo userinfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                self.OnNanDu_Button(PlayerPrefsHelp.GetChapterDifficulty(zstring.Format("{0}{1}", userinfo.UserId, self.ChapterId)));
            }

            self.UpdateLevelList();
        }

        private static void UpdateLevelList(this DlgDungeonMapLevel self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            DungeonSectionConfig dungeonSectionConfig = DungeonSectionConfigCategory.Instance.Get(self.ChapterId);
            self.DungeonSectionConfig = dungeonSectionConfig;
            self.ShowLevel.Clear();

            for (int i = 0; i < dungeonSectionConfig.RandomArea.Length; i++)
            {
                //只显示满足进入等级的关卡
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

            self.AddUIScrollItems(ref self.ScrollItemDungeonMapLevelItems, self.ShowLevel.Count);
            self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.SetVisible(true, self.ShowLevel.Count);
        }

        private static void OnDungeonMapLevelItemsRefresh(this DlgDungeonMapLevel self, Transform transform, int index)
        {
            Scroll_Item_DungeonMapLevelItem scrollItemDungeonMapLevelItem = self.ScrollItemDungeonMapLevelItems[index].BindTrans(transform);
            scrollItemDungeonMapLevelItem.Refresh(self.ShowLevel[index], self.DungeonSectionConfig.RandomArea[self.ShowLevel[index]],
                self.Difficulty, self.OnSelectLevel);
        }

        private static void OnNanDu_Button(this DlgDungeonMapLevel self, int diff)
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

            if (self.ScrollItemDungeonMapLevelItems != null)
            {
                foreach (Scroll_Item_DungeonMapLevelItem item in self.ScrollItemDungeonMapLevelItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetNanDu(self.Difficulty);
                }
            }
        }

        private static void OnSelectLevel(this DlgDungeonMapLevel self, int levelId)
        {
            self.View.E_RightBGImage.gameObject.SetActive(true);

            self.LevelId = levelId;

            DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(levelId);

            self.View.E_LevelNameText.text = dungeonConfig.ChapterName;
            self.View.E_LevelDesText.text = dungeonConfig.ChapterDes;
            using (zstring.Block())
            {
                self.View.E_EnterLevelText.text = zstring.Format("挑战等级：{0}", dungeonConfig.EnterLv);
            }

            if (self.ScrollItemDungeonMapLevelItems != null)
            {
                foreach (Scroll_Item_DungeonMapLevelItem item in self.ScrollItemDungeonMapLevelItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.UpdateSelect(self.LevelId);
                }
            }
        }

        private static async ETTask OnEnterMapButtonClick(this DlgDungeonMapLevel self)
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
            uiComponent.CloseWindow(WindowID.WindowID_DungeonMapLevel);
        }

        private static void OnReturnButtonClick(this DlgDungeonMapLevel self)
        {
            DlgDungeonMap dungeonMap = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDungeonMap>();
            dungeonMap.ReEnlarge();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMapLevel);
        }
    }
}