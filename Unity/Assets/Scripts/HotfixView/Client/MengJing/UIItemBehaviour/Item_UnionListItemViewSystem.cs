using System;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionListItem))]
    [EntitySystemOf(typeof(Scroll_Item_UnionListItem))]
    public static partial class Scroll_Item_UnionListItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_UnionListItem self)
        {
          
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_UnionListItem self)
        {
            self.DestroyWidget();
        }

        private static void OnClick(this Scroll_Item_UnionListItem self)
        {
            self.ClickCallback?.Invoke(self.UnionListItem);     
        }

        public static void SetSelected(this Scroll_Item_UnionListItem self, long unionid)
        {
            self.E_ImageHighLight.gameObject.SetActive(self.UnionListItem.UnionId == unionid);    
        }

        public static void Refresh(this Scroll_Item_UnionListItem self, UnionListItem unionListItem, Action<UnionListItem> clickCallback)
        {
            self.UnionListItem = unionListItem;
            self.ClickCallback = clickCallback;
            self.E_ImageHighLight.gameObject.SetActive(false);
            unionListItem.UnionLevel = Math.Max(unionListItem.UnionLevel, 1);
            int peopleMax = UnionConfigCategory.Instance.Get(unionListItem.UnionLevel).PeopleNum;
            self.E_ButtonImageDI.AddListener(self.OnClick);

            using (zstring.Block())
            {
                self.E_Text_NumberText.text = zstring.Format("人数 {0}/{1}", unionListItem.PlayerNumber, peopleMax);
            }

            self.E_Text_NameText.text = unionListItem.UnionName;
            self.E_Text_LeaderText.text = unionListItem.UnionLeader;
            self.E_Text_LevelText.text = unionListItem.UnionLevel.ToString();
        }
    }
}