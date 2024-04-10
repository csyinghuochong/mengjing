﻿using UnityEngine;

namespace ET
{
    public static class SkillHandlerSystem
    {
        //技能基础设置
        public static void BaseOnInit(this ASkillHandler self, SkillInfo skillcmd, Unit theUnitFrom, Unit theUnitBelongto = null)
        {
            self.SkillInfo = skillcmd;
            self.SkillConf = SkillConfigCategory.Instance.Get(skillcmd.WeaponSkillID);
            int effctId = self.SkillConf.SkillEffectID[0];
            if (effctId != 0)
            {
                EffectConfig effectConfig = EffectConfigCategory.Instance.Get(effctId);
                self.SkillExcuteHurtTime = (long)(1000 * effectConfig.SkillEffectDelayTime ) + skillcmd.SkillBeginTime;
                self.IsExcuteHurt =true ;
            }
            else
            {
                self.SkillExcuteHurtTime =  skillcmd.SkillBeginTime;
                self.IsExcuteHurt = false;
            }
            self.EffectId = effctId;
            self.TheUnitFrom = theUnitFrom;
            self.SkillState = SkillState.Running;
            
            self.TargetPosition = new Vector3(skillcmd.PosX, skillcmd.PosY, skillcmd.PosZ);
            self.EffectInstanceId.Clear();
        }

        //技能update
        public static void BaseOnUpdate(this ASkillHandler self)
        {
            long serverNow = TimeHelper.ServerNow();
           
            if (self.IsExcuteHurt && serverNow >= self.SkillExcuteHurtTime)
            {
                self.IsExcuteHurt = false;
                string music = self.SkillConf.SkillMusic;
                if (!string.IsNullOrEmpty(music) && music != "0" && self.TheUnitFrom.MainHero)
                {
                    EventType.SkillSound.Instance.Asset = "Skill/" + music;
                    EventSystem.Instance.PublishClass(EventType.SkillSound.Instance);
                }
            }

            if (serverNow >= self.SkillInfo.SkillEndTime)
            {
                self.SetSkillState(SkillState.Finished);
            }
        }

        //设置技能状态
        public static void SetSkillState(this ASkillHandler self, SkillState state)
        {
            self.SkillState = state;
        }

        //判断技能是否结束
        public static bool IsSkillFinied(this ASkillHandler self)
        {
            return self.SkillState == SkillState.Finished;
        }


        //技能指示器
        public static void OnShowSkillIndicator(this ASkillHandler self, SkillInfo skillcmd)
        {
            Unit unit = self.TheUnitFrom;
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillcmd.WeaponSkillID);
            if (skillConfig.IfShowSkillZhiShi == 1) //不显示
            {
                return;
            }
            if (skillConfig.SkillZhishiType == 0 || skillConfig.SkillDelayTime == 0)
            {
                return;
            }
            if ( (unit.Type == UnitType.Monster && skillConfig.SkillDelayTime > 0f)
               || (unit.Type == UnitType.Player && skillConfig.SkillDelayTime > 1f))
            {
                EventType.SkillYuJing.Instance.Unit = unit;
                EventType.SkillYuJing.Instance.SkillInfo = skillcmd;
                EventType.SkillYuJing.Instance.SkillConfig = skillConfig;
                Game.EventSystem.PublishClass(EventType.SkillYuJing.Instance);
            }
        }

        //播放技能特效
        public static void PlaySkillEffects(this ASkillHandler self, Vector3 effectPostion, float effectAngle = 0f)
        {
            //Debug.Log("PlaySkillEffects = " + self.EffectConf.Id);
            //特效为空直接返回
            if (self.EffectId == 0)
            {
                return;
            }
            if (StringBuilderHelper.NoEffectSkills.Contains(self.SkillConf.GameObjectName))
            {
                return;
            }
            EffectData playEffectBuffData = new EffectData();
            playEffectBuffData.TargetID = self.SkillInfo.TargetID;
            playEffectBuffData.SkillId = self.SkillConf.Id;                   //技能相关配置
            playEffectBuffData.EffectId = self.EffectId;                 //特效相关配置
            playEffectBuffData.EffectPosition = effectPostion;           //技能目标点
            playEffectBuffData.EffectAngle = effectAngle;
            playEffectBuffData.TargetAngle = self.SkillInfo.TargetAngle;         //技能角度
            playEffectBuffData.EffectBeginTime = self.SkillInfo.SkillBeginTime;
            playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect;              //特效类型
            playEffectBuffData.InstanceId = IdGenerater.Instance.GenerateInstanceId();
            self.EffectInstanceId.Add(playEffectBuffData.InstanceId);

            EventType.SkillEffect.Instance.EffectData = playEffectBuffData;
            EventType.SkillEffect.Instance.Unit = self.TheUnitFrom;
            EventSystem.Instance.PublishClass(EventType.SkillEffect.Instance);
        }

        //结束播放技能特效
        public static void EndSkillEffect(this ASkillHandler self)
        {
            for (int i = 0; i < self.EffectInstanceId.Count; i++)
            {
                EventType.SkillEffectFinish.Instance.EffectInstanceId = self.EffectInstanceId[i];
                EventType.SkillEffectFinish.Instance.Unit = self.TheUnitFrom;
                EventSystem.Instance.PublishClass(EventType.SkillEffectFinish.Instance);
            }
        }

        //播放受击特效
        public static void PlayHitEffect(this ASkillHandler self, Unit unit)
        {
            EffectData playEffectBuffData = new EffectData();
            EffectConfig hitSkillConfig = EffectConfigCategory.Instance.Get(self.SkillConf.SkillHitEffectID);
            playEffectBuffData.EffectId = hitSkillConfig.Id;                  //特效相关配置
            playEffectBuffData.EffectPosition = Vector3.zero;
            playEffectBuffData.TargetAngle = 0;
            playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect;

            EventType.SkillEffect.Instance.EffectData = playEffectBuffData;
            EventType.SkillEffect.Instance.Unit = unit;
            EventSystem.Instance.PublishClass(EventType.SkillEffect.Instance);
        }
    }
}
