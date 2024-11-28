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
            self.MainPetItem.SetActive(false);
            self.AssistPetItem = self.EG_AssistPetListRectTransform.GetChild(0).gameObject;
            self.AssistPetItem.SetActive(false);
            self.SkillItem = self.EG_SkillListRectTransform.GetChild(0).gameObject;
            self.SkillItem.SetActive(false);

            self.E_PlanSetToggleGroup.OnSelectIndex(self.Root().GetComponent<PetComponentC>().PetMeleePlan);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetMeleeSet self)
        {
            self.DestroyWidget();
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
                FlyTipComponent.Instance.ShowFlyTip("设置成功！");
            }
        }
    }
}