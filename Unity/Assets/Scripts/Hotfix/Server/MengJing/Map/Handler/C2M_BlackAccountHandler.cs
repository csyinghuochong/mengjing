using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_BlackAccountHandler : MessageHandler<Session, C2M_BlackAccountRequest, M2C_BlackAccountResponse>
    {
        protected override async ETTask Run(Session session, C2M_BlackAccountRequest request, M2C_BlackAccountResponse response)
        {
            await ETTask.CompletedTask;
            // DBManagerComponent dbManagerComponent = session.Root().GetComponent<DBManagerComponent>();
            // DBComponent dbComponent = dbManagerComponent.GetZoneDB(session.Zone());
            // List<DBCenterAccountInfo> centerAccountInfoList = await dbComponent.Query<DBCenterAccountInfo>(session.Zone(), d => d.Account == request.Account && d.Password == request.Password);
            // DBCenterAccountInfo dBCenterAccountInfo = centerAccountInfoList != null && centerAccountInfoList.Count > 0 ? centerAccountInfoList[0] : null;
            // if (dBCenterAccountInfo != null)
            // {
            //     ///确认要不要删除所有区服的账号数据
            //     dBCenterAccountInfo.AccountType = 2;////(int)AccountType.Delete;
            //     await dbComponent.Save<DBCenterAccountInfo>(session.Zone(), dBCenterAccountInfo); 
            // }
        }
    }
}
