using System.Collections.Generic;
namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class PetMatchDungeonComponent: Entity, IAwake, IDestroy
    {
        public long Timer;
        public long TimerNum;

        public bool GameOver;
        public bool SendReward { get; set; }
        
        public bool GameStart;
        public long StartTime;
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