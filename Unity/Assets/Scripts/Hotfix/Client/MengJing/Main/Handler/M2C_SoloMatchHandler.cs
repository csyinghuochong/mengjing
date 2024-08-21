namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_SoloMatchHandler : MessageHandler<Scene, M2C_SoloMatchResult>
    {
        protected override async ETTask Run(Scene root, M2C_SoloMatchResult message)
        {
            root.GetComponent<BattleMessageComponent>().SoloPiPeiStartTime = 0;

            //移除界面
            EventSystem.Instance.Publish(root, new UISoloQuit());

            //发送消息,服务器接受消息
            Log.Debug("收到服务器消息需要传送进竞技场地图....");
            EventSystem.Instance.Publish(root, new UISoloEnter() { m2C_SoloMatch = message });

            await ETTask.CompletedTask;
        }
    }
}