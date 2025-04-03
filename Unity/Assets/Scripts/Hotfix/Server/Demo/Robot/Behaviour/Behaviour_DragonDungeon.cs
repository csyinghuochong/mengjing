using System;
using ET.Server;
using ET.Client;

namespace ET
{
    //战场
    public class Behaviour_DragonDungeon : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_DragonDungeon;
        }

        public override bool Check(BehaviourComponent aiComponent, AIConfig aiConfig)
        {
            return aiComponent.NewBehaviour == BehaviourId();
        }

        public override async ETTask Execute(BehaviourComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Scene root = aiComponent.Root();
            TimerComponent timerComponent = root.GetComponent<TimerComponent>();
            TeamComponentC teamComponent = root.GetComponent<TeamComponentC>();

            Console.WriteLine("Behaviour_DragonDungeon");
            int errorCode = ErrorCode.ERR_TeamDungeonWait;
            while (true)
            {
                //获取队伍列表
                await TeamNetHelper.RequestTeamDungeonList(root, MapTypeEnum.DragonDungeon);
                string messagevalue = aiComponent.Message;
                string[] teamId = messagevalue.Split('_');

                if (errorCode != ErrorCode.ERR_Success)
                {
                    TeamInfo teamInfo = teamComponent.GetTeamInfo(long.Parse(teamId[1]));
                    if (teamInfo != null)
                    {
                        errorCode = await TeamNetHelper.TeamDungeonApplyRequest(root, teamInfo.TeamId, teamInfo.SceneId, teamInfo.FubenType, teamInfo.PlayerList[0].PlayerLv, true,MapTypeEnum.DragonDungeon);
                    }
                    else
                    {
                        Console.WriteLine("Behaviour_DragonDungeon  teamInfo == null");
                    }
                
                    Console.WriteLine($"Behaviour_DragonDungeon: Execute {errorCode}");
                }
                
                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(TimeHelper.Minute, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    //Console.WriteLine("Behaviour_TeamDungeon.Exit: IsCancel");
                    return;
                }
                else
                {
                    ActorId roborActorId = UnitCacheHelper.GetRobotServerId();
                    Main2RobotManager_Message main2RobotClientMessage = Main2RobotManager_Message.Create();
                    main2RobotClientMessage.OpType = 1;
                    main2RobotClientMessage.OpParam = root.Fiber.Id.ToString();
                    RobotManager2Main_Message respone =
                            await root.GetComponent<ProcessInnerSender>().Call(roborActorId, main2RobotClientMessage) as
                                    RobotManager2Main_Message;
                }
            }
        }
    }
}
