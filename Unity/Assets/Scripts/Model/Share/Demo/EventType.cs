using System.Collections.Generic;
using Unity.Mathematics;

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
    
    public struct UnitDead
    {
        public Unit Unit;
    }

}