using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET
{
    
    [ComponentOf(typeof(Unit))]
    public class UnitInfoComponent : Entity, IAwake
    {

        public int EnergySkillId { get; set; }

        public List<long> ZhaohuanIds = new List<long>();

        public string UnitName { get; set; }    //自身名字

        public string MasterName { get; set; }  //主人名字

        public string UnionName { get; set; } = String.Empty;  //帮会名字

        public string DemonName { get; set; }

        public List<KeyValuePair> Buffs = new List<KeyValuePair>();

        //掉落
        public List<DropInfo> Drops = new List<DropInfo>();

        public List<int> FashionEquipList { get; set; } = new List<int>();


        public int LastDungeonId  { get; set; } = 0;
        public float3 LastDungeonPosition { get; set; } 
        
        public int DirectionType  { get; set; } = 0;
    }
}