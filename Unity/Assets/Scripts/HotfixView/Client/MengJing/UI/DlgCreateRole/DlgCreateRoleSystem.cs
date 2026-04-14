using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CreateRoleSkillItem))]
    [FriendOf(typeof(DlgCreateRole))]
    [FriendOf(typeof(PlayerInfoComponent))]
    public static class DlgCreateRoleSystem
    {
        public static void RegisterUIEvent(this DlgCreateRole self)
        {
            self.View.E_CreateRoleButton.AddListenerAsync(self.OnCreateRoleButton);
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_RandomNameButton.AddListener(self.OnRandomNameButton);
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.View.E_CreateRoleNameInputField.onValueChanged.AddListener((string text) => { self.CheckSensitiveWords(); });

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            self.View.E_Icon_1_1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "1"));
            self.View.E_Icon_1_2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "1"));
            self.View.E_Icon_2_1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "2"));
            self.View.E_Icon_2_2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "2"));
            self.View.E_Icon_3_1Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "3"));
            self.View.E_Icon_3_2Image.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, "3"));

            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        public static void ShowWindow(this DlgCreateRole self, Entity contextData = null)
        {
        }

        public static void CheckSensitiveWords(this DlgCreateRole self)
        {
            string text_new = "";
            string text_old = self.View.E_CreateRoleNameInputField.text;
            MaskWordHelper.Instance.IsContainSensitiveWords(ref text_old, out text_new);
            text_old = text_old.Replace("*", "");
            self.View.E_CreateRoleNameInputField.text = text_old;
        }

        private static void OnRandomNameButton(this DlgCreateRole self)
        {
            string randomNameStr = "";
            int xingXuHaoMax = LanguageComponent.Instance.randomName_xing.Length - 1;
            int nameXuHaoMax = LanguageComponent.Instance.randomName_name.Length - 1;
            int xingXuHao = RandomHelper.NextInt(0, xingXuHaoMax);
            int nameXuHao = RandomHelper.NextInt(0, nameXuHaoMax);
            randomNameStr = LanguageComponent.Instance.randomName_xing[xingXuHao] + LanguageComponent.Instance.randomName_name[nameXuHao];

            if (randomNameStr != "")
            {
                randomNameStr = randomNameStr.Replace("*", "");
                self.View.E_CreateRoleNameInputField.text = randomNameStr;
            }
        }

        private static async ETTask OnCreateRoleButton(this DlgCreateRole self)
        {
            string createName = self.View.E_CreateRoleNameInputField.text;

            if (createName.Contains("*") || !StringHelper.IsSpecialChar(createName))
            {
                FlyTipComponent.Instance.ShowFlyTip("名字不合法!");
                return;
            }

            if (string.IsNullOrEmpty(createName))
            {
                FlyTipComponent.Instance.ShowFlyTip("请输入名字！！！");
                return;
            }

            if (self.Occ == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择职业！！！");
                return;
            }

            //參考危境，有角色则显示角色列表，点击空角色跳转到创建角色界面。
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            if (playerInfoComponent.CreateRoleList.Count >= 8)
            {
                Log.Debug("超出数量！");
                return;
            }

            await LoginHelper.RequestCreateRole(self.Root(), playerInfoComponent.AccountId, self.Occ, createName);

            self.OnCloseButton();
        }

        private static void OnFunctionSetBtn(this DlgCreateRole self, int index)
        {
            self.View.EG_OccShow_ZhanShiRectTransform.gameObject.SetActive(false);
            self.View.EG_OccShow_FaShiRectTransform.gameObject.SetActive(false);
            self.View.EG_OccShow_LieRenRectTransform.gameObject.SetActive(false);
            switch (index)
            {
                case 0:
                    self.View.EG_OccShow_ZhanShiRectTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.EG_OccShow_FaShiRectTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    self.View.EG_OccShow_LieRenRectTransform.gameObject.SetActive(true);
                    break;
            }

            self.Occ = index + 1;
            self.View.ES_ModelShow.SetCameraPosition(new Vector3(0f, 70f, 150f));
            self.View.ES_ModelShow.ShowPlayerModel(new ItemInfo(), self.Occ, 0, new List<int>());

            OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(self.Occ);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < occupationConfig.InitSkillID.Length; i++)
            {
                if (!self.ScrollItemCreateRoleSkillItems.ContainsKey(i))
                {
                    Scroll_Item_CreateRoleSkillItem item = self.AddChild<Scroll_Item_CreateRoleSkillItem>();
                    string path = "Assets/Bundles/UI/Item/Item_CreateRoleSkillItem.prefab";

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.View.EG_SkillListNodeRectTransform);
                    item.BindTrans(go.transform);
                    self.ScrollItemCreateRoleSkillItems.Add(i, item);
                }

                Scroll_Item_CreateRoleSkillItem scrollItemCreateRoleSkillItem = self.ScrollItemCreateRoleSkillItems[i];
                scrollItemCreateRoleSkillItem.uiTransform.gameObject.SetActive(true);
                scrollItemCreateRoleSkillItem.OnUpdateUI(occupationConfig.InitSkillID[i]);
            }

            if (self.ScrollItemCreateRoleSkillItems.Count > occupationConfig.InitSkillID.Length)
            {
                for (int i = occupationConfig.InitSkillID.Length; i < self.ScrollItemCreateRoleSkillItems.Count; i++)
                {
                    Scroll_Item_CreateRoleSkillItem scrollItemCreateRoleSkillItem = self.ScrollItemCreateRoleSkillItems[i];
                    scrollItemCreateRoleSkillItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }

        private static void OnCloseButton(this DlgCreateRole self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            uiComponent.ShowWindow(WindowID.WindowID_MJLobby);
            uiComponent.GetDlgLogic<DlgMJLobby>().SelectNewCreateRole();
            uiComponent.CloseWindow(WindowID.WindowID_CreateRole);
        }
    }
}