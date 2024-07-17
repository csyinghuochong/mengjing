using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_CountryHuoDong))]
    [FriendOfAttribute(typeof (ES_CountryHuoDong))]
    public static partial class ES_CountryHuoDongSystem
    {
        [EntitySystem]
        private static void Awake(this ES_CountryHuoDong self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_HuoDong_LingzhuButton.AddListener(self.Btn_HuoDong_Lingzhu);
            self.E_Btn_HuoDong_BaozangButton.AddListener(self.Btn_HuoDong_Baozang);
            self.E_Btn_HuoDong_LingzhuJieShaoButton.AddListener(self.Btn_HuoDong_LingzhuJieShao);
            self.E_Btn_HuoDong_ArenaButton.AddListener(self.On_Btn_HuoDong_Arena);
            self.E_Btn_HuoDong_ArenaJieShaoButton.AddListenerAsync(self.On_Btn_HuoDong_ArenaJieShao);
            self.E_Btn_HuoDong_XiaoGuiButton.AddListener(self.Btn_HuoDong_XiaoGui);

            int zone = self.Root().GetComponent<PlayerComponent>().ServerItem.ServerId;
            int openDay = ServerHelper.GetServeOpenrDay( zone);
            self.EG_UICountryTaskItem_0RectTransform.gameObject.SetActive(openDay <= 7);
        }

        [EntitySystem]
        private static void Destroy(this ES_CountryHuoDong self)
        {
            self.DestroyWidget();
        }

        public static void Btn_HuoDong_Lingzhu(this ES_CountryHuoDong self)
        {
            TaskViewHelp.OnGoToNpc(self.Root(), 20000028);
            self.OnBtn_Close();
        }

        public static void Btn_HuoDong_XiaoGui(this ES_CountryHuoDong self)
        {
            TaskViewHelp.OnGoToNpc(self.Root(), 20099007);
            self.OnBtn_Close();
        }

        public static void Btn_HuoDong_LingzhuJieShao(this ES_CountryHuoDong self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CountryHuoDongJieShao).Coroutine();
        }

        public static async ETTask On_Btn_HuoDong_ArenaJieShao(this ES_CountryHuoDong self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CountryHuoDongJieShao);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCountryHuoDongJieShao>().OnUpdateJieShao("角斗场规则",
                " 1.活动开启后,所有12级以上玩家均可进入。\n 2.活动开启10分钟后将禁止所有玩家进入此地图。\n 3.在角斗场内,玩家将互相发起挑战,坚持到最后1名的玩家将会\n 获得丰厚奖励。\n 4.在同一个角斗场内,人数最多达到20人。\n 5.20:00活动结束,如果场内剩余多人,则按照当前最低排名发放奖励。");
        }

        public static void On_Btn_HuoDong_Arena(this ES_CountryHuoDong self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "角斗场", "是否立即前往角斗场？", () => { self.RequestEnterArena().Coroutine(); }, null).Coroutine();
        }

        public static async ETTask RequestEnterArena(this ES_CountryHuoDong self)
        {
            int errorCode = await ActivityTipHelper.RequestEnterArena(self.Root());
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.OnBtn_Close();
            }
        }

        public static void Btn_HuoDong_Baozang(this ES_CountryHuoDong self)
        {
            TaskViewHelp.OnGoToNpc(self.Root(), 20000027);
            self.OnBtn_Close();
        }

        public static void OnBtn_Close(this ES_CountryHuoDong self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Country);
        }
    }
}