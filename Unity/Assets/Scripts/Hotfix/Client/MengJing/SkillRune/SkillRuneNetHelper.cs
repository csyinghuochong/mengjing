namespace ET.Client
{
    public static class SkillRuneNetHelper
    {
        /// <summary>
        /// 拉一次最新的技能符文数据：登录时在 LoginGameAsync 里调，打开界面时也可以再调一次
        /// </summary>
        public static async ETTask<int> RequestSkillRuneInfo(Scene root)
        {
            C2M_SkillRuneInfoRequest request = C2M_SkillRuneInfoRequest.Create();

            M2C_SkillRuneInfoResponse response = (M2C_SkillRuneInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<SkillRuneComponentC>().UpdateInfo(response.RuneList, response.SlotList);
            return response.Error;
        }

        /// <summary>
        /// 把背包里的技能符文镶到某个技能的指定孔位，响应里带回最新的技能符文数据
        /// </summary>
        public static async ETTask<int> EquipRune(Scene root, int skillId, int slotIndex, long runeId)
        {
            C2M_SkillRuneEquipRequest request = C2M_SkillRuneEquipRequest.Create();
            request.SkillId = skillId;
            request.SlotIndex = slotIndex;
            request.RuneId = runeId;

            M2C_SkillRuneEquipResponse response = (M2C_SkillRuneEquipResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<SkillRuneComponentC>().UpdateInfo(response.RuneList, response.SlotList);
            return response.Error;
        }

        /// <summary>
        /// 卸下某个技能指定孔位上的技能符文，响应里带回最新的技能符文数据
        /// </summary>
        public static async ETTask<int> UnequipRune(Scene root, int skillId, int slotIndex)
        {
            C2M_SkillRuneUnequipRequest request = C2M_SkillRuneUnequipRequest.Create();
            request.SkillId = skillId;
            request.SlotIndex = slotIndex;

            M2C_SkillRuneUnequipResponse response = (M2C_SkillRuneUnequipResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<SkillRuneComponentC>().UpdateInfo(response.RuneList, response.SlotList);
            return response.Error;
        }
    }
}
