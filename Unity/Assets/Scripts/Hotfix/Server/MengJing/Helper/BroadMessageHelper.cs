using System.Linq;
using System.Collections.Generic;


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
            A2A_ServerMessageRResponse g_SendChatRequest = (A2A_ServerMessageRResponse)await root.GetComponent<MessageSender>().Call
            (serverid, new A2A_ServerMessageRequest()
            {
                MessageType = messageType,
                MessageValue = message
            });
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
                if (listprogress[i].Id >= ComHelp.MaxZone || ConfigData.InnerZoneList.Contains(listprogress[i].Id))
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
            ActorId gateServerId = UnitCacheHelper.GetGateServerId(root.Zone());
            G2T_GateUnitInfoResponse g2M_UpdateUnitResponse_3 = (G2T_GateUnitInfoResponse)await root.GetComponent<MessageSender>().Call
            (gateServerId, new T2G_GateUnitInfoRequest()
            {
                UserID = unitid
            });
            if (g2M_UpdateUnitResponse_3.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse_3.SessionInstanceId > 0)
            {
                root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitid, new M2M_UnionTransferMessage() { UnionLeader = leader });
            }
            else
            {
                NumericComponentS numericComponent_3 = await UnitCacheHelper.GetComponentCache<NumericComponentS>(root, unitid);
                numericComponent_3.ApplyValue(NumericType.UnionLeader, leader, false);
                UnitCacheHelper.SaveComponentCache(root, numericComponent_3).Coroutine();
            }

        }
        
    }
    
}

