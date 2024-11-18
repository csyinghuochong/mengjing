using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetBarSetItem))]
    [FriendOfAttribute(typeof(ES_PetBarSetItem))]
    public static partial class ES_PetBarSetItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetBarSetItem self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarSetItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInit(this ES_PetBarSetItem self, int petBarIndex)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            PetBarInfo petBarInfo = petComponentC.PetFightList[petBarIndex];
            RolePetInfo rolePetInfo = petComponentC.GetPetInfoByID(petBarInfo.PetId);
            if (rolePetInfo != null)
            {
                PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.E_PetlIconImage.sprite = sp;
                self.E_LvText.text = zstring.Format("等级:{0}", rolePetInfo.PetLv);
            }
            else
            {
                self.E_PetlIconImage.sprite = null;
                self.E_LvText.text = "等级:0";
            }
        }
    }
}