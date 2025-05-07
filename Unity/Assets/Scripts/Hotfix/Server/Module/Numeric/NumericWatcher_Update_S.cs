namespace ET.Server
{
    [NumericWatcher(SceneType.Map, NumericType.Now_Hp)]
    public class NumericWatcher_Update_S: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
            NumericComponentS numericComponentDefend = unit.GetComponent<NumericComponentS>();

            Scene DomainScene = args.Defend.Scene();
            MapComponent mapComponent = DomainScene.GetComponent<MapComponent>();
            int sceneTypeEnum = mapComponent.MapType;
            int sceneId = mapComponent.SceneId;

            if (args.NewValue <= 0 && numericComponentDefend.GetAsInt(NumericType.Now_Dead) == 1)
            {
                return;
            }

            Unit attack = unit.GetParent<UnitComponent>().Get(args.AttackId);
            if (args.NewValue <= 0 && numericComponentDefend.GetAsInt(NumericType.Now_Dead) == 0)
            {
                if (attack == null || attack.IsDisposed)
                {
                    Log.Warning($"NumericWatcher_Now_Hp.args.NewValue <= 0: {attack.Type}");
                }

                // 死亡召唤
                if (args.SkillId > 0 && SkillConfigCategory.Instance.Get(args.SkillId).GameObjectName == "Skill_Com_Summon_5")
                {
                    ZhaoHuanHelper.DeadCreateZhaoHuan(args);
                }

                unit.GetComponent<HeroDataComponentS>().OnKillZhaoHuan(attack);
                unit.GetComponent<HeroDataComponentS>().OnDead(attack);
                unit.GetComponent<HeroDataComponentS>().PlayDeathSkill(attack);
            }

            if (attack != null && !attack.IsDisposed && (args.OldValue > args.NewValue))
            {
                Unit player = attack;

                if (attack.GetMasterId() > 0 && (attack.Type == UnitType.Pet || attack.Type == UnitType.Monster))
                {
                    player = attack.GetParent<UnitComponent>().Get(attack.GetMasterId());
                }

                if (player != null && player.Type != UnitType.Player)
                {
                    player = null;
                }

                Unit recordUnit = null; 
                switch (sceneTypeEnum)
                {
	                case MapTypeEnum.CellDungeon://个人副本接受到的伤害
		                recordUnit = unit.Type == UnitType.Player ? unit : null;
		                DomainScene.GetComponent<CellDungeonComponentS>().OnRecivedHurt(args.OldValue - args.NewValue);
		                break;
	                case MapTypeEnum.TeamDungeon://组队副本输出伤害
		                recordUnit = unit.Type == UnitType.Player ? unit : null;
		                DomainScene.GetComponent<TeamDungeonComponent>()?.OnUpdateDamage(player, unit, args.OldValue - args.NewValue);
		                break;
	                case MapTypeEnum.MiJing://秘境伤害
		                recordUnit = unit.Type == UnitType.Player ? unit : null;
		                DomainScene.GetComponent<MiJingDungeonComponent>()?.OnUpdateDamage(player, unit, args.OldValue - args.NewValue);
		                break;
	                case MapTypeEnum.TrialDungeon://试炼副本伤害
		                TrialDungeonComponent trialDungeonComponent = DomainScene.GetComponent<TrialDungeonComponent>();
		                if (trialDungeonComponent == null)
		                {
			                return;
		                }

		                recordUnit = trialDungeonComponent.OnUpdateDamage(player, attack, unit, args.OldValue - args.NewValue, args.SkillId);
	
		                break;
	                default:
		                recordUnit = unit.Type == UnitType.Player ? unit : null;
		                break;
                }

                if (recordUnit!=null)
                {
	                recordUnit.GetComponent<AttackRecordComponent>()?.OnUpdateDamage(player, attack, unit, args.OldValue - args.NewValue, args.SkillId, sceneTypeEnum);
                }
            }
        }
    }
    
    [NumericWatcher(SceneType.Map,(int)NumericType.SoloRankId)]
    public class NumericWatcher_SoloRankId : INumericWatcher
    {
	    public void Run(Unit unit, NumbericChange args)
        {
            // int no1_horse = 10009;
            // if (args.NewValue == 1) //排行第一
            // {
	           //  unit.GetComponent<UserInfoComponentS>().OnHorseActive(no1_horse, true);
            // }
            // else
            // {
	           //  unit.GetComponent<UserInfoComponentS>().OnHorseActive(no1_horse, false);
	           //  NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
	           //  if (numericComponent.GetAsInt(NumericType.HorseFightID) == no1_horse
	           //      || numericComponent.GetAsInt(NumericType.HorseRide) == no1_horse)
	           //  {
		          //   numericComponent.ApplyValue(NumericType.HorseFightID, 0);
		          //   numericComponent.ApplyValue(NumericType.HorseRide, 0);
	           //  }
            // }
        }
    }

	[NumericWatcher(SceneType.Map,(int)NumericType.CombatRankID)]
	public class NumericWatcher_CombatRankID : INumericWatcher
	{
		public void Run(Unit unit, NumbericChange args)
		{
			// int no1_horse = 10004;
			// if (args.NewValue == 1) //排行第一
			// {
			// 	unit.GetComponent<UserInfoComponentS>().OnHorseActive(no1_horse, true);
			// }
			// else
			// {
			// 	unit.GetComponent<UserInfoComponentS>().OnHorseActive(no1_horse, false);
			// 	NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
			// 	if (numericComponent.GetAsInt(NumericType.HorseFightID) == no1_horse)
			// 	{
			// 		numericComponent.ApplyValue(NumericType.HorseFightID, 0);
			// 		numericComponent.ApplyValue(NumericType.HorseRide, 0);
			// 	}
			// }
		}
	}

    
    [NumericWatcher(SceneType.Map,(int)NumericType.SeasonOpenTime)]
    public class NumericWatcher_SeasonOpenTime : INumericWatcher
    {
	    public void Run(Unit unit, NumbericChange args)
        {
           
        }
    }

    [NumericWatcher(SceneType.Map,(int)NumericType.OccCombatRankID)]
    public class NumericWatcher_OccCombatRankID : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
	        unit.GetComponent<BuffManagerComponentS>().InitCombatRankBuff();
        }
    }


    [NumericWatcher(SceneType.Map,(int)NumericType.RaceDonationRankID)]
	public class NumericWatcher_DonationRankID : INumericWatcher
	{
		public void Run(Unit unit, NumbericChange args)
		{
			unit.GetComponent<BuffManagerComponentS>().InitDonationBuff();
		}
	}
	
	/// <summary>
	/// 出战状态
	/// </summary>
	[NumericWatcher(SceneType.Map,(int)NumericType.HorseRide)]
	public class NumericWatcher_HorseRide : INumericWatcher
	{
		public void Run(Unit unit, NumbericChange args)
		{
			unit.OnUpdateHorseRide((int)args.OldValue);
		}
	}


    [NumericWatcher(SceneType.Map,NumericType.RechargeNumber)]
    public class NumericWatcher_RechargeNumber : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
	        unit.GetComponent<BuffManagerComponentS>().OnMaoXianJiaUpdate();
        }
    }
    
    [NumericWatcher(SceneType.Map,NumericType.MaoXianExp)]
    public class NumericWatcher_MaoXianExp : INumericWatcher
    {
	    public void Run(Unit unit, NumbericChange args)
	    {
		    unit.GetComponent<BuffManagerComponentS>().OnMaoXianJiaUpdate();
	    }
    }
    
    [NumericWatcher(SceneType.Map, NumericType.Now_Speed)]
    public class NumericWatcher_Now_Speed : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            float speed = args.Defend.GetComponent<NumericComponentS>().GetAsFloat(NumericType.Now_Speed);
            args.Defend.GetComponent<MoveComponent>()?.ChangeSpeed(speed);
        }
    }
}