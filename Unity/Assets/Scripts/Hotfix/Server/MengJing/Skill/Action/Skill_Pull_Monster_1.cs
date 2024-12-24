using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 拉怪技能:瞬间拉至自身/目标点
    /// </summary>
    public class Skill_Pull_Monster_1 : SkillHandlerS
    {
        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            skillS.NowPosition = theUnitFrom.Position;
        }

        public override void OnExecute(SkillS skillS)
        {
            this.OnUpdate(skillS, 0);
        }

        public void InitPullMonster(SkillS skillS)
        {
            List<Unit> monsters = GetTargetHelpS.GetEnemyMonsters(skillS.TheUnitFrom, skillS.TargetPosition, (float)(skillS.SkillConf.DamgeRange[0])*2);
         
            for (int i = 0; i < monsters.Count; i++)
            {
                Unit unit = monsters[i];
                AIComponent aIComponent = monsters[i].GetComponent<AIComponent>();
                if (aIComponent == null)
                {
                    continue;
                }
                float3 dir = (unit.Position - skillS.TargetPosition).normalize();
                unit.GetComponent<MoveComponent>().Stop(true);
                unit.Position = skillS.TargetPosition + math.mul(dir , new float3(1,1,1));
                unit.Stop(-2);
            }
        }


        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();

            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }
            //只触发一次，需要多次触发的重写
            if (!skillS.IsExcuteHurt)
            {
                InitPullMonster(skillS);
            }
            skillS.BaseOnUpdate();
            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
