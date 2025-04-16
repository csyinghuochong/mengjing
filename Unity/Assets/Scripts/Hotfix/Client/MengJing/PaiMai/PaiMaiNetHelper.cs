using System.Collections.Generic;

namespace ET.Client
{
    public static partial class PaiMaiNetHelper
    {
        public static async ETTask<P2C_PaiMaiShopShowListResponse> PaiMaiShopShowList(Scene root)
        {
            C2P_PaiMaiShopShowListRequest request = C2P_PaiMaiShopShowListRequest.Create();

            P2C_PaiMaiShopShowListResponse response = (P2C_PaiMaiShopShowListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> PaiMaiShop(Scene root, int paiMaiId, int buyNum)
        {
            C2M_PaiMaiShopRequest request = C2M_PaiMaiShopRequest.Create();
            request.PaiMaiId = paiMaiId;
            request.BuyNum = buyNum;

            M2C_PaiMaiShopResponse response = (M2C_PaiMaiShopResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<P2C_PaiMaiFindResponse> PaiMaiFind(Scene root, int itemType, long paimaiItemId)
        {
            C2P_PaiMaiFindRequest reuqest = C2P_PaiMaiFindRequest.Create();
            reuqest.ItemType = itemType;
            reuqest.PaiMaiItemInfoId = paimaiItemId;

            P2C_PaiMaiFindResponse response = (P2C_PaiMaiFindResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            return response;
        }

        public static async ETTask<P2C_PaiMaiSearchResponse> PaiMaiSearch(Scene root, List<int> findTypeList, List<int> findItemIdList)
        {
            C2P_PaiMaiSearchRequest reuqest = C2P_PaiMaiSearchRequest.Create();
            reuqest.FindTypeList = findTypeList;
            reuqest.FindItemIdList = findItemIdList;

            P2C_PaiMaiSearchResponse response = (P2C_PaiMaiSearchResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            return response;
        }

        public static async ETTask<P2C_PaiMaiListResponse> PaiMaiList(Scene root, int page, int paiMaiType, long userId)
        {
            C2P_PaiMaiListRequest request = C2P_PaiMaiListRequest.Create();
            request.Page = page;
            request.PaiMaiType = paiMaiType;
            request.UserId = userId;

            P2C_PaiMaiListResponse response = (P2C_PaiMaiListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> PaiMaiXiaJia(Scene root, int itemType, long paiMaiItemInfoId)
        {
            C2M_PaiMaiXiaJiaRequest request = C2M_PaiMaiXiaJiaRequest.Create();
            request.ItemType = itemType;
            request.PaiMaiItemInfoId = paiMaiItemInfoId;

            M2C_PaiMaiXiaJiaResponse response = (M2C_PaiMaiXiaJiaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> PaiMaiDuiHuan(Scene root, long diamondsNumber)
        {
            C2M_PaiMaiDuiHuanRequest request = C2M_PaiMaiDuiHuanRequest.Create();
            request.DiamondsNumber = diamondsNumber;

            M2C_PaiMaiDuiHuanResponse response = (M2C_PaiMaiDuiHuanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_PaiMaiBuyResponse> PaiMaiBuy(Scene root, PaiMaiItemInfo paiMaiItemInfo, int buyNum, int isRecharge)
        {
            C2M_PaiMaiBuyRequest request = C2M_PaiMaiBuyRequest.Create();
            request.PaiMaiItemInfo = paiMaiItemInfo;
            request.BuyNum = buyNum;
            request.IsRecharge = isRecharge;

            M2C_PaiMaiBuyResponse response = (M2C_PaiMaiBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
        
        public static async ETTask<M2C_PaiMaiBuyNewResponse> PaiMaiBuyNew(Scene root, PaiMaiItemInfo paiMaiItemInfo, int buyNum, int isRecharge)
        {
            C2M_PaiMaiBuyNewRequest request = C2M_PaiMaiBuyNewRequest.Create();

            request.PaiMaiItemInfoId = paiMaiItemInfo.Id;
            request.Price = paiMaiItemInfo.Price;
            request.ItemNum = paiMaiItemInfo.BagInfo.ItemNum;
            request.ItemId = paiMaiItemInfo.BagInfo.ItemID;
            request.BuyNum = buyNum;
            request.IsRecharge = isRecharge;
            
            M2C_PaiMaiBuyNewResponse response = (M2C_PaiMaiBuyNewResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
        
            return response;
        }
        
        public static async ETTask<M2C_PaiMaiSellResponse> PaiMaiSell(Scene root, PaiMaiItemInfo paiMaiItemInfo)
        {
            C2M_PaiMaiSellRequest request = C2M_PaiMaiSellRequest.Create();
            request.PaiMaiItemInfo = paiMaiItemInfo;

            M2C_PaiMaiSellResponse response = (M2C_PaiMaiSellResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<R2C_DBServerInfoResponse> DBServerInfo(Scene root)
        {
            C2R_DBServerInfoRequest request = C2R_DBServerInfoRequest.Create();

            R2C_DBServerInfoResponse response = (R2C_DBServerInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
        
        public static async ETTask<P2C_PaiMaiAuctionRecordResponse> PaiMaiAuctionRecord(Scene root)
        {
            C2P_PaiMaiAuctionRecordRequest request = C2P_PaiMaiAuctionRecordRequest.Create();

            P2C_PaiMaiAuctionRecordResponse response = (P2C_PaiMaiAuctionRecordResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}