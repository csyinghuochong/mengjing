using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPetPositionHandler : MessageLocationHandler<Unit, C2M_JiaYuanPetPositionRequest, M2C_JiaYuanPetPositionResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPetPositionRequest request, M2C_JiaYuanPetPositionResponse response)
        {
            if (unit.Scene().GetComponent<MapComponent>().SceneType != SceneTypeEnum.JiaYuan)
            {
                return;
            }

            List<Unit> units = unit.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Type == UnitType.Pet)
                {
                    if (units[i].GetComponent<AIComponent>().AIConfigId != 11)
                    {
                        continue;
                    }
                    response.PetList.Add(new UnitInfo()
                    {
                        Type = UnitType.Pet,
                        UnitId = units[i].Id,
                        ConfigId = units[i].ConfigId,
                        Position = units[i].Position,
                    });
                    continue;
                }
                if (units[i].Type == UnitType.Monster)
                {
                    if (!ConfigData.JiaYuanMonster.ContainsKey(  units[i].ConfigId))
                    {
                        continue;
                    }
                    response.PetList.Add(new UnitInfo()
                    {
                        Type = UnitType.Monster,
                        UnitId = units[i].Id,
                        ConfigId = units[i].ConfigId,
                        Position = units[i].Position
                    });
                    continue;
                }
            }
            await ETTask.CompletedTask;
        }
    }
}
