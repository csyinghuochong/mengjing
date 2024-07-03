namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_CreateDropItemsHandlers: MessageHandler<Scene, M2C_CreateDropItems>
    {
        protected override async ETTask Run(Scene root, M2C_CreateDropItems message)
        {
            for (int i = 0; i < message.Drops.Count; i++)
            {
                UnitFactory.CreateDropItem(root.CurrentScene(), message.Drops[i]);
            }
            
            await ETTask.CompletedTask;
        }
    }
}