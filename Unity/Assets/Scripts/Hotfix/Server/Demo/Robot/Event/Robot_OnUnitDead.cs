using System;
using System.Collections.Generic;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Robot_OnUnitDead : AEvent<Scene, UnitDead>
    {
        protected override async ETTask Run(Scene root, UnitDead args)
        {
            Unit unit = args.Unit;
            long InstanceId = unit.InstanceId;
            Console .WriteLine($"Robot_OnUnitDead！{unit.MainHero} {unit.Type} { unit.IsSelfRobot()}");
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
                        await root.GetComponent<TimerComponent>().WaitAsync(10000);
                        if (InstanceId != unit.InstanceId)
                        {
                            Log.Debug("InstanceId != unit.InstanceId");
                            return;
                        }
                        
                        EnterMapHelper.SendReviveRequest(root, false).Coroutine();
                        break;
                    case MapTypeEnum.DragonDungeon:
                        Console .WriteLine("地下城机器人死亡！");
                        await root.GetComponent<TimerComponent>().WaitAsync(1000);
                        if (InstanceId != unit.InstanceId)
                        {
                            Log.Debug("InstanceId != unit.InstanceId");
                            return;
                        }
                                                
                        EnterMapHelper.SendReviveRequest(root, false).Coroutine();
                        break;
                    case MapTypeEnum.Arena:
                        await root.GetComponent<TimerComponent>().WaitAsync(20000);
                        //发消息移除该rbobot
                        break;
                    case MapTypeEnum.Demon:
                        Console .WriteLine("恶魔活动机器人死亡！");
                        break;
                    case MapTypeEnum.RunRace:
                        Console .WriteLine("恶魔活动机器人死亡！");
                        break;
                    default:
                        EnterMapHelper.RequestQuitFuben(root);
                        await root.GetComponent<TimerComponent>().WaitAsync(10000);
                        root.GetComponent<BehaviourComponent>().Start();
                        root.GetComponent<BehaviourComponent>().ChangeBehaviour(BehaviourType.Behaviour_Stroll);
                        break;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}