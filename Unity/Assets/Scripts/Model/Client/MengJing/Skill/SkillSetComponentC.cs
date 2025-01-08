using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class SkillSetComponentC: Entity, IAwake, IDestroy
    {
        public int TianFuPlan { get; set; } = 0;

        public List<KeyValuePairInt> TianFuList1 { get; set; } = new(); //第一套天赋 只记录每个位置当前激活的天赋id.  

        public List<KeyValuePairInt> TianFuList2 { get; set; } = new(); //第二套天賦方案

        public List<KeyValuePairInt> TianFuAddition { get; set; } = new(); //附加天赋
        
        /// <summary>
        /// 玩家携带的技能列表
        /// </summary>
        public List<SkillPro> SkillList { get; set; } = new();

        //生命之盾
        public List<LifeShieldInfo> LifeShieldList { get; set; } = new();
    }
}