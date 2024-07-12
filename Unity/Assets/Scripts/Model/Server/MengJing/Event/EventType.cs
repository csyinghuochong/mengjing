namespace ET.Server
{
  
    public struct GMCommonRequest
    {
        public string Context;
    }
    
    public struct UnitKillEvent
    {
        public int WaitRevive;
        public Unit UnitAttack;
        public Unit UnitDefend;
    }
    
    public struct StateTypeAdd
    {
        public Unit UnitDefend;
        public long nowStateType;
    }
}