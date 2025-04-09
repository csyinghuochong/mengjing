namespace ET.Server
{
    [Event(SceneType.Map)]
    public class StateTypeAdd_OnNotify : AEvent<Scene, StateTypeAdd>
    {

        protected override async ETTask Run(Scene scene, StateTypeAdd args)
        {
            Unit unit = args.UnitDefend;
            long nowStateType = args.nowStateType;
            StateComponentS stateComponentS = unit.GetComponent<StateComponentS>();
            if (ErrorCode.ERR_Success != stateComponentS.CanMove() && unit.GetComponent<MoveComponent>()!=null)
            {
                unit.Stop(0);      
            }
            if (nowStateType == StateTypeEnum.Dizziness)
            {
                unit.GetComponent<SkillPassiveComponent>().OnTrigegerPassiveSkill(SkillPassiveTypeEnum.Dizziness_13);
            }
            if (nowStateType == StateTypeEnum.BaTi)
            {
                unit.GetComponent<BuffManagerComponentS>().OnRemoveBuffByState(StateTypeEnum.Dizziness);
            }
            
            unit.GetComponent<SkillManagerComponentS>().InterruptSing(0, true);
            unit.GetComponent<SkillPassiveComponent>()?.StateTypeAdd(nowStateType);
  
            M2C_UnitStateUpdate M2C_UnitStateUpdate = M2C_UnitStateUpdate.Create();
            if (CommonHelperS.IsStateBroadcastType(nowStateType))
            {
                M2C_UnitStateUpdate.UnitId = unit.Id;
                M2C_UnitStateUpdate.StateType = (long)nowStateType;
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
                    M2C_UnitStateUpdate.StateType = (long)nowStateType;
                    M2C_UnitStateUpdate.StateOperateType = 1;
                    M2C_UnitStateUpdate.StateTime = 0;
                    
                    MapMessageHelper.SendToClient(unit, M2C_UnitStateUpdate);
                }
            }
            await ETTask.CompletedTask;
        }
    }
}