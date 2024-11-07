using System.Collections.Generic;

namespace ET.Client
{
    
    [ChildOf(typeof(SceneAOIManagerComponent))]
    public class SceneCell: Entity, IAwake, IDestroy
    {
        // 处在这个cell的单位
        public Dictionary<long, EntityRef<SceneAOIEntity>> AOIUnits = new Dictionary<long, EntityRef<SceneAOIEntity>>();

        // 订阅了这个Cell的进入事件
        public Dictionary<long, EntityRef<SceneAOIEntity>> SubsEnterEntities = new Dictionary<long, EntityRef<SceneAOIEntity>>();

        // 订阅了这个Cell的退出事件
        public Dictionary<long, EntityRef<SceneAOIEntity>> SubsLeaveEntities = new Dictionary<long, EntityRef<SceneAOIEntity>>();
    }
}