using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionMysteryItem_A))]
    [EntitySystemOf(typeof(ES_UnionMystery_A))]
    [FriendOfAttribute(typeof(ES_UnionMystery_A))]
    public static partial class ES_UnionMystery_ASystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionMystery_A self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_UnionMysteryItemAsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionMysteryItemsRefresh);

            self.RequestMystery().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionMystery_A self)
        {
            self.DestroyWidget();
        }

        private static void OnUnionMysteryItemsRefresh(this ES_UnionMystery_A self, Transform transform, int index)
        {
            foreach (Scroll_Item_UnionMysteryItem_A item in self.ScrollItemUnionMysteryItemAs.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_UnionMysteryItem_A scrollItemUnionMysteryItemA = self.ScrollItemUnionMysteryItemAs[index].BindTrans(transform);
            scrollItemUnionMysteryItemA.OnUpdateUI(self.ShowMysteryItemInfos[index]);
        }

        public static void UpdateMysteryItem(this ES_UnionMystery_A self, List<MysteryItemInfo> mysteryItemInfos)
        {
            self.ShowMysteryItemInfos = mysteryItemInfos;
            self.AddUIScrollItems(ref self.ScrollItemUnionMysteryItemAs, self.ShowMysteryItemInfos.Count);
            self.E_UnionMysteryItemAsLoopVerticalScrollRect.SetVisible(true, self.ShowMysteryItemInfos.Count);
        }

        public static async ETTask RequestMystery(this ES_UnionMystery_A self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long unionId = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.UnionId_0);
            U2C_UnionMysteryListResponse response = await UnionNetHelper.UnionMysteryListRequest(self.Root(), unionId);
            self.UpdateMysteryItem(response.MysteryItemInfos);
        }
    }
}