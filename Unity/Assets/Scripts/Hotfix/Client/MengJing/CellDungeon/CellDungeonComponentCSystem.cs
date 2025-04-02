﻿using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{


    [EntitySystemOf(typeof(CellDungeonComponentC))]
    [FriendOf(typeof(CellDungeonComponentC))]
    public static partial class CellDungeonComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.CellDungeonComponentC self)
        {

        }
        
         public static void OnFubenSettlement(this CellDungeonComponentC self)
        {
            //self.Root().GetComponent<UserInfoComponentC>().OnFubenSettlement(self.ChapterId, (int)self.FubenDifficulty);
        }

        public static void InitFubenCell(this CellDungeonComponentC self, int mapid)
        {
            self.ChapterId = mapid;
            self.ChapterConfig = CellGenerateConfigCategory.Instance.Get(mapid);

            int[] size = self.ChapterConfig.InitSize;
            self.FubenCellInfoList = new CellDungeonInfo[size[0]][];
            for (int row = 0; row < size[0]; row++)
            {
                for (int line = 0; line < size[1]; line++)
                {
                    if (self.FubenCellInfoList[row] == null)
                    {
                        self.FubenCellInfoList[row] = new CellDungeonInfo[size[1]];
                    }
                    CellDungeonInfo fubenCellInfo = new CellDungeonInfo() { };
                    fubenCellInfo.row = row;
                    fubenCellInfo.line = line;
                    self.FubenCellInfoList[row][line] = fubenCellInfo;
                }
            }
        }

        public static int GetCellIndex(this CellDungeonComponentC self, int row, int line)
        {
            CellGenerateConfig chapterConfig = CellGenerateConfigCategory.Instance.Get(self.ChapterId);
            int rowTotal = chapterConfig.InitSize[0];
            return line * rowTotal + row;
        }

        public static CellDungeonInfo GetFubenCell(this CellDungeonComponentC self, int row, int line)
        {
            CellGenerateConfig chapterConfig = CellGenerateConfigCategory.Instance.Get(self.ChapterId);
            if (row >= 0 && row < chapterConfig.InitSize[0] && line >= 0 && line < chapterConfig.InitSize[1])
            {
                return self.FubenCellInfoList[row][line];
            }
            return null;
        }

        public static CellDungeonInfo GetFubenCell(this CellDungeonComponentC self, int cellIndex)
        {
            CellGenerateConfig chapterConfig = CellGenerateConfigCategory.Instance.Get(self.ChapterId);
            int row = cellIndex % chapterConfig.InitSize[0];
            int line = cellIndex / chapterConfig.InitSize[0];
            return self.FubenCellInfoList[row][line];
        }

        //已通过
        public static void SetWalkedFlag(this CellDungeonComponentC self, int cellIndex)
        {
            self.GetFubenCell(cellIndex).pass = true;
        }

        public static void SetStartedFlag(this CellDungeonComponentC self, int startCell)
        {
            self.GetFubenCell(startCell).ctype = (byte)CellDungeonStatu.Start;
        }

        public static void SetEndedFlag(this CellDungeonComponentC self, int endCell)
        {
            self.GetFubenCell(endCell).ctype = (byte)CellDungeonStatu.End;
        }

        public static bool IsEndCell(this CellDungeonComponentC self)
        {
            return self.SonFubenInfo.CurrentCell == self.FubenInfo.EndCell;
        }

        public static void UpdateCellType(this CellDungeonComponentC self, int CellIndex, List<int> PassableFlag)
        {
           
            //清空之前的PassableFlag
            CellGenerateConfig chapterConfig = CellGenerateConfigCategory.Instance.Get(self.ChapterId);
            int[] size = chapterConfig.InitSize;
            for (int k = 0; k < size[0]; k++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    if (self.FubenCellInfoList[k][j].ctype == (byte)CellDungeonStatu.Passable)
                    {
                        self.FubenCellInfoList[k][j].ctype = (byte)CellDungeonStatu.None;
                    }
                }
            }

            CellDungeonInfo fubenCellInfo = self.GetFubenCell(CellIndex);
            int row = fubenCellInfo.row;
            int line = fubenCellInfo.line;
            //设置相对于当前格子//上 左 下 右的四个格子
            //找到四周不可移动的格子
            CellDungeonInfo cellUp = self.GetFubenCell(row - 1, line);
            if (cellUp != null && cellUp.ctype == (byte)CellDungeonStatu.None)
            {
                cellUp.ctype = PassableFlag[0] == 1 ? (byte)CellDungeonStatu.Passable : (byte)CellDungeonStatu.Impassable;
            }
            CellDungeonInfo cellLeft = self.GetFubenCell(row, line - 1);
            if (cellLeft != null && cellLeft.ctype == (byte)CellDungeonStatu.None)
            {
                cellLeft.ctype = PassableFlag[1] == 1 ? (byte)CellDungeonStatu.Passable : (byte)CellDungeonStatu.Impassable;
            }
            CellDungeonInfo cellDown = self.GetFubenCell(row + 1, line);
            if (cellDown != null && cellDown.ctype == (byte)CellDungeonStatu.None)
            {
                cellDown.ctype = PassableFlag[2] == 1 ? (byte)CellDungeonStatu.Passable : (byte)CellDungeonStatu.Impassable;
            }
            CellDungeonInfo cellRight = self.GetFubenCell(row, line + 1);
            if (cellRight != null && cellRight.ctype == (byte)CellDungeonStatu.None)
            {
                cellRight.ctype = PassableFlag[3] == 1 ? (byte)CellDungeonStatu.Passable : (byte)CellDungeonStatu.Impassable;
            }
        }

        public static bool HaveFubenCellNpc(this CellDungeonComponentC self, int npcType)
        {
            for (int i = 0; i < self.FubenInfo.FubenCellNpcs.Count; i++)
            {
                if (self.FubenInfo.FubenCellNpcs[i].KeyId == npcType )
                {
                    return true;
                }
            }
            return false;
        }

        public static bool HaveFubenCellNpc(this CellDungeonComponentC self, int npcType, int cell)
        {
            for (int i = 0; i < self.FubenInfo.FubenCellNpcs.Count; i++)
            {
                if (self.FubenInfo.FubenCellNpcs[i].KeyId == npcType && self.FubenInfo.FubenCellNpcs[i].Value == cell.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool HaveFubenCellNpc(this CellDungeonComponentC self, int npcType, int cell, int sonId)
        {
            for (int i = 0; i < self.FubenInfo.FubenCellNpcs.Count; i++)
            {
                if (self.FubenInfo.FubenCellNpcs[i].KeyId == npcType
                    && self.FubenInfo.FubenCellNpcs[i].Value == cell.ToString()
                    && self.FubenInfo.FubenCellNpcs[i].Value2 == sonId.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public static void CheckChuansongOpen(this CellDungeonComponentC self)
        {
            Scene scene = self.Root().CurrentScene();
            if (!UnitHelper.IsAllMonsterDead(scene))
                return;
            
            EventSystem.Instance.Publish(self.Root(), new ChuanSongOpen());
        }

        public static int CheckEnterLevel(this CellDungeonComponentC self, int difficulty, int chapterid)
        {
            if (chapterid == 0)
            {
                return ErrorCode.ERR_NotFindLevel;
            }
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.PiLao <= 0)
            {
                return ErrorCode.ERR_TiLiNoEnough;
            }
            int sectionId =  TaskHelper.GetChapterSection(chapterid);
            int[] RandomArea = CellGenerateConfigCategory.Instance.Get(sectionId).RandomArea;
            List<int> intlist2 = new List<int>(RandomArea);
            int index = intlist2.IndexOf(chapterid);
            if (index > 0)
            {
                int lastLvel = intlist2[index - 1];
                if (!self.Root().GetComponent<UserInfoComponentC>().IsLevelPassed(lastLvel))
                {
                    return ErrorCode.ERR_LevelNotOpen;
                }
            }
            CellGenerateConfig chapterConfig = CellGenerateConfigCategory.Instance.Get(chapterid);
            FubenPassInfo fubenPassInfo = self.Root().GetComponent<UserInfoComponentC>().GetPassInfoByID(chapterid);
            if (difficulty == FubenDifficulty.Normal)
            {
                UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                if (userInfo.Lv < chapterConfig.EnterLv)
                {
                    return ErrorCode.ERR_LevelNoEnough;
                }
            }
            if (difficulty == FubenDifficulty.TiaoZhan && (fubenPassInfo == null || fubenPassInfo.Difficulty < 1))
            {
                return ErrorCode.ERR_LevelNormalNoPass;
            }
            if (difficulty == FubenDifficulty.DiYu && (fubenPassInfo == null || fubenPassInfo.Difficulty < 2))
            {
                return ErrorCode.ERR_LevelChallengeNoPass;
            }
            return ErrorCode.ERR_Success;
        }
        
    }

}