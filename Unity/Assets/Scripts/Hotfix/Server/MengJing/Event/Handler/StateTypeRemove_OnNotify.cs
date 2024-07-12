using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class StateTypeRemove_OnNotify : AEvent<Scene, StateTypeRemove>
    {
        protected override async ETTask Run(Scene scene, StateTypeRemove args)
        {
            
            //unit.GetComponent<SkillManagerComponent>().InterruptSing(0, true);
            //unit.GetComponent<SkillPassiveComponent>().StateTypeAdd(nowStateType);
            ////���͸ı����Ե������Ϣ
            //if (self.IsBroadcastType(nowStateType))
            //{
            //    MessageHelper.Broadcast(self.GetParent<Unit>(), new M2C_UnitStateUpdate() { UnitId = self.Parent.Id, StateType = (long)nowStateType, StateValue = stateValue, StateOperateType = 1, StateTime = 0 });
            //}
            //else
            //{
            //    if (unit.Type == UnitType.Player)
            //    {
            //        MessageHelper.SendToClient(self.GetParent<Unit>(), new M2C_UnitStateUpdate() { UnitId = self.Parent.Id, StateType = (long)nowStateType, StateValue = stateValue, StateOperateType = 1, StateTime = 0 });
            //    }
            //}
            await ETTask.CompletedTask;
        }
    }
}