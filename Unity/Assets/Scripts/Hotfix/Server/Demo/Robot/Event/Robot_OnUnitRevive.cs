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
                switch (mapComponent.MapType)
                {
                    case MapTypeEnum.Battle:
                    case MapTypeEnum.TeamDungeon:
                    case MapTypeEnum.BaoZang:
                    case MapTypeEnum.MiJing:
                        root.GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_Target);
                        root.GetComponent<BehaviourComponent>().Start();
                        break;
                    case MapTypeEnum.DragonDungeon:
                        Console .WriteLine("地下城机器人复活！");
                        root.GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_Target);
                        root.GetComponent<BehaviourComponent>().Start();
                        break;
                    case MapTypeEnum.Arena:
                        //发消息移除该rbobot
                        break;
                    case MapTypeEnum.Demon:
                        Console .WriteLine("恶魔活动机器人复活！");
                        break;
                    case MapTypeEnum.RunRace:
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