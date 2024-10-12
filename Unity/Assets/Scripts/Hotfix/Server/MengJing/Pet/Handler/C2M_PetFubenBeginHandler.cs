using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetFubenBeginHandler: MessageLocationHandler<Unit, C2M_PetFubenBeginRequest, M2C_PetFubenBeginResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetFubenBeginRequest request, M2C_PetFubenBeginResponse response)
        {
            Scene domainScene = unit.Scene();
            List<EntityRef<Unit>> allunits  = domainScene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                Unit unititem = allunits[i];
                if (unititem.Type!= UnitType.Pet && unititem.Type!= UnitType.Monster)
                {
                    continue;
                }
               unititem.GetComponent<AIComponent>().Begin();
               unititem.GetComponent<SkillPassiveComponent>().Begin();
               unititem.GetComponent<SkillPassiveComponent>()?.OnTrigegerPassiveSkill( SkillPassiveTypeEnum.PetBattleBegin_18, 0, 0 );
            }
            await ETTask.CompletedTask;
        }
    }
}

