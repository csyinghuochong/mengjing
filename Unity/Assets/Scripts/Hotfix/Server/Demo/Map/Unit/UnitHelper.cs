using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(MoveComponent))]
    [FriendOf(typeof(NumericComponentServer))]
    [FriendOf(typeof(UserInfoComponentServer))]
    public static partial class UnitHelper
    {
        public static UnitInfo CreateUnitInfo(Unit unit)
        {
            UnitInfo unitInfo = new();
            NumericComponentServer nc = unit.GetComponent<NumericComponentServer>();
            unitInfo.UnitId = unit.Id;
            unitInfo.ConfigId = unit.ConfigId;
            unitInfo.Type = (int)unit.Type();
            unitInfo.Position = unit.Position;
            unitInfo.Forward = unit.Forward;

            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            if (moveComponent != null)
            {
                if (!moveComponent.IsArrived())
                {
                    unitInfo.MoveInfo = new MoveInfo();
                    unitInfo.MoveInfo.Points.Add(unit.Position);
                    for (int i = moveComponent.N; i < moveComponent.Targets.Count; ++i)
                    {
                        float3 pos = moveComponent.Targets[i];
                        unitInfo.MoveInfo.Points.Add(pos);
                    }
                }
            }

            foreach ((int key, long value) in nc.NumericDic)
            {
                unitInfo.KV.Add(key, value);
            }

            return unitInfo;
        }
        
        // 获取看见unit的玩家，主要用于广播
        public static Dictionary<long, AOIEntity> GetBeSeePlayers(this Unit self)
        {
            return self.GetComponent<AOIEntity>().GetBeSeePlayers();
        }

        public static async ETTask<(bool, Unit)> LoadUnit(Player player, Scene scene,CreateRoleInfo createRoleInfo , string account, long accountId)
        {
            Unit unit = await UnitCacheHelper.GetUnitCache(scene, player.UnitId);

            bool isNewUnit = unit == null;
            
            //if (isNewUnit)
            {
                unit = UnitFactory.Create(scene, player.UnitId, UnitType.Player,createRoleInfo,account, accountId);

                UnitCacheHelper.AddOrUpdateUnitAllCache(unit);
            }

            return (isNewUnit, unit);
        }

        public static void RecordPostion(this Unit self, int sceneType, int sceneId)
        {
            bool record = false;
            NumericComponentServer numericComponent = self.GetComponent<NumericComponentServer>();
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
                numericComponent.Set(NumericType.MainCity_X, self.Position.x);
                numericComponent.Set(NumericType.MainCity_Y, self.Position.y);
                numericComponent.Set(NumericType.MainCity_Z, self.Position.z);
            }
            else
            {
                numericComponent.Set(NumericType.MainCity_X, 0f);
                numericComponent.Set(NumericType.MainCity_Y, 0f);
                numericComponent.Set(NumericType.MainCity_Z, 0f);
            }
        }
        
        public static int GetCurrentTowerId(this Unit self, int sceneType)
        {
            NumericComponentServer numericComponent = self.GetComponent<NumericComponentServer>();
            if (sceneType == SceneTypeEnum.TrialDungeon)
            {
                return numericComponent.GetAsInt(NumericType.TrialDungeonId);
            }
            if (sceneType == SceneTypeEnum.RandomTower)
            {
                return numericComponent.GetAsInt(NumericType.RandomTowerId);
            }
            if (sceneType == SceneTypeEnum.Tower)
            {
                return numericComponent.GetAsInt(NumericType.TowerId);
            }
            return 0;
        }
    }
}