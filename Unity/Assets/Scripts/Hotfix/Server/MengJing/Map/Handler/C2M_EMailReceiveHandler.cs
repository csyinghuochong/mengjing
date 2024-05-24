﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace ET
{

    [ActorMessageHandler]
    public class C2M_EMailReceiveHandler : AMActorLocationRpcHandler<Unit, C2M_ReceiveMailRequest, M2C_ReceiveMailResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ReceiveMailRequest request, M2C_ReceiveMailResponse response, Action reply)
        {
            //领取邮件
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.Received, unit.Id))
            {
                long mailServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), Enum.GetName(SceneType.EMail)).InstanceId;
                E2M_EMailReceiveResponse g_SendChatRequest = (E2M_EMailReceiveResponse)await ActorMessageSenderComponent.Instance.Call
                    (mailServerId, new M2E_EMailReceiveRequest() { Id = unit.GetComponent<UserInfoComponent>().UserInfo.UserId, MailId = request.MailId });

                MailInfo mailInfo = g_SendChatRequest.MailInfo;
                if (mailInfo == null)
                {
                    reply();
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
                        unit.GetComponent<BagComponent>().OnAddItemData(mailInfo.ItemList[i], mailInfo.ItemList[i].GetWay);
                        //string[] getwayInfo = mailInfo.ItemList[i].GetWay.Split('_');
                        //if (getwayInfo.Length >= 2 && mailInfo.ItemList[i].ItemID == 1 && int.Parse(getwayInfo[0]) == ItemGetWay.PaiMaiSell)
                        //{
                        //    unit.GetComponent<DataCollationComponent>().UpdateBuySelfPlayerList(mailInfo.ItemList[i].ItemNum, mailInfo.BuyPlayerId );
                        //}
                    }
                    else
                    {
                        unit.GetComponent<BagComponent>().OnAddItemData(mailInfo.ItemList[i], $"{ItemGetWay.ReceieMail}_{TimeHelper.ServerNow()}");
                    }
                }
                
                if (mailInfo != null && mailInfo.ItemSell != null)
                {
                    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(mailInfo.ItemSell.ItemID);
                    if (itemConfig.ItemType == 3)
                    {
                        unit.GetComponent<ChengJiuComponent>().TriggerEvent(ChengJiuTargetEnum.PaiMaiSellNumber_218, 0, 1);
                    }
                }
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
