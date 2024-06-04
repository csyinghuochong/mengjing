using System.Collections.Generic;

namespace ET.Client
{
    public static partial class PaiMaiNetHelper
    {
        public static async ETTask<P2C_PaiMaiShopShowListResponse> PaiMaiShopShowList(Scene root)
        {
            C2P_PaiMaiShopShowListRequest request = new();
            P2C_PaiMaiShopShowListResponse response =
                    (P2C_PaiMaiShopShowListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> PaiMaiShop(Scene root, int paiMaiId, int buyNum)
        {
            C2M_PaiMaiShopRequest request = new() { PaiMaiId = paiMaiId, BuyNum = buyNum };
            M2C_PaiMaiShopResponse response = (M2C_PaiMaiShopResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<P2C_PaiMaiFindResponse> PaiMaiFind(Scene root, int itemType, long paimaiItemId)
        {
            C2P_PaiMaiFindRequest reuqest = new() { ItemType = itemType, PaiMaiItemInfoId = paimaiItemId };
            P2C_PaiMaiFindResponse response = (P2C_PaiMaiFindResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            return response;
        }

        public static async ETTask<P2C_PaiMaiSearchResponse> PaiMaiSearch(Scene root, List<int> findTypeList, List<int> findItemIdList)
        {
            C2P_PaiMaiSearchRequest reuqest = new() { FindTypeList = findTypeList, FindItemIdList = findItemIdList };
            P2C_PaiMaiSearchResponse response = (P2C_PaiMaiSearchResponse)await root.GetComponent<ClientSenderCompnent>().Call(reuqest);

            return response;
        }

        public static async ETTask<P2C_PaiMaiListResponse> PaiMaiList(Scene root, int page, int paiMaiType, long userId)
        {
            C2P_PaiMaiListRequest request = new() { Page = page, PaiMaiType = paiMaiType, UserId = userId };
            P2C_PaiMaiListResponse response = (P2C_PaiMaiListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> PaiMaiXiaJia(Scene root, int itemType, long paiMaiItemInfoId)
        {
            C2M_PaiMaiXiaJiaRequest request = new() { ItemType = itemType, PaiMaiItemInfoId = paiMaiItemInfoId };
            M2C_PaiMaiXiaJiaResponse response = (M2C_PaiMaiXiaJiaResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> PaiMaiDuiHuan(Scene root, long diamondsNumber)
        {
            C2M_PaiMaiDuiHuanRequest request = new() { DiamondsNumber = diamondsNumber };
            M2C_PaiMaiDuiHuanResponse response = (M2C_PaiMaiDuiHuanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_PaiMaiBuyResponse> PaiMaiBuy(Scene root, PaiMaiItemInfo paiMaiItemInfo, int buyNum, int isRecharge)
        {
            C2M_PaiMaiBuyRequest request = new() { PaiMaiItemInfo = paiMaiItemInfo, BuyNum = buyNum, IsRecharge = isRecharge };
            M2C_PaiMaiBuyResponse response = (M2C_PaiMaiBuyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<R2C_DBServerInfoResponse> DBServerInfo(Scene root)
        {
            C2R_DBServerInfoRequest request = new();
            R2C_DBServerInfoResponse response = (R2C_DBServerInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_PaiMaiSellResponse> PaiMaiSell(Scene root, PaiMaiItemInfo paiMaiItemInfo)
        {
            C2M_PaiMaiSellRequest request = new() { PaiMaiItemInfo = paiMaiItemInfo };
            M2C_PaiMaiSellResponse response = (M2C_PaiMaiSellResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}