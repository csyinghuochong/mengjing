using System;

namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.Now_Hp)]
    public class NumericWatcher_Update_Now_Hp : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            NumericComponentC numericComponentDefend = unit.GetComponent<NumericComponentC>();

            long nowHpValue = numericComponentDefend.GetAsLong(NumericType.Now_Hp);
            long costHp = (nowHpValue - args.OldValue);
            EventSystem.Instance.Publish(unit.Root(), new Now_Hp_Update()
            {
                Defend = unit,
                ChangeHpValue = costHp,
                DamgeType = args.DamgeType,
                SkillID = args.SkillId,
                AttackId = args.AttackId
            });
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.Now_Dead)]
    public class NumericWatcher_Now_Dead : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (args.NewValue == 0) //复活
            {
                unit.Position = unit.GetBornPostion();
                EventSystem.Instance.Publish(unit.Root(), new UnitRevive() { Unit = unit });
            }

            if (args.NewValue == 1) //死亡
            {
                unit.GetComponent<HeroDataComponentC>().OnDead();
                EventSystem.Instance.Publish(unit.Root(), new UnitDead() { Unit = unit });
            }
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.SoloRankId)]
    public class NumericWatcher_SoloRankId : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            int no1_horse = 10009;

            if (args.Defend.MainHero)
            {
                if (args.NewValue == 1) //排行第一
                {
                    args.Defend.Root().GetComponent<UserInfoComponentC>().OnHorseActive(no1_horse, true);
                }
                else
                {
                    args.Defend.Root().GetComponent<UserInfoComponentC>().OnHorseActive(no1_horse, false);
                }
            }
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.CombatRankID)]
    public class NumericWatcher_CombatRankID : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            int no1_horse = 10004;

            if (args.Defend.MainHero)
            {
                if (args.NewValue == 1) //排行第一
                {
                    args.Defend.Root().GetComponent<UserInfoComponentC>().OnHorseActive(no1_horse, true);
                }
                else
                {
                    args.Defend.Root().GetComponent<UserInfoComponentC>().OnHorseActive(no1_horse, false);
                }
            }
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.SeasonOpenTime)]
    public class NumericWatcher_SeasonOpenTime : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            Log.Debug($"NumericWatcher_SeasonOpenTime:  {args.NewValue}");

            if (args.NewValue == 0)
            {
                Scene root = unit.Root();
                root.GetComponent<UserInfoComponentC>().OnResetSeason(false);
                root.GetComponent<BagComponentC>().OnResetSeason(false);
                root.GetComponent<TaskComponentC>().OnResetSeason(false);
            }
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.Now_Speed)]
    public class NumericWatcher_Now_Speed : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            float speed = args.Defend.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            args.Defend.GetComponent<MoveComponent>().ChangeSpeed(speed);
        }
    }

    [NumericWatcher(SceneType.Current, NumericType.PetFightIndex)]
    public class NumericWatcher_PetFightIndex : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            /////切换出战宠物。   0自身 123对应位置的宠物
            if (!unit.MainHero)
            {
                return;
            }

            Scene root = unit.Root();
            Scene currentScene = root.CurrentScene();
            int petfightindex = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetFightIndex);

            if (petfightindex > 0)
            {
                PetComponentC petComponentC = root.GetComponent<PetComponentC>();
                Unit pet = currentScene.GetComponent<UnitComponent>().Get(petComponentC.PetFightList[petfightindex - 1].PetId);

                root.GetComponent<AttackComponent>().MainUnit = pet;
                root.GetComponent<AttackComponent>().OnPetFightId(unit.ConfigId, pet.ConfigId);
            }
            else
            {
                root.GetComponent<AttackComponent>().MainUnit = unit;
                root.GetComponent<AttackComponent>().OnPetFightId(unit.ConfigId, 0);
            }

            EventSystem.Instance.Publish(root, new PetFormationUpdate());
        }
    }
}