using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (PetDungeonComponent))]
    [FriendOf(typeof (PetDungeonComponent))]
    public static partial class PetDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PetDungeonComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this PetDungeonComponent self)
        {
        }

        public static void OnGameOver(this PetDungeonComponent self)
        {
            List<Unit> players = FubenHelp.GetUnitList(self.Scene(), UnitType.Player);
            
            List<EntityRef<Unit>> units = self.Root().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                AIComponent aIComponent =unit.GetComponent<AIComponent>();

                aIComponent?.Stop();
            }

            M2C_FubenSettlement m2C_FubenSettlement = M2C_FubenSettlement.Create();
            bool allMonsterDead = FubenHelp.IsAllMonsterDead(self.Scene(), players[0]);
            int alivedPetNumber = FubenHelp.GetAlivePetNumber(self.Scene());
            int number = 0;
            PetComponentS petComponent = players[0].GetComponent<PetComponentS>();
            for (int i = 0; i < petComponent.PetFormations.Count; i++)
            {
                number += (petComponent.PetFormations[i] != 0 ? 1 : 0);
            }
            if (!allMonsterDead)
            {
                m2C_FubenSettlement.StarInfos = new List<int>() { 0, 0, 0 };
            }
            else if (alivedPetNumber >= number)  //星数规则 1星通关 2星 胜利后己方宠物3-4 3星满员
            {
                m2C_FubenSettlement.StarInfos = new List<int>() { 1, 1, 1 };
            }
            else if (alivedPetNumber >= 3)
            {
                m2C_FubenSettlement.StarInfos = new List<int>() { 1, 1, 0 };
            }
            else
            {
                m2C_FubenSettlement.StarInfos = new List<int>() { 1, 0, 0 };
            }

            m2C_FubenSettlement.BattleResult = allMonsterDead ? CombatResultEnum.Win : CombatResultEnum.Fail;
            if (m2C_FubenSettlement.BattleResult == CombatResultEnum.Win)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(69);
                int dropId = int.Parse(globalValueConfig.Value);
                List<RewardItem> rewardItems = new List<RewardItem>();
            
                DropHelper.DropIDToDropItem(dropId, rewardItems);
                DropHelper.zhenglirewardItems(rewardItems);
            
                m2C_FubenSettlement.RewardList.AddRange(rewardItems);
                players[0].GetComponent<BagComponentS>().OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.PetFubenReward}_{TimeHelper.ServerNow()}");
            
                int petfubeId = self.Scene().GetComponent<MapComponent>().SonSceneId;
                int star = 0;
                for (int i = 0; i < m2C_FubenSettlement.StarInfos.Count; i++)
                {
                    star += m2C_FubenSettlement.StarInfos[i];
                }
                players[0].GetComponent<PetComponentS>().OnPassPetFuben(petfubeId, star);
                players[0].GetComponent<TaskComponentS>().TriggerTaskEvent(TaskTargetType.PetFubenId_19, 0, petfubeId - 10000);
            }
            MapMessageHelper.SendToClient(players[0], m2C_FubenSettlement);
        }

        public static void OnKillEvent(this PetDungeonComponent self)
        {
            List<Unit> players = FubenHelp.GetUnitList(self.Scene(), UnitType.Player);
            bool allMonsterDead = FubenHelp.IsAllMonsterDead(self.Scene(),players[0]);
            int alivedPetNumber = FubenHelp.GetAlivePetNumber(self.Scene());
            if (!allMonsterDead && alivedPetNumber > 0)
            {
                return;
            }
            
            self.OnGameOver();
        }

        public static void GenerateFuben(this PetDungeonComponent self, Unit unit, int sceneId)
        {
            unit.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.WuDi);

            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            petComponent.CheckSkin();
            List<long> pets = petComponent.PetFormations;
            for (int i = 0; i < pets.Count; i++)
            {
                RolePetInfo rolePetInfo = petComponent.GetPetInfo(pets[i]);
                if (rolePetInfo == null)
                {
                    continue;
                }

                Unit petunit = UnitFactory.CreateTianTiPet(unit.Scene(), unit.Id,
                    CampEnum.CampPlayer_1, rolePetInfo, ConfigData.Formation_1[i], 0f, i);
                petunit.GetComponent<AIComponent>().Stop();
            }

            PetFubenConfig petFubenConfig = PetFubenConfigCategory.Instance.Get(sceneId);
            self.GenerateCellMonsters(petFubenConfig.Cell_1, 0);
            self.GenerateCellMonsters(petFubenConfig.Cell_2, 1);
            self.GenerateCellMonsters(petFubenConfig.Cell_3, 2);
            self.GenerateCellMonsters(petFubenConfig.Cell_4, 3);
            self.GenerateCellMonsters(petFubenConfig.Cell_5, 4);
            self.GenerateCellMonsters(petFubenConfig.Cell_6, 5);
            self.GenerateCellMonsters(petFubenConfig.Cell_7, 6);
            self.GenerateCellMonsters(petFubenConfig.Cell_8, 7);
            self.GenerateCellMonsters(petFubenConfig.Cell_9, 8);
        }

        public static void GenerateCellMonsters(this PetDungeonComponent self, string cellInfo, int index)
        {
            string[] monsters = cellInfo.Split('@');
            float3 position = ConfigData.Formation_2[index];

            for (int i = 0; i < monsters.Length; i++)
            {
                if (string.IsNullOrEmpty(monsters[i]) || monsters[i].Length <= 1)
                {
                    continue;
                }

                //70004001;1
                string[] monsterinfo = monsters[i].Split(';');
                int monsterId = int.Parse(monsterinfo[0]);
                int cmcount = int.Parse(monsterinfo[1]);
                if (cmcount > 100)
                {
                    Log.Error($"GenerateCellMonsters: {cellInfo}");
                    break;
                }

                for (int c = 0; c < cmcount; c++)
                {
                    float range = 0.5f;
                    float3 vector3 = new float3(position.x + RandomHelper.RandomNumberFloat(-1 * range, range),
                        position.y, position.z + RandomHelper.RandomNumberFloat(-1 * range, range));
                    Unit monsterunit = UnitFactory.CreateMonster(self.Scene(), monsterId, vector3,
                        new CreateMonsterInfo() { Camp = CampEnum.CampMonster1, Rotation = 180 });
                    monsterunit.GetComponent<NumericComponentS>().ApplyValue(NumericType.UnitPositon, index, false);
                }
            }
        }
    }
}