using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof (Scene))]
    public class PetComponentC: Entity, IAwake, IDestroy
    {
        public int PetFubeRewardId { get; set; }

        public int PetShouHuActive { get; set; }
        public List<long> TeamPetList { get; set; } = new(); //宠物天梯
        public List<long> PetFormations { get; set; } = new(); //宠物副本
        public List<long> PetShouHuList { get; set; } = new(); //守护列表（0-14宠物id  15/16/17矿场ID）
        public List<long> PetMingList { get; set; } = new(); //矿场队伍(15个宠物）
        public List<long> PetMingPosition { get; set; } = new(); //矿场宠物位置(27个位置)
        
        public List<long> PetFightList{ get; set; } = new(); //宠物出战列表，后期需要通过布阵界面设置
        
        public List<int> PetCangKuOpen { get; set; } = new();

        public List<RolePetInfo> RolePetInfos { get; set; } = new();
        public List<KeyValuePairLong> RolePetEggs { get; set; } = new(3);
        public List<PetFubenInfo> PetFubenInfos { get; set; } = new();
        public List<KeyValuePair> PetSkinList { get; set; } = new();

        public List<PetMingRecord> PetMingRecordList { get; set; } = new();

        //背包宠物
        public List<RolePetInfo> RolePetBag { get; set; } = new();

        public int UpdateNumber { get; set; } //1处理神兽技能
    }
}