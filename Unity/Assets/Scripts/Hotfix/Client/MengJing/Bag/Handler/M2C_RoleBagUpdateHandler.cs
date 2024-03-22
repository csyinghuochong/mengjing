namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_RoleBagUpdateHandler: MessageHandler<Scene, M2C_RoleBagUpdate>
    {
        protected override async ETTask Run(Scene root, M2C_RoleBagUpdate message)
        {
            root.GetComponent<BagComponent_C>().OnRecvBagUpdate(message);
            await ETTask.CompletedTask;
        }
    }
}