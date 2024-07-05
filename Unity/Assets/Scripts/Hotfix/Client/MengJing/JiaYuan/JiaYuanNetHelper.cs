using System.Collections.Generic;

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

        public static async ETTask<int> JiaYuanPlantRequest(Scene root, int cellIndex, int itemId)
        {
            C2M_JiaYuanPlantRequest request = new() { CellIndex = cellIndex, ItemId = itemId };
            M2C_JiaYuanPlantResponse response = (M2C_JiaYuanPlantResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_JiaYuanRecordListResponse> JiaYuanRecordListRequest(Scene root)
        {
            C2M_JiaYuanRecordListRequest request = new();
            M2C_JiaYuanRecordListResponse response = (M2C_JiaYuanRecordListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanDaShiResponse> JiaYuanDaShiRequest(Scene root, List<long> bagInfoIDs)
        {
            C2M_JiaYuanDaShiRequest request = new() { BagInfoIDs = bagInfoIDs };
            M2C_JiaYuanDaShiResponse response = (M2C_JiaYuanDaShiResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPurchaseRefresh> JiaYuanPurchaseRefresh(Scene root)
        {
            C2M_JiaYuanPurchaseRefresh request = new();
            M2C_JiaYuanPurchaseRefresh response = (M2C_JiaYuanPurchaseRefresh)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPurchaseResponse> JiaYuanPurchaseRequest(Scene root, int itemId, int purchaseId)
        {
            C2M_JiaYuanPurchaseRequest request = new() { ItemId = itemId, PurchaseId = purchaseId };
            M2C_JiaYuanPurchaseResponse response =
                    (M2C_JiaYuanPurchaseResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanCookResponse> JiaYuanCookRequest(Scene root, List<long> bagInfoIds)
        {
            C2M_JiaYuanCookRequest request = new() { BagInfoIds = bagInfoIds };
            M2C_JiaYuanCookResponse response = (M2C_JiaYuanCookResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanCookBookOpen> JiaYuanCookBookOpen(Scene root, int learnMakeId)
        {
            C2M_JiaYuanCookBookOpen request = new() { LearnMakeId = learnMakeId };
            M2C_JiaYuanCookBookOpen response = (M2C_JiaYuanCookBookOpen)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanMysteryBuyResponse> JiaYuanMysteryBuyRequest(Scene root, int mysteryId, int productId)
        {
            C2M_JiaYuanMysteryBuyRequest request = new() { MysteryId = mysteryId, ProductId = productId };
            M2C_JiaYuanMysteryBuyResponse response = (M2C_JiaYuanMysteryBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanMysteryListResponse> JiaYuanMysteryListRequest(Scene root, int npcID)
        {
            C2M_JiaYuanMysteryListRequest request = new() { NpcID = npcID };
            M2C_JiaYuanMysteryListResponse response = (M2C_JiaYuanMysteryListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPastureBuyResponse> JiaYuanPastureBuyRequest(Scene root, int mysteryId, int productId)
        {
            C2M_JiaYuanPastureBuyRequest request = new() { MysteryId = mysteryId, ProductId = productId };
            M2C_JiaYuanPastureBuyResponse response = (M2C_JiaYuanPastureBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPastureListResponse> JiaYuanPastureListRequest(Scene root)
        {
            C2M_JiaYuanPastureListRequest request = new();
            M2C_JiaYuanPastureListResponse response = (M2C_JiaYuanPastureListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
    }
}