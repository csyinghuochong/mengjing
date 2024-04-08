using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgDungeonLevel))]
    [FriendOf(typeof (Scroll_Item_DungeonLevelItem))]
    [EntitySystemOf(typeof (Scroll_Item_DungeonLevelItem))]
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
                DlgDungeonLevel uIDungeonLevel = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDungeonLevel>();

                FlyTipComponent.Instance.SpawnFlyTipDi($"请求传送 副本Id:{self.ChapterId} 副本难度：{uIDungeonLevel.Difficulty}");

                int errorCode =
                        await EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.LocalDungeon, self.ChapterId, uIDungeonLevel.Difficulty);

                if (errorCode != ErrorCode.ERR_Success)
                {
                    ErrorViewHelp.ShowErrorHint(self.Root(), errorCode);
                    return;
                }

                if (self.IsDisposed)
                {
                    return;
                }

                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonLevel);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        public static void OnInitData(this Scroll_Item_DungeonLevelItem self, int ChapterIndex, int levelIndex, int levelId)
        {
            self.LevelIndex = levelIndex;
            self.ChapterId = levelId;
            DungeonConfig chapterConfig = DungeonConfigCategory.Instance.Get(levelId);
            self.E_Lab_ChapSonNameOutText.text = chapterConfig.ChapterName;
            //self.Lab_ChapIndex.GetComponent<Text>().text = $"第{ChapterIndex}章 第{levelIndex+1}关";
            self.E_Lab_ChapIndexText.text = $"第{levelIndex + 1}关";
            self.E_Lab_EnterLevelText.text = "挑战等级:" + chapterConfig.EnterLv;

            //Sprite sp = ABAtlasHelp.GetIconSprite(ABAtlasTypes.MonsterIcon, chapterConfig.BossIcon.ToString());
            //self.ImageBossIcon.GetComponent<Image>().sprite = sp;

            self.E_ButtonEnterButton.AddListenerAsync(self.OnEnterChapter);
        }
    }
}