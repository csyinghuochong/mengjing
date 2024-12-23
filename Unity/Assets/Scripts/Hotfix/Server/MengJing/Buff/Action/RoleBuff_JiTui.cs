using Unity.Mathematics;

namespace ET.Server
{

    public class RoleBuff_JiTui: BuffHandlerS
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffData"></param>
        /// <param name="theUnitFrom">buff持有者</param>
        /// <param name="theUnitBelongto">施法者</param>
        /// <param name="skillHandler"></param>
        public override void OnInit(BuffS buffS, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler)
        {
            buffS.OnBaseBuffInit(buffS.BuffData, theUnitFrom, theUnitBelongto);
            int buff_time = buffS.mBuffConfig.BuffTime;
            float oldSpeed = theUnitFrom.GetComponent<NumericComponentS>().GetAsFloat(NumericType.Now_Speed);
            float newSpeed = (float)buffS.mBuffConfig.buffParameterValue;
            float distance = (buff_time * newSpeed) * 0.001f;
            float3 dir = (theUnitBelongto.Position - theUnitFrom.Position).normalize();
            if (theUnitBelongto.Id == theUnitFrom.Id)
            {
                dir = math.mul(theUnitBelongto.Rotation, new float3(0, 0, -1));
            }
            float3 vector3 = theUnitBelongto.Position + dir * distance;
            buffS.BeginTime = TimeHelper.ServerNow();
            buffS.StartPosition = theUnitBelongto.Position;
            buffS.TargetPosition =  theUnitBelongto.GetComponent<PathfindingComponent>().GetCanChongJiPath(theUnitBelongto.Position, vector3);

            int speedRate = 100;
            if (newSpeed > oldSpeed )
            {
                speedRate = (int)(newSpeed * 100f / oldSpeed);
            }
            theUnitBelongto.Stop(-1);
            theUnitBelongto.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.JiTui);
            theUnitBelongto.FindPathMoveToAsync(buffS.TargetPosition ,speedRate).Coroutine();
        }

        public override void OnUpdate(BuffS buffS)
        {
            if (TimeHelper.ServerNow() >= buffS.BuffEndTime)
            {
                buffS.BuffState = BuffState.Finished;
            }
        }

        public override void OnFinished(BuffS buffS)
        {
            buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.JiTui);
        }
    }
}