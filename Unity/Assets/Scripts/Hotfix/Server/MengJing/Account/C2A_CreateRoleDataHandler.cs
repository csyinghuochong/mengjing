using System;
using System.Collections;
using System.Collections.Generic;


namespace ET.Server
{
	[FriendOf(typeof(DBAccountInfo))]
	[FriendOf(typeof(UserInfoComponentServer))]
    [MessageSessionHandler(SceneType.Gate)]
    public class C2A_CreateRoleDataHandler: MessageSessionHandler<C2A_CreateRoleData, A2C_CreateRoleData>
    {
	    
	    //获取角色创建列表信息
	    public CreateRoleInfo GetRoleListInfo(UserInfo userInfo,long userID) 
	    {
		    CreateRoleInfo roleList = new CreateRoleInfo();

		    roleList.OccTwo =  userInfo.OccTwo;
		    roleList.UnitId = userID;
		    roleList.PlayerName = userInfo.Name;
		    roleList.PlayerLv = userInfo.Lv;
		    roleList.PlayerOcc = userInfo.Occ;

		    return roleList;
	    }
	    
        protected override async ETTask Run(Session session, C2A_CreateRoleData request, A2C_CreateRoleData response)
        {
	        Log.Debug("C2A_CreateRoleData.server1");
            //判断名字是否符合要求
            if (string.IsNullOrEmpty(request.CreateName))
            {
                response.Error = ErrorCode.ERR_CreateRoleName;
                response.Message = "角色名字过短!";
                return;
            }
            if (request.CreateName.Length >= 8)
            {
                response.Error = ErrorCode.ERR_CreateRoleName;
                response.Message = "角色名字过长!";
                return;
            }
            if (session.Zone() == 0)
            {
                Log.Error("session.DomainZone() == 0");
                response.Error = ErrorCode.ERR_Error;
                return;
            }
            
            using (session.AddComponent<SessionLockingComponent>())
			{
				using (await session.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.LoginAccount, request.AccountId.GetHashCode()))
				{
					DBComponent dbComponent = session.Root().GetComponent<DBManagerComponent>().GetZoneDB(session.Zone());
					List<UserInfoComponentServer> result = await dbComponent.Query<UserInfoComponentServer>(session.Zone(), _account => _account.UserName == request.CreateName);
					if (result.Count > 0)
					{
						response.Error = ErrorCode.ERR_RoleNameRepeat;
						return;
					}
					
					int zone = session.Zone();
					long userId = IdGenerater.Instance.GenerateId();
					ActorId dbCacheId = UnitCacheHelper.GetDbCacheId(zone);

			        //通过账号ID获取列表  //获取UserID,默认使用第一个角色
			        //D2G_GetComponent d2GGetUnit = (D2G_GetComponent)await ActorMessageSenderComponent.Instance.Call(dbCacheId, new G2D_GetComponent() { UnitId = request.AccountId, Component = DBHelper.DBAccountInfo });
			        //DBAccountInfo newAccount = d2GGetUnit.Component as DBAccountInfo;

			        List<DBAccountInfo> newAccountList = await dbComponent.Query<DBAccountInfo>(session.Zone(), d => d.Id == request.AccountId);
			        DBAccountInfo newAccount = newAccountList[0];

			        UserInfoComponentServer userInfoComponent = session.AddChildWithId<UserInfoComponentServer>(userId);
					userInfoComponent.Account = newAccount.Account;
					UserInfo userInfo = userInfoComponent.UserInfo;
					userInfo.Sp = 1;
					userInfo.UserId = userId;
					userInfo.BaoShiDu = 100;
					userInfo.JiaYuanLv = 10001;
					userInfo.JiaYuanFund = 10000;
					userInfo.AccInfoID = newAccount.Id;
					userInfo.Name = request.CreateName;
					userInfo.ServerMailIdCur = -1;
					userInfo.PiLao = int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);        //初始化疲劳
					userInfo.Vitality = int.Parse(GlobalValueConfigCategory.Instance.Get(10).Value);
					userInfo.MakeList.AddRange(ComHelp.StringArrToIntList(GlobalValueConfigCategory.Instance.Get(18).Value.Split(';')));
					userInfo.CreateTime = TimeHelper.ServerNow();

					if (newAccount.Password == ComHelp.RobotPassWord)
					{
						int robotId = int.Parse(newAccount.Account.Split('_')[0]);
						RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
						userInfo.Lv = robotConfig.Behaviour == 1 ?  RandomHelper.RandomNumber(10, 19) : robotConfig.Level;
						userInfo.Occ = robotConfig.Behaviour == 1 ?  RandomHelper.RandomNumber(1, 3) : robotConfig.Occ;
			            userInfo.Gold = 100000;
			            userInfo.RobotId = robotId;
			            //userInfo.OccTwo = robotConfig.OccTwo;
			        }
					else
					{
						userInfo.Lv = 1;
						userInfo.Gold = 0;
			            userInfo.SeasonLevel = 1;
			            userInfo.Occ = request.CreateOcc;
					}

					await dbComponent.Save(userInfoComponent);
					userInfoComponent.Dispose();

					//创建角色组件
					// await DBHelper.AddDataComponent<NumericComponentServer>(zone, userId, UnitCacheHelper.NumericComponent);
					// await DBHelper.AddDataComponent<DBFriendInfo>(zone, userId, UnitCacheHelper.DBFriendInfo);
					// await DBHelper.AddDataComponent<DBMailInfo>(zone, userId, UnitCacheHelper.DBMailInfo);

					//存储账号信息
					newAccount.UserList.Add(userId);
					await dbComponent.Save(newAccount);

					//返回角色信息
					CreateRoleInfo roleList = GetRoleListInfo(userInfo,  userId);
					response.createRoleInfo = roleList;
				}
			}
            
            await ETTask.CompletedTask;
        }
    }
}
	