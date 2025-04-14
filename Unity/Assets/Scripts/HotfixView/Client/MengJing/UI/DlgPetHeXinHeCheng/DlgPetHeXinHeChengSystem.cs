using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetHeXinHeChengViewComponent))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(DlgPetHeXinHeCheng))]
    public static class DlgPetHeXinHeChengSystem
    {
        public static void RegisterUIEvent(this DlgPetHeXinHeCheng self)
        {
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.View.E_Button_OneKeyButton.AddListener(self.OnButton_OneKeyButton);
            
            self.View.E_ImagePetHexinItemIconImage.gameObject.SetActive(false);

            self.View.E_PetHeXinListLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetHeXinListItemsRefresh);

            self.View.E_Btn_CloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetHeXinHeCheng);
            });
            self.View.E_Button_OneKeyButton.AddListenerAsync(self.Button_OneKey);

            self.OnUpdateItemList();
        }

        public static void ShowWindow(this DlgPetHeXinHeCheng self, Entity contextData = null)
        {
        }

        public static async ETTask Button_OneKey(this DlgPetHeXinHeCheng self)
        {
            int error = await PetNetHelper.RequestPetHeXinHeChengQuick(self.Root());

            if (error == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("宠物之核合成成功！"));
            }

            self.OnUpdateItemList();
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.OnEquipPetHeXin();
        }

        private static void OnUpdateItemList(this DlgPetHeXinHeCheng self)
        {
            self.ShowBagInfos.Clear();
            self.ShowBagInfos.AddRange(self.Root().GetComponent<BagComponentC>().GetItemsByLoc(ItemLocType.ItemPetHeXinBag));

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.View.E_PetHeXinListLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        private static void OnPetHeXinListItemsRefresh(this DlgPetHeXinHeCheng self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);

            scrollItemCommonItem.PointerDownHandler = (ItemInfo binfo, PointerEventData pdata) =>
            {
                self.PointerDown(binfo, pdata).Coroutine();
            };
            scrollItemCommonItem.PointerUpHandler = (ItemInfo binfo, PointerEventData pdata) => { self.PointerUp(binfo, pdata); };
            scrollItemCommonItem.BeginDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.BeginDrag(binfo, pdata); };
            scrollItemCommonItem.DragingHandler = (ItemInfo binfo, PointerEventData pdata) => { self.Draging(binfo, pdata); };
            scrollItemCommonItem.EndDragHandler = (ItemInfo binfo, PointerEventData pdata) => { self.EndDrag(binfo, pdata); };

            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None);

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.ShowBagInfos[index].ItemID);
            scrollItemCommonItem.HideItemName();
            scrollItemCommonItem.SetEventTrigger(true);
            using (zstring.Block())
            {
                scrollItemCommonItem.E_ItemNumText.text = zstring.Format("{0}级", itemConfig.UseLv);
                scrollItemCommonItem.uiTransform.GetChild(0).name =
                        zstring.Format("PetHeXinHeCheng_Image_ItemButton@{0}", self.ShowBagInfos[index].BagInfoID);
            }
        }

        private static async ETTask PointerDown(this DlgPetHeXinHeCheng self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = true;
            self.BagInfo = binfo;
            self.cancellationToken?.Cancel();
            self.cancellationToken = new ETCancellationToken();
            long instanceId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(200, self.cancellationToken);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            if (self.IsHoldDown)
            {
                EventSystem.Instance.Publish(self.Root(),
                    new ShowItemTips()
                    {
                        BagInfo = self.BagInfo,
                        ItemOperateEnum = ItemOperateEnum.None,
                        InputPoint = Input.mousePosition,
                        Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                        EquipList = new List<ItemInfo>()
                    });
            }
        }

        private static void PointerUp(this DlgPetHeXinHeCheng self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.BagInfo = null;
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
        }

        private static void BeginDrag(this DlgPetHeXinHeCheng self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.BagInfo = null;
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_ItemTips);
            self.BagItemCopy = UnityEngine.Object.Instantiate(self.View.E_ImagePetHexinItemIconImage.gameObject, self.View.uiTransform);
            self.BagItemCopy.SetActive(true);

            ItemConfig itemconfig = ItemConfigCategory.Instance.Get(binfo.ItemID);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemconfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.BagItemCopy.GetComponent<Image>().sprite = sp;
        }

        private static void Draging(this DlgPetHeXinHeCheng self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.BagInfo = null;
            Vector2 localPoint;
            RectTransform canvas = self.BagItemCopy.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.BagItemCopy.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        private static void EndDrag(this DlgPetHeXinHeCheng self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.BagInfo = null;
            RectTransform canvas = self.BagItemCopy.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("PetHeXinHeCheng_Image_ItemButton"))
                {
                    continue;
                }

                long baginfoId = long.Parse(name.Split('@')[1]);
                self.RequestPetHeXinHeCheng(binfo, self.Root().GetComponent<BagComponentC>().GetBagInfo(baginfoId)).Coroutine();
                break;
            }

            if (self.BagItemCopy != null)
            {
                UnityEngine.Object.Destroy(self.BagItemCopy);
                self.BagItemCopy = null;
            }
        }

        private static async ETTask RequestPetHeXinHeCheng(this DlgPetHeXinHeCheng self, ItemInfo bagInfo1, ItemInfo bagInfo2)
        {
            if (bagInfo1.BagInfoID == bagInfo2.BagInfoID)
            {
                return;
            }

            if (bagInfo1.ItemID != bagInfo2.ItemID)
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("同类型和同等级的宠物之核才能合成！"));
                return;
            }

            int error = await PetNetHelper.RequestPetHeXinHeCheng(self.Root(), bagInfo1.BagInfoID, bagInfo2.BagInfoID);

            if (error == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("宠物之核合成成功！"));
            }

            self.OnUpdateItemList();

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPet>()?.OnEquipPetHeXin();
        }
        public static void OnBtn_CloseButton(this DlgPetHeXinHeCheng self)
        {
        }
        public static void OnButton_OneKeyButton(this DlgPetHeXinHeCheng self)
        {
        }
    }
}
