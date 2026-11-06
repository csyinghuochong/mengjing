using System;
using System.Globalization;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(BuffManagerComponentS))]
    [FriendOf(typeof(BuffS))]
    public class Skill_TornadoStorm : SkillHandlerS
    {
        // 参数：生成点周围活动半径（米）；同目标伤害间隔（秒）。
        private static float[] Parameters(SkillConfig config)
        {
            string[] parts = config.GameObjectParameter.Split(';');
            if (parts.Length != 2) throw new ArgumentException("龙卷风暴参数：活动半径;伤害间隔秒数");
            float radius = float.Parse(parts[0], CultureInfo.InvariantCulture);
            float interval = float.Parse(parts[1], CultureInfo.InvariantCulture);
            if (!float.IsFinite(radius) || !float.IsFinite(interval) || radius <= 0 || interval < 0.1f
                || config.SkillMoveSpeed <= 0 || config.DamgeRangeType != 1)
                throw new ArgumentException("龙卷风暴活动半径、伤害间隔、速度或圆形伤害范围无效。");
            return new[] { radius, interval };
        }

        public override void OnInit(SkillS skill, Unit caster)
        {
            skill.BaseOnInit(skill.SkillInfo, caster);
            float[] p = Parameters(skill.SkillConf);
            skill.SkillTriggerInvelTime = (long)(p[1] * 1000);
            skill.NowPosition = caster.Position;
            skill.BulletUnit = null;
            skill.MoveTime = 0;
            // 此技能的999999表示一直存在，随施法者死亡或技能被清理结束。
            if (skill.SkillConf.SkillLiveTime == 999999) skill.SkillEndTime = long.MaxValue;
        }

        public override void OnExecute(SkillS skill)
        {
            skill.InitSelfBuff();
            OnUpdate(skill, 0);
        }

        public override void OnUpdate(SkillS skill, int updateMode)
        {
            Unit caster = skill.TheUnitFrom;
            long now = TimeHelper.ServerNow();
            if (caster == null || caster.IsDisposed
                || caster.GetComponent<NumericComponentS>().GetAsInt(NumericType.Now_Dead) != 0
                || now >= skill.SkillEndTime)
            {
                skill.SetSkillState(SkillState.Finished);
                return;
            }
            if (now < skill.SkillExcuteHurtTime) return;
            if (skill.BulletUnit == null)
            {
                skill.BulletUnit = UnitFactory.CreateBullet(caster.Scene(), caster.Id, skill.SkillConf.Id, 0,
                        skill.NowPosition, new CreateMonsterInfo());
            }
            Unit tornado = skill.BulletUnit;
            if (tornado.IsDisposed)
            {
                skill.SetSkillState(SkillState.Finished);
                return;
            }
            if (now >= skill.MoveTime) MoveRandomly(skill, tornado, now);
            skill.UpdateCheckPoint(tornado.Position);

            foreach (EntityRef<Unit> reference in caster.GetParent<UnitComponent>().GetAll())
            {
                Unit target = reference;
                if (target == null || target.IsDisposed || target.Id == caster.Id || target.Id == tornado.Id
                    || !target.IsCanBeAttack() || !caster.IsCanAttackUnit(target)
                    || !skill.CheckShape(target.Position)) continue;
                if (skill.LastHurtTimes.TryGetValue(target.Id, out long last)
                    && now - last < skill.SkillTriggerInvelTime) continue;
                skill.LastHurtTimes[target.Id] = now;
                if (skill.TriggeSkillHurt(target, 0)) RefreshContactBuff(skill, target, now);
            }
        }

        private static void MoveRandomly(SkillS skill, Unit tornado, long now)
        {
            float radius = Parameters(skill.SkillConf)[0];
            skill.MoveTime = now + 500;
            for (int attempt = 0; attempt < 8; attempt++)
            {
                float angle = RandomHelper.RandFloat01() * math.PI * 2;
                float distance = math.sqrt(RandomHelper.RandFloat01()) * radius;
                float3 destination = skill.NowPosition + new float3(math.cos(angle) * distance, 0, math.sin(angle) * distance);
                M2C_PathfindingResult path = new();
                tornado.GetComponent<PathfindingComponent>().Find(tornado.Position, destination, path.Points);
                if (path.Points.Count < 2 || math.distance(tornado.Position, path.Points[^1]) < 1) continue;
                float length = 0;
                for (int i = 1; i < path.Points.Count; i++) length += math.distance(path.Points[i - 1], path.Points[i]);
                path.Id = tornado.Id;
                path.SpeedRate = 100;
                MapMessageHelper.Broadcast(tornado, path);
                float speed = (float)skill.SkillConf.SkillMoveSpeed;
                tornado.GetComponent<MoveComponent>().MoveToAsync(path.Points, speed).Coroutine();
                skill.MoveTime = now + math.max(100, (long)(length / speed * 1000));
                return;
            }
        }

        // 接触刷新持续时间，避免每次判伤都删除旧减速，使新图标被旧删除消息清掉。
        private static void RefreshContactBuff(SkillS skill, Unit target, long now)
        {
            BuffManagerComponentS manager = target.GetComponent<BuffManagerComponentS>();
            foreach (int id in skill.SkillConf.BuffID)
            {
                if (id == 0) continue;
                SkillBuffConfig config = SkillBuffConfigCategory.Instance.Get(id);
                BuffS existing = null;
                if (manager != null && config.BuffAddClass == 0 && config.BuffType == 1)
                {
                    foreach (BuffS buff in manager.m_Buffs)
                    {
                        if (buff.mBuffConfig.Id == id && buff.BuffState == BuffState.Running && buff.BuffEndTime > now)
                        {
                            existing = buff;
                            break;
                        }
                    }
                }
                if (existing == null) skill.SkillBuff(id, target);
                else manager.BuffAddSyncTime(math.max(existing.BuffEndTime,
                        now + BuffSSystem.CheckBuffTime(target, config)
                        + 1000 * (int)existing.GetTianfuProAdd((int)BuffAttributeEnum.AddBuffTime)), config);
            }
        }

        public override void OnFinished(SkillS skill)
        {
            Unit tornado = skill.BulletUnit;
            skill.BulletUnit = null;
            if (tornado != null && !tornado.IsDisposed) tornado.GetParent<UnitComponent>().Remove(tornado.Id);
            skill.Clear();
        }
    }
}
