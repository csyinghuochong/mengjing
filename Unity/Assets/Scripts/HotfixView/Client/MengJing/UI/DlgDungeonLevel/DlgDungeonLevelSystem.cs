using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_DungeonLevelItem))]
    [FriendOf(typeof(DlgDungeonLevel))]
    public static class DlgDungeonLevelSystem
    {
        public static void RegisterUIEvent(this DlgDungeonLevel self)
        {
            self.View.E_NanDu_1_ButtonButton.AddListener(() => { self.OnNanDu_Button(1); });
            self.View.E_NanDu_2_ButtonButton.AddListener(() => { self.OnNanDu_Button(2); });
            self.View.E_NanDu_3_ButtonButton.AddListener(() => { self.OnNanDu_Button(3); });

            self.View.E_ButtonCloseButton.AddListenerAsync(self.OnButtonCloseButton);
            self.View.E_DungeonLevelItemLoopVerticalScrollRect.AddItemRefreshListener(self.OnDungeonLevelItemsRefresh);
        }

        public static void ShowWindow(this DlgDungeonLevel self, Entity contextData = null)
        {
        }

        public static void OnNanDu_Button(this DlgDungeonLevel self, int diff)
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

        public static void OnClickHandler(this DlgDungeonLevel self, int chapterId)
        {
            for (int i = 0; i < self.ScrollItemDungeonLevelItems.Count; i++)
            {
                Scroll_Item_DungeonLevelItem scrollItemDungeonLevelItem = self.ScrollItemDungeonLevelItems[i];
                if (scrollItemDungeonLevelItem.uiTransform != null)
                {
                    scrollItemDungeonLevelItem.SetSelected(scrollItemDungeonLevelItem.ChapterId == chapterId);
                }
            }
        }

        public static async ETTask OnButtonCloseButton(this DlgDungeonLevel self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Dungeon);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonLevel);
        }

        public static void OnInitData(this DlgDungeonLevel self, int chapterId)
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

            self.UpdateLevelList(chapterId).Coroutine();
        }

        private static void OnDungeonLevelItemsRefresh(this DlgDungeonLevel self, Transform transform, int index)
        {
            foreach (Scroll_Item_DungeonLevelItem item in self.ScrollItemDungeonLevelItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_DungeonLevelItem scrollItemDungeonLevelItem = self.ScrollItemDungeonLevelItems[index].BindTrans(transform);
            scrollItemDungeonLevelItem.OnInitData(0, self.ShowLevel[index], self.DungeonSectionConfig.RandomArea[self.ShowLevel[index]]);
        }

        public static async ETTask UpdateLevelList(this DlgDungeonLevel self, int chapterid)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            DungeonSectionConfig dungeonSectionConfig = DungeonSectionConfigCategory.Instance.Get(chapterid);
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

                self.View.E_Lab_LevelNameText.text = dungeonSectionConfig.Name;
                using (zstring.Block())
                {
                    self.View.E_Lab_OpenNumShowText.text = zstring.Format("({0}：{1}/{2})", LanguageComponent.Instance.LoadLocalization("冒险进度"),
                        (i + 1).ToString(), dungeonSectionConfig.RandomArea.Length.ToString());
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemDungeonLevelItems, self.ShowLevel.Count);
            self.View.E_DungeonLevelItemLoopVerticalScrollRect.SetVisible(true, self.ShowLevel.Count);

            // await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
            // self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIDungeonLevel");
            
            await ETTask.CompletedTask;
        }
    }
}