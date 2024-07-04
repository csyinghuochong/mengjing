namespace ET.Client
{
    public static class JiaYuanNetHelper
    {
        public static async ETTask<int> JiaYuanPetOperateRequest(Scene root, long petInfoId, int operate)
        {
            C2M_JiaYuanPetOperateRequest request = new() { PetInfoId = petInfoId, Operate = operate };
            M2C_JiaYuanPetOperateResponse response = (M2C_JiaYuanPetOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_JiaYuanInitResponse> JiaYuanInitRequest(Scene root, long masterId)
        {
            C2M_JiaYuanInitRequest request = new() { MasterId = masterId };
            M2C_JiaYuanInitResponse response = (M2C_JiaYuanInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> JiaYuanGatherRequest(Scene root, int cellIndex, long unitId, int operateType)
        {
            C2M_JiaYuanGatherRequest request = new() { CellIndex = cellIndex, UnitId = unitId, OperateType = operateType };
            M2C_JiaYuanGatherResponse response = (M2C_JiaYuanGatherResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> JiaYuanGatherOtherRequest(Scene root, int cellIndex, long masterId, long unitId, int operateType)
        {
            C2M_JiaYuanGatherOtherRequest request = new() { CellIndex = cellIndex, MasterId = masterId, UnitId = unitId, OperateType = operateType };
            M2C_JiaYuanGatherOtherResponse response = (M2C_JiaYuanGatherOtherResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> JiaYuanUprootRequest(Scene root, int cellIndex, long unitId, int operateType)
        {
            C2M_JiaYuanUprootRequest request = new() { CellIndex = cellIndex, UnitId = unitId, OperateType = operateType };
            M2C_JiaYuanUprootResponse response =
                    (M2C_JiaYuanUprootResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_JiaYuanPlanOpenResponse> JiaYuanPlanOpenRequest(Scene root, int cellIndex)
        {
            C2M_JiaYuanPlanOpenRequest request = new() { CellIndex = cellIndex };
            M2C_JiaYuanPlanOpenResponse response = (M2C_JiaYuanPlanOpenResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> JiaYuanPickRequest(Scene root, long unitId, long masterId)
        {
            C2M_JiaYuanPickRequest request = new() { UnitId = unitId, MasterId = masterId };
            M2C_JiaYuanPickResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_JiaYuanPickResponse;
            return response.Error;
        }

        public static async ETTask<int> JiaYuanUpLvRequest(Scene root)
        {
            C2M_JiaYuanUpLvRequest requet = new();
            M2C_JiaYuanUpLvResponse response = (M2C_JiaYuanUpLvResponse)await root.GetComponent<ClientSenderCompnent>().Call(requet);
            return response.Error;
        }

        public static async ETTask<int> JiaYuanExchangeRequest(Scene root, int exchangeType)
        {
            C2M_JiaYuanExchangeRequest request = new() { ExchangeType = exchangeType };
            M2C_JiaYuanExchangeResponse response = (M2C_JiaYuanExchangeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }
    }
}