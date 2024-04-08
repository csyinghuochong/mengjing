﻿using System.Collections.Generic;
namespace ET.Server
{
    //牵引拉怪
    public class Skill_Pull_Monster_2 : SkillHandlerS
    {
        //初始化
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);

            if (this.SkillConf.SkillMoveSpeed == 0f)
            {
                this.NowPosition = this.TargetPosition;
            }
            else
            {
                this.NowPosition = theUnitFrom.Position;
                Quaternion rotation = Quaternion.Euler(0, skillId.TargetAngle, 0); //按照Z轴旋转30度的Quaterion
                Vector3 movePosition = rotation * Vector3.forward * (this.SkillConf.SkillLiveTime * (float)(this.SkillConf.SkillMoveSpeed) * 0.001f);
                this.TargetPosition = this.NowPosition + movePosition;
            }
            OnExecute();
        }

        public override void OnExecute(SkillS skillS)
        {
            this.InitSelfBuff();
            this.OnUpdate();
        }

        public void UpdatePullPlayer()
        {
            List<Unit> players = AIHelp.GetEnemyUnit(this.TheUnitFrom, UnitType.Player, this.NowPosition, (float)(2f * this.SkillConf.DamgeRange[0]));
            for (int i = players.Count - 1; i >= 0; i--)
            {
                Unit unit = players[i];
                if (unit.Type != UnitType.Player)
                {
                    continue;
                }

                if (this.LastHurtTimes.ContainsKey(players[i].Id))
                {
                    continue;
                }
                this.LastHurtTimes.Add(players[i].Id, TimeHelper.ServerNow());
                BuffData buffData_2 = new BuffData();
                buffData_2.SkillId = this.SkillConf.Id;
                buffData_2.BuffId = 99002001;
                unit.GetComponent<BuffManagerComponent>().BuffFactory(buffData_2, unit, null);
                unit.GetComponent<StateComponent>().StateTypeAdd(StateTypeEnum.BePulled);
                players[i].Stop(0);
                players[i].FindPathMoveToAsync(this.NowPosition, null, false).Coroutine();
            }

            List<long> removeIds = new List<long>();
            foreach ((long uid, long time) in this.LastHurtTimes)
            {
                Unit unit = this.TheUnitFrom.GetParent<UnitComponent>().Get(uid);
                if (unit == null)
                {
                    removeIds.Add(uid);
                    continue;
                }
              
                if (Vector3.Distance(unit.Position, this.NowPosition) > (float)(2f * this.SkillConf.DamgeRange[0]))
                {
                    unit.GetComponent<BuffManagerComponent>().BuffRemoveByUnit(0, 99002001);
                    unit.GetComponent<StateComponent>().StateTypeRemove(StateTypeEnum.BePulled);
                    removeIds.Add(uid);
                    continue;
                }
            }
            for (int i = 0; i < removeIds.Count; i++)
            {
                this.LastHurtTimes.Remove(removeIds[i]);
            }
        }

        public void UpdatePullMonster()
        {
            List<Unit> monsters = AIHelp.GetEnemyMonsters(this.TheUnitFrom, this.NowPosition, (float)(2f *this.SkillConf.DamgeRange[0]));
            for (int i = monsters.Count - 1; i >= 0; i--)
            {
                Unit unit = monsters[i];
                AIComponent aIComponent = unit.GetComponent<AIComponent>();
                if (aIComponent == null)
                {
                    continue;
                }
                if (this.LastHurtTimes.ContainsKey(monsters[i].Id))
                {
                    continue;
                }

                this.LastHurtTimes.Add(monsters[i].Id, TimeHelper.ServerNow());
                BuffData buffData_2 = new BuffData();
                buffData_2.SkillId = this.SkillConf.Id;
                buffData_2.BuffId = 99002001;
                unit.GetComponent<BuffManagerComponent>().BuffFactory(buffData_2, unit, null);
                unit.GetComponent<StateComponent>().StateTypeAdd(StateTypeEnum.BePulled);
                aIComponent.TargetPoint.Clear();
                aIComponent.TargetPoint.Add(this.NowPosition);
                monsters[i].Stop(0);
                aIComponent.AIConfigId = 9;   //牵引AI
            }

            List<long> removeIds = new List<long>();
            foreach((long uid, long time) in this.LastHurtTimes)
            {
                Unit unit = this.TheUnitFrom.GetParent<UnitComponent>().Get(uid);
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
                
                if (Vector3.Distance(unit.Position, this.NowPosition) > (float)(2f * this.SkillConf.DamgeRange[0]))
                {
                    unit.GetComponent<BuffManagerComponent>().BuffRemoveByUnit(0, 99002001);
                    unit.GetComponent<StateComponent>().StateTypeRemove(StateTypeEnum.BePulled);
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
                aIComponent.TargetPoint[0] = this.NowPosition;
            }

            for (int i = 0; i < removeIds.Count; i++)
            { 
                this.LastHurtTimes.Remove(removeIds[i]);    
            }
        }

        public void FinishPullUnits()
        {
            foreach( (long unitid, long htime) in this.LastHurtTimes)
            {
                Unit unit = this.TheUnitFrom.GetParent<UnitComponent>().Get(unitid);
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
                    unit.GetComponent<BuffManagerComponent>().BuffRemoveByUnit(0, 99002001);
                    unit.GetComponent<StateComponent>().StateTypeRemove(StateTypeEnum.BePulled);
                    aIComponent.TargetPoint.Clear();
                }
                else
                {
                    unit.GetComponent<BuffManagerComponent>().BuffRemoveByUnit(0, 99002001);
                    unit.GetComponent<StateComponent>().StateTypeRemove(StateTypeEnum.BePulled);
                }
            }
            this.HurtIds.Clear();
            this.LastHurtTimes.Clear();
        }

        public override void OnUpdate(SkillS skillS)
        {
            long serverNow = TimeHelper.ServerNow();
            //根据技能效果延迟触发伤害
            if (serverNow < this.SkillExcuteHurtTime)
            {
                return;
            }
            Vector3 dir = (this.TargetPosition - NowPosition).normalized;
            float dis = PositionHelper.Distance2D(NowPosition, this.TargetPosition);
            float move = (float)this.SkillConf.SkillMoveSpeed * 0.1f;            //服务器0.1秒一帧
            move = Mathf.Min(dis, move);
            this.NowPosition = this.NowPosition + move * dir;
            this.NowPosition.y = this.TargetPosition.y + 0.5f;

            this.UpdatePullMonster();
            if(this.SkillConf.GameObjectParameter == "1")
            {
                this.UpdatePullPlayer();
            }

            this.UpdateCheckPoint(this.NowPosition);
            this.IsExcuteHurt = false;
            this.BaseOnUpdate();
            //获取目标与自身的距离是否小于0.5f,小于触发将伤害,销毁自身
            dis = PositionHelper.Distance2D(NowPosition, this.TargetPosition);
            if (this.SkillConf.SkillMoveSpeed > 0f && dis < 0.5f)
            {
                this.SetSkillState(SkillState.Finished);
            }

            this.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            this.FinishPullUnits();
            this.Clear();
        }
    }
}
