using Unity.Mathematics;

namespace ET.Server
{

    //召唤类型技能
    public class Skill_Com_Summon_1 : SkillHandlerS
    {
    
        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            Unit theUnitFrom = skillS.TheUnitFrom;
            //获取参数
            UnitInfoComponent unitInfoComponent = theUnitFrom.GetComponent<UnitInfoComponent>();
            if (unitInfoComponent.GetZhaoHuanNumber(theUnitFrom.GetParent<UnitComponent>()) >= 100)
            {
                return;
            }
            skillS.InitSelfBuff();
            //70009001;0;1;1
            string[] summonParList = SkillConfigCategory.Instance.Get(skillS.SkillInfo.WeaponSkillID).GameObjectParameter.Split('@');
            for (int y = 0; y < summonParList.Length; y++)
            {
                string[] skillParList = summonParList[y].Split(';');
                int createMonsterID = int.Parse(skillParList[0]);
                if (!MonsterConfigCategory.Instance.Contain(createMonsterID))
                {
                    Log.Error($"config==null  monsterid {createMonsterID}");
                    break;
                }

                //触发召唤
                string[] vec3Str = skillParList[1].Split(',');

                if(int.Parse(skillParList[2]) > 100)
                {
                    Log.Error($"skillParList[2]) > 100 {skillS.SkillInfo.WeaponSkillID}");
                    break;
                }
                for (int i = 0; i < int.Parse(skillParList[2]); i++)
                {
                    //随机坐标
                    float rangValue = float.Parse(skillParList[3]);
                    float ran_x = RandomHelper.ReturnRamdomValue_Float(0, rangValue) - rangValue / 2;
                    float ran_z = RandomHelper.ReturnRamdomValue_Float(0, rangValue) - rangValue / 2;

                    //获取追踪目标点
                    float3 initPosi = float3.zero;
                    if (vec3Str.Length >= 3)
                    {
                        //设置坐标点
                        initPosi = new float3(float.Parse(vec3Str[0]) + ran_x, float.Parse(vec3Str[1]), float.Parse(vec3Str[2]) + ran_z);
                    }
                    else
                    {
                        //创建在自己脚下
                        initPosi = new float3(theUnitFrom.Position.x + ran_x, theUnitFrom.Position.y, theUnitFrom.Position.z + ran_z); ;
                    }

                    //创建怪物
                    Unit unit = UnitFactory.CreateMonster(theUnitFrom.Scene(), createMonsterID, initPosi, new CreateMonsterInfo()
                    { Camp = theUnitFrom.GetBattleCamp(), MasterID = theUnitFrom.Id });
                    unitInfoComponent.ZhaohuanIds.Add(unit.Id);
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
