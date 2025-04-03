using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgRandomOpen))]
    public static class DlgRandomOpenSystem
    {
        public static void RegisterUIEvent(this DlgRandomOpen self)
        {
            self.OnInitUI().Coroutine();
        }

        public static void ShowWindow(this DlgRandomOpen self, Entity contextData = null)
        {
        }

        public static async ETTask OnInitUI(this DlgRandomOpen self)
        {
            int maxNumber = 0;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int randowTowerId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RandomTowerId);
            if (randowTowerId == 0)
            {
                maxNumber = 1;
            }
            else
            {
                maxNumber = TowerHelper.GetTowerListByScene(MapTypeEnum.RandomTower).Count;
            }

            if (maxNumber == 0)
            {
                return;
            }

            int randomNumber = 0;
            maxNumber = Mathf.Min(maxNumber, 7);
            for (int i = 0; i < maxNumber; i++)
            {
                randomNumber = RandomHelper.RandomNumber(1, maxNumber);
                self.View.E_Text_LayerText.text = randomNumber.ToString();
                await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            }

            await ActivityNetHelper.RandomTowerBeginRequest(self.Root(), randomNumber);

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RandomOpen);
        }
    }
}
