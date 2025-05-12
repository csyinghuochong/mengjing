using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_FangunSkill))]
    [FriendOfAttribute(typeof (ES_FangunSkill))]
    public static partial class ES_FangunSkillSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FangunSkill self, Transform transform)
        {
            self.uiTransform = transform;

            self.uiTransform.GetComponent<Button>().AddListener(self.OnUseFangunSkill);
            self.SkillId = GlobalValueConfigCategory.Instance.FangunSkillId;
        }

        [EntitySystem]
        private static void Destroy(this ES_FangunSkill self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdate(this ES_FangunSkill self, long leftTime)
        {
            if (leftTime > 0)
            {
                float proValue = (float)leftTime / 10000f;
                self.E_Img_SkillCDImage.fillAmount = proValue;
            }
            else
            {
                self.E_Img_SkillCDImage.fillAmount = 0f;
            }
        }

        public static void OnUseFangunSkill(this ES_FangunSkill self)
        {
            if (Time.time - self.LastSkillTime < 0.4f)
                return;

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int skillID = unit.GetComponent<SkillManagerComponentC>().FangunSkillId;

            EventSystem.Instance.Publish(self.Root(), new BeforeSkill());

            Quaternion quaternion = unit.Rotation;
            unit.GetComponent<SkillManagerComponentC>().SendUseSkill(skillID, 0, Mathf.FloorToInt(quaternion.eulerAngles.y), 0, 0).Coroutine();

            self.LastSkillTime = Time.time;
        }
    }
}
