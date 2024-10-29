using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PathfindingResultHandler : MessageLocationHandler<Unit, C2M_PathfindingResult>
    {
        protected override async ETTask Run(Unit unit, C2M_PathfindingResult message)
        {
            M2C_PathfindingResult m2CPathfindingResult = new();
            // 广播寻路路径
            m2CPathfindingResult.Id = unit.Id;
            m2CPathfindingResult.Points = message.Position;
            m2CPathfindingResult.YaoGan = true;
            m2CPathfindingResult.SpeedRate = message.SpeedRate;
            int petfightindex = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetFightIndex);

            MoveComponent moveComponent = null;
            if (petfightindex == 0)
            {
                moveComponent = unit.GetComponent<MoveComponent>();

                MapMessageHelper.Broadcast(unit, m2CPathfindingResult);
                MoveHelper.PathResultToAsync(unit, message.Position, moveComponent, message.SpeedRate).Coroutine();
            }
            else
            {
                PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
                Unit petunit = petComponentS.GetFightPetByIndex(petfightindex);
                if (petunit == null)
                {
                    return;
                }

                moveComponent = petunit.GetComponent<MoveComponent>();

                MapMessageHelper.Broadcast(petunit, m2CPathfindingResult);
                MoveHelper.PathResultToAsync(petunit, message.Position, moveComponent ,message.SpeedRate).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }
}