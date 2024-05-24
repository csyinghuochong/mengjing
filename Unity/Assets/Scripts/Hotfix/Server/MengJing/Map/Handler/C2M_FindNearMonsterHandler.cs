﻿using System;

namespace ET
{
    [ActorMessageHandler]
    public class C2M_FindNearMonsterHandler : AMActorLocationRpcHandler<Unit, C2M_FindNearMonsterRequest, M2C_FindNearMonsterResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_FindNearMonsterRequest request, M2C_FindNearMonsterResponse response, Action reply)
        {
            Unit listUnit = AIHelp.GetNearestEnemy(unit,  50f, true);
            if (listUnit !=null)
            {
                response.IfFindStatus = true;
                response.x = listUnit.Position.x;
                response.y = listUnit.Position.y;
                response.z = listUnit.Position.z;
                response.MonsterID = listUnit.Id;
            }
            else 
            {
                response.IfFindStatus = false;
            }

            reply();
            await ETTask.CompletedTask;

        }
    }
}
