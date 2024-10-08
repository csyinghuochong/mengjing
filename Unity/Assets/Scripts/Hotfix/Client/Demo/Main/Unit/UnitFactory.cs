using Unity.Mathematics;

namespace ET.Client
{
    public static partial class UnitFactory
    {
        public static Unit CreateUnit(Scene currentScene, UnitInfo unitInfo, bool mainHero = false)
        {
            bool selfpet = false;
            bool mainScene = currentScene.Name.Equals(StringBuilderData.MainCity);
            if (mainScene && unitInfo.Type == UnitType.Pet || unitInfo.Type == UnitType.JingLing)
            {
                long mainunitid = UnitHelper.GetMyUnitFromCurrentScene(currentScene).Id;
                foreach (var kv in unitInfo.KV)
                {
                    if (kv.Key == NumericType.MasterId && kv.Value == mainunitid)
                    {
                        selfpet = true;
                        break;
                    }
                }
            }

            if (unitInfo.Type == UnitType.Npc)
            {
                selfpet = true;
            }

            if (mainScene && (SettingData.NoShowOther || UnitHelper.GetUnitList(currentScene, UnitType.Player).Count >= SettingData.NoShowPlayer)
                && !mainHero && !selfpet)
            {
                return null;
            }

            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, (int)unitInfo.ConfigId);
            unitComponent.Add(unit);
            unit.MainHero = mainHero;
            unit.Type = unitInfo.Type;
            unit.ConfigId = unitInfo.ConfigId;

            unit.AddComponent<ObjectWait>();
            unit.AddComponent<HeroDataComponentC>();
            unit.AddComponent<StateComponentC>();
            unit.AddComponent<SingingComponent>();
            unit.AddComponent<MoveComponent>();
            UnitInfoComponent unitInfoComponent = unit.AddComponent<UnitInfoComponent>();
            unitInfoComponent.UnitName = unitInfo.UnitName;
            unitInfoComponent.MasterName = unitInfo.MasterName;
            unitInfoComponent.UnionName = unitInfo.UnionName;
            unitInfoComponent.FashionEquipList = unitInfo.FashionEquipList;

            unit.Position = unitInfo.Position;
            unit.Forward = unitInfo.Forward;

            NumericComponentC numericComponentC = unit.AddComponent<NumericComponentC>();
            foreach (var kv in unitInfo.KV)
            {
                numericComponentC.ApplyValue(kv.Key, kv.Value, false);
            }

            unit.MasterId = numericComponentC.GetAsLong(NumericType.MasterId);
            if (unitInfo.MoveInfo != null && unitInfo.MoveInfo.Points.Count > 0)
            {
                using (ListComponent<float3> list = ListComponent<float3>.Create())
                {
                    list.Add(unit.Position);
                    list.AddRange(unitInfo.MoveInfo.Points);

                    unit.MoveToAsync(list).Coroutine();
                }
            }

            bool noSkill = unit.Type == UnitType.Npc && NpcConfigCategory.Instance.Get(unit.ConfigId).AI == 0;
            if (!noSkill)
            {
                unit.AddComponent<SkillManagerComponentC>().InitData(unitInfo);
                unit.AddComponent<BuffManagerComponentC>().InitData(unitInfo);
            }

            if (mainHero)
            {
                int runraceMonster = numericComponentC.GetAsInt(NumericType.RunRaceTransform);
                unit.Root().GetComponent<AttackComponent>().OnTransformId(unit.ConfigId, runraceMonster);
            }

            EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() { Unit = unit });
            return unit;
        }
        
        public static Unit CreateDropItem(Scene currentScene, DropInfo dropInfo)
        {
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            long unitId = dropInfo.UnitId == 0 ? IdGenerater.Instance.GenerateId() : dropInfo.UnitId;
            if (unitComponent.Get(unitId) != null)
            {
                return null;
            }

            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitId, 1);
            unit.Type = UnitType.DropItem;
            unitComponent.Add(unit);

            dropInfo.UnitId = unitId;
            unit.AddComponent<DropComponentC>().DropInfo = dropInfo;
            unit.GetComponent<DropComponentC>().CellIndex = dropInfo.CellIndex;
            unit.AddComponent<UnitInfoComponent>();
            unit.Position = new float3(dropInfo.X, dropInfo.Y, dropInfo.Z);

            EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() { Unit = unit });
            return unit;
        }

        //创建传送点
        public static Unit CreateTransferItem(Scene currentScene, TransferInfo transferInfo)
        {
            if (transferInfo.TransferId == 20000040)
            {
                PetComponentC petComponent = currentScene.Root().GetComponent<PetComponentC>();
                if (!PetHelper.IsShenShouFull(petComponent.RolePetInfos))
                {
                    return null;
                }
            }

            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(transferInfo.UnitId, 1);
            unit.Type = UnitType.Transfers;
            unit.ConfigId = transferInfo.TransferId;
            unitComponent.Add(unit);

            ChuansongComponent chuansongComponent = unit.AddComponent<ChuansongComponent>();
            chuansongComponent.CellIndex = transferInfo.CellIndex;
            chuansongComponent.DirectionType = transferInfo.Direction;
            unit.AddComponent<UnitInfoComponent>();
            unit.Position = new(transferInfo.X, transferInfo.Y, transferInfo.Z);
            EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() { Unit = unit });
            return unit;
        }
    }
}