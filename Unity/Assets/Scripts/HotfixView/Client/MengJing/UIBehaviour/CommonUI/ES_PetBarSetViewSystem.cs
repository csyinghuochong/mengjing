using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetBarSet))]
    [FriendOfAttribute(typeof(ES_PetBarSet))]
    public static partial class ES_PetBarSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetBarSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_PlanSetToggleGroup.AddListener(self.OnPlanSet);
            self.E_PetTypeSetToggleGroup.AddListener(self.OnPetTypeSet);
            self.E_PetbarSetPetItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetBarSetItemsRefresh);
            self.E_ConfirmButton.AddListenerAsync(self.OnConfirm);

            self.E_PlanSetToggleGroup.OnSelectIndex(0);
            self.E_PetTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarSet self)
        {
            self.DestroyWidget();
        }

        private static void OnPlanSet(this ES_PetBarSet self, int index)
        {
        }

        private static void OnPetTypeSet(this ES_PetBarSet self, int index)
        {
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                if (index == 0)
                {
                    self.ShowRolePetInfos.Add(rolePetInfos[i]);
                    continue;
                }

                PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfos[i].ConfigId);
                if (petConfig.AttackType + 1 == index)
                {
                    self.ShowRolePetInfos.Add(rolePetInfos[i]);
                    continue;
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemPetbarSetPetItems, self.ShowRolePetInfos.Count);
            self.E_PetbarSetPetItemsLoopVerticalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }

        private static void OnPetBarSetItemsRefresh(this ES_PetBarSet self, Transform transform, int index)
        {
            Scroll_Item_PetbarSetPetItem item = self.ScrollItemPetbarSetPetItems[index].BindTrans(transform);

            item.E_TouchEventTrigger.gameObject.SetActive(false);
            item.E_TouchEventTrigger.triggers.Clear();
            item.E_TouchEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointerDown(pdata as PointerEventData); });
            item.E_TouchEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.OnBeginDrag(pdata as PointerEventData, index); });
            item.E_TouchEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.OnDraging(pdata as PointerEventData); });
            item.E_TouchEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.OnPointerUp(pdata as PointerEventData, index); });
            item.E_TouchEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.OnEndDrag(pdata as PointerEventData, index); });
            item.E_TouchEventTrigger.gameObject.SetActive(true);
            item.OnInitUI(self.ShowRolePetInfos[index]);
        }

        private static void OnPointerDown(this ES_PetBarSet self, PointerEventData pdata)
        {
            self.ClickTime = TimeHelper.ServerNow();
        }

        private static void OnBeginDrag(this ES_PetBarSet self, PointerEventData pdata, int index1)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= 500)
            {
                self.IsDrag = false;
                self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnBeginDrag(pdata);
            }
            else
            {
                self.IsDrag = true;
                self.E_IconImage.gameObject.SetActive(true);
                Scroll_Item_PetbarSetPetItem item = self.ScrollItemPetbarSetPetItems[index1];
                self.E_IconImage.sprite = item.E_IconImage.sprite;
            }
        }

        private static void OnDraging(this ES_PetBarSet self, PointerEventData pdata)
        {
            if (self.IsDrag)
            {
                Vector2 localPoint = new Vector3();
                RectTransform canvas = self.E_IconImage.transform.parent.GetComponent<RectTransform>();
                Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
                self.E_IconImage.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
            }
            else
            {
                self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnDrag(pdata);
            }
        }

        private static void OnPointerUp(this ES_PetBarSet self, PointerEventData pdata, int index1)
        {
            if (TimeHelper.ServerNow() - self.ClickTime <= 200)
            {
                self.OnClick(index1);
            }

            self.ClickTime = 0;
        }

        private static void OnEndDrag(this ES_PetBarSet self, PointerEventData pdata, int index1)
        {
            if (self.IsDrag)
            {
                RectTransform canvas = self.E_IconImage.transform.parent.GetComponent<RectTransform>();
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

                    // self.ChangePos(index1, index2);

                    break;
                }

                self.E_IconImage.gameObject.SetActive(false);
            }
            else
            {
                self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnEndDrag(pdata);
            }
        }

        private static void OnClick(this ES_PetBarSet self, int index1)
        {
        }

        private static async ETTask OnConfirm(this ES_PetBarSet self)
        {
            await ETTask.CompletedTask;
        }
    }
}