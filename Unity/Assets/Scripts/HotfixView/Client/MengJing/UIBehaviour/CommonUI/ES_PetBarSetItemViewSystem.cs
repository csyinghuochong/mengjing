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
            
            self.E_HighlightImage.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarSetItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInit(this ES_PetBarSetItem self, PetBarInfo petBarInfo)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            RolePetInfo rolePetInfo = petComponentC.GetPetInfoByID(petBarInfo.PetId);
            if (rolePetInfo != null)
            {
                PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.E_PetBarSetIconImage.gameObject.SetActive(true);
                self.E_LockImage.gameObject.SetActive(false);
                self.E_PetBarSetIconImage.sprite = sp;
                using (zstring.Block())
                {
                    self.E_LvText.text = zstring.Format("等级:{0}", rolePetInfo.PetLv);
                }
            }
            else
            {
                self.E_PetBarSetIconImage.gameObject.SetActive(false);
                self.E_LockImage.gameObject.SetActive(true);
                self.E_LvText.text = "等级:0";
            }

            int appearSkill = petBarInfo.AppearSkill;
            if (appearSkill != 0)
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(appearSkill);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.E_AppearSkillButton.transform.Find("mask/Icon").gameObject.SetActive(true);
                self.E_AppearSkillButton.transform.Find("mask/Icon").GetComponent<Image>().sprite = sp;
            }
            else
            {
                self.E_AppearSkillButton.transform.Find("mask/Icon").gameObject.SetActive(false);
                self.E_AppearSkillButton.transform.Find("mask/Icon").GetComponent<Image>().sprite = null;
            }

            int activeSkill = petBarInfo.ActiveSkill.Count > 0 ? petBarInfo.ActiveSkill[0] : 0;
            if (activeSkill != 0)
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(activeSkill);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.E_ActiveSkill_0Button.transform.Find("mask/Icon").gameObject.SetActive(true);
                self.E_ActiveSkill_0Button.transform.Find("mask/Icon").GetComponent<Image>().sprite = sp;
            }
            else
            {
                self.E_ActiveSkill_0Button.transform.Find("mask/Icon").gameObject.SetActive(false);
                self.E_ActiveSkill_0Button.transform.Find("mask/Icon").GetComponent<Image>().sprite = null;
            }
        }
    }
}