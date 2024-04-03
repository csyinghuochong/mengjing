using UnityEngine;

namespace ET.Client
{
    
    [Event(SceneType.Current)]
    public class MoveStop_PlayIdleAnimate: AEvent<Scene, MoveStop>
    {
        protected override async ETTask Run(Scene scene, MoveStop args)
        { 
            Unit unit = args.Unit;
            int unitType = unit.Type;
            
            Log.Debug(($"MoveStop_PlayIdleAnimate : {unitType}"));
            
            if (unitType == UnitType.Player && unit.GetComponent<StateComponentC>().ObstructStatus == 1)
            {
                args.Unit.GetComponent<StateComponentC>().ObstructStatus = 0;
            }
            else
            {
                args.Unit.GetComponent<FsmComponent>().ChangeState(FsmStateEnum.FsmIdleState);
            }

            //播放移动特效
            HeroTransformComponent heroTransformComponent = unit.GetComponent<HeroTransformComponent>();
            if (heroTransformComponent!=null && heroTransformComponent.RunEffect != null)
            {
                heroTransformComponent.RunEffect.SetActive(false);
                heroTransformComponent.RunEffect.GetComponent<ParticleSystem>().Stop();
            }
            await ETTask.CompletedTask;
        }
    }
    
}