using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class GameObjectComponent: Entity, IAwake, IDestroy
    {
        public string UnitAssetsPath { get; set; }
        public GameObject GameObject { get; set; }
        public string HorseAssetsPath;
        public GameObject ObjectHorse;
        public Material Material;
        public long DelayShow;

        public long HighLightTimer;
        public long DelayShowTimer;
        public string OldShader;

        public bool BianShenEffect;
        public bool Dissolve { get; set; }
    }
}