using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TeamerPositionHandler : MessageLocationHandler<Unit, C2M_TeamerPositionRequest, M2C_TeamerPositionResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TeamerPositionRequest request, M2C_TeamerPositionResponse response)
        {
            int sceneType = unit.Scene().GetComponent<MapComponent>().SceneType;
            List<Unit> units = unit.GetParent<UnitComponent>().GetAll();

            for (int i = 0; i < units.Count; i++)
            {
               
                if (sceneType == SceneTypeEnum.TeamDungeon && units[i].Id!=unit.Id && units[i].Type == UnitType.Player)
                {
                    response.UnitList.Add(new UnitInfo()
                    {
                        Type = units[i].Type,
                        UnitId = units[i].Id,
                        ConfigId = units[i].ConfigId,
                        UnitName = units[i].GetComponent<UserInfoComponentS>().UserInfo.Name,
                        Position = units[i].Position,
                    });
                }
               
                if (sceneType == SceneTypeEnum.LocalDungeon && (units[i].ConfigId == SeasonHelper.SeasonBossId || units[i].IsJingLingMonster()))
                {
                    response.UnitList.Add(new UnitInfo()
                    {
                        Type = units[i].Type,
                        UnitId = units[i].Id,
                        ConfigId = units[i].ConfigId,
                        Position = units[i].Position,
                    });
                }
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
