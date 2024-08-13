using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_UnionXiuLianItem))]
    [FriendOfAttribute(typeof(ES_UnionXiuLianItem))]
    public static partial class ES_UnionXiuLianItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionXiuLianItem self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImageIconButton.AddListener(() => { self.ClickHandler(self.Position); });
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionXiuLianItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_UnionXiuLianItem self, int postion, int type)
        {
            int numerType = ET.UnionHelper.GetXiuLianId(postion, type);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int xiulianid = numericComponent.GetAsInt(numerType);
            UnionQiangHuaConfig unionQiangHuaConfig = UnionQiangHuaConfigCategory.Instance.Get(xiulianid);
            self.E_Text_Tip_1Text.text = unionQiangHuaConfig.EquipSpaceName;
        }
    }
}
