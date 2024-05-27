﻿using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Rank)]
    public  class A2R_DeleteRoleDataHandler : MessageHandler<Scene, A2R_DeleteRoleData, R2A_DeleteRoleData>
    {

        protected override async ETTask Run(Scene scene, A2R_DeleteRoleData request, R2A_DeleteRoleData response, Action reply)
        {
            RankSceneComponent rankScene = scene.GetComponent<RankSceneComponent>();
            rankScene.OnDeleteRole(rankScene.DBRankInfo.rankingInfos, request.DeleUserID);
            rankScene.OnDeleteRole(rankScene.DBRankInfo.rankingCamp1, request.DeleUserID);
            rankScene.OnDeleteRole(rankScene.DBRankInfo.rankingCamp2, request.DeleUserID);

            rankScene.OnDeleteRole(rankScene.DBRankInfo.rankingPets, request.DeleUserID);

            reply();
            await ETTask.CompletedTask;
        }
    }
}
