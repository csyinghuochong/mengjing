using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [EntitySystemOf(typeof(AttackRecordComponent))]
    [FriendOf(typeof(AttackRecordComponent))]
    public static partial class AttackRecordComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.AttackRecordComponent self)
        {
            self.DropType = 0;
            self.AttackingId = 0;
            self.BeAttackId = 0;
            self.BeAttackPlayerList.Clear();

            if (self.GetParent<Unit>().Type != UnitType.Monster)
            {
                return;
            }
            self.DropType = MonsterConfigCategory.Instance.Get(self.GetParent<Unit>().ConfigId).DropType;
        }
        [EntitySystem]
        private static void Destroy(this ET.Server.AttackRecordComponent self)
        {

        }
        
        public static void BeAttacking(this AttackRecordComponent self, Unit attack, long hurtvalue)
        {
            if (hurtvalue >= 0)
            {
                return;
            }

            long attackId = UnitHelper.GetMasterId(attack);
            if (attackId == 0)
            {
                return;
            }
            if ( !self.BeAttackPlayerList.ContainsKey(attackId))
            {
                self.BeAttackPlayerList.Add(attackId, 0);
            }
            self.BeAttackPlayerList[attackId] += (hurtvalue * -1);

            self.UpdateBelongId();
        }

        public static void OnRemoveAttackByUnit(this AttackRecordComponent self, long unitid)
        {
            if (self.BeAttackPlayerList.ContainsKey(unitid))
            {
                self.BeAttackPlayerList.Remove(unitid);
            }
        }

        public static void ClearBeAttack(this AttackRecordComponent self)
        {
            self.BeAttackPlayerList.Clear();
            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            numericComponent.ApplyValue(NumericType.BossBelongID, 0);
        }

        public static List<long> GetBeAttackPlayerList(this AttackRecordComponent self)
        {
            return self.BeAttackPlayerList.Keys.ToList();
        }

        public static void UpdateBelongId(this AttackRecordComponent self)
        {
            long belongId = 0;
            long hurtvalue = 0;
            foreach ((long id , long hurt) in self.BeAttackPlayerList)
            {
                if (hurt > hurtvalue)
                {
                    hurtvalue = hurt;
                    belongId = id;
                }
            }

            NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
            if (numericComponent.GetAsLong(NumericType.BossBelongID)!= belongId)
            {
                numericComponent.ApplyValue(NumericType.BossBelongID, belongId);
                self.LastBelongTime = TimeHelper.ServerNow();
            }
        }
    }
}