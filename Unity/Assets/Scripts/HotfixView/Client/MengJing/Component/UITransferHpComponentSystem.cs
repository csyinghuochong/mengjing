using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(UITransferHpComponent))]
    [FriendOf(typeof(UITransferHpComponent))]
    public static partial class UITransferHpComponentSystem
    {
        [Invoke(TimerInvokeType.TransferUITimer)]
        public class TransferUITimer : ATimer<UITransferHpComponent>
        {
            protected override void Run(UITransferHpComponent self)
            {
                try
                {
                    self.OnTimer();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this UITransferHpComponent self)
        {
            self.HeadBar = null;
            self.EnterRange = false;
            self.InitTime = TimeHelper.ServerNow() + TimeHelper.Second * 3;
            self.UICamera = GlobalComponent.Instance.UICamera.GetComponent<Camera>();
            self.MainCamera = GlobalComponent.Instance.MainCamera.GetComponent<Camera>();
        }

        [EntitySystem]
        private static void Destroy(this UITransferHpComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            if (self.HeadBar != null)
            {
                UnityEngine.Object.Destroy(self.HeadBar);
                self.HeadBar = null;
            }
        }

        public static async ETTask OnInitUI(this UITransferHpComponent self, int transferId)
        {
            DungeonTransferConfig monsterConfig = DungeonTransferConfigCategory.Instance.Get(transferId);
            string path = ABPathHelper.GetUGUIPath("Blood/UITransfer");
            GameObject prefab = await ResourcesComponent.Instance.LoadAssetAsync<GameObject>(path);
            self.HeadBar = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
            self.HeadBar.transform.SetParent(GlobalComponent.Instance.BloodMonster.transform);
            self.HeadBar.transform.localScale = Vector3.one;

            self.UIPosition = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject.transform.Find("UIPosition");
            self.HeadBar.Get<GameObject>("Lal_Name").GetComponent<Text>().text = monsterConfig.Name;

            if (self.HeadBar.GetComponent<HeadBarUI>() == null)
            {
                self.HeadBar.AddComponent<HeadBarUI>();
            }

            self.HeadBarUI = self.HeadBar.GetComponent<HeadBarUI>();
            self.HeadBarUI.HeadPos = self.UIPosition;
            self.HeadBarUI.HeadBar = self.HeadBar;
        }

        public static void LateUpdate(this UITransferHpComponent self)
        {
            if (self.HeadBar == null)
            {
                return;
            }

            Transform UIPosition = self.UIPosition;
            Vector2 OldPosition = WorldPosiToUIPos.WorldPosiToUIPosition(UIPosition.position, self.HeadBar, self.UICamera, self.MainCamera);

            Vector3 NewPosition = Vector3.zero;
            NewPosition.x = OldPosition.x;
            NewPosition.y = OldPosition.y;
            self.HeadBar.transform.localPosition = NewPosition;
        }

        public static void OnTimer(this UITransferHpComponent self)
        {
            if (!self.EnterRange)
            {
                return;
            }

            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.LocalDungeon, 0, 0, self.GetParent<Unit>().ConfigId.ToString()).Coroutine();
        }

        public static void StartTimer(this UITransferHpComponent self)
        {
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            timerComponent.Remove(ref self.Timer);
            long leftTime = self.InitTime - TimeHelper.ServerNow();
            leftTime = Math.Max(10, leftTime);
            self.Timer = timerComponent.NewOnceTimer(TimeHelper.ServerNow() + leftTime, TimerInvokeType.TransferUITimer, self);
        }

        public static void OnCheckChuanSong(this UITransferHpComponent self, Unit mainhero)
        {
            Vector3 vector3 = self.GetParent<Unit>().Position;
            float distance = PositionHelper.Distance2D(vector3, mainhero.Position);

            if (distance <= 1.5f && !self.EnterRange)
            {
                self.EnterRange = true;
                if (UnitHelper.IsHaveBoss(mainhero.Scene(), vector3, 8f))
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", "附近有领主出现,请问是否进入新地图?", () => { self.StartTimer(); }, null).Coroutine();
                }
                else
                {
                    self.StartTimer();
                }
            }

            if (distance > 1.5f && self.EnterRange)
            {
                self.EnterRange = false;
            }
        }
    }
}