namespace ET.Server
{
    [NumericWatcher(SceneType.Map, NumericType.Now_Hp)]
    public class NumericWatcher_Update_S: INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            if (unit == null || unit.IsDisposed)
            {
                Log.Error("NumericType.Now_Hp == null");
            }

            UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
            NumericComponentS numericComponentDefend = unit.GetComponent<NumericComponentS>();

            Scene DomainScene = args.Defend.Scene();
            MapComponent mapComponent = DomainScene.GetComponent<MapComponent>();
            int sceneTypeEnum = mapComponent.SceneType;
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

                if (attack.MasterId > 0 && (attack.Type == UnitType.Pet || attack.Type == UnitType.Monster))
                {
                    player = attack.GetParent<UnitComponent>().Get(attack.MasterId);
                }

                if (player != null && player.Type != UnitType.Player)
                {
                    player = null;
                }

                if (sceneTypeEnum == (int)SceneTypeEnum.CellDungeon) //个人副本接受到的伤害
                {
                    DomainScene.GetComponent<CellDungeonComponent>().OnRecivedHurt(args.OldValue - args.NewValue);
                }

                if (sceneTypeEnum == (int)SceneTypeEnum.TeamDungeon && player != null) //组队副本输出伤害
                {
                    DomainScene.GetComponent<TeamDungeonComponent>()?.OnUpdateDamage(player, unit, args.OldValue - args.NewValue);
                }

                if (sceneTypeEnum == (int)SceneTypeEnum.MiJing && player != null) //秘境伤害
                {
                    DomainScene.GetComponent<MiJingComponent>()?.OnUpdateDamage(player, unit, args.OldValue - args.NewValue);
                }

                if (sceneTypeEnum == (int)SceneTypeEnum.TrialDungeon && player != null) //试炼副本伤害
                {
                    DomainScene.GetComponent<TrialDungeonComponent>()
                            ?.OnUpdateDamage(player, attack, unit, args.OldValue - args.NewValue, args.SkillId);
                }
            }
        }
    }
    
    
    
    [NumericWatcher(SceneType.Current, NumericType.Now_Speed)]
    public class NumericWatcher_Now_Speed : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            //float speed = args.Defend.GetComponent<NumericComponentC>().GetAsFloat(NumericType.Now_Speed);
            //args.Defend.GetComponent<MoveComponent>().ChangeSpeed(speed);
        }
    }
}