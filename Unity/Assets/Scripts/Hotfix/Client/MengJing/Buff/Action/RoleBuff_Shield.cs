﻿namespace ET
{
    [BuffHandler]
    public class RoleBuff_Shield : RoleBuff_Base
    {
        public override void OnUpdate()
        {
            this.BaseOnUpdate();

            NumericComponent numericComponent = this.TheUnitBelongto.GetComponent<NumericComponent>();
            if (numericComponent.GetAsLong(NumericType.Now_Shield_HP) <= 0)
            {
                this.BuffState = BuffState.Finished;
                return;
            }
            if (TimeHelper.ServerNow() >= this.BuffEndTime)
            {
                this.BuffState = BuffState.Finished;
            }
        }
    }
}
