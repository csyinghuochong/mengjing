using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{

    [ComponentOf()]
    public class SceneAOIEntity: Entity, IAwake<int, float3>, IDestroy
    {
     public SceneUnit Unit => this.GetParent<SceneUnit>();
    
     public int ViewDistance;
    
     public bool MainHero { get; set; }
        
     private EntityRef<SceneCell> cell;
    
     public SceneCell Cell
     {
         get
         {
             return this.cell;
         }
         set
         {
             this.cell = value;
         }
     }
    
     // 观察进入视野的Cell
     public HashSet<long> SubEnterCells = new HashSet<long>();
    
     // 观察离开视野的Cell
     public HashSet<long> SubLeaveCells = new HashSet<long>();
     
     // 观察进入视野的Cell
     public HashSet<long> enterHashSet = new HashSet<long>();
    
     // 观察离开视野的Cell
     public HashSet<long> leaveHashSet = new HashSet<long>();
    
     // 我看的见的Unit
     public Dictionary<long, EntityRef<SceneAOIEntity>> SeeUnits = new Dictionary<long, EntityRef<SceneAOIEntity>>();
     
     // 看见我的Unit
     public Dictionary<long, EntityRef<SceneAOIEntity>> BeSeeUnits = new Dictionary<long, EntityRef<SceneAOIEntity>>();
     
     // 我看的见的Player
     public Dictionary<long, EntityRef<SceneAOIEntity>> SeePlayers = new Dictionary<long, EntityRef<SceneAOIEntity>>();
    
     // 看见我的Player单独放一个Dict，用于广播
     public Dictionary<long, EntityRef<SceneAOIEntity>> BeSeePlayers = new Dictionary<long, EntityRef<SceneAOIEntity>>();
    }
}
