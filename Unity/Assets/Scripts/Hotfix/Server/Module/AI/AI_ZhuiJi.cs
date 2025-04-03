using Unity.Mathematics;

namespace ET.Server
{

    public class AI_ZhuiJi : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            if (aiComponent.TargetID == 0 || aiComponent.IsRetreat)
            {
                return 1;
            }
            Unit target = aiComponent.Scene().GetComponent<UnitComponent>().Get(aiComponent.TargetID);
            if (target == null)
            {
                aiComponent.TargetID = 0;
                return 1;
            }
            
            //获取范敌人是否在攻击范围内
            float distance = math.distance(target.Position, aiComponent.GetParent<Unit>().Position);
            bool zhuiji = distance >= aiComponent.ActDistance && (aiComponent.Parent as Unit).GetComponent<StateComponentS>().IsCanZhuiJi();
            return zhuiji?0 : 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            //获取附近最近距离的目标进行追击
            Unit unit = aiComponent.GetParent<Unit>();
            StateComponentS stateComponent = unit.GetComponent<StateComponentS>();

            long checktime;
            switch (aiComponent.SceneType)
            {
                case MapTypeEnum.PetDungeon:
                case MapTypeEnum.PetTianTi:
                case MapTypeEnum.PetMing:
                    checktime = 100;
                    break;
                default:
                    checktime = 200;
                    break;
            }

            for (int i = 0; i < 10000; i++)
            {
                Unit target = unit.GetParent<UnitComponent>().Get(aiComponent.TargetID);
                if (target != null)
                {
                    bool zhuiji =   math.distance(unit.Position, target.Position) >= aiComponent.ActDistance;
                    if (!zhuiji)
                    {
                        unit.Stop(-2);
                    }
                    if (zhuiji && checktime == 100 && stateComponent.CanMove() == ErrorCode.ERR_Success)
                    {
                        unit.FindPathMoveToAsync(target.Position).Coroutine();
                    }
                    if (zhuiji && checktime == 200 && stateComponent.CanMove() == ErrorCode.ERR_Success && i % 5 == 0)
                    {
                        float3 dir = unit.Position - target.Position;
                        float ange = math.degrees(math.atan2(dir.x, dir.z));
                        float addg = unit.Id % 100;
                        quaternion rotation = quaternion.Euler(0, math.radians(ange + addg), 0);
                        float3 ttt = target.Position + math.mul(rotation, math.forward()) * 1f;
                        unit.FindPathMoveToAsync(ttt).Coroutine();
                    }
                }
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(checktime, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }


}
