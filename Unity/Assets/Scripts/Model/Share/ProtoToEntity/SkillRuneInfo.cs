namespace ET
{
    /// <summary>
    /// 一枚技能符文实例（存档结构，客户端/服务端共用）。
    /// 协议结构是 SkillRuneInfoProto，存档和协议分开，协议字段变化不影响已有存档
    /// </summary>
    [EnableClass]
    public class SkillRuneInfo
    {
        /// <summary>
        /// 唯一 id
        /// </summary>
        public long Id;

        /// <summary>
        /// SkillRuneConfig.Id，当前等级那一行
        /// </summary>
        public int ConfigId;

        public void FromMessage(SkillRuneInfoProto proto)
        {
            if (proto == null)
            {
                return;
            }

            Id = proto.Id;
            ConfigId = proto.ConfigId;
        }

        public SkillRuneInfoProto ToMessage()
        {
            SkillRuneInfoProto proto = SkillRuneInfoProto.Create();
            proto.Id = Id;
            proto.ConfigId = ConfigId;
            return proto;
        }
    }
}
