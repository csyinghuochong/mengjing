using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.LoginCenter)]
    public class Center2C_BlackAccountHandler : MessageHandler<Session, C2Center_BlackAccountRequest, Center2C_BlackAccountResponse>
    {
        protected override async ETTask Run(Session session, C2Center_BlackAccountRequest request, Center2C_BlackAccountResponse response)
        {
            DBManagerComponent dbManagerComponent = session.Root().GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(session.Zone());
            List<DBCenterAccountInfo> centerAccountInfoList = await dbComponent.Query<DBCenterAccountInfo>(session.Zone(), d => d.Account == request.Account && d.Password == request.Password);
            DBCenterAccountInfo dBCenterAccountInfo = centerAccountInfoList != null && centerAccountInfoList.Count > 0 ? centerAccountInfoList[0] : null;
            if (dBCenterAccountInfo != null)
            {
                ///确认要不要删除所有区服的账号数据
                dBCenterAccountInfo.AccountType = 2;////(int)AccountType.Delete;
                await dbComponent.Save<DBCenterAccountInfo>(session.Zone(), dBCenterAccountInfo); 
            }
        }
    }
}
