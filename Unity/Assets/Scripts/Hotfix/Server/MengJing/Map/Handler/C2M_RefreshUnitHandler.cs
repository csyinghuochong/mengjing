using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RefreshUnitHandler : MessageLocationHandler<Unit, C2M_RefreshUnitRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_RefreshUnitRequest request)
        {
            unit.GetComponent<DBSaveComponent>().OnRelogin();
            
            // 通知客户端创建My Unit
            M2C_CreateMyUnit m2CCreateUnits = M2C_CreateMyUnit.Create();
            m2CCreateUnits.Unit = MapMessageHelper.CreateUnitInfo(unit);
            MapMessageHelper.SendToClient(unit, m2CCreateUnits);
            
            M2C_CreateUnits createUnits = M2C_CreateUnits.Create();
            Dictionary<long, EntityRef<AOIEntity>>  dict = unit.GetGetSeeUnits();
            foreach (AOIEntity u in dict.Values)
            {
                createUnits.Units.Add( MapMessageHelper.CreateUnitInfo(u.Unit) ); 
            }
            createUnits.UpdateAll = 1;
            MapMessageHelper.SendToClient(unit, createUnits);
            await ETTask.CompletedTask;
        }
    }
}
