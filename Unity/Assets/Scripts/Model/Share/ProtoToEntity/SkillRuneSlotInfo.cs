using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 一个技能上的技能符文孔位（存档结构，客户端/服务端共用）。
    /// 协议结构是 SkillRuneSlotInfoProto，存档和协议分开；
    /// 孔位数量由 GlobalValueConfig.SkillRuneSlotCount 决定，孔位记的是 SkillRuneInfo.Id
    /// </summary>
    [EnableClass]
    public class SkillRuneSlotInfo
    {
        /// <summary>
        /// 基础技能 id：同一条技能升级链共用这个 id，由 SkillConfigCategory.GetInitSkill 换算得到
        /// </summary>
        public int SkillId;

        /// <summary>
        /// 各孔位镶嵌的技能符文 id，下标 0 对应界面上的 1 号孔，0 表示空孔
        /// </summary>
        public List<long> RuneIds = new List<long>();

        public void FromMessage(SkillRuneSlotInfoProto proto)
        {
            if (proto == null)
            {
                return;
            }

            SkillId = proto.SkillId;
            RuneIds.Clear();
            if (proto.RuneIds != null)
            {
                RuneIds.AddRange(proto.RuneIds);
            }
        }

        public SkillRuneSlotInfoProto ToMessage()
        {
            SkillRuneSlotInfoProto proto = SkillRuneSlotInfoProto.Create();
            proto.SkillId = SkillId;
            proto.RuneIds.AddRange(RuneIds);
            return proto;
        }
    }
}
