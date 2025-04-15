using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class MoveHelper
    {
        // 可以多次调用，多次调用的话会取消上一次的协程
        public static async ETTask FindPathMoveToAsync(this Unit unit, float3 target, int speedRate = 100)
        {
            StateComponentS stateComponent = unit.GetComponent<StateComponentS>();
            
            // 以防止怪物再引力波的作用下不移动
            int errorCode = stateComponent.ServerCanMove();
            if (ErrorCode.ERR_Success != errorCode)
            {
                unit.SendStop(-1);
                return;
            }
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            moveComponent.SyncPosition();
            M2C_PathfindingResult m2CPathfindingResult = new();
            unit.GetComponent<PathfindingComponent>().Find(unit.Position, target, m2CPathfindingResult.Points);

            if (m2CPathfindingResult.Points.Count < 2)
            {
                unit.SendStop(-1);
                return;
            }

            // 广播寻路路径
            m2CPathfindingResult.Id = unit.Id;
            m2CPathfindingResult.SpeedRate = speedRate;
            MapMessageHelper.Broadcast(unit, m2CPathfindingResult);

            float speed = unit.GetComponent<NumericComponentS>().GetAsFloat(NumericType.Now_Speed);
            speed *= (speedRate * 0.01f);
            bool ret = await moveComponent.MoveToAsync(m2CPathfindingResult.Points, speed);
            if (ret) // 如果返回false，说明被其它移动取消了，这时候不需要通知客户端stop
            {
                unit.SendStop(0);
            }
        }

        public static async ETTask PathResultToAsync(Unit unit, List<float3> positonsss, MoveComponent moveComponent, int speedRate)
        {
            float speed = unit.GetComponent<NumericComponentS>().GetAsFloat(NumericType.Now_Speed);
            speed *= (speedRate * 0.01f);
            bool ret = await moveComponent.MoveToAsync(positonsss, speed);
            if (ret) // 如果返回false，说明被其它移动取消了，这时候不需要通知客户端stop
            {
                //Console.WriteLine($"PathResultToAsync  unit.SendStop(0):  {TimeHelper.ServerNow()}");
                //unit.SendStop(0);
            }
            await ETTask.CompletedTask;
        }
        
        // 可以多次调用，多次调用的话会取消上一次的协程
        public static async ETTask BulletMoveToAsync(this Unit unit,  float3 target)
        {
            float speed = unit.GetComponent<NumericComponentS>().GetAsFloat(NumericType.Now_Speed);
            if (speed < 0.01)
            {
                Log.Error("Bullet move speed is less than 0.1");
                unit.SendStop(-1);
                return;
            }

            float3 startpos = unit.Position;
            startpos.y = target.y;
            M2C_PathfindingResult m2CPathfindingResult = new();
            m2CPathfindingResult.Points.Add(startpos);
            m2CPathfindingResult.Points.Add(startpos + (target - unit.Position) * 0.5f);
            m2CPathfindingResult.Points.Add(target);
            // 广播寻路路径
            m2CPathfindingResult.Id = unit.Id;
            m2CPathfindingResult.SpeedRate = 100;
            MapMessageHelper.Broadcast(unit, m2CPathfindingResult);

            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();

            bool ret = await moveComponent.MoveToAsync(m2CPathfindingResult.Points, speed);
            if (ret) // 如果返回false，说明被其它移动取消了，这时候不需要通知客户端stop
            {
                unit.SendStop(0);
            }
        }

        public static float3 GetCanReachPath(int navMeshId, float3 start, float3 target)
        {
            // using var list = ListComponent<Vector3>.Create();
            // Vector3 dir = (start - target).normalized;
            // while (true)
            // {
            //     Game.Scene.GetComponent<RecastPathComponent>().SearchPath(self.NavMeshId, start, target, list, 2);
            //     if (list.Count >= 2)
            //     {
            //         target = list[list.Count - 1];
            //         break;
            //     }
            //     if (Vector3.Distance(start, target) < 0.5f)
            //     {
            //         break;
            //     }
            //     target = target + (0.5f * dir);
            // }
            return target;
        }

        public static void Stop(this Unit unit, int error)
        {
            unit.GetComponent<MoveComponent>().Stop(error == 0);
            unit.SendStop(error);
        }

        // error: 0表示协程走完正常停止
        public static void SendStop(this Unit unit, int error)
        {
            M2C_Stop m2CStop = M2C_Stop.Create();
            m2CStop.Error = error;
            m2CStop.Id = unit.Id;
            m2CStop.Position = unit.Position;
            m2CStop.Rotation = unit.Rotation;
            MapMessageHelper.Broadcast(unit, m2CStop);
        }
        
        public static void StopResult(this Unit unit, float3 position,  int error)
        {
            unit.GetComponent<MoveComponent>().Stop(error == 0);
            unit.Position = position;
            M2C_StopResult m2CStop = M2C_StopResult.Create();
            m2CStop.Error = error;
            m2CStop.Id = unit.Id;
            m2CStop.Position = unit.Position;
            m2CStop.Rotation = unit.Rotation;
            MapMessageHelper.Broadcast(unit, m2CStop);
        }
    }
}