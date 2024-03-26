using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PetListItem))]
    [FriendOf(typeof (PetComponentC))]
    [EntitySystemOf(typeof (ES_PetList))]
    [FriendOfAttribute(typeof (ES_PetList))]
    public static partial class ES_PetListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetList self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_PetListItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetListItemsRefresh);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetList self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_PetList self)
        {
            self.PetSkinId = 0;
            self.LastSelectItem = null;

            self.RefreshCreateRoleItems();
        }

        private static void OnPetListItemsRefresh(this ES_PetList self, Transform transform, int index)
        {
            Scroll_Item_PetListItem scrollItemPetListItem = self.ScrollItemPetListItems[index].BindTrans(transform);
            scrollItemPetListItem.SetClickHandler((long petId) => { self.OnClickPetHandler(petId); });

            scrollItemPetListItem.E_ImageDiButtonButton.gameObject.SetActive(false);
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.gameObject.SetActive(true);
            int i1 = index;
            scrollItemPetListItem.uiTransform.gameObject.name = $"UIPetListItem_{i1}";

            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.OnPointerDown(pdata as PointerEventData); });
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.OnPointerUp(pdata as PointerEventData, i1); });
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.BeginDrag,
                (pdata) => { self.OnBeginDrag(pdata as PointerEventData, i1); });
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.Drag,
                (pdata) => { self.OnDraging(pdata as PointerEventData); });
            scrollItemPetListItem.E_ImageDiEventTriggerEventTrigger.RegisterEvent(EventTriggerType.EndDrag,
                (pdata) => { self.OnEndDrag(pdata as PointerEventData, i1); });

            scrollItemPetListItem.OnInitData(self.ShowRolePetInfos[index], self.NextPetNumber());
        }

        private static void RefreshCreateRoleItems(this ES_PetList self)
        {
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                if (rolePetInfos[i].PetStatus != 3)
                {
                    self.ShowRolePetInfos.Add(rolePetInfos[i]);
                }
            }

            int nextLv = self.NextPetNumber();
            if (nextLv > 0)
            {
                self.ShowRolePetInfos.Add(null);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetListItems, self.ShowRolePetInfos.Count);
            self.E_PetListItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);

            if (self.ShowRolePetInfos.Count > 0)
            {
                self.EG_RightRectTransform.gameObject.SetActive(true);
                self.EG_GameObject2RectTransform.gameObject.SetActive(false);
                self.ScrollItemPetListItems[0].OnClickPetItem();
            }
            else
            {
                self.EG_RightRectTransform.gameObject.SetActive(false);
                self.EG_GameObject2RectTransform.gameObject.SetActive(true);
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber));
            self.E_Text_PetNumberText.text = $"{PetHelper.GetBagPetNum(rolePetInfos)}/{maxNum}";
        }

        private static int NextPetNumber(this ES_PetList self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int level = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            int curNumber = PetHelper.GetBagPetNum(self.Root().GetComponent<PetComponentC>().RolePetInfos);
            if (curNumber < PetHelper.GetPetMaxNumber(level, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber)))
            {
                return 0;
            }

            string[] petInfos = GlobalValueConfigCategory.Instance.Get(34).Value.Split('@');
            for (int i = 0; i < petInfos.Length; i++)
            {
                string[] petNumber = petInfos[i].Split(';');
                if (level < int.Parse(petNumber[0]))
                {
                    return int.Parse(petNumber[0]);
                }
            }

            return 0;
        }

        private static void OnClickPetHandler(this ES_PetList self, long petId)
        {
            if (self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId) == null)
            {
                return;
            }

            self.PetSkinId = 0;
            self.LastSelectItem = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(petId);
            // self.UIPageButton.OnSelectIndex(0);
            // self.OnChangeNode(1);
            // self.OnUpdatePetInfo(self.LastSelectItem);
            // self.UpdatePetModel(self.LastSelectItem);
            // self.UpdatePetSelected(self.LastSelectItem);
            // self.UpdatePetHeXin(self.LastSelectItem);
            // self.JiBanBtn.SetActive(PetHelper.IsShenShou(self.LastSelectItem.ConfigId));
        }

        private static void OnPointerDown(this ES_PetList self, PointerEventData pdata)
        {
            self.ClickTime = TimeHelper.ServerNow();
            self.IsChange = false;
        }

        private static void OnPointerUp(this ES_PetList self, PointerEventData pdata, int index1)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= 200)
            {
                self.OnClick(index1);
            }

            self.ClickTime = 0;
        }

        private static void OnBeginDrag(this ES_PetList self, PointerEventData pdata, int index1)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= 500)
            {
                self.IsChange = false;
                self.E_PetListItemsLoopVerticalScrollRect.OnBeginDrag(pdata);
            }
            else
            {
                self.IsChange = true;
                self.EG_MaskRectTransform.gameObject.SetActive(true);
                self.EG_MaskRectTransform.transform.Find("Img_PetIcon").GetComponent<Image>().sprite =
                        self.ScrollItemPetListItems[index1].E_Img_PetHeroIonImage.sprite;
                self.EG_MaskRectTransform.transform.SetParent(self.Root().GetComponent<GlobalComponent>().PopUpRoot);
                self.EG_MaskRectTransform.transform.localScale = Vector3.one;
            }
        }

        private static void OnDraging(this ES_PetList self, PointerEventData pdata)
        {
            if (self.IsChange)
            {
                if (self.EG_MaskRectTransform == null)
                {
                    return;
                }

                Vector2 localPoint = new Vector3();
                RectTransform canvas = self.EG_MaskRectTransform.transform.parent.GetComponent<RectTransform>();
                Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

                self.EG_MaskRectTransform.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
            }
            else
            {
                self.E_PetListItemsLoopVerticalScrollRect.OnDrag(pdata);
            }
        }

        private static void OnEndDrag(this ES_PetList self, PointerEventData pdata, int index1)
        {
            if (self.IsChange)
            {
                if (self.EG_MaskRectTransform == null)
                {
                    return;
                }

                RectTransform canvas = self.EG_MaskRectTransform.transform.parent.GetComponent<RectTransform>();
                GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
                List<RaycastResult> results = new List<RaycastResult>();
                gr.Raycast(pdata, results);

                for (int i = 0; i < results.Count; i++)
                {
                    string name = results[i].gameObject.name;
                    if (!name.Contains("ImageDiEventTrigger"))
                    {
                        continue;
                    }

                    name = results[i].gameObject.transform.parent.parent.name;

                    int index2 = int.Parse(name.Substring(14, name.Length - 14));

                    self.ChangePos(index1, index2);

                    break;
                }

                self.EG_MaskRectTransform.transform.SetParent(self.uiTransform);
                self.EG_MaskRectTransform.gameObject.SetActive(false);
            }
            else
            {
                self.E_PetListItemsLoopVerticalScrollRect.OnEndDrag(pdata);
            }
        }

        private static void OnClick(this ES_PetList self, int index)
        {
            self.ScrollItemPetListItems[index].OnClickPetItem();
        }

        private static void ChangePos(this ES_PetList self, int index1, int index2)
        {
            if (index1 == index2)
            {
                return;
            }

            long petId1 = self.ScrollItemPetListItems[index1].PetId;
            long petId2 = self.ScrollItemPetListItems[index2].PetId;

            if (petId1 == 0 || petId2 == 0)
            {
                return;
            }

            RolePetInfo rolePetInfo1 = null;
            RolePetInfo rolePetInfo2 = null;
            int petIndex1 = 0;
            int petIndex2 = 0;
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            for (int i = 0; i < petComponentC.RolePetInfos.Count; i++)
            {
                if (petComponentC.RolePetInfos[i].Id == petId1)
                {
                    rolePetInfo1 = petComponentC.RolePetInfos[i];
                    petIndex1 = i;
                }

                if (petComponentC.RolePetInfos[i].Id == petId2)
                {
                    rolePetInfo2 = petComponentC.RolePetInfos[i];
                    petIndex2 = i;
                }
            }

            if (rolePetInfo1 == null || rolePetInfo2 == null)
            {
                return;
            }

            petComponentC.RolePetInfos[petIndex1] = rolePetInfo2;
            petComponentC.RolePetInfos[petIndex2] = rolePetInfo1;

            PetNetHelper.RequestChangePos(self.Root(), petIndex1, petIndex2).Coroutine();

            self.OnUpdateUI();
        }
    }
}