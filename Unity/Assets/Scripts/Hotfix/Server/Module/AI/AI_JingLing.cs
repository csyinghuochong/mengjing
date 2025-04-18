using Unity.Mathematics;

namespace ET.Server
{
    
    public class AI_JingLing : AAIHandler
    {

        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 0;
        }

        private static float3 GetFollowPosition(Unit unit, Unit master)
        {
            float3 dir = unit.Position - master.Position;
            float ange = math.degrees(math.atan2(dir.x, dir.z));
            float addg = unit.Id % 50;
            quaternion rotation = quaternion.Euler(0, math.radians(ange + addg), 0);
            float3 tar = master.Position + math.mul(rotation, math.forward()) * 1f;
            return tar;
        }
        
        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            
            Unit unit = aiComponent.GetParent<Unit>();
            NumericComponentS numericComponentS = unit.GetComponent<NumericComponentS>();
            long masterid =numericComponentS.GetAsLong(NumericType.MasterId);
            Unit master = unit.GetParent<UnitComponent>().Get(masterid);
           
            long oldSpeed =numericComponentS.GetAsLong(NumericType.Base_Speed_Base);
            
            long masterspeed = master.GetComponent<NumericComponentS>().GetAsLong(NumericType.Now_Speed);
            numericComponentS.ApplyValue(NumericType.Base_Speed_Base, masterspeed);
            
            while (true)
            {
                int speedProp = 100;
                int errorCode = unit.GetComponent<StateComponentS>().CanMove();
                float distacne = math.distance(unit.Position, master.Position);

                if (errorCode == ErrorCode.ERR_Success && distacne > 10f)  //距离大于10米加速追
                {
                    speedProp = 150;
                }
                if(errorCode != ErrorCode.ERR_Success ||  distacne < 2f)   //距离小于2米停止追
                {
                    speedProp = 0;
                }

                //宠物移动速度限制
                if (speedProp > 0)
                {
                    float3 nextTarget = GetFollowPosition(unit, master);
                    unit.FindPathMoveToAsync(nextTarget, speedProp).Coroutine();
                }

                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(300, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    break;
                }
            }

            if (!unit.IsDisposed)
            {
                unit.GetComponent<NumericComponentS>()?.ApplyValue(NumericType.Base_Speed_Base, oldSpeed);
            }
            
            // Unit unit = aiComponent.GetParent<Unit>();
            // long unitId = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);
            // Unit master = unit.GetParent<UnitComponent>().Get(unitId);
            //
            // while (true)
            // {
            //     if (master != null)
            //     {
            //         long nowspeed = master.GetComponent<NumericComponentS>().GetAsLong(NumericType.Now_Speed) + 1 ;
            //         int errorCode = unit.GetComponent<StateComponentS>().CanMove();
            //         float distacne = math.distance(unit.Position, master.Position);
            //      
            //         if (errorCode == ErrorCode.ERR_Success && distacne > 2f)
            //         {
            //             nowspeed = (long)(nowspeed * distacne / 2f);
            //         }
            //         else
            //         {
            //             nowspeed = 0;
            //         }
            //      
            //         //宠物移动速度限制
            //         if (nowspeed >= 100000) {
            //             nowspeed = 100000;
            //         }
            //      
            //         if (nowspeed > 0)
            //         {
            //             float3 nextTarget = GetFollowPosition(unit, master);
            //             unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Speed, nowspeed);
            //             unit.FindPathMoveToAsync(nextTarget).Coroutine();
            //         }
            //     }
            //     else
            //     {
            //         Log.Debug("master == null");
            //     }
            //     
            //     await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(200, cancellationToken);
            //     if (cancellationToken.IsCancel())
            //     {
            //         break;
            //     }
            // }
        }
    }
}