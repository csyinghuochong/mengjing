using MongoDB.Bson;

namespace ET.Client
{
    public static class UnitTypeHelper
    {
        public static bool IsCanBeAttack(this Unit self, bool checkdead = true)
        {
            if (self.Type == UnitType.Npc || self.Type == UnitType.DropItem
                || self.Type == UnitType.Chuansong || self.Type == UnitType.JingLing
                || self.Type == UnitType.Pasture || self.Type == UnitType.Plant
                || self.Type == UnitType.Bullet || self.Type == UnitType.Stall)
                return false;
            if (self.Type == UnitType.Monster && (self.GetMonsterType() == (int)MonsterTypeEnum.SceneItem))
                return false;

            if (checkdead)
            {
                NumericComponentC numericComponent = self.GetComponent<NumericComponentC>();
                if (numericComponent.GetAsLong((int)NumericType.Now_Hp) <= 0
                    || numericComponent.GetAsLong((int)NumericType.Now_Dead) == 1)
                    return false;
            }

            return true;
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
    }
}