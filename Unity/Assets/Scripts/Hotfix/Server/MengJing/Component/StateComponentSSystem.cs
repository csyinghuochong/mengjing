namespace ET.Server
{

    [EntitySystemOf(typeof(StateComponentS))]
    [FriendOf(typeof(StateComponentS))]
    public static partial class StateComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.StateComponentS self)
        {
            self.CurrentStateType = StateTypeEnum.None;
            self.RigidityEndTime = 0;
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.StateComponentS self)
        {
            self.CurrentStateType = StateTypeEnum.None;
            self.RigidityEndTime = 0;
            self.ObstructStatus = 0;
        }

        public static bool IsCanZhuiJi(this StateComponentS self)
        {
            if (ErrorCode.ERR_Success!=self.CanMove())
            {
                return false;
            }
            if (self.StateTypeGet(StateTypeEnum.Singing))
            {
                return false;
            }
            return true;
        }


        public static void Reset(this StateComponentS self)
        {
            self.CurrentStateType = StateTypeEnum.None;
        }

        public static void SetRigidityEndTime(this StateComponentS self, long addTime)
        {
            self.RigidityEndTime = addTime;
        }

        public static bool IsRigidity(this StateComponentS self)
        {
            return TimeHelper.ClientNow() < self.RigidityEndTime;
        }

        public static void SetNetWaitEndTime(this StateComponentS self, long addTime)
        {
            self.NetWaitEndTime = addTime;
        }

        public static bool IsNetWaitEndTime(this StateComponentS self)
        {
            return TimeHelper.ClientNow() < self.NetWaitEndTime;
        }

        public static int CanUseSkill(this StateComponentS self, SkillConfig skillConfig, bool checkDead)
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
            
            if (self.StateTypeGet(StateTypeEnum.Silence))
            {
                if (skillConfig.Id != 60000011 && skillConfig.SkillActType != 0)
                {
                    return ErrorCode.ERR_CanNotUseSkill_Silence;
                }
            }

            Unit unit = self.GetParent<Unit>();
            if (checkDead && unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) == 1)
            {
                return ErrorCode.ERR_CanNotSkillDead;
            }
            if (unit.Type == UnitType.Monster && self.StateTypeGet(StateTypeEnum.Singing))
            {
                return ErrorCode.ERR_CanNotMove_Singing;
            }
            return ErrorCode.ERR_Success;
        }

        public static int ServerCanMove(this StateComponentS self)
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

        public static int CanMove(this StateComponentS self)
        {
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

            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
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
        /// ����ĳ��״̬
        /// </summary>
        /// <param name="nowStateType"></param>
        public static void StateTypeAdd(this StateComponentS self, long nowStateType, string stateValue = "0")
        {
            Unit unit = self.GetParent<Unit>();
            self.CurrentStateType = self.CurrentStateType | nowStateType;

            //ѣ��״ֹ̬ͣ��ǰ�ƶ�(����������)
            if (ErrorCode.ERR_Success != self.CanMove())
            {
                unit.Stop(0);        //ֹͣ��ǰ�ƶ�
              
            }
            if (nowStateType == StateTypeEnum.Dizziness)
            {
                //unit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.Dizziness_13);
            }
            if (nowStateType == StateTypeEnum.BaTi)
            {
                ///unit.GetComponent<BuffManagerComponent>().OnRemoveBuffByState(StateTypeEnum.Dizziness);
            }
            //unit.GetComponent<SkillManagerComponent>().InterruptSing(0, true);
            //unit.GetComponent<SkillPassiveComponent>().StateTypeAdd(nowStateType);
            ////���͸ı����Ե������Ϣ
            //if (self.IsBroadcastType(nowStateType))
            //{
            //    MessageHelper.Broadcast(self.GetParent<Unit>(), new M2C_UnitStateUpdate() { UnitId = self.Parent.Id, StateType = (long)nowStateType, StateValue = stateValue, StateOperateType = 1, StateTime = 0 });
            //}
            //else
            //{
            //    if (unit.Type == UnitType.Player)
            //    {
            //        MessageHelper.SendToClient(self.GetParent<Unit>(), new M2C_UnitStateUpdate() { UnitId = self.Parent.Id, StateType = (long)nowStateType, StateValue = stateValue, StateOperateType = 1, StateTime = 0 });
            //    }
            //}

            EventSystem.Instance.Publish( self.Scene(), new StateTypeAdd() { UnitDefend = unit, nowStateType = nowStateType }  );
        }

        public static bool IsBroadcastType(this StateComponentS self, long nowStateType)
        {
            return nowStateType == StateTypeEnum.Singing
                || nowStateType == StateTypeEnum.OpenBox
                || nowStateType == StateTypeEnum.Stealth
                || nowStateType == StateTypeEnum.Hide
                || nowStateType == StateTypeEnum.BaTi;
        }

        /// <summary>
        /// �Ƴ�ĳ��״̬
        /// </summary>
        /// <param name="nowStateType"></param>
        public static void StateTypeRemove(this StateComponentS self, long nowStateType)
        {
            self.CurrentStateType = self.CurrentStateType & ~nowStateType;


            //���͸ı����Ե������Ϣ
            Unit unit = self.GetParent<Unit>();
            if (unit == null || unit.IsDisposed)
                return;
            //unit.GetComponent<SkillManagerComponent>().InterruptSing(0, true);
            //unit.GetComponent<SkillPassiveComponent>().StateTypeAdd(nowStateType);
            ////���͸ı����Ե������Ϣ
            //if (self.IsBroadcastType(nowStateType))
            //{
            //    MessageHelper.Broadcast(self.GetParent<Unit>(), new M2C_UnitStateUpdate() { UnitId = self.Parent.Id, StateType = (long)nowStateType, StateValue = stateValue, StateOperateType = 1, StateTime = 0 });
            //}
            //else
            //{
            //    if (unit.Type == UnitType.Player)
            //    {
            //        MessageHelper.SendToClient(self.GetParent<Unit>(), new M2C_UnitStateUpdate() { UnitId = self.Parent.Id, StateType = (long)nowStateType, StateValue = stateValue, StateOperateType = 1, StateTime = 0 });
            //    }
            //}
        }

        /// <summary>
        /// ��ȡĳ��״̬�Ƿ����
        /// </summary>
        /// <param name="nowStateType"></param>
        public static bool StateTypeGet(this StateComponentS self, long nowStateType)
        {
            long state = (self.CurrentStateType & nowStateType);
            //Log.Debug("nowStateTypes = " + nowStateTypes + " state = " + state);
            // 0 ��ʾû��״̬   ����0��ʾ��״̬
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
        /// ��ȡ��ǰ״̬
        /// </summary>
        /// <returns></returns>
        public static long GetNowStateType(this StateComponentS self)
        {
            return self.CurrentStateType;
        }

        public static bool SkillBuffStateContrast(this StateComponentS self, int buffStateType, long stateType)
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


    }
}