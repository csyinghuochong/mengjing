using Unity.Mathematics;

namespace ET.Server
{


    public class AI_Pasture : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();

            for (int i = 0; i < 100000; ++i)
            {
                float3 nextTarget;
                if (unit.Type == UnitType.Pasture)
                {
                    nextTarget = JiaYuanHelper.GetRandomPos();
                }
                else
                {
                    nextTarget = ConfigData.JiaYuanPetPosition[RandomHelper.RandomNumber(0, ConfigData.JiaYuanPetPosition.Count)];
                }
                unit.FindPathMoveToAsync(nextTarget).Coroutine();
                long waitTime = RandomHelper.RandomNumber(40000, 100000);
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(waitTime, cancellationToken);
                if (cancellationToken.IsCancel())
                {

                    return;
                }
            }
        }
    }
}