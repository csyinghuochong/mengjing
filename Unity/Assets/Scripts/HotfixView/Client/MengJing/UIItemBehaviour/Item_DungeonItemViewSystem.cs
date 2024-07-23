using System;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_DungeonItem))]
    [EntitySystemOf(typeof(Scroll_Item_DungeonItem))]
    public static partial class Scroll_Item_DungeonItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_DungeonItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_DungeonItem self)
        {
            self.DestroyWidget();
        }

        public static int GetOpenLevel(this Scroll_Item_DungeonItem self, int chapterId)
        {
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

            return level;
        }

        public static async ETTask OnInitData(this Scroll_Item_DungeonItem self, int index, int chapterId)
        {
            self.ChapterId = chapterId;
            self.EG_UnLockRectTransform.gameObject.SetActive(false);
            self.EG_MoveRectTransform.gameObject.SetActive(false);
            self.E_Text_IndexText.text = DungeonSectionConfigCategory.Instance.Get(chapterId).ChapterName;
            self.E_Text_NameText.text = DungeonSectionConfigCategory.Instance.Get(chapterId).Name;

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int openlv = self.GetOpenLevel(chapterId);
            int selfLv = userInfoComponent.UserInfo.Lv;
            if (selfLv < openlv)
            {
                self.EG_UnLockRectTransform.gameObject.SetActive(true);
                using (zstring.Block())
                {
                    self.E_Text_UnlockLevelText.text = zstring.Format("{0}级解锁", openlv);
                }
            }
            else
            {
                self.EG_UnLockRectTransform.gameObject.SetActive(false);
            }

            long instanceid = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(index * 100);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.EG_MoveRectTransform.gameObject.SetActive(true);
            self.EG_MoveRectTransform.GetComponent<DoTweeningMove>().enabled = true;

            self.E_Image_DIButton.AddListenerAsync(self.OnShowChpaterLevels);
        }

        public static void SetClickHandler(this Scroll_Item_DungeonItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static async ETTask OnShowChpaterLevels(this Scroll_Item_DungeonItem self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            await uiComponent.ShowWindowAsync(WindowID.WindowID_DungeonLevel);
            DlgDungeonLevel dungeonLevel = uiComponent.GetDlgLogic<DlgDungeonLevel>();
            dungeonLevel.OnInitData(self.ChapterId);
            uiComponent.CloseWindow(WindowID.WindowID_Dungeon);
        }
    }
}