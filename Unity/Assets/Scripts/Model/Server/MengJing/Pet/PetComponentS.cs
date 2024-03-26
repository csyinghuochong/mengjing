using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class PetComponentS : Entity, IAwake, ITransfer, IUnitCache
    {
        public int PetFubeRewardId { get; set; }

        public int PetShouHuActive { get; set; }
        public List<long> TeamPetList  { get; set; } = default;      //宠物天梯
        public List<long> PetFormations { get; set; }= default;    //宠物副本
        public List<long> PetShouHuList { get; set; }= default;    //守护列表（0-14宠物id  15/16/17矿场ID）
        public List<long> PetMingList { get; set; }= default;     //矿场队伍(15个宠物）
        public List<long> PetMingPosition { get; set; }= default;   //矿场宠物位置(27个位置)
        public List<int>  PetCangKuOpen { get; set; }= default; 

        public List<RolePetInfo> RolePetInfos  { get; set; }= default; 
        public List<KeyValuePairInt> RolePetEggs { get; set; }= default; 
        public List<PetFubenInfo> PetFubenInfos{ get; set; }= default; 
        public List<KeyValuePair> PetSkinList { get; set; }= default; 

        public List<PetMingRecord> PetMingRecordList { get; set; }= default; 

        //背包宠物
        public List<RolePetInfo> RolePetBag { get; set; }= default; 

        public int UpdateNumber { get; set; }  //1处理神兽技能
    }
    
}