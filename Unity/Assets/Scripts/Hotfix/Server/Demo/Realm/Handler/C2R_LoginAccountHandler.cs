using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ET.Server
{

    [FriendOf(typeof(DBCenterAccountInfo))]
    [MessageSessionHandler(SceneType.Realm)]
	public class C2R_LoginAccountHandler : MessageSessionHandler<C2R_LoginAccount, R2C_LoginAccount>
	{

        protected override async ETTask Run(Session session, C2R_LoginAccount request, R2C_LoginAccount response)
		{
            if (session.Root().SceneType != SceneType.Realm)
            {
                Log.Error($"LoginTest C2A_LoginAccount请求的Scene错误，当前Scene为：{session.Root().SceneType}");
                session.Dispose();
                return;
            }

            if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))
			{
				response.Error = 20002;
                session.Disconnect().Coroutine();
                return;
			}
            // if (!Regex.IsMatch(request.Account.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
            // {
            //     response.Error = ErrorCode.ERR_AccountNameFormError;
            //     session.Disconnect().Coroutine();
            //     return;
            // }
            //
            // if (!Regex.IsMatch(request.Password.Trim(), @"^[A-Za-z0-9]+$"))
            // {
            //     response.Error = ErrorCode.ERR_PasswordFormError;
            //     session.Disconnect().Coroutine();
            //     return;
            // }

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect().Coroutine();
                return;
            }

            //public const int RegisterLogin = 0;     //注册账号登录
            //public const int WeixLogin = 1;         //微信登录
            //public const int QQLogin = 2;           //QQ登录
            //public const int PhoneCodeLogin = 3;         //短信验证吗登录
            //public const int PhoneNumLogin = 4;        //手机号登录
            //public const int TapTap = 5;                //taptap登录
            //先检测一下QQ和微信登录
            CoroutineLockComponent coroutineLockComponent = session.Root().GetComponent<CoroutineLockComponent>();
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await coroutineLockComponent.Wait(CoroutineLockType.LoginAccount, request.Account.Trim().GetHashCode()))
                {

                    DBComponent dBComponent = session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone()); 
                    List<DBCenterAccountInfo> centerAccountInfoList = await dBComponent.Query<DBCenterAccountInfo>(session.Zone(), d => d.Account == request.Account && d.Password == request.Password);
                    DBCenterAccountInfo centerAccountInfo = null;
                    if (centerAccountInfoList != null && centerAccountInfoList.Count > 0)
                    {
                        centerAccountInfo = centerAccountInfoList[0];
                        session.AddChild(centerAccountInfo);
                        
                        if (centerAccountInfo.AccountType == (int)AccountType.BlackList)
                        {
                            response.Error = ErrorCode.ERR_AccountInBlackListError;
                            session.Disconnect().Coroutine();
                            centerAccountInfo?.Dispose();
                            return;
                        }


                        if (!centerAccountInfo.Password.Equals(request.Password))
                        {
                            response.Error = ErrorCode.ERR_LoginInfoIsNull;
                            session.Disconnect().Coroutine();
                            centerAccountInfo?.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        centerAccountInfo =  session.AddChild<DBCenterAccountInfo>();
                        centerAccountInfo.PlayerInfo = PlayerInfo.Create();
                        centerAccountInfo.Account = request.Account.Trim();
                        centerAccountInfo.Password = request.Password;
                        centerAccountInfo.CreateTime  = TimeInfo.Instance.ServerNow();
                        centerAccountInfo.AccountType = (int)AccountType.General;
                        await dBComponent.Save<DBCenterAccountInfo>(centerAccountInfo);
                    }

                    if (session.IsDisposed || session.Zone() == 0)
                    {
                        Log.Console($"session.IsDisposed: {request.Account}");
                        response.Error = ErrorCode.ERR_LoginInfoIsNull;
                        session.Disconnect().Coroutine();
                        return;
                    }

                    bool IsHoliday = session.Root().GetComponent<FangChenMiComponentS>().IsHoliday;;
                    bool StopServer = session.Root().GetComponent<FangChenMiComponentS>().IsHoliday;;
                    if (StopServer && !GMHelp.IsGmAccount(request.Account))
                    {
                        response.Error = ErrorCode.ERR_StopServer;
                        session.Disconnect().Coroutine();
                        return;
                    }
                    
                    //防沉迷相关
                    // if (centerAccountInfo.PlayerInfo.RealName == 0)
                    // {
                    //     response.Error = ErrorCode.ERR_NotRealName;
                    //     response.AccountId = centerAccountInfo.Id;
                    //     session.Disconnect().Coroutine();
                    //     centerAccountInfo?.Dispose();
                    //     return;
                    // }
                    // string idCardNo = centerAccountInfo.PlayerInfo.IdCardNo;
                    // int canLogin = CanLogin(idCardNo, IsHoliday, request.age_type);
                    // if (canLogin != ErrorCode.ERR_Success)
                    // {
                    //     response.Error = canLogin;
                    //     session.Disconnect().Coroutine();
                    //     centerAccountInfo?.Dispose();
                    //     return;
                    // }
                    
                    Scene rootScene = session.Root();
                    TokenComponent tokenComponent = rootScene.GetComponent<TokenComponent>();
                    string queueToken = tokenComponent.Get(centerAccountInfo.Account);

                    //在线人数判断有问题。[获取的是在保存在账号服的玩家数量]
                    AccountSessionsComponent accountSessionsComponent = session.Root().GetComponent<AccountSessionsComponent>();
                    long onlineNumber = accountSessionsComponent.AccountSessionDictionary.Values.Count;
                    int maxNumber = GlobalValueConfigCategory.Instance.OnLineLimit;
                    //Log.Console($" {session.DomainZone()} ---  onlineNumber:{onlineNumber}");
                    if (accountSessionsComponent.Get(centerAccountInfo.Account) == null &&
                        onlineNumber >= maxNumber && (string.IsNullOrEmpty(queueToken) || queueToken != request.Token))
                    {
                        Log.Console($" {session.Zone()} --- onlineNumber: {onlineNumber}  queueToken:{queueToken} request.Token:{request.Token}");

                        queueToken = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                        tokenComponent.Remove(centerAccountInfo.Account);
                        tokenComponent.Add(centerAccountInfo.Account, queueToken);

                        //long queueServerId = DBHelper.GetQueueServerId(session.DomainZone());
                        //Q2A_EnterQueue d2GGetUnit = (Q2A_EnterQueue)await ActorMessageSenderComponent.Instance.Call(queueServerId, new A2Q_EnterQueue()
                        //{
                        //    AccountId = account.Id,
                        //    Token = queueToken
                        //});

                        ////进入排队
                        //response.Error = ErrorCode.ERR_EnterQueue;
                        //response.AccountId = account.Id;
                        //response.QueueNumber = d2GGetUnit.QueueNumber;
                        //response.QueueAddres = StartSceneConfigCategory.Instance.Queues[session.DomainZone()].OuterIPPort.ToString();

                        session.Disconnect().Coroutine();
                        centerAccountInfo?.Dispose();
                        return;
                    }
                    
                    R2L_LoginAccountRequest r2LLoginAccountRequest = R2L_LoginAccountRequest.Create();
                    r2LLoginAccountRequest.AccountName = request.Account;
                    StartSceneConfig loginCenterConfig = StartSceneConfigCategory.Instance.LoginCenterConfig;
                    var loginAccountResponse =  await session.Fiber().Root.GetComponent<MessageSender>()
                            .Call(loginCenterConfig.ActorId, r2LLoginAccountRequest) as L2R_LoginAccountRequest;
  
                    if (loginAccountResponse.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = loginAccountResponse.Error;
                        session?.Disconnect().Coroutine();
                        centerAccountInfo?.Dispose();
                        return;
                    }
                    
                    Session otherSession  = accountSessionsComponent.Get(request.Account);
                   
                    otherSession?.Send( A2C_Disconnect.Create());
                    otherSession?.Disconnect().Coroutine();
                    accountSessionsComponent.Add(request.Account, session);
                    session.AddComponent<AccountCheckOutTimeComponent, string>(request.Account);

                    response.RoleLists.Clear();
                    for (int i = 0; i < centerAccountInfo.RoleList.Count; i++)
                    {
                        if (centerAccountInfo.RoleList[i].ServerId != request.ServerId)
                        {
                            continue;
                        }

                        DBManagerComponent dbManagerComponent = session.Root().GetComponent<DBManagerComponent>();
                        DBComponent dbComponent = dbManagerComponent.GetZoneDB(request.ServerId);
                        
                        List<UserInfoComponentS> userinfolist = await dbComponent.Query<UserInfoComponentS>(request.ServerId,d=> d.Id ==centerAccountInfo.RoleList[i].UnitId);
                        if (userinfolist == null || userinfolist.Count == 0)
                        {
                            continue;
                        }

                        CreateRoleInfo roleList = GetRoleListInfo(userinfolist[0].UserInfo, centerAccountInfo.RoleList[i].UnitId);
                        List<NumericComponentS> numericComponentlist = await dbComponent.Query<NumericComponentS>(request.ServerId,d=> d.Id ==centerAccountInfo.RoleList[i].UnitId);
                        if (numericComponentlist == null || numericComponentlist.Count == 0)
                        {
                            continue;
                        }

                        roleList.State = centerAccountInfo.RoleList[i].State;
                        roleList.ServerId = centerAccountInfo.RoleList[i].ServerId;
                        roleList.WeaponId = numericComponentlist[0].GetAsInt(NumericType.Now_Weapon);
                        roleList.EquipIndex = numericComponentlist[0].GetAsInt(NumericType.EquipIndex);
                        response.RoleLists.Add(roleList);
                    }
                    
                    string Token = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                    tokenComponent.Remove(centerAccountInfo.Account);    //Token也是保留十分钟
                    tokenComponent.Add(centerAccountInfo.Account, Token);
                    response.PlayerInfo = centerAccountInfo.PlayerInfo;
                    response.AccountId = centerAccountInfo.Id;
                    response.Token = Token;
                    
                    for (int r = 0; r < response.PlayerInfo.RechargeInfos.Count; r++)
                    {
                        response.PlayerInfo.RechargeInfos[r].OrderInfo = String.Empty;
                    }
                    centerAccountInfo?.Dispose();
                    
                    Console.WriteLine($"C2RLoginAccountHandler__11");
                }
            }
		}

        private CreateRoleInfo GetRoleListInfo(UserInfo userInfo, long userID)
        {
            CreateRoleInfo roleList = CreateRoleInfo.Create();

            roleList.OccTwo = userInfo.OccTwo;
            roleList.UnitId = userID;
            roleList.PlayerName = userInfo.Name;
            roleList.PlayerLv = userInfo.Lv;
            roleList.PlayerOcc = userInfo.Occ;
            return roleList;
        }

        public int CanLogin(string identityCard, bool isHoliday, int age_type)
        {
            int age = IDCardHelper.GetBirthdayAgeSex(identityCard, age_type);
            if (age >= 18)
            {
                return ErrorCode.ERR_Success;
            }
            if (age < 12)
            {
                return ErrorCode.ERR_FangChengMi_Tip6;
            }
            DateTime dateTime = TimeHelper.DateTimeNow();
            if (isHoliday)
            {
                if (dateTime.Hour == 20)
                {
                    return ErrorCode.ERR_Success;           //允许登录
                }
                else
                {
                    return ErrorCode.ERR_FangChengMi_Tip7;
                }
            }
            else
            {
                return ErrorCode.ERR_FangChengMi_Tip7;
            }
        }

	}
}
