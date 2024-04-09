namespace ET.Client
{
    public static class JingLingNetHelper
    {
        public static async ETTask<int> RequestJingLingUse(Scene root, int jingLingId, int operateType)
        {
            C2M_JingLingUseRequest request = new() { JingLingId = jingLingId, OperateType = operateType };
            M2C_JingLingUseResponse response =
                    await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_JingLingUseResponse;
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            ChengJiuComponentC chengJiuComponent = root.GetComponent<ChengJiuComponentC>();
            chengJiuComponent.JingLingId = response.JingLingId;
            return ErrorCode.ERR_Success;
        }
    }
}