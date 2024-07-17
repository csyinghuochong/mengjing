namespace ET.Server
{
    
    public class AI_Tower : AAIHandler
    {

        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit unit = aiComponent.GetParent<Unit>();
            MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(unit.ConfigId);

            for (int i = 0; i < 100000; ++i)
            {
                if (unit.IsDisposed)
                    return;

                C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                cmd.SkillID = monsterCof.ActSkillID;
                //技能释放角度
                cmd.TargetAngle = int.Parse(monsterCof.AIParameter);

                //触发技能
                unit.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, true);
                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(1000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }

    }

}