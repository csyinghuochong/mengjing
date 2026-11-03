using System.Collections.Generic;

namespace ET.Client
{
    public static class RuneNetHelper
    {
        /// <summary>
        /// 拉一次最新的符文数据：登录时在 LoginGameAsync 里调，开界面前也可以再调一次
        /// </summary>
        public static async ETTask<int> RequestRuneInfo(Scene root)
        {
            C2M_RuneInfoRequest request = C2M_RuneInfoRequest.Create();

            M2C_RuneInfoResponse response = (M2C_RuneInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<RuneComponentC>().UpdateRuneInfo(response.Info);
            return response.Error;
        }

        /// <summary>
        /// 开启孔位，响应里带回最新的符文数据
        /// </summary>
        public static async ETTask<int> UnlockSlot(Scene root, int slotId)
        {
            C2M_RuneUnlockSlotRequest request = C2M_RuneUnlockSlotRequest.Create();
            request.SlotId = slotId;

            M2C_RuneUnlockSlotResponse response = (M2C_RuneUnlockSlotResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<RuneComponentC>().UpdateRuneInfo(response.Info);
            return response.Error;
        }

        /// <summary>
        /// 镶嵌符文，响应里带回最新的符文数据
        /// </summary>
        public static async ETTask<int> SocketRune(Scene root, int slotId, long runeId)
        {
            C2M_RuneSocketRequest request = C2M_RuneSocketRequest.Create();
            request.SlotId = slotId;
            request.RuneId = runeId;

            M2C_RuneSocketResponse response = (M2C_RuneSocketResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<RuneComponentC>().UpdateRuneInfo(response.Info);
            return response.Error;
        }

        /// <summary>
        /// 拆卸符文，响应里带回最新的符文数据
        /// </summary>
        public static async ETTask<int> UnsocketRune(Scene root, int slotId)
        {
            C2M_RuneUnsocketRequest request = C2M_RuneUnsocketRequest.Create();
            request.SlotId = slotId;

            M2C_RuneUnsocketResponse response = (M2C_RuneUnsocketResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<RuneComponentC>().UpdateRuneInfo(response.Info);
            return response.Error;
        }

        /// <summary>
        /// 升级符文，镶嵌中的也能升，响应里带回最新的符文数据
        /// </summary>
        public static async ETTask<int> UpgradeRune(Scene root, long runeId)
        {
            C2M_RuneUpgradeRequest request = C2M_RuneUpgradeRequest.Create();
            request.RuneId = runeId;

            M2C_RuneUpgradeResponse response = (M2C_RuneUpgradeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<RuneComponentC>().UpdateRuneInfo(response.Info);
            return response.Error;
        }

        /// <summary>
        /// 批量分解符文，一次可以分解多枚，只能分解背包里的，响应里带回最新的符文数据
        /// </summary>
        public static async ETTask<int> DecomposeRunes(Scene root, List<long> runeIds)
        {
            C2M_RuneDecomposeRequest request = C2M_RuneDecomposeRequest.Create();
            request.RuneIds.AddRange(runeIds);

            M2C_RuneDecomposeResponse response = (M2C_RuneDecomposeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<RuneComponentC>().UpdateRuneInfo(response.Info);
            return response.Error;
        }
    }
}
