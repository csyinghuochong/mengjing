using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_MainPetFight))]
    [FriendOfAttribute(typeof(ES_MainPetFight))]
    public static partial class ES_MainPetFightSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainPetFight self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ClickButton.AddListener(self.OnClick);
        }

        [EntitySystem]
        private static void Destroy(this ES_MainPetFight self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this ES_MainPetFight self, RolePetInfo rolePetInfo, int fightIndex)
        {
            if (rolePetInfo == null)
            {
                self.uiTransform.gameObject.SetActive(false);
                return;
            }

            self.uiTransform.gameObject.SetActive(true);

            self.RolePetInfo = rolePetInfo;
            self.FightIndex = fightIndex;

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_PetIconImage.sprite = sp;
            self.E_PetLvText.text = rolePetInfo.PetLv.ToString();

            Unit pet = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(rolePetInfo.Id);
            if (pet == null)
            {
                self.E_PetHPImage.fillAmount = 0;
                return;
            }
            NumericComponentC numericComponent = pet.GetComponent<NumericComponentC>();
            float curhp = numericComponent.GetAsLong(NumericType.Now_Hp);
            float blood = curhp / numericComponent.GetAsLong(NumericType.Now_MaxHp);
            self.E_PetHPImage.fillAmount = blood;
        }

        private static void OnClick(this ES_MainPetFight self)
        {
            if (self.RolePetInfo == null || !self.uiTransform.gameObject.activeSelf)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMain>()?.OnPetFightSwitch(self.FightIndex).Coroutine();
        }
    }
}