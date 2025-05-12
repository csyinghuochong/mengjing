using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_MainSkillFangun))]
    [FriendOfAttribute(typeof(ES_MainSkillFangun))]
    public static partial class ES_MainSkillFangunSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainSkillFangun self, Transform transform)
        {
            self.uiTransform = transform;
            
            self.SkillId = GlobalValueConfigCategory.Instance.FangunSkillId;
            transform.GetComponent<Button>().onClick.AddListener(   self.OnUseFangunSkill  );
        }
        
        [EntitySystem]
        private static void Destroy(this ES_MainSkillFangun self)
        {

        }
        
        public static void OnUpdate(this ES_MainSkillFangun self, long leftTime)
        {
            if (leftTime > 0)
            {
                int showCostTime = (int)(leftTime / 1000f) + 1;
                float proValue = (float)leftTime / 10000f;
                //self.Text_Time.text = showCostTime.ToString();
                self.E_Img_SkillCD.fillAmount = proValue;
            }
            else
            {
                //self.Text_Time.text = string.Empty;
                self.E_Img_SkillCD.fillAmount = 0f;
            }
        }

        public static void OnUseFangunSkill(this ES_MainSkillFangun self)
        {
            if (Time.time - self.LastSkillTime < 0.4f)
                return;

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Scene());
            int skillID = unit.GetComponent<SkillManagerComponentC>().FangunSkillId;
            EventSystem.Instance.Publish( self.Root(), new BeforeSkill()) ;
            unit.GetComponent<SkillManagerComponentC>().SendUseSkill(skillID, 0, Mathf.FloorToInt(MathHelper.QuaternionToEulerAngle_Y(unit.Rotation)), 0, 0).Coroutine();

            self.LastSkillTime = Time.time;
        }
    }
}
