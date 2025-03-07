using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class DBSaveComponent:Entity, IAwake, ITransfer, IDestroy
    {
        public long Timer= 0;
        public long DBInterval{ get; set; }   //秒
        public long NoFindPath{ get; set; }

        public PlayerState PlayerState { get; set; }

        public HashSet<Type> EntityChangeTypeSet { get; } = new HashSet<Type>();
    }
}