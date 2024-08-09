namespace ET.Server
{

    [MessageHandler(SceneType.Queue)]
    public class G2Q_ExitGameHandler : MessageHandler<Scene, G2Q_ExitGame, Q2G_ExitGame>
    {
        protected override async ETTask Run(Scene scene, G2Q_ExitGame request, Q2G_ExitGame response)
        {

            await ETTask.CompletedTask;
        }

    }
}
