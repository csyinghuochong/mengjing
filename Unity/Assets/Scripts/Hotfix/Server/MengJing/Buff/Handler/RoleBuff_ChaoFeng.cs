

namespace ET.Server
{
    
    public class RoleBuff_ChaoFeng: BuffHandlerS
    {
        public override void OnInit(BuffS buffS, Unit theUnitFrom, Unit theUnitBelongto, SkillS skillHandler)
        {
            buffS.OnBaseBuffInit(buffS.BuffData, theUnitFrom, theUnitBelongto);

            if (theUnitBelongto.Type == UnitType.Monster || theUnitBelongto.Type == UnitType.Pet)
            {
                theUnitBelongto.GetComponent<AIComponent>().ChangeTarget( theUnitFrom.Id);
                buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.ChaoFeng);
            }
        }

        public override void OnUpdate(BuffS buffS)
        {
            if (TimeHelper.ServerNow() > buffS.BuffEndTime)
            {
                buffS.BuffState = BuffState.Finished;
            }
        }

        public override void OnFinished(BuffS buffS)
        {
            if (buffS.TheUnitBelongto.Type == UnitType.Monster || buffS.TheUnitBelongto.Type == UnitType.Pet)
            {
                buffS.TheUnitBelongto.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.ChaoFeng);
            }
        }
    }
}