namespace ET.Server
{

    [MessageHandler(SceneType.EMail)]
    public class M2E_EMailReceiveHandler : MessageHandler<Scene, M2E_EMailReceiveRequest, E2M_EMailReceiveResponse>
    {

        protected override async ETTask Run(Scene scene, M2E_EMailReceiveRequest request, E2M_EMailReceiveResponse response )
        {
            DBMailInfo dBMailInfo = await UnitCacheHelper.GetComponent<DBMailInfo>(scene.Root(), request.Id);
            for (int i = dBMailInfo.MailInfoList.Count - 1; i >= 0; i--)
            {
                if (dBMailInfo.MailInfoList[i].MailId == request.MailId)
                {
                    MailInfo mailInfo = dBMailInfo.MailInfoList[i];
                    dBMailInfo.MailInfoList.RemoveAt(i);
                    response.MailInfo = mailInfo;
                    break;
                }
            }

            await UnitCacheHelper.SaveComponent(scene.Root(), request.Id,  dBMailInfo);
        }
    }
}
