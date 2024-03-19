using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;


namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class SkillSetComponentServer : Entity, IAwake, ITransfer, IDestroy, IUnitCache, IDeserialize
    {
        public int TianFuPlan = 0;

        public List<int> TianFuList = new List<int>();          //��һ�����x����

        public List<int> TianFuList1 = new List<int>();         //�ڶ������x����

        public List<int> TianFuAddition = new List<int>();         //�����츳

        public List<SkillPro> SkillList = new List<SkillPro>();

        //����֮��
        public List<LifeShieldInfo> LifeShieldList = new List<LifeShieldInfo>();


        public M2C_SkillSetMessage M2C_SkillSetMessage = new M2C_SkillSetMessage() { SkillSetInfo = new SkillSetInfo() };
    }
}