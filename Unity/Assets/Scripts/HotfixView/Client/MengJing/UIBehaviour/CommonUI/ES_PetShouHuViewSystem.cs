using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_PetShouHu))]
    [FriendOfAttribute(typeof (ES_PetShouHu))]
    public static partial class ES_PetShouHuSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetShouHu self, Transform transform)
        {
            self.uiTransform = transform;

            self.ShouhuInfos.Add(self.ES_ShouhuInfo0);
            self.ShouhuInfos.Add(self.ES_ShouhuInfo1);
            self.ShouhuInfos.Add(self.ES_ShouhuInfo2);
            self.ShouhuInfos.Add(self.ES_ShouhuInfo3);
            self.E_PetShouHuItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetShouHuItemsRefresh);
            self.E_ButtonSetButton.AddListenerAsync(self.OnButtonSet);

            self.ShouhuInfos[0].OnClickButton();
            self.OnUpdateUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetShouHu self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonSet(this ES_PetShouHu self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            C2M_PetShouHuActiveRequest request = new C2M_PetShouHuActiveRequest() { PetShouHuActive = self.SelectIndex + 1 };
            M2C_PetShouHuActiveResponse response =
                    (M2C_PetShouHuActiveResponse)await self.Root().GetComponent<SessionComponent>().Session.Call(request);
            if (self.IsDisposed || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            petComponent.PetShouHuActive = response.PetShouHuActive;
            self.SetShouHuActive(petComponent.PetShouHuActive - 1);
            FlyTipComponent.Instance.SpawnFlyTipDi($"激活: {ConfigData.PetShouHuAttri[petComponent.PetShouHuActive - 1].Value}");
        }

        public static async ETTask OnButtonShouHuHandler(this ES_PetShouHu self, long petid)
        {
            C2M_PetShouHuRequest request = new C2M_PetShouHuRequest() { PetInfoId = petid, Position = self.SelectIndex };
            M2C_PetShouHuResponse response = (M2C_PetShouHuResponse)await self.Root().GetComponent<SessionComponent>().Session.Call(request);

            self.Root().GetComponent<PetComponentC>().PetShouHuList = response.PetShouHuList;

            self.OnUpdateUI();
        }

        private static void OnPetShouHuItemsRefresh(this ES_PetShouHu self, Transform transform, int index)
        {
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
                self.ShouhuInfos[i].E_ImageSelectImage.gameObject.SetActive(i == index);
            }
        }

        public static void SetShouHuActive(this ES_PetShouHu self, int index)
        {
            for (int i = 0; i < self.ShouhuInfos.Count; i++)
            {
                self.ShouhuInfos[i].E_ImageActiveImage.gameObject.SetActive(i == index);
            }
        }

        public static void UpdateShouwHuInfo(this ES_PetShouHu self)
        {
            for (int i = 0; i < self.ShouhuInfos.Count; i++)
            {
                self.ShouhuInfos[i].OnUpdateUI(i);
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