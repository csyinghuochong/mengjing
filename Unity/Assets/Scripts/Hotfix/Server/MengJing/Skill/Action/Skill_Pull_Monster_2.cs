using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 牵引拉怪
    /// </summary>
    public class Skill_Pull_Monster_2 : SkillHandlerS
    {
        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            if (skillS.SkillConf.SkillMoveSpeed == 0f)
            {
                skillS.NowPosition = skillS.TargetPosition;
            }
            else
            {
                skillS.NowPosition = theUnitFrom.Position;
                quaternion rotation = quaternion.Euler(0, math.radians(skillS.SkillInfo.TargetAngle), 0); //按照Z轴旋转30度的Quaterion
                float3 movePosition = math.mul(rotation, new float3(0, 0, 1)) * (skillS.SkillConf.SkillLiveTime * (float)(skillS.SkillConf.SkillMoveSpeed) * 0.001f);
                skillS.TargetPosition = skillS.NowPosition + movePosition;
            }
            OnExecute(skillS);
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            this.OnUpdate(skillS, 0);
        }

        public void UpdatePullPlayer(SkillS skillS)
        {
            List<Unit> players = GetTargetHelpS.GetEnemyUnit(skillS.TheUnitFrom, UnitType.Player, skillS.NowPosition, (float)(2f * skillS.SkillConf.DamgeRange[0]));
            for (int i = players.Count - 1; i >= 0; i--)
            {
                Unit unit = players[i];
                if (unit.Type != UnitType.Player)
                {
                    continue;
                }

                if (skillS.LastHurtTimes.ContainsKey(players[i].Id))
                {
                    continue;
                }
                skillS.LastHurtTimes.Add(players[i].Id, TimeHelper.ServerNow());
                BuffData buffData_2 = new BuffData();
                buffData_2.SkillId = skillS.SkillConf.Id;
                buffData_2.BuffId = 99002001;
                unit.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_2, unit, null);
                unit.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.BePulled);
                players[i].Stop(0);
                players[i].FindPathMoveToAsync(skillS.NowPosition).Coroutine();
            }

            List<long> removeIds = new List<long>();
            foreach ((long uid, long time) in skillS.LastHurtTimes)
            {
                Unit unit = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(uid);
                if (unit == null)
                {
                    removeIds.Add(uid);
                    continue;
                }
              
                if (PositionHelper.Distance2D(unit.Position, skillS.NowPosition) > (float)(2f * skillS.SkillConf.DamgeRange[0]))
                {
                    unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, 99002001);
                    unit.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.BePulled);
                    removeIds.Add(uid);
                    continue;
                }
            }
            for (int i = 0; i < removeIds.Count; i++)
            {
                skillS.LastHurtTimes.Remove(removeIds[i]);
            }
        }

        public void UpdatePullMonster(SkillS skillS)
        {
            List<Unit> monsters = GetTargetHelpS.GetEnemyMonsters(skillS.TheUnitFrom, skillS.NowPosition, (float)(2f *skillS.SkillConf.DamgeRange[0]));
            for (int i = monsters.Count - 1; i >= 0; i--)
            {
                Unit unit = monsters[i];
                AIComponent aIComponent = unit.GetComponent<AIComponent>();
                if (aIComponent == null)
                {
                    continue;
                }
                if (skillS.LastHurtTimes.ContainsKey(monsters[i].Id))
                {
                    continue;
                }

                skillS.LastHurtTimes.Add(monsters[i].Id, TimeHelper.ServerNow());
                BuffData buffData_2 = new BuffData();
                buffData_2.SkillId = skillS.SkillConf.Id;
                buffData_2.BuffId = 99002001;
                unit.GetComponent<BuffManagerComponentS>().BuffFactory(buffData_2, unit, null);
                unit.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.BePulled);
                aIComponent.TargetPoint.Clear();
                aIComponent.TargetPoint.Add(skillS.NowPosition);
                monsters[i].Stop(0);
                aIComponent.AIConfigId = 9;   //牵引AI
            }

            List<long> removeIds = new List<long>();
            foreach((long uid, long time) in skillS.LastHurtTimes)
            {
                Unit unit = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(uid);
                if (unit == null)
                {
                    removeIds.Add(uid);
                    continue;
                }
                AIComponent aIComponent = unit.GetComponent<AIComponent>();
                if (aIComponent == null)
                {
                    removeIds.Add(uid);
                    continue;
                }
                
                if (PositionHelper.Distance2D(unit.Position, skillS.NowPosition) > (float)(2f * skillS.SkillConf.DamgeRange[0]))
                {
                    unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, 99002001);
                    unit.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.BePulled);
                    aIComponent.TargetPoint.Clear();
                    removeIds.Add(uid);
                    continue;
                }
                if (aIComponent.TargetPoint.Count == 0)
                {
                    removeIds.Add(uid);
                    continue;
                }
                //夹角大于20度认为不是直线移动，停止拉怪
                //Vector3 fromVector = this.TargetPosition - unit.Position;
                //Vector3 toVector = this.TargetPosition - this.NowPosition;
                //fromVector = fromVector.normalized;
                //toVector = toVector.normalized;
                //Vector2 v1 = new Vector2() { x = fromVector.x, y = fromVector.z };
                //Vector2 v2 = new Vector2() { x = toVector.x, y = toVector.z };
                //float angle = Mathf.Acos( Vector2.Dot(v1, v2));
                //float angle_1 = Mathf.Rad2Deg(Mathf.Atan2(v1.x, v1.y));
                //float angle_2 = Mathf.Rad2Deg(Mathf.Atan2(v2.x, v2.y));
                //Log.Debug($" angle:  {angle_1} { angle_2}  {angle}");
                aIComponent.TargetPoint[0] = skillS.NowPosition;
            }

            for (int i = 0; i < removeIds.Count; i++)
            { 
                skillS.LastHurtTimes.Remove(removeIds[i]);    
            }
        }

        public void FinishPullUnits(SkillS skillS)
        {
            foreach( (long unitid, long htime) in skillS.LastHurtTimes)
            {
                Unit unit = skillS.TheUnitFrom.GetParent<UnitComponent>().Get(unitid);
                if (unit == null)
                {
                    continue;
                }

                if (unit.Type == UnitType.Monster)
                {
                    AIComponent aIComponent = unit.GetComponent<AIComponent>();
                    if (aIComponent == null)
                    {
                        continue;
                    }
                    unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, 99002001);
                    unit.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.BePulled);
                    aIComponent.TargetPoint.Clear();
                }
                else
                {
                    unit.GetComponent<BuffManagerComponentS>().BuffRemoveByUnit(0, 99002001);
                    unit.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.BePulled);
                }
            }
            skillS.HurtIds.Clear();
            skillS.LastHurtTimes.Clear();
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }
            float3 dir = (skillS.TargetPosition - skillS.NowPosition).normalize();
            float dis = PositionHelper.Distance2D(skillS.NowPosition, skillS.TargetPosition);
            float move = (float)skillS.SkillConf.SkillMoveSpeed * 0.1f;            //服务器0.1秒一帧
            move = math.min(dis, move);
            
            float3 nowposition = skillS.NowPosition + move * dir;
            skillS.NowPosition = new float3(nowposition.x, skillS.TargetPosition.y + 0.5f, nowposition.z);

            this.UpdatePullMonster(skillS);
            if(skillS.SkillConf.GameObjectParameter == "1")
            {
                this.UpdatePullPlayer(skillS);
            }

            skillS.UpdateCheckPoint(skillS.NowPosition);
            skillS.IsExcuteHurt = false;
            skillS.BaseOnUpdate();
            //获取目标与自身的距离是否小于0.5f,小于触发将伤害,销毁自身
            dis = PositionHelper.Distance2D(skillS.NowPosition, skillS.TargetPosition);
            if (skillS.SkillConf.SkillMoveSpeed > 0f && dis < 0.5f)
            {
                skillS.SetSkillState(SkillState.Finished);
            }

            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            this.FinishPullUnits(skillS);
            skillS.Clear();
        }
    }
}
