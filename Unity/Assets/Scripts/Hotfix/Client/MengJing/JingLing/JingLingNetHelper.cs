namespace ET.Client
{
    public static class JingLingNetHelper
    {
        public static async ETTask<int> RequestJingLingActivate(Scene root, int jingLingId)
        {
            C2M_JingLingActiveRequest request = C2M_JingLingActiveRequest.Create();
            request.JingLingId = jingLingId;

            M2C_JingLingActiveResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_JingLingActiveResponse;
            return response.Error;
        }

        public static async ETTask<int> RequestJingLingUse(Scene root, int jingLingId, int operateType)
        {
            C2M_JingLingUseRequest request = C2M_JingLingUseRequest.Create();
            request.JingLingId = jingLingId;
            request.OperateType = operateType;

            M2C_JingLingUseResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_JingLingUseResponse;
            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            ChengJiuComponentC chengJiuComponent = root.GetComponent<ChengJiuComponentC>();
            chengJiuComponent.OnFightJingLing(chengJiuComponent.GetFightJingLing() == jingLingId ? 0 : jingLingId);

            return ErrorCode.ERR_Success;
        }
        
        public static async ETTask<M2C_ZhuaBuType1Response> ZhuaBuType1Request(Scene root, long jingLingId, int itemId, string operateType)
        {
            C2M_ZhuaBuType1Request request = C2M_ZhuaBuType1Request.Create();
            request.JingLingId = jingLingId;
            request.ItemId = itemId;
            request.OperateType = operateType;

            M2C_ZhuaBuType1Response response = (M2C_ZhuaBuType1Response)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
        
        public static async ETTask<M2C_ZhuaBuType2Response> ZhuaBuType2Request(Scene root, long jingLingId, int itemId, string operateType)
        {
            C2M_ZhuaBuType2Request request = C2M_ZhuaBuType2Request.Create();
            request.JingLingId = jingLingId;
            request.ItemId = itemId;
            request.OperateType = operateType;

            M2C_ZhuaBuType2Response response = (M2C_ZhuaBuType2Response)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_FindJingLingResponse> FindJingLingRequest(Scene root)
        {
            C2M_FindJingLingRequest request = C2M_FindJingLingRequest.Create();

            M2C_FindJingLingResponse response = (M2C_FindJingLingResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
    }
}