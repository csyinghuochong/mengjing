using System;
using System.Collections;
using System.Collections.Generic;


namespace ET.Server
{
	[FriendOf(typeof(DBAccountInfo))]
	[FriendOf(typeof(UserInfoComponentS))]
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
					if (newAccount.Password == ComHelp.RobotPassWord)
					{
						robotId = int.Parse(newAccount.Account.Split('_')[0]);
					}

					//存储账号信息
					CreateRoleInfo createRoleInfo = new CreateRoleInfo()
					{
						UnitId = userId,PlayerLv = 1, 
						PlayerOcc = request.CreateOcc,
						PlayerName  = request.CreateName,
						RobotId = robotId,
					};
					newAccount.RoleList.Add(createRoleInfo);
					await dbComponent.Save(newAccount);

					//返回角色信息
					response.createRoleInfo = createRoleInfo;
				}
			}
            
            await ETTask.CompletedTask;
        }
    }
}
	