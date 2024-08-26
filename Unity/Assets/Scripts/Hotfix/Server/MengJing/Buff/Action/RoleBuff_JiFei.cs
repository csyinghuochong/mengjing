using Unity.Mathematics;

namespace ET.Server
{
    
    public class RoleBuff_JiFei: BuffHandlerS
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
            float speed = (float)buffS.mBuffConfig.buffParameterValue;
            float distance = (buffS.mBuffConfig.buffParameterType * speed) * 0.001f;
            float3 dir = (theUnitBelongto.Position - theUnitFrom.Position).normalize();
            float3 vector3 = theUnitBelongto.Position + dir * distance;
            theUnitBelongto.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.JiTui);
            buffS.BeginTime = TimeHelper.ServerNow();
            buffS.StartPosition = theUnitBelongto.Position;
            buffS.TargetPosition = vector3;
            buffS.TheUnitBelongto.Position = buffS.TargetPosition;
        }

        public override void OnUpdate(BuffS buffS)
        {
            if (TimeHelper.ServerNow() >= buffS.BuffEndTime)
            {
                buffS.BuffState = BuffState.Finished;
                buffS.TheUnitBelongto.Position = buffS.StartPosition;
                Log.Console($"stop: {buffS.TheUnitBelongto.Position.x} {buffS.TheUnitBelongto.Position.z}");
                buffS.TheUnitBelongto.Stop(-2);
            }
        }

        public override void OnFinished(BuffS buffS)
        {
            buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.JiTui);
        }
    }
    
}