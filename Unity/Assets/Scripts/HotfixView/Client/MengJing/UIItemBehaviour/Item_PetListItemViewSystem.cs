using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetListItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetListItem))]
    public static partial class Scroll_Item_PetListItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetListItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetListItem self)
        {
            self.DestroyWidget();
        }

        public static void OnClickPetItem(this Scroll_Item_PetListItem self)
        {
            self.ClickPetHandler?.Invoke(self.PetId);
        }

        public static void OnSelectUI(this Scroll_Item_PetListItem self, RolePetInfo rolePetInfo)
        {
            self.E_ImageXuanzhongImage.gameObject.SetActive(self.PetId == rolePetInfo.Id);
        }

        public static void OnUpdatePetPoint(this Scroll_Item_PetListItem self, RolePetInfo rolePetInfo)
        {
            if (rolePetInfo == null)
            {
                return;
            }

            if (rolePetInfo.Id != self.PetId)
            {
                return;
            }

            self.PetId = rolePetInfo.Id;
            self.E_ReddotImage.gameObject.SetActive(rolePetInfo.AddPropretyNum > 0);
        }

        public static void OnRName(this Scroll_Item_PetListItem self, RolePetInfo rolePetInfo)
        {
            self.E_Lab_PetNameText.text = rolePetInfo.PetName;
        }

        public static void OnPetFightingSet(this Scroll_Item_PetListItem self, RolePetInfo rolePetInfo)
        {
            self.E_Img_CanZhanImage.gameObject.SetActive(rolePetInfo != null && self.PetId == rolePetInfo.Id);
        }

        public static void OnPetProtectSet(this Scroll_Item_PetListItem self, RolePetInfo rolePetInfo)
        {
            self.E_Image_ProtectImage.gameObject.SetActive(rolePetInfo != null && self.PetId == rolePetInfo.Id);
        }

        public static void SetClickHandler(this Scroll_Item_PetListItem self, Action<long> action)
        {
            self.ClickPetHandler = action;
        }

        public static void OnInitData(this Scroll_Item_PetListItem self, RolePetInfo rolePetInfo, int nextLv)
        {
            self.E_ImageXuanzhongImage.gameObject.SetActive(false);
            self.E_ImageDiButtonButton.AddListener(self.OnClickPetItem);

            if (rolePetInfo != null)
            {
                self.PetId = rolePetInfo.Id;
            }
            else
            {
                self.PetId = 0;
            }

            self.EG_Node_1RectTransform.gameObject.SetActive(rolePetInfo != null);
            self.EG_Node_2RectTransform.gameObject.SetActive(rolePetInfo == null);
            if (rolePetInfo != null)
            {
                self.OnUpdatePetPoint(rolePetInfo);
                PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.E_Img_PetHeroIonImage.sprite = sp;

                self.E_Img_CanZhanImage.gameObject.SetActive(rolePetInfo.PetStatus == 1);
                self.E_Lab_PetNameText.text = rolePetInfo.PetName;
                using (zstring.Block())
                {
                    self.E_Lab_PetLvText.text = zstring.Format("{0}{1}", rolePetInfo.PetLv, "级");
                }

                self.E_Lab_PetQualityText.text = CommonViewHelper.GetPetQualityName(petConfig.PetQuality);
                self.E_Lab_PetQualityText.color = CommonViewHelper.QualityReturnColor(petConfig.PetQuality);

                self.E_Lab_StatusText.text = rolePetInfo.PetStatus == 2 ? "散步中..." : String.Empty;

                self.E_Image_ProtectImage.gameObject?.SetActive(rolePetInfo.IsProtect);
            }
            else
            {
                using (zstring.Block())
                {
                    self.E_Text_OpenText.text = zstring.Format("{0}级开启", nextLv);
                }
            }
        }

        public static void UpdateLv(this Scroll_Item_PetListItem self)
        {
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(self.PetId);
            if (rolePetInfo != null)
            {
                using (zstring.Block())
                {
                    self.E_Lab_PetLvText.text = zstring.Format("{0}{1}", rolePetInfo.PetLv, "级");
                }
            }
        }

        public static void StartShowImg(this Scroll_Item_PetListItem self, GameObject startObj)
        {
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, "Start_2");
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            startObj.GetComponent<Image>().sprite = sp;
        }
    }
}