using Unity.Mathematics;
using System;

namespace ET.Client
{
    [EntitySystemOf(typeof (SingingComponent))]
    [FriendOf(typeof (SingingComponent))]
    public static partial class SingingComponentSystem
    {
        
          
        [Invoke(TimerInvokeType.PlayerSingingTimer)]
        public class PlayerSingingTimer: ATimer<SingingComponent>
        {
            protected override void Run(SingingComponent self)
            {
                try
                {
                    self.OnTimer();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
        
        [EntitySystem]
        private static void Awake(this SingingComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SingingComponent self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        public static void OnTimer(this SingingComponent self)
        {
            self.PassTime = TimeHelper.ServerNow() - self.BeginTime;
            self.UpdateUISinging();
        }

        public static void UpdateUISinging(this SingingComponent self)
        {
            EventSystem.Instance.Publish(self.Root(), new SingingUpdate()
            {
                Type = self.Type,
                PassTime = self.PassTime,
                TotalTime = self.TotalTime
            });

            if (self.Type == 1 && self.PassTime < 0)
            {
                //打断吟唱前
                StateComponentC stateComponent = self.GetParent<Unit>().GetComponent<StateComponentC>();
                stateComponent.SendUpdateState(2, StateTypeEnum.Singing, "0_0");
            }

            if (self.Type == 1 && self.PassTime > self.TotalTime)
            {
                //吟唱前结束，释放技能
                self.PassTime = -1;
                self.TotalTime = -1;
                Unit unit = self.GetParent<Unit>();
                StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
                stateComponent.SendUpdateState(2, StateTypeEnum.Singing, "0_0");
                self.ImmediateUseSkill();
            }

            if (self.Type == 2 && self.PassTime > self.TotalTime)
            {
                //吟唱后结束，释放技能
                self.PassTime = -1;
                self.TotalTime = -1;
            }

            if (self.PassTime < 0)
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            }
        }

        public static void AfterSkillSing(this SingingComponent self, SkillConfig skillConfig)
        {
            if (skillConfig.ComboSkillID == 0 && skillConfig.SkillSingTime > 0f)
            {
                self.Type = 2;
                self.PassTime = 0;
                self.TotalTime = (long)(1000 * skillConfig.SkillSingTime);
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
                self.BeginTime = TimeHelper.ServerNow();
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.PlayerSingingTimer, self);
            }
        }

        //被攻击，吟唱时间倒退0.3秒
        public static void StateTypeAdd(this SingingComponent self, long nowStateType)
        {
            if (self.Type == 1 && self.Timer > 0)
            {
                bool daduan = nowStateType == StateTypeEnum.Silence || nowStateType == StateTypeEnum.Dizziness;
                self.PassTime = daduan? -1 : self.PassTime;
                self.UpdateUISinging();
            }
        }

        /// <summary>
        /// 施法中吟唱由服务器打断
        /// </summary>
        /// <param name="self"></param>
        public static void OnInterrupt(this SingingComponent self)
        {
            self.PassTime = -1;
            self.UpdateUISinging();
            HintHelp.ShowHint(self.Root(), "施法中断！");
        }

        public static void BeginMove(this SingingComponent self)
        {
            long passTime = self.PassTime;
            if (passTime <= 0)
            {
                return;
            }

            self.PassTime = -1;
            self.UpdateUISinging();

            //立即释放技能
            if (self.c2M_SkillCmd == null || self.c2M_SkillCmd.SkillID == 0)
            {
                return;
            }

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.c2M_SkillCmd.SkillID);
            if (self.c2M_SkillCmd == null || self.c2M_SkillCmd.SkillID == 0)
            {
                return;
            }

            if (skillConfig.SkillFrontSingTime > 0f && SkillHelp.havePassiveSkillType(skillConfig.PassiveSkillType, 2))
            {
                float sinValue = (float)((0.001f * passTime) / (float)skillConfig.SkillFrontSingTime);
                sinValue = math.min(sinValue, 1f);
                self.c2M_SkillCmd.SingValue = sinValue;
                self.ImmediateUseSkill();
            }
        }

        public static void PlayerXuLiEffect(this SingingComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            EffectData playEffectBuffData = new EffectData();
            playEffectBuffData.EffectId = 21202031; //特效相关配置
            playEffectBuffData.EffectPosition = unit.Position;
            playEffectBuffData.TargetAngle = 0;
            playEffectBuffData.EffectTypeEnum = EffectTypeEnum.SkillEffect;
            playEffectBuffData.InstanceId = IdGenerater.Instance.GenerateInstanceId();
            self.EffectInstanceId = playEffectBuffData.InstanceId;
            EventSystem.Instance.Publish(self.Root(), new SkillEffect()
            {
                EffectData = playEffectBuffData,
                Unit = unit
            });
        }

        //技能吟唱
        public static void BeforeSkillSing(this SingingComponent self, C2M_SkillCmd c2M_SkillCmd)
        {
            self.c2M_SkillCmd.SkillID = c2M_SkillCmd.SkillID;
            self.c2M_SkillCmd.TargetID = c2M_SkillCmd.TargetID;
            self.c2M_SkillCmd.TargetAngle = c2M_SkillCmd.TargetAngle;
            self.c2M_SkillCmd.TargetDistance = c2M_SkillCmd.TargetDistance;
            self.c2M_SkillCmd.WeaponSkillID = c2M_SkillCmd.WeaponSkillID;
            self.c2M_SkillCmd.ItemId = c2M_SkillCmd.ItemId;
            self.c2M_SkillCmd.SingValue = 1f;

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(c2M_SkillCmd.SkillID);
            self.Type = 1;
            self.PassTime = 0;
            self.TotalTime = (long)(skillConfig.SkillFrontSingTime * 1000);
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.BeginTime = TimeHelper.ServerNow();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.PlayerSingingTimer, self);

            Unit unit = self.GetParent<Unit>();
 
            self.Root().GetComponent<ClientSenderCompnent>().Send(C2M_Stop.Create());
            StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
            stateComponent.SendUpdateState(1, StateTypeEnum.Singing, $"{c2M_SkillCmd.SkillID}_0");

            if (skillConfig.SkillFrontSingTime > 0f && SkillHelp.havePassiveSkillType(skillConfig.PassiveSkillType, 2))
            {
                self.PlayerXuLiEffect();

                //镜头拉远
                EventSystem.Instance.Publish( self.Root(), new ChangeCameraMoveType()
                {
                    CameraType = 4
                });
            }
        }

        public static void BeginSkill(this SingingComponent self)
        {
            if (self.PassTime > 0)
            {
                self.PassTime = -1;
                self.UpdateUISinging();
            }

            if (self.EffectInstanceId > 0)
            {
                self.ResetEffect();
            }
        }

        public static bool IsSkillSinging(this SingingComponent self, int skillid)
        {
            Unit unit = self.GetParent<Unit>();
            if (self.c2M_SkillCmd != null && self.c2M_SkillCmd.SkillID == skillid
                && unit.GetComponent<StateComponentC>().StateTypeGet(StateTypeEnum.Singing))
            {
                return true;
            }

            return false;
        }

        public static void ResetEffect(this SingingComponent self)
        {
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.c2M_SkillCmd.SkillID);
            if (self.EffectInstanceId != 0 && skillConfig.SkillFrontSingTime > 0f && SkillHelp.havePassiveSkillType(skillConfig.PassiveSkillType, 2))
            {
                //镜头回位
                EventSystem.Instance.Publish( self.Root(), new ChangeCameraMoveType()
                {
                    CameraType = 5
                });
                
                EventSystem.Instance.Publish(self.Root(), new SkillEffectFinish()
                {
                    EffectInstanceId = self.EffectInstanceId,
                    Unit = self.GetParent<Unit>()
                });
                self.EffectInstanceId = 0;
            }
        }

        public static void ImmediateUseSkill(this SingingComponent self)
        {
            self.ResetEffect();

            if (self.Type != 1)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            unit.GetComponent<SkillManagerComponentC>().ImmediateUseSkill(self.c2M_SkillCmd).Coroutine();
        }
    }
}