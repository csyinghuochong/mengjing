using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public static partial class MoveHelper
    {
        // 可以多次调用，多次调用的话会取消上一次的协程
        public static async ETTask<int> MoveToAsync(this Unit unit, float3 targetPos, ETCancellationToken cancellationToken = null, long needTime = 0,int direction_new = 0 , int direction_old = 0)
        {
            StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
            stateComponent.ObstructStatus = 0;
            int errorCode = stateComponent.CanMove();
            if (ErrorCode.ERR_Success != errorCode)
            {
                HintHelp.ShowErrorHint(unit.Root(), errorCode);
                stateComponent.CheckSilence();
                return -1;
            }

            float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            if (speed <= 0.1f)
            {
                HintHelp.ShowHint(unit.Root(), "速度异常,请重新登录");
            }

            C2M_PathfindingRequest msg = C2M_PathfindingRequest.Create();
            msg.Position = targetPos;
            msg.NeedTime = needTime;
            msg.direction_new = direction_new;
            msg.direction_old = direction_old;
            unit.Root().GetComponent<ClientSenderCompnent>().Send(msg);

            ObjectWait objectWait = unit.GetComponent<ObjectWait>();

            // 要取消上一次的移动协程
            objectWait.Notify(new Wait_UnitStop() { Error = WaitTypeError.Cancel });

            // 一直等到unit发送stop
            Wait_UnitStop waitUnitStop = await objectWait.Wait<Wait_UnitStop>(cancellationToken);
            if (cancellationToken.IsCancel())
            {
                return WaitTypeError.Cancel;
            }

            return waitUnitStop.Error;
        }

        
        // 可以多次调用，多次调用的话会取消上一次的协程
        public static async ETTask<int> MoveResultToAsync(this Unit unit, List<float3> pathlist,  ETCancellationToken cancellationToken = null ,long needTime = 0,int direction_new = 0 , int direction_old = 0)
        {
            StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
            stateComponent.ObstructStatus = 0;
            int errorCode = stateComponent.CanMove();
            if (ErrorCode.ERR_Success != errorCode)
            {
                HintHelp.ShowErrorHint(unit.Root(), errorCode);
                stateComponent.CheckSilence();
                return -1;
            }

            float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            if (speed <= 0.1f)
            {
                HintHelp.ShowHint(unit.Root(), "速度异常,请重新登录");
            }

            C2M_PathfindingResult msg = C2M_PathfindingResult.Create();
            msg.Position = pathlist;
            msg.NeedTime = needTime;
            msg.direction_old = direction_old;
            msg.direction_new = direction_new;
            unit.Root().GetComponent<ClientSenderCompnent>().Send(msg);
            ObjectWait objectWait = unit.GetComponent<ObjectWait>();

            // 要取消上一次的移动协程
            objectWait.Notify(new Wait_UnitStop() { Error = WaitTypeError.Cancel });

            // 一直等到unit发送stop
            Wait_UnitStop waitUnitStop = await objectWait.Wait<Wait_UnitStop>(cancellationToken);
            if (cancellationToken.IsCancel())
            {
                return WaitTypeError.Cancel;
            }

            return waitUnitStop.Error;
        }

        
        public static async ETTask MoveToAsync(this Unit unit, List<float3> path)
        {
            float speed = unit.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            await moveComponent.MoveToAsync(path, speed);
        }

        public static void Stop(Scene root, bool YaoGan)
        {
            C2M_Stop c2MStop = C2M_Stop.Create();
            c2MStop.YaoGan = YaoGan;
            root.GetComponent<ClientSenderCompnent>().Send(c2MStop);
        }
    }
}