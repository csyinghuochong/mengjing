using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class UISoloQuitEvent : AEvent<Scene, UISoloQuit>
    {
        protected override async ETTask Run(Scene scene, UISoloQuit args)
        {
            scene.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Solo);

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class Solo_SoloReward : AEvent<Scene, UISoloReward>
    {
        protected override async ETTask Run(Scene scene, UISoloReward args)
        {
            // EventType.UISoloReward args = cls as EventType.UISoloReward;
            //
            // UI uisoloReward = UIHelper.GetUI(args.ZoneScene, UIType.UISoloReward);
            // if (uisoloReward == null)
            // {
            //     UI ui = await UIHelper.Create(args.ZoneScene, UIType.UISoloReward);
            //
            //     ui.GetComponent<UISoloRewardComponent>().OnInit(args.m2C_SoloDungeon.SoloResult, args.m2C_SoloDungeon.RewardItem);
            // }

            await ETTask.CompletedTask;
        }
    }
}