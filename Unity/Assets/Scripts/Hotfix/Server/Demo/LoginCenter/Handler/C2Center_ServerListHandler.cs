using System;
using System.Collections;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageSessionHandler(SceneType.Realm)]
    public class C2Center_ServerListHandler: MessageSessionHandler<C2Center_ServerList, Center2C_ServerList>
    {
        protected override async ETTask Run(Session session, C2Center_ServerList request, Center2C_ServerList response)
        {
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect().Coroutine();
                return;
            }
            
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.GetServerList, 0))
                {
                    long serverTime = TimeHelper.ServerNow();
                    List<ServerItem> serverItems = ServerHelper.GetServerList(VersionMode.Beta);
                    response.ServerItems.Clear();
                    for (int i = 0; i < serverItems.Count; i++)
                    {
                        if (serverItems[i].Show != 0 && serverItems[i].ServerOpenTime <= serverTime)
                        {
                            response.ServerItems.Add(serverItems[i]);
                        }
                    }
                    
                    string[] stringxxx = LogHelper.GetNoticeNew().Split('@');
                    response.NoticeVersion = stringxxx[0];
                    response.NoticeText = stringxxx[1];
                }
            } 
            Console.WriteLine("R2C_ServerList Handler");
            await ETTask.CompletedTask;
        }
    }
    
}