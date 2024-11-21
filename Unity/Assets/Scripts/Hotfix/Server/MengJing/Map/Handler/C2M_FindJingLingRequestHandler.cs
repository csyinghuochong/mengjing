using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_FindJingLingRequestHandler : MessageLocationHandler<Unit, C2M_FindJingLingRequest, M2C_FindJingLingResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FindJingLingRequest request, M2C_FindJingLingResponse response)
        {
            int jinglingid = 0;
            List<Unit> units = UnitHelper.GetUnitList( unit.Scene(), UnitType.Monster );
            for (int i = 0; i < units.Count; i++)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(units[i].ConfigId);

                if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_57 || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_58 || monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_59)
                {
                    jinglingid = monsterConfig.Id;
                    break;
                }
            }

            response.MonsterID = jinglingid;    
            await ETTask.CompletedTask;
        }
    }
}
