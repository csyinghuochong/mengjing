using System.Collections.Generic;

namespace ET.Server
{

    //闪电链2
    //选中范围释放类型技能。 Skill_ChainLightning2 GameObjectParameter 人数;伤害提升@人数;伤害提升  1;0.1@6;0.3
    //根据人数计算出伤害提升系数 
    public class Skill_ChainLightning_2 : SkillHandlerS
    {

        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            OnUpdate(skillS, 0);
        }

        public void BroadcastSkill(SkillS skillS, long unitid, long targetId, float x, float y, float z)
        {
            M2C_ChainLightning M2C_ChainLightning = M2C_ChainLightning.Create();
            M2C_ChainLightning.UnitId = unitid;
            M2C_ChainLightning.TargetID = targetId;
            M2C_ChainLightning.SkillID = skillS.SkillInfo.WeaponSkillID;
            M2C_ChainLightning.PosX = x;
            M2C_ChainLightning.PosY = y;
            M2C_ChainLightning.PosZ = z;
            MapMessageHelper.Broadcast(skillS.TheUnitFrom, M2C_ChainLightning);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }

            if (!skillS.IsExcuteHurt)
            {
                skillS.IsExcuteHurt = true;

                List<Unit> enemyList = new List<Unit>();
                List<EntityRef<Unit>> entities = skillS.TheUnitFrom.GetParent<UnitComponent>().GetAll();

                for (int i = entities.Count - 1; i >= 0; i--)
                {
                    Unit uu = entities[i];

                    //检测目标是否在技能范围
                    if (!skillS.CheckShape(uu.Position))
                    {
                        continue;
                    }

                    if (!skillS.TheUnitFrom.IsCanAttackUnit(uu))
                    {
                        continue;
                    }

                    enemyList.Add(uu);
                }

                //1;0.1@6;0.3
                int enemyNumber = enemyList.Count;
                string[] gameparaminfo = skillS.SkillConf.GameObjectParameter.Split('@');
                for (int i = gameparaminfo.Length - 1; i >= 0; i--)
                {
                    string[] hurtaddInfo = gameparaminfo[i].Split(';');
                    if (int.Parse(hurtaddInfo[0]) >= enemyNumber)
                    {
                        skillS.HurtAddPro = float.Parse(hurtaddInfo[1]);
                        break;
                    }
                }

                for (int i = 0; i < enemyList.Count; i++)
                {
                    skillS.OnCollisionUnit(enemyList[i]);
                    BroadcastSkill(skillS, skillS.TheUnitFrom.Id, enemyList[i].Id, 0f, 0f, 0f);
                }

                ///根据范围内敌人数量计算伤害加成
                skillS.HurtAddPro = 0f;
            }

            if (serverNow > skillS.SkillEndTime || skillS.HurtIds.Count >= 5)
            {
                skillS.SetSkillState(SkillState.Finished);
            }

            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
