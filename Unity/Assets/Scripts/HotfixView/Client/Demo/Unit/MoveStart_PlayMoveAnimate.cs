using UnityEngine;

namespace ET.Client
{
    
    [Event(SceneType.Current)]
    public class MoveStart_PlayMoveAnimate: AEvent<Scene, MoveStart>
    {
        protected override async ETTask Run(Scene scene, MoveStart args)
        { 
            Unit unit = args.Unit;

            if (SettingData.ShowFindPath)
            {
                Transform gameObject = GameObject.Find("Global/FindPath").transform;
                for (int i = 0; i < 10; i++)
                {
                    if (i < args.targes.Count)
                    {
                        gameObject.Find(i.ToString()).transform.localPosition = args.targes[i];
                        gameObject.Find(i.ToString()).gameObject.SetActive(true);
                    }
                    else
                    {
                        gameObject.Find(i.ToString()).gameObject.SetActive(false);
                    }
                }
            }

            StateComponentC stateComponent = unit.GetComponent<StateComponentC>();
            if (stateComponent.StateTypeGet(StateTypeEnum.BePulled)
                || stateComponent.StateTypeGet(StateTypeEnum.JiTui))
            {
                return;
            }
            unit.GetComponent<FsmComponent>()?.ChangeState(FsmStateEnum.FsmRunState);
            unit.GetComponent<HeroTransformComponent>()?.ShowRunEffect();
            
            await ETTask.CompletedTask;
        }
    }
    
}