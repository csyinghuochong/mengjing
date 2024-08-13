using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ZuoQiShow))]
    [FriendOfAttribute(typeof (ES_ZuoQiShow))]
    public static partial class ES_ZuoQiShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ZuoQiShow self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ZuoQiShowItemsLoopHorizontalScrollRect.AddItemRefreshListener(self.OnZuoQiShowItemsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ZuoQiShow self)
        {
            self.DestroyWidget();
        }

        private static void OnZuoQiShowItemsRefresh(this ES_ZuoQiShow self, Transform transform, int index)
        {
            Scroll_Item_ZuoQiShowItem scrollItemZuoQiShowItem = self.ScrollItemZuoQiShowItems[index].BindTrans(transform);
            scrollItemZuoQiShowItem.OnInitUI(self.ShowZuoQiShowConfigs[index]);
        }

        public static void OnInitUI(this ES_ZuoQiShow self)
        {
            self.ShowZuoQiShowConfigs.Clear();
            self.ShowZuoQiShowConfigs.AddRange(ZuoQiShowConfigCategory.Instance.GetAll().Values.ToList());
            self.ShowZuoQiShowConfigs.Sort((a, b) => a.Quality - b.Quality);

            self.AddUIScrollItems(ref self.ScrollItemZuoQiShowItems, self.ShowZuoQiShowConfigs.Count);
            self.E_ZuoQiShowItemsLoopHorizontalScrollRect.SetVisible(true, self.ShowZuoQiShowConfigs.Count);
        }
    }
}
