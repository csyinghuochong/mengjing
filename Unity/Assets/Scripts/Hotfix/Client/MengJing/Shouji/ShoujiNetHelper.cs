using System.Collections.Generic;

namespace ET.Client
{
    public static partial class ShoujiNetHelper
    {
        public static async ETTask<M2C_ShouJiTreasureResponse> ShouJiTreasure(Scene root, List<long> itemIds, int shouJiId)
        {
            C2M_ShouJiTreasureRequest request = new() { ItemIds = itemIds, ShouJiId = shouJiId };
            M2C_ShouJiTreasureResponse response = (M2C_ShouJiTreasureResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}