using System.Collections.Generic;

namespace ET.Client
{
    
    [ComponentOf(typeof(Scene))]
    public class SkillSetComponentC: Entity, IAwake, IDestroy
    {
        public int TianFuPlan = 0;

        public List<int> TianFuList { get; set; } = new List<int>(); //第一套天賦方案

        public List<int> TianFuList1 { get; set; }= new List<int>();         //第二套天賦方案

        public List<int> TianFuAddition { get; set; }= new List<int>();         //附加天赋

        public List<SkillPro> SkillList { get; set; }= new List<SkillPro>();

        //生命之盾
        public List<LifeShieldInfo> LifeShieldList{ get; set; } = new List<LifeShieldInfo>();
    }
}

