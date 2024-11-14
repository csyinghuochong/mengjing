using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetBarSet))]
    [FriendOfAttribute(typeof(ES_PetBarSet))]
    public static partial class ES_PetBarSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetBarSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_PlanSetToggleGroup.AddListener(self.OnPlanSet);
            self.E_PetTypeSetToggleGroup.AddListener(self.OnPetTypeSet);
            self.E_ConfirmButton.AddListenerAsync(self.OnConfirm);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarSet self)
        {
            self.DestroyWidget();
        }

        private static void OnPlanSet(this ES_PetBarSet self, int index)
        {
        }

        private static void OnPetTypeSet(this ES_PetBarSet self, int index)
        {
        }

        private static async ETTask OnConfirm(this ES_PetBarSet self)
        {
            await ETTask.CompletedTask;
        }
    }
}