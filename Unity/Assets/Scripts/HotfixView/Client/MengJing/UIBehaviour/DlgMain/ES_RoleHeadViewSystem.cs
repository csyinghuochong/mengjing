using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_RoleHead))]
    [FriendOfAttribute(typeof(ES_RoleHead))]
    public static partial class ES_RoleHeadSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleHead self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImagePetHeadIconButton.AddListener(self.OnImagePetHeadIconButton);

            self.E_SetButton.AddListener(self.OnSetButton);

            self.UserInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            self.E_PlayerHeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, self.UserInfoComponent.UserInfo.Occ.ToString()));

            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            string serverName = playerInfoComponent.ServerItem.ServerName;
            self.E_ServerNameText.text = serverName;

            self.InitShow();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleHead self)
        {
            self.DestroyWidget();
        }

        public static void OnEnterScene(this ES_RoleHead self, int sceneTypeEnum)
        {
            self.OnPetFightSet();
        }

        public static void OnUpdateCombat(this ES_RoleHead self)
        {
            long combat = self.UserInfoComponent.UserInfo.Combat;
            using (zstring.Block())
            {
                self.E_CombatText.text = zstring.Format("战力: {0}", combat);
            }
        }

        public static void OnImagePetHeadIconButton(this ES_RoleHead self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetQuickFight).Coroutine();
        }

        public static void OnSetButton(this ES_RoleHead self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Setting).Coroutine();
        }

        public static void InitShow(this ES_RoleHead self)
        {
            self.UpdateShowRoleName();
            self.UpdateShowRoleExp();
            self.UpdateShowRolePiLao();
            self.OnPetFightSet();
            self.OnUpdateCombat();
            self.UpdateShowRoleHuoLi();
        }

        public static void OnPetFightSet(this ES_RoleHead self)
        {
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetFightPet();
            self.EG_PetIconSetRectTransform.gameObject.SetActive(false);
            if (rolePetInfo == null)
            {
                return;
            }

            //宠物头像显示
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImagePetHeadIconImage.sprite = sp;
            self.E_Lab_PetNameText.text = rolePetInfo.PetName;
            Unit pet = self.Root().CurrentScene().GetComponent<UnitComponent>().Get(rolePetInfo.Id);
            using (zstring.Block())
            {
                self.E_Lab_PetLvText.text = zstring.Format("{0}:{1}", LanguageComponent.Instance.LoadLocalization("等级"), rolePetInfo.PetLv);
            }

            self.OnUpdatePetHP(pet);
        }

        //角色名称更新
        public static void UpdateShowRoleName(this ES_RoleHead self)
        {
            self.E_RoleNameText.text = self.UserInfoComponent.UserInfo.Name;
        }

        //角色经验更新
        public static void UpdateShowRoleExp(this ES_RoleHead self)
        {
            self.E_RoleLvText.text = self.UserInfoComponent.UserInfo.Lv.ToString();
        }

        //角色疲劳更新
        public static void UpdateShowRolePiLao(this ES_RoleHead self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int maxPiLao = unit.GetMaxPiLao();
            using (zstring.Block())
            {
                self.E_RolePiLaoText.text = zstring.Format("{0}{1}/{2}", LanguageComponent.Instance.LoadLocalization("体力:"),
                    self.UserInfoComponent.UserInfo.PiLao, maxPiLao);
            }

            self.E_RolePiLaoImgImage.fillAmount = 1f * self.UserInfoComponent.UserInfo.PiLao / maxPiLao;
        }

        //更新活力
        public static void UpdateShowRoleHuoLi(this ES_RoleHead self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int skillNumber = 1 + numericComponent.GetAsInt(NumericType.MakeType_2) > 0 ? 1 : 0;
            int maxPiLao = unit.GetMaxHuoLi(skillNumber);

            using (zstring.Block())
            {
                self.E_RoleHuoLiText.text = zstring.Format("{0}{1}/{2}", LanguageComponent.Instance.LoadLocalization("活力:"),
                    self.UserInfoComponent.UserInfo.Vitality, maxPiLao);
            }

            self.E_RoleHuoLiImgImage.fillAmount = 1f * self.UserInfoComponent.UserInfo.Vitality / maxPiLao;
        }

        //初始化界面基础信息
        public static void OnUpdatePetHP(this ES_RoleHead self, Unit pet)
        {
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetFightPet();
            if (pet == null || rolePetInfo == null || pet.Id != rolePetInfo.Id)
            {
                return;
            }

            NumericComponentC numericComponent = pet.GetComponent<NumericComponentC>();
            float curhp = numericComponent.GetAsLong(NumericType.Now_Hp);
            float blood = curhp / numericComponent.GetAsLong(NumericType.Now_MaxHp);
            blood = Mathf.Max(blood, 0f);
            self.E_Img_PetHpImage.fillAmount = blood;
        }
    }
}