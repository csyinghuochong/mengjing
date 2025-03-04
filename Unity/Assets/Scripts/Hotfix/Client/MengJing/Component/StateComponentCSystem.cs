namespace ET.Client
{
    [EntitySystemOf(typeof(StateComponentC))]
    [FriendOf(typeof(StateComponentC))]
    public static partial class StateComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this StateComponentC self)
        {
            self.CurrentStateType = StateTypeEnum.None;
            self.RigidityEndTime = 0;
        }

        public static void Reset(this StateComponentC self)
        {
            self.CurrentStateType = StateTypeEnum.None;
        }

        public static void SetRigidityEndTime(this StateComponentC self, long addTime)
        {
            self.RigidityEndTime = addTime;
        }

        public static bool IsRigidity(this StateComponentC self)
        {
            return TimeHelper.ClientNow() < self.RigidityEndTime;
        }
        
        public static bool IsCanBeAttack(this StateComponentC self)
        {
            if (self.StateTypeGet(StateTypeEnum.Hide))
            {
                return false;
            }
            return true;
        }

        public static void SetNetWaitEndTime(this StateComponentC self, long addTime)
        {
            self.NetWaitEndTime = addTime;
        }

        public static bool IsNetWaitEndTime(this StateComponentC self)
        {
            return TimeHelper.ClientNow() < self.NetWaitEndTime;
        }

        public static int CanUseSkill(this StateComponentC self, SkillConfig skillConfig, bool checkDead)
        {
            if (self.StateTypeGet(StateTypeEnum.BePulled))
            {
                return ErrorCode.ERR_CanNotMove_1;
            }

            if (self.IsNetWaitEndTime())
            {
                return ErrorCode.ERR_CanNotUseSkill_NetWait;
            }

            if (self.StateTypeGet(StateTypeEnum.Dizziness))
            {
                if (skillConfig.OpenType == 0)
                {
                    return ErrorCode.ERR_CanNotUseSkill_Dizziness;
                }
            }

            if (self.StateTypeGet(StateTypeEnum.JiTui))
            {
                return ErrorCode.ERR_CanNotUseSkill_JiTui;
            }

            if (self.StateTypeGet(StateTypeEnum.Sleep))
            {
                return ErrorCode.ERR_CanNotUseSkill_Sleep;
            }

            if (self.StateTypeGet(StateTypeEnum.Hung))
            {
                return ErrorCode.ERR_CanNotUseSkill_Hung;
            }

            //沉默后可以普通攻击和前冲
            if (self.StateTypeGet(StateTypeEnum.Silence))
            {
                if (skillConfig.Id != 60000011 && skillConfig.SkillActType != 0)
                {
                    return ErrorCode.ERR_CanNotUseSkill_Silence;
                }
            }

            Unit unit = self.GetParent<Unit>();
            if (checkDead && unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.Now_Dead) == 1)
            {
                return ErrorCode.ERR_CanNotSkillDead;
            }

            if (unit.Type == UnitType.Monster && self.StateTypeGet(StateTypeEnum.Singing))
            {
                return ErrorCode.ERR_CanNotMove_Singing;
            }

            return ErrorCode.ERR_Success;
        }

        public static int ServerCanMove(this StateComponentC self)
        {
            int canMove = self.CanMove();
            if (canMove == ErrorCode.ERR_Success)
            {
                return canMove;
            }

            if (self.StateTypeGet(StateTypeEnum.BePulled) || self.StateTypeGet(StateTypeEnum.JiTui))
            {
                return ErrorCode.ERR_Success;
            }

            return canMove;
        }

        public static int CanMove(this StateComponentC self)
        {
            if (self.StateTypeGet(StateTypeEnum.Transfer))
            {
                return ErrorCode.ERR_CanNotMove_1;
            }
            if (self.StateTypeGet(StateTypeEnum.BePulled))
            {
                return ErrorCode.ERR_CanNotMove_1;
            }

            if (self.StateTypeGet(StateTypeEnum.NoMove))
            {
                return ErrorCode.ERR_CanNotMove_1;
            }

            if (self.IsNetWaitEndTime())
            {
                return ErrorCode.ERR_CanNotMove_NetWait;
            }

            if (self.IsRigidity())
            {
                return ErrorCode.ERR_CanNotMove_Rigidity;
            }

            if (self.StateTypeGet(StateTypeEnum.Dizziness))
            {
                return ErrorCode.ERR_CanNotMove_Dizziness;
            }

            if (self.StateTypeGet(StateTypeEnum.JiTui))
            {
                return ErrorCode.ERR_CanNotMove_JiTui;
            }

            if (self.StateTypeGet(StateTypeEnum.Shackle))
            {
                return ErrorCode.ERR_CanNotMove_Shackle;
            }

            if (self.StateTypeGet(StateTypeEnum.Sleep))
            {
                return ErrorCode.ERR_CanNotMove_Sleep;
            }

            if (self.StateTypeGet(StateTypeEnum.Fear))
            {
                return ErrorCode.ERR_CanNotMove_Fear;
            }

            Unit unit = self.GetParent<Unit>();
            if (unit.Type == UnitType.Monster && self.StateTypeGet(StateTypeEnum.Singing))
            {
                return ErrorCode.ERR_CanNotMove_Singing;
            }

            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            if (numericComponent.GetAsInt(NumericType.Now_Speed) <= 0)
            {
                return ErrorCode.ERR_CanNotMove_Speed;
            }

            if (numericComponent.GetAsInt(NumericType.Now_Dead) == 1)
            {
                return ErrorCode.ERR_CanNotMove_Dead;
            }

            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 增加某个状态
        /// </summary>
        /// <param name="nowStateType"></param>
        public static void StateTypeAdd(this StateComponentC self, long nowStateType, string stateValue = "0")
        {
            Unit unit = self.GetParent<Unit>();
            self.CurrentStateType = self.CurrentStateType | nowStateType;

            if (unit.MainHero)
            {
                if (ErrorCode.ERR_Success != self.CanMove())
                {
                    self.SilenceCheckTime = TimeHelper.ServerNow();
                }

                if (nowStateType == StateTypeEnum.Dizziness || nowStateType == StateTypeEnum.Shackle)
                {
                    //self.Root().GetComponent<AttackComponent>().RemoveTimer();
                }
                //unit.GetComponent<SingingComponent>().StateTypeAdd(nowStateType);
            }
        }

        public static bool IsBroadcastType(this StateComponentC self, long nowStateType)
        {
            return nowStateType == StateTypeEnum.Singing
                    || nowStateType == StateTypeEnum.OpenBox
                    || nowStateType == StateTypeEnum.Stealth
                    || nowStateType == StateTypeEnum.Hide
                    || nowStateType == StateTypeEnum.BaTi;
        }

        /// <summary>
        /// 移除某个状态
        /// </summary>
        /// <param name="nowStateType"></param>
        public static void StateTypeRemove(this StateComponentC self, long nowStateType)
        {
            self.CurrentStateType = self.CurrentStateType & ~nowStateType;

            Unit unit = self.GetParent<Unit>();
            if (unit.MainHero && self.CanMove() == ErrorCode.ERR_Success)
            {
                self.SilenceCheckTime = 0;
            }
        }

        /// <summary>
        /// 获取某个状态是否存在
        /// </summary>
        /// <param name="nowStateType"></param>
        public static bool StateTypeGet(this StateComponentC self, long nowStateType)
        {
            long state = (self.CurrentStateType & nowStateType);
            //Log.Debug("nowStateTypes = " + nowStateTypes + " state = " + state);
            // 0 表示没有状态   大于0表示有状态
            if (state > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取当前状态
        /// </summary>
        /// <returns></returns>
        public static long GetNowStateType(this StateComponentC self)
        {
            return self.CurrentStateType;
        }

        public static bool SkillBuffStateContrast(this StateComponentC self, int buffStateType, long stateType)
        {
            if (1 << buffStateType == stateType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CheckSilence(this StateComponentC self)
        {
            if (self.SilenceCheckTime == 0)
            {
                return;
            }

            if (self.SilenceCheckTime < TimeHelper.ServerNow() - 5000)
            {
                self.SilenceCheckTime = 0;
                self.StateTypeRemove(StateTypeEnum.Dizziness);
                self.StateTypeRemove(StateTypeEnum.Silence);
                self.StateTypeRemove(StateTypeEnum.Shackle);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zoneScene"></param>
        /// <param name="operatype">1新增  2移除</param>
        /// <param name="stateType"></param>
        /// <param name="stateValue"></param>
        public static void SendUpdateState(this StateComponentC self, int operatype, long stateType, string stateValue)
        {
            if (self.c2M_UnitStateUpdate == null)
            {
                self.c2M_UnitStateUpdate = C2M_UnitStateUpdate.Create();
            }

            C2M_UnitStateUpdate c2M_UnitStateUpdate = self.c2M_UnitStateUpdate;
            c2M_UnitStateUpdate.StateOperateType = operatype;
            c2M_UnitStateUpdate.StateType = stateType;
            c2M_UnitStateUpdate.StateValue = stateValue;
            self.Root().GetComponent<ClientSenderCompnent>().Send(c2M_UnitStateUpdate);
        }
    }
}