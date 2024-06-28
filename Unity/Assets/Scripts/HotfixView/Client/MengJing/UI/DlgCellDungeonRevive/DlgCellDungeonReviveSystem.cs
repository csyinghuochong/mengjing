using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgCellDungeonRevive))]
    public static class DlgCellDungeonReviveSystem
    {
        public static void RegisterUIEvent(this DlgCellDungeonRevive self)
        {
            self.View.E_Button_ReviveButton.AddListener(self.OnButton_Revive);
            self.View.E_Button_ExitButton.AddListener(self.OnButton_Exit);
        }

        public static void ShowWindow(this DlgCellDungeonRevive self, Entity contextData = null)
        {
        }

        public static bool IsNoAutoExit(this DlgCellDungeonRevive self, int sceneType)
        {
            return sceneType == SceneTypeEnum.TeamDungeon
                    || sceneType == SceneTypeEnum.Battle
                    || sceneType == SceneTypeEnum.BaoZang
                    || sceneType == SceneTypeEnum.MiJing
                    || sceneType == SceneTypeEnum.UnionRace;
        }

        public static void Check(this DlgCellDungeonRevive self, int leftTime)
        {
            self.LeftTime = leftTime;
            self.View.E_Text_ExitTipText.text = $"{leftTime}秒后退出副本";
            if (leftTime <= 0)
            {
                self.OnAuto_Exit();
            }
        }

        public static async ETTask BegingTimer(this DlgCellDungeonRevive self)
        {
            self.Check(self.LeftTime);
            long instanceId = self.InstanceId;
            for (int i = self.LeftTime - 1; i >= 0; i--)
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                self.Check(i);
            }
        }

        public static void OnInitUI(this DlgCellDungeonRevive self, int seneTypeEnum)
        {
            self.SceneType = seneTypeEnum;
            self.LeftTime = seneTypeEnum == SceneTypeEnum.TeamDungeon? 3 : 10;

            self.BegingTimer().Coroutine();

            string reviveCost = GlobalValueConfigCategory.Instance.Get(5).Value;
            string[] needList = reviveCost.Split(';');

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(needList[0]));
            self.View.E_Text_CostNameText.text = itemConfig.ItemName;

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_ImageCostImage.sprite = sp;

            //显示副本
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            long selfNum = bagComponent.GetItemNumber(int.Parse(needList[0]));
            long needNum = int.Parse(needList[1]);
            if (selfNum >= needNum)
            {
                self.View.E_Text_CostText.text = selfNum + "/" + needNum;
                self.View.E_Text_CostText.color = Color.green;
            }
            else
            {
                self.View.E_Text_CostText.text = selfNum + "/" + needNum + "(" + "道具不足" + ")";
                self.View.E_Text_CostText.color = Color.yellow;
            }

            if (self.SceneType != SceneTypeEnum.LocalDungeon)
            {
                self.View.E_Text_ExitDesText.text = "返回出生点";
            }
        }

        public static void OnButton_Revive(this DlgCellDungeonRevive self)
        {
            string reviveCost = GlobalValueConfigCategory.Instance.Get(5).Value;
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            bool success = bagComponent.CheckNeedItem(reviveCost);
            if (!success)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("道具不足");
                return;
            }

            if (self.SceneType == SceneTypeEnum.UnionRace)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("不支持复活");
                return;
            }

            EnterMapHelper.SendReviveRequest(self.Root(), true).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
        }

        public static void OnAuto_Exit(this DlgCellDungeonRevive self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (self.IsNoAutoExit(mapComponent.SceneType))
            {
                return;
            }

            SessionComponent sessionComponent = self.Root().GetComponent<SessionComponent>();
            if (sessionComponent.Session == null || sessionComponent.Session.IsDisposed)
            {
                return;
            }

            EnterMapHelper.RequestQuitFuben(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
        }

        public static void OnButton_Exit(this DlgCellDungeonRevive self)
        {
            MapComponent mapComponent = self.Root().GetComponent<MapComponent>();
            if (self.IsNoAutoExit(mapComponent.SceneType))
            {
                if (self.LeftTime > 0)
                {
                    if (self.SceneType == SceneTypeEnum.LocalDungeon)
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi($"{self.LeftTime}秒后可返回主城！");
                    }
                    else
                    {
                        FlyTipComponent.Instance.ShowFlyTipDi($"{self.LeftTime}秒后可返回出生点！");
                    }
                }
                else
                {
                    EnterMapHelper.SendReviveRequest(self.Root(), false).Coroutine();
                    self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
                }
            }
            else
            {
                EnterMapHelper.RequestQuitFuben(self.Root());
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonRevive);
            }
        }
    }
}