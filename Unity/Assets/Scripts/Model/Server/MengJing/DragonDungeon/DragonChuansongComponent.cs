using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class DragonChuansongComponent : Entity, IAwake, IDestroy
    {
        public long Timer;

        public bool Enter;
    }
}