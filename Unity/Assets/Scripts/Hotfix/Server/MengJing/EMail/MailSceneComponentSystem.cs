namespace ET.Server
{


    [EntitySystemOf(typeof(MailSceneComponent))]
    [FriendOf(typeof(MailSceneComponent))]
    public static partial class MailSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MailSceneComponent self)
        {
            self.InitServerInfo().Coroutine();

            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(TimeHelper.Hour * 10 + self.Zone() * 1000, TimerInvokeType.MailSceneTimer, self);
        }
        
        public static async ETTask InitServerInfo(this MailSceneComponent self)
        {
           
            await self.Root().GetComponent<TimerComponent>().WaitAsync( RandomHelper.RandomNumber(4000,10000) );
            DBServerMailInfo dBServerInfo = await UnitCacheHelper.GetComponent<DBServerMailInfo>( self.Root(), self.Zone() );
            if (dBServerInfo == null)
            {
                dBServerInfo = self.AddChildWithId<DBServerMailInfo>(self.Zone());
            }
            self.dBServerMailInfo = dBServerInfo;
            self.SaveDB().Coroutine();
        }

        public static int GetMaxMaild(this MailSceneComponent self)
        {
            int maxId = 0; 
            foreach ((int id, ServerMailItem ServerItem) in self.dBServerMailInfo.ServerMailList)
            {
                if (id >= maxId)
                {
                    maxId = id;
                }
            }
            return maxId;
        }

        public static async ETTask<int> OnLogin(this MailSceneComponent self, long unitid, int curmailid)
        {
            //检测没有发送的邮件
            foreach ((int id, ServerMailItem ServerItem) in self.dBServerMailInfo.ServerMailList)
            {
                if (curmailid >= id)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(ServerItem.ParasmNew))
                {
                    await  MailHelp.ServerMailItem(self.Root(), unitid, ServerItem);
                }
        
                curmailid = id;
            }
            return curmailid;
        }


        public static async ETTask SaveDB(this MailSceneComponent self)
        {
            await UnitCacheHelper.SaveComponent(self.Root(), self.Zone(), self.dBServerMailInfo);
        }
    }

}