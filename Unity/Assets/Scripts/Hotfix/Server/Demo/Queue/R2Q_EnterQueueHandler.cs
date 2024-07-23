namespace ET.Server
{

    [MessageHandler(SceneType.Queue)]
    public class R2Q_EnterQueueHandler : MessageHandler<Scene, R2Q_EnterQueue, Q2R_EnterQueue>
    {
        protected override async ETTask Run(Scene scene, R2Q_EnterQueue request, Q2R_EnterQueue response)
        {
            scene.Root().GetComponent<TokenComponent>().Add(request.Account, request.Token, false);
            response.QueueNumber = scene.Root().GetComponent<TokenComponent>().GetTotalNumber() + 1;
            
            await ETTask.CompletedTask;
        }

    }
}
