using System;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class Robot_OnSceneChangeFinish : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            TimerComponent timerComponent = scene.Root().GetComponent<TimerComponent>();

            //0   测试机器人
            //1   任务机器人
            //2   组队副本机器人
            //3   战场机器人
            //4   世界boos机器人
            //5   角斗场机器人
            //6   solo场机器人
            //7   副本机器人
            //8   塔防机器人
            //9   奔跑大赛机器人
            //10  恶魔活动机器人
            //11  龙与地下城机器人
            //12  宠物挑战赛机器人
            BehaviourComponent behaviourComponent = scene.Root().GetComponent<BehaviourComponent>();
            if (behaviourComponent == null)
            {
                return;
            }
            
            if (args.SceneType == MapTypeEnum.MainCityScene)
            {
                behaviourComponent.InitBehaviour();
            }
            
            switch (args.SceneType)
            {
                case MapTypeEnum.Arena:
                case MapTypeEnum.Battle:
                case MapTypeEnum.TeamDungeon:
                case MapTypeEnum.LocalDungeon:
                case MapTypeEnum.DragonDungeon:
                    await timerComponent.WaitAsync(TimeHelper.Second * 5);
                    behaviourComponent.ChangeBehaviour(BehaviourType.Behaviour_Target);
                    break;
                case MapTypeEnum.PetMatch:
                    await timerComponent.WaitAsync(TimeHelper.Second * 5);
                    behaviourComponent.ChangeBehaviour(BehaviourType.Behaviour_PetMatchFight);
                    break;
                default:
                    break;
            }
            
            await ETTask.CompletedTask;
        }
    }
}