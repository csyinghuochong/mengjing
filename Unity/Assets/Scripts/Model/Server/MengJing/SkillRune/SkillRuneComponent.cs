using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 技能符文：玩家拥有的技能符文实例，以及每个主动技能上镶嵌的技能符文孔位。
    /// 符文配置查 SkillRuneConfig（一行一级，NextId 串下一级），
    /// 每个技能可镶嵌的孔位数量查 GlobalValueConfig.SkillRuneSlotCount。
    /// 这里存的是存档结构 SkillRuneInfo / SkillRuneSlotInfo，
    /// 下发给客户端的协议结构是 SkillRuneInfoProto / SkillRuneSlotInfoProto
    /// </summary>
    [ComponentOf(typeof(Unit))]
    public class SkillRuneComponent : Entity, IAwake, IDestroy, ITransfer, IUnitCache, IDeserialize
    {
        /// <summary>
        /// 拥有的技能符文，已镶嵌的也在里面。
        /// 孔位里记的是 SkillRuneInfo.Id，技能符文背包 = 没有被任何孔位引用的那些
        /// </summary>
        public List<SkillRuneInfo> RuneList { get; set; } = new List<SkillRuneInfo>();

        /// <summary>
        /// 每个技能（按基础技能 id）的孔位。只记录镶嵌过符文的技能，没有记录就是空孔
        /// </summary>
        public List<SkillRuneSlotInfo> SlotList { get; set; } = new List<SkillRuneSlotInfo>();
    }
}
