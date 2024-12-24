using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 创建怪物矩阵
    /// </summary>
    public class Skill_MonsterMatrix : SkillHandlerS
    {
        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            string gameObjectParameter = skillS.SkillConf.GameObjectParameter;
            //召唤ID；是否复刻玩家形象（0不是，1是）；行数量，列数量；行间距，列间距；血量比例,攻击比例,魔法比例,物防比例，魔防比例；血量固定值,攻击固定值，魔法固定值，物防固定值，魔防固定值
            //'90000001;1;3,4;1,1;0.5,0.5,0.5,0.5,0.5;0,0,0,0,0
            //'90000101;0;3,4;2,2;0.5,0.5,0.5,0.5,0.5;0,0,0,0,0
            string[] summonParList = gameObjectParameter.Split(';');

            int monsterId = int.Parse(summonParList[0]);

            int rowNumber = int.Parse(summonParList[2].Split(',')[0]);
            int columnNumber = int.Parse(summonParList[2].Split(',')[1]);
            int maxNumber = int.Parse(summonParList[2].Split(',')[2]);

            float rowSpace = float.Parse(summonParList[3].Split(',')[0]);
            float columnSpace = float.Parse(summonParList[3].Split(',')[1]);

            //以this.TargetPosition 为中心  计算坐标点 创建怪物矩形UnitFactory.CreateMonster
            //矩形需要根据TargetAngle旋转
            int curNumber = 0;
            int centerX = rowNumber / 2;
            int centerZ = columnNumber / 2;

            if (rowNumber * columnNumber > 100)
            {
                Log.Error($"Skill_MonsterMatrix: {skillS.SkillConf.Id}");
                return;
            }

            for (int x = 0; x < rowNumber; x++)
            {
                for (int z = 0; z < columnNumber; z++)
                {
                    float newX = skillS.TargetPosition.x + (x - centerX) * rowSpace;     
                    float newZ = skillS.TargetPosition.z + (z - centerZ) * columnSpace; 
                    float3 createVector3 = new float3(newX, skillS.TargetPosition.y, newZ);
                    Unit unit = UnitFactory.CreateMonster(skillS.TheUnitFrom.Scene(), monsterId, createVector3,
                        new CreateMonsterInfo()
                        {
                            Camp = skillS.TheUnitFrom.GetBattleCamp(),
                            MasterID = skillS.TheUnitFrom.Id,
                            AttributeParams = summonParList[1] + ";" + summonParList[4] + ";" + summonParList[5]
                        });
                    skillS.TheUnitFrom.GetComponent<UnitInfoComponent>().ZhaohuanIds.Add(unit.Id);

                    curNumber++;
                    if (curNumber >= maxNumber)
                    {
                        break;
                    }
                }
            }

            OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            skillS.BaseOnUpdate();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
