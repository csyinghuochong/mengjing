using System;
using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof (BagComponentClient))]
    public static class BagClientHelper
    {
        public static async ETTask<int> RequestBagInit(Scene root)
        {
            Log.Debug($"C2M_BagInitHandler: client0");
            M2C_BagInitResponse response = (M2C_BagInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(new C2M_BagInitRequest());

            BagComponentClient bagComponentClient = root.GetComponent<BagComponentClient>();
            for (int i = 0; i < response.BagInfos.Count; i++)
            {
                int Loc = response.BagInfos[i].Loc;
                List<BagInfo> bagList = bagComponentClient.AllItemList[Loc];
                bagList.Add(response.BagInfos[i]);
            }

            Log.Debug($"C2M_BagInitHandler: client1");
            return ErrorCode.ERR_Success;
        }
    }
}