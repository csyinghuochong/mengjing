using Unity.Mathematics;

namespace ET.Client
{
    [EntitySystemOf(typeof (SkillC))]
    [FriendOf(typeof (SkillC))]
    public static partial class SkillCSystem
    {
        [EntitySystem]
        private static void Awake(this SkillC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SkillC self)
        {
           //do nothing
        }

        //技能基础设置
        public static void BaseOnInit(this SkillC self, SkillInfo skillcmd, Unit theUnitFrom, Unit theUnitBelongto = null)
        {
            self.SkillInfo = skillcmd;
            self.SkillConf = SkillConfigCategory.Instance.Get(skillcmd.WeaponSkillID);
            int effctId = self.SkillConf.SkillEffectID[0];
            if (effctId != 0)
            {
                EffectConfig effectConfig = EffectConfigCategory.Instance.Get(effctId);
                self.SkillExcuteHurtTime = (long)(1000 * effectConfig.SkillEffectDelayTime) + skillcmd.SkillBeginTime;
                self.IsExcuteHurt = true;
            }
            else
            {
                self.SkillExcuteHurtTime = skillcmd.SkillBeginTime;
                self.IsExcuteHurt = false;
            }

            if (self.SkillConf.ShakeCameraType != 0)
            {
                self.SkillShakeCameraTime = (long)(1000 * self.SkillConf.ShakeStart) + skillcmd.SkillBeginTime;
                self.IsCanShakeCamera = true;
            }
            else
            {
                self.SkillShakeCameraTime = skillcmd.SkillBeginTime;
                self.IsCanShakeCamera = false;
            }

            self.EffectId = effctId;
            self.TheUnitFrom = theUnitFrom;
            self.SkillState = SkillState.Running;

            self.TargetPosition = new float3(skillcmd.PosX, skillcmd.PosY, skillcmd.PosZ);
            self.EffectInstanceId.Clear();
        }

        //技能update
        public static void BaseOnUpdate(this SkillC self)
        {
            long serverNow = TimeHelper.ServerNow();

            if (self.IsExcuteHurt && serverNow >= self.SkillExcuteHurtTime)
            {
                self.IsExcuteHurt = false;
                string music = self.SkillConf.SkillMusic;
                if (!string.IsNullOrEmpty(music) && music != "0" && self.TheUnitFrom.MainHero)
                {
                    EventSystem.Instance.Publish(self.Root(), new SkillSound() { Asset ="Skill/" + music  } );
                }
            }

            if (self.IsCanShakeCamera && serverNow >= self.SkillShakeCameraTime)
            {
                self.IsCanShakeCamera = false;
                EventSystem.Instance.Publish(self.Root(),
                    new ShakeCamera() { ShakeCameraType = self.SkillConf.ShakeCameraType, ShakeDuration = (float)self.SkillConf.ShakeDuration });
            }

            if (serverNow >= self.SkillInfo.SkillEndTime)
            {
                self.SetSkillState(SkillState.Finished);
            }
        }

        //设置技能状态
        public static void SetSkillState(this SkillC self, SkillState state)
        {
            self.SkillState = state;
        }

        //判断技能是否结束
        public static bool IsSkillFinied(this SkillC self)
        {
            return self.SkillState == SkillState.Finished;
        }
        //技能指示器
        public static void OnShowSkillIndicator(this SkillC self, SkillInfo skillcmd)
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

            if ((unit.Type == UnitType.Monster && skillConfig.SkillDelayTime > 0f)
                || (unit.Type == UnitType.Player && skillConfig.SkillDelayTime > 1f))
            {
                EventSystem.Instance.Publish(self.Root(),  new SkillYuJing()
                {
                    Unit = unit,
                    SkillInfo =  skillcmd,
                    SkillConfig =  skillConfig
                });
            }
        }

        //播放技能特效
        public static void PlaySkillEffects(this SkillC self, float3 effectPostion, float effectAngle = 0f)
        {
            //Debug.Log("PlaySkillEffects = " + self.EffectConf.Id);
            //特效为空直接返回
            if (self.EffectId == 0)
            {
                return;
            }

            if (StringBuilderData.NoEffectSkills.Contains(self.SkillConf.GameObjectName))
            {
                return;
            }

            EffectData playEffectBuffData = new EffectData();
            playEffectBuffData.TargetID = self.SkillInfo.TargetID;
            playEffectBuffData.EffectId = self.EffectId; //特效相关配置
            playEffectBuffData.EffectPosition = effectPostion; //技能目标点
            playEffectBuffData.EffectAngle = effectAngle;
            playEffectBuffData.TargetAngle = self.SkillInfo.TargetAngle; //技能角度
            playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect; //特效类型
            playEffectBuffData.InstanceId = IdGenerater.Instance.GenerateInstanceId();
            self.EffectInstanceId.Add(playEffectBuffData.InstanceId);
            EventSystem.Instance.Publish(self.Root(), new SkillEffect()
            {
                EffectData =  playEffectBuffData,
                Unit = self.TheUnitFrom
            });
        }

        //结束播放技能特效
        public static void EndSkillEffect(this SkillC self)
        {
            if (self.Scene() == null)
            {
                return;
            }

            for (int i = 0; i < self.EffectInstanceId.Count; i++)
            {
                EventSystem.Instance.Publish( self.Root(), new SkillEffectFinish
                {
                    EffectInstanceId = self.EffectInstanceId[i],
                    Unit =  self.TheUnitFrom
                });
            }
        }

        //播放受击特效
        public static void PlayHitEffect(this SkillC self, Unit unit)
        {
            EffectData playEffectBuffData = new EffectData();
            EffectConfig hitSkillConfig = EffectConfigCategory.Instance.Get(self.SkillConf.SkillHitEffectID);
            playEffectBuffData.EffectId = hitSkillConfig.Id; //特效相关配置
            playEffectBuffData.EffectPosition = float3.zero;
            playEffectBuffData.TargetAngle = 0;
            playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect;
            
            EventSystem.Instance.Publish(self.Root(), new SkillEffect()
            {
                EffectData =  playEffectBuffData,
                Unit =  unit
            });
        }

    }
}