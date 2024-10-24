namespace ET.Server
{
    [Event(SceneType.Map)]
    public class StateTypeRemove_OnNotify : AEvent<Scene, StateTypeRemove>
    {
        protected override async ETTask Run(Scene scene, StateTypeRemove args)
        {
            Unit unit = args.UnitDefend;
            
            unit.GetComponent<SkillManagerComponentS>().InterruptSing(0, true);
            unit.GetComponent<SkillPassiveComponent>().StateTypeAdd(args.nowStateType);

            M2C_UnitStateUpdate M2C_UnitStateUpdate = M2C_UnitStateUpdate.Create();
            
            if (ComHelperS.IsStateBroadcastType(args.nowStateType))
            {
                M2C_UnitStateUpdate.UnitId = unit.Id;
                M2C_UnitStateUpdate.StateType = (long)args.nowStateType;
                M2C_UnitStateUpdate.StateValue = args.stateValue;
                M2C_UnitStateUpdate.StateOperateType = 1;
                M2C_UnitStateUpdate.StateTime = 0;
                MapMessageHelper.Broadcast(unit, M2C_UnitStateUpdate);
            }
            else
            {
                if (unit.Type == UnitType.Player)
                {
                    M2C_UnitStateUpdate.UnitId = unit.Id;
                    M2C_UnitStateUpdate.StateType = (long)args.nowStateType;
                    M2C_UnitStateUpdate.StateValue = args.stateValue;
                    M2C_UnitStateUpdate.StateOperateType = 1;
                    M2C_UnitStateUpdate.StateTime = 0;
                    MapMessageHelper.SendToClient(unit, M2C_UnitStateUpdate);
                }
            }
            await ETTask.CompletedTask;
        }
    }
}