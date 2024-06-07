using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_OnMailUpdate_DlgMailRefresh: AEvent<Scene, DataUpdate_OnMailUpdate>
    {
        protected override async ETTask Run(Scene scene, DataUpdate_OnMailUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMail>()?.OnMailUpdate();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof (Scroll_Item_MailItem))]
    [FriendOf(typeof (DlgMail))]
    public static class DlgMailSystem
    {
        public static void RegisterUIEvent(this DlgMail self)
        {
            self.View.E_MailItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMailItemsRefresh);
            self.View.E_ButtonGetButton.AddListener(self.OnButtonGet);
            self.View.E_ButtonOneKeyButton.AddListenerAsync(self.OnButtonOneKey);
        }

        public static void ShowWindow(this DlgMail self, Entity contextData = null)
        {
            self.RequestMaiList();
        }

        public static void RequestMaiList(this DlgMail self)
        {
            MailNetHelper.SendGetMailList(self.Root()).Coroutine();
            // NetHelper.SendReddotRead(self.ZoneScene(), ReddotType.Email).Coroutine();
        }

        public static void OnButtonGet(this DlgMail self)
        {
            MailNetHelper.SendReceiveMail(self.Root()).Coroutine();
        }

        public static async ETTask OnButtonOneKey(this DlgMail self)
        {
            long instanceid = self.InstanceId;
            MailComponentC mailComponent = self.Root().GetComponent<MailComponentC>();

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (mailComponent.MailInfoList.Count > 0)
            {
                int errorCode = await MailNetHelper.SendReceiveMail(self.Root());
                if (errorCode != 0)
                {
                    break;
                }

                if (instanceid != self.InstanceId)
                {
                    break;
                }

                await timerComponent.WaitAsync(200);
            }
        }

        public static void OnSelectMail(this DlgMail self)
        {
            self.UpdateMailSelected();
            self.UpdateMailContent();
        }

        public static void UpdateMailSelected(this DlgMail self)
        {
            MailComponentC mailComponent = self.Root().GetComponent<MailComponentC>();
            if (mailComponent.SelectMail == null)
            {
                self.View.EG_MailContentRectTransform.gameObject.SetActive(false);
                self.View.E_NoMailText.gameObject.SetActive(true);
                return;
            }

            self.View.EG_MailContentRectTransform.gameObject.SetActive(true);
            self.View.E_NoMailText.gameObject.SetActive(false);

            if (self.ScrollItemMailItems != null)
            {
                foreach (Scroll_Item_MailItem scrollItemMailItem in self.ScrollItemMailItems.Values)
                {
                    if (scrollItemMailItem.uiTransform == null)
                    {
                        continue;
                    }

                    scrollItemMailItem.SetSelected(mailComponent.SelectMail);
                }
            }
        }

        public static void UpdateMailContent(this DlgMail self)
        {
            MailComponentC mailComponent = self.Root().GetComponent<MailComponentC>();
            MailInfo mailInfos = mailComponent.SelectMail;
            self.View.E_TextMailTitleText.text = mailInfos.Title;
            self.View.E_TextMailContentText.text = mailInfos.Context;

            List<RewardItem> rewardItems = new();
            foreach (BagInfo bagInfo in mailInfos.ItemList)
            {
                rewardItems.Add(new RewardItem() { ItemID = bagInfo.ItemID, ItemNum = bagInfo.ItemNum });
            }

            self.View.ES_RewardList.Refresh(rewardItems);
        }

        public static void OnMailUpdate(this DlgMail self)
        {
            MailComponentC mailComponent = self.Root().GetComponent<MailComponentC>();
            self.View.E_NumTextText.text = $"{mailComponent.MailInfoList.Count}/100";

            //增删改
            List<MailInfo> mailInfos = mailComponent.MailInfoList;
            if (mailInfos.Count == 0)
            {
                mailComponent.SelectMail = null;
                self.View.EG_MailContentRectTransform.gameObject.SetActive(false);
                self.View.E_NoMailText.gameObject.SetActive(true);

                self.AddUIScrollItems(ref self.ScrollItemMailItems, 0);
                self.View.E_MailItemsLoopVerticalScrollRect.SetVisible(true, 0);
                return;
            }

            self.View.EG_MailContentRectTransform.gameObject.SetActive(true);
            self.View.E_NoMailText.gameObject.SetActive(false);

            if (self.Reverse > 0)
            {
                mailInfos.Reverse();
            }

            self.Reverse -= 1;

            self.AddUIScrollItems(ref self.ScrollItemMailItems, mailInfos.Count);
            self.View.E_MailItemsLoopVerticalScrollRect.SetVisible(true, mailInfos.Count);

            mailComponent.SelectMail = mailInfos[0];
            self.OnSelectMail();
        }

        private static void OnMailItemsRefresh(this DlgMail self, Transform transform, int index)
        {
            Scroll_Item_MailItem scrollItemMailItem = self.ScrollItemMailItems[index].BindTrans(transform);

            MailComponentC mailComponent = self.Root().GetComponent<MailComponentC>();

            scrollItemMailItem.OnUpdateUI(mailComponent.MailInfoList[index]);
            scrollItemMailItem.SetClickHandler(() => { self.OnSelectMail(); });
        }
    }
}