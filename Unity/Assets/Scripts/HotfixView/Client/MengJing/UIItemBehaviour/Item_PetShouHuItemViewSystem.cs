using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetShouHuItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetShouHuItem))]
    public static partial class Scroll_Item_PetShouHuItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetShouHuItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetShouHuItem self)
        {
            self.DestroyWidget();
        }

        public static void SetButtonShouHuHandler(this Scroll_Item_PetShouHuItem self, Action<long> action)
        {
            self.ButtonShouHuHandler = action;
        }

        public static void OnInitUI(this Scroll_Item_PetShouHuItem self, RolePetInfo rolePetInfo)
        {
            List<long> shouhulist = self.Root().GetComponent<PetComponentC>().PetShouHuList;
            self.RolePetInfo = rolePetInfo;

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Img_PetHeroIonImage.sprite = sp;

            self.E_Lab_PetNameText.text = rolePetInfo.PetName;

            self.EG_Node_1RectTransform.gameObject.SetActive(shouhulist.Contains(rolePetInfo.Id));
            self.EG_Node_2RectTransform.gameObject.SetActive(!shouhulist.Contains(rolePetInfo.Id));

            using (zstring.Block())
            {
                self.E_Lab_PinFenText.text = zstring.Format("评分: {0}", rolePetInfo.PetPingFen);
            }

            if (PetHelper.IsShenShou(rolePetInfo.ConfigId))
            {
                self.E_Lab_ShouHuText.text = "神兽守护";
            }
            else
            {
                self.E_Lab_ShouHuText.text = ConfigData.PetShouHuAttri[rolePetInfo.ShouHuPos - 1].Value;
            }

            using (zstring.Block())
            {
                string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, zstring.Format("ShouHu_{0}", rolePetInfo.ShouHuPos - 1));
                Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);
                self.E_Img_ShouHuIconImage.sprite = sp2;
            }

            self.E_ButtonShouHuButton.AddListener(() => { self.ButtonShouHuHandler(self.RolePetInfo.Id); });
        }
    }
}