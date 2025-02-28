using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_ActivitySingInVIP))]
    [FriendOf(typeof(ES_ActivitySingInFree))]
    [FriendOf(typeof(Scroll_Item_ActivitySingInItem))]
    [EntitySystemOf(typeof(ES_ActivitySingIn))]
    [FriendOfAttribute(typeof(ES_ActivitySingIn))]
    public static partial class ES_ActivitySingInSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivitySingIn self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_TypeSetToggleGroup.AddListener(self.OnTypeSet);

            self.E_TypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivitySingIn self)
        {
            self.DestroyWidget();
        }

        private static void OnTypeSet(this ES_ActivitySingIn self, int page)
        {
            CommonViewHelper.HideChildren(self.EG_PanelRootRectTransform);
            if (page == 0)
            {
                self.ES_ActivitySingInFree.uiTransform.gameObject.SetActive(true);
            }
            else
            {
                self.ES_ActivitySingInVip.uiTransform.gameObject.SetActive(true);
            }
        }
    }
}