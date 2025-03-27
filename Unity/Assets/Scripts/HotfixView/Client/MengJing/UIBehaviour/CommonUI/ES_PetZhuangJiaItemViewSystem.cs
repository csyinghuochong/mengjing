using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetZhuangJiaItem))]
    [FriendOfAttribute(typeof(ES_PetZhuangJiaItem))]
    public static partial class ES_PetZhuangJiaItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetZhuangJiaItem self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ImageIconButton.AddListener(() => { self.ClickHandler(self.Position); });
        }

        [EntitySystem]
        private static void Destroy(this ES_PetZhuangJiaItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_PetZhuangJiaItem self, int position)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            PetZhuangJiaConfig petZhuangJiaConfig = PetZhuangJiaConfigCategory.Instance.Get(petComponentC.PetZhuangJiaList[position]);

            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIconImage.gameObject, petZhuangJiaConfig.Lv == 0);
            self.E_NameText.text = petZhuangJiaConfig.Name;
            using (zstring.Block())
            {
                self.E_LvText.text = zstring.Format("{0}级", petZhuangJiaConfig.Lv);
            }
        }
    }
}