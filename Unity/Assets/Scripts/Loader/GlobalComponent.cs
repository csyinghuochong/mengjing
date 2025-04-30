using UnityEngine;

namespace ET
{
    [FriendOf(typeof(GlobalComponent))]
    public static partial class GlobalComponentSystem
    {
        [EntitySystem]
        public static void Awake(this GlobalComponent self)
        {
            GlobalComponent.Instance = self;

            self.Global = GameObject.Find("/Global").transform;
            self.Unit = GameObject.Find("/Global/Unit").transform;
            self.UI = GameObject.Find("/Global/UI").transform;
            self.BloodRoot = GameObject.Find("/Global/UI/BloodRoot").transform;
            self.NormalRoot = GameObject.Find("/Global/UI/NormalRoot").transform;
            self.MidRoot = GameObject.Find("/Global/UI/MidRoot").transform;
            self.PopUpRoot = GameObject.Find("/Global/UI/PopUpRoot").transform;
            self.FixedRoot = GameObject.Find("/Global/UI/FixedRoot").transform;
            self.OtherRoot = GameObject.Find("/Global/UI/OtherRoot").transform;
            self.PoolRoot = GameObject.Find("/Global/PoolRoot").transform;
            self.MainCamera = GameObject.Find("/Global/MainCamera").transform;
            self.UICamera = GameObject.Find("/Global/UICamera").transform;
            self.GlobalConfig = Resources.Load<GlobalConfig>("GlobalConfig");

            self.BloodPlayer = new GameObject("BloodPlayer");
            self.BloodPlayer.AddComponent<RectTransform>();
            SetParent(self.BloodPlayer, self.BloodRoot.gameObject);
            self.BloodMonster = new GameObject("BloodMonster");
            self.BloodMonster.AddComponent<RectTransform>();
            SetParent(self.BloodMonster, self.BloodRoot.gameObject);

            self.BloodText = new GameObject("BloodText");
            self.BloodText.AddComponent<RectTransform>();
            SetParent(self.BloodText, self.BloodRoot.gameObject);
            self.BloodText_Layer0 = new GameObject("BloodText_Layer0");
            self.BloodText_Layer0.AddComponent<RectTransform>();
            SetParent(self.BloodText_Layer0, self.BloodText);
            self.BloodText_Layer1 = new GameObject("BloodText_Layer1");
            self.BloodText_Layer1.AddComponent<RectTransform>();
            SetParent(self.BloodText_Layer1, self.BloodText);
            self.BloodText_Layer2 = new GameObject("BloodText_Layer1");
            self.BloodText_Layer2.AddComponent<RectTransform>();
            SetParent(self.BloodText_Layer2, self.BloodText);
        }

        [EntitySystem]
        public static void Destroy(this GlobalComponent self)
        {
            GameObject.DestroyImmediate(  self.BloodPlayer );
            GameObject.DestroyImmediate(  self.BloodMonster );
            GameObject.DestroyImmediate(  self.BloodText );
            GameObject.DestroyImmediate(  self.BloodText_Layer0 );
            GameObject.DestroyImmediate(  self.BloodText_Layer1 );
            GameObject.DestroyImmediate(  self.BloodText_Layer2 );
            self.BloodPlayer  = null;
            self.BloodMonster= null;
            self.BloodText = null;
            self.BloodText_Layer0 = null;
            self.BloodText_Layer1 = null;
            self.BloodText_Layer2 = null;
        }

        public static void SetParent(GameObject son, GameObject parent)
        {
            if (son == null || parent == null)
                return;
            son.transform.SetParent(parent.transform);
            son.transform.localPosition = Vector3.zero;
            son.transform.localScale = Vector3.one;
        }
    }

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