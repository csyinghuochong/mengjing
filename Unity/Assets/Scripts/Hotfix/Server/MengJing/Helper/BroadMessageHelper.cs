using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{
    
    public static class BroadMessageHelper
    {
        public static void SendBroadMessage(Scene root, int messageType, string message)
        {
            ActorId chatServerId = UnitCacheHelper.GetChatId(root.Zone());
            SendServerMessage(root, chatServerId, messageType, message).Coroutine();
        }

        public static async ETTask SendServerMessage(Scene root, ActorId serverid, int messageType, string message)
        {
            A2A_ServerMessageRequest A2A_ServerMessageRequest = A2A_ServerMessageRequest.Create();
            A2A_ServerMessageRequest.MessageType = messageType;
            A2A_ServerMessageRequest.MessageValue = message;
            A2A_ServerMessageRResponse g_SendChatRequest = (A2A_ServerMessageRResponse)await root.GetComponent<MessageSender>().Call
            (serverid, A2A_ServerMessageRequest);
        }

        /// <summary>
        /// 一般是做全服操作
        /// </summary>
        /// <returns></returns>
        public static List<int> GetAllZone()
        {
            List<int> zoneList = new List<int> { };
            List<StartZoneConfig> listprogress = StartZoneConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < listprogress.Count; i++)
            {
                if (listprogress[i].Id >= CommonHelp.MaxZone || ConfigData.InnerZoneList.Contains(listprogress[i].Id))
                {
                    continue;
                }
                if (!StartSceneConfigCategory.Instance.Gates.ContainsKey(listprogress[i].Id))
                {
                    continue;
                }
                zoneList.Add(listprogress[i].Id);
            }
            return zoneList;
        }
        
        public static async ETTask NoticeUnionLeader(Scene root, long unitid, int leader)
        {
            U2M_UnionTransferResult u2M_UnionTransferMessage = U2M_UnionTransferResult.Create();
            u2M_UnionTransferMessage.UnionLeader = leader;
            M2U_UnionTransferResult m2UUnionTransferResult = (M2U_UnionTransferResult)await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(unitid, u2M_UnionTransferMessage);
            if (m2UUnionTransferResult.Error != ErrorCode.ERR_Success)
            {
                NumericComponentS numericComponent_3 = await UnitCacheHelper.GetComponentCache<NumericComponentS>(root, unitid);
                numericComponent_3.ApplyValue(NumericType.UnionLeader, leader, false);
                UnitCacheHelper.SaveComponentCache(root, numericComponent_3).Coroutine();
            }
        }
        
    }
    
}

