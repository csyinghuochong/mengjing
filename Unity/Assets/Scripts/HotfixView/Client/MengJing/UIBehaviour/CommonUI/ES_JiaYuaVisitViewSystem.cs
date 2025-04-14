using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanVisitItem))]
    [EntitySystemOf(typeof(ES_JiaYuaVisit))]
    [FriendOfAttribute(typeof(ES_JiaYuaVisit))]
    public static partial class ES_JiaYuaVisitSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuaVisit self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_FunctionSetBtnToggleGroup.AddListener(self.OnClickPageButton);
            self.E_JiaYuanVisitItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanVisitItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuaVisit self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnInitUI(this ES_JiaYuaVisit self, int operateType)
        {
            JiaYuanComponentC jiaYuanComponent = self.Root().GetComponent<JiaYuanComponentC>();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            M2C_JiaYuanVisitListResponse response =
                    await JiaYuanNetHelper.JiaYuanVisitListRequest(self.Root(), jiaYuanComponent.MasterId, unit.Id, operateType);

            self.m2C_JiaYuanVisitList = response;
            self.OnClickPageButton(self.E_FunctionSetBtnToggleGroup.GetCurrentIndex());
        }

        private static void OnJiaYuanVisitItemsRefresh(this ES_JiaYuaVisit self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanVisitItem item in self.ScrollItemJiaYuanVisitItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanVisitItem scrollItemJiaYuanVisitItem = self.ScrollItemJiaYuanVisitItems[index].BindTrans(transform);
            scrollItemJiaYuanVisitItem.OnUpdateUI(self.Visits[index]);
        }

        public static void OnClickPageButton(this ES_JiaYuaVisit self, int page)
        {
            if (self.m2C_JiaYuanVisitList == null)
            {
                return;
            }

            bool blackroom = UnitHelper.IsBackRoom(self.Root());
            if (blackroom)
            {
                return;
            }

            self.Visits = page == 1 ? self.m2C_JiaYuanVisitList.JiaYuanVisit_1 : self.m2C_JiaYuanVisitList.JiaYuanVisit_2;

            self.AddUIScrollItems(ref self.ScrollItemJiaYuanVisitItems, self.Visits.Count);
            self.E_JiaYuanVisitItemsLoopVerticalScrollRect.SetVisible(true, self.Visits.Count);

            self.UpdateGatherTimes();
        }

        public static void UpdateGatherTimes(this ES_JiaYuaVisit self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            using (zstring.Block())
            {
                self.E_TextLimitText.text = zstring.Format("采摘:{0}/5\r\n打扫:{1}/5", numericComponent.GetAsInt(NumericType.JiaYuanGatherOther),
                    numericComponent.GetAsInt(NumericType.JiaYuanPickOther));
            }
        }
    }
}
