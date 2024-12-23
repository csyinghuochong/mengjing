using Unity.Mathematics;

namespace ET.Server
{
    public class Skill_Other_ChongJi_1 : SkillHandlerS
    {
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            skillS.SkillFirstHurtTime = 0;
            skillS.SpeedAddValue = 0f;
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();

            this.OnUpdate(skillS, 0);
        }

        public void MoveToSync(SkillS skillS)
        {
            NumericComponentS numericComponent = skillS.TheUnitFrom.GetComponent<NumericComponentS>();
            float oldSpeed = numericComponent.GetAsFloat(NumericType.Now_Speed);
            double addPro = (double)numericComponent.GetAsInt(NumericType.Now_JumpDisAdd) / 10;
            float newSpeed = (float)(skillS.SkillConf.SkillMoveSpeed * (1 + addPro));

            int speedRate = 100;
            if (newSpeed > oldSpeed )
            {
                speedRate = (int)(newSpeed * 100f / oldSpeed);
            }
         
            skillS.TheUnitFrom.GetComponent<StateComponentS>().SetRigidityEndTime(0);
            float moveDistance = ((float)skillS.SkillConf.SkillMoveSpeed * skillS.SkillConf.SkillLiveTime * 0.001f);
            quaternion rotation = quaternion.Euler(0, math.radians(skillS.SkillInfo.TargetAngle), 0); //按照Z轴旋转30度的Quaterion
            float3 TargetPosition = skillS.TheUnitFrom.Position + math.mul(rotation, new float3(0, 0, 1)) * moveDistance;
            skillS.TargetPosition = skillS.TheUnitFrom.GetComponent<PathfindingComponent>().GetCanChongJiPath(skillS.TheUnitFrom.Position, TargetPosition);
            
            skillS.TheUnitFrom.FindPathMoveToAsync(skillS.TargetPosition, speedRate).Coroutine();
            skillS.NowPosition = skillS.TheUnitFrom.Position;
            skillS.TheUnitFrom.GetComponent<BuffManagerComponentS>().AddBuffRecord(1, 1);
        }
        
        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            long serverNow = TimeHelper.ServerNow();

            //根据技能效果延迟触发伤害
            if (serverNow < skillS.SkillExcuteHurtTime)
            {
                return;
            }

            //只触发一次，需要多次触发的重写
            if (!skillS.IsExcuteHurt)
            {
                skillS.IsExcuteHurt = true;
                MoveToSync(skillS);
                //MoveToAsync().Coroutine();
            }

            if (serverNow > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }

            if (skillS.ICheckShape.Count > 0)
            {
                //分成五份计算
                float3 oldpos = skillS.NowPosition;
                float3 newpos = skillS.TheUnitFrom.Position;
                float3 inteva = (newpos - oldpos) / 5;

                for (int i = 0; i < 5; i++)
                {
                    skillS.UpdateCheckPoint(oldpos + inteva * (i + 1));
                    skillS.ExcuteSkillAction();
                }
            }

            if (skillS.SkillFirstHurtTime > 0 && skillS.SkillConf.GameObjectParameter == "1")
            {
                skillS.TheUnitFrom.Stop(-2);
                skillS.SetSkillState(SkillState.Finished);
                return;
            }

            skillS.NowPosition = skillS.TheUnitFrom.Position;
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}