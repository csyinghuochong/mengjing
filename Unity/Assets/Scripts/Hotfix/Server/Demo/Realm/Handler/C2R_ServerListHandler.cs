using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageSessionHandler(SceneType.Realm)]
    public class C2R_ServerListHandler: MessageSessionHandler<C2R_ServerList, R2C_ServerList>
    {
        protected override async ETTask Run(Session session, C2R_ServerList request, R2C_ServerList response)
        {
            //session.RemoveComponent<SessionAcceptTimeoutComponent>();  5秒后自动销毁
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
                    List<ServerItem> serverItems = ServerHelper.GetServerList(request.VersionMode);
                    response.ServerItems.Clear();
                    for (int i = 0; i < serverItems.Count; i++)
                    {
                        if (serverItems[i].Show != 0 && serverItems[i].ServerOpenTime <= serverTime)
                        {
                            response.ServerItems.Add(serverItems[i]);
                        }
                    }
                    
                    string[] stringxxx = ServerLogHelper.GetNoticeNew().Split('@');
                    response.NoticeVersion = stringxxx[0];
                    response.NoticeText = stringxxx[1];
                }
            } 
            await ETTask.CompletedTask;
        }
    }
    
}