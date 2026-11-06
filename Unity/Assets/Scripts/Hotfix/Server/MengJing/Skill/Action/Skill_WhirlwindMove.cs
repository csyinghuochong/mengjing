using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(AIComponent))]
    public class Skill_WhirlwindMove : Skill_ComSelfRang_Damge_1
    {
        private const int Executed = 1;
        private const int AddedBlock = 2;
        private const int ResumeAI = 4;

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            base.OnInit(skillS, theUnitFrom);
            // These existing per-skill slots are unused by the inherited handler.
            // Hotfix handlers themselves must not declare mutable fields.
            skillS.IsStop = 0;
            skillS.MoveTime = 0;
        }

        public override void OnExecute(SkillS skillS)
        {
            if ((skillS.IsStop & Executed) != 0)
            {
                return;
            }

            Unit unit = skillS.TheUnitFrom;
            AIComponent ai = unit.GetComponent<AIComponent>();
            StateComponentS state = unit.GetComponent<StateComponentS>();
            int flags = Executed;
            if (ai != null && ai.Timer != 0)
            {
                flags |= ResumeAI;
            }
            if (!state.StateTypeGet(StateTypeEnum.BePulled))
            {
                flags |= AddedBlock;
            }
            skillS.IsStop = flags;

            // This existing state rejects both normal attacks and passive casts.
            // ServerCanMove still permits the movement driven by this skill.
            if ((flags & AddedBlock) != 0)
            {
                state.StateTypeAdd(StateTypeEnum.BePulled);
            }
            if ((flags & ResumeAI) != 0)
            {
                ai.Stop_2();
            }
            unit.Stop(-2);
            base.OnExecute(skillS);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            Unit unit = skillS.TheUnitFrom;
            if (unit == null || unit.IsDisposed ||
                unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) != 0)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }

            // The inherited handler updates a SelfFollow circle and repeats damage.
            base.OnUpdate(skillS, updateMode);

            // Let the inherited handler process the final scheduled damage tick
            // before finishing; it also checks the configured end time.
            if (TimeHelper.ServerNow() > skillS.SkillEndTime)
            {
                return;
            }

            if ((skillS.IsStop & Executed) == 0 || TimeHelper.ServerNow() < skillS.MoveTime)
            {
                return;
            }
            skillS.MoveTime = TimeHelper.ServerNow() + 250;

            Unit target = unit.GetParent<UnitComponent>().Get(skillS.SkillInfo.TargetID);
            if (target == null || target.IsDisposed || !unit.IsCanAttackUnit(target))
            {
                target = GetTargetHelpS.GetNearestEnemy(unit, 30f, true);
            }
            if (target == null || target.IsDisposed)
            {
                unit.Stop(-2);
                return;
            }

            float3 offset = target.Position - unit.Position;
            offset.y = 0;
            if (math.lengthsq(offset) <= 1f)
            {
                unit.Stop(-2);
                return;
            }
            unit.FindPathMoveToAsync(target.Position).Coroutine();
        }

        public override void OnFinished(SkillS skillS)
        {
            int flags = skillS.IsStop;
            skillS.IsStop = 0;
            skillS.MoveTime = 0;
            if ((flags & Executed) != 0)
            {
                Unit unit = skillS.TheUnitFrom;
                if (unit != null && !unit.IsDisposed)
                {
                    unit.Stop(-2);
                    StateComponentS state = unit.GetComponent<StateComponentS>();
                    if ((flags & AddedBlock) != 0 && state != null)
                    {
                        state.StateTypeRemove(StateTypeEnum.BePulled);
                    }
                    NumericComponentS numeric = unit.GetComponent<NumericComponentS>();
                    AIComponent ai = unit.GetComponent<AIComponent>();
                    if ((flags & ResumeAI) != 0 && ai != null && numeric != null &&
                        numeric.GetAsInt(NumericType.Now_Dead) == 0)
                    {
                        ai.Begin();
                    }
                }
            }
            base.OnFinished(skillS);
        }
    }
}
