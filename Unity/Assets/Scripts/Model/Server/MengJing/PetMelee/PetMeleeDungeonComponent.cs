using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class PetMeleeDungeonComponent : Entity, IAwake, IDestroy
    {
        public bool GameStart;
        public bool GameOver;
        public long PetMeleeDungeonBattleTimer; //战斗倒计时
        public long PetMeleeDungeonDealCardTimer; //发牌记时
        public long PetMeleeDungeonRestoreTimer; //恢复记时

        private EntityRef<Unit> player;
        public Unit Player { get => this.player; set => this.player = value; }

        public List<PetMeleeCardInfo> PetMeleeCardInHand { get; set; } = new(); //手里的卡
        public List<PetMeleeCardInfo> PetMeleeCardPool = new(); //储存池里的卡
        public List<long> UsedMainPetList = new();
        public List<int> UsedSkillList = new();
    }
}