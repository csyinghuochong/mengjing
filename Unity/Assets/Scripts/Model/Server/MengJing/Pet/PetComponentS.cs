using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class PetComponentS : Entity, IAwake, ITransfer, IUnitCache
    {
        public int PetFubeRewardId { get; set; }

        public int PetShouHuActive { get; set; }
        public List<long> TeamPetList  { get; set; } = new List<long>();      //宠物天梯
        public List<long> PetFormations { get; set; }= new List<long>();    //宠物副本
        public List<long> PetShouHuList { get; set; }= new List<long>();    //守护列表（0-14宠物id  15/16/17矿场ID）
        public List<long> PetMingList { get; set; }= new List<long>();     //矿场队伍(15个宠物）
        public List<long> PetMingPosition { get; set; }= new List<long>();   //矿场宠物位置(27个位置)
        
        public List<int>  PetCangKuOpen { get; set; }= new List<int>();

        public int PetFightPlan { get; set; }
        public List<PetBarInfo> PetFightList_1 { get; set; } = new();   //宠物出战列表  （后期需要通过布阵界面来设置）
        public List<PetBarInfo> PetFightList_2 { get; set; } = new();
        public List<PetBarInfo> PetFightList_3 { get; set; } = new();
        public List<int> PetBarConfigList { get; set; } = new();

        public int PetMeleePlan { get; set; }
        public List<PetMeleeInfo> PetMeleeInfoList { get; set; } = new();
        
        public List<RolePetInfo> RolePetInfos  { get; set; }= new List<RolePetInfo>(); 
        public List<KeyValuePairLong> RolePetEggs { get; set; }= new List<KeyValuePairLong>(); 
        public List<PetFubenInfo> PetFubenInfos{ get; set; }= new List<PetFubenInfo>(); 
        public List<KeyValuePair> PetSkinList { get; set; }= new List<KeyValuePair>(); 

        public List<PetMingRecord> PetMingRecordList { get; set; }= new List<PetMingRecord>(); 

        //背包宠物
        public List<RolePetInfo> RolePetBag { get; set; }= new List<RolePetInfo>(); 

        public int UpdateNumber { get; set; }  //1处理神兽技能
    }
    
}