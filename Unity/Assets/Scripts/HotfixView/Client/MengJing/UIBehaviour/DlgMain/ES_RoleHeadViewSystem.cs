using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RoleHead))]
    [FriendOfAttribute(typeof (ES_RoleHead))]
    public static partial class ES_RoleHeadSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleHead self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImagePetHeadIconButton.AddListener(self.OnImagePetHeadIcon);

            self.E_SetButton.AddListener(self.OnOpenSettingUI);

            self.UserInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            self.E_PlayerHeadIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, self.UserInfoComponent.UserInfo.Occ.ToString()));

            // AccountInfoComponent accountInfoComponent = self.ZoneScene().GetComponent<AccountInfoComponent>();
            // string serverName = accountInfoComponent.ServerName;
            self.E_ServerNameText.text = "测试服";

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
            self.E_CombatText.text = $"战力: {combat}";
        }

        public static void OnImagePetHeadIcon(this ES_RoleHead self)
        {
            // UIHelper.Create(self.ZoneScene(), UIType.UIPetQuickFight).Coroutine();
        }

        public static void OnOpenSettingUI(this ES_RoleHead self)
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
            int sceneType = self.Root().GetComponent<MapComponent>().SceneType;
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetFightPet();
            self.EG_PetIconSetRectTransform.gameObject.SetActive(!GlobalHelp.IsBanHaoMode() && rolePetInfo != null &&
                sceneType != SceneTypeEnum.RunRace);
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
            self.E_Lab_PetLvText.text = GameSettingLanguge.Instance.LoadLocalization("等级") + ":" + rolePetInfo.PetLv;
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
            self.E_RoleLvText.text = GameSettingLanguge.Instance.LoadLocalization("等级") + ":" + self.UserInfoComponent.UserInfo.Lv;
        }

        //角色疲劳更新
        public static void UpdateShowRolePiLao(this ES_RoleHead self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int maxPiLao = unit.GetMaxPiLao();
            self.E_RolePiLaoText.text = GameSettingLanguge.Instance.LoadLocalization("体力:") + self.UserInfoComponent.UserInfo.PiLao + "/" + maxPiLao;
            self.E_RolePiLaoImgImage.fillAmount = 1f * self.UserInfoComponent.UserInfo.PiLao / maxPiLao;
        }

        //更新活力
        public static void UpdateShowRoleHuoLi(this ES_RoleHead self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int skillNumber = 1 + numericComponent.GetAsInt(NumericType.MakeType_2) > 0? 1 : 0;
            int maxPiLao = unit.GetMaxHuoLi(skillNumber);

            self.E_RoleHuoLiText.text = GameSettingLanguge.Instance.LoadLocalization("活力:") + self.UserInfoComponent.UserInfo.Vitality + "/" + maxPiLao;
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