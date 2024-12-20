using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_AttackGrid))]
    [FriendOfAttribute(typeof (ES_AttackGrid))]
    public static partial class ES_AttackGridSystem
    {
        [EntitySystem]
        private static void Awake(this ES_AttackGrid self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_SkillStartEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown(pdata as PointerEventData); });
            self.E_Btn_SkillStartEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.OnEndDrag(pdata as PointerEventData); });
            self.E_Btn_SkillStartEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(pdata as PointerEventData); });
        }

        [EntitySystem]
        private static void Destroy(this ES_AttackGrid self)
        {
            self.DestroyWidget();
        }

        public static void OnEndDrag(this ES_AttackGrid self, PointerEventData pdata)
        {
            self.EG_FightEffectRectTransform.gameObject.SetActive(false);

            self.Root().GetComponent<SkillIndicatorComponent>().RecoveryEffect();
        }

        public static void PointerUp(this ES_AttackGrid self, PointerEventData pdata)
        {
            self.StopAction();
            self.EG_FightEffectRectTransform.gameObject.SetActive(false);
            Scene root = self.Root();
            root.GetComponent<SkillIndicatorComponent>().RecoveryEffect();
            Unit unit = self.GetParent<ES_MainSkill>().MainUnit;
            if (unit == null)
            {
                return;
            }

            LockTargetComponent lockTargetComponent = root.GetComponent<LockTargetComponent>();
            long targetId = lockTargetComponent.LockTargetUnit();
            Unit targetUnit = unit.GetParent<UnitComponent>().Get(targetId);
            AttackComponent attackComponent = self.Root().GetComponent<AttackComponent>();
            if (targetUnit == null)
            {
                attackComponent.MoveAttackId = 0;
                attackComponent.AutoAttack_1(unit, null);
            }
            else
            {
                attackComponent.BeginAutoAttack(targetUnit.Id);
            }
        }

        public static async ETTask ShowFightEffect(this ES_AttackGrid self)
        {
            self.EG_FightEffectRectTransform.gameObject.SetActive(true);
            if (!self.InitEffect)
            {
                self.InitEffect = true;
                GameObject prefab = await self.Root().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetAsync<GameObject>(ABPathHelper.GetEffetPath("UIFightHintEffect"));
                GameObject effect = UnityEngine.Object.Instantiate(prefab);
                effect.GetComponent<UISizeFangDa>().Obj_Img = self.E_Btn_SkillStartButton.gameObject;
                CommonViewHelper.SetParent(effect, self.EG_FightEffectRectTransform.gameObject);
            }
            else
            {
                if (self.EG_FightEffectRectTransform.childCount > 0)
                {
                    GameObject effect = self.EG_FightEffectRectTransform.GetChild(0).gameObject;
                    effect.SetActive(false);
                    effect.SetActive(true);
                }
            }
        }

        public static void PointerDown(this ES_AttackGrid self, PointerEventData pdata)
        {
            self.ShowFightEffect().Coroutine();
            self.Root().GetComponent<SkillIndicatorComponent>().ShowCommonAttackZhishi();
        }

        public static void StopAction(this ES_AttackGrid self)
        {
            self.Root().GetComponent<AttackComponent>().RemoveTimer();
        }
    }
}
