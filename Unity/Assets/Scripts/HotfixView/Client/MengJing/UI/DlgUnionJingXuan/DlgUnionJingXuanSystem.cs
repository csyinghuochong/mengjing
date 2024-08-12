using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgUnionJingXuan))]
    public static class DlgUnionJingXuanSystem
    {
        public static void RegisterUIEvent(this DlgUnionJingXuan self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            self.View.E_ButtonConfirmButton.AddListener(() => { self.OnButtonConfirmButton(1).Coroutine(); });
            self.View.E_ButtonCancelButton.AddListener(self.OnButtonCancelButton);
        }

        public static void ShowWindow(this DlgUnionJingXuan self, Entity contextData = null)
        {
        }

        public static void OnImageButtonButton(this DlgUnionJingXuan self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_UnionJingXuan);
        }

        public static void OnButtonCancelButton(this DlgUnionJingXuan self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "取消申请", "是否确认取消申请族长?", () => { self.OnButtonConfirmButton(0).Coroutine(); }, null).Coroutine();
        }

        public static async ETTask OnButtonConfirmButton(this DlgUnionJingXuan self, int operateType)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            U2C_UnionJingXuanResponse response = await UnionNetHelper.UnionJingXuanRequest(self.Root(), unit.Id,
                unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0), operateType);

            self.UnionInfo.JingXuanList = response.JingXuanList;
            self.UnionInfo.JingXuanEndTime = response.JingXuanEndTime;
            self.OnUpdateUI(self.UnionInfo);

            if (response.JingXuanList.Count == 0)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_UnionJingXuan);
            }
        }

        public static UnionPlayerInfo GetUnionPlayerInfo(this DlgUnionJingXuan self, long playerid)
        {
            for (int i = 0; i < self.UnionInfo.UnionPlayerList.Count; i++)
            {
                if (self.UnionInfo.UnionPlayerList[i].UserID == playerid)
                {
                    return self.UnionInfo.UnionPlayerList[i];
                }
            }

            return null;
        }

        public static void OnUpdateUI(this DlgUnionJingXuan self, UnionInfo unionInfo)
        {
            self.UnionInfo = unionInfo;

            // int number = 0;
            // for (int i = 0; i < unionInfo.JingXuanList.Count; i++)
            // {
            //     UnionPlayerInfo unionPlayerInfo = self.GetUnionPlayerInfo(unionInfo.JingXuanList[i]);
            //     if (unionPlayerInfo == null)
            //     {
            //         continue;
            //     }
            //
            //     UIUnionJingXuanItemComponent ui_1 = null;
            //     if (number < self.JingXuanItemList.Count)
            //     {
            //         ui_1 = self.JingXuanItemList[number];
            //         ui_1.GameObject.SetActive(true);
            //     }
            //     else
            //     {
            //         GameObject storeItem = GameObject.Instantiate(self.JingXuanItem);
            //         UICommonHelper.SetParent(storeItem, self.ItemNodeList);
            //         storeItem.SetActive(true);
            //         ui_1 = self.AddChild<UIUnionJingXuanItemComponent, GameObject>(storeItem);
            //         self.JingXuanItemList.Add(ui_1);
            //     }
            //
            //     ui_1.OnUpdateUI(i, unionPlayerInfo);
            //     number++;
            // }
            //
            // for (int i = number; i < self.JingXuanItemList.Count; i++)
            // {
            //     self.JingXuanItemList[i].GameObject.SetActive(false);
            // }
            //
            // Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            // bool haveself = unionInfo.JingXuanList.Contains(unit.Id);
            // self.View.E_ButtonConfirmButton.gameObject.SetActive(!haveself);
            // self.View.E_AlreadyJingXuan.SetActive(haveself);
        }
    }
}