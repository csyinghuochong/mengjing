using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 自身释放一个指定技能后，如果自身有一个或多个特定的召唤物，其召唤物会跟随角色本身一起释放角色当前技能
    /// </summary>
    public class Skill_Com_Summon_6: SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();

            Unit theUnitFrom = skillS.TheUnitFrom;

            if (theUnitFrom.Type == UnitType.Player)
            {
                // 召唤物释放相同技能
                // '90000102,90000103(如果填0是所有)
                // 召唤ID,召唤ID
                string[] summonParList = skillS.SkillConf.GameObjectParameter.Split(';');
                List<int> monsterIds = new List<int>();
                bool allMonster = false;
                try
                {
                    foreach (string s in summonParList)
                    {
                        if (s == "0")
                        {
                            allMonster = true;
                            break;
                        }

                        monsterIds.Add(int.Parse(s));
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                    return;
                }

                List<EntityRef<Unit>> all = theUnitFrom.GetParent<UnitComponent>().GetAll();
                foreach (Unit unit in all)
                {
                    if (unit.Type == UnitType.Monster && unit.GetMasterId() == theUnitFrom.Id && (allMonster || monsterIds.Contains(unit.ConfigId)))
                    {
                        C2M_SkillCmd cmd = C2M_SkillCmd.Create();
                        cmd.TargetID = skillS.SkillInfo.TargetID;
                        cmd.SkillID = skillS.SkillConf.Id;
                        if (skillS.SkillConf.SkillZhishiTargetType == 1) //自身点
                        {
                            cmd.TargetAngle = 0;
                            cmd.TargetDistance = 0;
                        }
                        else
                        {
                            if (skillS.TheUnitTarget != null)
                            {
                                float3 direction = skillS.TheUnitTarget.Position - unit.Position;
                                float ange = math.atan2(direction.x, direction.z) * 3.14f;
                                cmd.TargetAngle = (int)math.floor(ange);
                                cmd.TargetDistance = PositionHelper.Distance2D(unit.Position, skillS.TheUnitTarget.Position);
                            }
                        }

                        unit.GetComponent<SkillManagerComponentS>().OnUseSkill(cmd, true);
                    }
                }
            }

            OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            skillS.BaseOnUpdate();
            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}