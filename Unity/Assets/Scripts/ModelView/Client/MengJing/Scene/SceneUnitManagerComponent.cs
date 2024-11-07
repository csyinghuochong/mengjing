using System.Collections.Generic;

namespace ET.Client
{

    [ComponentOf(typeof (Scene))]
    public class SceneUnitManagerComponent: Entity, IAwake, IDestroy
    {

        public Dictionary<string, List<MapObjectItem>> MapObjectConfigs = new Dictionary<string, List<MapObjectItem>>();

        public SceneUnit MainSceneUnit { get; set; }

        public long Timer;
    }
}