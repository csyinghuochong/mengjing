using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.YujingTimer)]
    public class YujingTimer : ATimer<SkillYujingComponent>
    {
        protected override void Run(SkillYujingComponent self)
        {
            try
            {
                self.OnUpdate();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [EntitySystemOf(typeof(SkillYujingComponent))]
    [FriendOf(typeof(SkillYujingComponent))]
    public static partial class SkillYujingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillYujingComponent self)
        {
            self.Timer = 0;
            self.mSkillConfig = null;
            self.SkillIndicatorList = new List<SkillIndicatorItem>();
        }

        [EntitySystem]
        private static void Destroy(this SkillYujingComponent self)
        {
            for (int i = self.SkillIndicatorList.Count - 1; i >= 0; i--)
            {
                SkillIndicatorItem skillIndicatorItem = self.SkillIndicatorList[i];
                self.RecoveryEffect(skillIndicatorItem);
                self.SkillIndicatorList.RemoveAt(i);
            }

            self.SkillIndicatorList = null;
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        public static string GetIndicatorPath(this SkillYujingComponent self, int skillZhishiType)
        {
            string effect = "";
            switch (skillZhishiType)
            {
                case SkillZhishiType.Position:
                    effect = "SkillZhishi/Yujing_Position";
                    break;
                case SkillZhishiType.Line:
                    effect = "SkillZhishi/Yujing_Dir";
                    break;
                case SkillZhishiType.Angle60:
                    effect = "SkillZhishi/Yujing_Area_60";
                    break;
                case SkillZhishiType.Angle120:
                    effect = "SkillZhishi/Yujing_Area_120";
                    break;
            }

            return ABPathHelper.GetEffetPath(effect);
        }

        //怪物技能预警
        public static void ShowMonsterSkillYujin(this SkillYujingComponent self, SkillInfo skillcmd, double delayTime, bool enemy)
        {
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillcmd.WeaponSkillID);
            self.mSkillConfig = skillConfig;
            SkillIndicatorItem skillIndicatorItem = new SkillIndicatorItem();
            skillIndicatorItem.SkillInfo = skillcmd;
            skillIndicatorItem.SkillZhishiType = skillConfig.SkillZhishiType;
            skillIndicatorItem.EffectPath = self.GetIndicatorPath(skillIndicatorItem.SkillZhishiType);
            skillIndicatorItem.InstanceId = IdGenerater.Instance.GenerateInstanceId();
            skillIndicatorItem.TargetAngle = skillcmd.TargetAngle;
            skillIndicatorItem.PassTime = 0;
            skillIndicatorItem.LiveTime = (float)delayTime;
            skillIndicatorItem.Enemy = enemy;
            self.SkillIndicatorList.Add(skillIndicatorItem);
            self.Root().GetComponent<GameObjectLoadComponent>().AddLoadQueue( skillIndicatorItem.EffectPath, skillIndicatorItem.InstanceId, true,self.OnLoadGameObject);
        }

        public static void OnLoadGameObject(this SkillYujingComponent self, GameObject gameObject, long formId)
        {
            if (self.IsDisposed)
            {
                GameObject.DestroyImmediate(gameObject);
                return;
            }

            SkillIndicatorItem skillIndicatorItem = null;
            for (int i = 0; i < self.SkillIndicatorList.Count; i++)
            {
                if (self.SkillIndicatorList[i].InstanceId == formId)
                {
                    skillIndicatorItem = self.SkillIndicatorList[i];
                    break;
                }
            }

            if (skillIndicatorItem == null)
            {
                GameObject.DestroyImmediate(gameObject);
                return;
            }

            SkillInfo skillcmd = skillIndicatorItem.SkillInfo;
            skillIndicatorItem.GameObject = gameObject;
            skillIndicatorItem.GameObject.transform.localScale = Vector3.one * 0.1f;

            Color colorred = new Color(255f / 255f, 71f / 255F, 0f / 255f);
            Color colorgreen = Color.green;

            GameObject Quad_1 = null;
            GameObject Quad_2 = null;

            switch (skillIndicatorItem.SkillZhishiType)
            {
                case SkillZhishiType.Position:
                    Quad_1 = gameObject.transform.Find("Skill_InnerArea/Position/Quad").gameObject;
                    Quad_2 = gameObject.transform.Find("Skill_OuterArea/Position/Quad").gameObject;

                    //Quad_1.GetComponent<MeshRenderer>().material.color = skillIndicatorItem.Enemy ? Color.red : Color.green;
                    //Quad_2.GetComponent<MeshRenderer>().material.color = skillIndicatorItem.Enemy ? Color.red : Color.green;
                    break;
                case SkillZhishiType.Line:
                    //effect = "SkillZhishi/Yujing_Dir";
                    Quad_1 = gameObject.transform.Find("Skill_Dir/scale/Quad1").gameObject;
                    Quad_2 = gameObject.transform.Find("Skill_Dir/scale/Quad2").gameObject;
                    break;
                case SkillZhishiType.Angle60:
                    //effect = "SkillZhishi/Yujing_Area_60";
                    Quad_1 = gameObject.transform.Find("Skill_Area/Position/Quad").gameObject;
                    Quad_2 = gameObject.transform.Find("Skill_Area_60/Position/scale/Quad").gameObject;
                    break;
                case SkillZhishiType.Angle120:
                    //effect = "SkillZhishi/Yujing_Area_120";
                    Quad_1 = gameObject.transform.Find("Skill_Area/Position/Quad").gameObject;
                    Quad_2 = gameObject.transform.Find("Skill_Area_120/Position/scale/Quad").gameObject;
                    break;
            }

            Quad_1.GetComponent<MeshRenderer>().material.SetColor("_TintColor", skillIndicatorItem.Enemy ? colorred : colorgreen);
            Quad_2.GetComponent<MeshRenderer>().material.SetColor("_TintColor", skillIndicatorItem.Enemy ? colorred : colorgreen);

            skillIndicatorItem.GameObject.SetActive(true);
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            CommonViewHelper.SetParent(skillIndicatorItem.GameObject, globalComponent.Unit.gameObject);
            skillIndicatorItem.GameObject.transform.position = new Vector3(skillcmd.PosX, skillcmd.PosY, skillcmd.PosZ);
            self.InitZhishiEffect(skillIndicatorItem);
            self.AddTimer();
        }

        public static void AddTimer(this SkillYujingComponent self)
        {
            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.YujingTimer, self);
            }
        }

        private static void InitZhishiEffect(this SkillYujingComponent self, SkillIndicatorItem skillIndicatorItem)
        {
            switch (skillIndicatorItem.SkillZhishiType)
            {
                case SkillZhishiType.Position:
                    skillIndicatorItem.GameObject.Get<GameObject>("Skill_OuterArea").transform.localScale =
                            Vector3.one * (float)self.mSkillConfig.DamgeRange[0] * 2f;
                    break;
                case SkillZhishiType.Line:
                    float outerRadius =
                            (float)self.mSkillConfig.SkillRangeSize * 2f; //半径 * 2                                                              
                    //skillIndicatorItem.GameObject.Get<GameObject>("Skill_Area").transform.localScale = new Vector3(outerRadius, 1f, outerRadius);
                    skillIndicatorItem.GameObject.Get<GameObject>("Skill_Dir").transform.localRotation =
                            Quaternion.Euler(0, skillIndicatorItem.TargetAngle, 0);
                    skillIndicatorItem.GameObject.Get<GameObject>("Skill_Dir").transform.localScale =
                            Vector3.one * (float)self.mSkillConfig.DamgeRange[0] * 2f;
                    break;
                case SkillZhishiType.Angle60:
                    skillIndicatorItem.GameObject.Get<GameObject>("Skill_Area_60").transform.localRotation =
                            Quaternion.Euler(0, skillIndicatorItem.TargetAngle, 0);
                    break;
                case SkillZhishiType.Angle120:
                    skillIndicatorItem.GameObject.Get<GameObject>("Skill_Area_120").transform.localRotation =
                            Quaternion.Euler(0, skillIndicatorItem.TargetAngle, 0);
                    break;
            }
        }

        public static void RecoveryEffect(this SkillYujingComponent self, SkillIndicatorItem skillIndicatorItem)
        {
            if (skillIndicatorItem.GameObject != null)
            {
                skillIndicatorItem.GameObject.SetActive(false);
                self.Root().GetComponent<GameObjectLoadComponent>().RecoverGameObject(skillIndicatorItem.EffectPath, skillIndicatorItem.GameObject);
            }

            skillIndicatorItem = null;
        }

        public static void OnUpdate(this SkillYujingComponent self)
        {
            for (int i = self.SkillIndicatorList.Count - 1; i >= 0; i--)
            {
                SkillIndicatorItem skillIndicatorItem = self.SkillIndicatorList[i];
                skillIndicatorItem.PassTime += Time.deltaTime;
                if (skillIndicatorItem.GameObject == null)
                {
                    continue;
                }

                switch (skillIndicatorItem.SkillZhishiType)
                {
                    case SkillZhishiType.Position:
                        skillIndicatorItem.GameObject.Get<GameObject>("Skill_InnerArea").transform.localScale = Vector3.one *
                                (skillIndicatorItem.PassTime / skillIndicatorItem.LiveTime) * (float)self.mSkillConfig.DamgeRange[0] * 2f;
                        break;
                    default:
                        //skillIndicatorItem.GameObject.transform.localScale = Vector3.one * (skillIndicatorItem.PassTime / skillIndicatorItem.LiveTime) * 2f;
                        break;
                }

                if (skillIndicatorItem.LiveTime != -1 && skillIndicatorItem.PassTime >= skillIndicatorItem.LiveTime)
                {
                    self.RecoveryEffect(skillIndicatorItem);
                    self.SkillIndicatorList.RemoveAt(i);
                }
            }

            if (self.SkillIndicatorList.Count == 0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }
    }
}