using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [Invoke(TimerInvokeType.UIPetMeleeMain)]
    public class UIPetMeleeMain : ATimer<DlgPetMeleeMain>
    {
        protected override void Run(DlgPetMeleeMain self)
        {
            try
            {
                self.Update();
            }
            catch (Exception e)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("move timer error: {0}\n{1}", self.Id, e.ToString()));
                }
            }
        }
    }

    [FriendOf(typeof(DlgPetMeleeMain))]
    public static class DlgPetMeleeMainSystem
    {
        public static void RegisterUIEvent(this DlgPetMeleeMain self)
        {
            self.View.E_PetMeleeItemsLoopHorizontalScrollRect.AddItemRefreshListener(self.OnPetMeleeItemsRefresh);
            self.View.E_CancelButton.AddListener(self.OnCancel);
        }

        public static void ShowWindow(this DlgPetMeleeMain self, Entity contextData = null)
        {
            self.View.E_CancelButton.gameObject.SetActive(false);
            self.RefreshItems();
        }

        public static void BeforeUnload(this DlgPetMeleeMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void Update(this DlgPetMeleeMain self)
        {
            if (InputHelper.Check_GetMouseButtonDown0())
            {
                if (GameObject.Find("Global").GetComponent<Init>().EditorMode)
                {
                    if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }
                }
                else
                {
                    if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        return;
                    }
                }

                if (self.IsPointerOverGameObject(Input.mousePosition))
                {
                    return;
                }

                RaycastHit raycastHit;
                Ray Ray = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                bool hit = Physics.Raycast(Ray, out raycastHit, 100, 1 << LayerMask.NameToLayer(LayerEnum.Map.ToString()));
                if (!hit)
                {
                    return;
                }

                if (raycastHit.collider == null || raycastHit.collider.gameObject == null)
                {
                    return;
                }

                // 发送放置消息
                FlyTipComponent.Instance.ShowFlyTip($"准备放置宠物 位置：{raycastHit.point}");

                self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
                self.View.E_CancelButton.gameObject.SetActive(false);
            }
        }

        private static bool IsPointerOverGameObject(this DlgPetMeleeMain self, Vector2 mousePosition)
        {
            //创建一个点击事件
            PointerEventData eventData = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
            eventData.position = mousePosition;
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            //向点击位置发射一条射线，检测是否点击UI
            UnityEngine.EventSystems.EventSystem.current.RaycastAll(eventData, raycastResults);
            if (raycastResults.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void RefreshItems(this DlgPetMeleeMain self)
        {
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                if (rolePetInfos[i].PetStatus == 0)
                {
                    self.ShowRolePetInfos.Add(rolePetInfos[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemPetMeleeItems, self.ShowRolePetInfos.Count);
            self.View.E_PetMeleeItemsLoopHorizontalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }

        private static void OnPetMeleeItemsRefresh(this DlgPetMeleeMain self, Transform transform, int index)
        {
            Scroll_Item_PetMeleeItem scrollItemPetMeleeItem = self.ScrollItemPetMeleeItems[index].BindTrans(transform);
            scrollItemPetMeleeItem.Refresh(self.ShowRolePetInfos[index]);
        }

        public static void OnClickItem(this DlgPetMeleeMain self, RolePetInfo rolePetInfo)
        {
            FlyTipComponent.Instance.ShowFlyTip($"选中宠物{rolePetInfo.Id}");

            if (self.Timer == 0)
            {
                self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UIPetMeleeMain, self);
            }

            self.View.E_CancelButton.gameObject.SetActive(true);
        }

        private static void OnCancel(this DlgPetMeleeMain self)
        {
            self.View.E_CancelButton.gameObject.SetActive(false);
        }
    }
}