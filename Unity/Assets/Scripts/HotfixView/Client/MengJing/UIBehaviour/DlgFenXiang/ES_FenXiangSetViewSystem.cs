using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_FenXiangSet))]
    [FriendOfAttribute(typeof (ES_FenXiangSet))]
    public static partial class ES_FenXiangSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FenXiangSet self, Transform transform)
        {
            self.uiTransform = transform;

            if (GlobalHelp.GetPlatform() == 5)
            {
                self.EG_FenXiang_TikTokRectTransform.gameObject.SetActive(false);
                self.EG_FenXiang_WeiXinRectTransform.gameObject.SetActive(false);
                self.EG_FenXiang_QQRectTransform.gameObject.SetActive(true);
                self.EG_FenXiang_QQRectTransform.localPosition = new Vector3(0f, 112f, 0f);
                self.E_Text_tip1Text.gameObject.SetActive(false);
                self.E_Button_AddQQButton.gameObject.SetActive(false);
            self.E_Button_AddQQButton.AddListener(self.OnButton_AddQQButton);
            self.E_Button_supportButton.AddListener(self.OnButton_supportButton);
            }
            else
            {
                self.EG_FenXiang_TikTokRectTransform.gameObject.SetActive(false);
                self.EG_FenXiang_WeiXinRectTransform.gameObject.SetActive(true);
                self.EG_FenXiang_QQRectTransform.gameObject.SetActive(true);
                self.EG_FenXiang_QQRectTransform.localPosition = new Vector3(-257f, 112f, 0f);
            }

            if (CommonHelp.IsBanHaoZone( self.Root().GetComponent<PlayerInfoComponent>().ServerItem.ServerId) )
            {
                self.E_Text_tip1Text.gameObject.SetActive(false);
            }

            self.EG_FenXiang_QQRectTransform.Find("Button_Share").GetComponent<Button>().AddListener(self.OnQQZone);
            self.EG_FenXiang_QQRectTransform.Find("Button_Friend").GetComponent<Button>().AddListener(self.OnQQShare);
            self.EG_FenXiang_WeiXinRectTransform.Find("Button_Share").GetComponent<Button>().AddListener(self.OnWeiXinShare);
            self.EG_FenXiang_WeiXinRectTransform.Find("Button_Friend").GetComponent<Button>().AddListener(self.OnWeChatMoments);
            self.E_Button_supportButton.AddListener(() =>
            {
                // self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
            });

            self.E_Button_AddQQButton.AddListener(self.OpenAddQQ);

            self.EG_FenXiang_TikTokRectTransform.Find("Button_Share").GetComponent<Button>().AddListener(self.OnTikTokShare);
            self.EG_FenXiang_TikTokRectTransform.Find("Button_Friend").GetComponent<Button>().AddListener(self.OnTikTokShare);

            // GameObject.Find("Global").GetComponent<Init>().OnShareHandler = (int pType, bool value) =>
            // {
            //     self.OnShareHandler(pType, value).Coroutine();
            // };

            self.RequestPopularizeCode().Coroutine();
            self.OnUpdateUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_FenXiangSet self)
        {
            self.DestroyWidget();
        }

        public static void OpenAddQQ(this ES_FenXiangSet self)
        {
            Application.OpenURL(
                "http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=8IC8YKKACgjkp_zJyDN0GGCf4baWxU7B&authKey=gQTYvxiFMLkP9I7u%2FmzapPS3M29gId4jQ8mzYVcwpQ3dOyCXBqVOJKcQZrA8mYhN&noverify=0&group_code=719546102");
        }

        public static async ETTask RequestPopularizeCode(this ES_FenXiangSet self)
        {
            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            if (TimeHelper.ServerNow() - battleMessageComponent.LastPopularize_ListTime < TimeHelper.Minute)
            {
                return;
            }

            battleMessageComponent.LastPopularize_ListTime = TimeHelper.ServerNow();

            Popularize2C_ListResponse response = await ActivityNetHelper.Popularize_ListRequest(self.Root());
            self.PopularizeCode = response.PopularizeCode.ToString();
            Log.Debug($"self.PopularizeCode :{self.PopularizeCode}");
        }

        public static async ETTask OnShareHandler(this ES_FenXiangSet self, int pType, bool share)
        {
            //1 4微信  2 5QQ
            Log.Debug($"分享回调：  {pType} {share}");
            int sType = self.ShareType;
            if (sType != 1 && sType != 2)
            {
                return;
            }

            TaskComponentC taskComponent = self.Root().GetComponent<TaskComponentC>();
            if (taskComponent.GetHuoYueDu() < 30)
            {
                FlyTipComponent.Instance.ShowFlyTip("活跃度低于30没有奖励！");
                return;
            }

            long instanceid = self.InstanceId;
            await ActivityNetHelper.ShareSucessRequest(self.Root(), sType);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.OnUpdateUI();
        }

        public static void OnUpdateUI(this ES_FenXiangSet self)
        {
            self.EG_FenXiang_WeiXinRectTransform.Find("Image_complete").gameObject.SetActive(self.IsShared(1));
            self.EG_FenXiang_QQRectTransform.Find("Image_complete").gameObject.SetActive(self.IsShared(2));
        }

        public static bool IsShared(this ES_FenXiangSet self, int sType)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long shareSet = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.FenShangSet);
            return (shareSet & sType) > 0;
        }

        public static void FenXiangByType(this ES_FenXiangSet self, int shareType)
        {
            // string title = "危境";
            // string text = "暗黑系列ARPG探索类手游《危境》系列正式开启！";
            //
            // if (shareType == 4 || shareType == 5)
            // {
            //     title = "快来和我一起玩危境吧!";
            //     text = "一把木剑，一件布衣，点击这个链接开始你的探险吧!";
            // }

            // FenXiangContent fenXiangContent = new FenXiangContent();
            // fenXiangContent.FenXiang_Title = title;
            // fenXiangContent.FenXiang_Text = text;
            // fenXiangContent.FenXiang_ImageUrl = "https://img.71acg.net/kbdev/opensj/20230109/15243214265";
            // //fenXiangContent.FenXiang_ClickUrl = "http://verification.weijinggame.com/weijing/";
            // fenXiangContent.FenXiang_ClickUrl = "https://l.tapdb.net/08MLKXV5?channel=rep-rep_d2ves97egb7";
            //
            // fenXiangContent.Fenxiangtype = shareType;
            // self.ShareType = shareType;

#if UNITY_EDITOR
            self.OnShareHandler(shareType, true).Coroutine();
#else
            //GlobalHelp.FenXiang(fenXiangContent);
#endif
        }

        public static void OnQQShare(this ES_FenXiangSet self)
        {
            //QQ好友
            self.FenXiangByType(5);
        }

        public static void OnWeiXinShare(this ES_FenXiangSet self)
        {
            //微信朋友圈
            if (self.IsShared(1))
            {
                return;
            }

            self.FenXiangByType(1);
        }

        public static void OnWeChatMoments(this ES_FenXiangSet self)
        {
            //微信好友
            self.FenXiangByType(4);
        }

        public static void OnQQZone(this ES_FenXiangSet self)
        {
            //QQ空间
            if (self.IsShared(2))
            {
                return;
            }

            self.FenXiangByType(2);
        }

        public static void OnTikTokShareHandler(this ES_FenXiangSet self, int sharemode, bool sucess)
        {
        }

        public static void OnTikTokShare(this ES_FenXiangSet self)
        {
            Log.Debug($"OnTikTokShare:");
            // EventType.TikTokShare.Instance.ZoneScene = self.ZoneScene();
            // EventType.TikTokShare.Instance.ShareHandler = self.OnTikTokShareHandler;
            // EventType.TikTokShare.Instance.ShareMessage = new List<string>()
            // {
            //     "https://img.71acg.net/kbdev/opensj/20230109/15243214265", "https://l.tapdb.net/08MLKXV5?channel=rep-rep_d2ves97egb7"
            // };
            // EventSystem.Instance.PublishClass(EventType.TikTokShare.Instance);
        }
        public static void OnButton_AddQQButton(this ES_FenXiangSet self)
        {
        }
        public static void OnButton_supportButton(this ES_FenXiangSet self)
        {
        }
    }
}
