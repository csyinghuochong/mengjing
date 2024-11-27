using System.Collections.Generic;

namespace ET.Client
{
    // 客户端挂在ClientScene上，服务端挂在Unit上
    [ComponentOf(typeof(Scene))]
    public class PetComponentC : Entity, IAwake, IDestroy
    {
        public int PetFubeRewardId { get; set; }

        public int PetShouHuActive { get; set; }
        public List<long> TeamPetList { get; set; } = new(); //宠物天梯
        public List<long> PetFormations { get; set; } = new(); //宠物副本
        public List<long> PetShouHuList { get; set; } = new(); //守护列表（0-14宠物id  15/16/17矿场ID）
        public List<long> PetMingList { get; set; } = new(); //矿场队伍(15个宠物）
        public List<long> PetMingPosition { get; set; } = new(); //矿场宠物位置(27个位置)

        public int PetFightPlan { get; set; }
        public List<PetBarInfo> PetFightList_1 { get; set; } = new(); //宠物出战列表  （后期需要通过布阵界面来设置）
        public List<PetBarInfo> PetFightList_2 { get; set; } = new();
        public List<PetBarInfo> PetFightList_3 { get; set; } = new();
        public List<int> PetBarConfigList { get; set; } = new();

        public int PetMeleePlan { get; set; }
        public List<int> PetMeleeMainPetList { get; set; } = new(); // 宠物乱斗，主战宠物
        public List<int> PetMeleeAssistPetList { get; set; } = new(); // 宠物乱斗，辅战宠物
        public List<int> PetMeleeSkillList { get; set; } = new(); // 宠物乱斗，魔法卡牌
        
        public List<int> PetCangKuOpen { get; set; } = new();

        public List<RolePetInfo> RolePetInfos { get; set; } = new();
        public List<KeyValuePairLong> RolePetEggs { get; set; } = new(3);
        public List<PetFubenInfo> PetFubenInfos { get; set; } = new();
        public List<KeyValuePair> PetSkinList { get; set; } = new();

        public List<PetMingRecord> PetMingRecordList { get; set; } = new();

        //背包宠物
        public List<RolePetInfo> RolePetBag { get; set; } = new();
        
    }
}