namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class OneChallenge_OnApply : AEvent<Scene, UIOneChallenge>
    {
        protected override async ETTask Run(Scene scene, UIOneChallenge args)
        {
            if (args.m2C_OneChallenge.Operatate == 1)
            {
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(scene, "挑战", zstring.Format("{0}向你发起挑战，是否接受?", args.m2C_OneChallenge.OtherName),
                        () => { RunAsync(scene, args).Coroutine(); }, null).Coroutine();
                }
            }

            if (args.m2C_OneChallenge.Operatate == 2)
            {
                MapComponent mapComponent = scene.GetComponent<MapComponent>();
                if (mapComponent.MapType != MapTypeEnum.MainCityScene)
                {
                    return;
                }

                int sceneId = BattleHelper.GetSceneIdByType(MapTypeEnum.OneChallenge);
                EnterMapHelper.RequestTransfer(scene, MapTypeEnum.OneChallenge, sceneId, 0, args.m2C_OneChallenge.OtherId.ToString()).Coroutine();
            }

            await ETTask.CompletedTask;
        }

        private async ETTask RunAsync(Scene root, UIOneChallenge args)
        {
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.MapType != MapTypeEnum.MainCityScene)
            {
                return;
            }

            await FriendNetHelper.OneChallengeRequest(root, 2, args.m2C_OneChallenge.OtherId);
        }
    }
}