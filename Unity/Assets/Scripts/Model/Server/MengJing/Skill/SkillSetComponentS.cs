using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class SkillSetComponentS : Entity, IAwake, ITransfer, IDestroy, IUnitCache, IDeserialize
    {
        public int TianFuPlan = 0;

        public List<int> TianFuList = new List<int>();         

        public List<int> TianFuList1 = new List<int>();        

        public List<int> TianFuAddition = new List<int>();       

        public List<SkillPro> SkillList { get; set; } = new List<SkillPro>();


        public List<LifeShieldInfo> LifeShieldList = new List<LifeShieldInfo>();


        public M2C_SkillSetMessage M2C_SkillSetMessage = M2C_SkillSetMessage.Create();
    }
}