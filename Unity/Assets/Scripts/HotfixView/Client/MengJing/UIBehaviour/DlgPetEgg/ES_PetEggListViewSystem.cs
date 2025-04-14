using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_PetEggListItem))]
    [EntitySystemOf(typeof(ES_PetEggList))]
    [FriendOfAttribute(typeof(ES_PetEggList))]
    public static partial class ES_PetEggListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetEggList self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_BagItemsLoopHorizontalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.PetList.Add(self.ES_PetEggListItem_0);
            self.PetList.Add(self.ES_PetEggListItem_1);
            self.PetList.Add(self.ES_PetEggListItem_2);
            foreach (ES_PetEggListItem item in self.PetList)
            {
                item.BeginDragHandler = (binfo, pdata) => { self.PetEggBeginDrag(binfo, pdata); };
                item.DragingHandler = (binfo, pdata) => { self.PetEggDraging(binfo, pdata); };
                item.EndDragHandler = (binfo, pdata) => { self.PetEggEndDrag(binfo, pdata); };
            }

            self.EG_IconItemDargRectTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetEggList self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_PetEggList self)
        {
            self.UpdateEggItemUI();
            self.UpdatePetEggUI();
        }

        private static void OnBagItemsRefresh(this ES_PetEggList self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.SkillSet);
            scrollItemCommonItem.SetEventTrigger(true);
            scrollItemCommonItem.BeginDragHandler = (binfo, pdata) => { self.BeginDrag(binfo, pdata); };
            scrollItemCommonItem.DragingHandler = (binfo, pdata) => { self.Draging(binfo, pdata); };
            scrollItemCommonItem.EndDragHandler = (binfo, pdata) => { self.EndDrag(binfo, pdata); };
        }

        public static void UpdateEggItemUI(this ES_PetEggList self)
        {
            self.ShowBagInfos.Clear();
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemSubType == 102 && itemConfig.ItemType == 1)
                {
                    self.ShowBagInfos.Add(bagInfos[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopHorizontalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void UpdatePetEggUI(this ES_PetEggList self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            for (int i = 0; i < self.PetList.Count; i++)
            {
                ES_PetEggListItem esPetEggListItem = self.PetList[i];
                esPetEggListItem.OnUpdateUI(petComponent.RolePetEggs[i], i);
            }
        }

        public static void BeginDrag(this ES_PetEggList self, ItemInfo binfo, PointerEventData pdata)
        {
            self.EG_IconItemDargRectTransform.gameObject.SetActive(true);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(binfo.ItemID);
            GameObject icon = self.EG_IconItemDargRectTransform.Find("ImageIcon").gameObject;
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            icon.GetComponent<Image>().sprite = sp;
            CommonViewHelper.SetParent(self.EG_IconItemDargRectTransform.gameObject, self.uiTransform.parent.parent.gameObject);
        }

        public static void Draging(this ES_PetEggList self, ItemInfo binfo, PointerEventData pdata)
        {
            Vector2 localPoint;
            RectTransform canvas = self.uiTransform.parent.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.EG_IconItemDargRectTransform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        public static async ETTask RequestHatch(this ES_PetEggList self, int index, ItemInfo bagInfo)
        {
            ES_PetEggListItem esPetEggListItem = self.PetList[index];
            KeyValuePairLong oldEgg = esPetEggListItem.RolePetEgg;
            if (oldEgg != null && oldEgg.KeyId > 0)
            {
                return;
            }

            int error = await PetNetHelper.RequestPetEggPut(self.Root(), index, bagInfo.BagInfoID);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.UpdateEggItemUI();
            self.UpdatePetEggUI();
        }

        public static void EndDrag(this ES_PetEggList self, ItemInfo binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.uiTransform.parent.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("ES_PetEggListItem"))
                {
                    continue;
                }

                int index = int.Parse(name.Substring(name.Length - 1, 1));
                self.RequestHatch(index, binfo).Coroutine();
                break;
            }

            CommonViewHelper.SetParent(self.EG_IconItemDargRectTransform.gameObject, self.uiTransform.gameObject);
            self.EG_IconItemDargRectTransform.gameObject.SetActive(false);
        }

        public static void PetEggBeginDrag(this ES_PetEggList self, int binfo, PointerEventData pdata)
        {
            self.EG_IconItemDargRectTransform.gameObject.SetActive(true);
            self.EG_IconItemDargRectTransform.localScale = Vector3.one * 2f;
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get((int)petComponent.RolePetEggs[binfo].KeyId);
            GameObject icon = self.EG_IconItemDargRectTransform.Find("ImageIcon").gameObject;
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            icon.GetComponent<Image>().sprite = sp;
            CommonViewHelper.SetParent(self.EG_IconItemDargRectTransform.gameObject, self.uiTransform.parent.parent.gameObject);
        }

        public static void PetEggDraging(this ES_PetEggList self, int binfo, PointerEventData pdata)
        {
            Vector2 localPoint;
            RectTransform canvas = self.EG_IconItemDargRectTransform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            self.EG_IconItemDargRectTransform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
        }

        public static async ETTask RequestXieXia(this ES_PetEggList self, int binfo)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足！");
                return;
            }

            int error = await PetNetHelper.RequestPetEggPutOut(self.Root(), binfo);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.UpdateEggItemUI();
            self.UpdatePetEggUI();
        }

        public static void PetEggEndDrag(this ES_PetEggList self, int binfo, PointerEventData pdata)
        {
            RectTransform canvas = self.EG_IconItemDargRectTransform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("RolePetEggUIItem"))
                {
                    continue;
                }

                self.RequestXieXia(binfo).Coroutine();
                break;
            }

            CommonViewHelper.SetParent(self.EG_IconItemDargRectTransform.gameObject, self.UITransform.gameObject);
            self.EG_IconItemDargRectTransform.gameObject.SetActive(false);
        }
    }
}
