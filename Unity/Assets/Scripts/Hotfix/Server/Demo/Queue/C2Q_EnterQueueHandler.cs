using System;
using System.Collections.Generic;

namespace ET.Server
{

    [FriendOf(typeof(DBCenterAccountInfo))]
    [MessageSessionHandler(SceneType.Queue)]
    public class C2Q_EnterQueueHandler : MessageSessionHandler<C2Q_EnterQueue, Q2C_EnterQueue>
    {
        protected override async ETTask Run(Session session, C2Q_EnterQueue request, Q2C_EnterQueue response)
        {
            AccountSessionsComponent accountSessionsComponent = session.Root().GetComponent<AccountSessionsComponent>();
            //accountSessionsComponent.Add( request.Account, session );
            
            await ETTask.CompletedTask;
        }
    }
}
