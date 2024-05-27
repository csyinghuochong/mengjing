using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RefreshUnitHandler : MessageLocationHandler<Unit, C2M_RefreshUnitRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_RefreshUnitRequest request)
        {
            M2C_CreateUnits createUnits = new M2C_CreateUnits();
            Dictionary<long, AOIEntity> dict = unit.GetBeSeePlayers();
            foreach (AOIEntity u in dict.Values)
            {
                createUnits.Units.Add( UnitHelper.CreateUnitInfo(u.Unit) ); 
            }
            createUnits.UpdateAll = 1;
            MapMessageHelper.SendToClient(unit, createUnits);
            await ETTask.CompletedTask;
        }
    }
}
