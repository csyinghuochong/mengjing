﻿using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2U_UnionCreateHandler : MessageHandler<Scene, M2U_UnionCreateRequest, U2M_UnionCreateResponse>
    {
        protected override async ETTask Run(Scene scene, M2U_UnionCreateRequest request, U2M_UnionCreateResponse response)
        {
            Log.Warning($"M2U_UnionCreateRequest:{request.UserID}");
            if (request.UnionName.Length > 7 || !StringHelper.IsSpecialChar(request.UnionName))
            {
                response.Error = ErrorCode.ERR_Union_Same_Name;
                return;
            }

            DBManagerComponent dbManagerComponent = scene.Root().GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(scene.Zone());
            List<DBUnionInfo> result = await dbComponent.Query<DBUnionInfo>(scene.Zone(), _unionifo => _unionifo.UnionInfo.UnionName == request.UnionName);
            if (result.Count > 0)
            {
                response.Error = ErrorCode.ERR_Union_Same_Name;
                return;
            }

           
            long unionId = IdGenerater.Instance.GenerateId();
            DBUnionInfo unionInfo = scene.AddChildWithId<DBUnionInfo>(unionId);

            unionInfo.UnionInfo.Level = 1;
            unionInfo.UnionInfo.UnionId = unionId;
            unionInfo.UnionInfo.LeaderId = request.UserID;       
            unionInfo.UnionInfo.UnionName = request.UnionName;
            unionInfo.UnionInfo.UnionPurpose = request.UnionPurpose;

            UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(scene.Root(), request.UserID);
            unionInfo.UnionInfo.LeaderName = userInfoComponent.UserInfo.Name;
            UnionPlayerInfo UnionPlayerInfo = UnionPlayerInfo.Create();
            UnionPlayerInfo.PlayerLevel = userInfoComponent.UserInfo.Lv;
            UnionPlayerInfo.PlayerName = userInfoComponent.UserInfo.Name;
            UnionPlayerInfo.UserID = request.UserID;
            unionInfo.UnionInfo.UnionPlayerList.Add(UnionPlayerInfo);
            UnitCacheHelper.SaveComponentCache(scene.Root(), unionInfo).Coroutine();
            response.UnionId = unionId;
            
            unionInfo.Dispose();
            await ETTask.CompletedTask;
        }
    }
}
