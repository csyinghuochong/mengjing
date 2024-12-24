using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{

    /// <summary>
    /// 全地图随机子弹
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_4 : SkillHandlerS
    {
        
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();

            string[] paraminfos = skillS.SkillConf.GameObjectParameter.Split('@');
            List<float3> vector3s = new List<float3>();
            for (int i = 0; i < paraminfos.Length; i++)
            {
                string[] posinfo = paraminfos[i].Split(';');
                vector3s.Add(new float3(float.Parse(posinfo[0]), float.Parse(posinfo[1]), float.Parse(posinfo[2])));
            }
            int startindex = RandomHelper.RandomNumber(0, vector3s.Count);
            float3 startpos = vector3s[startindex];

            vector3s.RemoveAt(startindex);

            int endindex = RandomHelper.RandomNumber(0, vector3s.Count);
            float3 targetpos = vector3s[endindex];

            //创建一个Unit添加子弹组件向目标点移动
            Unit unit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.TheUnitFrom.Id, skillS.SkillConf.Id, 0, startpos, new CreateMonsterInfo());
            unit.AddComponent<RoleBullet1Componet>().OnBaseBulletInit(skillS, skillS.TheUnitFrom.Id);
            unit.BulletMoveToAsync(targetpos).Coroutine();

            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int uopdateMode)
        {
            if (TimeHelper.ServerNow() > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}
