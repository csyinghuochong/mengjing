using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class PetComponent_S : Entity, IAwake, ITransfer, IUnitCache
    {
        public int PetFubeRewardId { get; set; }

        public int PetShouHuActive { get; set; }
        public List<long> TeamPetList { get; set; }       //宠物天梯
        public List<long> PetFormations { get; set; }     //宠物副本
        public List<long> PetShouHuList { get; set; }    //守护列表（0-14宠物id  15/16/17矿场ID）
        public List<long> PetMingList { get; set; }     //矿场队伍(15个宠物）
        public List<long> PetMingPosition { get; set; }  //矿场宠物位置(27个位置)
        public List<int>  PetCangKuOpen { get; set; }

        public List<RolePetInfo> RolePetInfos  { get; set; }
        public List<KeyValuePairInt> RolePetEggs { get; set; }
        public List<PetFubenInfo> PetFubenInfos{ get; set; }
        public List<KeyValuePair> PetSkinList { get; set; }

        public List<PetMingRecord> PetMingRecordList { get; set; }

        //背包宠物
        public List<RolePetInfo> RolePetBag { get; set; }

        public int UpdateNumber { get; set; }  //1处理神兽技能
    }
    
}