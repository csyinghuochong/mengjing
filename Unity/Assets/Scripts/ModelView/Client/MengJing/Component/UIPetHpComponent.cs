using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UIPetHpComponent : Entity, IAwake, IDestroy
    {
        public GameObject GameObject { get; set; }
        public GameObject Img_HpValue;

        public Transform UIPosition;

        public GameObject UIPlayerHpText;
        public GameObject Lal_Name;
        public GameObject Lal_JiaZuName;

        private EntityRef<ES_MainBuff> es_MainBuff;
        public ES_MainBuff ES_MainBuff { get => this.es_MainBuff; set => this.es_MainBuff = value; }

        public string HeadBarPath;
    }
}