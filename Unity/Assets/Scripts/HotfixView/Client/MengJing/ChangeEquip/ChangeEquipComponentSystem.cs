using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(ChangeEquipComponent))]
    [EntitySystemOf(typeof(ChangeEquipComponent))]
    public static partial class ChangeEquipComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ChangeEquipComponent self)
        {
            self.target = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
        }

        [EntitySystem]
        private static void Destroy(this ChangeEquipComponent self)
        {
        }

        public static void InitWeapon(this ChangeEquipComponent self, List<int> fashions, int occ, int equipId = 0)
        {
            NumericComponentC numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentC>();
            self.AddComponent<ChangeEquipHelper>().WeaponId = equipId;
            self.GetComponent<ChangeEquipHelper>().EquipIndex = numericComponent.GetAsInt(NumericType.EquipIndex);
            self.GetComponent<ChangeEquipHelper>().LoadEquipment(self.target, fashions, occ);
        }

        public static void ChangeEquipIndex(this ChangeEquipComponent self)
        {
            NumericComponentC numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentC>();
            self.GetComponent<ChangeEquipHelper>().EquipIndex = numericComponent.GetAsInt(NumericType.EquipIndex);
        }

        public static void UpdateFashion(this ChangeEquipComponent self, List<int> fashions, int occ, int equipId = 0)
        {
            self.GetComponent<ChangeEquipHelper>().LoadEquipment(self.target, fashions, occ);
        }

        public static void ChangeWeapon(this ChangeEquipComponent self, int weaponId)
        {
            self.GetComponent<ChangeEquipHelper>().ChangeWeapon(weaponId);
        }
    }
}