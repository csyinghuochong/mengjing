using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class UIJingLingHpComponent: Entity, IAwake, IDestroy
    {
        public GameObject GameObject { get; set; }

        public Transform UIPosition;

        public GameObject UIPlayerHpText;
        public GameObject Lal_Name;
        public GameObject Lal_JiaZuName;

        public string HeadBarPath;
    }
}