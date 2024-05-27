﻿using System;
using System.Collections.Generic;


namespace ET
{

    [ActorMessageHandler]
    public class C2M_TeamerPositionHandler : AMActorLocationRpcHandler<Unit, C2M_TeamerPositionRequest, M2C_TeamerPositionResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TeamerPositionRequest request, M2C_TeamerPositionResponse response, Action reply)
        {
            int sceneType = unit.DomainScene().GetComponent<MapComponent>().SceneTypeEnum;
            List<Unit> units = unit.GetParent<UnitComponent>().GetAll();

            for (int i = 0; i < units.Count; i++)
            {
               
                if (sceneType == SceneTypeEnum.TeamDungeon && units[i].Id!=unit.Id && units[i].Type == UnitType.Player)
                {
                    response.UnitList.Add(new UnitInfo()
                    {
                        UnitType = units[i].Type,
                        UnitId = units[i].Id,
                        ConfigId = units[i].ConfigId,
                        UnitName = units[i].GetComponent<UserInfoComponent>().UserInfo.Name,
                        X = units[i].Position.x,
                        Y = units[i].Position.y,
                        Z = units[i].Position.z,
                    });
                }
               
                if (sceneType == SceneTypeEnum.LocalDungeon && (units[i].ConfigId == SeasonHelper.SeasonBossId || units[i].IsJingLingMonster()))
                {
                    response.UnitList.Add(new UnitInfo()
                    {
                        UnitType = units[i].Type,
                        UnitId = units[i].Id,
                        ConfigId = units[i].ConfigId,
                        X = units[i].Position.x,
                        Y = units[i].Position.y,
                        Z = units[i].Position.z,
                    });
                }
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
