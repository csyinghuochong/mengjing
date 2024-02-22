using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (PlayerComponent))]
    [FriendOf(typeof (Scroll_Item_CreateRoleItem))]
    [EntitySystemOf(typeof (Scroll_Item_CreateRoleItem))]
    public static partial class Scroll_Item_CreateRoleItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CreateRoleItem self)
        {
            self.E_SelectRoleButton.AddListenerAsync(self.OnSelectRoleButton);
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CreateRoleItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_CreateRoleItem self, CreateRoleInfo createRoleInfo)
        {
            self.CreateRoleInfo = createRoleInfo;
            if (createRoleInfo != null)
            {
                self.E_RoleNameText.text = createRoleInfo.PlayerName;
                self.E_RoleLvText.text = GameSettingLanguge.LoadLocalization("等级:") + createRoleInfo.PlayerLv;
                if (createRoleInfo.OccTwo > 0)
                {
                    OccupationTwoConfig occupationTwo = OccupationTwoConfigCategory.Instance.Get(createRoleInfo.OccTwo);
                    self.E_RoleOccText.text = $"职业:{occupationTwo.OccupationName}";
                }
                else
                {
                    OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(createRoleInfo.PlayerOcc);
                    self.E_RoleOccText.text = $"职业:{occupationConfig.OccupationName}";
                }

                self.E_RoleHeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, createRoleInfo.PlayerOcc.ToString()));
                self.E_RoleHeadIconImage.gameObject.SetActive(true);
                self.EG_NoRoleRectTransform.gameObject.SetActive(false);
                self.EG_RoleRectTransform.gameObject.SetActive(true);
            }
            else
            {
                PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
                if (playerComponent.CreateRoleList.Count >= 8)
                {
                    self.EG_NoRoleRectTransform.gameObject.SetActive(false);
                    self.EG_RoleRectTransform.gameObject.SetActive(false);
                    self.E_RoleLvText.gameObject.SetActive(false);
                    self.E_RoleHeadIconImage.gameObject.SetActive(false);
                }
                else
                {
                    //显示为空
                    self.EG_NoRoleRectTransform.gameObject.SetActive(true);
                    self.EG_RoleRectTransform.gameObject.SetActive(false);
                    self.E_RoleNameText.text = GameSettingLanguge.LoadLocalization("点击创建角色");
                    self.E_RoleLvText.gameObject.SetActive(false);
                    self.E_RoleHeadIconImage.gameObject.SetActive(false);
                    self.E_RoleOccText.text = "职业:战士/法师";
                }
            }

            self.E_DiImage.gameObject.SetActive(self.CreateRoleInfo == null);
        }

        private static async ETTask OnSelectRoleButton(this Scroll_Item_CreateRoleItem self)
        {
            UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
            if (self.CreateRoleInfo == null)
            {
                uiComponent.ShowWindow(WindowID.WindowID_CreateRole);
                uiComponent.CloseWindow(WindowID.WindowID_MJLobby);
            }

            PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            if (playerComponent.CreateRoleList.Count >= 8)
            {
                Log.Error("角色列表已达上限！");
                return;
            }

            uiComponent.GetDlgLogic<DlgMJLobby>().UpdateSelect(self.CreateRoleInfo);
        }

        public static void UpdateSelectStatus(this Scroll_Item_CreateRoleItem self, CreateRoleInfo createRoleListInfo)
        {
            if (createRoleListInfo != null && createRoleListInfo == self.CreateRoleInfo)
            {
                self.E_SelectImage.gameObject.SetActive(true);
                self.uiTransform.localScale = Vector3.one * 1.2f;
            }
            else
            {
                self.E_SelectImage.gameObject.SetActive(false);
                self.uiTransform.transform.localScale = Vector3.one;
            }
        }
    }
}