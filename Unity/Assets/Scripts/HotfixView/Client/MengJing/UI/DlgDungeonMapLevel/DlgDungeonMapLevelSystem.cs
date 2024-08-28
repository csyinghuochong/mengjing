using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgDungeonMapLevel))]
    public static class DlgDungeonMapLevelSystem
    {
        public static void RegisterUIEvent(this DlgDungeonMapLevel self)
        {
            self.View.E_NanDu_1_ButtonButton.AddListener(() => { self.OnNanDu_Button(1); });
            self.View.E_NanDu_2_ButtonButton.AddListener(() => { self.OnNanDu_Button(2); });
            self.View.E_NanDu_3_ButtonButton.AddListener(() => { self.OnNanDu_Button(3); });

            self.View.E_ReturnButton.AddListener(self.OnReturnButtonClick);
            self.View.E_DungeonMapLevelItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnDungeonMapLevelItemsRefresh);
        }

        public static void ShowWindow(this DlgDungeonMapLevel self, Entity contextData = null)
        {
        }

        public static void Init(this DlgDungeonMapLevel self, int chapterId)
        {
            self.ChapterId = chapterId;

            int[] openLv = DungeonSectionConfigCategory.Instance.Get(self.ChapterId).OpenLevel;
            using (zstring.Block())
            {
                self.View.E_NanDu_1_ButtonButton.transform.Find("TextOpenLevel").GetComponent<Text>().text = zstring.Format("激活等级:{0}级", openLv[0]);
                self.View.E_NanDu_2_ButtonButton.transform.Find("TextOpenLevel").GetComponent<Text>().text = zstring.Format("激活等级:{0}级", openLv[1]);
                self.View.E_NanDu_3_ButtonButton.transform.Find("TextOpenLevel").GetComponent<Text>().text = zstring.Format("激活等级:{0}级", openLv[2]);

                UserInfo userinfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                self.OnNanDu_Button(PlayerPrefsHelp.GetChapterDifficulty(zstring.Format("{0}{1}", userinfo.UserId, self.ChapterId)));
            }

            // self.UpdateLevelList(chapterId).Coroutine();
        }

        private static void OnDungeonMapLevelItemsRefresh(this DlgDungeonMapLevel self, Transform transform, int index)
        {
            Scroll_Item_DungeonMapLevelItem scrollItemDungeonMapLevelItem = self.ScrollItemDungeonMapLevelItems[index].BindTrans(transform);
            scrollItemDungeonMapLevelItem.Refresh(self.ShowLevel[index], self.DungeonSectionConfig.RandomArea[self.ShowLevel[index]], self.Difficulty);
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

            // TODO 更新Item
        }

        private static void OnReturnButtonClick(this DlgDungeonMapLevel self)
        {
            DlgDungeonMap dungeonMap = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDungeonMap>();
            dungeonMap.ReEnlarge();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMapLevel);
        }
    }
}