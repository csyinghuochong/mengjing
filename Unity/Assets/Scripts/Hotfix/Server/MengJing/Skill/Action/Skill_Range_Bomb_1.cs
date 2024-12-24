using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 范围轰炸
    /// </summary>
    public class Skill_Range_Bomb_1 : SkillHandlerS
    {
        
        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            //1; 60031162
            string[] paramsinfo = skillS.SkillConf.GameObjectParameter.Split(';');
            skillS.SkillTriggerInvelTime = (long)(float.Parse(paramsinfo[0]) * 1000);
            skillS.SkillTriggerLastTime = 0;
            skillS.TriggeSkillId = int.Parse(paramsinfo[1]);  
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.BulletUnit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.TheUnitFrom.Id, skillS.SkillConf.Id, 0, skillS.TheUnitFrom.Position, new CreateMonsterInfo()); ;
            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            skillS.BaseOnUpdate();

            long servernow = TimeHelper.ServerNow();
            if (servernow - skillS.SkillTriggerLastTime < skillS.SkillTriggerInvelTime)
            {
                return;
            }

            skillS.SkillTriggerLastTime = servernow;
            List<EntityRef<Unit>> entities = skillS.TheUnitFrom.GetParent<UnitComponent>().GetAll();
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                Unit target = entities[i];
                //检测目标是否在技能范围
                if (!skillS.TheUnitFrom.IsCanAttackUnit(target))
                {
                    continue;
                }
                if (!skillS.CheckShape(target.Position) )
                {
                    continue;
                }

                float3 direction = target.Position - skillS.BulletUnit.Position;
                float ange = (math.atan2(direction.x, direction.z)) * 3.14f;
                C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                //触发技能
                cmd.TargetID = target.Id;
                cmd.SkillID = skillS.TriggeSkillId;
                cmd.TargetAngle = (int)math.floor(ange);
                cmd.TargetDistance = PositionHelper.Distance2D(skillS.BulletUnit.Position, target.Position);
                skillS.TheUnitFrom.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, false);
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            //移除Unity
            if (skillS.BulletUnit != null && !skillS.BulletUnit.IsDisposed)
            {
                skillS.BulletUnit.GetParent<UnitComponent>().Remove(skillS.BulletUnit.Id);
            }
           
            skillS.Clear();
        }
    }
}
