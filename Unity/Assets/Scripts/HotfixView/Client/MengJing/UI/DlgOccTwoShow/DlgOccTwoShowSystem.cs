using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof (DlgOccTwoShow))]
    public static class DlgOccTwoShowSystem
    {
        public static void RegisterUIEvent(this DlgOccTwoShow self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgOccTwoShow self, Entity contextData = null)
        {
        }

        public static void OnBtn_CloseButton(this DlgOccTwoShow self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_OccTwoShow);
        }
        
        public static void OnInitUI(this DlgOccTwoShow self)
        {
            int occTwo = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;

            self.InitModelShowView();
            self.ShowSkillList(occTwo).Coroutine();
        }

        public static async ETTask ShowSkillList(this DlgOccTwoShow self, int occTwo)
        {
            var path = ABPathHelper.GetUGUIPath("Item/Item_CommonSkillItem");
            var bundleGameObject = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(path);
            OccupationTwoConfig twoConfig = OccupationTwoConfigCategory.Instance.Get(occTwo);
            for (int i = 0; i < twoConfig.SkillID.Length; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
                CommonViewHelper.SetParent(go, self.View.EG_SkillListItemRectTransform.gameObject);
                Scroll_Item_CommonSkillItem ui_item = self.AddChild<Scroll_Item_CommonSkillItem>(go);
                ui_item.uiTransform = go.transform;
                ui_item.OnUpdateUI(twoConfig.SkillID[i], ABAtlasTypes.RoleSkillIcon);
            }
        }

        public static void InitModelShowView(this DlgOccTwoShow self)
        {
            OccupationTwoConfig twoCof = OccupationTwoConfigCategory.Instance.Get(self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo);

            self.View.E_TextOccTwoNameText.text = twoCof.OccupationName;

            self.View.ES_ModelShow.SetCameraPosition(new Vector3(0f, 70f, 150f));
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemInfo bagInfo = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            self.View.ES_ModelShow.ShowPlayerModel(bagInfo, userInfo.Occ, 0, bagComponent.FashionEquipList);
        }
    }
}
