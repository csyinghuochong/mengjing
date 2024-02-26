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
                c2GEnterMap.UnitId = root.GetComponent<PlayerComponent>().CurrentRoleId;

                G2C_EnterMap g2CEnterMap = await root.GetComponent<ClientSenderCompnent>().Call(c2GEnterMap) as G2C_EnterMap;

                root.GetComponent<PlayerComponent>().MyId = c2GEnterMap.UnitId;

                // 等待场景切换完成
                await root.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();

                await BagClientHelper.RequestBagInit(root);
                await ActivityNetHelper.RequestActivityInfo(root);

                EventSystem.Instance.Publish(root, new EnterMapFinish());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
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