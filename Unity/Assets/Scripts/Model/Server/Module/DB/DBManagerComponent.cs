namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class DBManagerComponent: Entity, IAwake, IDestroy
    {

        //[StaticField]
        //public static DBManagerComponent Instance { get;  set; } 
        public EntityRef<DBComponent>[] DBComponents = new EntityRef<DBComponent>[IdGenerater.MaxZone];
        
    }
}