using System.Collections.Generic;
using System;


namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class DBSaveComponent:Entity, IAwake, ITransfer, IDestroy
    {
        public long Timer= 0;
        public long DBInterval{ get; set; }
        public long NoFindPath{ get; set; }

        public HashSet<Type> EntityChangeTypeSet { get; } = new HashSet<Type>();
    }
}