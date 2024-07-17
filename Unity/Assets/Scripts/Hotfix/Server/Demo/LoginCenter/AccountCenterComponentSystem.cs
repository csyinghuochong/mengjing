using System.Collections.Generic;

namespace ET.Server
{


    [EntitySystemOf(typeof(AccountCenterComponent))]
    [FriendOf(typeof(AccountCenterComponent))]
    [FriendOf(typeof(DBCenterSerialInfo))]
    public static partial class AccountCenterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this AccountCenterComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this AccountCenterComponent self)
        {

        }

        
         public static int GetSerialKeyId(this AccountCenterComponent self, string serial)
         {
             DBCenterSerialInfo dBCenterSerialInfo = self.DBCenterSerialInfo;
             for (int i = 0; i < dBCenterSerialInfo.SerialList.Count; i++)
             {
                 if (dBCenterSerialInfo.SerialList[i].Value != serial)
                 {
                     continue;
                 }

                 return dBCenterSerialInfo.SerialList[i].KeyId ;
             }
             return 1;
         }

         
         public static int GetSerialReward(this AccountCenterComponent self, string serial)
         {
             DBCenterSerialInfo dBCenterSerialInfo = self.DBCenterSerialInfo;
             for (int i = dBCenterSerialInfo.SerialList.Count - 1; i >= 0; i--)
             {
                 if (dBCenterSerialInfo.SerialList[i].Value != serial)
                 {
                     continue;
                 }
                 if (dBCenterSerialInfo.SerialList[i].Value2 == "1")
                 {
                     return ErrorCode.ERR_AlreadyReceived;
                 }

                 dBCenterSerialInfo.SerialList[i].Value2 = "1";
                 return ErrorCode.ERR_Success;
             }
             return ErrorCode.ERR_SerialNoExist;
         }

         public static async ETTask InitDBRankInfo(this AccountCenterComponent self)
         {
             DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone());
             List<DBCenterSerialInfo> d2GGetUnit = await dbComponent.Query<DBCenterSerialInfo>(self.Zone(), _account => _account.Id == self.Zone());
             if (d2GGetUnit.Count == 0)
             {
                 self.DBCenterSerialInfo = self.AddComponentWithId<DBCenterSerialInfo>(self.Zone());
             }
             else
             {
                 self.DBCenterSerialInfo = d2GGetUnit[0];
             }

             self.SaveDB().Coroutine();
         }

         public static void UpdateTianQi(this AccountCenterComponent self)
         {
             int[] rand = { 95, 4, 1 };
             int index = RandomHelper.RandomByWeight(rand);
             switch (index)
             {
                 case 0:
                     self.TianQiValue = 0;
                     break;
                 case 1:
                     self.TianQiValue = 1;
                     break;
                 case 2:
                     self.TianQiValue = 2;
                     break;
             }
         }

         public static async ETTask SaveDB(this AccountCenterComponent self)
         {
             DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone());
             await dbComponent.Save<DBCenterSerialInfo>(self.Zone(), self.DBCenterSerialInfo);

             self.TianQITime++;
             if (self.TianQITime >= 12)
             {
                 self.TianQITime = 0;
                 //self.TianQiValue = RandomHelper.RandomNumber(1, 3);
                 self.UpdateTianQi();

                 // List<int> zones = ServerMessageHelper.GetAllZone();
                 // for (int i = 0; i < zones.Count; i++)
                 // {
                 //     long chatServerId = StartSceneConfigCategory.Instance.GetBySceneName(zones[i], "Chat").InstanceId;
                 //     A2A_ServerMessageRResponse g_SendChatRequest = (A2A_ServerMessageRResponse)await ActorMessageSenderComponent.Instance.Call
                 //         (chatServerId, new A2A_ServerMessageRequest()
                 //         {
                 //             MessageType = NoticeType.TianQiChange,
                 //             MessageValue = self.TianQiValue.ToString(),
                 //         });
                 //
                 //     await TimerComponent.Instance.WaitAsync(10000);
                 // }
             }
         }
    }

}