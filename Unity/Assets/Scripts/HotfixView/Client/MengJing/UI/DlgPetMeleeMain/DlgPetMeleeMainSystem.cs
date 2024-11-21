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

    [FriendOf(typeof(DlgPetMeleeMainViewComponent))]
    [FriendOf(typeof(Scroll_Item_PetMeleeItem))]
    [FriendOf(typeof(DlgPetMeleeMain))]
    public static class DlgPetMeleeMainSystem
    {
        public static void RegisterUIEvent(this DlgPetMeleeMain self)
        {
            self.View.E_TouchEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.View.E_TouchEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
            self.View.E_TouchEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            self.View.E_PetMeleeItemsLoopHorizontalScrollRect.AddItemRefreshListener(self.OnPetMeleeItemsRefresh);

            self.RefreshItems();
            self.StartTime = TimeInfo.Instance.ServerNow();
            self.ReadyTime = 10000; // 倒计时时间 (暂时，之后根据公式读表)
            self.MaxMoLi = 1000; // 最大魔力 (暂时，之后根据公式读表)
            self.MoLi = 300; // 魔力 (暂时，之后根据公式读表)
            self.MoLiRegenRate = 20; // 每秒魔力回复 (暂时，之后根据公式读表)
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UIPetMeleeMain, self);
            self.View.E_IconImage.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgPetMeleeMain self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgPetMeleeMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void BeginDrag(this DlgPetMeleeMain self, PointerEventData pdata)
        {
            self.PreviousPressPosition = pdata.position;
        }

        public static void Drag(this DlgPetMeleeMain self, PointerEventData pdata)
        {
            float x = (self.PreviousPressPosition.x - pdata.position.x) * 0.05f;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().ApplyCameraPos_X(x, -10, 10);
            self.PreviousPressPosition = pdata.position;
        }

        public static void EndDrag(this DlgPetMeleeMain self, PointerEventData pdata)
        {
        }

        public static void Update(this DlgPetMeleeMain self)
        {
            long nowTime = TimeInfo.Instance.ServerNow();
            if (!self.GameStart)
            {
                long leftTime = self.ReadyTime - (nowTime - self.StartTime);

                if (leftTime > 0)
                {
                    using (zstring.Block())
                    {
                        self.View.E_LeftTimeTextText.text = zstring.Format("剩余时间：{0}", leftTime / 1000);
                    }

                    self.View.E_LeftTimeImgImage.fillAmount = leftTime * 1f / self.ReadyTime;
                }
                else
                {
                    FlyTipComponent.Instance.ShowFlyTip("一大波怪物正在来袭!!!");
                    PetNetHelper.PetMeleeBeginRequest(self.Root()).Coroutine();
                    self.View.EG_TopRectTransform.gameObject.SetActive(false);
                    self.GameStart = true;
                }
            }

            if (nowTime - self.LastMoLiRegenTime >= 1000)
            {
                self.LastMoLiRegenTime = nowTime;
                self.MoLi += self.MoLiRegenRate;
                if (self.MoLi > self.MaxMoLi)
                {
                    self.MoLi = self.MaxMoLi;
                }
            }

            using (zstring.Block())
            {
                self.View.E_MoLiText.text = zstring.Format("{0}/{1}", self.MoLi, self.MaxMoLi);
            }

            self.View.E_MoLiImgImage.fillAmount = self.MoLi * 1f / self.MaxMoLi;

            self.RefreshItemCD();
        }

        private static async ETTask PetMeleePlaceRequest(this DlgPetMeleeMain self, Vector3 pos)
        {
            int error = await PetNetHelper.PetMeleePlaceRequest(self.Root(), self.PetId, pos);

            if (error == 0)
            {
                self.MoLi -= self.CostMoLi;

                foreach (Scroll_Item_PetMeleeItem item in self.ScrollItemPetMeleeItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    if (item.RolePetInfo == null)
                    {
                        continue;
                    }

                    if (self.PetId != item.RolePetInfo.Id)
                    {
                        continue;
                    }

                    item.SetCD();
                    break;
                }
            }
        }

        private static void RefreshItems(this DlgPetMeleeMain self)
        {
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;
            self.ShowRolePetInfos.Clear();

            UnitComponent unitComponent = self.Root().CurrentScene().GetComponent<UnitComponent>();

            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                // if (rolePetInfos[i].PetStatus != 0)
                // {
                //     continue;
                // }

                if (unitComponent.Get(rolePetInfos[i].Id) != null)
                {
                    continue;
                }

                self.ShowRolePetInfos.Add(rolePetInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetMeleeItems, self.ShowRolePetInfos.Count);
            self.View.E_PetMeleeItemsLoopHorizontalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }

        private static void RefreshItemCD(this DlgPetMeleeMain self)
        {
            foreach (Scroll_Item_PetMeleeItem item in self.ScrollItemPetMeleeItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                item.RefreshCD();
            }
        }

        private static void BeginDrag(this DlgPetMeleeMain self, PointerEventData pdata, Scroll_Item_PetMeleeItem item)
        {
            self.CanPlace = true;

            if (item.EndTime > TimeHelper.ServerNow())
            {
                FlyTipComponent.Instance.ShowFlyTip("冷却中。。。");
                self.CanPlace = false;
                return;
            }

            if (self.MoLi < item.CostMoLi)
            {
                FlyTipComponent.Instance.ShowFlyTip("魔力不足");
                self.CanPlace = false;
                return;
            }

            self.CostMoLi = item.CostMoLi;
            self.PetId = item.RolePetInfo.Id;
            self.View.E_IconImage.sprite = item.E_IconImage.sprite;
            self.View.E_IconImage.gameObject.SetActive(true);
        }

        private static void Drag(this DlgPetMeleeMain self, PointerEventData pdata, Scroll_Item_PetMeleeItem item)
        {
            if (self.CanPlace == false)
            {
                return;
            }

            Vector2 localPoint = new Vector2();
            RectTransform canvas = self.View.uiTransform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            self.View.E_IconImage.transform.localPosition = localPoint;
        }

        private static void EndDrag(this DlgPetMeleeMain self, PointerEventData pdata, Scroll_Item_PetMeleeItem item)
        {
            if (self.CanPlace == false)
            {
                return;
            }

            self.View.E_IconImage.gameObject.SetActive(false);

            RaycastHit raycastHit;
            Ray Ray = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(Ray, out raycastHit, 100, 1 << LayerMask.NameToLayer(LayerEnum.Map.ToString()));
            if (!hit)
            {
                return;
            }

            Vector3 pos = raycastHit.point;
            self.PetMeleePlaceRequest(pos).Coroutine();
        }

        private static void OnPetMeleeItemsRefresh(this DlgPetMeleeMain self, Transform transform, int index)
        {
            Scroll_Item_PetMeleeItem scrollItemPetMeleeItem = self.ScrollItemPetMeleeItems[index].BindTrans(transform);
            scrollItemPetMeleeItem.Refresh(self.ShowRolePetInfos[index]);
            scrollItemPetMeleeItem.E_IconEventTrigger.RegisterEvent(EventTriggerType.BeginDrag,
                (pdata) => { self.BeginDrag(pdata as PointerEventData, scrollItemPetMeleeItem); });
            scrollItemPetMeleeItem.E_IconEventTrigger.RegisterEvent(EventTriggerType.Drag,
                (pdata) => { self.Drag(pdata as PointerEventData, scrollItemPetMeleeItem); });
            scrollItemPetMeleeItem.E_IconEventTrigger.RegisterEvent(EventTriggerType.EndDrag,
                (pdata) => { self.EndDrag(pdata as PointerEventData, scrollItemPetMeleeItem); });
        }
    }
}