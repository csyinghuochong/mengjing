using System;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 随机召唤一个曾经击败过的boss协助战斗
    /// </summary>
    public class Skill_Com_Summon_3: SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            Unit theUnitFrom = skillS.TheUnitFrom;
            UnitInfoComponent unitInfoComponent = theUnitFrom.GetComponent<UnitInfoComponent>();
            if (unitInfoComponent.GetZhaoHuanNumber(theUnitFrom.GetParent<UnitComponent>()) >= 100)
            {
                return;
            }

            skillS.InitSelfBuff();

            //'90000102;1;1;1;0.5,0.5,0.5,0.5,0.5;0,0,0,0,0
            //召唤ID；是否复刻玩家形象（0不是，1是）；范围；数量；血量比例,攻击比例,魔法比例,物防比例，魔防比例；血量固定值,攻击固定值，魔法固定值，物防固定值，魔防固定值
            string gameObjectParameter = skillS.SkillConf.GameObjectParameter;
            string[] summonParList = gameObjectParameter.Split(';');

            UserInfo userInfo = theUnitFrom.GetComponent<UserInfoComponentS>()?.UserInfo;
            if (userInfo != null && userInfo.DefeatedBossIds.Count > 0)
            {
                int monsterId = 0;
                float range = 0f;
                int number = 0;

                monsterId = ConfigData.DefeatedBossIds[userInfo.DefeatedBossIds[RandomHelper.RandomNumber(0, userInfo.DefeatedBossIds.Count)]];

                try
                {
                    range = float.Parse(summonParList[2]);
                    number = int.Parse(summonParList[3]);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                    return;
                }

                if (number > 100)
                {
                    Log.Error($"Skill_Com_Summon_3: {skillS.SkillConf.Id}");
                    return;
                }

                // 先销毁之前的
                UnitComponent unitComponent = theUnitFrom.GetParent<UnitComponent>();
                for (int i = unitInfoComponent.ZhaohuanIds.Count - 1; i >= 0; i--)
                {
                    long id = unitInfoComponent.ZhaohuanIds[i];
                    Unit unit = unitComponent.Get(id);
                    if (unit == null || !ConfigData.DefeatedBossIds.ContainsValue(unit.ConfigId))
                    {
                        continue;
                    }

                    unit.GetComponent<HeroDataComponentS>().OnDead(null);
                    unitInfoComponent.ZhaohuanIds.Remove(id);
                }

                for (int y = 0; y < number; y++)
                {
                    //随机坐标
                    float ran_x = RandomHelper.RandomNumberFloat(-1 * range, range);
                    float ran_z = RandomHelper.RandomNumberFloat(-1 * range, range);
                    float3 initPosi = new float3(theUnitFrom.Position.x + ran_x, theUnitFrom.Position.y, theUnitFrom.Position.z + ran_z);

                    if (skillS.SkillConf.SkillZhishiType == 1)
                    {
                        initPosi = skillS.TargetPosition;
                    }

                    Unit unitMonster = UnitFactory.CreateMonster(theUnitFrom.Scene(), monsterId, initPosi,
                        new CreateMonsterInfo()
                        {
                            Camp = theUnitFrom.GetBattleCamp(),
                            MasterID = theUnitFrom.Id,
                            AttributeParams = summonParList[1] + ";" + summonParList[4] + ";" + summonParList[5]
                        });
                    unitInfoComponent.ZhaohuanIds.Add(unitMonster.Id);
                }
            }

            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS,int updateMode)
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