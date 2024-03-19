using System.Collections.Generic;
using System;


namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class DBSaveComponent:Entity, IAwake, ITransfer
    {
        public long Timer { get; set; }
        public long DBInterval{ get; set; }
        public long NoFindPath{ get; set; }

        public HashSet<Type> EntityChangeTypeSet { get; } = new HashSet<Type>();
    }
}