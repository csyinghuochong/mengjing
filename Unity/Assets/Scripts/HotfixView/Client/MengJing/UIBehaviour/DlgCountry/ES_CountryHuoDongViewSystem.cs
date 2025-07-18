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

            self.E_Btn_HuoDong_LingzhuButton.AddListener(self.OnBtn_HuoDong_LingzhuButton);
            self.E_Btn_HuoDong_BaozangButton.AddListener(self.OnBtn_HuoDong_BaozangButton);
            self.E_Btn_HuoDong_LingzhuJieShaoButton.AddListener(self.OnBtn_HuoDong_LingzhuJieShaoButton);
            self.E_Btn_HuoDong_ArenaButton.AddListener(self.OnBtn_HuoDong_ArenaButton);
            self.E_Btn_HuoDong_ArenaJieShaoButton.AddListenerAsync(self.OnBtn_HuoDong_ArenaJieShaoButton);
            self.E_Btn_HuoDong_XiaoGuiButton.AddListener(self.OnBtn_HuoDong_XiaoGuiButton);
            
            int openDay = TimeHelper.GetServeOpenDay( self.Root().GetComponent<PlayerInfoComponent>().ServerItem.ServerOpenTime);
            self.EG_UICountryTaskItem_0RectTransform.gameObject.SetActive(openDay <= 7 );

            Transform transTaskListNodeform =  self.UITransform.Find("Right/ScrollView_1/Viewport/TaskListNode");
            transTaskListNodeform.Find("UICountryTaskItem_1").gameObject.SetActive(false);
            transTaskListNodeform.Find("UICountryTaskItem_2").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1023).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_3").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1031).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_4").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1060).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_5").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1057).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_6").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1025).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_7").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1061).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_8").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1052).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_9").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1055).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_10").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1043).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_11").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1045).IfOpen =="0");
            transTaskListNodeform.Find("UICountryTaskItem_12").gameObject.SetActive(FuntionConfigCategory.Instance.Get(1058).IfOpen =="0");
        }

        [EntitySystem]
        private static void Destroy(this ES_CountryHuoDong self)
        {
            self.DestroyWidget();
        }

        public static void OnBtn_HuoDong_LingzhuButton(this ES_CountryHuoDong self)
        {
            TaskViewHelp.OnGoToNpc(self.Root(), 20000028);
            self.OnBtn_Close();
        }

        public static void OnBtn_HuoDong_XiaoGuiButton(this ES_CountryHuoDong self)
        {
            TaskViewHelp.OnGoToNpc(self.Root(), 20099007);
            self.OnBtn_Close();
        }

        public static void OnBtn_HuoDong_LingzhuJieShaoButton(this ES_CountryHuoDong self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CountryHuoDongJieShao).Coroutine();
        }

        public static async ETTask OnBtn_HuoDong_ArenaJieShaoButton(this ES_CountryHuoDong self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CountryHuoDongJieShao);

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCountryHuoDongJieShao>().OnUpdateJieShao("角斗场规则",
                " 1.活动开启后，所有12级以上玩家均可进入。\n 2.活动开启10分钟后将禁止所有玩家进入此地图。\n 3.在角斗场内，玩家将互相发起挑战，坚持到最后1名的玩家将会\n 获得丰厚奖励。\n 4.在同一个角斗场内，人数最多达到20人。\n 5.20:00活动结束，如果场内剩余多人，则按照当前最低排名发放奖励。");
        }

        public static void OnBtn_HuoDong_ArenaButton(this ES_CountryHuoDong self)
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

        public static void OnBtn_HuoDong_BaozangButton(this ES_CountryHuoDong self)
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
