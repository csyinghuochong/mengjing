namespace ET.Client
{
    public static class GemTalentNetHelper
    {
        /// <summary>
        /// 拉取最新的宝石天赋数据：激活状态与历史最大点数都在服务端，打开界面前调一次
        /// </summary>
        public static async ETTask<int> RequestGemTalentInfo(Scene root)
        {
            C2M_GemTalentInfoRequest request = C2M_GemTalentInfoRequest.Create();

            M2C_GemTalentInfoResponse response = (M2C_GemTalentInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<GemTalentComponentC>().UpdateGemTalentInfo(response.Info);
            return response.Error;
        }

        /// <summary>
        /// 激活宝石天赋节点，返回错误码，响应里带回最新的宝石天赋数据
        /// </summary>
        public static async ETTask<int> ActiveGemTalent(Scene root, int gemTalentId)
        {
            C2M_GemTalentActiveRequest request = C2M_GemTalentActiveRequest.Create();
            request.GemTalentId = gemTalentId;

            M2C_GemTalentActiveResponse response = (M2C_GemTalentActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<GemTalentComponentC>().UpdateGemTalentInfo(response.Info);
            return response.Error;
        }

        /// <summary>
        /// 重置宝石天赋：消耗钻石清空已激活节点，响应里带回最新的宝石天赋数据
        /// </summary>
        public static async ETTask<int> ResetGemTalent(Scene root)
        {
            C2M_GemTalentReSetRequest request = C2M_GemTalentReSetRequest.Create();

            M2C_GemTalentReSetResponse response = (M2C_GemTalentReSetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<GemTalentComponentC>().UpdateGemTalentInfo(response.Info);
            return response.Error;
        }
    }
}
