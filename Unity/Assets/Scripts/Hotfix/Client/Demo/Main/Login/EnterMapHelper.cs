using System;

namespace ET.Client
{
    [FriendOf(typeof (PlayerComponent))]
    public static partial class EnterMapHelper
    {
        public static async ETTask<int> RequestTransfer(Scene root, int newsceneType, int sceneId, int difficulty = FubenDifficulty.None,
        string paraminfo = "0")
        {
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (TimeHelper.ServerNow() - mapComponent.LastQuitTime < 2000)
            {
                return ErrorCode.ERR_OperationOften;
            }

            mapComponent.LastQuitTime = TimeHelper.ServerNow();
            if (!SceneConfigHelper.CanTransfer(mapComponent.SceneType, newsceneType))
            {
                HintHelp.ShowHint(root, "请先退出副本！");
                return ErrorCode.ERR_RequestExitFuben;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            if (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_Stall) > 0)
            {
                HintHelp.ShowHint(root, "请先退出摆摊！");
                return ErrorCode.ERR_RequestExitFuben;
            }

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            if (SceneConfigHelper.UseSceneConfig(newsceneType) && sceneId > 0)
            {
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
                if (sceneConfig.DayEnterNum > 0 && sceneConfig.DayEnterNum <= userInfoComponent.GetSceneFubenTimes(sceneId))
                {
                    HintHelp.ShowHint(root, "次数不足！");
                    return ErrorCode.ERR_TimesIsNot;
                }

                if (sceneConfig.EnterLv > userInfoComponent.GetUserLv())
                {
                    HintHelp.ShowHint(root, $"{sceneConfig.EnterLv}级开启！");
                    return ErrorCode.ERR_LevelIsNot;
                }
            }

            if (DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(sceneId))
            {
                root.GetComponent<BattleMessageComponent>().LastDungeonId = mapComponent.SceneId;
            }
            else
            {
                root.GetComponent<BattleMessageComponent>().LastDungeonId = 0;
            }

            C2M_TransferMap request = new() { SceneType = newsceneType, SceneId = sceneId, Difficulty = difficulty, paramInfo = paraminfo };
            M2C_TransferMap response = (M2C_TransferMap)await root.GetComponent<ClientSenderCompnent>().Call(request);
            userInfoComponent.AddSceneFubenTimes(sceneId);
            return ErrorCode.ERR_Success;
        }

        public static async ETTask Match(Fiber fiber)
        {
            try
            {
                G2C_Match g2CEnterMap = await fiber.Root.GetComponent<ClientSenderCompnent>().Call(new C2G_Match()) as G2C_Match;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void RequestQuitFuben(Scene zoneScene)
        {
            RequestTransfer(zoneScene, (int)SceneTypeEnum.MainCityScene, CommonHelp.MainCityID()).Coroutine();
        }

        public static async ETTask SendReviveRequest(Scene root, bool revive)
        {
            Actor_SendReviveRequest request = new() { Revive = revive };
            Actor_SendReviveResponse response = await root.GetComponent<ClientSenderCompnent>().Call(request) as Actor_SendReviveResponse;
        }
    }
}