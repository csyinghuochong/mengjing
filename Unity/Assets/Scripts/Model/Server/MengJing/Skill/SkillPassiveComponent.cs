using System.Collections.Generic;

namespace ET.Server
{
    
    [EnableClass]
    public class SkillPassiveInfo
    {
        public int SkillId;
        public List<int> SkillPassiveTypeEnum;
        public List<float> SkillPro;                  //�������ʻ���Ѫ���ٷֱ�
        public int TriggerOnce;                 //�Ƿ񴥷�һ��
        public long TriggerInterval;           //�������
        public long LastTriggerTime;            //�ϴδ���ʱ��
        public int TriggerNumber;

        public SkillPassiveInfo(int skillId, List<int> skillPassiveTypeEnum, List<float> skillPro, int triggerOnce, double triggerTime)
        {
            this.SkillId = skillId;
            this.SkillPassiveTypeEnum = skillPassiveTypeEnum;
            this.SkillPro = skillPro;
            this.TriggerOnce = triggerOnce;
            this.TriggerInterval = (long)(1000 * triggerTime);
            this.LastTriggerTime = 0;
        }

        public void Reset()
        {

            this.LastTriggerTime = 0;
        }
    }


    [ComponentOf(typeof(Unit))]
    public class SkillPassiveComponent : Entity, IAwake, IDestroy, ITransfer
    {
        public long Timer;
        public int UnitType;
        public long SingTimer;
        public int HuixueTimeNum;               //��Ѫ������ʱ��,���봥��
        public List<SkillPassiveInfo> SkillPassiveInfos = new List<SkillPassiveInfo>();

        public C2M_SkillCmd C2M_SkillCmd = C2M_SkillCmd.Create();

        public SkillPassiveInfo SingSkillIfo;
        public long SingTargetId = 0;

    }
}
