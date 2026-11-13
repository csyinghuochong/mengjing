using System.Collections.Generic;

namespace ET.Client
{
    /// <summary>
    /// 客户端的技能符文数据：拥有的符文实例 + 每个技能的孔位。
    /// 登录时/打开界面时由服务端下发，符文配置查 SkillRuneConfig，
    /// 孔位数量查 GlobalValueConfig.SkillRuneSlotCount。
    /// 本地存的是客户端/服务端共用的存档结构 SkillRuneInfo / SkillRuneSlotInfo
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class SkillRuneComponentC : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 拥有的全部技能符文，已镶嵌的也在里面。
        /// 孔位里引用的是 SkillRuneInfo.Id，技能符文背包 = 没有被任何孔位引用的那些
        /// </summary>
        public List<SkillRuneInfo> RuneList { get; set; } = new List<SkillRuneInfo>();

        /// <summary>
        /// 有孔位记录的技能，服务端只发有记录的，没有记录的技能视为全部空孔
        /// </summary>
        public List<SkillRuneSlotInfo> SlotList { get; set; } = new List<SkillRuneSlotInfo>();
    }
}
