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
            self.FangunSkillId = GlobalValueConfigCategory.Instance.FangunSkillId;

            Unit unit = self.GetParent<Unit>();
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            long masterId = numericComponentC.GetAsLong(NumericType.MasterId);
            self.UpdateCD = unit.MainHero || (unit.Type == UnitType.Pet && masterId == self.Root().GetComponent<PlayerInfoComponent>().CurrentRoleId);
        }

        [EntitySystem]
        private static void Destroy(this SkillManagerComponentC self)
        {          
            self.SkillCDs.Clear();
            self.OnDispose();
        }

        public static bool HaveSkillType(this SkillManagerComponentC self, string skilltype)
        {
            int skillcnt = self.Skills.Count;
            for (int i = skillcnt - 1; i >= 0; i--)
            {
                SkillC skillC = self.Skills[i];
                if (skillC.SkillConf.GameObjectName.Equals(skilltype))
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool HaveSkillById(this SkillManagerComponentC self, int skillId)
        {
            int skillcnt = self.Skills.Count;
            for (int i = skillcnt - 1; i >= 0; i--)
            {
                SkillC skillC = self.Skills[i];
                if (skillC.SkillConf.Id == skillId)
                {
                    return true;
                }
            }
            return false;
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
                    skill.Dispose();
                    self.Skills.RemoveAt(i);
                    continue;
                }
                
                aaiHandler.OnUpdate(skill);
            }

            if (self.UpdateCD)
            {
                EventSystem.Instance.Publish(self.Root(), new SkillCDUpdate());
            }

            if (self.Skills.Count == 0 && self.SkillCDs.Count == 0 && self.SkillPublicCDTime < nowTime)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            }
        }

        public static void OnDispose(this SkillManagerComponentC self)
        {
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
            self.Skills.Clear();
            self.SkillCDs.Clear();
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
                
                skill.Dispose();
                self.Skills.RemoveAt(i);
            }
            self.Skills.Clear();
            
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
                C2M_SkillCmd skillCmd = C2M_SkillCmd.Create();
                
                //宠物释放技能 ->获取当前主动的宠物id
                if (unit.Type == UnitType.Pet)
                {
                    skillCmd.PetId = unit.Id;
                }

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
                StateComponentC stateComponentC = unit.GetComponent<StateComponentC>();
                stateComponentC.SetNetWaitEndTime(time_1 + 1000);
                M2C_SkillCmd m2C_SkillCmd = await self.Root().GetComponent<ClientSenderCompnent>().Call(skillCmd) as M2C_SkillCmd;
                if (unit.IsDisposed)
                {
                    return ErrorCode.ERR_NetWorkError;
                }
                stateComponentC.SetNetWaitEndTime(0);
                
                if (m2C_SkillCmd.Error == 0)
                {
                    SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
                    int weaponSkill = SkillHelp.GetWeaponSkill(skillCmd.SkillID, UnitHelper.GetEquipType(self.Root()),
                        skillSetComponent.SkillList);
                    SkillConfig skillWeaponConfig = SkillConfigCategory.Instance.Get(weaponSkill);

                    long addTime = (long)(skillWeaponConfig.SkillRigidity * 1000);
                    long time_2 = TimeHelper.ClientNow();
                    long rigidity = addTime - (time_2 - time_1);
                    rigidity = Math.Max(rigidity, 0);

                    stateComponentC.SetRigidityEndTime(rigidity + time_2);
                }
                else
                {
                    stateComponentC.SetRigidityEndTime(0);
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

        public static void InitData(this SkillManagerComponentC self,  UnitInfo unitInfo)
        {
            self.t_Skills = unitInfo.Skills;
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

            if (unit.Type == UnitType.Monster)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                Log.Debug($"怪物：{monsterConfig.Id} {monsterConfig.MonsterName}  释放技能: {skillcmd.SkillInfos[0].WeaponSkillID}  {skillConfig.SkillName} ");
            }

            if (moveComponent != null && !moveComponent.IsArrived() && skillConfig.IfStopMove == 0)
            {
                moveComponent.Stop(false);
            }

            if (self.UpdateCD)
            {
                self.AddSkillCD(skillcmd.SkillID, skillcmd.CDEndTime, skillcmd.PublicCDTime);

                EventSystem.Instance.Publish(self.Root(), new OnSkillUse() { SkillId = skillcmd.SkillID });
            }

            unit.SpeedRate = 100;
            if (unit.Type != UnitType.Player && skillcmd.SkillInfos.Count > 0)
            {
                Unit target = unit.GetParent<UnitComponent>().Get(skillcmd.SkillInfos[0].TargetID);
                if (target != null)
                {
                    // float3 dir = target.Position - unit.Position ;
                    // float ange = math.atan2(dir.x, dir.z);
                    // unit.Rotation = quaternion.Euler(0, ange, 0);
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
            // if (skillConfig.IfStopMove == 1)
            // {
            //     EventSystem.Instance.Publish(self.Root(), new PlayAnimator()
            //     {
            //         Unit = unit,
            //         Animator = skillConfig.SkillAnimation
            //     });
            // }
            // else
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
                    Log.Error($"SkillId {skillcmd.SkillInfos[i].WeaponSkillID} 中配置了无效的effectid {effctId}");
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

        public static bool HaveChongJi(this SkillManagerComponentC self)
        {
            int skillcnt = self.Skills.Count;
            for (int i = skillcnt - 1; i >= 0; i--)
            {
                SkillC skillS = self.Skills[i];
                if (skillS.SkillConf.GameObjectName == ConfigData.Skill_Other_ChongJi_1)
                {
                    return true;
                }
            }
            return false;
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
            if (itemId > 0 && SceneConfigHelper.UseSceneConfig(mapComponent.MapType))
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