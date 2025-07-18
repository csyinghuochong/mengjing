using System;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RechargeItem))]
    [FriendOf(typeof(DlgRecharge))]
    public static class DlgRechargeSystem
    {
        public static void RegisterUIEvent(this DlgRecharge self)
        {
            self.View.E_ButtonAliPayButton.AddListener(() =>
            {
                self.View.E_ImageSelect1Image.gameObject.SetActive(false);
                self.View.E_ImageSelect2Image.gameObject.SetActive(true);
                self.PayType = PayTypeEnum.AliPay;
            });
            self.View.E_ButtonWeiXinButton.AddListener(() =>
            {
                self.View.E_ImageSelect1Image.gameObject.SetActive(true);
                self.View.E_ImageSelect2Image.gameObject.SetActive(false);
                self.PayType = PayTypeEnum.WeiXinPay;
            });
            self.View.E_ImageSelect1Image.gameObject.SetActive(false);
            self.View.E_ImageSelect2Image.gameObject.SetActive(true);

            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);

            self.View.E_RechargeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRechargeItemsRefresh);
            
            self.View.EG_LoadingRectTransform.gameObject.SetActive(false);
            self.PayType = PayTypeEnum.AliPay;

            self.InitRechargeList();

            if (GlobalHelp.GetPlatform() == 5)
            {
                self.PayType = PayTypeEnum.TikTok;
                self.View.E_ImageSelect1Image.gameObject.SetActive(false);
                self.View.E_ImageSelect2Image.gameObject.SetActive(false);
                self.View.E_ButtonAliPayButton.gameObject.SetActive(false);
                self.View.E_ButtonWeiXinButton.gameObject.SetActive(false);
            }
#if UNITY_IPHONE && !UNITY_EDITOR
                self.View.E_ImageSelect1Image.gameObject.SetActive(false);
                self.View.E_ImageSelect2Image.gameObject.SetActive(false);
                self.View.E_ButtonAliPayButton.gameObject.SetActive(false);
                self.View.E_ButtonWeiXinButton.gameObject.SetActive(false);
#endif
        }

        public static void ShowWindow(this DlgRecharge self, Entity contextData = null)
        {
            self.UpdateRechargeNum();
        }

        public static void UpdateRechargeNum(this DlgRecharge self)
        {
            FangChenMiComponentC fangChenMiComponent = self.Root().GetComponent<FangChenMiComponentC>();
            self.View.E_Text_ReChargeText.text = $"{fangChenMiComponent.GetToDayNum()}/30";
        }
        
        private static void OnRechargeItemsRefresh(this DlgRecharge self, Transform transform, int index)
        {
            foreach (Scroll_Item_RechargeItem item in self.ScrollItemRechargeItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            var item1 = ConfigData.RechargeGive.ToList()[index];
            Scroll_Item_RechargeItem scrollItemRechargeItem = self.ScrollItemRechargeItems[index].BindTrans(transform);
            scrollItemRechargeItem.OnInitData(item1.Key, item1.Value);
            scrollItemRechargeItem.SetClickHandler((number) => { self.OnClickRechargeItem(number).Coroutine(); });
        }

        public static void InitRechargeList(this DlgRecharge self)
        {
            self.AddUIScrollItems(ref self.ScrollItemRechargeItems, ConfigData.RechargeGive.Count);
            self.View.E_RechargeItemsLoopVerticalScrollRect.SetVisible(true, ConfigData.RechargeGive.Count);
        }

        public static void OnGetRiskControlInfo(this DlgRecharge self, string riskControl)
        {
            Log.Debug($"OnGetRiskControlInfo: {riskControl}");
            self.RequestRecharge(riskControl).Coroutine();
        }

        public static async ETTask RequestRecharge(this DlgRecharge self, string riskControl = "")
        {
            M2C_RechargeResponse response = await UserInfoNetHelper.RechargeRequest(self.Root(), riskControl, self.ReChargeNumber, self.PayType);

            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (CommonHelp.IsBanHaoZone(self.Root().GetComponent<PlayerInfoComponent>().ServerItem.ServerId) || string.IsNullOrEmpty(response.Message))
            {
                return;
            }

            // if (self.PayType == PayTypeEnum.AliPay)
            // {
            //     GlobalHelp.AliPay(response.Message);
            // }
            //
            // if (self.PayType == PayTypeEnum.WeiXinPay)
            // {
            //     GlobalHelp.WeChatPay(response.Message);
            // }

            if (self.PayType == PayTypeEnum.TikTok)
            {
                if (GlobalHelp.GetBigVersion() >= 17 && GlobalHelp.GetPlatform() == 5)
                {
#if UNITY_ANDROID
                    // Log.ILog.Debug($"M2C_RechargeResponse: {sendChatResponse.Message}");
                    // EventType.TikTokPayRequest.Instance.ZoneScene = self.ZoneScene();
                    // EventType.TikTokPayRequest.Instance.PayMessage = sendChatResponse.Message;
                    // EventType.TikTokPayRequest.Instance.RechargeNumber = self.ReChargeNumber;
                    // EventSystem.Instance.PublishClass(EventType.TikTokPayRequest.Instance);
#endif
                }
            }
        }
        
        public static async ETTask OnClickRechargeItem(this DlgRecharge self, int chargetNumber)
        {
            FangChenMiComponentC fangChenMiComponent = self.Root().GetComponent<FangChenMiComponentC>();
            int code = fangChenMiComponent.CanRechage(chargetNumber);
            if (code != ErrorCode.ERR_Success)
            {
                string tips = "";
                if (code == ErrorCode.ERR_FangChengMi_Tip3)
                {
                    tips = $"{ErrorViewData.ErrorHints[code]}";
                }
                else
                {
                    tips = $"{ErrorViewData.ErrorHints[code]} 你本月已充值{fangChenMiComponent.GetMouthTotal()}元";
                }
            
                PopupTipHelp.OpenPopupTip_2(self.Root(), "防沉迷提示", tips, () => { }).Coroutine();
                return;
            }

            self.ReChargeNumber = chargetNumber;

#if UNITY_IPHONE
            //self.Loading.SetActive(true);
            //GlobalHelp.OnIOSPurchase(chargetNumber);
            //C2M_RechargeRequest c2E_GetAllMailRequest = new C2M_RechargeRequest() { RechargeNumber = chargetNumber, PayType = PayTypeEnum.IOSPay };
            //self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2E_GetAllMailRequest).Coroutine();
#else

            if (GlobalHelp.GetPlatform() == 5)
            {
                if (GlobalHelp.GetBigVersion() >= 17 && GlobalHelp.GetPlatform() == 5)
                {
#if UNITY_ANDROID
                    // EventType.TikTokRiskControlInfo.Instance.ZoneScene = self.ZoneScene();
                    // EventType.TikTokRiskControlInfo.Instance.RiskControlInfoHandler = (string text) => { self.OnGetRiskControlInfo(text); };
                    // EventSystem.Instance.PublishClass(EventType.TikTokRiskControlInfo.Instance);
#endif
                }
            }
            else
            {
                self.RequestRecharge().Coroutine();
            }

            //记录tap数据
            try
            {
                // string serverName = self.Root().GetComponent<PlayerComponent>().ServerName;
                // UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
                // TapSDKHelper.UpLoadPlayEvent(userInfo.Name, serverName, userInfo.Lv, 4, chargetNumber);
            }
            catch (Exception ex)
            {
                using (zstring.Block())
                {
                    Log.Debug(zstring.Format("UIRecharge ex:{0}", ex.ToString()));
                }
            }

#endif
            
            
            await ETTask.CompletedTask;
        }

        public static void OnImageButtonButton(this DlgRecharge self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Recharge);
        }
    }
}