using System;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Robot_OnUnitRevive: AEvent<Scene, UnitRevive>
    {
        protected override async ETTask Run(Scene root, UnitRevive args)
        {
            Unit unit = args.Unit;

            long InstanceId = unit.InstanceId;
            if (unit.MainHero && unit.IsSelfRobot())
            {
                MapComponent mapComponent = root.GetComponent<MapComponent>();
                root.GetComponent<BehaviourComponent>().Stop();
                switch (mapComponent.SceneType)
                {
                    case SceneTypeEnum.Battle:
                    case SceneTypeEnum.TeamDungeon:
                    case SceneTypeEnum.BaoZang:
                    case SceneTypeEnum.MiJing:
                        root.GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_Target);
                        root.GetComponent<BehaviourComponent>().Start();
                        break;
                    case SceneTypeEnum.DragonDungeon:
                        Console .WriteLine("地下城机器人复活！");
                        root.GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_Target);
                        root.GetComponent<BehaviourComponent>().Start();
                        break;
                    case SceneTypeEnum.Arena:
                        //发消息移除该rbobot
                        break;
                    case SceneTypeEnum.Demon:
                        Console .WriteLine("恶魔活动机器人复活！");
                        break;
                    case SceneTypeEnum.RunRace:
                        Console .WriteLine("恶魔活动机器人复活！");
                        break;
                    default:
                       
                        break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}