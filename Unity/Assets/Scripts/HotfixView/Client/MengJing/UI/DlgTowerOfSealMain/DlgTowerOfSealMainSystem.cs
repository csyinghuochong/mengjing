namespace ET.Client
{
    [FriendOf(typeof(DlgTowerOfSealMain))]
    public static class DlgTowerOfSealMainSystem
    {
        public static void RegisterUIEvent(this DlgTowerOfSealMain self)
        {
            self.View.E_StartBtnButton.AddListener(self.OnStartBtn);
            
            self.UpdateInfo();
        }

        public static void ShowWindow(this DlgTowerOfSealMain self, Entity contextData = null)
        {
        }

        public static void UpdateInfo(this DlgTowerOfSealMain self)
        {
            self.View.E_LevelNumTextText.text = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.SealTowerArrived).ToString();
        }

        public static void ShowStartBtn(this DlgTowerOfSealMain self)
        {
            self.View.E_StartBtnButton.gameObject.SetActive(true);
        }

        public static void OnStartBtn(this DlgTowerOfSealMain self)
        {
            NumericComponentC numericComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();

            // 如果已经通关塔顶
            if (numericComponent.GetAsInt(NumericType.SealTowerFinished) >= 100)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经通关塔顶，请明日再来挑战!");
                return;
            }

            // 如果该层的Boss未击败
            if (numericComponent.GetAsInt(NumericType.SealTowerArrived) > numericComponent.GetAsInt(NumericType.SealTowerFinished))
            {
                FlyTipComponent.Instance.ShowFlyTip("该层怪物并未击败，请击败本次怪物再继续挑战!!!");
                return;
            }
            
            // 打开花费道具继续挑战UI
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TowerOfSealCost).Coroutine();
        }
    }
}