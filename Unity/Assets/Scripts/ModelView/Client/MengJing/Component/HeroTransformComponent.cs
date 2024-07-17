using UnityEngine;

namespace ET.Client
{
    
    /// <summary>
    /// 位置类型
    /// </summary>
    public static class PosType
    {
        public const string Name = "Name";
        public const string Hp = "Hp";
        public const string MiddleBuff = "MiddleBuff";

        public const string Di = "Di";
        public const string Center = "Center";
        public const string Head = "Head";
        public const string Hand = "Hand";

        public const string Weapon_R = "Weapon_R";
    }
    
    [ComponentOf(typeof(Unit))]
    public class HeroTransformComponent : Entity, IAwake
    {
        public Transform namePos { get; set; }
        public Transform pos_di{ get; set; }
        public Transform pos_center{ get; set; }
        public Transform pos_Head{ get; set; }
        public Transform middleBuffPos{ get; set; }
        public GameObject RunEffect{ get; set; }
        public Transform pos_Hand{ get; set; }
    }
    
}