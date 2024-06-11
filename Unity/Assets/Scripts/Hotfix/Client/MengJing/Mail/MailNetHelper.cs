using System;
using System.Collections.Generic;

namespace ET.Client
{
    public static class MailNetHelper
    {
        public static async ETTask<E2C_GetAllMailResponse> SendGetMailList(Scene root)
        {
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            C2E_GetAllMailRequest request = new() { ActorId = userInfo.UserId };
            E2C_GetAllMailResponse response = (E2C_GetAllMailResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<MailComponentC>().MailInfoList = response.MailInfos;

            EventSystem.Instance.Publish(root, new DataUpdate_OnMailUpdate());
            return response;
        }

        public static async ETTask<int> SendReceiveMail(Scene root)
        {
            MailComponentC mailComponent = root.GetComponent<MailComponentC>();
            if (mailComponent.SelectMail == null)
            {
                return ErrorCode.ERR_NetWorkError;
            }

            int needcell = 1;
            for (int i = 0; i < mailComponent.SelectMail.ItemList.Count; i++)
            {
                BagInfo bagInfo = mailComponent.SelectMail.ItemList[i];
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (itemConfig.ItemPileSum == 999999)
                {
                    continue;
                }

                needcell += (int)Math.Ceiling(bagInfo.ItemNum * 1f / itemConfig.ItemPileSum);
            }

            if (root.GetComponent<BagComponentC>().GetBagLeftCell() < needcell)
            {
                return ErrorCode.ERR_BagIsFull;
            }

            C2M_ReceiveMailRequest request = new() { MailId = mailComponent.SelectMail.MailId };
            M2C_ReceiveMailResponse response = (M2C_ReceiveMailResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != 0)
            {
                return response.Error;
            }

            for (int i = mailComponent.MailInfoList.Count - 1; i >= 0; i--)
            {
                if (mailComponent.MailInfoList[i].MailId == mailComponent.SelectMail.MailId)
                {
                    mailComponent.MailInfoList.RemoveAt(i);
                }
            }

            EventSystem.Instance.Publish(root, new DataUpdate_OnMailUpdate());
            return ErrorCode.ERR_Success;
        }
    }
}