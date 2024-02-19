using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public struct SceneChangeStart
    {
    }
    
    public struct SceneChangeFinish
    {
    }
    
    public struct AfterCreateClientScene
    {
    }
    
    public struct AfterCreateCurrentScene
    {
    }

    public struct AppStartInitFinish
    {
    }

    public struct LoginFinish
    {
    }

    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }

    public struct ShowItemTips
    {
        public Scene Scene;
        public BagInfo BagInfo;
        public ItemOperateEnum ItemOperateEnum;
        public float3 InputPoint;
        public List<BagInfo> EquipList;
        public int Occ;
    }
}