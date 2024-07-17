using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_SettingTitleItem))]
    [EntitySystemOf(typeof (Scroll_Item_SettingTitleItem))]
    public static partial class Scroll_Item_SettingTitleItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SettingTitleItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SettingTitleItem self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonActivite(this Scroll_Item_SettingTitleItem self)
        {
            await BagClientNetHelper.TitleUse(self.Root(), self.Title);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSetting>().OnTitleUse();
        }

        public static void OnUpdateUI(this Scroll_Item_SettingTitleItem self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int titleId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.TitleID);
            self.E_ButtonActiviteButton.gameObject.SetActive(titleId != self.Title);
            self.EG_UseSetRectTransform.gameObject.SetActive(titleId == self.Title);
        }

        public static void OnInitUI(this Scroll_Item_SettingTitleItem self, int titieInfoId, bool activeed)
        {
            self.E_ButtonActiviteButton.AddListenerAsync(self.OnButtonActivite);
            if (self.UIXuLieZhenComponent != null)
            {
                self.UIXuLieZhenComponent.Dispose();
                self.UIXuLieZhenComponent = null;
            }

            self.UIXuLieZhenComponent = self.AddChild<UIXuLieZhenComponent, GameObject>(self.E_RawImageImage.gameObject);

            self.Title = titieInfoId;
            TitleConfig titleConfig = TitleConfigCategory.Instance.Get(titieInfoId);
            self.E_ChengHaoNameText.text = titleConfig.Name;

            self.UIXuLieZhenComponent.OnUpdateTitle(titieInfoId).Coroutine();

            self.E_ObjGetTextText.text = titleConfig.GetDes;
            self.E_Text_valueText.text = titleConfig.Des;
            self.OnUpdateUI();

            CommonViewHelper.SetImageGray(self.Root(), self.E_RawImageImage.gameObject, !activeed);
        }
    }
}