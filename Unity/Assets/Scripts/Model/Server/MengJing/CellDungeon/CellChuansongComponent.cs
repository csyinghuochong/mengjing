
using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class CellChuansongComponent : Entity, IAwake, IDestroy
    {
        public bool EnterRange;

        public long InitTime;

        public long Timer;
        
        public int SceneType;   
    }
}