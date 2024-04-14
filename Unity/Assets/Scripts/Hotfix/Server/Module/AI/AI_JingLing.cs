using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
    public class AI_JingLing : AAIHandler
    {

        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 1;
        }

        public static float3 GetFollowPosition(Unit unit, Unit master)
        {
            float3 dir = math.normalize(unit.Position - master.Position);
            float3 tar = master.Position + dir * math.forward() * 1.5f;
            return tar;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            long unitId = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);
            Unit master = unit.GetParent<UnitComponent>().Get(unitId);

            while (true)
            {
                long nowspeed = master.GetComponent<NumericComponentS>().GetAsLong(NumericType.Now_Speed) + 1 ;
                int errorCode = unit.GetComponent<StateComponentS>().CanMove();
                float distacne = math.distance(unit.Position, master.Position);

                if (errorCode == ErrorCode.ERR_Success && distacne > 2f)
                {
                    nowspeed = (long)(nowspeed * distacne / 2f);
                }
                else
                {
                    nowspeed = 0;
                }

                //宠物移动速度限制
                if (nowspeed >= 100000) {
                    nowspeed = 100000;
                }

                if (nowspeed > 0)
                {
                    float3 nextTarget = GetFollowPosition(unit, master);
                    unit.GetComponent<NumericComponentS>().Set(NumericType.Now_Speed, nowspeed);
                    unit.FindPathMoveToAsync(nextTarget).Coroutine();
                }
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(200, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    break;
                }
            }
        }
    }
}