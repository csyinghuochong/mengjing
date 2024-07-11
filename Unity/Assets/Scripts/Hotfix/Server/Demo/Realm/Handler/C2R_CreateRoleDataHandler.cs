using System;
using System.Collections;
using System.Collections.Generic;


namespace ET.Server
{
	[FriendOf(typeof(DBAccountInfo))]
	[FriendOf(typeof(UserInfoComponentS))]
    [MessageSessionHandler(SceneType.Realm)]
    public class C2R_CreateRoleDataHandler: MessageSessionHandler<C2R_CreateRoleData, R2C_CreateRoleData>
    {
	   
        protected override async ETTask Run(Session session, C2R_CreateRoleData request, R2C_CreateRoleData response)
        {
	        if (session.GetComponent<SessionLockingComponent>()!=null)
	        { 
		        response.Error = ErrorCode.ERR_RequestRepeatedly;
		        response.Message = "角色名字过短!";
		        return;
	        }

	        if (session.Root().SceneType != SceneType.Realm)
	        {
		        Log.Error($"LoginTest C2G_CreateRoleData请求的Scene错误，当前Scene为：{session.Root().SceneType}");
		        session.Dispose();
		        return;
	        }
	        
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
					List<UserInfoComponentS> result = await dbComponent.Query<UserInfoComponentS>(session.Zone(), _account => _account.UserName == request.CreateName);
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

					int robotId = 0;
					if (newAccount.Password == CommonHelp.RobotPassWord)
					{
						robotId = int.Parse(newAccount.Account.Split('_')[0]);
					}

					//存储账号信息
					CreateRoleInfo createRoleInfo = CreateRoleInfo.Create();
					createRoleInfo.UnitId = userId;
					createRoleInfo.PlayerLv = 1;
					createRoleInfo.PlayerOcc = request.CreateOcc;
					createRoleInfo.PlayerName = request.CreateName;
					createRoleInfo.RobotId = robotId;
					newAccount.RoleList.Add(createRoleInfo);
					await dbComponent.Save(newAccount);

					//返回角色信息
					response.createRoleInfo = createRoleInfo;
				}
			}
            
            await ETTask.CompletedTask;
        }
        
        //获取角色创建列表信息
        public CreateRoleInfo GetRoleListInfo(UserInfo userInfo,long userID)
        {
	        CreateRoleInfo roleList = CreateRoleInfo.Create();

	        roleList.OccTwo =  userInfo.OccTwo;
	        roleList.UnitId = userID;
	        roleList.PlayerName = userInfo.Name;
	        roleList.PlayerLv = userInfo.Lv;
	        roleList.PlayerOcc = userInfo.Occ;

	        return roleList;
        }

    }
}
	