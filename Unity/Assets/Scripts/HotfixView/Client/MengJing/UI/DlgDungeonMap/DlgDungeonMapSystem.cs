using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
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

            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMap); });
        }

        public static void ShowWindow(this DlgDungeonMap self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgDungeonMap self)
        {
            self.View.E_MapPanelImage.GetComponent<RectTransform>().DOKill();
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
            self.EnableBtns(false);

            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            RectTransform buttonRectTransform = clickedButton.GetComponent<RectTransform>();

            Vector3 targetScale = Vector3.one * self.ScaleFactor;
            rectTransform.DOScale(targetScale, self.Duration).SetEase(Ease.Linear);

            Vector3 buttonLocalPosition = rectTransform.InverseTransformPoint(buttonRectTransform.position);
            Vector3 targetPosition = rectTransform.localPosition - buttonLocalPosition;
            rectTransform.DOLocalMove(targetPosition, self.Duration).SetEase(Ease.Linear).onComplete = () =>
            {
                if (self.CanOpen(chapterId))
                {
                    self.ShowLevel(chapterId).Coroutine();
                }
                else
                {
                    FlyTipComponent.Instance.ShowFlyTip("未开启");
                    self.ReEnlarge();
                }
            };
        }

        private static async ETTask ShowLevel(this DlgDungeonMap self, int chapterId)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DungeonMapLevel);
            DlgDungeonMapLevel dlgDungeonMapLevel = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDungeonMapLevel>();
            dlgDungeonMapLevel.Init(chapterId);
        }

        public static void ReEnlarge(this DlgDungeonMap self)
        {
            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            rectTransform.DOScale(Vector3.one, self.Duration).SetEase(Ease.Linear);

            rectTransform.DOLocalMove(Vector3.zero, self.Duration).SetEase(Ease.Linear).onComplete = () => { self.EnableBtns(true); };
        }
    }
}