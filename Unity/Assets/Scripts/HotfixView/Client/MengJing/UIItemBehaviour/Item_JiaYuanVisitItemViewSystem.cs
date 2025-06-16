using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanVisitItem))]
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanVisitItem))]
    public static partial class Scroll_Item_JiaYuanVisitItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanVisitItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanVisitItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanVisitItem self, JiaYuanVisit jiaYuanVisit)
        {
            self.E_ButtonVisitButton.AddListener(self.OnButtonVisit);
            self.JiaYuanVisit = jiaYuanVisit;

            using (zstring.Block())
            {
                self.E_TextTimes_2Text.text = zstring.Format("×{0}", jiaYuanVisit.Rubbish);
                self.E_TextTimes_1Text.text = zstring.Format("×{0}", jiaYuanVisit.Gather);
            }

            self.E_TextNameText.text = jiaYuanVisit.PlayerName;
            self.E_ImageIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, jiaYuanVisit.Occ.ToString()));
        }

        public static void OnButtonVisit(this Scroll_Item_JiaYuanVisitItem self)
        {
            long masterid = self.Root().GetComponent<JiaYuanComponentC>().MasterId;
            if (masterid == self.JiaYuanVisit.UnitId)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经在当前房间中！");
                return;
            }

            self.Root().GetComponent<JiaYuanComponentC>().MasterId = self.JiaYuanVisit.UnitId;
            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.JiaYuan, 2000011, 1, self.JiaYuanVisit.UnitId.ToString()).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanMain);
        }
    }
}