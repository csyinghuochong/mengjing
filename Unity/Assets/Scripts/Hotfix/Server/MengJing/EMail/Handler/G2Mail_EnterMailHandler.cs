namespace ET.Server
{
    [MessageHandler(SceneType.EMail)]
    public class G2Mail_EnterMailHandler : MessageHandler<Scene, G2Mail_EnterMail, Mail2G_EnterMail>
    {
        protected override async ETTask Run(Scene scene, G2Mail_EnterMail request, Mail2G_EnterMail response)
        {
            MailSceneComponent mailScene = scene.GetComponent<MailSceneComponent>();
            if (request.ServerMailIdCur != -1)
            {
                mailScene.OnLogin(request.UnitId, request.ServerMailIdCur).Coroutine();
            }
            response.ServerMailIdMax = mailScene.GetMaxMaild();
            await ETTask.CompletedTask;
        }
    }
}
