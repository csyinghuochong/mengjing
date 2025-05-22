using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ActivityTokenItem))]
    [EntitySystemOf(typeof(ES_ActivityToken))]
    [FriendOfAttribute(typeof(ES_ActivityToken))]
    public static partial class ES_ActivityTokenSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityToken self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_GoPayButton.AddListener(self.OnBtn_GoPayButton);
            self.E_ActivityTokenItemsLoopHorizontalScrollRect.AddItemRefreshListener(self.OnActivityTokenItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivityToken self)
        {
            self.DestroyWidget();
        }

        private static void OnActivityTokenItemsRefresh(this ES_ActivityToken self, Transform transform, int index)
        {
            foreach (Scroll_Item_ActivityTokenItem item in self.ScrollItemActivityTokenItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_ActivityTokenItem scrollItemActivityTokenItem = self.ScrollItemActivityTokenItems[index].BindTrans(transform);
            scrollItemActivityTokenItem.OnInitUI(self.ShowActivityConfigs[index]);
        }

        public static void OnBtn_GoPayButton(this ES_ActivityToken self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Recharge).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Activity);
        }

        public static void OnInitUI(this ES_ActivityToken self)
        {
            self.ShowActivityConfigs.Clear();
            List<ActivityConfig> activityConfigs = ActivityConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < activityConfigs.Count; i++)
            {
                if (activityConfigs[i].ActivityType != 24)
                {
                    continue;
                }

                self.ShowActivityConfigs.Add(activityConfigs[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemActivityTokenItems, self.ShowActivityConfigs.Count);
            self.E_ActivityTokenItemsLoopHorizontalScrollRect.SetVisible(true, self.ShowActivityConfigs.Count);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int selfRechage = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber);
            using (zstring.Block())
            {
                self.E_TextRechargeText.text = zstring.Format("当前额度：{0}/298", selfRechage);
            }

            self.E_TextRechargeText.gameObject.SetActive(selfRechage < 298);
            
            CommonViewHelper.SetImageGrayAllChild( self.Root(),  self.E_Image98Image.gameObject,  selfRechage < 98);
            CommonViewHelper.SetImageGrayAllChild( self.Root(),  self.E_Image298Image.gameObject,  selfRechage < 298);
        }
    }
}
