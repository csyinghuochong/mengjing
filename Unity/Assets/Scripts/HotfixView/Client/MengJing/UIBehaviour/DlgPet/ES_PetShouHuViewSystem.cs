using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetShouHuItem))]
    [FriendOf(typeof(ES_ShouhuInfo))]
    [EntitySystemOf(typeof(ES_PetShouHu))]
    [FriendOfAttribute(typeof(ES_PetShouHu))]
    public static partial class ES_PetShouHuSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetShouHu self, Transform transform)
        {
            self.uiTransform = transform;

            self.ES_ShouhuInfo0.SetSelectHandler(0, self.OnSetSelectHandler);
            self.ES_ShouhuInfo1.SetSelectHandler(1, self.OnSetSelectHandler);
            self.ES_ShouhuInfo2.SetSelectHandler(2, self.OnSetSelectHandler);
            self.ES_ShouhuInfo3.SetSelectHandler(3, self.OnSetSelectHandler);

            self.ShouhuInfos.Add(self.ES_ShouhuInfo0);
            self.ShouhuInfos.Add(self.ES_ShouhuInfo1);
            self.ShouhuInfos.Add(self.ES_ShouhuInfo2);
            self.ShouhuInfos.Add(self.ES_ShouhuInfo3);
            self.E_PetShouHuItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetShouHuItemsRefresh);
            self.E_ButtonSetButton.AddListenerAsync(self.OnButtonSetButton);

            ES_ShouhuInfo esShouhuInfo = self.ShouhuInfos[0];
            esShouhuInfo.OnImageButtonButton();
            self.OnUpdateUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetShouHu self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonSetButton(this ES_PetShouHu self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            int error = await PetNetHelper.RequestPetShouHuActive(self.Root(), self.SelectIndex + 1);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.SetShouHuActive(petComponent.PetShouHuActive - 1);
            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("激活: {0}", ConfigData.PetShouHuAttri[petComponent.PetShouHuActive - 1].Value));
            }
        }

        public static async ETTask OnButtonShouHuHandler(this ES_PetShouHu self, long petid)
        {
            await PetNetHelper.RequestPetShouHu(self.Root(), petid, self.SelectIndex);

            self.OnUpdateUI();
        }

        private static void OnPetShouHuItemsRefresh(this ES_PetShouHu self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetShouHuItem item in self.ScrollItemPetShouHuItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetShouHuItem scrollItemPetShouHuItem = self.ScrollItemPetShouHuItems[index].BindTrans(transform);
            scrollItemPetShouHuItem.SetButtonShouHuHandler((long petid) => { self.OnButtonShouHuHandler(petid).Coroutine(); });
            scrollItemPetShouHuItem.OnInitUI(self.ShowRolePetInfos[index]);
        }

        public static void UpdatePetList(this ES_PetShouHu self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();

            self.ShowRolePetInfos.Clear();
            self.ShowRolePetInfos.AddRange(petComponent.RolePetInfos);

            self.AddUIScrollItems(ref self.ScrollItemPetShouHuItems, self.ShowRolePetInfos.Count);
            self.E_PetShouHuItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }

        public static void OnSetSelectHandler(this ES_PetShouHu self, int index)
        {
            self.SelectIndex = index;

            for (int i = 0; i < self.ShouhuInfos.Count; i++)
            {
                ES_ShouhuInfo esShouhuInfo = self.ShouhuInfos[i];
                esShouhuInfo.E_ImageSelectImage.gameObject.SetActive(i == index);
            }
        }

        public static void SetShouHuActive(this ES_PetShouHu self, int index)
        {
            for (int i = 0; i < self.ShouhuInfos.Count; i++)
            {
                ES_ShouhuInfo esShouhuInfo = self.ShouhuInfos[i];
                esShouhuInfo.E_ImageActiveImage.gameObject.SetActive(i == index);
            }
        }

        public static void UpdateShouwHuInfo(this ES_PetShouHu self)
        {
            for (int i = 0; i < self.ShouhuInfos.Count; i++)
            {
                ES_ShouhuInfo esShouhuInfo = self.ShouhuInfos[i];
                esShouhuInfo.OnUpdateUI(i);
            }
        }

        public static void OnUpdateUI(this ES_PetShouHu self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            self.UpdatePetList();
            self.UpdateShouwHuInfo();
            self.SetShouHuActive(petComponent.PetShouHuActive - 1);
        }
    }
}
