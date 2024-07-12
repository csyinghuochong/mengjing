using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetListItem))]
    [EntitySystemOf(typeof (ES_ProtectPet))]
    [FriendOfAttribute(typeof (ES_ProtectPet))]
    public static partial class ES_ProtectPetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ProtectPet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_PetListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetListItemsRefresh);
            self.E_UnlockButtonButton.AddListener(() => { self.RequestProtect(false).Coroutine(); });
            self.E_XiLianButtonButton.AddListener(() => { self.RequestProtect(true).Coroutine(); });
        }

        [EntitySystem]
        private static void Destroy(this ES_ProtectPet self)
        {
            self.DestroyWidget();
        }

        private static void OnPetListItemsRefresh(this ES_ProtectPet self, Transform transform, int index)
        {
            Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index].BindTrans(transform);
            scrollItemPetListItem.SetClickHandler((petId) => { self.OnClickPetHandler(petId); });
            scrollItemPetListItem.OnInitData(self.ShowRolePetInfos[index], 0);
        }

        public static void OnUpdateUI(this ES_ProtectPet self)
        {
            self.PetInfoId = 0;
            self.OnInitPetList();
            if (self.ScrollItemPetListItems != null)
            {
                Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[0];
                scrollItemPetListItem.OnClickPetItem();
            }
        }

        public static void OnClickPetHandler(this ES_ProtectPet self, long petId)
        {
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId);
            if (rolePetInfo == null)
            {
                return;
            }

            if (self.ScrollItemPetListItems != null)
            {
                foreach (Scroll_Item_PetListItem item in self.ScrollItemPetListItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.OnSelectUI(rolePetInfo);
                }
            }

            self.PetInfoId = petId;
            self.E_XiLianButtonButton.gameObject.SetActive(!rolePetInfo.IsProtect);
            self.E_UnlockButtonButton.gameObject.SetActive(rolePetInfo.IsProtect);
            self.E_Text_NameText.text = rolePetInfo.PetName;
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_PetIconImage.sprite = sp;
        }

        public static async ETTask RequestProtect(this ES_ProtectPet self, bool isprotectd)
        {
            await PetNetHelper.RolePetProtect(self.Root(), self.PetInfoId, isprotectd);

            if (self.IsDisposed)
            {
                return;
            }

            string tip = isprotectd? "锁定" : "解锁";
            FlyTipComponent.Instance.ShowFlyTipDi($"宠物{tip}成功");
            self.Root().GetComponent<PetComponentC>().OnPetProtect(self.PetInfoId, isprotectd);
            self.OnInitPetList();
            self.OnClickPetHandler(self.PetInfoId);
        }

        public static void OnInitPetList(this ES_ProtectPet self)
        {
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;

            self.ShowRolePetInfos.Clear();
            self.ShowRolePetInfos.AddRange(rolePetInfos);

            self.AddUIScrollItems(ref self.ScrollItemPetListItems, self.ShowRolePetInfos.Count);
            self.E_PetListItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }
    }
}