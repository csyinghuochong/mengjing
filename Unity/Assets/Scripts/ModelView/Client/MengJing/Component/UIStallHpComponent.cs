using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{  
    [ComponentOf(typeof(Unit))]
    public class UIStallHpComponent: Entity, IAwake, IDestroy
    {
        public GameObject DialogText;
        public GameObject Lal_Name;
        public GameObject Img_HpValue{ get; set; }
        public GameObject GameObject { get; set; }
        public GameObject UIPlayerHpText { get; set; }
        public GameObject BuffShieldValue;
        public GameObject Img_ChengHao;
        public Image Img_AngleValue;
        public GameObject Img_AngleValueDi;
        public GameObject Img_MpValueDi;
        public Image Img_MpValue;

        public Transform UIPosition;
        public string HeadBarPath;
        public Vector2 LastPositon;
        public GameObject Lal_AddtionName;
        public GameObject PlayerNameSet;
        public GameObject Lal_JiaZuName;
        public float LastTime;
                public long Timer;
                public long DialogTimer;
    }
}