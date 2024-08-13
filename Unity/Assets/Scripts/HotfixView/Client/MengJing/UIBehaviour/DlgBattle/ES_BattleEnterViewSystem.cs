using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_BattleEnter))]
    [FriendOfAttribute(typeof (ES_BattleEnter))]
    public static partial class ES_BattleEnterSystem
    {
        [EntitySystem]
        private static void Awake(this ES_BattleEnter self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ButtonEnterButton.AddListenerAsync(self.OnButtonEnterButton);

            GlobalValueConfig globalValue = GlobalValueConfigCategory.Instance.Get(56);
            self.ES_RewardList.Refresh(globalValue.Value);
        }

        [EntitySystem]
        private static void Destroy(this ES_BattleEnter self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonEnterButton(this ES_BattleEnter self)
        {
            int errorCode = await ActivityNetHelper.RequstBattleEnter(self.Root());
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Battle);
                return;
            }

            HintHelp.ShowErrorHint(self.Root(), errorCode);
        }
    }
}
