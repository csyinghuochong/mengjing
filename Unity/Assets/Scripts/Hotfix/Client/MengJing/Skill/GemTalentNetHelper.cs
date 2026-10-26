namespace ET.Client
{
    public static class GemTalentNetHelper
    {
        /// <summary>
        /// 激活宝石天赋节点，返回错误码，成功后服务端会下发 M2C_SkillSetMessage 刷新数据
        /// </summary>
        public static async ETTask<int> ActiveGemTalent(Scene root, int gemTalentId)
        {
            C2M_GemTalentActiveRequest request = C2M_GemTalentActiveRequest.Create();
            request.GemTalentId = gemTalentId;

            M2C_GemTalentActiveResponse response =
                    (M2C_GemTalentActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        /// <summary>
        /// 重置宝石天赋：消耗钻石清空已激活节点，返回错误码
        /// </summary>
        public static async ETTask<int> ResetGemTalent(Scene root)
        {
            C2M_GemTalentReSetRequest request = C2M_GemTalentReSetRequest.Create();

            M2C_GemTalentReSetResponse response =
                    (M2C_GemTalentReSetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }
    }
}
