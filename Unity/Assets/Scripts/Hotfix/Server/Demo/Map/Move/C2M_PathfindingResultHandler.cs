using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PathfindingResultHandler : MessageLocationHandler<Unit, C2M_PathfindingResult>
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private  int LinearMap(int value)
        {
            if (value < 100) return 100;
            return (int)Math.Min(200, 100 + (value - 100) * 0.1);
        }
        
        protected override async ETTask Run(Unit unit, C2M_PathfindingResult message)
        {
            if (unit.GetComponent<StateComponentS>().StateTypeGet(StateTypeEnum.Transfer))
            {
                return;
            }

            M2C_PathfindingResult m2CPathfindingResult = new();
           
            MoveComponent  moveComponent = unit.GetComponent<MoveComponent>();
            long passTime = TimeHelper.ServerNow() - message.ServerTime;

            message.SpeedRate = LinearMap((int)passTime);
            
            //moveComponent.Current = message.Current;
            //moveComponent.Frame = message.Frame;

            //如果延迟过大， 则加速追赶
            
            // 广播寻路路径
            m2CPathfindingResult.Id = unit.Id;
            m2CPathfindingResult.Points = message.Position;
            m2CPathfindingResult.YaoGan = true;
            m2CPathfindingResult.SpeedRate = message.SpeedRate;
            
            MapMessageHelper.Broadcast(unit, m2CPathfindingResult);
            MoveHelper.PathResultToAsync(unit, message.Position, moveComponent, message.SpeedRate).Coroutine();
           
            await ETTask.CompletedTask;
        }
    }
}