namespace ET.Server
{
    [MessageHandler(SceneType.EMail)]
    public class M2E_EMailSendHandler: MessageHandler<Scene, M2E_EMailSendRequest, E2M_EMailSendResponse>
    {
        protected override async ETTask Run(Scene scene, M2E_EMailSendRequest request, E2M_EMailSendResponse response)
        {
   
            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.EMail, request.Id))
            {

                //存储邮件
                if (request.GetWay == ItemGetWay.RunRace)
                {
                    Log.Warning($"家族争霸赛邮件1: {request.Id}");
                }
                if (request.GetWay == ItemGetWay.MiJingBoss)
                {
                    Log.Warning($"世界BOSS邮件1: {request.Id}");
                }
                response.Error = await MailHelp.SendUserMail(scene.Root(), request.Id, request.MailInfo);

                if (request.GetWay == ItemGetWay.RunRace)
                {
                    Log.Warning($"家族争霸赛邮件2: {response.Error}");
                }
                if (request.GetWay == ItemGetWay.MiJingBoss)
                {
                    Log.Warning($"世界BOSS邮件2: {response.Error}");
                }

                if (response.Error != ErrorCode.ERR_Success)
                {
                    response.Error = response.Error;

                    return;
                }
                
                A2M_GetUnitInfoRequest a2MGetUnitInfoRequest = A2M_GetUnitInfoRequest.Create();
                M2A_GetUnitInfoResponse m2AGetUnitInfoResponse = await scene.Root().GetComponent<MessageLocationSenderComponent>()
                        .Get(LocationType.Unit).Call(request.Id, a2MGetUnitInfoRequest) as M2A_GetUnitInfoResponse;
                
                //在线直接推送
                if (m2AGetUnitInfoResponse.Error == ErrorCode.ERR_Success && m2AGetUnitInfoResponse.PlayerState == (int)PlayerState.Game )
                {
                    M2C_UpdateMailInfo m2C_HorseNoticeInfo = M2C_UpdateMailInfo.Create();
                    MapMessageHelper.SendToClient( scene.Root(), request.Id, m2C_HorseNoticeInfo);
                }
                else
                {
                    ReddotComponentS reddotComponent = await UnitCacheHelper.GetComponentCache<ReddotComponentS>(scene.Root(), request.Id);
                    if (reddotComponent != null)
                    {
                        reddotComponent.AddReddont((int)ReddotType.Email);
                        await UnitCacheHelper.SaveComponentCache(scene.Root(), reddotComponent);
                    }
                }
                
            }
        }

    }
}
