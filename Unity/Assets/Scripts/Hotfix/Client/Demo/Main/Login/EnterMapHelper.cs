using System;


namespace ET.Client
{
    public static partial class EnterMapHelper
    {
        public static async ETTask EnterMapAsync(Scene root)
        {
            try
            {
                C2G_EnterMap c2GEnterMap = new C2G_EnterMap();
                
                
                G2C_EnterMap g2CEnterMap = await root.GetComponent<ClientSenderCompnent>().Call(c2GEnterMap) as G2C_EnterMap;
                
                // 等待场景切换完成
                await root.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();

                await BagClientHelper.RequestBagInit(root);

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

        public static async RequestCreateRole(Scene root, long accountId,  int occ, string name)
        {

            C2A_CreateRoleData c2ACreateRoleData = new C2A_CreateRoleData() { AccountId = accountId, CreateOcc = occ, CreateName = name };

        }
    }
}