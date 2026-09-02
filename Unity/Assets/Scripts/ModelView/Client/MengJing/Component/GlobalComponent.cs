using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class GlobalComponent : Entity, IAwake, IDestroy
    {
        [StaticField]
        public static GlobalComponent Instance { get; set; }

        public Transform Global { get; set; }
        public Transform Unit { get; set; }
        public Transform UI;

        public GlobalConfig GlobalConfig { get; set; }

        public Transform BloodRoot { get; set; }
        public Transform NormalRoot { get; set; }
        public Transform MidRoot { get; set; }
        public Transform PopUpRoot { get; set; }
        public Transform FixedRoot { get; set; }
        public Transform PoolRoot { get; set; }
        public Transform OtherRoot { get; set; }

        public Transform MainCamera { get; set; }

        public Transform UICamera { get; set; }

        public GameObject BloodPlayer { get; set; }
        public GameObject BloodMonster { get; set; }

        public GameObject BloodText { get; set; }
        public GameObject BloodText_Layer0 { get; set; }
        public GameObject BloodText_Layer1 { get; set; }
        public GameObject BloodText_Layer2 { get; set; }
    }
}