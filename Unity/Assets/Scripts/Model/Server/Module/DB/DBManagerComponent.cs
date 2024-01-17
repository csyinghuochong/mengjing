using System;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class DBManagerComponent: Entity, IAwake, IDestroy
    {

        [StaticField]
        public static DBManagerComponent Instance { get;  set; } 
        public DBComponent[] DBComponents = new DBComponent[IdGenerater.MaxZone];
    }
}