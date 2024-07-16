using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof (UserInfoComponentS))]
    [MessageSessionHandler(SceneType.Realm)]
    public class C2R_DeleteRoleDataHandler: MessageSessionHandler<C2R_DeleteRoleData, R2C_DeleteRoleData>
    {
        protected override async ETTask Run(Session session, C2R_DeleteRoleData request, R2C_DeleteRoleData response)
        {
            try
            {
                if (session.Root().SceneType != SceneType.Realm)
                {
                    Log.Error($"LoginTest C2G_DeleteRoleData请求的Scene错误，当前Scene为：{session.Root().SceneType}");
                    session.Dispose();
                    return;
                }
                
                if (session.GetComponent<SessionLockingComponent>() != null)
                {
                    response.Error = ErrorCode.ERR_RequestRepeatedly;
                    CloseSession(session).Coroutine();
                    return;
                }

                using (session.AddComponent<SessionLockingComponent>())
                {
                    //存储账号信息
                    int zone = session.Zone();
                    DBComponent dbComponent = session.Root().GetComponent<DBManagerComponent>().GetZoneDB(zone);
                    List<DBCenterAccountInfo> newAccountList = await dbComponent.Query<DBCenterAccountInfo>(zone, d => d.Id == request.AccountId);
                    if (newAccountList.Count == 0)
                    {
                        response.Error = ErrorCode.ERR_NotFindAccount;
                        return;
                    }

                    Log.Warning($"C2A_DeleteRoleData: {request.AccountId} {request.UserId}");

                    DBCenterAccountInfo newAccount = newAccountList[0];
                    //移除角色
                    if (newAccount.RoleList.Count > 0)
                    {
                        for (int i = newAccount.RoleList.Count - 1; i >= 0; i--)
                        {
                            if (newAccount.RoleList[i].UnitId == request.UserId)
                            {
                                newAccount.RoleList[i].State = (int)RoleInfoState.Freeze;
                            }
                        }
                        
                    }

                    await dbComponent.Save<DBCenterAccountInfo>(zone, newAccount);
                    // long mapInstanceId = DBHelper.GetRankServerId(session.DomainZone());
                    // R2A_DeleteRoleData deleteResponse = (R2A_DeleteRoleData)await ActorMessageSenderComponent.Instance.Call(mapInstanceId,
                    //     new A2R_DeleteRoleData() { DeleUserID = request.UserId, AccountId = request.AccountId });
                    // DBHelper.DeleteUnitCache(session.DomainZone(), request.UserId).Coroutine();
                    // UserInfoComponent userInfoComponent = await DBHelper.GetComponentCache<UserInfoComponent>(zone, request.UserId);
                    // NumericComponent numericComponent = await DBHelper.GetComponentCache<NumericComponent>(zone, request.UserId);
                    // if (userInfoComponent != null && userInfoComponent.UserInfo.Lv <= 10 &&
                    //     numericComponent.GetAsInt(NumericType.RechargeNumber) <= 0)
                    // {
                    //     List<string> allComponets = DBHelper.GetAllUnitComponent();
                    //     for (int i = 0; i < allComponets.Count; i++)
                    //     {
                    //         dbComponent.Remove<Entity>(zone, request.UserId, allComponets[i]).Coroutine();
                    //     }
                    // }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }

            await ETTask.CompletedTask;
        }

        private async ETTask CloseSession(Session session)
        {
            Log.Debug("CloseSession");
            await session.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            session.Dispose();
        }
    }
}