using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetCangKuDefend))]
    [FriendOf(typeof(Scroll_Item_PetCangKuItem))]
    [EntitySystemOf(typeof (ES_PetCangKu))]
    [FriendOfAttribute(typeof (ES_PetCangKu))]
    public static partial class ES_PetCangKuSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetCangKu self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_PetCangKuItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetCangKuItemsRefresh);
            self.E_PetCangKuDefendsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetCangKuDefendsRefresh);

            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetCangKu self)
        {
            self.DestroyWidget();
        }

        private static void OnPetCangKuItemsRefresh(this ES_PetCangKu self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetCangKuItem item in self.ScrollItemPetCangKuItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetCangKuItem scrollItemPetCangKuItem = self.ScrollItemPetCangKuItems[index].BindTrans(transform);
            scrollItemPetCangKuItem.OnUpdateUI(self.ShowRolePetInfos[index]);
        }

        private static void OnPetCangKuDefendsRefresh(this ES_PetCangKu self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetCangKuDefend item in self.ScrollItemPetCangKuDefends.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetCangKuDefend scrollItemPetCangKuDefend = self.ScrollItemPetCangKuDefends[index].BindTrans(transform);
            scrollItemPetCangKuDefend.SetAction(self.OnPetPutCangku);
            scrollItemPetCangKuDefend.OnUpdateUI(self.Root().GetComponent<UserInfoComponentC>().UserInfo.JiaYuanLv,
                self.ShowCangkuDefends[index].Item1, self.ShowCangkuDefends[index].Item2);
        }

        public static void OnInitUI(this ES_PetCangKu self)
        {
            self.UpdatePetCangKuDefend();
            self.UpdatePetCangKuItemList();
        }

        public static void UpdatePetCangKuDefend(this ES_PetCangKu self)
        {
            int openindex = 0;
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            self.ShowCangkuDefends.Clear();
            for (int i = 0; i < ConfigData.PetOpenCangKu.Count + 1; i++)
            {
                if (petComponent.PetCangKuOpen.Contains(i))
                {
                    openindex++;
                }

                self.ShowCangkuDefends.Add((i + 1, openindex));
            }

            self.AddUIScrollItems(ref self.ScrollItemPetCangKuDefends, self.ShowCangkuDefends.Count);
            self.E_PetCangKuDefendsLoopVerticalScrollRect.SetVisible(true, self.ShowCangkuDefends.Count);
        }

        public static void OnPetPutCangku(this ES_PetCangKu self)
        {
            self.UpdatePetCangKuDefend();
            self.UpdatePetCangKuItemList();
        }

        public static void UpdatePetCangKuItemList(this ES_PetCangKu self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < petComponent.RolePetInfos.Count; i++)
            {
                RolePetInfo rolePetInfo = petComponent.RolePetInfos[i];
                if (rolePetInfo.PetStatus != 0)
                {
                    continue;
                }

                self.ShowRolePetInfos.Add(rolePetInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetCangKuItems, self.ShowRolePetInfos.Count);
            self.E_PetCangKuItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }
    }
}
