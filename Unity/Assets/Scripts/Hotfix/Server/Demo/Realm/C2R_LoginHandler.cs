using System;
using System.Collections;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(DBAccountInfo))]
    [FriendOf(typeof(UserInfoComponentServer))]
    [FriendOf(typeof(GlobalValueConfigCategory))]
    [MessageSessionHandler(SceneType.Realm)]
	public class C2R_LoginHandler : MessageSessionHandler<C2R_Login, R2C_Login>
	{

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

        protected override async ETTask Run(Session session, C2R_Login request, R2C_Login response)
		{

            //if (session.Root().SceneType != SceneType.Account)
            //{
            //    Log.Error($"LoginTest C2A_LoginAccount请求的Scene错误，当前Scene为：{session.Root().SceneType}");
            //    session.Dispose();
            //    return;
            //}

            if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))
			{
				response.Error = 20002;
				CloseSession(session).Coroutine();
                return;
			}

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                CloseSession(session).Coroutine();
                return;
            }

            //public const int RegisterLogin = 0;     //注册账号登录
            //public const int WeixLogin = 1;         //微信登录
            //public const int QQLogin = 2;           //QQ登录
            //public const int PhoneCodeLogin = 3;         //短信验证吗登录
            //public const int PhoneNumLogin = 4;        //手机号登录
            //public const int TapTap = 5;                //taptap登录
            //先检测一下QQ和微信登录
            long AccountId = 0;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginAccount, request.Account.Trim().GetHashCode()))
                {
                    ActorId accountZone = StartSceneConfigCategory.Instance.AccountCenterConfig.ActorId;
                    Center2A_CheckAccount centerAccount = (Center2A_CheckAccount)await session.Root().GetComponent<MessageSender>().Call(accountZone, new A2Center_CheckAccount()
                    {
                        AccountName = request.Account,
                        Password = request.Password,
                        ThirdLogin = request.ThirdLogin
                    });
                    PlayerInfo playerInfo = centerAccount.PlayerInfo != null ? centerAccount.PlayerInfo : null;


                    //没有则注册
                    if (centerAccount.PlayerInfo == null)
                    {
                        Center2A_RegisterAccount saveAccount = (Center2A_RegisterAccount)await session.Root().GetComponent<MessageSender>().Call(accountZone, new A2Center_RegisterAccount()
                        {
                            AccountName = request.Account,
                            Password = request.Password
                        });
                        AccountId = saveAccount.AccountId;
                    }
                    else
                    {
                        AccountId = centerAccount.AccountId;
                    }

                    if (session.IsDisposed || session.Zone() == 0)
                    {
                        Log.Console($"session.IsDisposed: {request.Account}");
                        response.Error = ErrorCode.ERR_LoginInfoIsNull;
                        CloseSession(session).Coroutine();
                        return;
                    }

                    DBComponent dBComponent = session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone());
                    List<DBAccountInfo> accountInfoList = await dBComponent.Query<DBAccountInfo>(session.Zone(), d => d.Account == request.Account && d.Password == request.Password);
                    if (accountInfoList.Count == 0 && AccountId > 0)
                    {
                        accountInfoList = await dBComponent.Query<DBAccountInfo>(session.Zone(), d => d.Id == AccountId);
                    }

                    if (accountInfoList.Count == 0 && (request.Password == "3" || request.Password == "4"))
                    {
                        string password = request.Password == "3" ? "4" : "3";
                        accountInfoList = await dBComponent.Query<DBAccountInfo>(session.Zone(), d => d.Account == request.Account && d.Password == password);
                    }

                    DBAccountInfo account = accountInfoList != null && accountInfoList.Count > 0 ? accountInfoList[0] : null;
                    if (AccountId > 0 && account == null)
                    {
                        //Log.Console($"当前区找不到账号: {session.DomainZone()} {request.AccountName} {request.Password}");
                        //Log.Warning($"当前区找不到账号: {session.DomainZone()} {request.AccountName} {request.Password}");
                    }
                    bool IsHoliday = false;
                    bool StopServer = false;
                    Center2A_CheckAccount checkAccount = (Center2A_CheckAccount)await session.Root().GetComponent<MessageSender>().Call(accountZone, new A2Center_CheckAccount()
                    {
                        AccountName = request.Account,
                        Password = request.Password,
                        ThirdLogin = request.ThirdLogin
                    });
                    PlayerInfo centerPlayerInfo = checkAccount.PlayerInfo;
                    IsHoliday = checkAccount.IsHoliday;
                    StopServer = checkAccount.StopServer;
                    if (StopServer && !GMHelp.IsGmAccount(request.Account))
                    {
                        response.Error = ErrorCode.ERR_StopServer;
                        CloseSession(session).Coroutine();
                        return;
                    }

                    if (centerPlayerInfo == null)
                    {
                        response.Error = ErrorCode.ERR_LoginInfoIsNull;
                        CloseSession(session).Coroutine();
                        return;
                    }
                    if (account == null)
                    {
                        //在该区创建账号信息
                        account = session.AddChildWithId<DBAccountInfo>(AccountId);
                        account.Account = request.Account;
                        account.Password = request.Password;
                        account.CreateTime = TimeHelper.ServerNow();
                        await dBComponent.Save<DBAccountInfo>(session.Zone(), account);
                    }

                    if (account.AccountType == 2) //黑名单
                    {
                        response.Error = ErrorCode.ERR_AccountInBlackListError;
                        response.AccountId = account.Id;
                        CloseSession(session).Coroutine();
                        account?.Dispose();
                        return;
                    }
                    if (centerPlayerInfo.RealName == 0)
                    {
                        response.Error = ErrorCode.ERR_NotRealName;
                        response.AccountId = account.Id;
                        CloseSession(session).Coroutine();
                        account?.Dispose();
                        return;
                    }
                    if (session.IsDisposed || session.Zone() == 0)
                    {
                        Log.Console($"session.IsDisposed: {request.Account}");
                        response.Error = ErrorCode.ERR_LoginInfoIsNull;
                        CloseSession(session).Coroutine();
                        account?.Dispose();
                        return;
                    }

                    //防沉迷相关
                    string idCardNo = centerPlayerInfo.IdCardNo;
                    int canLogin = CanLogin(idCardNo, IsHoliday, request.age_type);
                    if (canLogin != ErrorCode.ERR_Success)
                    {
                        response.Error = canLogin;
                        CloseSession(session).Coroutine();
                        account?.Dispose();
                        return;
                    }
                    Scene rootScene = session.Root();
                    TokenComponent tokenComponent = rootScene.GetComponent<TokenComponent>();
                    string queueToken = tokenComponent.Get(account.Id);

                    //在线人数判断有问题。[获取的是在保存在账号服的玩家数量]
                    AccountSessionsComponent accountSessionsComponent = session.Root().GetComponent<AccountSessionsComponent>();
                    long onlineNumber = accountSessionsComponent.GetAll().Values.Count;
                    int maxNumber = GlobalValueConfigCategory.Instance.OnLineLimit;
                    //Log.Console($" {session.DomainZone()} ---  onlineNumber:{onlineNumber}");
                    if (accountSessionsComponent.Get(account.Id) == 0 &&
                        onlineNumber >= maxNumber && (string.IsNullOrEmpty(queueToken) || queueToken != request.Token))
                    {
                        Log.Console($" {session.Zone()} --- onlineNumber: {onlineNumber}  queueToken:{queueToken} request.Token:{request.Token}");

                        queueToken = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                        tokenComponent.Remove(account.Id);
                        tokenComponent.Add(account.Id, queueToken, true);

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

                        CloseSession(session).Coroutine();
                        account?.Dispose();
                        return;
                    }

                    //请求登录中心服查询有没有同账号玩家登录[uwa]
                    //StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "LoginCenter");
                    //long loginCenterInstanceId = startSceneConfig.InstanceId;
                    //ActorId loginCenterInstanceId = StartSceneConfigCategory.Instance.LoginCenterConfig.ActorId;//踢掉进入gate的玩家
                    //var loginAccountResponse = (L2A_LoginAccountResponse)await session.Root().GetComponent<MessageSender>().Call(loginCenterInstanceId, new A2L_LoginAccountRequest() { AccountId = account.Id, Relink = request.Relink });

                    //if (loginAccountResponse.Error != ErrorCode.ERR_Success)
                    //{
                    //    response.Error = loginAccountResponse.Error;
                    //    CloseSession(session).Coroutine();
                    //    account?.Dispose();
                    //    return;
                    //}

                    //AccountSessionsComponent.Remove 需要在适当的时候移除
                    long accountSessionInstanceId = accountSessionsComponent.Get(account.Id);
                    //Session otherSession = EventSystem.Instance.Get(accountSessionInstanceId) as Session;
                    //if (otherSession != null)
                    //{
                    //    Log.Warning($"LoginTest C2A_LoginAccount.ERR_OtherAccountLogin1 account.Id: {account.Id}");
                    //}
                    //// //踢accout服的玩家下线
                    //otherSession?.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_OtherAccountLogin });                
                    //CloseSession(otherSession).Coroutine();

                    accountSessionsComponent.Add(account.Id, session.InstanceId);
                    session.AddComponent<AccountCheckOutTimeComponent, long>(account.Id);   //自己在账号服只能停留600秒

                    string Token = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                    tokenComponent.Remove(account.Id);    //Token也是保留十分钟
                    tokenComponent.Add(account.Id, Token);

                    response.RoleLists.Clear();
                    ActorId dbCacheId = UnitCacheHelper.GetDbCacheId(session.Zone());
                    for (int i = 0; i < account.UserList.Count; i++)
                    {
                        UserInfoComponentServer userinfo = await UnitCacheHelper.GetComponentCache<UserInfoComponentServer>(session.Root(), account.UserList[i]);
                        if (userinfo == null)
                        {
                            continue;
                        }

                        CreateRoleInfo roleList = GetRoleListInfo(userinfo.UserInfo, account.UserList[i]);
                        // NumericComponentServer numericComponent = await UnitCacheHelper.GetComponentCache<NumericComponentServer>(session.Root(), account.UserList[i]);
                        // if (numericComponent == null)
                        // {
                        //     continue;
                        // }
                        //
                        // roleList.WeaponId = numericComponent.GetAsInt(NumericType.Now_Weapon);
                        // roleList.EquipIndex = numericComponent.GetAsInt(NumericType.EquipIndex);
                        response.RoleLists.Add(roleList);
                    }
                    response.PlayerInfo = centerPlayerInfo;
                    response.AccountId = account.Id;
                    response.Token = Token;
                    for (int r = 0; r < response.PlayerInfo.RechargeInfos.Count; r++)
                    {
                        response.PlayerInfo.RechargeInfos[r].OrderInfo = String.Empty;
                    }
                    account?.Dispose();

                }
            }

            // 随机分配一个Gate
            StartSceneConfig config = RealmGateAddressHelper.GetGate(session.Zone(), request.Account);
			Log.Debug($"gate address: {config}");
			
			// 向gate请求一个key,客户端可以拿着这个key连接gate
			G2R_GetLoginKey g2RGetLoginKey = (G2R_GetLoginKey) await session.Fiber().Root.GetComponent<MessageSender>().Call(
				config.ActorId, new R2G_GetLoginKey() {Account = request.Account});

			response.Address = config.InnerIPPort.ToString();
			response.Key = g2RGetLoginKey.Key;
			response.GateId = g2RGetLoginKey.GateId;
			
			CloseSession(session).Coroutine();
		}

        private CreateRoleInfo GetRoleListInfo(UserInfo userInfo, long userID)
        {
            CreateRoleInfo roleList = new CreateRoleInfo();

            roleList.OccTwo = userInfo.OccTwo;
            roleList.UnitId = userID;
            roleList.PlayerName = userInfo.Name;
            roleList.PlayerLv = userInfo.Lv;
            roleList.PlayerOcc = userInfo.Occ;

            return roleList;
        }

        private async ETTask CloseSession(Session session)
		{
            Log.Debug("CloseSession");
			await session.Root().GetComponent<TimerComponent>().WaitAsync(1000);
			session.Dispose();
		}
	}
}
