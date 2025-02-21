using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    /// 属性类Buff
    /// </summary>
    public class RoleBuff_Attribute: BuffHandlerS
    {
        public override void OnInit(BuffS buffS, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler)
        {
            buffS.OnBaseBuffInit(buffS.BuffData, theUnitFrom, theUnitBelongto);

            buffS.OnUpdate();
        }

        public override void OnUpdate(BuffS buffS)
        {
            NumericComponentS heroCom = buffS.TheUnitBelongto.GetComponent<NumericComponentS>();
            if (heroCom == null)
            {
                Log.Warning("RoleBuff_Attribute.heroCom == null");
                buffS.BuffState = BuffState.Finished;
                return;
            }

            long serverTime = TimeHelper.ServerNow();
            buffS.PassTime = serverTime - buffS.BeginTime;

            //buff是否为循环触发的
            if (buffS.InterValTime > 0)
            {
                long InterValTimePass = serverTime - buffS.InterValTimeBegin;
                if (InterValTimePass >= buffS.InterValTime)
                {
                    buffS.InterValTimeBegin = serverTime;
                    buffS.IsTrigger = false;
                }
            }

            //执行buff
            if (!buffS.IsTrigger && buffS.PassTime >= buffS.DelayTime)
            {
                ///移动才触发
                if (buffS.mBuffConfig.MoveAction == 1)
                {
                    MoveComponent moveComponent = buffS.TheUnitBelongto.GetComponent<MoveComponent>();
                    if (moveComponent != null && !moveComponent.IsArrived())
                    {
                        buffSetProperty(buffS, heroCom);
                    }
                }
                else
                {
                    buffSetProperty(buffS, heroCom);
                }
            }

            //buff执行结束
            if (serverTime >= buffS.BuffEndTime)
            {
                buffS.BuffState = BuffState.Finished;
            }
        }

        public void buffSetProperty(BuffS buffS, NumericComponentS heroCom)
        {
            //Log.Info("触发Buff" + this.BuffData.BuffConfig.BuffName);

            buffS.IsTrigger = true;
            
            int buffNumber = 1;
            int buffindex = 0;

            BuffManagerComponentS buffManagerComponent = buffS.TheUnitBelongto.GetComponent<BuffManagerComponentS>();
            if ( buffS.mBuffConfig.BuffAddSync == 1 &&  buffS.mBuffConfig.buffParameterType == 3001 )
            {
                buffNumber = buffManagerComponent.GetBuffSourceNumber(0, buffS.mBuffConfig.Id);
                buffindex = buffManagerComponent.GetBuffIndexById(buffS);
                if (buffindex > 0)
                {
                    return;
                }
            }
            
            switch (buffS.mBuffConfig.BuffType)
            {
                //属性类buff
                case 1:
                    int NowBuffParameterType = buffS.mBuffConfig.buffParameterType;
                    float NowBuffParameterValue = (float)buffS.mBuffConfig.buffParameterValue  * buffNumber +
                            buffS.GetTianfuProAdd((int)BuffAttributeEnum.AddParameterValue);
                    int NowBuffParameterValueType = buffS.mBuffConfig.buffParameterValueType;

                    int ValueType = buffS.mBuffConfig.buffParameterValueDef; //0 表示整数  1表示浮点数
                    //乘法算法
                    if (NowBuffParameterValueType != 0)
                    {
                        ValueType = NumericHelp.GetNumericValueType(NowBuffParameterValueType);
                        //临时代吗
                        if (buffS.mBuffConfig.buffParameterValue < 1 && buffS.mBuffConfig.buffParameterValueType == 1002)
                        {
                            ValueType = 1;
                        }

                        if (NowBuffParameterType == 3001 && NowBuffParameterValue > 0f)
                        {
                            //NowBuffParameterValue += heroCom.GetAsFloat(NumericType.Now_ShenNongPro);
                        }

                        //取整数
                        if (ValueType == 1)
                        {
                            buffS.NowBuffValue = heroCom.GetAsLong(NowBuffParameterValueType) * NowBuffParameterValue;
                        }

                        //取浮点数
                        if (ValueType == 2)
                        {
                            buffS.NowBuffValue = heroCom.GetAsFloat(NowBuffParameterValueType) * NowBuffParameterValue;
                        }
                    }
                    else
                    {
                        //加法算法
                        buffS.NowBuffValue = NowBuffParameterValue;
                    }

                    if (NowBuffParameterType == 3001)
                    {
                        //神农属性额外处理
                        buffS.NowBuffValue = buffS.NowBuffValue * (1f + heroCom.GetAsFloat(NumericType.Now_ShenNongPro) +
                            heroCom.GetAsFloat(NumericType.Now_ShenNongProNoFight));
                        int nowdamgeType = 2;
                        if (buffS.NowBuffValue < 0)
                        {
                            nowdamgeType = 0;
                        }

                        heroCom.ApplyChange(NumericType.Now_Hp, (long)buffS.NowBuffValue, true, true, buffS.TheUnitFrom.Id, 0, nowdamgeType);
                    }
                    else if (NowBuffParameterType == NumericType.CardTransform)
                    {
                        heroCom.ApplyChange(NumericType.CardTransform, (int)(buffS.mBuffConfig.buffParameterValue), true, true, buffS.TheUnitFrom.Id,0, 0);
                    }
                    else if (NowBuffParameterType == NumericType.SkillUseMP)
                    {
                        heroCom.ApplyChange(NumericType.SkillUseMP, (long)buffS.NowBuffValue, true, true, buffS.TheUnitFrom.Id, 0);
                    }
                    else if (NowBuffParameterType == NumericType.PetMeleeMoLi)
                    {
                        heroCom.ApplyChange(NumericType.PetMeleeMoLi, (long)buffS.NowBuffValue, true, true, buffS.TheUnitFrom.Id, 0);
                    }
                    else if (NowBuffParameterType == NumericType.BattleCamp)
                    {
                        AIComponent belongToAIComponent = buffS.TheUnitBelongto.GetComponent<AIComponent>();

                        int oldAi = belongToAIComponent.AIConfigId;
                        int oldCamp = heroCom.GetAsInt(NumericType.BattleCamp);
                        int newCamp = buffS.TheUnitFrom.GetComponent<NumericComponentS>().GetAsInt(NumericType.BattleCamp);
                        heroCom.ApplyValue(NumericType.BattleCamp, newCamp, true, true, 0, 0);
                        heroCom.ApplyValue(NumericType.BattleCampOld, oldCamp, true, true, 0, 0);
                        heroCom.ApplyValue(NumericType.MasterId,  buffS.TheUnitFrom.Id, true, true, 0, 0);
                        heroCom.ApplyValue(NumericType.Old_AI, oldAi, true, true, 0, 0);

                        AttackRecordComponent attackRecordComponent = buffS.TheUnitFrom.GetComponent<AttackRecordComponent>();
                        attackRecordComponent.BeAttackId = 0;
                        attackRecordComponent.AttackingId = 0;

                        belongToAIComponent.AIConfigId = 14;
                        belongToAIComponent.TargetID = 0;
                        belongToAIComponent.Stop_2();
                        belongToAIComponent.Begin();
                        Console.WriteLine($"newCamp:   {heroCom.Id}   {oldCamp} ==>  {newCamp}");
                    }
                    else
                    {
                        HeroDataComponentS heroDataComponentS = buffS.TheUnitBelongto.GetComponent<HeroDataComponentS>();
                        //整数
                        if (ValueType == 0)
                        {
                            heroDataComponentS.BuffPropertyUpdate_Long(NowBuffParameterType, (long)buffS.NowBuffValue);
                        }

                        //浮点数
                        if (ValueType == 1)
                        {
                            heroDataComponentS .BuffPropertyUpdate_Float(NowBuffParameterType, (float)buffS.NowBuffValue);
                        }
                    }

                    break;

                //状态类buff
                case 2:
                    NowBuffParameterType = buffS.mBuffConfig.buffParameterType;
                    long sta = (1 << NowBuffParameterType);
                    buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeAdd(sta);
                    break;

                case 3: //释放技能 
                    //buff來源者再次釋放技能
                    if (!buffS.TheUnitFrom.IsDisposed)
                    {
                        C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                        cmd.SkillID = buffS.mBuffConfig.buffParameterType;
                        cmd.TargetID = buffS.TheUnitBelongto.Id;
                        float3 direction = buffS.TheUnitBelongto.Position - buffS.TheUnitFrom.Position;
                        float ange = 0; /// Mathf.Rad2Deg(Mathf.Atan2(direction.x, direction.z));
                        // if (direction == new float3(0,0,0))
                        // {
                        //     cmd.TargetAngle = 0;///(int)Quaternion.QuaternionToEuler(this.TheUnitBelongto.Rotation).y;
                        // }
                        // else
                        {
                            cmd.TargetAngle = (int)math.floor(ange);
                        }
                        cmd.TargetDistance = PositionHelper.Distance2D(buffS.TheUnitBelongto.Position, buffS.TheUnitFrom.Position);
                        buffS.TheUnitFrom.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, false);
                    }

                    break;
                case 4:
                    buffS.TheUnitBelongto.GetComponent<SkillPassiveComponent>().AddPassiveSkill(buffS.mBuffConfig.buffParameterType);
                    break;
                case 5: //驱散
                    //(buffParameterValue2  ) 需要提前解析要移除的buffid。拓展SkillBuffConfig 放在ConfigPartial
                    List<int> relieveBuffs = SkillBuffConfigCategory.Instance.GetRelieveBuffs(buffS.mBuffConfig.Id);
                    if (relieveBuffs != null && relieveBuffs.Count > 0)
                    {
                        foreach (int buffId in relieveBuffs)
                        {
                            buffS.TheUnitBelongto.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, buffId);
                        }
                    }

                    break;
                case 6: //一次性技能
                    if (buffS.TheUnitBelongto.Type == UnitType.Player)
                    {
                        using var list = ListComponent<int>.Create();
                        if (!CommonHelp.IfNull(buffS.mBuffConfig.buffParameterValue2))
                        {
                            string[] skillinfos = buffS.mBuffConfig.buffParameterValue2.Split(';');
                            for (int i = 0; i < skillinfos.Length; i++)
                            {
                                list.Add(int.Parse(skillinfos[i]));
                            }
                        }

                        if (list.Count > 0)
                        {
                            //服务器也做个记录
                            int skillid = list[RandomHelper.RandomNumber(0, list.Count)];
                            buffS.TheUnitBelongto.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.BuffSkill, skillid.ToString());
                        }
                    }
                    break;
                case 7:
                    break;
                default:
                    break;
            }
        }

        public override void OnFinished(BuffS buffS)
        {
            if (!buffS.IsTrigger)
            {
                return;
            }

            //移除相关属性
            switch (buffS.mBuffConfig.BuffType)
            {
                case 1:
                    //Log.Debug("执行buff移除属性...");
                    int NowBuffParameterType = buffS.mBuffConfig.buffParameterType;
                    NumericComponentS numericComponentS = buffS.TheUnitBelongto.GetComponent<NumericComponentS>();
                    if (NowBuffParameterType == 3001)
                    {
                        //血量不进行移除
                    }
                    else if (NowBuffParameterType == 3164)
                    {
                        numericComponentS.ApplyValue(NowBuffParameterType, 0);
                    }
                    else if (NowBuffParameterType == 3134)
                    {
                        //怒气不进行移除
                    }
                    else if (NowBuffParameterType == NumericType.PetMeleeMoLi)
                    {
                        //怒气不进行移除
                    }
                    else if (NowBuffParameterType == NumericType.BattleCamp)
                    {
                        int oldCamp = numericComponentS.GetAsInt(NumericType.BattleCampOld);
                        int oldAi  =  numericComponentS.GetAsInt(NumericType.Old_AI);
                        numericComponentS.ApplyValue(NumericType.BattleCamp, oldCamp, true, true, 0, 0);
                        numericComponentS.ApplyValue(NumericType.MasterId,  0, true, true, 0, 0);

                        AIComponent belongAIComponent = buffS.TheUnitBelongto.GetComponent<AIComponent>();
                        belongAIComponent.AIConfigId = oldAi;
                        belongAIComponent.TargetID = 0;
                        belongAIComponent.Stop_2();
                        belongAIComponent.Begin();

                        Console.WriteLine($"resetCamp:   {numericComponentS.Id}");
                    }
                    else
                    {
                        int ValueType = buffS.mBuffConfig.buffParameterValueDef; //0 表示整数  1表示浮点数
                        HeroDataComponentS heroDataComponentS = buffS.TheUnitBelongto.GetComponent<HeroDataComponentS>();
                        //整数
                        if (ValueType == 0)
                        {
                            heroDataComponentS.BuffPropertyUpdate_Long(NowBuffParameterType, (long)buffS.NowBuffValue * -1);
                        }
                        //浮点数
                        if (ValueType == 1)
                        {
                            heroDataComponentS .BuffPropertyUpdate_Float(NowBuffParameterType, (float)buffS.NowBuffValue * -1);
                        }
                    }

                    break;
                case 2:
                    NowBuffParameterType = buffS.mBuffConfig.buffParameterType;
                    buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeRemove(1 << NowBuffParameterType);
                    break;
                case 4:
                    buffS.TheUnitBelongto.GetComponent<SkillPassiveComponent>().RemovePassiveSkill(buffS.mBuffConfig.buffParameterType);
                    break;
                default:
                    break;
            }
        }
    }
}