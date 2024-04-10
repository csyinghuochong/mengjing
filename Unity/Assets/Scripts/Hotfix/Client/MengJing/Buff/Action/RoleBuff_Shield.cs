namespace ET.Client
{
    public class RoleBuff_Shield : RoleBuff_Base
    {
        public override void OnUpdate(BuffC buffC)
        {
            buffC.BaseOnUpdate();

            NumericComponentC numericComponent = buffC.TheUnitBelongto.GetComponent<NumericComponentC>();
            if (numericComponent.GetAsLong(NumericType.Now_Shield_HP) <= 0)
            {
                buffC.BuffState = BuffState.Finished;
                return;
            }
            if (TimeHelper.ServerNow() >= buffC.BuffEndTime)
            {
                buffC.BuffState = BuffState.Finished;
            }
        }
    }
}
