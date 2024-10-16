using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 前方投掷一个球,球会向前方移动，拖拽敌人
    /// 脚本对应参数【是否冲锋，伤害间隔时间】
    /// 0表示不冲锋，1表示跟随弹道冲锋
    /// </summary>
    public class Skill_ComTargetMove_RangDamge_5: SkillHandlerS
    {
      
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);

            string[] paraminfos = skillS.SkillConf.GameObjectParameter.Split(';');
            skillS.isChonFeng = int.Parse(paraminfos[0]);
            if (paraminfos[1] != "0")
            {
                skillS.SkillTriggerInvelTime = (long)(float.Parse(paraminfos[1]) * 1000);
            }

            skillS.SkillExcuteNum = 1;
            skillS.TargetPosition = skillS.TheUnitFrom.Position;
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            this.CreateBullet(skillS);
            if (TimeHelper.ServerNow() > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }
        }

        public override void OnFinished(SkillS skillS)
        {
            if (skillS.isChonFeng == 1)
            {
                ReSetUnit(skillS, skillS.TheUnitFrom);
            }

            UnitComponent unitComponent = skillS.TheUnitFrom.GetParent<UnitComponent>();
            foreach (long id in skillS.HurtIds)
            {
                Unit unit = unitComponent.Get(id);
                if (unit == null)
                {
                    continue;
                }

                this.ReSetUnit(skillS, unit);
            }

            skillS.Clear();
        }

        public void CreateBullet(SkillS skillS)
        {
            if (TimeHelper.ServerNow() < skillS.SkillExcuteHurtTime)
            {
                return;
            }

            if (skillS.SkillExcuteNum <= 0)
            {
                return;
            }

            skillS.HurtIds.Clear();

            Unit unit = UnitFactory.CreateBullet(skillS.TheUnitFrom.Scene(), skillS.TheUnitFrom.Id, skillS.SkillConf.Id, 0, skillS.TheUnitFrom.Position,
                new CreateMonsterInfo());
            unit.AddComponent<RoleBullet5Componnet>().OnBaseBulletInit(skillS, skillS.TheUnitFrom.Id);
            float3 target = this.GetBulletTargetPoint(skillS, skillS.SkillInfo.TargetAngle);
            unit.BulletMoveToAsync(target).Coroutine();
            skillS.SkillExcuteNum--;
            
            skillS.TargetPosition = skillS.TheUnitFrom.GetComponent<PathfindingComponent>().GetCanChongJiPath(skillS.TheUnitFrom.Position, target);
            if (skillS.isChonFeng == 1)
            {
                this.PushUnit(skillS, skillS.TheUnitFrom);
            }
        }

        public void PushUnit(SkillS skillS, Unit unit)
        {
            unit.GetComponent<StateComponentS>().StateTypeAdd(StateTypeEnum.BePulled);
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            float oldSpeed = numericComponent.GetAsFloat(NumericType.Now_Speed);
            float oldspeedAdd = numericComponent.GetAsFloat(NumericType.Extra_Buff_Speed_Add);
            double addPro = (double)numericComponent.GetAsInt(NumericType.Now_JumpDisAdd) / 10;
            float newSpeed = (float)(skillS.SkillConf.SkillMoveSpeed * (1 + addPro));
            float newspeedAdd = newSpeed - oldSpeed;

            if (newSpeed > oldSpeed && newspeedAdd > oldspeedAdd)
            {
                skillS.SpeedAddValue = newspeedAdd - oldspeedAdd;
                numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Add, newspeedAdd);
            }
            else
            {
                skillS.SpeedAddValue = 0f;
            }

            unit.GetComponent<StateComponentS>().SetRigidityEndTime(0);
            unit.FindPathMoveToAsync(skillS.TargetPosition).Coroutine();
        }

        public void ReSetPush(SkillS skillS,  Unit unit)
        {
            unit.GetComponent<StateComponentS>().SetRigidityEndTime(0);
            unit.FindPathMoveToAsync(skillS.TargetPosition).Coroutine();
        }

        public void ReSetUnit(SkillS skillS, Unit unit)
        {
            unit.GetComponent<StateComponentS>().StateTypeRemove(StateTypeEnum.BePulled);
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            float curspeedAdd = numericComponent.GetAsFloat(NumericType.Extra_Buff_Speed_Add) - skillS.SpeedAddValue;
            numericComponent.ApplyValue(NumericType.Extra_Buff_Speed_Add, math.max(0, curspeedAdd));
        }

        public float3 GetBulletTargetPoint(SkillS skillS, int angle)
        {
            float3 sourcePoint = skillS.TheUnitFrom.Position;
            quaternion rotation = quaternion.Euler(0, math.radians(angle), 0);
            float3 TargetPoint = sourcePoint + math.mul(rotation , new float3(0,0,1)) * skillS.SkillConf.SkillLiveTime * (float)skillS.SkillConf.SkillMoveSpeed * 0.001f;
            return TargetPoint;
        }
    }
}