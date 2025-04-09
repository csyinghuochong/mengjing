using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    public static class MapHelper
    {
        public static void LogMoveInfo(string message)
        {
            //Log.ILog.Debug(message);
        }

        public static Unit GetNearestUnit(Unit main)
        {
            List<Entity> units = main.GetParent<UnitComponent>().Children.Values.ToList();
            Unit nearest = null;
            float distance = -1f;
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i] as Unit;
                if (main.Id == unit.Id)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd > distance && distance > 0)
                {
                    continue;
                }

                if (!main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                if (distance < 0f || dd < distance)
                {
                    nearest = unit;
                    distance = dd;
                }
            }

            return nearest;
        }

        public static Unit GetNearItem(Scene zoneScene)
        {
            float distance = 10f;
            Unit unit = null;
            Unit main = UnitHelper.GetMyUnitFromClientScene(zoneScene);
            List<EntityRef<Unit>> units = zoneScene.CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit uu = units[i];
                if (uu.Type != UnitType.DropItem)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, uu.Position);
                if (dd < distance)
                {
                    unit = uu;
                    distance = dd;
                }
            }

            return unit;
        }

        public static long GetChestBox(Scene zoneScene)
        {
            float distance = 10f;
            Unit unit = null;
            Unit main = UnitHelper.GetMyUnitFromClientScene(zoneScene);
            List<EntityRef<Unit>> units = zoneScene.CurrentScene().GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit uu = units[i];
                if (!uu.IsChest())
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, uu.Position);
                if (dd < distance)
                {
                    unit = uu;
                    distance = dd;
                }
            }

            return unit != null ? unit.Id : 0;
        }

        public static List<Unit> GetCanShiQuByCell(Scene zoneScene, int cell)
        {
            List<Unit> ids = new List<Unit>();
            List<Entity> units = zoneScene.CurrentScene().GetComponent<UnitComponent>().Children.Values.ToList();
            for (int i = 0; i < units.Count; i++)
            {
                Unit uu = units[i] as Unit;
                if (uu.Type != UnitType.DropItem)
                {
                    continue;
                }

                int dropcell = uu.GetComponent<NumericComponentC>().GetAsInt(NumericType.CellIndex);
                if (dropcell == cell)
                {
                    ids.Add(uu);
                }

                if (ids.Count >= 20)
                {
                    break;
                }
            }

            return ids;
        }

        public static List<Unit> GetCanShiQu(Scene zoneScene, float distance)
        {
            List<Unit> drops = new List<Unit>();
            List<Entity> units = zoneScene.CurrentScene().GetComponent<UnitComponent>().Children.Values.ToList();
            Unit main = UnitHelper.GetMyUnitFromClientScene(zoneScene);
            for (int i = 0; i < units.Count; i++)
            {
                Unit uu = units[i] as Unit;
                if (uu.Type != UnitType.DropItem)
                {
                    continue;
                }

                if (PositionHelper.Distance2D(main.Position, uu.Position) < distance)
                {
                    drops.Add(uu);
                }

                if (drops.Count >= 20)
                {
                    break;
                }
            }

            return drops;
        }

        public static async ETTask<int> SendPickItem(Scene root, List<Unit> unitDrops)
        {
            BagComponentC bagComponentC = root.GetComponent<BagComponentC>();
            bagComponentC.RealAddItem--;
            
            List<long> unitDropIds = new();
            List<long> removeIds = new();
            List<(int, int)> unitDropTipInfos = new List<(int, int)>();
            foreach (Unit unit in unitDrops)
            {
                if (unit != null && !unit.IsDisposed)
                {
                    NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
                    
                    unitDropIds.Add(unit.Id);
                    
                    if (numericComponent.GetAsInt(NumericType.DropType) == 1)
                    {
                        removeIds.Add(unit.Id);
                    }
                    
                    unitDropTipInfos.Add(new(numericComponent.GetAsInt(NumericType.DropItemId), numericComponent.GetAsInt(NumericType.DropItemNum)));
                }
            }
            
            C2M_PickItemRequest request = C2M_PickItemRequest.Create();
            request.ItemIds = unitDropIds;
            M2C_PickItemResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as M2C_PickItemResponse;

            UnitComponent unitComponent = root.CurrentScene().GetComponent<UnitComponent>();
            foreach (long id in removeIds)
            {
                unitComponent.Remove(id);
            }
            
            if (response.Error == ErrorCode.ERR_Success)
            {
                foreach ((int, int) unitDropTipInfo in unitDropTipInfos)
                {
                    EventSystem.Instance.Publish(root, new GetDrop() { ItemId = unitDropTipInfo.Item1, ItemNum = unitDropTipInfo.Item2 });
                }
            }

            bagComponentC.RealAddItem++;
            
            return response.Error;
        }

        public static async ETTask<int> RequestTowerReward(Scene root, int towerid, int sceneType)
        {
            C2M_RandomTowerRewardRequest request = C2M_RandomTowerRewardRequest.Create();
            request.RewardId = towerid;
            request.SceneType = sceneType;

            M2C_RandomTowerRewardResponse respone = (M2C_RandomTowerRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (respone.Error == ErrorCode.ERR_Success)
            {
                UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
                userInfoComponent.UserInfo.TowerRewardIds.Add(towerid);
            }

            return respone.Error;
        }

        public static async ETTask<int> RequestPetMeleeReward(Scene root, int sceneId)
        {
            C2M_PetMeleeRewardRequest request = C2M_PetMeleeRewardRequest.Create();
            request.SceneId = sceneId;

            M2C_PetMeleeRewardResponse respone = (M2C_PetMeleeRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (respone.Error == ErrorCode.ERR_Success)
            {
                PetComponentC petComponentC = root.GetComponent<PetComponentC>();
                petComponentC.PetMeleeRewardIds.Add(sceneId);
            }

            return respone.Error;
        }
    }
}