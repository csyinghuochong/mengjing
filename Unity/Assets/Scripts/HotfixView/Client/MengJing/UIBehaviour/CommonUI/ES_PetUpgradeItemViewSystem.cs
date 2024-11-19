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
            using (zstring.Block())
            {
                self.E_PetBarLvText.text = zstring.Format("等级:{0}", petBarConfig.Level);
            }
        }
    }
}