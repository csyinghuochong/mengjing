using Unity.Mathematics;

namespace ET.Server
{
    
    public class RoleBuff_Bounce: BuffHandlerS
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
            buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.NoMove);
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
            buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.NoMove);
        }
    }
    
}