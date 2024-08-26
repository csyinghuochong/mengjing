using System.Collections.Generic;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Fashion_FashionUpdate : AEvent<Scene, FashionUpdate>
    {
        protected override async ETTask Run(Scene scene, FashionUpdate args)
        {
            Unit unit = args.Unit;
            List<int> fashionids = args.Unit.GetComponent<UnitInfoComponent>().FashionEquipList;

            NumericComponentC numericComponent = args.Unit.GetComponent<NumericComponentC>();
            int weaponid = numericComponent.GetAsInt(NumericType.Now_Weapon);

            unit.GetComponent<ChangeEquipComponent>().UpdateFashion(fashionids, unit.ConfigId, weaponid);

            await ETTask.CompletedTask;
        }
    }
}