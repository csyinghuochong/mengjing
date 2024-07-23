using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetQuickFightItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetQuickFightItem))]
    public static partial class Scroll_Item_PetQuickFightItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetQuickFightItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetQuickFightItem self)
        {
            self.DestroyWidget();
        }

        public static void OnTimer(this Scroll_Item_PetQuickFightItem self, long cdTime)
        {
            if (cdTime <= 0)
            {
                self.E_TexTCdText.text = string.Empty;
            }
            else
            {
                int leftsecond = Mathf.FloorToInt(cdTime * 0.001f);
                using (zstring.Block())
                {
                    self.E_TexTCdText.text = zstring.Format("{0}秒", leftsecond);
                }
            }
        }

        public static void OnUpdateUI(this Scroll_Item_PetQuickFightItem self, long fightid)
        {
            self.E_TextText.GetComponent<Text>().text = fightid == self.PetId ? "休息" : "出战";
        }

        public static void OnInitUI2(this Scroll_Item_PetQuickFightItem self, RolePetInfo rolePetInfo, Action<long> handler)
        {
            self.E_TexTCdText.text = string.Empty;
            self.E_ButtonButton.AddListener(() => { self.ClickHandler(self.PetId); });
            self.E_IconButton.AddListener(() => { self.ClickHandler(self.PetId); });

            self.PetId = rolePetInfo.Id;
            self.ClickHandler = handler;

            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_IconImage.sprite = sp;
        }
    }
}