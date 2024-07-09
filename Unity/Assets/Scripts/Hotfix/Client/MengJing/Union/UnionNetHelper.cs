using System.Collections.Generic;

namespace ET.Client
{
    public static partial class UnionNetHelper
    {
        public static async ETTask<U2C_UnionApplyResponse> UnionApply(Scene root, long unionId, long userId)
        {
            C2U_UnionApplyRequest request = new() { UnionId = unionId, UserId = userId };
            U2C_UnionApplyResponse response = (U2C_UnionApplyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionListResponse> UnionList(Scene root)
        {
            C2U_UnionListRequest request = new();
            U2C_UnionListResponse response = (U2C_UnionListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_UnionCreateResponse> UnionCreate(Scene root, string unionName, string unionPurpose)
        {
            C2M_UnionCreateRequest request = new() { UnionName = unionName, UnionPurpose = unionPurpose };
            M2C_UnionCreateResponse response = (M2C_UnionCreateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionOperatateResponse> UnionOperatate(Scene root, long unionId, int operatate, string value)
        {
            C2U_UnionOperatateRequest request = new() { UnionId = unionId, Operatate = operatate, Value = value };
            U2C_UnionOperatateResponse response = (U2C_UnionOperatateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<M2C_UnionLeaveResponse> UnionLeave(Scene root)
        {
            C2M_UnionLeaveRequest request = new();
            M2C_UnionLeaveResponse response = (M2C_UnionLeaveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionMyInfoResponse> UnionMyInfo(Scene root, long unionId)
        {
            C2U_UnionMyInfoRequest request = new() { UnionId = unionId };
            U2C_UnionMyInfoResponse response = (U2C_UnionMyInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_DonationRankListResponse> DonationRankListRequest(Scene root)
        {
            C2U_DonationRankListRequest request = new();
            U2C_DonationRankListResponse response = (U2C_DonationRankListResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionSignUpResponse> UnionSignUpRequest(Scene root, long unionId)
        {
            C2U_UnionSignUpRequest request = new() { UnionId = unionId };
            U2C_UnionSignUpResponse response = (U2C_UnionSignUpResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionRaceInfoResponse> UnionRaceInfoRequest(Scene root)
        {
            C2U_UnionRaceInfoRequest request = new();
            U2C_UnionRaceInfoResponse response = (U2C_UnionRaceInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<int> UnionDonationRequest(Scene root, int type)
        {
            C2M_UnionDonationRequest request = new() { Type = type };
            M2C_UnionDonationResponse response = (M2C_UnionDonationResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<U2C_UnionRecordResponse> UnionRecordRequest(Scene root, long unionId)
        {
            C2U_UnionRecordRequest request = new() { UnionId = unionId };
            U2C_UnionRecordResponse response = (U2C_UnionRecordResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionMysteryListResponse> UnionMysteryListRequest(Scene root, long unionId)
        {
            C2U_UnionMysteryListRequest request = new() { UnionId = unionId };
            U2C_UnionMysteryListResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as U2C_UnionMysteryListResponse;
            return response;
        }

        public static async ETTask<int> UnionMysteryBuyRequest(Scene root, int mysteryId, int buyNumber)
        {
            C2M_UnionMysteryBuyRequest request = new() { MysteryId = mysteryId, BuyNumber = buyNumber };
            M2C_UnionMysteryBuyResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_UnionMysteryBuyResponse;
            return response.Error;
        }

        public static async ETTask<U2C_UnionKeJiQuickResponse> UnionKeJiQuickRequest(Scene root, long unionId, int position)
        {
            C2U_UnionKeJiQuickRequest request = new() { UnionId = unionId, Position = position };
            U2C_UnionKeJiQuickResponse response = (U2C_UnionKeJiQuickResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask<U2C_UnionKeJiActiteResponse> UnionKeJiActiteRequest(Scene root, long unionId, int position)
        {
            C2U_UnionKeJiActiteRequest request = new() { UnionId = unionId, Position = position };
            U2C_UnionKeJiActiteResponse response = (U2C_UnionKeJiActiteResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }
    }
}