using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.LoginCenter)]
    public class C2Center_RegisterHandler : MessageHandler<Session, C2Center_Register, Center2C_Register>
    {

        protected override async ETTask Run(Session session, C2Center_Register request, Center2C_Register response)
        {
            Log.Warning($"C2Center_Register:{request.Account}");
            if (session.Scene().SceneType != SceneType.LoginCenter)
            {
                Log.Warning($"请求的Scene错误2，当前Scene为：{session.Scene().SceneType}");
                session.Dispose();
                return;
            }
            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;

                session.Disconnect().Coroutine();
                return;
            }

            if (string.IsNullOrEmpty(request.Account) || !StringHelper.IsSafeSqlString(request.Account))
            {
                response.Error = ErrorCode.ERR_UnSafeSqlString;
                session.Disconnect().Coroutine();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Register, request.Account.Trim().GetHashCode()))
                {
                    DBManagerComponent dbManagerComponent = session.Root().GetComponent<DBManagerComponent>();
                    DBComponent dbComponent = dbManagerComponent.GetZoneDB(session.Zone());
                    
                    List<DBCenterAccountInfo> result = await dbComponent.Query<DBCenterAccountInfo>(session.Zone(), _account => _account.Account == request.Account);

                    //如果查询数据不为空,表示当前账号已经被注册
                    if (result.Count > 0)
                    {
                        response.Error = ErrorCode.ERR_AccountAlreadyRegister;
                        session.Disconnect().Coroutine();
                        return;
                    }

                    //创建一条数据库信息,创建账号信息
                    DBCenterAccountInfo newAccount = session.AddChild<DBCenterAccountInfo>();
                    newAccount.Account = request.Account;
                    newAccount.Password = request.Password;
                    newAccount.PlayerInfo = new PlayerInfo();

                    if (request.Password == ComHelp.RobotPassWord)
                    {
                        newAccount.PlayerInfo.RealName = 1;
                        newAccount.PlayerInfo.Name = request.Account;
                        newAccount.PlayerInfo.IdCardNo = "429001198010232399";
                    }
 
                    await dbComponent.Save(session.Zone(), newAccount);
                    //发送创建回执
                }
            }
        }
    }
}
