using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JingXuanItem))]
    [FriendOf(typeof(DlgUnionJingXuan))]
    public static class DlgUnionJingXuanSystem
    {
        public static void RegisterUIEvent(this DlgUnionJingXuan self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
            self.View.E_ButtonConfirmButton.AddListener(() => { self.OnButtonConfirmButton(1).Coroutine(); });
            self.View.E_ButtonCancelButton.AddListener(self.OnButtonCancelButton);
            self.View.E_JingXuanItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJingXuanItemsRefresh);
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
            PopupTipHelp.OpenPopupTip(self.Root(), "取消申请", "是否确认取消申请会长?", () => { self.OnButtonConfirmButton(0).Coroutine(); }, null).Coroutine();
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

        private static void OnJingXuanItemsRefresh(this DlgUnionJingXuan self, Transform transform, int index)
        {
            foreach (Scroll_Item_JingXuanItem item in self.ScrollItemJingXuanItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JingXuanItem scrollItemJingXuanItem = self.ScrollItemJingXuanItems[index].BindTrans(transform);
            scrollItemJingXuanItem.OnUpdateUI(self.UnionPlayerInfos[index].Item1, self.UnionPlayerInfos[index].Item2);
        }

        public static void OnUpdateUI(this DlgUnionJingXuan self, UnionInfo unionInfo)
        {
            self.UnionInfo = unionInfo;

            self.UnionPlayerInfos.Clear();
            for (int i = 0; i < unionInfo.JingXuanList.Count; i++)
            {
                UnionPlayerInfo unionPlayerInfo = self.GetUnionPlayerInfo(unionInfo.JingXuanList[i]);
                if (unionPlayerInfo == null)
                {
                    continue;
                }

                self.UnionPlayerInfos.Add(new(i, unionPlayerInfo));
            }

            self.AddUIScrollItems(ref self.ScrollItemJingXuanItems, self.UnionPlayerInfos.Count);
            self.View.E_JingXuanItemsLoopVerticalScrollRect.SetVisible(true, self.UnionPlayerInfos.Count);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            bool haveself = unionInfo.JingXuanList.Contains(unit.Id);
            self.View.E_ButtonConfirmButton.gameObject.SetActive(!haveself);
            self.View.EG_AlreadyJingXuanRectTransform.gameObject.SetActive(haveself);
        }
    }
}