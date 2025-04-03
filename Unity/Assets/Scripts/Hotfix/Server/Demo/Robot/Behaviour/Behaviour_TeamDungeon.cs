using System;
using ET.Client;

namespace ET
{
    //战场
    public class Behaviour_TeamDungeon : BehaviourHandler
    {
        public override int BehaviourId()
        {
            return BehaviourType.Behaviour_TeamDungeon;
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

            //Console.WriteLine("Behaviour_TeamDungeon");
            while (true)
            {
                //获取队伍列表
                int errorCode = await TeamNetHelper.RequestTeamDungeonList(root, MapTypeEnum.TeamDungeon);
                string messagevalue = aiComponent.Message;
                string[] teamId = messagevalue.Split('_');
                TeamInfo teamInfo = teamComponent.GetTeamInfo(long.Parse(teamId[1]));
                if (teamInfo != null)
                {
                    errorCode = await TeamNetHelper.TeamDungeonApplyRequest(root, teamInfo.TeamId, teamInfo.SceneId, teamInfo.FubenType, teamInfo.PlayerList[0].PlayerLv, true,MapTypeEnum.TeamDungeon);
                }
                if (errorCode != 0)
                {
                    Console.WriteLine($"Behaviour_TeamDungeon: Execute {errorCode}");
                }
                
                // 因为协程可能被中断，任何协程都要传入cancellationToken，判断如果是中断则要返回
                await timerComponent.WaitAsync(20000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    //Console.WriteLine("Behaviour_TeamDungeon.Exit: IsCancel");
                    return;
                }
            }
        }
    }
}
