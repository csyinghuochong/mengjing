using System;

namespace ET.Client
{
    [FriendOf(typeof (PlayerComponent))]
    public static partial class EnterMapHelper
    {
        public static async ETTask EnterMapAsync(Scene root)
        {
            try
            {
                C2G_EnterMap c2GEnterMap = new C2G_EnterMap();
                c2GEnterMap.AccountId =  root.GetComponent<PlayerComponent>().AccountId;
                c2GEnterMap.UnitId = root.GetComponent<PlayerComponent>().CurrentRoleId;

                G2C_EnterMap g2CEnterMap = await root.GetComponent<ClientSenderCompnent>().Call(c2GEnterMap) as G2C_EnterMap;

                root.GetComponent<PlayerComponent>().MyId = c2GEnterMap.UnitId;

                // 等待场景切换完成
                await root.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();

                await UserInfoNetHelper.RequestUserInfoInit(root);
                await BagClientNetHelper.RequestBagInit(root);
                await PetNetHelper.RequestPetInfo(root);
                await TaskClientNetHelper.RequestTaskInit(root);
                await SkillNetHelper.RequestSkillSet(root);
                await FriendNetHelper.RequestFriendInfo(root);
                await ActivityNetHelper.RequestActivityInfo(root);
                
                
                EventSystem.Instance.Publish(root, new EnterMapFinish());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

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
                return ErrorCode.ERR_RequestExitFuben;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(root);
            if (unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.Now_Stall) > 0)
            {
                return ErrorCode.ERR_RequestExitFuben;
            }

            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            if (SceneConfigHelper.UseSceneConfig(newsceneType) && sceneId > 0)
            {
                SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
                if (sceneConfig.DayEnterNum > 0 && sceneConfig.DayEnterNum <= userInfoComponent.GetSceneFubenTimes(sceneId))
                {
                    return ErrorCode.ERR_TimesIsNot;
                }
                if (sceneConfig.EnterLv > userInfoComponent.GetUserLv())
                {
                    return ErrorCode.ERR_LevelIsNot;
                }
            }
            if (DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(sceneId))
            {
                root.GetComponent<BattleMessageComponent>().SetLastDungeonId(mapComponent.SceneId);
            }
            else
            {
                root.GetComponent<BattleMessageComponent>().SetLastDungeonId(0);
            }
              
            C2M_TransferMap c2M_ItemHuiShouRequest = new C2M_TransferMap()
            { 
                SceneType = newsceneType, SceneId = sceneId,  Difficulty = difficulty, paramInfo = paraminfo
            };
            M2C_TransferMap r2c_roleEquip = (M2C_TransferMap)await root.GetComponent<ClientSenderCompnent>().Call(c2M_ItemHuiShouRequest);
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

        public static async ETTask RequestCreateRole(Scene root, long accountId, int occ, string name)
        {
            Log.Debug("C2A_CreateRoleData.client0");
            C2A_CreateRoleData c2ACreateRoleData = new C2A_CreateRoleData() { AccountId = accountId, CreateOcc = occ, CreateName = name };
            A2C_CreateRoleData a2CCreateRoleData = await root.GetComponent<ClientSenderCompnent>().Call(c2ACreateRoleData) as A2C_CreateRoleData;
            root.GetComponent<PlayerComponent>().CreateRoleList.Add(a2CCreateRoleData.createRoleInfo);
        }

        public static async ETTask RequestDeleteRole(Scene root, long accountId, long userId, CreateRoleInfo createRoleInfo)
        {
            C2A_DeleteRoleData request = new() { AccountId = accountId, UserId = userId };
            A2C_DeleteRoleData response = await root.GetComponent<ClientSenderCompnent>().Call(request) as A2C_DeleteRoleData;
            root.GetComponent<PlayerComponent>().CreateRoleList.Remove(createRoleInfo);
        }
    }
}