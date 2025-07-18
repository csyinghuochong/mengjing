namespace ET.Client
{
    [FriendOf(typeof(DlgArenaMain))]
    public static class DlgArenaMainSystem
    {
        public static void RegisterUIEvent(this DlgArenaMain self)
        {
            self.OnInitUI();
        }

        public static void ShowWindow(this DlgArenaMain self, Entity contextData = null)
        {
        }

        public static void OnUpdateUI(this DlgArenaMain self, M2C_AreneInfoResult message)
        {
            if (message.LeftPlayer < 0)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "竞技场第一", "恭喜你获得竞技场第1名，奖励内容8点发送至邮箱。", () =>
                {
                    if (self.IsDisposed)
                    {
                        return;
                    }

                    EnterMapHelper.RequestQuitFuben(self.Root());
                }, null).Coroutine();
            }
            else
            {
                using (zstring.Block())
                {
                    self.View.E_TextVSText.text = zstring.Format("剩余人数： {0}", message.LeftPlayer);
                }
            }
        }

        public static void OnInitUI(this DlgArenaMain self)
        {
            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            if (battleMessageComponent.M2C_AreneInfoResult != null)
            {
                self.OnUpdateUI(battleMessageComponent.M2C_AreneInfoResult);
            }
        }
    }
}
