using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    
    /// <summary>
    /// 召唤
    /// </summary>
    public class Skill_Com_Summon_2 : SkillHandlerS
    {

        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        //退出
        public override void OnExecute(SkillS skillS)
        {
            Unit theUnitFrom = skillS.TheUnitFrom;
            UnitInfoComponent unitInfoComponent = theUnitFrom.GetComponent<UnitInfoComponent>();
            if (unitInfoComponent.GetZhaoHuanNumber(theUnitFrom.GetParent<UnitComponent>()) >= 100)
            {
                return;
            }
            skillS.InitSelfBuff();

            //'90000102;1;1;1;0.5,0.5,0.5,0.5,0.5;0,0,0,0,0;90000102,90000103
            //召唤ID；是否复刻玩家形象（0不是，1是）；范围；数量；血量比例,攻击比例,魔法比例,物防比例，魔防比例；血量固定值,攻击固定值，魔法固定值，物防固定值，魔防固定值;保留之前的怪
            string gameObjectParameter = skillS.SkillConf.GameObjectParameter;
            string[] summonParList = gameObjectParameter.Split(';');

            int monsterId = 0; 
            float range = 0f; 
            int number = 0;
            try
            {
                monsterId = int.Parse(summonParList[0]);
                range = float.Parse(summonParList[2]);
                number = int.Parse(summonParList[3]);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return;
            }

            List<int> destoryOldMonsterList = new List<int>();
            if (summonParList.Length >= 7)
            {
                string[] monsterids = summonParList[6].Split(",");
                for (int i = 0; i < monsterids.Length; i++)
                {
                    if (!CommonHelp.IfNull(monsterids[i]))
                    {
                        destoryOldMonsterList.Add( int.Parse(monsterids[i]) );
                    }
                }
            }

            if (destoryOldMonsterList.Count > 0)
            {
                List<EntityRef<Unit>> entities = theUnitFrom.GetParent<UnitComponent>().GetAll();
                for (int i = entities.Count - 1; i >= 0; i--)
                {
                    Unit uu = entities[i];
                    if (uu.Type == UnitType.Monster && destoryOldMonsterList.Contains(uu.ConfigId) && uu.GetMasterId() == theUnitFrom.Id)
                    {
                        uu.GetComponent<HeroDataComponentS>().OnDead(null);
                        unitInfoComponent.ZhaohuanIds.Remove(uu.Id);
                    }
                }
            }

            if (number > 100)
            {
                Log.Error($"Skill_Com_Summon_2: {skillS.SkillConf.Id}");
                return;
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

                Unit unitMonster = UnitFactory.CreateMonster(theUnitFrom.Scene(), monsterId, initPosi, new CreateMonsterInfo()
                { Camp = theUnitFrom.GetBattleCamp(), MasterID = theUnitFrom.Id, AttributeParams = summonParList[1] + ";"+ summonParList[4] + ";" + summonParList[5] });
                unitInfoComponent.ZhaohuanIds.Add(unitMonster.Id);
            }

            this.OnUpdate(skillS, 0);
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
