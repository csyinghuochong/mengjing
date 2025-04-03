using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TeamerPositionHandler : MessageLocationHandler<Unit, C2M_TeamerPositionRequest, M2C_TeamerPositionResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TeamerPositionRequest request, M2C_TeamerPositionResponse response)
        {
            int sceneType = unit.Scene().GetComponent<MapComponent>().MapType;
            List<EntityRef<Unit>> units = unit.GetParent<UnitComponent>().GetAll();

            for (int i = 0; i < units.Count; i++)
            {
                Unit uniitem = units[i];
                
                if ((sceneType == MapTypeEnum.TeamDungeon || sceneType == MapTypeEnum.DragonDungeon) && uniitem.Id!=unit.Id && uniitem.Type == UnitType.Player)
                {
                    UnitInfo UnitInfo = UnitInfo.Create();
                    UnitInfo.Type = uniitem.Type;
                    UnitInfo.UnitId = uniitem.Id;
                    UnitInfo.ConfigId = uniitem.ConfigId;
                    UnitInfo.UnitName = uniitem.GetComponent<UserInfoComponentS>().UserInfo.Name;
                    UnitInfo.Position = uniitem.Position;
                    response.UnitList.Add(UnitInfo);
                }
               
                if (sceneType == MapTypeEnum.LocalDungeon && (CommonHelp.IsSeasonBoss(uniitem.ConfigId)   ||uniitem.IsJingLingMonster()))
                {
                    UnitInfo unitInfo = UnitInfo.Create();
                    unitInfo.Type = uniitem.Type;
                    unitInfo.UnitId = uniitem.Id;
                    unitInfo.ConfigId = uniitem.ConfigId;
                    unitInfo.Position = uniitem.Position;
                    response.UnitList.Add(unitInfo);
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
