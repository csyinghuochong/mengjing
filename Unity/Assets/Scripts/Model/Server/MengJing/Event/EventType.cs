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
}