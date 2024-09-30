using System.Collections.Generic;

namespace ET.Server
{
    
    public static class CellDungeonNpc
    {
        public const int HuiFuItem = 1;
        public const int ShenMiNpc = 2;
        public const int ChestList = 3;
        public const int MoLengRoom = 4;
    }

    public enum CellDungeonStatu : byte
    {
        None = 0,
        Start,          //起点                
        End,            //终点
        Passable,       //可以通行
        Impassable      //不可通行
    }

    public enum DirectionType : byte
    {
        None,
        Up,
        Left,
        Down,
        Right
    }

    [EnableClass]
    public class CellDungeonInfo
    {
        public int row;         //行
        public int line;        //列
        public int sonid;       //随机地块
        public byte ctype;      //格子属性
        public bool pass;       //是否通关
    }

    /// <summary>
    /// 副本组件
    /// </summary>
    [ComponentOf(typeof(Scene))]
    public class CellDungeonComponentS : Entity, IAwake
    {
        public int ChapterId { get; set; }
        public long EnterTime { get; set; }
        public long HurtValue { get; set; }
        public CellGenerateConfig ChapterConfig { get; set; }
        public int FubenDifficulty { get; set; }

        public FubenInfo FubenInfo { get; set; } = FubenInfo.Create();
        public SonFubenInfo SonFubenInfo { get; set; } = SonFubenInfo.Create();

        public CellDungeonInfo[][] FubenCellInfoList { get; set; }

        //神秘商品
        public List<int> EnergySkills { get; set; } = new List<int>() { };
        public List<MysteryItemInfo> MysteryItemInfos  { get; set; }= new List<MysteryItemInfo>();
        public CellDungeonInfo CurrentFubenCell { get; set; }
    }   //队长
}
