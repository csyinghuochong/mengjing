using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_OnMailUpdate_DlgMailRefresh : AEvent<Scene, OnMailUpdate>
    {
        protected override async ETTask Run(Scene scene, OnMailUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgMail>()?.OnMailUpdate();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(Scroll_Item_MailItem))]
    [FriendOf(typeof(DlgMail))]
    public static class DlgMailSystem
    {
        public static void RegisterUIEvent(this DlgMail self)
        {
            self.View.E_MailItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMailItemsRefresh);
            self.View.E_ButtonGetButton.AddListener(self.OnButtonGetButton);
            self.View.E_ButtonOneKeyButton.AddListenerAsync(self.OnButtonOneKeyButton);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);

            self.RequestMaiList();
        }

        public static void ShowWindow(this DlgMail self, Entity contextData = null)
        {
        }

        public static void RequestMaiList(this DlgMail self)
        {
            MailNetHelper.SendGetMailList(self.Root()).Coroutine();
            UserInfoNetHelper.ReddotReadRequest(self.Root(), ReddotType.Email).Coroutine();
        }

        public static void OnButtonGetButton(this DlgMail self)
        {
            MailNetHelper.SendReceiveMail(self.Root()).Coroutine();
        }

        public static async ETTask OnButtonOneKeyButton(this DlgMail self)
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
                self.View.UITransform.Find("Left").gameObject.SetActive(false);
                self.View.E_NoMailText.gameObject.SetActive(true);
                
                return;
            }

            self.View.EG_MailContentRectTransform.gameObject.SetActive(true);
            self.View.UITransform.Find("Left").gameObject.SetActive(true);
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
            foreach (ItemInfoProto bagInfo in mailInfos.ItemList)
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

            // Test 
            // MailInfo mailInfo1 = MailInfo.Create();
            // mailInfo1.Context = "1111111111";
            // ItemInfoProto itemInfoProto1 = ItemInfoProto.Create();
            // itemInfoProto1.ItemID = 1;
            // itemInfoProto1.ItemNum = 1;
            // mailInfo1.ItemList.Add(itemInfoProto1);
            // mailInfos.Add(mailInfo1);
            // for (int i = 0; i < 20; i++)
            // {
            //     MailInfo mailInfo2 = MailInfo.Create();
            //     mailInfo2.Context = i.ToString();
            //     mailInfos.Add(mailInfo2);
            // }

            if (mailInfos.Count == 0)
            {
                mailComponent.SelectMail = null;
                self.View.UITransform.Find("Left").gameObject.SetActive(false);
                self.View.EG_MailContentRectTransform.gameObject.SetActive(false);
                self.View.E_NoMailText.gameObject.SetActive(true);

                self.AddUIScrollItems(ref self.ScrollItemMailItems, 0);
                self.View.E_MailItemsLoopVerticalScrollRect.SetVisible(true, 0);
                return;
            }

            self.View.UITransform.Find("Left").gameObject.SetActive(true);
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
            foreach (Scroll_Item_MailItem item in self.ScrollItemMailItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_MailItem scrollItemMailItem = self.ScrollItemMailItems[index].BindTrans(transform);

            MailComponentC mailComponent = self.Root().GetComponent<MailComponentC>();

            scrollItemMailItem.OnUpdateUI(mailComponent.MailInfoList[index]);
            scrollItemMailItem.SetClickHandler(() => { self.OnSelectMail(); });
            scrollItemMailItem.SetSelected(mailComponent.SelectMail);
        }

        public static void OnBtn_CloseButton(this DlgMail self)
        {
        }
    }
}