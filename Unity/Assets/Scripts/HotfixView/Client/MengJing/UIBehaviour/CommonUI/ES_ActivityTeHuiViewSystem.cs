using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ActivityTeHui))]
    [FriendOfAttribute(typeof (ES_ActivityTeHui))]
    public static partial class ES_ActivityTeHuiSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityTeHui self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ActivityTeHuiItemsLoopHorizontalScrollRect.AddItemRefreshListener(self.OnActivityTeHuiItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivityTeHui self)
        {
            self.DestroyWidget();
        }

        private static void OnActivityTeHuiItemsRefresh(this ES_ActivityTeHui self, Transform transform, int index)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            Scroll_Item_ActivityTeHuiItem scrollItemActivityTeHuiItem = self.ScrollItemActivityTeHuiItems[index].BindTrans(transform);
            int activityId = activityComponent.DayTeHui[index];
            scrollItemActivityTeHuiItem.OnUpdateUI(activityId, activityComponent.ActivityReceiveIds.Contains(activityId));
        }

        public static void OnUpdateUI(this ES_ActivityTeHui self)
        {
            ActivityComponentC activityComponent = self.Root().GetComponent<ActivityComponentC>();
            // 测试数据
            if (activityComponent.DayTeHui.Count == 0)
            {
                activityComponent.DayTeHui = DayTeHuiHelper.GetDayTeHuiList(2, 60);
            }

            self.AddUIScrollItems(ref self.ScrollItemActivityTeHuiItems, activityComponent.DayTeHui.Count);
            self.E_ActivityTeHuiItemsLoopHorizontalScrollRect.SetVisible(true, activityComponent.DayTeHui.Count);
        }
    }
}