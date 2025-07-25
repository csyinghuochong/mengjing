using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof (MoveComponent))]
    [FriendOf(typeof (NumericComponentS))]
    [FriendOf(typeof (UserInfoComponentS))]
    public static partial class UnitHelper
    {
        
        // 获取看见unit的玩家，主要用于广播
        public static Dictionary<long, EntityRef<AOIEntity>>  GetBeSeePlayers(this Unit self)
        {
            return self.GetComponent<AOIEntity>().GetBeSeePlayers();
        }
        
        public static Dictionary<long, EntityRef<AOIEntity>>  GetGetSeeUnits(this Unit self)
        {
            return self.GetComponent<AOIEntity>().GetSeeUnits();
        }
        
        public static void RecordPostion(this Unit self, int sceneType, int sceneId)
        {
            bool record = false;
            NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
            if (!SceneConfigHelper.UseSceneConfig(sceneType) || sceneId == 0)
            {
                record = false;
            }
            else
            {
                if (!SceneConfigCategory.Instance.Contain(sceneId))
                {
                    record = false;
                    Log.Debug($"sceneconfig ==null:  sceneType: {sceneType} sceneId: {sceneId}");
                }
                else
                {
                    record = SceneConfigCategory.Instance.Get(sceneId).IfInitPosi == 1;
                }
            }

            if (record)
            {
                numericComponent.ApplyValue(NumericType.MainCity_X, self.Position.x);
                numericComponent.ApplyValue(NumericType.MainCity_Y, self.Position.y);
                numericComponent.ApplyValue(NumericType.MainCity_Z, self.Position.z);
            }
            else
            {
                numericComponent.ApplyValue(NumericType.MainCity_X, 0f);
                numericComponent.ApplyValue(NumericType.MainCity_Y, 0f);
                numericComponent.ApplyValue(NumericType.MainCity_Z, 0f);
            }
        }

        public static int GetCurrentTowerId(this Unit self, int sceneType)
        {
            NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
            if (sceneType == MapTypeEnum.TrialDungeon)
            {
                return numericComponent.GetAsInt(NumericType.TrialDungeonId);
            }

            if (sceneType == MapTypeEnum.RandomTower)
            {
                return numericComponent.GetAsInt(NumericType.RandomTowerId);
            }

            if (sceneType == MapTypeEnum.Tower)
            {
                return numericComponent.GetAsInt(NumericType.TowerId);
            }

            return 0;
        }

        public static int GetMonsterType(this Unit self)
        {
            return MonsterConfigCategory.Instance.Get(self.ConfigId).MonsterType;
        }
        
        public static int GetMonsterSonType(this Unit self)
        {
            return MonsterConfigCategory.Instance.Get(self.ConfigId).MonsterSonType;
        }

        public static bool IsSceneItem(this Unit self)
        {
            if (self.Type != UnitType.Monster)
            {
                return false;
            }

            return self.GetMonsterType() == MonsterTypeEnum.SceneItem;
        }

        public static bool IsTowerMonster(this Unit self)
        {
            if (self.Type != UnitType.Monster)
            {
                return false;
            }

            return self.GetMonsterSonType() > 0;
        }

        public static bool IsSameTeam(this Unit self, Unit other)
        {
            if (self.Id == other.Id)
            {
                return true;
            }

            long teamid_1 = self.GetTeamId();
            long teamid_2 = other.GetTeamId();
            return teamid_1 == teamid_2 && teamid_1 != 0;
        }
        
        public static bool MasterIsPlayer(this Unit self)
        {
            long masterId = self.GetMasterId();
            if (masterId == 0)
            {
                return false;
            }
            Unit master = self.GetParent<UnitComponent>().Get(masterId);
            if (master == null)
            {
                return false;
            }
            return master.Type == UnitType.Player;
        }
        
        public static long GetTeamId(this Unit self)
        {
            return self.GetComponent<NumericComponentS>().GetAsInt(NumericType.TeamId);
        }
        
        public static int GetAttackMode(this Unit self)
        {
            return self.GetComponent<NumericComponentS>().GetAsInt(NumericType.AttackMode);
        }

        public static long GetUnionId(this Unit self)
        {
            return self.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
        }

        public static void SetBornPosition(this Unit self, float3 vector3, bool notice)
        {
            NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.Born_X, (long)(vector3.x * 10000), notice);
            numericComponent.ApplyValue(NumericType.Born_Y, (long)(vector3.y * 10000), notice);
            numericComponent.ApplyValue(NumericType.Born_Z, (long)(vector3.z * 10000), notice);
        }

        public static float3 GetBornPostion(this Unit self)
        {
            NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
            return new float3(numericComponent.GetAsFloat(NumericType.Born_X),
                numericComponent.GetAsFloat(NumericType.Born_Y),
                numericComponent.GetAsFloat(NumericType.Born_Z));
        }

        public static bool IsYeWaiMonster(this Unit self)
        {
            return self.Type == UnitType.Monster && self.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId) == 0;
        }
        
        public static int GetBattleCamp(this Unit self)
        {
            NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
            return numericComponent.GetAsInt(NumericType.BattleCamp);
        }

        public static bool IsCanBeAttack(this Unit self, bool checkdead = true)
        {
            if (self.Type == UnitType.Npc || self.Type == UnitType.DropItem
                || self.Type == UnitType.Transfers || self.Type == UnitType.JingLing
                || self.Type == UnitType.Pasture || self.Type == UnitType.Plant
                || self.Type == UnitType.Bullet || self.Type == UnitType.Stall
                || self.Type == UnitType.CellTransfers)
            {
                return false;
            }

            if (self.Type == UnitType.Monster && (self.GetMonsterType() == (int)MonsterTypeEnum.SceneItem))
            {
                return false;
            }

            StateComponentS stateComponentS = self.GetComponent<StateComponentS>();
            if (stateComponentS == null)
            {
                Console.WriteLine($"stateComponentS == null:  {self.Type}  {self.ConfigId}");
                return false;
            }

            if (!stateComponentS.IsCanBeAttack())
            {
                return false;
            }

            if (checkdead)
            {
                NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
                if (numericComponent.GetAsLong((int)NumericType.Now_Hp) <= 0
                    || numericComponent.GetAsLong((int)NumericType.Now_Dead) == 1)
                    return false;
            }

            return true;
        }

        public static Unit GetUnitByCellIndex(Scene curScene, int cellIndex, List<Unit> allunits)
        {
            for (int i = 0; i < allunits.Count; i++)
            {
                if (allunits[i].GetComponent<NumericComponentS>().GetAsInt(NumericType.GatherCellIndex) == cellIndex)
                {
                    return allunits[i];
                }
            }

            return null;
        }

        public static void AddDataComponent<K>(this Unit self) where K : Entity, IAwake, new()
        {
            if (self.GetComponent<K>() == null)
            {
                self.AddComponent<K>();
            }
        }

        public static long GetMasterId(this Unit self)
        {
            if (self.Type == UnitType.Player)
            {
                return self.Id;
            }
            
            return self.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);

            // if (self.Type == UnitType.Pet || self.Type == UnitType.Monster
            //     || self.Type == UnitType.JingLing || self.Type == UnitType.Pasture
            //     || self.Type == UnitType.Stall)
            // {
            //     return self.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);
            // }
            //
            // return 0;
        }

        public static bool IsMasterOrPet(this Unit self, Unit defend, PetComponentS petComponent)
        {
            long masterId = self.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);
            long othermaster = defend.GetComponent<NumericComponentS>().GetAsLong(NumericType.MasterId);
            if (self.Type != UnitType.Player && masterId == defend.Id)
            {
                return true;
            }

            if (self.Type == UnitType.Player && othermaster == self.Id)
            {
                return true;
            }

            if (masterId > 0 && masterId == othermaster)
            {
                return true;
            }

            if (self.Type == UnitType.Player && petComponent.GetFightPetId() == defend.Id)
            {
                return true;
            }

            return self.Id == defend.Id;
        }

        public static int GetEquipType(this Unit self)
        {
            if (self.Type != UnitType.Player)
            {
                return ItemEquipType.Common;
            }

            int itemId = self.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Weapon);
            return ItemHelper.GetEquipType(self.ConfigId, itemId);
        }

        public static int GetWeaponSkill(this Unit self, int skillId, List<SkillPro> skillPros)
        {
            int EquipType = self.GetEquipType();
            return SkillHelp.GetWeaponSkill(skillId, EquipType, skillPros);
        }

        public static int GetMaoXianExp(this Unit self)
        {
            int rechargeNum = self.GetComponent<NumericComponentS>().GetAsInt(NumericType.RechargeNumber);
            rechargeNum *= 10;
            rechargeNum += self.GetComponent<NumericComponentS>().GetAsInt(NumericType.MaoXianExp);
            return rechargeNum;
        }

        public static bool IsBoss(this Unit self)
        {
            if (self.Type != UnitType.Monster)
            {
                return false;
            }

            return self.GetMonsterType() == MonsterTypeEnum.Boss;
        }

        public static bool IsHavePlayer(Scene scene)
        {
            bool haveplayer = false;
            List<Entity> units = scene.GetComponent<UnitComponent>().Children.Values.ToList();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i] as Unit;
                if (unit.Type == UnitType.Player)
                {
                    haveplayer = true;
                    break;
                }
            }
        
            return haveplayer;
        }
        
        public static List<Unit> GetUnitList(Scene scene, int unitType)
        {
            List<Unit> list = new List<Unit>();
            List<EntityRef<Unit>> allunits = scene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                Unit unit = allunits[i];
                if (unit.Type == unitType)
                {
                    list.Add(allunits[i]);
                }
            }

            return list;
        }

        public static List<Unit> GetUnitList(Scene scene, List<int> unitType)
        {
            List<Unit> list = new List<Unit>();
            List<EntityRef<Unit>> allunits = scene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                Unit unit = allunits[i];
                if (unitType.Contains( unit.Type) )
                {
                    list.Add(allunits[i]);
                }
            }

            return list;
        }
        
        public static bool IsSameUnion(this Unit self, Unit other)
        {
            long teamid_1 = self.GetUnionId();
            long teamid_2 = other.GetUnionId();
            return teamid_1 == teamid_2 && teamid_1 != 0;
        }

        public static bool IsCanAttackUnit(this Unit self, Unit defend, bool checkdead = true)
        {
            if (self.Id == defend.Id)
            {
                return false;
            }

            if (!defend.IsCanBeAttack(checkdead))
            {
                return false;
            }

            MapComponent mapComponent = self.Scene().GetComponent<MapComponent>();
            PetComponentS petComponent = self.Type == UnitType.Player? self.GetComponent<PetComponentS>() : null;

            if (mapComponent.MapType != MapTypeEnum.Battle 
                && mapComponent.MapType != MapTypeEnum.PetMelee
                && mapComponent.MapType != MapTypeEnum.PetMatch)
            {
                if( self.IsYeWaiMonster()  && defend.IsYeWaiMonster())
                {
                    return false;
                }
            }
            
            if (mapComponent.MapType == MapTypeEnum.PetMelee
                || mapComponent.MapType == MapTypeEnum.PetMatch)
            {
                if (defend.Type == UnitType.Player)
                {
                    return false;
                }
                return self.GetBattleCamp() != defend.GetBattleCamp();
            }
            
            if (mapComponent.MapType == (int)MapTypeEnum.PetDungeon
                || mapComponent.MapType == (int)MapTypeEnum.PetTianTi
                || mapComponent.MapType == (int)MapTypeEnum.PetMing)
            {
                if (self.Type == UnitType.Player)
                {
                    return self.GetBattleCamp() != defend.GetBattleCamp();
                }
                else
                {
                    return defend.Type != UnitType.Player && self.GetBattleCamp() != defend.GetBattleCamp();
                }
            }

            if (mapComponent.MapType == (int)MapTypeEnum.BaoZang
                || mapComponent.MapType == (int)MapTypeEnum.MiJing)
            {
                //0不允许pvp
                if (SceneConfigCategory.Instance.Get(mapComponent.SceneId).IfPVP == 0)
                {
                    return self.GetBattleCamp() != defend.GetBattleCamp() && !self.IsSameTeam(defend);
                }

                //0全体: 对全部造成伤害
                //1队伍 : 对自己队伍之外的人和怪造成伤害
                //2公会：对自己公会外的人和怪造成伤害
                //3和平：对任何人都不造成伤害
                int attackmode = self.GetAttackMode();
                if (attackmode == 1 && self.IsSameTeam(defend))
                {
                    return false;
                }

                if (attackmode == 2 && self.IsSameUnion(defend))
                {
                    return false;
                }

                if (attackmode == 3 && defend.Type == UnitType.Player)
                {
                    return false;
                }

                //允许pk地图
                return !self.IsMasterOrPet(defend, petComponent);
            }

            if (mapComponent.MapType == MapTypeEnum.UnionRace)
            {
                if (self.IsSameUnion(defend))
                {
                    return false;
                }

                if (self.IsMasterOrPet(defend, petComponent))
                {
                    return false;
                }

                return true;
            }

            if (mapComponent.MapType == MapTypeEnum.Union)
            {
                return self.GetBattleCamp() != defend.GetBattleCamp();
            }

            if (mapComponent.MapType == (int)MapTypeEnum.Arena
                || mapComponent.MapType == (int)MapTypeEnum.Solo
                || mapComponent.MapType == MapTypeEnum.RunRace
                || mapComponent.MapType == MapTypeEnum.OneChallenge)
            {
                //允许pk地图
                return !self.IsMasterOrPet(defend, petComponent);
            }
            
            if (mapComponent.MapType == MapTypeEnum.Battle
                || mapComponent.MapType == MapTypeEnum.Demon)
            {
                return self.GetBattleCamp() != defend.GetBattleCamp();
            }

            if (mapComponent.MapType == (int)MapTypeEnum.JiaYuan)
            {
                return false;
            }
            
            int camp_1 = self.GetBattleCamp();
            int camp_2 = defend.GetBattleCamp();
            bool result = camp_1!= camp_2 && !self.IsSameTeam(defend);
            return result;
        }
        
        public static async ETTask<int> UpdateUnionToChat(this Unit self)
        {
            ActorId chatServerId = UnitCacheHelper.GetChatServerId( self.Zone() );

            M2Chat_UpdateUnion M2Chat_UpdateUnion = M2Chat_UpdateUnion.Create();
            M2Chat_UpdateUnion.UnitId = self.Id;
            M2Chat_UpdateUnion.UnionId = self.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0);
            Chat2M_UpdateUnion chat2G_EnterChat = (Chat2M_UpdateUnion)await self.Root().GetComponent<MessageSender>().Call(chatServerId, M2Chat_UpdateUnion);
            return chat2G_EnterChat.Error;
        }
        
        public static List<Unit> GetAliveUnitList(Scene scene, int unitType)
        {
            List<Unit> units = new List<Unit>();
            List<EntityRef<Unit>> allunits = scene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                Unit unit = allunits[i];
                if (unit.Type == unitType && unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) == 0)
                {
                    units.Add(allunits[i]);
                }
            }
            return units;
        }
        
        public static List<Unit> GetUnitList(Scene scene, float3 position, int unitType, float distance)
        {
            List<Unit> units = new List<Unit>();
            List<EntityRef<Unit>> allunits = scene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                Unit unit = allunits[i];
                if (unit.Type != unitType)
                {
                    continue;
                }

                if (math.distance(unit.Position, position) > distance)
                {
                    continue;
                }

                units.Add(allunits[i]);
            }

            return units;
        }
        
        public static bool IsRobot(this Unit self)
        {
            return self.Type == UnitType.Player && self.GetComponent<UserInfoComponentS>().UserInfo.RobotId > 0;
        }

        public static bool ISGM(this Unit self)
        {
            return self.Type == UnitType.Player && GMHelp.IsGmAccount(self.GetComponent<UserInfoComponentS>().Account);
        }

        public static void UpdateYueKaTimes(this Unit self)
        {
            NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.YueKaRemainTimes, 7);
            numericComponent.ApplyValue(NumericType.YueKaEndTime, 7);
        }
        
        public static bool IsJingLingMonster(this Unit self)
        {
            if (self.Type != UnitType.Monster)
            {
                return false;
            }
            int sonType = MonsterConfigCategory.Instance.Get(self.ConfigId).MonsterSonType;
            return sonType == 58 || sonType == 59;
        }
        
        public static int GetRealPlayer(Scene scene)
        {
            int realPlayer = 0;
            List<EntityRef<Unit>> allunits = scene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                Unit unit = allunits[i];
                if (unit.Type != UnitType.Player)
                {
                    continue;
                }
                if (unit.GetComponent<UserInfoComponentS>().UserInfo.RobotId == 0)
                {
                    realPlayer++;
                }
            }
            return realPlayer;
        }
        
        public static bool IsChest(this Unit self)
        {
            if (self.Type != UnitType.Monster)
            {
                return false;
            }
            int sonType = MonsterConfigCategory.Instance.Get(self.ConfigId).MonsterSonType;
            return sonType == 55 || sonType == 56 || sonType == 57;
        }

        public static bool IsPetMeleeTower(this Unit self)
        {
            if (self.Type != UnitType.Monster)
            {
                return false;
            }
            int sonType = MonsterConfigCategory.Instance.Get(self.ConfigId).MonsterSonType;
            return sonType == 62;
        }

        public static int GetTeamDungeonTimes(this Unit self)
        {
            NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
            return numericComponent.GetAsInt(NumericType.TeamDungeonTimes);
        }

        public static int GetTeamDungeonXieZhu(this Unit self)
        {
            NumericComponentS numericComponent = self.GetComponent<NumericComponentS>();
            return numericComponent.GetAsInt(NumericType.TeamDungeonXieZhu);
        }

        
        public static List<Unit> GetUnitListByCamp(Scene scene, int unitType, int camp)
        {
            List<Unit> units = new List<Unit>();
            List<EntityRef<Unit>> allunits = scene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                Unit unit = allunits[i];
                if (unit.Type == unitType && unit.GetBattleCamp() == camp)
                {
                    units.Add(allunits[i]);
                }
            }
            return units;
        }

        public static void RemoveAllNoSelf(Unit unit)
        {
            UnitComponent unitComponent = unit.GetParent<UnitComponent>();
            List<Entity> allunits = unitComponent.Children.Values.ToList();
            for (int i = allunits.Count - 1; i >= 0; i--)
            {
                if (unit.Id == allunits[i].Id)
                    continue;
                unitComponent.Remove(allunits[i].Id);
            }
        }

        public static string GetAIPriorityParams(this Unit target)
        {
            string targetinfo = string.Empty;
            if (target!=null)
            {
                switch (target.Type)
                {
                    case UnitType.Monster:
                        MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(target.ConfigId);
                        targetinfo = $"{target.Type};{monsterConfig.MonsterType};{monsterConfig.MonsterSonType}";
                        break;
                    default:
                        targetinfo = $"{target.Type};1;0";
                        break;
                }
            }

            return targetinfo;
        }

        public static void RemoveAllNoType(Scene scene, List<int> typelist)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            List<Entity> allunits = unitComponent.Children.Values.ToList();
            for (int i = allunits.Count - 1; i >= 0; i--)
            {
                Unit unit = allunits[i] as Unit;
                if (typelist.Contains(unit.Type()))
                {
                    continue;
                }
                unitComponent.Remove(unit.Id);
            }
        }
    }
}