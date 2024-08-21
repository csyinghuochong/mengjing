using Unity.Mathematics;

namespace ET.Server
{
    
    
    public class RoleBuff_Fear: BuffHandlerS
    {
        public override void OnInit(BuffS buffS, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler)
        {
            buffS.OnBaseBuffInit(buffS.BuffData, theUnitFrom, theUnitBelongto);
            buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.Fear);

            float3 targetpos = new float3
                (
                    buffS.TheUnitBelongto.Position.x + RandomHelper.RandomNumberFloat(-10, 10),
                    buffS.TheUnitBelongto.Position.y,
                    buffS.TheUnitBelongto.Position.z + RandomHelper.RandomNumberFloat(-10, 10)
                );
            buffS.TargetPosition = targetpos;
            buffS.TargetPosition = buffS.TheUnitBelongto.GetComponent<PathfindingComponent>().GetCanChongJiPath(buffS.TheUnitBelongto.Position, buffS.TargetPosition);
            buffS.TheUnitBelongto.FindPathMoveToAsync(buffS.TargetPosition).Coroutine();
        }

        public override void OnUpdate(BuffS buffS)
        {
            if (TimeHelper.ServerNow() > buffS.BuffEndTime)
            {
                buffS.BuffState = BuffState.Finished;
            }

            if (PositionHelper.Distance2D(buffS.TargetPosition, buffS.TheUnitBelongto.Position) < 0.5f)
            {
                float3 targetposition = new float3(buffS.TheUnitBelongto.Position.x + RandomHelper.RandomNumberFloat(-8, 8),
                    buffS.TheUnitBelongto.Position.y,
                    buffS.TheUnitBelongto.Position.z + RandomHelper.RandomNumberFloat(-8, 8));

                buffS.TargetPosition = targetposition;
                int navmeshid = buffS.TheUnitBelongto.Scene().GetComponent<MapComponent>().NavMeshId;
                buffS.TargetPosition = MoveHelper.GetCanReachPath(navmeshid, buffS.TheUnitBelongto.Position, buffS.TargetPosition);
                buffS.TheUnitBelongto.FindPathMoveToAsync(buffS.TargetPosition).Coroutine();
            }
        }

        public override void OnFinished(BuffS buffS)
        {
            buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.Fear);
        }
    }
    
}