using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgDungeonLevel))]
    [FriendOf(typeof(Scroll_Item_DungeonLevelItem))]
    [EntitySystemOf(typeof(Scroll_Item_DungeonLevelItem))]
    public static partial class Scroll_Item_DungeonLevelItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_DungeonLevelItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_DungeonLevelItem self)
        {
            self.DestroyWidget();
        }

        public static void SetSelected(this Scroll_Item_DungeonLevelItem self, bool value)
        {
            self.E_ImageSelectImage.gameObject.SetActive(value);
        }

        public static void OnClikButton(this Scroll_Item_DungeonLevelItem self)
        {
            self.ClickHandler(self.ChapterId);
        }

        public static void SetClickHandler(this Scroll_Item_DungeonLevelItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        private static async ETTask OnEnterChapter(this Scroll_Item_DungeonLevelItem self)
        {
            try
            {
                if (Time.time - self.SendTime < 2f)
                {
                    return;
                }

                self.SendTime = Time.time;

                UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                int errorCode = 0;
                if (self.Type == 0)
                {
                    DlgDungeonLevel uIDungeonLevel = uiComponent.GetDlgLogic<DlgDungeonLevel>();

                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("请求传送 副本Id:{0} 副本难度：{1}", self.ChapterId, uIDungeonLevel.Difficulty));
                    }

                    errorCode =
                            await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.LocalDungeon, self.ChapterId, uIDungeonLevel.Difficulty);
                }

                if (self.Type == 1)
                {
                    if (self.Root().GetComponent<LockTargetComponent>().LastLockId != 0)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("战斗状态不能传送地图!");
                        return;
                    }

                    errorCode =
                            await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.LocalDungeon, self.ChapterId,
                                self.Root().GetComponent<MapComponent>().FubenDifficulty);
                }

                if (errorCode != ErrorCode.ERR_Success)
                {
                    HintHelp.ShowErrorHint(self.Root(), errorCode);
                    return;
                }

                if (self.IsDisposed)
                {
                    return;
                }

                uiComponent.CloseWindow(WindowID.WindowID_DungeonLevel);
                uiComponent.CloseWindow(WindowID.WindowID_DungeonMapTransfer);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        public static void OnInitData(this Scroll_Item_DungeonLevelItem self, int type, int levelIndex, int levelId)
        {
            self.Type = type;
            self.LevelIndex = levelIndex;
            self.ChapterId = levelId;
            DungeonConfig chapterConfig = DungeonConfigCategory.Instance.Get(levelId);
            self.E_Lab_ChapSonNameOutText.text = chapterConfig.ChapterName;
            using (zstring.Block())
            {
                self.E_Lab_ChapIndexText.text = zstring.Format("第{0}关", levelIndex + 1);
                self.E_Lab_EnterLevelText.text = zstring.Format("挑战等级:{0}", chapterConfig.EnterLv);
            }

            self.E_ButtonEnterButton.AddListenerAsync(self.OnEnterChapter);
        }
    }
}