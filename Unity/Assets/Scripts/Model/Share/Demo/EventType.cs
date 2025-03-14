using System.Collections.Generic;

namespace ET.Client
{
    public struct SceneChangeStart
    {
        public Scene RootScene;
        public int LastSceneType;
        public int LastChapterId;
        public int SceneType;
        public int ChapterId;
    }

    public struct SceneChangeFinish
    {
        public int SceneType;
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
    
    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }

    public struct UnitRemove
    {
        public List<long> RemoveIds;
    }

    public struct UnitDead
    {
        public bool Wait;
        public Unit Unit;
    }

    public struct UnitRevive
    {
        public Unit Unit;
    }
    
    public struct LoginFinish
    {
    }
    
    public struct SessionDispose
    {
        
    }
}