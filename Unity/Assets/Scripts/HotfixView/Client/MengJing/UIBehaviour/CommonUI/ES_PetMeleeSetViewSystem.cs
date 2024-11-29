using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetMeleeSet))]
    [FriendOfAttribute(typeof(ES_PetMeleeSet))]
    public static partial class ES_PetMeleeSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetMeleeSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_PlanSetToggleGroup.AddListener((index) => { self.OnPlanSet(index).Coroutine(); });

            self.E_SetMainButton.AddListener(self.OnSetMain);
            self.E_SetAssistButton.AddListener(self.OnSetAssist);
            self.E_SetSkillButton.AddListener(self.OnSetSkill);

            self.MainPetItem = self.EG_MainPetListRectTransform.GetChild(0).gameObject;
            self.AssistPetItem = self.EG_AssistPetListRectTransform.GetChild(0).gameObject;
            self.SkillItem = self.EG_SkillListRectTransform.GetChild(0).gameObject;
            self.InitItemList();

            self.E_PlanSetToggleGroup.OnSelectIndex(self.Root().GetComponent<PetComponentC>().PetMeleePlan);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetMeleeSet self)
        {
            self.DestroyWidget();
        }

        private static void InitItemList(this ES_PetMeleeSet self)
        {
            self.MainPetItemList.Add(self.MainPetItem);
            for (int i = 1; i < 6; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.MainPetItem, self.MainPetItem.transform.parent);
                self.MainPetItemList.Add(go);
            }

            self.AssistPetItemList.Add(self.AssistPetItem);
            for (int i = 1; i < 12; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.AssistPetItem, self.AssistPetItem.transform.parent);
                self.AssistPetItemList.Add(go);
            }

            self.SkillItemList.Add(self.SkillItem);
            for (int i = 1; i < 6; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.SkillItem, self.SkillItem.transform.parent);
                self.SkillItemList.Add(go);
            }
        }

        private static void RefreshItemList(this ES_PetMeleeSet self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            for (int i = 0; i < 6; i++)
            {
                Sprite sprite = null;
                if (i < self.PetMeleeInfo.MainPetList.Count)
                {
                    long petId = self.PetMeleeInfo.MainPetList[i];
                    RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(petId);
                    PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
                    sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                }

                GameObject go = self.MainPetItemList[i];
                go.transform.Find("Mask/Icon").GetComponent<Image>().sprite = sprite;
            }

            for (int i = 0; i < 12; i++)
            {
                GameObject go = self.AssistPetItemList[i];
                if (i < self.PetMeleeInfo.AssistPetList.Count)
                {
                    int petTuJianConfigId = self.PetMeleeInfo.AssistPetList[i];
                    PetTuJianConfig petTuJianConfig = PetTuJianConfigCategory.Instance.Get(petTuJianConfigId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petTuJianConfig.Icon.ToString());
                    Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    go.transform.Find("mask/Icon").gameObject.SetActive(true);
                    go.transform.Find("mask/Icon").GetComponent<Image>().sprite = sprite;
                }
                else
                {
                    go.transform.Find("mask/Icon").gameObject.SetActive(false);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                GameObject go = self.SkillItemList[i];
                if (i < self.PetMeleeInfo.SkillList.Count)
                {
                    int skillConfigId = self.PetMeleeInfo.SkillList[i];
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillConfigId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                    Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    go.transform.Find("mask/Icon").gameObject.SetActive(true);
                    go.transform.Find("mask/Icon").GetComponent<Image>().sprite = sprite;
                }
                else
                {
                    go.transform.Find("mask/Icon").gameObject.SetActive(false);
                }
            }
        }

        private static async ETTask OnPlanSet(this ES_PetMeleeSet self, int index)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();

            if (petComponentC.PetMeleePlan != index)
            {
                int error = await PetNetHelper.RequestPetMeleePlan(self.Root(), index);

                if (error == ErrorCode.ERR_Success)
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("宠物乱斗切换 {0}", index));
                    }
                }
            }

            // 复制一份
            if (self.PetMeleeInfo == null)
            {
                self.PetMeleeInfo = PetMeleeInfo.Create();
            }

            self.PetMeleeInfo.MainPetList.Clear();
            self.PetMeleeInfo.AssistPetList.Clear();
            self.PetMeleeInfo.SkillList.Clear();

            PetMeleeInfo petMeleeInfo = petComponentC.PetMeleeInfoList[petComponentC.PetMeleePlan];
            self.PetMeleeInfo.MainPetList.AddRange(petMeleeInfo.MainPetList);
            self.PetMeleeInfo.AssistPetList.AddRange(petMeleeInfo.AssistPetList);
            self.PetMeleeInfo.SkillList.AddRange(petMeleeInfo.SkillList);

            self.RefreshItemList();

            await ETTask.CompletedTask;
        }

        private static void OnSetMain(this ES_PetMeleeSet self)
        {
        }

        private static void OnSetAssist(this ES_PetMeleeSet self)
        {
        }

        private static void OnSetSkill(this ES_PetMeleeSet self)
        {
        }

        private static async ETTask OnConfirm(this ES_PetMeleeSet self)
        {
            int error = await PetNetHelper.RequestPetMeleeSet(self.Root(), self.PetMeleeInfo);
            if (error == ErrorCode.ERR_Success)
            {
                self.RefreshItemList();
                FlyTipComponent.Instance.ShowFlyTip("设置成功！");
            }
        }
    }
}