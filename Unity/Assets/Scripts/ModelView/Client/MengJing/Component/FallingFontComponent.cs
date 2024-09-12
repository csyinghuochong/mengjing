using System.Collections.Generic;
using System.Numerics;

namespace ET.Client
{
    public enum FallingFontType
    {
        Normal = 0,
        Self = 1,
        Target = 2,
        Add = 3,
        Special = 4
    }
    
    [ComponentOf(typeof(Scene))]
    public class FallingFontComponent : Entity, IAwake, IDestroy
    {
        public Unit Unit { get; set; }
        public string ShowText;
        public FallingFontType FontType;
        public Vector3 StartScale;
        
        public long Timer;
        public List<EntityRef<FallingFontShowComponent>> FallingFontShows = new();
        
        public int BatchSize = 50; // 每帧处理的任务数
        public int Index = -1;
    }
}