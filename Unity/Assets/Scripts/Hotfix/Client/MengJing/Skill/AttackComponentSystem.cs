using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof (AttackComponent))]
    [FriendOf(typeof (AttackComponent))]
    public static partial class AttackComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.AttackComponent self)
        {
            self.BagComponent = self.Root().GetComponent<BagComponentC>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.AttackComponent self)
        {
            self.RemoveTimer();
        }

        public static void BeginAutoAttack(this AttackComponent self, long moveTargetId)
        {
            self.RemoveTimer();
            self.MoveAttackId = moveTargetId;
            self.Timer = self.Root().GetComponent<TimerComponent>() .NewRepeatedTimer(200, TimerInvokeType.AutoAttackGridTimer, self);
            self.OnUpdate();
        }

        public static void RemoveTimer(this AttackComponent self)
        {
            self.MoveAttackId = 0;
            self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
        }

        public static void OnUpdate(this AttackComponent self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (self.MoveAttackId == 0 || unit == null || unit.IsDisposed)
            {
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
                return;
            }

            Unit taretUnit = unit.GetParent<UnitComponent>().Get(self.MoveAttackId);
            if (taretUnit == null || taretUnit.IsDisposed || taretUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.Now_Dead) == 1)
            {
                self.MoveAttackId = 0;
                self.Root().GetComponent<ClientSenderCompnent>().Send(new C2M_Stop());
                self.Root().GetComponent<TimerComponent>()?.Remove(ref self.Timer);
                return;
            }

            if (PositionHelper.Distance2D(unit.Position, taretUnit.Position) <= self.AttackDistance)
            {
                self.AutoAttack_1(unit, taretUnit);
                if (!self.AutoAttack)
                {
                    self.RemoveTimer();
                }
            }
            else
            {
                self.MoveAttackTime = TimeHelper.ClientNow();
                unit.MoveToAsync(taretUnit.Position).Coroutine();
            }
        }

        public static void OnTransformId(this AttackComponent self, int occ, int runraceMonster)
        {
            if (runraceMonster == 0)
            {
                self.OnInitOcc(occ);
            }
            else
            {
                self.InitMonster(runraceMonster);
            }
        }

        public static void OnInitOcc(this AttackComponent self, int occ)
        {
            //普通攻击
            OccupationConfig occConfig = OccupationConfigCategory.Instance.Get(occ);
            self.UpdateSkillInfo(occConfig.InitActSkillID);

            self.UpdateComboTime();
        }

        public static void InitMonster(this AttackComponent self, int monsterId)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
            self.UpdateSkillInfo(monsterConfig.ActSkillID);
        }

        public static void SetAttackSpeed(this AttackComponent self)
        {
            int EquipType = UnitHelper.GetEquipType(self.Root());
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            float attackSpped = 1f + numericComponent.GetAsFloat(NumericType.Now_ActSpeedPro);
            self.SkillCDs = EquipType == (int)ItemEquipType.Knife? new List<int>() { 500, 1000, 1000 } : new List<int>() { 700, 700, 700 };
            for (int i = 0; i < self.SkillCDs.Count; i++)
            {
                self.SkillCDs[i] = (int)(self.SkillCDs[i] / attackSpped);
            }
        }

        public static void SetComboSkill(this AttackComponent self, long timeNow)
        {
            int lastSkill = self.ComboSkillId;
            if (timeNow - self.LastSkillTime > self.CombatEndTime)
            {
                self.ComboSkillId = self.SkillId;
            }
            else
            {
                self.ComboSkillId = SkillConfigCategory.Instance.Get(self.ComboSkillId).ComboSkillID;
            }

            int EquipType = UnitHelper.GetEquipType(self.Root());
            if ((EquipType == (int)ItemEquipType.Sword
                    || EquipType == (int)ItemEquipType.Common))
            {
                self.ComboSkillId = self.RandomGetSkill(lastSkill);
            }

            if (self.ComboSkillId == 60000103 || self.ComboSkillId == 60000203)
            {
                self.ComboStartTime = 1250;
                self.CombatEndTime = 2000;
            }

            if (self.ComboSkillId == 0)
            {
                self.ComboSkillId = self.SkillList[0];
            }

            int index = self.SkillList.IndexOf(self.ComboSkillId);
            self.CDTime = self.SkillCDs[index];
        }

        //连击
        public static void UpdateComboTime(this AttackComponent self)
        {
            int equipType = UnitHelper.GetEquipType(self.Root());
            if (equipType == ItemEquipType.Sword)
            {
                //剑
                self.ComboStartTime = 500;
                self.CombatEndTime = 500;
            }
            else if (equipType == ItemEquipType.Knife)
            {
                //刀
                self.ComboStartTime = 1000;
                self.CombatEndTime = 2000;
            }
            else
            {
                //空手默认是剑
                self.ComboStartTime = 500;
                self.CombatEndTime = 500;
            }
        }

        public static int RandomGetSkill(this AttackComponent self, int lastSkill)
        {
            int index = RandomHelper.RandomByWeight(self.Weights);
            return self.SkillList[index];
        }

        public static int GetTargetAnagle(this AttackComponent self, Unit unit, Unit taretUnit)
        {
            if (taretUnit == null || taretUnit.IsDisposed)
            {
                //return (int)quaternion.QuaternionToEuler(unit.Rotation).y;
                return 0;
            }
            else
            {
                
                // Vector3 direction = taretUnit.Position - unit.Position;
                // float ange = Mathf.Rad2Deg * Mathf.Atan2(direction.x, direction.z);
                // return Mathf.FloorToInt(ange);
                
                return 0;
            }
        }

        public static void AutoAttack_1(this AttackComponent self, Unit unit, Unit taretUnit)
        {
            long timeNow = TimeHelper.ServerNow();
            if (timeNow <= self.CDEndTime)
            {
                return;
            }

            self.SetAttackSpeed();
            self.SetComboSkill(timeNow);
            int targetAngle = self.GetTargetAnagle(unit, taretUnit);
            unit.GetComponent<SkillManagerComponentC>().SendUseSkill(self.ComboSkillId, 0, targetAngle, taretUnit != null? taretUnit.Id : 0, 0, false)
                    .Coroutine();
            self.LastSkillTime = TimeHelper.ServerNow();
            self.CDEndTime = self.LastSkillTime + self.CDTime;
        }

        public static void UpdateAttackDis(this AttackComponent self, int skillid)
        {
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(
                SkillHelp.GetWeaponSkill(skillid, UnitHelper.GetEquipType(self.Root()), null));
            self.AttackDistance = (float)skillConfig.SkillRangeSize;
        }

        public static void UpdateSkillInfo(this AttackComponent self, int skillid)
        {
            self.SkillId = skillid;
            self.ComboSkillId = SkillConfigCategory.Instance.Get(skillid).ComboSkillID;
            self.UpdateAttackDis(skillid);

            self.SkillList.Clear();
            while (skillid != 0 && self.SkillList.Count < 3)
            {
                self.SkillList.Add(skillid);
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
                skillid = skillConfig.ComboSkillID;
                if (!SkillConfigCategory.Instance.Contain(skillid))
                {
                    break;
                }
            }

            switch (self.SkillList.Count)
            {
                case 3:
                    self.Weights = new List<int>() { 50, 50, 40 };
                    break;
                case 2:
                    self.Weights = new List<int>() { 70, 20 };
                    break;
                case 1:
                    self.Weights = new List<int>() { 100 };
                    break;
            }
        }
    }
}