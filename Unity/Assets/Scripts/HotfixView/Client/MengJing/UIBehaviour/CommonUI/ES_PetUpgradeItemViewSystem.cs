using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetUpgradeItem))]
    [FriendOfAttribute(typeof(ES_PetUpgradeItem))]
    public static partial class ES_PetUpgradeItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetUpgradeItem self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_PetUpgradeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInit(this ES_PetUpgradeItem self, int petBarConfigId)
        {
            PetBarConfig petBarConfig = PetBarConfigCategory.Instance.Get(petBarConfigId);
            self.E_PetBarNameText.text = petBarConfig.Name;
            self.E_PetBarLvText.text = string.Format("等级:{0}", petBarConfig.Level);
        }
    }
}