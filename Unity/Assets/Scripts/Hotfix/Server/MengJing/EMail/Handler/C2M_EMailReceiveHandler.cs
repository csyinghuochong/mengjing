using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_EMailReceiveHandler : MessageLocationHandler<Unit, C2M_ReceiveMailRequest, M2C_ReceiveMailResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ReceiveMailRequest request, M2C_ReceiveMailResponse response)
        {
            //领取邮件
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Received, unit.Id))
            {
                ActorId mailServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "EMail").ActorId;
                M2E_EMailReceiveRequest M2E_EMailReceiveRequest = M2E_EMailReceiveRequest.Create();
                M2E_EMailReceiveRequest.Id = unit.GetComponent<UserInfoComponentS>().UserInfo.UserId;
                M2E_EMailReceiveRequest.MailId = request.MailId;
                E2M_EMailReceiveResponse g_SendChatRequest = (E2M_EMailReceiveResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (mailServerId,M2E_EMailReceiveRequest);

                MailInfo mailInfo = g_SendChatRequest.MailInfo;
                if (mailInfo == null)
                {
                    return;
                }

                for (int i = mailInfo.ItemList.Count - 1; i >= 0; i--)
                {
                    if (mailInfo.ItemList[i].ItemID == 110000164)

                    {
                        mailInfo.ItemList[i].ItemID = 10000164;
                    }
                    if (!string.IsNullOrEmpty(mailInfo.ItemList[i].GetWay))
                    {
                        unit.GetComponent<BagComponentS>().OnAddItemData(mailInfo.ItemList[i], mailInfo.ItemList[i].GetWay);
                    }
                    else
                    {
                        unit.GetComponent<BagComponentS>().OnAddItemData(mailInfo.ItemList[i], $"{ItemGetWay.ReceieMail}_{TimeHelper.ServerNow()}");
                    }
                }
                
                if (mailInfo != null && mailInfo.ItemSell != null)
                {
                    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(mailInfo.ItemSell.ItemID);
                    if (itemConfig.ItemType == 3)
                    {
                        unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.PaiMaiSellNumber_218, 0, 1);
                    }
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
