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
    }
}