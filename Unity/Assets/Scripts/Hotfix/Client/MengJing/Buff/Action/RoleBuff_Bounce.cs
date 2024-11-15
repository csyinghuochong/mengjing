using Unity.Mathematics;

namespace ET.Client
{
    /// <summary>
    /// 无视地形
    /// </summary>
    public class RoleBuff_Bounce : RoleBuff_Base
    {

        public override void OnExecute(BuffC buffc)
        {
            buffc.EffectInstanceId = buffc.PlayBuffEffects();
            buffc.BuffState = BuffState.Running;
            
            buffc.StartPosition = buffc.TheUnitBelongto.Position;
            BuffData buffData =  buffc.BuffData;
            buffData.TargetPostion = buffc.StartPosition + math.up() * (float)buffc.mSkillBuffConf.buffParameterValue;
            buffc.BuffData = buffData;
            ChangePosition(buffc).Coroutine();
        }

        private async ETTask ChangePosition(BuffC buffc)
        { 
            
            //上升 0.3 下降0.2  置空0.5
            float shangsheng = 0.3f;
            float zhikong = 0.5f;
            //float xiajiang = 0.2f;
            while (buffc.BuffState == BuffState.Running) 
            {
                buffc.BaseOnUpdate();
                long leftTime =  buffc.BuffEndTime - TimeHelper.ServerNow() ;
                if (leftTime <= 0)
                {
                    buffc.TheUnitBelongto.Position = buffc.StartPosition;
                    break;
                }

                float progress = 1f  - (float)(leftTime * 1f / buffc.mSkillBuffConf.BuffTime);
                if (progress <= shangsheng)
                {
                    //上升
                    buffc.TheUnitBelongto.Position = buffc.StartPosition + (buffc.BuffData.TargetPostion - buffc.StartPosition) * (progress / shangsheng);
                }
                else if (progress < (shangsheng + zhikong))
                {
                    //do nothing
                }
                else
                {
                    //下降
                    buffc.TheUnitBelongto.Position = buffc.StartPosition + (buffc.BuffData.TargetPostion - buffc.StartPosition) * ((1f - progress) / (shangsheng + zhikong));
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
