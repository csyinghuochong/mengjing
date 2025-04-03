namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_PetMatchResultHandler : MessageHandler<Scene, M2C_PetMatchResult>
    {
        protected override async ETTask Run(Scene root, M2C_PetMatchResult message)
        {
            root.GetComponent<BattleMessageComponent>().SoloPiPeiStartTime = 0;
            
            //移除界面
            //发送消息,服务器接受消息
            Log.Debug("收到服务器消息需要传送进竞技场地图....");
            EventSystem.Instance.Publish(root, new PetMatchResult() { m2C_SoloMatch = message });

            await ETTask.CompletedTask;
        }
    }
}
