using System;
using Unity.Mathematics;

namespace ET.Server
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene scene, long id, int unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    unit.AddComponent<MoveComponent>();
                    unit.Position = new float3(-10, 0, -10);
                    unit.Type = UnitType.Player;
                    if (unit.GetComponent<NumericComponentServer>() ==  null)
                    {
                        NumericComponentServer numericComponentServer = unit.AddComponent<NumericComponentServer>();
                        numericComponentServer.Set(NumericType.Speed, 6f); // 速度是6米每秒
                        numericComponentServer.Set(NumericType.AOI, 15000); // 视野15米
                    }

                    if (unit.GetComponent<BagComponentServer>() == null)
                    {
                        unit.AddComponent<BagComponentServer>();
                    }
                    unitComponent.Add(unit);
                    // 加入aoi
                    unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}