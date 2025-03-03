using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UICellTransferHpComponent : Entity, IAwake, IDestroy
    {

        public bool EnterRange;

        public long InitTime;

        public long Timer;
    }
}