using System.Collections.Generic;
using System.Linq;

namespace ET
{
    public static class SceneConfigHelper
    {

        public static bool CanTransfer(int oldScene, int newScene)
        {
            if ((newScene == MapTypeEnum.Solo || newScene == MapTypeEnum.TeamDungeon )
                && (oldScene == MapTypeEnum.LocalDungeon || oldScene == MapTypeEnum.JiaYuan))
            {
                return true;
            }

            if (oldScene == newScene
                        && oldScene != MapTypeEnum.LocalDungeon
                        && oldScene != MapTypeEnum.JiaYuan
                        && oldScene != MapTypeEnum.MainCityScene
                        && oldScene != MapTypeEnum.PetDungeon
                        && oldScene != MapTypeEnum.SeasonTower
                        && oldScene != MapTypeEnum.CellDungeon)
            {
                return false;
            };
            if (oldScene != newScene
                && oldScene > MapTypeEnum.MainCityScene
                && newScene > MapTypeEnum.MainCityScene)
            {
                return false;
            }
            return true;
        }

        public static List<int> GetSceneListByType(int sceneType)
        {
            List<int> sceneList = new List<int>();
            List<SceneConfig> sceneConfigs = SceneConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < sceneConfigs.Count; i++)
            {
                if (sceneConfigs[i].MapType != sceneType)
                {
                    continue;
                }
                sceneList.Add(sceneConfigs[i].Id);  
            }

            return sceneList;
        }

        public static bool IsCanRideHorse(int sceneTypeEnum)
        {
            return (sceneTypeEnum != MapTypeEnum.RunRace
                && sceneTypeEnum != MapTypeEnum.Happy
                && sceneTypeEnum != MapTypeEnum.SingleHappy);
        }

        /// <summary>
        /// 单人副本
        /// </summary>
        /// <param name="sceneTypeEnum"></param>
        /// <returns></returns>
        public static bool IsSingleFuben(int sceneTypeEnum)
        {
            return sceneTypeEnum == MapTypeEnum.CellDungeon
                || sceneTypeEnum == MapTypeEnum.PetTianTi
                || sceneTypeEnum == MapTypeEnum.Tower
                || sceneTypeEnum == MapTypeEnum.LocalDungeon
                || sceneTypeEnum == MapTypeEnum.PetDungeon
                || sceneTypeEnum == MapTypeEnum.RandomTower
                || sceneTypeEnum == MapTypeEnum.TrialDungeon
                || sceneTypeEnum == MapTypeEnum.SealTower
                || sceneTypeEnum == MapTypeEnum.PetMing
                || sceneTypeEnum == MapTypeEnum.SeasonTower
                || sceneTypeEnum == MapTypeEnum.PetMelee
                || sceneTypeEnum == MapTypeEnum.SingleHappy;
        }



        public static bool ShowRightTopButton(int sceneType)
        {
            return sceneType != MapTypeEnum.Battle
                && sceneType != MapTypeEnum.TrialDungeon
                && sceneType != MapTypeEnum.Tower
                && sceneType != MapTypeEnum.Arena
                && sceneType != MapTypeEnum.Happy
                && sceneType != MapTypeEnum.RunRace
                && sceneType != MapTypeEnum.Demon
                && sceneType != MapTypeEnum.SeasonTower
                && sceneType != MapTypeEnum.SingleHappy;
        }

        public static bool ShowLeftButton(int sceneType)
        {
            return sceneType != MapTypeEnum.TrialDungeon
                && sceneType != MapTypeEnum.MiJing
                && sceneType != MapTypeEnum.Happy
                && sceneType != MapTypeEnum.RunRace
                && sceneType != MapTypeEnum.Demon
                && sceneType != MapTypeEnum.SingleHappy;
        }

        public static bool UseSceneConfig(int sceneType)
        {
            return sceneType != MapTypeEnum.LocalDungeon
                 && sceneType != MapTypeEnum.CellDungeon
                 && sceneType != MapTypeEnum.DragonDungeon
                 && sceneType != MapTypeEnum.LoginScene;
        }

        public static bool IfCanRevive(int sceneType, int sceneId)
        {
            if (!UseSceneConfig(sceneType))
            {
                return true;
            }
            return SceneConfigCategory.Instance.Get(sceneId).IfUseRes == 0;
        }

        public static bool ShowMiniMap(int sceneType, int sceneId)
        {
            if (!UseSceneConfig(sceneType))
            {
                return true;
            }
            return SceneConfigCategory.Instance.Get(sceneId).ifShowMinMap == 1;
        }

        public static List<int> CreateMonsterList(string createMonster)
        {
            List<int> monsterId = new List<int>();
            if (CommonHelp.IfNull(createMonster))
            {
                return monsterId;
            }

            string[] monsters = createMonster.Split('@');
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] == "0")
                {
                    continue;
                }
                string[] mondels = monsters[i].Split(';');
                int monsterid = int.Parse(mondels[2]);
                if (!MonsterConfigCategory.Instance.Contain(monsterid))
                {
                    Log.Error($"monsterid==null {monsterid}");
                    continue;
                }
                monsterId.Add(monsterid);
            }
            return monsterId;

        }

        public static List<int> CreateMonsterList(int[] monsterPos)
        {
            List<int> monsterIds = new List<int>();
            if (monsterPos == null || monsterPos.Length == 0)
            {
                return monsterIds;
            }
            for (int i = 0; i < monsterPos.Length; i++)
            {
                int posid = monsterPos[i];
                while (posid != 0)
                {
                    posid = CreateMonsterByPos(posid, monsterIds);
                }
            }
            return monsterIds;
        }

        public static int CreateMonsterByPos(int monsterPos, List<int> monsterIds)
        {
            if (monsterPos == 0)
            {
                return 0;
            }

            MonsterPositionConfig monsterPosition = MonsterPositionConfigCategory.Instance.Get(monsterPos);
            monsterIds.AddRange(monsterPosition.MonsterID);

            return monsterPosition.NextID;
        }

        public static List<int> GetSceneMonsterList(int sceneId)
        {
            List<int> monsterid = new List<int>();

            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            if (sceneConfig == null)
            {
                return monsterid;
            }

            monsterid.AddRange(CreateMonsterList(sceneConfig.CreateMonsterPosi));
            return monsterid;
        }

        public static string GetLocalDungeonMonsters_2(int mapid)
        {
            if (mapid == 0)
            {
                return string.Empty;
            }

            DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(mapid);
            string allmonster = string.Empty;
            if (dungeonConfig.MonsterPosition != 0)
            {
                int posid = dungeonConfig.MonsterPosition;
                while (posid != 0)
                {
                    MonsterPositionConfig monsterPosition = MonsterPositionConfigCategory.Instance.Get(posid);

                    if (posid == monsterPosition.NextID)
                    {
                        Log.Error($"posid == monsterPosition.NextID:  {posid}");
                        break;
                    }


                    //1;157.69,29.24,49.88;41005001;1

                    posid = monsterPosition.NextID;

                    string monsterinfo = string.Empty;
                    int mtype = monsterPosition.Type;

                    for (int monster = 0; monster < monsterPosition.MonsterID.Length; monster++)
                    {
                        int monsterid = monsterPosition.MonsterID[monster];
                        switch (mtype)
                        {
                            case 1:
                                monsterinfo = $"1;{monsterPosition.Position};{monsterid};{monsterPosition.CreateNum[monster]}";
                                break;
                            case 2:
                                monsterinfo = $"2;{monsterPosition.Position};{monsterid};{monsterPosition.CreateNum[monster]},{monsterPosition.CreateRange}";
                                break;
                            default:
                                break;
                        }

                        if (!string.IsNullOrEmpty(monsterinfo))
                        {
                            if (!string.IsNullOrEmpty(allmonster))
                            {
                                allmonster = allmonster + "@" + monsterinfo;
                            }
                            else
                            {
                                allmonster = monsterinfo;
                            }
                        }
                    }
                    
                    if (posid == 0)
                    {
                        break;
                    }
                }
            }
            return allmonster;
        }



        public static string[] GetPostionMonster(int fubenid, int monsterId, int wave)
        {
            string monsterlist = GetLocalDungeonMonsters_2(fubenid);
            string[] monsters = monsterlist.Split('@');
            for (int i = 0; i < monsters.Length; i++)
            {
                if (CommonHelp.IfNull(monsters[i]))
                {
                    continue;
                }
                string[] mondels = monsters[i].Split(';');
                string[] position = mondels[1].Split(',');
                int monsterid = int.Parse(mondels[2]);
                if (monsterid == monsterId || i == wave)
                {
                    return position;
                }
            }
            return null;
        }

        public static int GetFubenByMonster(int monsterId)
        {
            if (ConfigData.MonsterToFuben.ContainsKey(monsterId))
            {
                return ConfigData.MonsterToFuben[monsterId];
            }

            List<DungeonConfig> dungeonConfigs = DungeonConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < dungeonConfigs.Count; i++)
            {
                List<int> allmonster = GetLocalDungeonMonsters(dungeonConfigs[i].Id);
                if (allmonster.Contains(monsterId))
                {
                    ConfigData.MonsterToFuben.Add(monsterId, dungeonConfigs[i].Id);
                    return dungeonConfigs[i].Id;
                }
            }
            return 0;
        }

        public static List<int> GetLocalDungeonMonsters(int mapid)
        {
            List<int> monsterIds = new List<int>();
            //DungeonConfig chapterSonConfig = DungeonConfigCategory.Instance.Get(mapid);
            //string createMonster = chapterSonConfig.CreateMonster;
            //if (chapterSonConfig.MonsterGroup != 0)
            //{
            //    MonsterGroupConfig monsterGroupConfig = MonsterGroupConfigCategory.Instance.Get(chapterSonConfig.MonsterGroup);
            //    createMonster = createMonster + "@" + monsterGroupConfig.CreateMonster;
            //}
            string createMonster = GetLocalDungeonMonsters_2(mapid);
            string[] monsters = createMonster.Split('@');
            for (int i = 0; i < monsters.Length; i++)
            {
                if (CommonHelp.IfNull(monsters[i]))
                {
                    continue;
                }
                string[] mondels = monsters[i].Split(';');
                string[] monsterid = mondels[2].Split(',');
                monsterIds.Add(int.Parse(monsterid[0]));
            }
            return monsterIds;
        }
    }
}
