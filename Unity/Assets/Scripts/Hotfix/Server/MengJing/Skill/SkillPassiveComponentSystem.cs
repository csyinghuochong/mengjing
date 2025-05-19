using ET.Client;
using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(SkillPassiveComponent))]
    [FriendOf(typeof(SkillPassiveComponent))]
    [FriendOf(typeof(SkillSetComponentS))]
    public static partial class SkillPassiveComponentSystem
    {
        [Invoke(TimerInvokeType.SkillPassive)]
        public class SkillPassiveTimer : ATimer<SkillPassiveComponent>
        {
            protected override void Run(SkillPassiveComponent self)
            {
                try
                {
                    self.Check();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [Invoke(TimerInvokeType.MonsterSingingTimer)]
        public class MonsterSingingTimer : ATimer<SkillPassiveComponent>
        {
            protected override void Run(SkillPassiveComponent self)
            {
                try
                {
                    self.OnSingOver();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this SkillPassiveComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SkillPassiveComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void Stop(this SkillPassiveComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void Reset(this SkillPassiveComponent self)
        {
            for (int i = 0; i < self.SkillPassiveInfos.Count; i++)
            {
                self.SkillPassiveInfos[i].Reset();
            }
        }

        public static void Begin(this SkillPassiveComponent self)
        {
            Unit unit = self.GetParent<Unit>();

            //缓存值
            self.UnitType = unit.Type;
            StateComponentS StateComponent = unit.GetComponent<StateComponentS>();
            NumericComponentS NumericComponent = unit.GetComponent<NumericComponentS>();

            if (NumericComponent.GetAsInt(NumericType.Now_Dead) != 0)
            {
                return;
            }

            if (unit.Type == UnitType.Player)
            {
                if (unit.SceneType == MapTypeEnum.RunRace || unit.SceneType == MapTypeEnum.Demon)
                {
                    return;
                }

                int equipId = NumericComponent.GetAsInt(NumericType.Now_Weapon);
                self.OnTrigegerPassiveSkill(SkillPassiveTypeEnum.WandBuff_8, equipId);
                self.OnTrigegerPassiveSkill(SkillPassiveTypeEnum.EquipIndex_15);
            }

            bool xueliangcheck = false;
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            if (unit.Type == UnitType.Player || unit.Type == UnitType.Pet)
            {
                xueliangcheck = true;
            }
            else if (unit.Type == UnitType.Monster)
            {
                for (int i = 0; i < self.SkillPassiveInfos.Count; i++)
                {
                    if (self.SkillPassiveInfos[i].SkillPassiveTypeEnum.Contains(SkillPassiveTypeEnum.XueLiang_2))
                    {
                        xueliangcheck = true;
                        break;
                    }
                }
            }

            if (xueliangcheck)
            {
                self.Stop();
                self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.SkillPassive, self);
            }
        }

        public static void CheckHuiXue(this SkillPassiveComponent self)
        {
            self.HuixueTimeNum = self.HuixueTimeNum + 1;
            //5秒触发一次回血
            if (self.HuixueTimeNum >= 5)
            {
                self.HuixueTimeNum = 0;
            }
            else
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            if (unit == null)
            {
                Log.Info("Unit is null");
            }
            
            NumericComponentS NumericComponent = unit.GetComponent<NumericComponentS>();
            if (NumericComponent == null)
            {
                Log.Info("NumericComponent is null");
            }

            //只有玩家和宠物有回血
            if (self.UnitType == UnitType.Pet)
            {
                long maxHp = NumericComponent.GetAsLong(NumericType.Now_MaxHp);

                //满血不触发回血
                if (NumericComponent.GetAsLong((int)NumericType.Now_Hp) >= maxHp)
                    return;

                long addHpValue = 0;
                float now_SecHpAddPro = NumericComponent.GetAsFloat(NumericType.Now_SecHpAddPro);
                if (now_SecHpAddPro > 0f)
                {
                    addHpValue = (long)(maxHp * now_SecHpAddPro);
                }

                addHpValue += (long)(maxHp * 0.05f);

                //每5秒恢复5%生命
                NumericComponent.ApplyValue(NumericType.Now_Hp, addHpValue, true);
            }

            if (self.UnitType == UnitType.Player)
            {
                long maxHp = NumericComponent.GetAsLong(NumericType.Now_MaxHp);

                //满血不触发回血
                if (NumericComponent.GetAsLong((int)NumericType.Now_Hp) >= maxHp)
                    return;

                long addHpValue = 0;
                float now_SecHpAddPro = NumericComponent.GetAsFloat(NumericType.Now_SecHpAddPro);
                if (now_SecHpAddPro > 0f)
                {
                    addHpValue = (long)(maxHp * now_SecHpAddPro);
                }

                long now_HuiXue = NumericComponent.GetAsLong(NumericType.Now_HuiXue);
                if (now_HuiXue > 0f)
                {
                    addHpValue = now_HuiXue * 5;
                }

                if (addHpValue > 0)
                {
                    NumericComponent.ApplyChange(NumericType.Now_Hp, addHpValue, true);
                }
            }
        }

        public static void Check(this SkillPassiveComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            self.CheckHuiXue();
            self.OnTrigegerPassiveSkill(SkillPassiveTypeEnum.XueLiang_2, unit.Id);
            self.OnTrigegerPassiveSkill(SkillPassiveTypeEnum.IdleStill_14, unit.Id);
            if (unit.Type == UnitType.Player && unit.ConfigId == 3)
            {
                NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
                int nowMp = numericComponent.GetAsInt(NumericType.SkillUseMP);
                int maxMp = numericComponent.GetAsInt(NumericType.Max_SkillUseMP);
                float addMp = numericComponent.GetAsFloat(NumericType.Max_SkillUseMPAdd);
                int equipIndex = numericComponent.GetAsInt(NumericType.EquipIndex);
                //equipIndex 0弓   1剑
                int huifuspeed = equipIndex == 0 ? 1 : 2;  
                
                //再加上恢复速度加速
                huifuspeed = (int)(10 * huifuspeed * (1 + addMp));
                
                nowMp = nowMp + huifuspeed;

                if (nowMp > maxMp)
                {
                    nowMp = maxMp;
                }

                numericComponent.ApplyValue(NumericType.SkillUseMP, nowMp);
            }
        }

        public static void AddPassiveSkill(this SkillPassiveComponent self, int skillId)
        {
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            self.AddPassiveSkillByType(skillConfig);
        }

        public static void RemovePassiveSkill(this SkillPassiveComponent self, int skillId)
        {
            for (int i = self.SkillPassiveInfos.Count - 1; i >= 0; i--)
            {
                if (self.SkillPassiveInfos[i].SkillId != skillId)
                {
                    continue;
                }

                self.SkillPassiveInfos.RemoveAt(i);
                break;
            }
        }

        /// <summary>
        /// 更新角色被动技能
        /// </summary>
        /// <param name="self"></param>
        public static void UpdatePassiveSkill(this SkillPassiveComponent self)
        {
            self.SkillPassiveInfos.Clear();

            List<SkillPro> skillList = self.GetParent<Unit>().GetComponent<SkillSetComponentS>().SkillList;
            for (int i = 0; i < skillList.Count; i++)
            {
                if (skillList[i].SkillSetType == (int)SkillSetEnum.Item)
                {
                    continue;
                }

                if (!SkillConfigCategory.Instance.Contain(skillList[i].SkillID))
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillList[i].SkillID);
                self.AddPassiveSkillByType(skillConfig);
            }
        }

        /// <summary>
        /// 更新怪物被动技能
        /// </summary>
        /// <param name="self"></param>
        public static void UpdateMonsterPassiveSkill(this SkillPassiveComponent self)
        {
            self.SkillPassiveInfos.Clear();
            int configId = self.GetParent<Unit>().ConfigId;
            MonsterConfig MonsterCof = MonsterConfigCategory.Instance.Get(configId);
            int[] aiSkillIDList = MonsterCof.SkillID;
            if (aiSkillIDList == null)
            {
                return;
            }

            for (int i = 0; i < aiSkillIDList.Length; i++)
            {
                if (aiSkillIDList[i] == 0)
                {
                    continue;
                }

                if (!SkillConfigCategory.Instance.Contain(aiSkillIDList[i]))
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(aiSkillIDList[i]);
                self.AddPassiveSkillByType(skillConfig);
            }
        }

        public static void UpdatePastureSkill(this SkillPassiveComponent self)
        {
        }

        public static void UpdateJingLingSkill(this SkillPassiveComponent self, int jinglingid)
        {
            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(jinglingid);
            if (jingLingConfig.FunctionType != JingLingFunctionType.AddSkill)
            {
                return;
            }

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(int.Parse(jingLingConfig.FunctionValue));
            self.AddPassiveSkillByType(skillConfig);
        }

        public static bool HaveSkillId(this SkillPassiveComponent self, int skillId)
        {
            for (int i = 0; i < self.SkillPassiveInfos.Count; i++)
            {
                if (self.SkillPassiveInfos[i].SkillId == skillId)
                {
                    return true;
                }
            }

            return false;
        }

        public static void UpdatePetPassiveSkill(this SkillPassiveComponent self, RolePetInfo rolePetInfo)
        {
            self.SkillPassiveInfos.Clear();
            int configId = self.GetParent<Unit>().ConfigId;
            PetConfig MonsterCof = PetConfigCategory.Instance.Get(configId);
            List<int> zhuanzhuids = new List<int>();
            string[] zhuanzhuskills = MonsterCof.ZhuanZhuSkillID.Split(';');
            for (int i = 0; i < zhuanzhuskills.Length; i++)
            {
                if (zhuanzhuskills[i].Length > 1)
                {
                    zhuanzhuids.Add(int.Parse(zhuanzhuskills[i]));
                }
            }

            for (int i = 0; i < zhuanzhuids.Count; i++)
            {
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(zhuanzhuids[i]);
                self.AddPassiveSkillByType(skillConfig);
            }

            string[] baseSkillID = MonsterCof.BaseSkillID.Split(';');
            for (int i = 0; i < baseSkillID.Length; i++)
            {
                int baseSkillId = int.Parse(baseSkillID[i]);
                if (baseSkillId == 0)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(baseSkillId);
                self.AddPassiveSkillByType(skillConfig);
            }

            for (int i = 0; i < rolePetInfo.PetSkill.Count; i++)
            {
                int baseSkillId = rolePetInfo.PetSkill[i];
                if (baseSkillId == 0)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(baseSkillId);
                self.AddPassiveSkillByType(skillConfig);
            }
        }

        public static void AddPassiveSkillByType(this SkillPassiveComponent self, SkillConfig skillConfig)
        {
            if (skillConfig.SkillType == 1 || SkillHelp.havePassiveSkillType(skillConfig.PassiveSkillType, 0))
            {
                return;
            }

            for (int i = 0; i < self.SkillPassiveInfos.Count; i++)
            {
                if (self.SkillPassiveInfos[i].SkillId == skillConfig.Id)
                {
                    return;
                }
            }

            List<int> PassiveSkillType = new List<int>();
            List<float> PassiveSkillPro = new List<float> { };
            for (int i = 0; i < skillConfig.PassiveSkillType.Length; i++)
            {
                PassiveSkillType.Add(skillConfig.PassiveSkillType[i]);
                PassiveSkillPro.Add((float)skillConfig.PassiveSkillPro[i]);
            }

            SkillPassiveInfo skillPassiveInfo = new SkillPassiveInfo(skillConfig.Id, PassiveSkillType,
                PassiveSkillPro, skillConfig.PassiveSkillTriggerOnce, skillConfig.SkillCD);
            self.SkillPassiveInfos.Add(skillPassiveInfo);
        }

        public static void BeginSingSkill(this SkillPassiveComponent self, SkillPassiveInfo skillIfo, long targetId = 0)
        {
            self.SingSkillIfo = skillIfo;
            self.SingTargetId = targetId;
            self.Root().GetComponent<TimerComponent>().Remove(ref self.SingTimer);

            Unit unit = self.GetParent<Unit>();
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillIfo.SkillId);
            int angle = 0; // (int)Quaternion.QuaternionToEuler(unit.Rotation).y;
            StateComponentS StateComponent = unit.GetComponent<StateComponentS>();
            StateComponent.StateTypeAdd(StateTypeEnum.Singing, $"{skillIfo.SkillId}_{angle}");
            self.SingTimer = self.Root().GetComponent<TimerComponent>()
                    .NewOnceTimer(TimeHelper.ServerNow() + (long)(skillConfig.SkillFrontSingTime * 1000), TimerInvokeType.MonsterSingingTimer, self);
        }

        public static void OnSingOver(this SkillPassiveComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            StateComponentS StateComponent = unit.GetComponent<StateComponentS>();
            StateComponent.StateTypeRemove(StateTypeEnum.Singing);
            if (self.SingSkillIfo != null)
            {
                self.ImmediateUseSkill(self.SingSkillIfo, self.SingTargetId);
            }
        }

        public static void StateTypeAdd(this SkillPassiveComponent self, long nowStateType)
        {
            Unit unit = self.GetParent<Unit>();
            StateComponentS StateComponent = unit.GetComponent<StateComponentS>();
            if (self.SingTimer > 0 && (nowStateType == StateTypeEnum.Silence || nowStateType == StateTypeEnum.Dizziness))
            {
                self.Root().GetComponent<TimerComponent>().Remove(ref self.SingTimer);
                StateComponent.StateTypeRemove(StateTypeEnum.Singing);
            }
        }

        public static void ImmediateUseSkill(this SkillPassiveComponent self, SkillPassiveInfo skillIfo, long targetId = 0)
        {
            if (self.InstanceId == 0)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            List<long> targetIdList = new List<long>();
            AIComponent aIComponent = unit.GetComponent<AIComponent>();
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillIfo.SkillId);
            if (aIComponent != null)
            {
                targetId = aIComponent.TargetID;
                Unit aiTarget = unit.GetParent<UnitComponent>().Get(targetId);
                if (aiTarget != null && skillConfig.SkillTargetType == (int)SkillTargetType.TargetOnly
                    && PositionHelper.Distance2D(unit.Position, aiTarget.Position) > aIComponent.ActDistance)
                {
                    return;
                }

                if (skillConfig.SkillTargetTypeNum == 0)
                {
                    targetIdList.Add(targetId);
                }
                else
                {
                    List<long> enemyids = GetTargetHelpS.GetNearestEnemyIds(unit, (float)aIComponent.ActRange, skillConfig.SkillTargetTypeNum);
                    if ((skillConfig.SkillTargetTypeNum == 2 || skillConfig.SkillTargetTypeNum == 3) && enemyids.Count > 0)
                    {
                        aIComponent.ChangeTarget(enemyids[0]);
                    }

                    targetIdList.AddRange(enemyids);
                }
            }

            if (targetIdList.Count == 0)
            {
                targetId = targetId > 0 ? targetId : self.GetParent<Unit>().Id;
                targetIdList.Add(targetId);
            }

            int targetAngle = (int)MathHelper.QuaternionToEulerAngle_Y(unit.Rotation);
            Unit target = unit.GetParent<UnitComponent>().Get(targetId);
            if (target != null && target.Id != targetId)
            {
                float3 dir = target.Position - unit.Position;
                targetAngle =  (int)math.degrees( math.degrees(math.atan2(dir.x, dir.z)));
            }

            SkillManagerComponentS skillManagerComponent = unit.GetComponent<SkillManagerComponentS>();
            for (int i = 0; i < targetIdList.Count; i++)
            {
                C2M_SkillCmd cmd = self.C2M_SkillCmd;
                cmd.TargetAngle = targetAngle;

                if (unit.Type == UnitType.Monster)
                {
                    cmd.SkillID = skillIfo.SkillId;
                }
                else
                {
                    cmd.SkillID = skillIfo.SkillId;
                }

                cmd.TargetID = targetIdList[i];
                skillManagerComponent.OnUseSkill(cmd, false);
            }

            long serverTime = TimeHelper.ServerNow();
            long rigidityEndTime = (long)(skillConfig.SkillRigidity * 1000) + serverTime;
            if (unit.IsDisposed)
            {
                Log.Debug("SkillPassiveComponent :unit.IsDisposed ");
                return;
            }

            unit.GetComponent<StateComponentS>().SetRigidityEndTime(rigidityEndTime);
        }

        public static void OnPlayerMove(this SkillPassiveComponent self)
        {
            for (int i = 0; i < self.SkillPassiveInfos.Count; i++)
            {
                if (self.SkillPassiveInfos[i].SkillPassiveTypeEnum.Contains(SkillPassiveTypeEnum.IdleStill_14))
                {
                    self.SkillPassiveInfos[i].LastTriggerTime = TimeHelper.ServerNow();
                }
            }
        }

        public static void OnTrigegerPassiveSkill(this SkillPassiveComponent self, int skillPassiveTypeEnum, long targetId = 0, int skillid = 0)
        {
            Unit unit = self.GetParent<Unit>();

            if (unit.Type == UnitType.Player)
            {
                ChengJiuComponentS chengJiuComponent = unit.GetComponent<ChengJiuComponentS>();
                if (chengJiuComponent.JingLingUnitId != 0 && unit.GetParent<UnitComponent>().Get(chengJiuComponent.JingLingUnitId) != null)
                {
                    Unit jingling = unit.GetParent<UnitComponent>().Get(chengJiuComponent.JingLingUnitId);
                    jingling.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(skillPassiveTypeEnum, targetId, skillid);
                }
            }

            using ListComponent<SkillPassiveInfo> skillPassiveInfos = ListComponent<SkillPassiveInfo>.Create();
            for (int i = 0; i < self.SkillPassiveInfos.Count; i++)
            {
                if (!self.SkillPassiveInfos[i].SkillPassiveTypeEnum.Contains(skillPassiveTypeEnum))
                {
                    continue;
                }

                if (self.SkillPassiveInfos[i].SkillPassiveTypeEnum.Contains(SkillPassiveTypeEnum.AckNumber_16))
                {
                    self.SkillPassiveInfos[i].TriggerNumber++;
                }

                skillPassiveInfos.Add(self.SkillPassiveInfos[i]);
            }

            if (skillPassiveInfos.Count == 0)
            {
                return;
            }

            long serverTime = TimeHelper.ServerNow();

            for (int s = 0; s < skillPassiveInfos.Count; s++)
            {
                SkillPassiveInfo skillIfo = skillPassiveInfos[s];

                float skillproValue = skillIfo.SkillPro[skillIfo.SkillPassiveTypeEnum.IndexOf(skillPassiveTypeEnum)];
                if (skillPassiveTypeEnum == SkillPassiveTypeEnum.WandBuff_8)
                {
                    int weapontype = Convert.ToInt32(skillproValue);
                    int buffId = SkillConfigCategory.Instance.Get(skillIfo.SkillId).InitBuffID[0];
                    int weaponType = targetId == 0 ? ItemEquipType.Common : (int)ItemConfigCategory.Instance.Get((int)targetId).EquipType;
                    if (weaponType != weapontype)
                    {
                        unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, buffId);
                    }

                    if (weaponType == weapontype && buffId != 0)
                    {
                        BuffData buffData_1 = new BuffData();
                        buffData_1.SkillId = skillIfo.SkillId;
                        buffData_1.BuffId = buffId;
                        unit.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_1, unit, null);
                    }

                    continue;
                }

                //只触发一次
                if (skillIfo.LastTriggerTime > 0 && skillIfo.TriggerOnce == 1)
                {
                    continue;
                }

                //触发限制
                if (skillIfo.TriggerInterval > 0 && serverTime - skillIfo.LastTriggerTime < skillIfo.TriggerInterval)
                {
                    continue;
                }

                bool trigger = false;

                switch (skillPassiveTypeEnum)
                {
                    case SkillPassiveTypeEnum.AckGaiLv_1:
                        trigger = skillproValue >= RandomHelper.RandFloat01();
                        break;
                    case SkillPassiveTypeEnum.XueLiang_2:
                        NumericComponentS numCom = unit.GetComponent<NumericComponentS>();
                        if (unit.Type == UnitType.JingLing)
                        {
                            Unit master = unit.GetParent<UnitComponent>().Get(unit.GetMasterId());
                            numCom = (master != null && !master.IsDisposed) ? master.GetComponent<NumericComponentS>() : numCom;
                        }

                        long nowHp = numCom.GetAsLong((int)NumericType.Now_Hp);
                        long maxHp = numCom.GetAsLong((int)NumericType.Now_MaxHp);
                        float hpPro = (float)nowHp / (float)maxHp;
                        trigger = hpPro <= skillproValue;
                        break;
                    case SkillPassiveTypeEnum.BeHurt_3:
                    case SkillPassiveTypeEnum.Critical_4:
                    case SkillPassiveTypeEnum.ShanBi_5:
                    case SkillPassiveTypeEnum.WillDead_6:
                    case SkillPassiveTypeEnum.SkillGaiLv_7:
                    case SkillPassiveTypeEnum.AckDistance_9:
                    case SkillPassiveTypeEnum.AckDistance_10:
                    case SkillPassiveTypeEnum.IdleStill_14:
                    case SkillPassiveTypeEnum.EquipIndex_15:
                    case SkillPassiveTypeEnum.AllSkill_17:
                    case SkillPassiveTypeEnum.AckCritical_19:
                    case SkillPassiveTypeEnum.FanGunCD_20:
                        trigger = skillproValue >= RandomHelper.RandFloat01();
                        break;
                    case SkillPassiveTypeEnum.TeamerEnter_12:
                        trigger = true;
                        break;
                    case SkillPassiveTypeEnum.AckNumber_16:
                        trigger = skillIfo.TriggerNumber >= skillproValue;
                        if (trigger)
                        {
                            skillIfo.TriggerNumber = 0;
                        }

                        break;
                }

                if (!trigger)
                {
                    continue;
                }

                if (skillid == skillIfo.SkillId)
                {
                    Log.Debug($"SkillPassiveComponent: {skillIfo.SkillId}");
                    continue;
                }

                SkillManagerComponentS skillManagerComponent = unit.GetComponent<SkillManagerComponentS>();
                if (skillManagerComponent.IsCanUseSkill(skillIfo.SkillId, false, skillPassiveTypeEnum != SkillPassiveTypeEnum.WillDead_6) !=
                    ErrorCode.ERR_Success)
                {
                    continue;
                }

                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillIfo.SkillId);
                if (skillConfig.SkillFrontSingTime > 0f)
                {
                    self.BeginSingSkill(skillIfo, targetId);
                }
                else
                {
                    self.ImmediateUseSkill(skillIfo, targetId);
                }

                skillIfo.LastTriggerTime = serverTime;
            }
        }
    }
}