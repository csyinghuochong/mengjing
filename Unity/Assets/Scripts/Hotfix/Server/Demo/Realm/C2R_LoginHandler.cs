using System;
using System.Net;
using System.Collections.Generic;

namespace ET.Server
{
	[FriendOf(typeof(AccountInfo))]
    [FriendOf(typeof(AccountInfoComponent))]
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

		private async ETTask CloseSession(Session session)
		{
			await session.Root().GetComponent<TimerComponent>().WaitAsync(1000);
			session.Dispose();
		}
	}
}
