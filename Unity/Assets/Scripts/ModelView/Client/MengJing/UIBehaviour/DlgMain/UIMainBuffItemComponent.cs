using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ChildOf]
    public class UIMainBuffItemComponent: Entity, IAwake<GameObject>, IDestroy
    {
        public Text TextNumber;
        public GameObject TextLeftTime;
        public GameObject TextBuffName;
        public GameObject Img_BuffCD;
        public GameObject ImgBufflIcon;
        public GameObject GameObject;

        public int BuffID;
        public long BuffTime;
        public long EndTime;
        public string SpellCast;
        public string BuffIcon;
        public string aBAtlasTypes;

        public long UnitId;
        public BuffManagerComponentC BuffManagerComponent { get; set; }
    }
}