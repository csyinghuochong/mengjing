using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TrialDungeonFinishHandler : MessageLocationHandler<Unit, C2M_TrialDungeonFinishRequest, M2C_TrialDungeonFinishResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TrialDungeonFinishRequest request, M2C_TrialDungeonFinishResponse response )
        {
            Scene domainScene = unit.Scene();
            TrialDungeonComponent trialDungeonComponent = domainScene.GetComponent<TrialDungeonComponent>();
            if (trialDungeonComponent == null)
            {
                return;
            }

            List<Unit> monsterList = UnitHelper.GetUnitList(unit.Scene(), UnitType.Monster);
            for (int i = monsterList.Count - 1; i >= 0; i--)
            {
                domainScene.GetComponent<UnitComponent>().Remove(monsterList[i].Id);
            }
            
            await ETTask.CompletedTask;
        }
    }
}
