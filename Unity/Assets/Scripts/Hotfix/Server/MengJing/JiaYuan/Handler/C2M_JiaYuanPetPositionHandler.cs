using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanPetPositionHandler : MessageLocationHandler<Unit, C2M_JiaYuanPetPositionRequest, M2C_JiaYuanPetPositionResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanPetPositionRequest request, M2C_JiaYuanPetPositionResponse response)
        {
            if (unit.Scene().GetComponent<MapComponent>().MapType != MapTypeEnum.JiaYuan)
            {
                return;
            }

            List<EntityRef<Unit>> units = unit.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit uniitem = units[i];
                if (uniitem.Type == UnitType.Pet)
                {
                    if (uniitem.GetComponent<AIComponent>().AIConfigId != 11)
                    {
                        continue;
                    }

                    UnitInfo unitInfo = UnitInfo.Create();
                    unitInfo.Type = UnitType.Pet;
                    unitInfo.UnitId = uniitem.Id;
                    unitInfo.ConfigId = uniitem.ConfigId;
                    unitInfo.Position = uniitem.Position;
                    response.PetList.Add(unitInfo);
                    continue;
                }
                if (uniitem.Type == UnitType.Monster)
                {
                    if (!ConfigData.JiaYuanMonster.ContainsKey( uniitem.ConfigId))
                    {
                        continue;
                    }

                    UnitInfo unitInfo = UnitInfo.Create();
                    unitInfo.Type = UnitType.Monster;
                    unitInfo.UnitId = uniitem.Id;
                    unitInfo.ConfigId = uniitem.ConfigId;
                    unitInfo.Position = uniitem.Position;
                    response.PetList.Add(unitInfo);
                    continue;
                }
            }
            await ETTask.CompletedTask;
        }
    }
}
