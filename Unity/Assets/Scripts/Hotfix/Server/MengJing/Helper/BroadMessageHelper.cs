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
    }
    
}

