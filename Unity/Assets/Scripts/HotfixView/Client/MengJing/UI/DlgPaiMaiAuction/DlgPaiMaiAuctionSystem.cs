using System;

namespace ET.Client
{
    [Invoke(TimerInvokeType.AuctionTimer)]
    public class AuctionTimer : ATimer<DlgPaiMaiAuction>
    {
        protected override void Run(DlgPaiMaiAuction self)
        {
            try
            {
                self.OnAuctionTimer();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [FriendOf(typeof(DlgPaiMaiAuction))]
    public static class DlgPaiMaiAuctionSystem
    {
        public static void RegisterUIEvent(this DlgPaiMaiAuction self)
        {
            self.View.E_Btn_AuctionButton.AddListenerAsync(self.OnBtn_AuctionButton);
            self.View.E_Btn_CanYuButton.AddListener(self.OnBtn_CanYuButton);
            self.View.E_Btn_RecordButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_AuctionRecord).Coroutine();
            });
            self.View.E_Btn_BuyNum_jian1Button.AddListener(() => { self.Btn_BuyNum_jia(-1); });
            self.View.E_Btn_BuyNum_jia1Button.AddListener(() => { self.Btn_BuyNum_jia(1); });
            
            self.RequestPaiMaiAuction().Coroutine();

            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);
            long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;

            long openTime = FunctionHelp.GetOpenTime(1040);
            long closeTime = FunctionHelp.GetCloseTime(1040);
            if (curTime >= openTime && curTime < closeTime)
            {
                self.LeftTime = closeTime - curTime;
                self.AuctionTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.AuctionTimer, self);
                self.OnAuctionTimer();
            }
            else
            {
                self.View.E_Text_2Text.text = "已结束";
            }
        }

        public static void ShowWindow(this DlgPaiMaiAuction self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgPaiMaiAuction self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.AuctionTimer);
        }

        public static void OnAuctionTimer(this DlgPaiMaiAuction self)
        {
            if (self.LeftTime < 0)
            {
                self.View.E_Text_2Text.text = "已结束";
                self.Root().GetComponent<TimerComponent>().Remove(ref self.AuctionTimer);
                return;
            }

            using (zstring.Block())
            {
                self.View.E_Text_2Text.text = zstring.Format("剩余时间:{0}", TimeHelper.ShowLeftTime(self.LeftTime * 1000));
            }

            self.LeftTime--;
        }

        public static void Btn_BuyNum_jia(this DlgPaiMaiAuction self, int add)
        {
            long paiprice = long.Parse(self.View.E_TextPriceText.text);

            string text = self.View.E_Lab_RmbNumInputField.text;

            if (add < 0)
            {
                //降低
                add = (int)(add * paiprice * 0.1f);
            }

            if (add > 0)
            {
                //增加
                add = (int)(add * paiprice * 0.1f);
            }

            long curprice = long.Parse(text);

            curprice += add;

            if (curprice < paiprice)
            {
                FlyTipComponent.Instance.ShowFlyTip("不能小于竞拍价！");
                return;
            }

            self.View.E_Lab_RmbNumInputField.text = curprice.ToString();
        }

        public static async ETTask OnBtn_AuctionButton(this DlgPaiMaiAuction self)
        {
            string text = self.View.E_Lab_RmbNumInputField.text;
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            long price = long.Parse(text);
            if (price < 0)
            {
                return;
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            if (userInfo.Gold < price)
            {
                FlyTipComponent.Instance.ShowFlyTip("金币不足！");
                return;
            }

            await ActivityNetHelper.PaiMaiAuctionPrice(self.Root(), price);
        }

        public static void OnBtn_CanYuButton(this DlgPaiMaiAuction self)
        {
            int returngold = (int)(self.AuctionStart * 0.1f);
            if (returngold <= 0)
            {
                return;
            }

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "参与竞拍", zstring.Format("扣除{0}金币的保证金", returngold), () => { self.RquestCanYu().Coroutine(); },
                    null).Coroutine();
            }
        }

        public static async ETTask RquestCanYu(this DlgPaiMaiAuction self)
        {
            if (self.AuctionJoin)
            {
                return;
            }

            self.AuctionJoin = true;
            int error = await ActivityNetHelper.PaiMaiAuctionJoin(self.Root());
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.RequestPaiMaiAuction().Coroutine();
        }

        public static async ETTask RequestPaiMaiAuction(this DlgPaiMaiAuction self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            P2C_PaiMaiAuctionInfoResponse response = await ActivityNetHelper.PaiMaiAuctionInfo(self.Root(), unit.Id);
            if (response.AuctionItem == 0)
            {
                self.View.E_Text_2Text.text = "已结束";
                self.View.E_Btn_AuctionButton.gameObject.SetActive(false);
                self.View.E_Btn_CanYuButton.gameObject.SetActive(false);
                return;
            }

            self.OnUpdateUI(response.AuctionItem, response.AuctionNumber, response.AuctionPrice);
            using (zstring.Block())
            {
                self.View.E_TextAuctionPlayerText.text = zstring.Format("出价玩家:{0}", response.AuctionPlayer);
            }

            self.View.ES_CommonItem.E_ItemNumText.text = response.AuctionNumber.ToString();
            self.AuctionStart = response.AuctionStart;

            self.View.E_Btn_CanYuButton.gameObject.SetActive(!response.AuctionJoin);
            self.View.E_Btn_AuctionButton.gameObject.SetActive(response.AuctionJoin);
            self.AuctionJoin = false;
            if (response.AuctionJoin)
            {
                int returngold = (int)(response.AuctionStart * 0.1f);
                using (zstring.Block())
                {
                    string text = zstring.Format("已经缴纳{0}保证金", returngold);
                    self.View.E_TextBaoZhenJinText.text = text;
                }
            }
            else
            {
                self.View.E_TextBaoZhenJinText.text = string.Empty;
            }
        }

        public static void OnUpdateUI(this DlgPaiMaiAuction self, int itemid, int number, long price)
        {
            self.View.E_TextPriceText.text = price.ToString();
            self.View.E_Lab_RmbNumInputField.text = price.ToString();

            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemID = itemid;
            bagInfo.ItemNum = number;
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
        }

        public static void OnRecvHorseNotice(this DlgPaiMaiAuction self, string noticeText)
        {
            string[] infos = noticeText.Split('_');
            int itmeid = int.Parse(infos[0]);
            int itmenumber = int.Parse(infos[1]);
            long price = long.Parse(infos[2]);
            self.OnUpdateUI(itmeid, itmenumber, price);
            using (zstring.Block())
            {
                self.View.E_TextAuctionPlayerText.text = zstring.Format("出价玩家:{0}", infos[3]);
            }
        }
    }
}
