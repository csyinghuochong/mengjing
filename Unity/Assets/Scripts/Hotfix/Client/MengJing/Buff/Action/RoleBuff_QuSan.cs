namespace ET.Client
{
    public class RoleBuff_QuSan : RoleBuff_Base
    {
        public override void OnInit(BuffC buffc, BuffData buffData, Unit theUnitBelongto)
        {
            buffc.BaseOnBuffInit(buffData, theUnitBelongto);

            BuffManagerComponentC buffManager = theUnitBelongto.GetComponent<BuffManagerComponentC>();
            for (int i = buffManager.m_Buffs.Count - 1; i >= 0; i--)
            {
                SkillBuffConfig skillBuff = buffManager.m_Buffs[i].mSkillBuffConf;
                if (skillBuff!=null &&  skillBuff.BuffBenefitType == 2)
                {
                    buffManager.m_Buffs[i].BuffState = BuffState.Finished;
                }
            }
        }
    }
}
