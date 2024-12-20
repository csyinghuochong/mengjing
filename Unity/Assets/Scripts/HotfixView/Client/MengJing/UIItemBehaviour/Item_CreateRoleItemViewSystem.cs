using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(PlayerInfoComponent))]
    [FriendOf(typeof(Scroll_Item_CreateRoleItem))]
    [EntitySystemOf(typeof(Scroll_Item_CreateRoleItem))]
    public static partial class Scroll_Item_CreateRoleItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CreateRoleItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CreateRoleItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_CreateRoleItem self, CreateRoleInfo createRoleInfo, Action<CreateRoleInfo> updateSelectAction)
        {
            self.CreateRoleInfo = createRoleInfo;
            if (createRoleInfo != null)
            {
                self.E_RoleNameText.text = createRoleInfo.PlayerName;
                using (zstring.Block())
                {
                    self.E_RoleLvText.text = zstring.Format("{0}{1}", LanguageComponent.Instance.LoadLocalization("等级:"), createRoleInfo.PlayerLv);
                }

                if (createRoleInfo.OccTwo > 0)
                {
                    OccupationTwoConfig occupationTwo = OccupationTwoConfigCategory.Instance.Get(createRoleInfo.OccTwo);
                    using (zstring.Block())
                    {
                        self.E_RoleOccText.text = zstring.Format("职业:{0}", occupationTwo.OccupationName);
                    }
                }
                else
                {
                    OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(createRoleInfo.PlayerOcc);
                    using (zstring.Block())
                    {
                        self.E_RoleOccText.text = zstring.Format("职业:{0}", occupationConfig.OccupationName);
                    }
                }

                self.E_RoleHeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, createRoleInfo.PlayerOcc.ToString()));
                self.EG_NoRoleRectTransform.gameObject.SetActive(false);
                self.EG_RoleRectTransform.gameObject.SetActive(true);
            }
            else
            {
                PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
                if (playerInfoComponent.CreateRoleList.Count >= 8)
                {
                    self.EG_NoRoleRectTransform.gameObject.SetActive(false);
                    self.EG_RoleRectTransform.gameObject.SetActive(false);
                }
                else
                {
                    self.EG_NoRoleRectTransform.gameObject.SetActive(true);
                    self.EG_RoleRectTransform.gameObject.SetActive(false);
                }
            }

            self.E_DiImage.gameObject.SetActive(self.CreateRoleInfo == null);
            self.E_SelectRoleButton.AddListener(() =>
            {
                UIComponent uiComponent = self.Root().GetComponent<UIComponent>();
                if (self.CreateRoleInfo == null)
                {
                    uiComponent.ShowWindow(WindowID.WindowID_CreateRole);
                    uiComponent.HideWindow(WindowID.WindowID_MJLobby);
                }
                else
                {
                    updateSelectAction?.Invoke(self.CreateRoleInfo);
                }
            });
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
                self.uiTransform.localScale = Vector3.one;
            }
        }
    }
}