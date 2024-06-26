using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class UIPetHpComponent: Entity, IAwake, IDestroy
    {
        public GameObject GameObject { get; set; }
        public GameObject Img_HpValue;

        public Transform UIPosition;

        public GameObject UIPlayerHpText;
        public GameObject Lal_Name;
        public GameObject Lal_JiaZuName;

        public string HeadBarPath;
    }
}