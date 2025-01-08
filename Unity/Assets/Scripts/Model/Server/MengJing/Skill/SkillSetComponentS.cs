using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Unit))]
    public class SkillSetComponentS : Entity, IAwake, ITransfer, IDestroy, IUnitCache, IDeserialize
    {

        public int TianFuPlan { get; set; } = 0; //对应TalentConfig.TalentType

        public List<KeyValuePairInt> TianFuList1{ get; set; } = new List<KeyValuePairInt>();        //第一套天赋 只记录每个位置当前激活的天赋id->等级.  

        public List<KeyValuePairInt> TianFuList2{ get; set; } = new List<KeyValuePairInt>();        //第二套天赋 

        public List<KeyValuePairInt> TianFuAddition = new List<KeyValuePairInt>();      //附加天赋

        /// <summary>
        /// 玩家携带的技能列表
        /// </summary>
        public List<SkillPro> SkillList { get; set; } = new List<SkillPro>();

        /// <summary>
        /// 玩家的生命护盾
        /// </summary>
        public List<LifeShieldInfo> LifeShieldList = new List<LifeShieldInfo>();
        
    }
}