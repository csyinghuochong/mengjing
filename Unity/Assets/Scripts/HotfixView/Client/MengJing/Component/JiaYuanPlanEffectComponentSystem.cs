using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(JiaYuanPlanEffectComponent))]
    [EntitySystemOf(typeof(JiaYuanPlanEffectComponent))]
    public static partial class JiaYuanPlanEffectComponentSystem
    {
        [EntitySystem]
        private static void Awake(this JiaYuanPlanEffectComponent self)
        {
            self.PlanEffectPath = string.Empty;
            self.PlanEffectObj = null;

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this JiaYuanPlanEffectComponent self)
        {
            self.RecoverGameObject();
        }

        public static void OnUprootPlan(this JiaYuanPlanEffectComponent self)
        {
            self.RecoverGameObject();
        }

        public static void RecoverGameObject(this JiaYuanPlanEffectComponent self)
        {
            if (self.PlanEffectObj != null)
            {
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(self.PlanEffectPath, self.PlanEffectObj, false);
                self.PlanEffectObj = null;
            }
        }

        public static void UpdateEffect(this JiaYuanPlanEffectComponent self, int planStage)
        {
            if (planStage == 4)
            {
                return;
            }

            self.PlanEffectPath = ABPathHelper.GetEffetPath("ScenceEffect/Eff_JiaYuan_Zhong");
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue(self.PlanEffectPath, self.InstanceId, true,self.OnLoadEffect);
        }

        public static void OnLoadEffect(this JiaYuanPlanEffectComponent self, GameObject go, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.Destroy(go);
                return;
            }

            self.PlanEffectObj = go;
            CommonViewHelper.SetParent(go, GlobalComponent.Instance.Unit.gameObject);
            go.transform.localPosition = self.GetParent<Unit>().Position;
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
        }

        public static void OnInitUI(this JiaYuanPlanEffectComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int planStage = ET.JiaYuanHelper.GetPlanStage(unit.ConfigId, numericComponent.GetAsLong(NumericType.StartTime),
                numericComponent.GetAsInt(NumericType.GatherNumber));
            self.OnUpdateUI(planStage);
        }

        public static void OnUpdateUI(this JiaYuanPlanEffectComponent self, int planStage)
        {
            self.RecoverGameObject();
            self.UpdateEffect(planStage);
        }
    }
}