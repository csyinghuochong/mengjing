using System.Collections.Generic;


namespace ET
{
    
    [ComponentOf(typeof(Scene))]
    public class RandNameComponent : Entity, IAwake
    {
        
        public List<string> RandNameNameList = new List<string>();
        public List<string> RandNameXing = new List<string>();
    }
}

