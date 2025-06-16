using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CellDungeonItem))]
    [FriendOf(typeof(DlgCellChapterSelectViewComponent))]
    [FriendOf(typeof(DlgCellChapterSelect))]
    public static class DlgCellChapterSelectSystem
    {
        public static void RegisterUIEvent(this DlgCellChapterSelect self)
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
            }

            self.View.E_NanDu_1_ButtonButton.AddListener(() => { self.OnNanDu_Button(1); });
            self.View.E_NanDu_2_ButtonButton.AddListener(() => { self.OnNanDu_Button(2); });
            self.View.E_NanDu_3_ButtonButton.AddListener(() => { self.OnNanDu_Button(3); });

            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellChapterSelect); });
            self.View.E_LevelReturnButton.AddListener(self.ReEnlarge);
            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMapButtonClick);
            self.View.E_CellDungeonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCellDungeonItemsRefresh);
        }

        public static void ShowWindow(this DlgCellChapterSelect self, Entity contextData = null)
        {
            self.View.EG_LevelPanelRectTransform.gameObject.SetActive(false);
        }

        public static void BeforeUnload(this DlgCellChapterSelect self)
        {
            self.View.EG_MapPanelRectTransform.DOKill();
        }

        private static void OnCellDungeonItemsRefresh(this DlgCellChapterSelect self, Transform transform, int index)
        {
            foreach (Scroll_Item_CellDungeonItem item in self.ScrollItemCellDungeonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CellDungeonItem scrollItemDungeonMapLevelItem = self.ScrollItemCellDungeonItems[index].BindTrans(transform);
            CellChapterConfig cellChapterConfig = CellChapterConfigCategory.Instance.Get(self.ChapterId);
            scrollItemDungeonMapLevelItem.Refresh(cellChapterConfig.RandomArea[index]);
        }

        public static void OnSelect(this DlgCellChapterSelect self, int levelId)
        {
            self.LevelId = levelId;

            CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(levelId);
            self.View.E_LevelNameText.text = cellGenerateConfig.ChapterName;
            self.View.E_LevelDesText.text = cellGenerateConfig.ChapterDes;
            using (zstring.Block())
            {
                self.View.E_EnterLevelText.text = zstring.Format("进入等级：{0}", cellGenerateConfig.EnterLv);
            }
        }

        private static bool CanOpen(this DlgCellChapterSelect self, int chapterId)
        {
            if (!CellChapterConfigCategory.Instance.Contain(chapterId))
            {
                return false;
            }

            int selfLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;

            int level = 100;
            int[] chapters = CellChapterConfigCategory.Instance.Get(chapterId).RandomArea;
            for (int i = 0; i < chapters.Length; i++)
            {
                CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(chapters[i]);
                if (cellGenerateConfig.EnterLv < level)
                {
                    level = cellGenerateConfig.EnterLv;
                }
            }

            return selfLv >= level;
        }

        private static void EnableBtns(this DlgCellChapterSelect self, bool enable)
        {
            foreach (GameObject go in self.MapGameObjects)
            {
                go.GetComponent<Button>().enabled = enable;
            }
        }

        private static void SetTitle(this DlgCellChapterSelect self, bool enable)
        {
            foreach (GameObject go in self.MapGameObjects)
            {
                go.transform.Find("Title")?.gameObject.SetActive(enable);
            }
        }

        private static void Enlarge(this DlgCellChapterSelect self, int map, int chapterId)
        {
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

            Vector3 targetScale = Vector3.one * self.ScaleFactor;
            rectTransform.DOScale(targetScale, self.Duration).SetEase(Ease.Linear);

            Vector3 buttonLocalPosition = self.View.uiTransform.InverseTransformPoint(buttonRectTransform.position);
            Vector3 targetPosition = rectTransform.localPosition - buttonLocalPosition;
            targetPosition *= self.ScaleFactor;
            targetPosition.x -= 250f;
            rectTransform.DOLocalMove(targetPosition, self.Duration).SetEase(Ease.Linear).onComplete = () =>
            {
                self.SetTitle(false);

                CellChapterConfig cellChapterConfig = CellChapterConfigCategory.Instance.Get(self.ChapterId);
                self.AddUIScrollItems(ref self.ScrollItemCellDungeonItems, cellChapterConfig.RandomArea.Length);
                self.View.E_CellDungeonItemsLoopVerticalScrollRect.SetVisible(true, cellChapterConfig.RandomArea.Length);

                // 默认选第一个
                Scroll_Item_CellDungeonItem item = self.ScrollItemCellDungeonItems[0];
                item.OnClick();

                self.CurrentMap.transform.SetParent(self.View.E_BlackBGImage.transform);
                self.View.EG_MapPanelRectTransform.gameObject.SetActive(false);

                UserInfo userinfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                using (zstring.Block())
                {
                    self.OnNanDu_Button(PlayerPrefsHelp.GetChapterDifficulty(zstring.Format("{0}{1}", userinfo.UserId, self.ChapterId)));
                }

                self.View.EG_LevelPanelRectTransform.gameObject.SetActive(true);
                self.View.E_CloseButton.gameObject.SetActive(false);
            };
        }

        public static void ReEnlarge(this DlgCellChapterSelect self)
        {
            RectTransform rectTransform = self.View.EG_MapPanelRectTransform;
            rectTransform.DOScale(Vector3.one, self.Duration).SetEase(Ease.Linear);

            self.View.EG_LevelPanelRectTransform.gameObject.SetActive(false);
            self.View.E_CloseButton.gameObject.SetActive(true);
            self.View.EG_MapPanelRectTransform.gameObject.SetActive(true);
            self.CurrentMap.transform.SetParent(self.View.EG_MapPanelRectTransform);
            self.CurrentMap.transform.SetSiblingIndex(self.OriginalIndex);
            self.SetTitle(true);

            rectTransform.DOLocalMove(Vector3.zero, self.Duration).SetEase(Ease.Linear).onComplete = () => { self.EnableBtns(true); };
        }

        private static void OnNanDu_Button(this DlgCellChapterSelect self, int diff)
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
                    self.View.E_AdditionText.text = string.Empty;
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

        public static async ETTask OnEnterMapButtonClick(this DlgCellChapterSelect self)
        {
            // using (zstring.Block())
            // {
            //     FlyTipComponent.Instance.ShowFlyTip(zstring.Format("请求传送 副本Id:{0} 副本难度：{1}", self.LevelId, self.Difficulty));
            // }

            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.CellDungeon, self.LevelId, self.Difficulty, "0");

            if (errorCode != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), errorCode);
                return;
            }

            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.CloseWindow(WindowID.WindowID_CellChapterSelect);
        }
    }
}