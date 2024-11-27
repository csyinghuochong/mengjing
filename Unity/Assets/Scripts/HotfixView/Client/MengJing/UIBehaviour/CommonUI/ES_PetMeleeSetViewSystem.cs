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

            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_PetMeleeSet self)
        {
            self.DestroyWidget();
        }

        private static async ETTask OnPlanSet(this ES_PetMeleeSet self, int index)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();

            if (petComponentC.PetFightPlan != index)
            {
            }

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
    }
}