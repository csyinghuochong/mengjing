namespace ET.Server
{
    public class RoleBuff_Shield : BuffHandlerS
    {
        public override void OnInit(BuffS buffS, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler)
        {
            buffS.OnBaseBuffInit(buffS.BuffData, theUnitFrom, theUnitBelongto);

            NumericComponentS numericComponent = buffS.TheUnitBelongto.GetComponent<NumericComponentS>();
            int maxHp = numericComponent.GetAsInt(NumericType.Now_MaxHp);
            //1百分比 2固定伤害
            int totalValue = 0;
            if (buffS.mBuffConfig.buffParameterType == 1)
            {
                numericComponent.ApplyValue(NumericType.Now_Shield_HP,
                    (int)buffS.mBuffConfig.buffParameterValue * theUnitFrom.GetComponent<NumericComponentS>().GetAsLong(NumericType.Now_Hp), true);
                totalValue = (int)(maxHp * 1f * buffS.mBuffConfig.buffParameterValue);
            }
            else
            {
                totalValue = (int)buffS.mBuffConfig.buffParameterValue;
            }

            numericComponent.ApplyValue(NumericType.Now_Shield_HP, totalValue, true);
            numericComponent.ApplyValue(NumericType.Now_Shield_MaxHP, totalValue, true);
            numericComponent.ApplyValue(NumericType.Now_Shield_DamgeCostPro, buffS.mBuffConfig.DamgePro, false);
        }

        public override void OnUpdate(BuffS buffS)
        {
            NumericComponentS numericComponent = buffS.TheUnitBelongto.GetComponent<NumericComponentS>();

            if (numericComponent.GetAsLong(NumericType.Now_Shield_HP) <= 0)
            {
                buffS.BuffState = BuffState.Finished;
                int skillId = 0;
                if (!string.IsNullOrEmpty(buffS.mBuffConfig.buffParameterValue2))
                {
                    skillId = int.Parse(buffS.mBuffConfig.buffParameterValue2);
                }

                if (skillId > 0)
                {
                    C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                    cmd.SkillID = skillId;
                    cmd.TargetID = 0;
                    cmd.TargetAngle = (int)buffS.TheUnitBelongto.Rotation.value.y;
                    cmd.TargetDistance = 0;
                    buffS.TheUnitBelongto.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, true);
                }

                return;
            }

            if (TimeHelper.ServerNow() > buffS.BuffEndTime)
            {
                buffS.BuffState = BuffState.Finished;
            }
        }

        public override void OnFinished(BuffS buffS)
        {
            NumericComponentS numericComponent = buffS.TheUnitBelongto.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.Now_Shield_HP, 0);
        }
    }
}