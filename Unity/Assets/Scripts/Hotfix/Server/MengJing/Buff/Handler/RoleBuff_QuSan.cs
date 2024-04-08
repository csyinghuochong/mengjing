namespace ET.Server
{
    
    public class RoleBuff_QuSan: BuffHandlerS
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffData"></param>
        /// <param name="theUnitFrom">buff持有者</param>
        /// <param name="theUnitBelongto">施法者</param>
        /// <param name="skillHandler"></param>
        public override void OnInit(BuffS buffS, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler)
        {
            buffS.OnBaseBuffInit(buffS.BuffData, theUnitFrom, theUnitBelongto);
            buffS.BeginTime = TimeHelper.ServerNow();

            BuffManagerComponentS buffManager = theUnitFrom.GetComponent<BuffManagerComponentS>();
            for (int i = buffManager.m_Buffs.Count - 1; i >= 0; i--)
            {
                SkillBuffConfig skillBuff = buffManager.m_Buffs[i].mBuffConfig;
                if (skillBuff.BuffBenefitType == 2)
                {
                    buffManager.m_Buffs[i].BuffState = BuffState.Finished;
                }
            }
        }

        public override void OnUpdate(BuffS buffS)
        {
            if (TimeHelper.ServerNow() > buffS.BuffEndTime)
            {
                buffS.BuffState = BuffState.Finished;
            }
        }

        public override void OnFinished(BuffS buffS)
        {
        }
    }
    
}