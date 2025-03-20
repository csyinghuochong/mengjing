using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_UnionMystery_A))]
    [FriendOf(typeof(ES_UnionMystery_B))]
    [EntitySystemOf(typeof(ES_UnionMystery))]
    [FriendOfAttribute(typeof(ES_UnionMystery))]
    public static partial class ES_UnionMysterySystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionMystery self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BtnItemTypeSetToggleGroup.AddListener(self.OnFunctionSetBtn);
            self.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionMystery self)
        {
            self.DestroyWidget();
        }

        private static void OnFunctionSetBtn(this ES_UnionMystery self, int index)
        {
            CommonViewHelper.HideChildren(self.EG_SubViewNodeRectTransform);

            switch (index)
            {
                case 0:
                    self.ES_UnionMystery_A.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.ES_UnionMystery_B.uiTransform.gameObject.SetActive(true);
                    self.ES_UnionMystery_B.OnUpdateUI();
                    break;
            }
        }
    }
}