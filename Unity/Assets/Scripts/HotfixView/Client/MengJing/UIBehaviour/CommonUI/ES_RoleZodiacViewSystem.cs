using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_RoleZodiac))]
    [FriendOfAttribute(typeof(ES_RoleZodiac))]
    public static partial class ES_RoleZodiacSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleZodiac self, Transform transform)
        {
            self.uiTransform = transform;
            
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleZodiac self)
        {
            self.DestroyWidget();
        }
        
        public static void OnUpdateUI(this ES_RoleZodiac self)
        {
        }
        
        private static void OnItemTypeSet(this ES_RoleZodiac self, int index)
        {
        }
        
        private static void OnBagItemsRefresh(this ES_RoleZodiac self, Transform transform, int index)
        {
            // Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            // scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.XiangQianBag,
            //     self.UpdateSelect);
        }
    }
}