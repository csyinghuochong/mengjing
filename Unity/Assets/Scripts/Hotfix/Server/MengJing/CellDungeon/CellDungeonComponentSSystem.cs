using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(CellDungeonComponentS))]
    [FriendOf(typeof(CellDungeonComponentS))]
    public static partial class CellDungeonComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this CellDungeonComponentS self)
        {
        }

        public static void InitFubenCell(this CellDungeonComponentS self, int chapterid)
        {
            self.FubenInfo = FubenInfo.Create();
            self.SonFubenInfo = SonFubenInfo.Create();
            self.ChapterConfig = CellGenerateConfigCategory.Instance.Get(chapterid);
            self.ChapterId = chapterid;

            ////随机生成地图格子
            CellGenerateConfig chapterConfig = self.ChapterConfig;
            int rowTotal = chapterConfig.InitSize[0];
            int lineTotal = chapterConfig.InitSize[1];

            //第一列随机起点
            self.FubenInfo.StartCell = self.GetCellIndex(RandomHelper.RandomNumber(0, rowTotal), 0);
            //最后列列随机终点
            self.FubenInfo.EndCell = self.GetCellIndex(RandomHelper.RandomNumber(0, rowTotal), lineTotal - 1);

            int sceneRoomNumber = rowTotal * lineTotal < 10 ? 1 : 2;
            int[] randomArea = chapterConfig.RandomArea;

            List<int> huiFuItems = new List<int>(RandomHelper.GetRandoms(sceneRoomNumber, 0, rowTotal * lineTotal));
            List<int> canWalk = new List<int>();
            int shenMiNpcCell = -1;

            self.FubenCellInfoList = new CellDungeonInfo[rowTotal][];
            for (int row = 0; row < rowTotal; row++)
            {
                for (int line = 0; line < lineTotal; line++)
                {
                    if (self.FubenCellInfoList[row] == null)
                    {
                        self.FubenCellInfoList[row] = new CellDungeonInfo[lineTotal];
                    }

                    CellDungeonInfo fubenCellInfo = new CellDungeonInfo() { };
                    self.FubenCellInfoList[row][line] = fubenCellInfo;
                    fubenCellInfo.row = row;
                    fubenCellInfo.line = line;
                    fubenCellInfo.sonid = randomArea[RandomHelper.RandomNumber(0, randomArea.Length)];
                    fubenCellInfo.pass = false;
                    fubenCellInfo.ctype = RandomHelper.RandFloat01() > 0.2f ? (byte)CellDungeonStatu.Impassable : (byte)CellDungeonStatu.Passable;

                    int cellIndex = self.GetCellIndex(row, line);
                    if (cellIndex == self.FubenInfo.StartCell)
                    {
                        fubenCellInfo.ctype = (byte)CellDungeonStatu.Start;
                        fubenCellInfo.sonid = chapterConfig.StartArea;
                        self.CurrentFubenCell = fubenCellInfo;
                        continue;
                    }

                    if (cellIndex == self.FubenInfo.EndCell)
                    {
                        fubenCellInfo.ctype = (byte)CellDungeonStatu.End;
                        fubenCellInfo.sonid = chapterConfig.EndArea;
                        continue;
                    }

                    if (fubenCellInfo.ctype == (byte)CellDungeonStatu.Passable)
                    {
                        canWalk.Add(cellIndex);
                    }

                    CellDungeonConfig chapterSonConfig = CellDungeonConfigCategory.Instance.Get(fubenCellInfo.sonid);
                    if (chapterSonConfig.NpcList.Contains(1000015))
                    {
                        shenMiNpcCell = cellIndex;
                        self.FubenInfo.FubenCellNpcs.Add(new KeyValuePair() { KeyId = CellDungeonNpc.ShenMiNpc, Value = cellIndex.ToString() });
                    }
                }
            }

            //从起点到终点随机一条可以通行路线
            int newIndex = self.FubenInfo.StartCell;
            int EndIndex = self.FubenInfo.EndCell;
            while (true)
            {
                int row = newIndex % self.ChapterConfig.InitSize[0];
                int line = newIndex / self.ChapterConfig.InitSize[0];

                //随机上[1] 右[2] 下[4]三个方向往前推进
                int randomArrow = RandomHelper.RandomNumber(1, 4);
                switch (randomArrow)
                {
                    case 1:
                        row--;
                        break;
                    case 2:
                        line++;
                        break;
                    case 3:
                        row++;
                        break;
                }

                row = math.clamp(row, 0, rowTotal - 1);
                line = math.clamp(line, 0, lineTotal - 1);
                CellDungeonInfo fubenCellInfo = self.FubenCellInfoList[row][line];
                if (fubenCellInfo.ctype == (byte)CellDungeonStatu.Start)
                {
                    continue;
                }

                fubenCellInfo.ctype = (byte)CellDungeonStatu.Passable;
                newIndex = self.GetCellIndex(row, line);
                if (!canWalk.Contains(newIndex))
                {
                    canWalk.Add(newIndex);
                }

                if (math.abs(newIndex - EndIndex) == 1 && (line == (int)(EndIndex / rowTotal))
                    || math.abs(newIndex - EndIndex) == rowTotal)
                {
                    break;
                }
            }

            //确保起点到神秘Npc一定可以通行
            if (shenMiNpcCell != -1 && !canWalk.Contains(shenMiNpcCell))
            {
                int row = shenMiNpcCell % self.ChapterConfig.InitSize[0];
                int line = shenMiNpcCell / self.ChapterConfig.InitSize[0];

                for (int i = 0; i < line; i++)
                {
                    CellDungeonInfo fubenCellInfo = self.FubenCellInfoList[row][i];
                    if (fubenCellInfo.ctype == (byte)CellDungeonStatu.Impassable)
                    {
                        fubenCellInfo.ctype = (byte)CellDungeonStatu.Passable;
                        if (!canWalk.Contains(newIndex))
                        {
                            canWalk.Add(newIndex);
                        }
                    }
                }

                int row_start = self.FubenInfo.StartCell % self.ChapterConfig.InitSize[0];

                int row_1, row_2 = 0;
                row_1 = row_start <= row ? row_start : row;
                row_2 = row_start > row ? row_start : row;
                for (int i = row_1; i < row_2; i++)
                {
                    CellDungeonInfo fubenCellInfo = self.FubenCellInfoList[i][line];
                    if (fubenCellInfo.ctype == (byte)CellDungeonStatu.Impassable)
                    {
                        fubenCellInfo.ctype = (byte)CellDungeonStatu.Passable;
                        if (!canWalk.Contains(newIndex))
                        {
                            canWalk.Add(newIndex);
                        }
                    }
                }
            }

            //从所有可以行走的格子随机出各种Npc
            List<int> specialCells = new List<int>();
            for (int i = 0; i < self.ChapterConfig.SpecialRoom.Length; i++)
            {
                int index = RandomHelper.RandomNumber(0, canWalk.Count);
                int cellIndex = canWalk[index];
                float rate = RandomHelper.RandFloat01();

                if (self.ChapterConfig.SpecialRoomPro[i] > rate && !specialCells.Contains(cellIndex))
                {
                    CellDungeonInfo fubenCellInfo = self.GetByCellIndex(cellIndex);
                    fubenCellInfo.sonid = self.ChapterConfig.SpecialRoom[i];
                    self.FubenInfo.FubenCellNpcs.Add(new KeyValuePair()
                    {
                        KeyId = CellDungeonNpc.MoLengRoom, Value = cellIndex.ToString(), Value2 = fubenCellInfo.sonid.ToString()
                    });
                    specialCells.Add(cellIndex);
                }
            }

            bool haveHuifu = false;
            for (int i = 0; i < canWalk.Count; i++)
            {
                int cellIndex = canWalk[i];
                if (!specialCells.Contains(cellIndex) && huiFuItems.Contains(cellIndex))
                {
                    haveHuifu = true;
                    specialCells.Add(cellIndex);
                    self.FubenInfo.FubenCellNpcs.Add(new KeyValuePair() { KeyId = CellDungeonNpc.HuiFuItem, Value = cellIndex.ToString() });
                }
            }

            if (!haveHuifu)
            {
                for (int i = 0; i < canWalk.Count; i++)
                {
                    int cellIndex = canWalk[i];
                    CellDungeonInfo fubenCellInfo = self.GetByCellIndex(cellIndex);
                    CellDungeonConfig chapterSonConfig = CellDungeonConfigCategory.Instance.Get(fubenCellInfo.sonid);
                    string[] createScenceMonsterPro = chapterSonConfig.CreateScenceMonsterPro.Split(';');
                    if (createScenceMonsterPro != null && createScenceMonsterPro.Length > 1)
                    {
                        float rate = float.Parse(createScenceMonsterPro[0]);
                        if (!specialCells.Contains(cellIndex) && rate >= RandomHelper.RandFloat01())
                        {
                            specialCells.Add(cellIndex);
                            self.FubenInfo.FubenCellNpcs.Add(new KeyValuePair() { KeyId = CellDungeonNpc.ChestList, Value = cellIndex.ToString() });
                        }
                    }
                }
            }
        }

        public static CellDungeonInfo GetNextSonCell(this CellDungeonComponentS self, int cellIndex, int directionType)
        {
            int row = cellIndex % self.ChapterConfig.InitSize[0];
            int line = cellIndex / self.ChapterConfig.InitSize[0];

            switch (directionType)
            {
                case 1:
                    row--;
                    break;
                case 2:
                    line--;
                    break;
                case 3:
                    row++;
                    break;
                case 4:
                    line++;
                    break;
            }

            if (row >= 0 && row < self.ChapterConfig.InitSize[0] && line >= 0 && line < self.ChapterConfig.InitSize[1])
            {
                return self.FubenCellInfoList[row][line];
            }

            return null;
        }

        public static int GetCurentIndex(this CellDungeonComponentS self)
        {
            return self.GetCellIndex(self.CurrentFubenCell.row, self.CurrentFubenCell.line);
        }

        public static int GetCellIndex(this CellDungeonComponentS self, int row, int line)
        {
            int rowTotal = self.ChapterConfig.InitSize[0];
            return line * rowTotal + row;
        }

        public static CellDungeonInfo GetByCellIndex(this CellDungeonComponentS self, int cellIndex)
        {
            int row = cellIndex % self.ChapterConfig.InitSize[0];
            int line = cellIndex / self.ChapterConfig.InitSize[0];
            return self.GetFubenCell(row, line);
        }

        public static CellDungeonInfo GetFubenCell(this CellDungeonComponentS self, int row, int line)
        {
            if (row >= 0 && row < self.ChapterConfig.InitSize[0] && line >= 0 && line < self.ChapterConfig.InitSize[1])
            {
                return self.FubenCellInfoList[row][line];
            }

            return null;
        }

        public static bool GetCellPassable(this CellDungeonComponentS self, int row, int line)
        {
            CellDungeonInfo fubenCell = self.GetFubenCell(row, line);
            return fubenCell != null ? (fubenCell.ctype != (byte)CellDungeonStatu.Impassable) : false;
        }

        public static List<int> GetPassableFlag(this CellDungeonComponentS self, CellDungeonInfo fubenCell = null)
        {
            List<int> flags = new List<int>() { 0, 0, 0, 0 };
            fubenCell = fubenCell != null ? fubenCell : self.CurrentFubenCell;
            if (fubenCell.ctype == (byte)CellDungeonStatu.End)
            {
                return flags;
            }

            int curRow = fubenCell.row;
            int curLine = fubenCell.line;
            //上 左 下 右
            flags[0] = (self.GetCellPassable(curRow - 1, curLine) ? 1 : 0);
            flags[1] = (self.GetCellPassable(curRow, curLine - 1) ? 1 : 0);
            flags[2] = (self.GetCellPassable(curRow + 1, curLine) ? 1 : 0);
            flags[3] = (self.GetCellPassable(curRow, curLine + 1) ? 1 : 0);

            return flags;
        }

        public static void OnRecivedHurt(this CellDungeonComponentS self, long hurtvalue)
        {
            self.HurtValue += hurtvalue;
        }

        public static bool HaveFubenCellNpc(this CellDungeonComponentS self, int npcType, int cell)
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

        public static void InitFirstCell(this CellDungeonComponentS self)
        {
            CellDungeonInfo curCell = self.CurrentFubenCell;
            self.HurtValue = 0;
            self.EnterTime = TimeHelper.ServerNow();
            self.SonFubenInfo.SonSceneId = curCell.sonid;
            self.SonFubenInfo.CurrentCell = self.FubenInfo.StartCell;
            self.SonFubenInfo.PassableFlag = self.GetPassableFlag();
            self.EnergySkills.AddRange(ConfigData.EnergySkills);
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            mapComponent.SetMapInfo((int)MapTypeEnum.CellDungeon, self.ChapterId, curCell.sonid);

            CellDungeonConfig chapterSon = CellDungeonConfigCategory.Instance.Get(curCell.sonid);
            mapComponent.NavMeshId = chapterSon.MapID;
        }

        public static void OnEnterFirstCell(this CellDungeonComponentS self, Unit unit, M2M_UnitTransferRequest request)
        {
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            unit.AddComponent<PathfindingComponent, int>(mapComponent.NavMeshId);
            //Game.Scene.GetComponent<RecastPathComponent>().Update(scene.GetComponent<MapComponent>().NavMeshId);
            //更新unit坐标
            CellDungeonConfig chapterSon = CellDungeonConfigCategory.Instance.Get(self.CurrentFubenCell.sonid);
            unit.Position = new float3(chapterSon.BornPosLeft[0] * 0.01f, chapterSon.BornPosLeft[1] * 0.01f, chapterSon.BornPosLeft[2] * 0.01f);
            unit.Rotation = quaternion.identity;
            self.GenerateFubenScene(false);

            // 通知客户端开始切场景
            string parminfo = self.CurrentFubenCell.sonid.ToString();
            M2C_StartSceneChange m2CStartSceneChange = new()
            {
                SceneInstanceId = self.Scene().InstanceId, SceneId = request.SceneId, SceneType = request.SceneType, Difficulty = request.Difficulty,
                ParamInfo = parminfo
            };
            MapMessageHelper.SendToClient(unit, m2CStartSceneChange);

            M2C_CellDungeonInfo m2CCellDungeonInfo = M2C_CellDungeonInfo.Create();
            m2CCellDungeonInfo.SceneId = request.SceneId;
            m2CCellDungeonInfo.FubenInfo = self.FubenInfo;
            m2CCellDungeonInfo.SonFubenInfo = self.SonFubenInfo;
            MapMessageHelper.SendToClient(unit, m2CCellDungeonInfo);
        }

        public static void InitSonCell(this CellDungeonComponentS self,  string ParamInfo)
        {
            string[] cellinfo = ParamInfo.Split('_');
            int CurrentCell = int.Parse(cellinfo[0]);
            int DirectionType = int.Parse(cellinfo[1]);

            CellDungeonInfo fubenCellInfoCurt = self.GetByCellIndex(CurrentCell);
            fubenCellInfoCurt.pass = true;
            CellDungeonInfo fubenCellInfoNext = self.GetNextSonCell(CurrentCell, DirectionType);
            self.CurrentFubenCell = fubenCellInfoNext;
           
            SonFubenInfo enterFubenInfo = SonFubenInfo.Create();
            enterFubenInfo.SonSceneId = fubenCellInfoNext.sonid;
            enterFubenInfo.PassableFlag = self.GetPassableFlag();
            enterFubenInfo.CurrentCell = self.GetCellIndex(fubenCellInfoNext.row, fubenCellInfoNext.line);
            self.SonFubenInfo = enterFubenInfo;
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            int sonid = fubenCellInfoNext.sonid;
            mapComponent.SetMapInfo(MapTypeEnum.CellDungeon, mapComponent.SceneId, sonid);
            CellDungeonConfig chapterSon = CellDungeonConfigCategory.Instance.Get(sonid);
            mapComponent.NavMeshId = chapterSon.MapID;
          
            //创建副本内的各种Unit
            self.GenerateFubenScene(fubenCellInfoNext.pass);
        }

        public static void OnEnterSonCell(this CellDungeonComponentS self,  string ParamInfo)
        {
            string[] cellinfo = ParamInfo.Split('_');
            int DirectionType = int.Parse(cellinfo[1]);
            
            
            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            CellDungeonInfo fubenCellInfoNext = self.CurrentFubenCell;
            int sonid = fubenCellInfoNext.sonid;
            CellDungeonConfig chapterSon = CellDungeonConfigCategory.Instance.Get(mapComponent.SonSceneId);
            
           
            //更新unit出生点坐标
            int[] borpos;
            switch (DirectionType)
            {
                case 1:
                    borpos = chapterSon.BornPosDwon;
                    break;
                case 2:
                    borpos = chapterSon.BornPosRight;
                    break;
                case 3:
                    borpos = chapterSon.BornPosUp;
                    break;
                default:
                    borpos = chapterSon.BornPosLeft;
                    break;
            }
            
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            M2C_CellSonDungeonInfo m2CCellDungeonInfo = M2C_CellSonDungeonInfo.Create();
            
            for (int i = 0; i < players.Count; i++)
            {
                Unit unit = players[i];
                
                unit.GetComponent<MoveComponent>().Stop(true);
                unit.GetComponent<SkillManagerComponentS>().OnFinish(true);
                unit.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.Transfer);
                
                if (!fubenCellInfoNext.pass)
                {
                    unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.PiLao, "-1");
                }

                unit.RemoveComponent<PathfindingComponent>();
                unit.AddComponent<PathfindingComponent, int>(mapComponent.NavMeshId);

                unit.Position = new float3(borpos[0] * 0.01f, borpos[1] * 0.01f, borpos[2] * 0.01f);
                unit.Rotation = quaternion.identity;
                unit.SetBornPosition(unit.Position, false);

                m2CCellDungeonInfo.UnitIds.Add(unit.Id);
                m2CCellDungeonInfo.Positions.Add(unit.Position);
            }

            
            List<Unit> pets = UnitHelper.GetUnitList(self.Scene(), UnitType.Pet);
            for (int i = 0; i < pets.Count; i++)
            {
                Unit pet = pets[i];

                pet.GetComponent<MoveComponent>().Stop(true);
                pet.GetComponent<SkillManagerComponentS>().OnFinish(true);
               
                pet.RemoveComponent<PathfindingComponent>();
                pet.AddComponent<PathfindingComponent, int>(mapComponent.NavMeshId);
                
                pet.Position = new float3(borpos[0] * 0.01f, borpos[1] * 0.01f, borpos[2] * 0.01f);
                pet.Rotation = quaternion.identity;
                m2CCellDungeonInfo.UnitIds.Add(pet.Id);
                m2CCellDungeonInfo.Positions.Add(pet.Position);
            }
            
            m2CCellDungeonInfo.SonFubenInfo = self.SonFubenInfo;
            MapMessageHelper.SendToClient(players[0], m2CCellDungeonInfo);
            
            self.MainHeroRemoveTransfer(players[0]).Coroutine();
        }

        public static async ETTask MainHeroRemoveTransfer(this CellDungeonComponentS self, Unit unit)
        {
            await self.Root().GetComponent<TimerComponent>().WaitAsync(200);
            unit.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.Transfer);
        }

        public static void GenerateFubenScene(this CellDungeonComponentS self, bool pass)
        {
            CellDungeonInfo fubenCellInfo = self.CurrentFubenCell;
            CellDungeonConfig chapterSonConfig = CellDungeonConfigCategory.Instance.Get(fubenCellInfo.sonid);

            //回血道具
            bool huifu = self.HaveFubenCellNpc(CellDungeonNpc.HuiFuItem, self.GetCurentIndex());
            if (huifu && !pass)
            {
                string createScenceMonster = chapterSonConfig.CreateScenceMonster;
                string[] sceneMonsters = createScenceMonster.Split('@');
                for (int i = 0; i < sceneMonsters.Length; i++)
                {
                    string[] seneItems = sceneMonsters[i].Split(';');
                    if (seneItems.Length < 2)
                    {
                        continue;
                    }

                    string[] position = seneItems[0].Split(",");
                    float3 vector3 = new float3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
                    UnitFactory.CreateMonster(self.Scene(), int.Parse(seneItems[1]), vector3,
                        new CreateMonsterInfo() { Camp = CampEnum.CampMonster1 });
                }
            }

            //生成宝箱
            bool chest = self.HaveFubenCellNpc(CellDungeonNpc.ChestList, self.GetCurentIndex());
            if (chest && !pass)
            {
                string[] createScenceMonsterPro = chapterSonConfig.CreateScenceMonsterPro.Split("@");
                for (int i = 0; i < createScenceMonsterPro.Length; i++)
                {
                    string[] monsterInfo = createScenceMonsterPro[i].Split(";");
                    if (monsterInfo.Length < 3)
                    {
                        continue;
                    }

                    string[] position = monsterInfo[1].Split(",");
                    float3 vector3 = new float3(float.Parse(position[0]), float.Parse(position[1]), float.Parse(position[2]));
                    UnitFactory.CreateMonster(self.Scene(), int.Parse(monsterInfo[2]), vector3,
                        new CreateMonsterInfo() { Camp = CampEnum.CampMonster1 });
                }
            }

            //开始刷怪
            if (!pass)
            {
                FubenHelp.CreateMonsterList(self.Scene(), chapterSonConfig.CreateMonster);
            }

            //生成npc
            int[] npcList = chapterSonConfig.NpcList;
            for (int i = 0; i < npcList.Length; i++)
            {
                if (npcList[i] == 0)
                {
                    continue;
                }

                if (npcList[i] == 1000016)
                {
                    self.InitMysteryItemInfos();
                }

                UnitFactory.CreateNpc(self.Scene(), npcList[i]);
            }

            //生成传送点
            List<int> passableFlags = self.GetPassableFlag();
            string[] chuansongs = chapterSonConfig.TransmitPosi.Split(';');

            for (int i = 0; i < chuansongs.Length; i++)
            {
                if (chuansongs[i] == "0")
                {
                    continue;
                }

                if (passableFlags[i] != 1)
                {
                    //不能传送
                }
                else
                {
                    //读取传送坐标点配置
                    string[] position = chuansongs[i].Split(',');
                    float3 vector3 = new float3(float.Parse(position[0]) * 0.01f, float.Parse(position[1]) * 0.01f,
                        float.Parse(position[2]) * 0.01f);
                    //创建传送点Unit
                    Unit chuansong = self.Scene().GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
                    chuansong.Type = UnitType.CellTransfers;
                    chuansong.GetParent<UnitComponent>().Add(chuansong);
                    chuansong.AddComponent<CellChuansongComponent>();
                    NumericComponentS numericComponentS = chuansong.AddComponent<NumericComponentS>();
                    numericComponentS.ApplyValue(NumericType.CellIndex, self.GetCellIndex(fubenCellInfo.row, fubenCellInfo.line), false); //走过的格子
                    numericComponentS.ApplyValue(NumericType.DirectionType, i + 1, false);
                    chuansong.AddComponent<UnitInfoComponent>();
                    chuansong.Position = vector3;
                    chuansong.AddComponent<AOIEntity, int, float3>(9 * 1000, chuansong.Position);
                }
            }
        }

        public static void OnKillEvent(this CellDungeonComponentS self)
        {
            if (self.IsAllMonsterDead() && self.CurrentFubenCell.ctype == (int)CellDungeonStatu.End)
            {
                int starNumber = 0;
                long needTime = TimeHelper.ServerNow() - self.EnterTime;
                List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);

                long maxHp = players[0].GetComponent<NumericComponentS>().GetAsLong(NumericType.Now_MaxHp);
                CellGenerateConfig chapterConfig = CellGenerateConfigCategory.Instance.Get(self.ChapterId);

                M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();

                m2C_FubenSettlement.BattleResult = 1;
                m2C_FubenSettlement.BattleGrade = 1;
                m2C_FubenSettlement.RewardExp = chapterConfig.RewardExp;
                m2C_FubenSettlement.RewardGold = chapterConfig.RewardGold;

                DropHelper.DropIDToDropItem_2(chapterConfig.BoxDropID, m2C_FubenSettlement.RewardList);
                DropHelper.DropIDToDropItem_2(chapterConfig.BoxDropID, m2C_FubenSettlement.RewardList);
                DropHelper.DropIDToDropItem_2(chapterConfig.BoxDropID, m2C_FubenSettlement.RewardList);

                DropHelper.DropIDToDropItem_2(chapterConfig.BoxDropID, m2C_FubenSettlement.RewardListExcess);
                DropHelper.DropIDToDropItem_2(chapterConfig.BoxDropID, m2C_FubenSettlement.RewardListExcess);
                DropHelper.DropIDToDropItem_2(chapterConfig.BoxDropID, m2C_FubenSettlement.RewardListExcess);

                m2C_FubenSettlement.StarInfos.Add(1);
                m2C_FubenSettlement.StarInfos.Add((needTime <= 5 * 60 * 1000) ? 1 : 0);
                m2C_FubenSettlement.StarInfos.Add((self.HurtValue < maxHp * 0.3) ? 1 : 0);
                for (int i = 0; i < m2C_FubenSettlement.StarInfos.Count; i++)
                {
                    starNumber += m2C_FubenSettlement.StarInfos[i];
                }

                MapMessageHelper.SendToClient(players[0], m2C_FubenSettlement);

                UserInfo userInfo = players[0].GetComponent<UserInfoComponentS>().UserInfo;
                List<FubenPassInfo> fubenPassInfos = userInfo.FubenPassList;
                FubenPassInfo fubenPassInfo = null;
                for (int i = 0; i < fubenPassInfos.Count; i++)
                {
                    if (fubenPassInfos[i].FubenId == self.ChapterId)
                    {
                        fubenPassInfo = fubenPassInfos[i];
                        break;
                    }
                }

                if (fubenPassInfo == null)
                {
                    fubenPassInfo = FubenPassInfo.Create();
                    fubenPassInfo.FubenId = self.ChapterId;
                    userInfo.FubenPassList.Add(fubenPassInfo);
                }

                fubenPassInfo.Difficulty =
                        ((int)self.FubenDifficulty > fubenPassInfo.Difficulty) ? (int)self.FubenDifficulty : fubenPassInfo.Difficulty;

                players[0].GetComponent<UserInfoComponentS>()
                        .UpdateRoleMoneyAdd(UserDataType.Exp, chapterConfig.RewardExp.ToString(), true, ItemGetWay.FubenGetReward);
                players[0].GetComponent<UserInfoComponentS>()
                        .UpdateRoleMoneyAdd(UserDataType.Gold, chapterConfig.RewardGold.ToString(), true, ItemGetWay.FubenGetReward);

                players[0].GetComponent<TaskComponentS>().OnPassFuben(self.FubenDifficulty, self.ChapterId, starNumber);
                players[0].GetComponent<ChengJiuComponentS>().OnPassFuben(self.FubenDifficulty, self.ChapterId, starNumber);
            }
        }

        public static void InitMysteryItemInfos(this CellDungeonComponentS self)
        {
            self.MysteryItemInfos.Clear();
            int openServerDay = ServerHelper.GetServeOpenDay(self.Zone());
            self.MysteryItemInfos = MysteryShopHelper.InitMysteryItemInfos(openServerDay);
        }

        public static bool IsAllMonsterDead(this CellDungeonComponentS self)
        {
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            return FubenHelp.IsAllMonsterDead(self.Scene(), players[0]);
        }
    }
}