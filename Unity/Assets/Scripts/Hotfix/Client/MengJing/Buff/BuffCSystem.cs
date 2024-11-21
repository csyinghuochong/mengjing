namespace ET.Client
{
    [EntitySystemOf(typeof(BuffC))]
    [FriendOf(typeof(BuffC))]
    public static partial class BuffCSystem
    {
        [EntitySystem]
        private static void Awake(this BuffC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.BuffC self)
        {
           //do nothing
        }
        
        /// <summary>
        /// 子弹和Buff做区分
        /// </summary>
        /// <param name="self"></param>
        /// <param name="buffData"></param>
        /// <param name="theUnitFrom"></param>
        /// <param name="theUnitBelongto"></param>
        public static void BaseOnBuffInit(this BuffC self, BuffData buffData, Unit theUnitBelongto)
        {
            self.PassTime = 0f;
            self.TheUnitBelongto = theUnitBelongto;
            self.BuffData = buffData;
            self.EffectInstanceId = 0;
            //获取数据
            self.mSkillConf = SkillConfigCategory.Instance.Get(buffData.SkillId);
            self.mSkillBuffConf = SkillBuffConfigCategory.Instance.Get(buffData.BuffId);
            self.mEffectConf = self.mSkillBuffConf.BuffEffectID == 0 ? null : EffectConfigCategory.Instance.Get(self.mSkillBuffConf.BuffEffectID);
            self.BuffEndTime = TimeHelper.ServerNow() + self.mSkillBuffConf.BuffTime;
            self.BuffEndTime = buffData.BuffEndTime > 0 ? buffData.BuffEndTime : self.BuffEndTime;
            self.BuffBeginTime = TimeHelper.ServerNow();
            self.StartPosition = theUnitBelongto.Position;
        }

        /// <summary>
        /// Buff持续
        /// </summary>
        public static void BaseOnUpdate(this BuffC self)
        {
            self.PassTime = (TimeHelper.ClientNow() - self.BuffBeginTime) * 0.001f;
        }

        public static void Clear(this BuffC self)
        {
            self.PassTime = 0;
            self.BuffEndTime = 0;
            self.mSkillConf = null;
            self.mEffectConf = null;
            self.mSkillBuffConf = null;
            self.TheUnitBelongto = null;
            //self.BuffState = BuffState.Waiting;
        }

        //播放特效
        public static long PlayBuffEffects(this BuffC self)
        {
            EffectData playEffectBuffData = new EffectData();
            if (self.mEffectConf == null)
            {
                return 0;
            }

            playEffectBuffData.EffectId = self.mEffectConf.Id;
            playEffectBuffData.TargetAngle = self.BuffData.TargetAngle;
            playEffectBuffData.EffectTypeEnum = EffectTypeEnum.BuffEffect;
            playEffectBuffData.InstanceId = IdGenerater.Instance.GenerateInstanceId();

            //特效类型

            EventSystem.Instance.Publish(self.Root(), new SkillEffect()
            {
                EffectData = playEffectBuffData,
                Unit = self.TheUnitBelongto
            }
            );

            self.EffectData = playEffectBuffData;
            return playEffectBuffData.InstanceId;
        }
      
    }
}