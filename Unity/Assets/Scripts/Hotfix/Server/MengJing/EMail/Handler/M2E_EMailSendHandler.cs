using System;

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

                ActorId gateServerId = UnitCacheHelper.GetGateServerId(scene.Zone());
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse = (G2T_GateUnitInfoResponse)await scene.Root().GetComponent<MessageSender>().Call
                      (gateServerId, new T2G_GateUnitInfoRequest()
                      {
                          UserID = request.Id
                      });

                //在线直接推送
                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    M2C_UpdateMailInfo m2C_HorseNoticeInfo = new M2C_UpdateMailInfo();
                    MapMessageHelper.SendToClient( scene.Root(), g2M_UpdateUnitResponse.SessionInstanceId, m2C_HorseNoticeInfo);
                }
                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.None)
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
