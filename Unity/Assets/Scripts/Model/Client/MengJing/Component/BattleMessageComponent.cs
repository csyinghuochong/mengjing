using System.Collections.Generic;
using ET.Client;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class BattleMessageComponent : Entity, IAwake
    {
        //public M2C_BattleInfoResult M2C_BattleInfoResult;
        public M2C_AreneInfoResult M2C_AreneInfoResult { get; set; } = null;

        //public M2C_RankRunRaceMessage M2C_RankRunRaceMessage;
        public M2C_HappyInfoResult M2C_HappyInfoResult { get; set; } = null;
        public M2C_RunRaceBattleInfo M2C_RunRaceBattleInfo { get; set; } = null;

        //竞技场开始匹配时间戳
        public long SoloPiPeiStartTime { get; set; }

        //竞技场胜负记录
        public int SoloNum_Win;
        public int SoloNum_Fail;

        //召唤机器人时间戳
        public long CallTeamRobotTime { get; set; }

        /// <summary>
        /// 骑乘状态
        /// </summary>
        public long RideForbidTime;

        public long RideTargetUnit;

        public long UploadMemoryTime { get; set; }

        public int LastDungeonId { get; set; }
        
        public bool TransferMap { get; set; }

        public Dictionary<long, long> PetFightCD { get; set; } = new();

        // 组队喊话频率
        public long ShoutInterval;

        public int FirstWinBossId { get; set; }

        public bool ShowPetChouKaGet { get; set; } = false;
        public List<RolePetAdd> RolePetAdds { get; set; } = new List<RolePetAdd>();
        public Dictionary<long, long> OneChallengeTime { get; set; } = new();

        public List<long> AttackSelfPlayer { get; set; } = new List<long>();

        public long LastPopularize_ListTime { get; set; } = 0;
    }
}