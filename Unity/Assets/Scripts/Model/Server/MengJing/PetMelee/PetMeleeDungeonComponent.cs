using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class PetMeleeDungeonComponent : Entity, IAwake, IDestroy
    {
        public bool GameStart;
        public long StartTime;
        public bool GameOver { get; set; }
        public long PetMeleeDungeonBattleTimer; //战斗倒计时
        public long PetMeleeDungeonDealCardTimer; //发牌记时
        public long PetMeleeDungeonRestoreTimer; //恢复记时


        public List<long> BegingPlayers = new();
       // private EntityRef<Unit> player;
       // public Unit Player { get => this.player; set => this.player = value; }

        public Dictionary<long, List<PetMeleeCardInfo>> PetMeleeCardInHand { get; set; } = new(); //手里的卡
        public Dictionary<long, List<PetMeleeCardInfo>> PetMeleeCardPool = new(); //储存池里的卡
        public Dictionary<long,  List<long>> UsedMainPetList = new();
        public Dictionary<long, List<int>> UsedSkillList = new();
    }
}