using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (LocalDungeonComponent))]
    [FriendOf(typeof (LocalDungeonComponent))]
    public static partial class LocalDungeonComponentSystem
    {
        [EntitySystem]
        private static void Awake(this LocalDungeonComponent self)
        {

        }

        [EntitySystem]
        private static void Destroy(this LocalDungeonComponent self)
        {
        }

        public static void OnKillEvent(this LocalDungeonComponent self, Unit unit, Unit attack)
        {
            if (attack == null )
            {
                return;
            }

            if (unit.Type == UnitType.Monster)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                UserInfoComponentS userInfoComponent = self.MainUnit.GetComponent<UserInfoComponentS>();
                if (userInfoComponent == null || userInfoComponent.IsDisposed)
                {
                    return;
                }

                if (monsterConfig.MonsterType == (int)MonsterTypeEnum.Boss && userInfoComponent.GetUserLv() >= 20)
                {
                    userInfoComponent.UpdateRoleData(UserDataType.BaoShiDu, "-1", true);
                    return;
                }

                ///刷新刷出神秘之门
                if (userInfoComponent.GetUserLv() > 0 && !unit.IsSceneItem() && RandomHelper.RandFloat01() < 0.001f)
                {
                    int shenminId = 40000003;
                    List<EntityRef<Unit>> npclist = self.MainUnit.GetParent<UnitComponent>().GetAll();
                    for (int i = 0; i < npclist.Count; i++)
                    {
                        Unit npc = npclist[i];
                        if (npc.Type == UnitType.Npc && npc.ConfigId == shenminId)
                        {
                            shenminId = 0;
                        }
                    }

                    if (shenminId != 0)
                    {
                        UnitFactory.CreateNpcByPosition(self.Root(), shenminId, unit.Position);
                    }
                }
            }

            if(unit.Type == UnitType.Player)
            {
                //弹出结算界面
                
            }
        }

        public static void OnCleanBossCD(this LocalDungeonComponent self)
        {
            List<EntityRef<Unit>> entities = self.Scene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < entities.Count; i++)
            {
                Unit entity = entities[i];
                if (entity.Type != UnitType.Monster)
                {
                    continue;
                }

                if (entity.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) == 1)
                {
                    entity.GetComponent<HeroDataComponentS>().OnRevive();
                }
            }
        }

        public static void OnUpdateDamage(this LocalDungeonComponent self, Unit player, Unit attack, Unit defend, long damage, int skillid)
        {
            if (player == null)
            {
                return;
            }

            if (defend.Type != UnitType.Monster)
            {
                return;
            }
        }
        
        public static void GenerateFuben(this LocalDungeonComponent self, int mapid)
        {
            DungeonConfig chapterSonConfig = DungeonConfigCategory.Instance.Get(mapid);

            string allmonster = SceneConfigHelper.GetLocalDungeonMonsters_2(mapid);
            FubenHelp.CreateMonsterList(self.Scene(), allmonster);

            //生成npc
            int[] npcList = chapterSonConfig.NpcList;
            if (npcList != null)
            {
                for (int i = 0; i < npcList.Length; i++)
                {
                    if (npcList[i] == 0)
                    {
                        continue;
                    }

                    UnitFactory.CreateNpc(self.Scene(), npcList[i]);
                }
            }

            //生成传送点
            //读取传送坐标点配置
            if (chapterSonConfig.TransmitPos != null)
            {
                for (int i = 0; i < chapterSonConfig.TransmitPos.Length; i++)
                {
                    int transferId = chapterSonConfig.TransmitPos[i];
                    if (transferId == 0)
                    {
                        continue;
                    }

                    DungeonTransferConfig dungeonTransferConfig = DungeonTransferConfigCategory.Instance.Get(transferId);
                    int[] position = dungeonTransferConfig.Position;
                    float3 vector3 = new float3(position[0] * 0.01f, position[1] * 0.01f, position[2] * 0.01f);
                    //创建传送点Unit
                    Unit chuansong = self.Scene().GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
                    self.Scene().GetComponent<UnitComponent>().Add(chuansong);
                    chuansong.AddComponent<UnitInfoComponent>();
                    chuansong.AddComponent<NumericComponentS>();
                    chuansong.ConfigId = transferId;
                    chuansong.Type = UnitType.Transfers;
                    chuansong.Position = vector3;
                    chuansong.AddComponent<AOIEntity, int, float3>(9 * 1000, chuansong.Position);
                }
            }
        }
    }
}