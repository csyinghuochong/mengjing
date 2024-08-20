using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    [EntitySystemOf(typeof(SkillManagerComponentC))]
    [FriendOf(typeof(SkillManagerComponentC))]
    public static partial class SkillManagerComponentCSystem
    {
        [Invoke(TimerInvokeType.SkillTimerC)]
        public class SkillTimer : ATimer<SkillManagerComponentC>
        {
            protected override void Run(SkillManagerComponentC self)
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

        [EntitySystem]
        private static void Awake(this SkillManagerComponentC self)
        {
            self.t_Skills.Clear();
            self.Skills.Clear();
            self.SkillCDs.Clear();
            self.SkillPublicCDTime = 0;
            self.FangunSkillId = int.Parse(GlobalValueConfigCategory.Instance.Get(2).Value);

            Unit unit = self.GetParent<Unit>();
            self.MainHero = unit.MainHero;
        }

        [EntitySystem]
        private static void Destroy(this SkillManagerComponentC self)
        {
            self.SkillCDs.Clear();
            self.OnFinish();
        }

        public static bool IsSkillMoveTime(this SkillManagerComponentC self)
        {
            return TimeHelper.ClientNow() < self.SkillMoveTime;
        }

        public static bool IsSkillSingTime(this SkillManagerComponentC self)
        {
            return TimeHelper.ClientNow() < self.SkillSingTime;
        }

        public static SkillCDItem GetSkillCD(this SkillManagerComponentC self, int skillId)
        {
            for (int i = 0; i < self.SkillCDs.Count; i++)
            {
                if (self.SkillCDs[i].SkillID == skillId)
                {
                    return self.SkillCDs[i];
                }
            }

            return null;
        }

        public static long GetCdTime(this SkillManagerComponentC self, int skillId, long nowTime)
        {
            SkillCDItem skillCD = self.GetSkillCD(skillId);
            if (skillCD != null)
            {
                return skillCD.CDEndTime - nowTime;
            }

            return 0;
        }

        /// <summary>
        /// 清除所有技能和Cd
        /// </summary>
        /// <param name="self"></param>
        public static void ClearSkillAndCd(this SkillManagerComponentC self)
        {
            self.SkillCDs.Clear();
            self.OnFinish();
        }

        public static void ClearSkillCD(this SkillManagerComponentC self, int skillId)
        {
            for (int i = 0; i < self.SkillCDs.Count; i++)
            {
                if (self.SkillCDs[i].SkillID == skillId)
                {
                    self.SkillCDs[i].CDEndTime = 0;
                }
            }
        }

        public static void Check(this SkillManagerComponentC self)
        {
            long nowTime = TimeHelper.ServerNow();
            int skillcdcnt = self.SkillCDs.Count;
            for (int i = skillcdcnt - 1; i >= 0; i--)
            {
                if (self.SkillCDs[i].CDEndTime < nowTime)
                {
                    self.SkillCDs.RemoveAt(i);
                }
            }

            int skillcnt = self.Skills.Count;
            for (int i = skillcnt - 1; i >= 0; i--)
            {
                SkillC skill = self.Skills[i];
                SkillHandlerC aaiHandler = SkillDispatcherComponentC.Instance.Get(skill.SkillConf.GameObjectName);
                if (skill.IsSkillFinied())
                {
                    aaiHandler.OnFinished(skill);
                    self.Skills.RemoveAt(i);
                    ObjectPool.Instance.Recycle(skill);
                    continue;
                }

                //self.Skills[i].OnUpdate();
                aaiHandler.OnUpdate(skill);
            }

            if (self.MainHero)
            {
                EventSystem.Instance.Publish(self.Root(), new SkillCDUpdate());
            }

            if (self.Skills.Count == 0 && self.SkillCDs.Count == 0 && self.SkillPublicCDTime < nowTime)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }

        public static void OnFinish(this SkillManagerComponentC self)
        {
            int skillcnt = self.Skills.Count;
            for (int i = skillcnt - 1; i >= 0; i--)
            {
                SkillC skill = self.Skills[i];

                if (skill == null)
                {
                    Log.Error("技能消失？！");
                    self.Skills.RemoveAt(i);
                    continue;
                }

                SkillHandlerC aaiHandler = SkillDispatcherComponentC.Instance.Get(skill.SkillConf.GameObjectName);
                aaiHandler.OnFinished(skill);
                self.Skills.RemoveAt(i);
                ObjectPool.Instance.Recycle(skill);
            }

            if (self.Skills.Count == 0 && self.SkillCDs.Count == 0)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }

        //发送使用消息的技能
        public static async ETTask<int> SendUseSkill(this SkillManagerComponentC self, int skillid, int itemId, int angle, long targetId,
        float distance, bool checksing = true)
        {
            try
            {
                Unit unit = self.GetParent<Unit>();
                if (self.SkillCmd == null)
                {
                    self.SkillCmd = C2M_SkillCmd.Create();
                }

                C2M_SkillCmd skillCmd = self.SkillCmd;
                skillCmd.SkillID = skillid;
                skillCmd.TargetAngle = angle;
                skillCmd.TargetID = targetId;
                skillCmd.ItemId = itemId;
                skillCmd.TargetDistance = distance;
                int errorCode = self.CanUseSkill(itemId, skillid);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    HintHelp.ShowErrorHint(self.Root(), errorCode);
                    return errorCode;
                }

                if (unit.GetComponent<SingingComponent>().IsSkillSinging(skillid))
                {
                    return ErrorCode.ERR_Success;
                }

                unit.GetComponent<SingingComponent>().BeginSkill();
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
                SkillSetComponentC skillSetComponent = unit.Root().GetComponent<SkillSetComponentC>();
                if (checksing && skillConfig.SkillFrontSingTime > 0 && !skillSetComponent.IsSkillSingingCancel(skillConfig.Id))
                {
                    unit.GetComponent<SingingComponent>().BeforeSkillSing(skillCmd);
                    self.Root().GetComponent<AttackComponent>().RemoveTimer();
                    errorCode = ErrorCode.ERR_Success;
                }
                else
                {
                    errorCode = await self.ImmediateUseSkill(skillCmd);
                }

                if (errorCode == ErrorCode.ERR_Success)
                {
                    unit.GetComponent<SingingComponent>().AfterSkillSing(skillConfig);
                }

                return errorCode;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }
        }

        public static async ETTask<int> ImmediateUseSkill(this SkillManagerComponentC self, C2M_SkillCmd skillCmd)
        {
            long time_1 = TimeHelper.ClientNow();
            Unit unit = self.GetParent<Unit>();
            try
            {
                unit.GetComponent<StateComponentC>().SetNetWaitEndTime(time_1 + 200);
                M2C_SkillCmd m2C_SkillCmd = await self.Root().GetComponent<ClientSenderCompnent>().Call(skillCmd) as M2C_SkillCmd;
                if (unit.IsDisposed)
                {
                    return ErrorCode.ERR_NetWorkError;
                }

                unit.GetComponent<StateComponentC>().SetNetWaitEndTime(0);
                if (m2C_SkillCmd.Error == 0)
                {
                    BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
                    SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
                    int weaponSkill = SkillHelp.GetWeaponSkill(skillCmd.SkillID, UnitHelper.GetEquipType(self.Root()),
                        skillSetComponent.SkillList);
                    SkillConfig skillWeaponConfig = SkillConfigCategory.Instance.Get(weaponSkill);

                    long addTime = (long)(skillWeaponConfig.SkillRigidity * 1000);
                    long time_2 = TimeHelper.ClientNow();
                    long rigidity = addTime - (time_2 - time_1);
                    rigidity = Math.Max(rigidity, 0);

                    unit.GetComponent<StateComponentC>().SetRigidityEndTime(rigidity + time_2);
                }
                else
                {
                    unit.GetComponent<StateComponentC>().SetRigidityEndTime(0);
                }

                if (!string.IsNullOrEmpty(m2C_SkillCmd.Message))
                {
                    HintHelp.ShowHint(self.Root(), m2C_SkillCmd.Message);
                }

                return m2C_SkillCmd.Error;
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
                self.Root().GetComponent<AttackComponent>()?.RemoveTimer();
                return ErrorCode.ERR_NetWorkError;
            }
        }

        public static void AddSkillSecond(this SkillManagerComponentC self, int skillId, int secondId)
        {
            if (self.SkillSecond.ContainsKey(secondId))
            {
                return;
            }

            self.SkillSecond.Add(secondId, skillId);
        }

        public static void AddSkillCD(this SkillManagerComponentC self, int skillId, long cdEndTime, long pulicCD)
        {
            if (self.SkillSecond.ContainsKey(skillId))
            {
                skillId = self.SkillSecond[skillId];
            }

            //添加技能CD列表
            SkillCDItem skillcd = self.GetSkillCD(skillId);
            if (skillcd == null)
            {
                skillcd = new SkillCDItem();
                self.SkillCDs.Add(skillcd);
            }

            skillcd.SkillID = skillId;
            skillcd.CDEndTime = cdEndTime;
            ; // + 100;
            self.SkillPublicCDTime = pulicCD;
            ; // + 100;
            self.AddSkillTimer();
        }

        public static void AddSkillTimer(this SkillManagerComponentC self)
        {
            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.SkillTimerC, self);
            }
        }

        public static void InitSkill(this SkillManagerComponentC self)
        {
            List<SkillInfo> skillInfos = self.t_Skills;
            for (int i = 0; i < skillInfos.Count; i++)
            {
                if (skillInfos[i].SkillEndTime < TimeHelper.ServerNow())
                {
                    continue;
                }

                M2C_UnitUseSkill m2C_UnitUseSkill = M2C_UnitUseSkill.Create();
                m2C_UnitUseSkill.SkillInfos.Add(skillInfos[i]);
                self.OnUseSkill(m2C_UnitUseSkill);
            }

            self.t_Skills.Clear();
        }

        /// <summary>
        /// CD异常 换客户端时间111111111111111
        /// </summary>
        /// <param name="self"></param>
        /// <param name="skillcmd"></param>
        public static void OnUseSkill(this SkillManagerComponentC self, M2C_UnitUseSkill skillcmd)
        {
            Unit unit = self.GetParent<Unit>();
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillcmd.SkillInfos[0].WeaponSkillID);

            if (moveComponent != null && !moveComponent.IsArrived() && skillConfig.IfStopMove == 0)
            {
                moveComponent.Stop(true);
            }

            if (unit.MainHero && !unit.IsSelfRobot())
            {
                self.AddSkillCD(skillcmd.SkillID, skillcmd.CDEndTime, skillcmd.PublicCDTime);

                EventSystem.Instance.Publish(self.Root(), new OnSkillUse() { SkillId = skillcmd.SkillID });
            }

            if (unit.Type != UnitType.Player && skillcmd.SkillInfos.Count > 0)
            {
                Unit target = unit.GetParent<UnitComponent>().Get(skillcmd.SkillInfos[0].TargetID);
                if (target != null)
                {
                    //float3 direction = target.Position - unit.Position;
                    //float ange =Mathf.Rad2Deg * Mathf.Atan2(direction.x, direction.z);
                    unit.Rotation = quaternion.Euler(0, math.radians(skillcmd.TargetAngle), 0);
                }
                else
                {
                    unit.Rotation = quaternion.Euler(0, math.radians(skillcmd.TargetAngle), 0);
                }
            }
            else
            {
                unit.Rotation = quaternion.Euler(0, math.radians(skillcmd.TargetAngle), 0);
            }

            //播放对应攻击动作
            if (skillConfig.IfStopMove == 1)
            {
                EventSystem.Instance.Publish(self.Root(), new PlayAnimator()
                {
                    Unit = unit,
                    Animator = skillConfig.SkillAnimation
                });
            }
            else
            {
                bool noMoveSkill = skillConfig.GameObjectName.Equals("Skill_Other_XuanFengZhan_1");
                long SkillMoveTime = noMoveSkill ? skillConfig.SkillLiveTime + TimeHelper.ClientNow() : 0;
                self.SkillMoveTime = SkillMoveTime;

                double singTime = skillConfig.SkillSingTime;
                self.SkillSingTime = singTime == 0f ? 0 : TimeHelper.ClientNow() + (int)(1000f * singTime);

                double rigibTime = skillConfig.SkillRigidity;
                long skillRigibTime = TimeHelper.ClientNow() + (int)(1000f * rigibTime);
                //光之能量 保持在动作的最后一帧
                if (!noMoveSkill && skillConfig.Id >= 61022301 && skillConfig.Id <= 61022306)
                {
                    self.SkillMoveTime = skillRigibTime;
                }

                if (!CommonHelp.IfNull(skillConfig.SkillAnimation))
                {
                    int fsmType = skillConfig.ComboSkillID > 0 ? 5 : 4;
                    if (ConfigData.NotCombatSkill.Contains(skillConfig.SkillAnimation))
                    {
                        fsmType = 4;
                    }

                    EventSystem.Instance.Publish(self.Root(), new FsmChange()
                    {
                        FsmHandlerType = fsmType,
                        SkillId = skillcmd.SkillInfos[0].WeaponSkillID,
                        Unit = unit
                    });
                }
            }

            //播放对应技能特效
            for (int i = 0; i < skillcmd.SkillInfos.Count; i++)
            {
                SkillConfig skillConfig1 = SkillConfigCategory.Instance.Get(skillcmd.SkillInfos[i].WeaponSkillID);
                int effctId = skillConfig1.SkillEffectID[0];
                if (effctId != 0 && !EffectConfigCategory.Instance.Contain(effctId))
                {
                    Log.Error($"无效的effectid {effctId}");
                    continue;
                }

                SkillC skillHandler = self.AddChild<SkillC>();
                skillHandler.SkillInfo = skillcmd.SkillInfos[i];
                skillHandler.SkillConf = skillConfig1;
                self.Skills.Add(skillHandler);
                //skillHandler.OnInit(skillcmd.SkillInfos[i], unit);
                SkillHandlerC aaiHandler = SkillDispatcherComponentC.Instance.Get(skillHandler.SkillConf.GameObjectName);
                aaiHandler.OnInit(skillHandler, unit);
            }

            self.AddSkillTimer();
        }

        public static void InterruptSkill(this SkillManagerComponentC self, int skillId)
        {
            int skillcnt = self.Skills.Count;
            for (int i = skillcnt - 1; i >= 0; i--)
            {
                SkillC skillHandler = self.Skills[i];
                if (skillHandler.SkillConf.Id != skillId)
                {
                    continue;
                }

                skillHandler.SetSkillState(SkillState.Finished);
            }
        }

        public static void OnSkillSecondResult(this SkillManagerComponentC self, M2C_SkillSecondResult message)
        {
            if (message.HurtIds.Count == 0)
            {
            }
        }

        public static int CanUseSkill(this SkillManagerComponentC self, int itemId, int skillId)
        {
            Unit unit = self.GetParent<Unit>();

            //检查魔法值
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            int skillMp = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.SkillUseMP);
            if (skillConfig.SkillUseMP > 0 && skillMp < skillConfig.SkillUseMP)
            {
                return ErrorCode.ERR_CanNotUseSkill_MP;
            }

            //普攻不检测CD
            if (skillConfig.SkillActType != 0)
            {
                SkillCDItem skillCDList = self.GetSkillCD(skillId);
                //技能冷却中
                if (skillCDList != null)
                {
                    return ErrorCode.ERR_UseSkillInCD5;
                }

                //公共技能冷却
                long leftPublicCD = self.SkillPublicCDTime - TimeHelper.ServerNow();
                if (leftPublicCD > 1500)
                {
                    Log.Error($"leftPublicCD > 1000 {leftPublicCD}");
                    self.SkillPublicCDTime = TimeHelper.ServerNow();
                    leftPublicCD = 0;
                }

                if (itemId == 0 && leftPublicCD > 0)
                {
                    return ErrorCode.ERR_UseSkillInCD6;
                }
            }

            StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
            int errorCode = stateComponent.CanUseSkill(skillConfig, true);
            if (errorCode != ErrorCode.ERR_Success)
            {
                stateComponent.CheckSilence();
                return errorCode;
            }

            if (self.IsSkillMoveTime())
            {
                return ErrorCode.ERR_SkillMoveTime;
            }

            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (itemId > 0 && SceneConfigHelper.UseSceneConfig(mapComponent.SceneType))
            {
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(mapComponent.SceneId);
                if (sceneConfig.IfUseSkillItem == 1)
                {
                    return ErrorCode.ERR_NoUseItemSkill;
                }
            }

            return 0;
        }
    }
}