using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof (Scene))]
    public class PetComponent_C:  Entity, IAwake, IDestroy
    {

        public int PetFubeRewardId { get; set; }

        public int PetShouHuActive { get; set; }
        public List<long> TeamPetList = new List<long>() { };       //宠物天梯
        public List<long> PetFormations = new List<long>() { };     //宠物副本
        public List<long> PetShouHuList = new List<long>() { };     //守护列表（0-14宠物id  15/16/17矿场ID）
        public List<long> PetMingList = new List<long>() { };       //矿场队伍(15个宠物）
        public List<long> PetMingPosition = new List<long>();   //矿场宠物位置(27个位置)
        public List<int>  PetCangKuOpen = new List<int>() { };   

        public List<RolePetInfo> RolePetInfos = new List<RolePetInfo>();
        public List<KeyValuePairInt> RolePetEggs = new List<KeyValuePairInt>(3);
        public List<PetFubenInfo> PetFubenInfos = new List<PetFubenInfo>();
        public List<KeyValuePair> PetSkinList = new List<KeyValuePair>() { };

        public List<PetMingRecord> PetMingRecordList = new List<PetMingRecord>();

        //背包宠物
        public List<RolePetInfo> RolePetBag = new List<RolePetInfo>();

        public int UpdateNumber { get; set; }   //1处理神兽技能
        
    }
}
