using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.EMail)]
    public class M2E_EMailSendHandler: MessageHandler<Scene, M2E_EMailSendRequest, E2M_EMailSendResponse>
    {
        protected override async ETTask Run(Scene scene, M2E_EMailSendRequest request, E2M_EMailSendResponse response)
        {
            //
            
            await ETTask.CompletedTask;
        }
    }
}
