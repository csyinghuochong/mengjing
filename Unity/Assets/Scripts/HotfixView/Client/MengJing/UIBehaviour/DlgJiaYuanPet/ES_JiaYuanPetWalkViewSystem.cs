using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanPetWalkItem))]
    [EntitySystemOf(typeof (ES_JiaYuanPetWalk))]
    [FriendOfAttribute(typeof (ES_JiaYuanPetWalk))]
    public static partial class ES_JiaYuanPetWalkSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanPetWalk self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_JiaYuanPetWalkItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnJiaYuanPetWalkItemsRefresh);
            
            self.OnUpdateUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanPetWalk self)
        {
            self.DestroyWidget();
        }

        public static async ETTask PetItemSelect(this ES_JiaYuanPetWalk self, string dataParams)
        {
            string[] paramsList = dataParams.Split('@');
            long petId = long.Parse(paramsList[1]);
            RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId);

            int lv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;

            if (self.Position == 1 && lv < 10)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }

            if (self.Position == 2 && lv < 20)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }

            C2M_JiaYuanPetWalkRequest request = new() { PetStatus = 2, PetId = rolePetInfo.Id, Position = self.Position };
            M2C_JiaYuanPetWalkResponse response = (M2C_JiaYuanPetWalkResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<JiaYuanComponentC>().JiaYuanPetList_2 = response.JiaYuanPetList;
            self.OnUpdateUI();
        }

        public static void OnClickButtonAdd(this ES_JiaYuanPetWalk self, int position)
        {
            self.Position = position;
        }

        public static void OnClickButtonStop(this ES_JiaYuanPetWalk self)
        {
            self.OnUpdateUI();
        }

        private static void OnJiaYuanPetWalkItemsRefresh(this ES_JiaYuanPetWalk self, Transform transform, int index)
        {
            foreach (Scroll_Item_JiaYuanPetWalkItem item in self.ScrollItemJiaYuanPetWalkItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_JiaYuanPetWalkItem scrollItemJiaYuanPetWalkItem = self.ScrollItemJiaYuanPetWalkItems[index].BindTrans(transform);

            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            scrollItemJiaYuanPetWalkItem.SetClickAddHandler(self.OnClickButtonAdd);
            scrollItemJiaYuanPetWalkItem.SetClickStopHandler(self.OnClickButtonStop);
            scrollItemJiaYuanPetWalkItem.Position = index;

            JiaYuanPet jiaYuanPet = jiaYuanComponentC.GetJiaYuanPetGetPosition(index);
            if (jiaYuanPet != null && jiaYuanPet.unitId != 0)
            {
                scrollItemJiaYuanPetWalkItem.OnUpdateUI(petComponent.GetPetInfoByID(jiaYuanPet.unitId), jiaYuanPet);
            }
            else
            {
                scrollItemJiaYuanPetWalkItem.OnUpdateUI(null, null);
            }
        }

        public static void OnUpdateUI(this ES_JiaYuanPetWalk self)
        {
            self.AddUIScrollItems(ref self.ScrollItemJiaYuanPetWalkItems, 3);
            self.E_JiaYuanPetWalkItemsLoopVerticalScrollRect.SetVisible(true, 3);
        }
    }
}
