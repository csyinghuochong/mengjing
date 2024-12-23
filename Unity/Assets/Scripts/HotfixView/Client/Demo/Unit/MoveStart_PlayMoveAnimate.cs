using UnityEngine;

namespace ET.Client
{
    
    [Event(SceneType.Current)]
    public class MoveStart_PlayMoveAnimate: AEvent<Scene, MoveStart>
    {
        protected override async ETTask Run(Scene scene, MoveStart args)
        { 
            Unit unit = args.Unit;
            
            StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
            if (stateComponent.StateTypeGet(StateTypeEnum.BePulled)
                || stateComponent.StateTypeGet(StateTypeEnum.JiTui))
            {
                return;
            }
            
            if (unit.GetComponent<SkillManagerComponentC>().HaveChongJi())
            {
                return;
            }
            
            unit.GetComponent<FsmComponent>()?.ChangeState(FsmStateEnum.FsmRunState);
            unit.GetComponent<HeroTransformComponent>()?.ShowRunEffect();
            
            await ETTask.CompletedTask;
        }
    }
    
}