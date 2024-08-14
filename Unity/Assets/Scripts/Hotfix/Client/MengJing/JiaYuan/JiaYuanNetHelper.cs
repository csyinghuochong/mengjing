using System.Collections.Generic;

namespace ET.Client
{
    public static class JiaYuanNetHelper
    {
        public static async ETTask<int> JiaYuanPetOperateRequest(Scene root, long petInfoId, int operate)
        {
            C2M_JiaYuanPetOperateRequest request = C2M_JiaYuanPetOperateRequest.Create();
            request.PetInfoId = petInfoId;
            request.Operate = operate;

            M2C_JiaYuanPetOperateResponse response = (M2C_JiaYuanPetOperateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_JiaYuanInitResponse> JiaYuanInitRequest(Scene root, long masterId)
        {
            C2M_JiaYuanInitRequest request = C2M_JiaYuanInitRequest.Create();
            request.MasterId = masterId;

            M2C_JiaYuanInitResponse response = (M2C_JiaYuanInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> JiaYuanGatherRequest(Scene root, int cellIndex, long unitId, int operateType)
        {
            C2M_JiaYuanGatherRequest request = C2M_JiaYuanGatherRequest.Create();
            request.CellIndex = cellIndex;
            request.UnitId = unitId;
            request.OperateType = operateType;

            M2C_JiaYuanGatherResponse response = (M2C_JiaYuanGatherResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> JiaYuanGatherOtherRequest(Scene root, int cellIndex, long masterId, long unitId, int operateType)
        {
            C2M_JiaYuanGatherOtherRequest request = C2M_JiaYuanGatherOtherRequest.Create();
            request.CellIndex = cellIndex;
            request.MasterId = masterId;
            request.UnitId = unitId;
            request.OperateType = operateType;

            M2C_JiaYuanGatherOtherResponse response = (M2C_JiaYuanGatherOtherResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_JiaYuanUprootResponse> JiaYuanUprootRequest(Scene root, int cellIndex, long unitId, int operateType)
        {
            C2M_JiaYuanUprootRequest request = C2M_JiaYuanUprootRequest.Create();
            request.CellIndex = cellIndex;
            request.UnitId = unitId;
            request.OperateType = operateType;

            M2C_JiaYuanUprootResponse response = (M2C_JiaYuanUprootResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPlanOpenResponse> JiaYuanPlanOpenRequest(Scene root, int cellIndex)
        {
            C2M_JiaYuanPlanOpenRequest request = C2M_JiaYuanPlanOpenRequest.Create();
            request.CellIndex = cellIndex;

            M2C_JiaYuanPlanOpenResponse response = (M2C_JiaYuanPlanOpenResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> JiaYuanPickRequest(Scene root, long unitId, long masterId)
        {
            C2M_JiaYuanPickRequest request = C2M_JiaYuanPickRequest.Create();
            request.UnitId = unitId;
            request.MasterId = masterId;

            M2C_JiaYuanPickResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_JiaYuanPickResponse;
            return response.Error;
        }

        public static async ETTask<int> JiaYuanUpLvRequest(Scene root)
        {
            C2M_JiaYuanUpLvRequest requet = C2M_JiaYuanUpLvRequest.Create();

            M2C_JiaYuanUpLvResponse response = (M2C_JiaYuanUpLvResponse)await root.GetComponent<ClientSenderCompnent>().Call(requet);
            return response.Error;
        }

        public static async ETTask<int> JiaYuanExchangeRequest(Scene root, int exchangeType)
        {
            C2M_JiaYuanExchangeRequest request = C2M_JiaYuanExchangeRequest.Create();
            request.ExchangeType = exchangeType;

            M2C_JiaYuanExchangeResponse response = (M2C_JiaYuanExchangeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> JiaYuanPlantRequest(Scene root, int cellIndex, int itemId)
        {
            C2M_JiaYuanPlantRequest request = C2M_JiaYuanPlantRequest.Create();
            request.CellIndex = cellIndex;
            request.ItemId = itemId;

            M2C_JiaYuanPlantResponse response = (M2C_JiaYuanPlantResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_JiaYuanRecordListResponse> JiaYuanRecordListRequest(Scene root)
        {
            C2M_JiaYuanRecordListRequest request = C2M_JiaYuanRecordListRequest.Create();

            M2C_JiaYuanRecordListResponse response = (M2C_JiaYuanRecordListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanDaShiResponse> JiaYuanDaShiRequest(Scene root, List<long> bagInfoIDs)
        {
            C2M_JiaYuanDaShiRequest request = C2M_JiaYuanDaShiRequest.Create();
            request.BagInfoIDs = bagInfoIDs;

            M2C_JiaYuanDaShiResponse response = (M2C_JiaYuanDaShiResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPurchaseRefresh> JiaYuanPurchaseRefresh(Scene root)
        {
            C2M_JiaYuanPurchaseRefresh request = C2M_JiaYuanPurchaseRefresh.Create();

            M2C_JiaYuanPurchaseRefresh response = (M2C_JiaYuanPurchaseRefresh)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPurchaseResponse> JiaYuanPurchaseRequest(Scene root, int itemId, int purchaseId)
        {
            C2M_JiaYuanPurchaseRequest request = C2M_JiaYuanPurchaseRequest.Create();
            request.ItemId = itemId;
            request.PurchaseId = purchaseId;

            M2C_JiaYuanPurchaseResponse response = (M2C_JiaYuanPurchaseResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanCookResponse> JiaYuanCookRequest(Scene root, List<long> bagInfoIds)
        {
            C2M_JiaYuanCookRequest request = C2M_JiaYuanCookRequest.Create();
            request.BagInfoIds = bagInfoIds;

            M2C_JiaYuanCookResponse response = (M2C_JiaYuanCookResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanCookBookOpen> JiaYuanCookBookOpen(Scene root, int learnMakeId)
        {
            C2M_JiaYuanCookBookOpen request = C2M_JiaYuanCookBookOpen.Create();
            request.LearnMakeId = learnMakeId;

            M2C_JiaYuanCookBookOpen response = (M2C_JiaYuanCookBookOpen)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanMysteryBuyResponse> JiaYuanMysteryBuyRequest(Scene root, int mysteryId, int productId)
        {
            C2M_JiaYuanMysteryBuyRequest request = C2M_JiaYuanMysteryBuyRequest.Create();
            request.MysteryId = mysteryId;
            request.ProductId = productId;

            M2C_JiaYuanMysteryBuyResponse response = (M2C_JiaYuanMysteryBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanMysteryListResponse> JiaYuanMysteryListRequest(Scene root, int npcID)
        {
            C2M_JiaYuanMysteryListRequest request = C2M_JiaYuanMysteryListRequest.Create();
            request.NpcID = npcID;

            M2C_JiaYuanMysteryListResponse response = (M2C_JiaYuanMysteryListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPastureBuyResponse> JiaYuanPastureBuyRequest(Scene root, int mysteryId, int productId)
        {
            C2M_JiaYuanPastureBuyRequest request = C2M_JiaYuanPastureBuyRequest.Create();
            request.MysteryId = mysteryId;
            request.ProductId = productId;

            M2C_JiaYuanPastureBuyResponse response = (M2C_JiaYuanPastureBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPastureListResponse> JiaYuanPastureListRequest(Scene root)
        {
            C2M_JiaYuanPastureListRequest request = C2M_JiaYuanPastureListRequest.Create();

            M2C_JiaYuanPastureListResponse response = (M2C_JiaYuanPastureListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> JiaYuanStoreRequest(Scene root, int horseId)
        {
            C2M_JiaYuanStoreRequest request = C2M_JiaYuanStoreRequest.Create();
            request.HorseId = horseId;

            M2C_JiaYuanStoreResponse response = (M2C_JiaYuanStoreResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> PetPutCangKu(Scene root, long petInfoId, int petStatus)
        {
            C2M_PetPutCangKu request = C2M_PetPutCangKu.Create();
            request.PetInfoId = petInfoId;
            request.PetStatus = petStatus;

            M2C_PetPutCangKu response = (M2C_PetPutCangKu)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> PetOpenCangKu(Scene root, int openIndex)
        {
            C2M_PetOpenCangKu request = C2M_PetOpenCangKu.Create();
            request.OpenIndex = openIndex;

            M2C_PetOpenCangKu response = (M2C_PetOpenCangKu)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<M2C_JiaYuanWatchResponse> JiaYuanWatchRequest(Scene root, long masterId, long operateId)
        {
            C2M_JiaYuanWatchRequest request = C2M_JiaYuanWatchRequest.Create();
            request.MasterId = masterId;
            request.OperateId = operateId;

            M2C_JiaYuanWatchResponse response = (M2C_JiaYuanWatchResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPetFeedResponse> JiaYuanPetFeedRequest(Scene root, long petId, List<long> bagInfoIDs)
        {
            C2M_JiaYuanPetFeedRequest request = C2M_JiaYuanPetFeedRequest.Create();
            request.PetId = petId;
            request.BagInfoIDs = bagInfoIDs;

            M2C_JiaYuanPetFeedResponse response = (M2C_JiaYuanPetFeedResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanVisitListResponse> JiaYuanVisitListRequest(Scene root, long masterId, long unitId, int operateType)
        {
            C2M_JiaYuanVisitListRequest request = C2M_JiaYuanVisitListRequest.Create();
            request.MasterId = masterId;
            request.UnitId = unitId;
            request.OperateType = operateType;

            M2C_JiaYuanVisitListResponse response = (M2C_JiaYuanVisitListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_JiaYuanPetPositionResponse> JiaYuanPetPositionRequest(Scene root, long masterId)
        {
            C2M_JiaYuanPetPositionRequest request = C2M_JiaYuanPetPositionRequest.Create();
            request.MasterId = masterId;

            M2C_JiaYuanPetPositionResponse response = (M2C_JiaYuanPetPositionResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
    }
}