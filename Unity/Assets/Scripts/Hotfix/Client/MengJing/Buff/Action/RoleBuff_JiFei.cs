using Unity.Mathematics;

namespace ET.Client
{
    /// <summary>
    /// 无视地形
    /// </summary>
    public class RoleBuff_JiFei : RoleBuff_Base
    {

        public override void OnExecute(BuffC buffc)
        {
            buffc.EffectInstanceId = buffc.PlayBuffEffects();
            buffc.BuffState = BuffState.Running;
            ChangePosition(buffc).Coroutine();
        }

        private async ETTask ChangePosition(BuffC buffc)
        { 
            while (buffc.BuffState == BuffState.Running) 
            {
                buffc.BaseOnUpdate();
                float leftTime = buffc.mSkillBuffConf.buffParameterType * 0.001f - buffc.PassTime;
                if (leftTime <= 0f)
                {
                    buffc.TheUnitBelongto.Position = buffc.BuffData.TargetPostion;
                    break;
                }
                else
                {
                    buffc.TheUnitBelongto.Position = buffc.StartPosition + (buffc.BuffData.TargetPostion - buffc.StartPosition).normalize() * (float)buffc.mSkillBuffConf.buffParameterValue * buffc.PassTime;
                }
                await  buffc.Root().GetComponent<TimerComponent>().WaitFrameAsync();
                if (buffc.BuffState != BuffState.Running)
                {
                    break;
                }
            }
        }
    }
}
