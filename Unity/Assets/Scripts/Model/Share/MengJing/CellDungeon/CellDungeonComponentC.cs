using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class CellDungeonComponentC : Entity, IAwake
    {
        public int ChapterId { get; set; }
        public long EnterTime { get; set; }
        public long HurtValue { get; set; }
        public CellGenerateConfig ChapterConfig { get; set; }
        public int FubenDifficulty { get; set; }

        public FubenInfo FubenInfo { get; set; } = FubenInfo.Create();
        public SonFubenInfo SonFubenInfo { get; set; } = SonFubenInfo.Create();

        public CellDungeonInfo[][] FubenCellInfoList { get; set; }

    }
}