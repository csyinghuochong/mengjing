using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ET.Server
{
    [FriendOf(typeof(DBCenterAccountInfo))]
    [MessageSessionHandler(SceneType.Realm)]
    public class C2R_RegisterAccountHandler : MessageSessionHandler<C2R_RegisterAccount, R2C_RegisterAccount>
    {
        protected override async ETTask Run(Session session, C2R_RegisterAccount request, R2C_RegisterAccount response)
        {
            if (session.Root().SceneType != SceneType.Realm)
            {
                Log.Error($"LoginTest C2R_LoginAccount请求的Scene错误，当前Scene为：{session.Root().SceneType}");
                session.Dispose();
                return;
            }

            if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))
            {
                response.Error = ErrorCode.ERR_AccountOrPasswordError;
                session.Disconnect().Coroutine();
                return;
            }

            if (!Regex.IsMatch(request.Account.Trim(), @"^[A-Za-z0-9_]+$")) //, @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
            {
                response.Error = ErrorCode.ERR_AccountNameFormError;
                session.Disconnect().Coroutine();
                return;
            }

            if (!Regex.IsMatch(request.Password.Trim(), @"^[A-Za-z0-9@#]+$"))
            {
                response.Error = ErrorCode.ERR_PasswordFormError;
                session.Disconnect().Coroutine();
                return;
            }

            request.Account = request.Account.Trim().ToLower();
            request.Password = request.Password.Trim().ToLower();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect().Coroutine();
                return;
            }

            CoroutineLockComponent coroutineLockComponent = session.Root().GetComponent<CoroutineLockComponent>();
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await coroutineLockComponent.Wait(CoroutineLockType.RegisterAccount, request.Account.Trim().GetHashCode()))
                {
                    DBComponent dBComponent = session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone());
                    List<DBCenterAccountInfo> centerAccountInfoList = await dBComponent.Query<DBCenterAccountInfo>(session.Zone(), d => d.Account == request.Account);
                    DBCenterAccountInfo centerAccountInfo = null;
                    if (centerAccountInfoList != null && centerAccountInfoList.Count > 0)
                    {
                        // 账号已经存在
                        response.Error = ErrorCode.ERR_AccountAlreadyExists;
                    }
                    else
                    {
                        centerAccountInfo = session.AddChild<DBCenterAccountInfo>();
                        centerAccountInfo.PlayerInfo = PlayerInfo.Create();
                        centerAccountInfo.Account = request.Account.Trim();
                        centerAccountInfo.Password = request.Password;
                        centerAccountInfo.CreateTime = TimeInfo.Instance.ServerNow();
                        centerAccountInfo.AccountType = (int)AccountType.Normal;
                        if (ConfigData.RobotPassWord.Equals(request.Password))
                        {
                            centerAccountInfo.PlayerInfo.RealName = 1;
                            centerAccountInfo.PlayerInfo.Name = request.Account;
                            centerAccountInfo.PlayerInfo.IdCardNo = "429001198010232399";
                        }

                        await dBComponent.Save<DBCenterAccountInfo>(centerAccountInfo);
                        centerAccountInfo?.Dispose();
                    }
                }
            }
        }
    }
}
