using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectMagicItem))]
    [EntitySystemOf(typeof(Scroll_Item_SelectMagicItem))]
    public static partial class Scroll_Item_SelectSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SelectMagicItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SelectMagicItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_SelectMagicItem self, int magicId)
        {
            self.Time = 250;
            self.ScrollRect = self.uiTransform.parent.parent;

            self.E_TouchEventTrigger.triggers.Clear();
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.OnPointerDown(pdata as PointerEventData); });
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.OnPointerUp(pdata as PointerEventData); });
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.OnBeginDrag(pdata as PointerEventData); });
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.OnDraging(pdata as PointerEventData); });
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.OnEndDrag(pdata as PointerEventData); });

            self.E_SelectedImage.gameObject.SetActive(false);

            self.magicId = magicId;
            PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(magicId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, petMagicCardConfig.Icon.ToString());
            Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sprite;
            self.E_NameText.text = petMagicCardConfig.Name;
        }

        private static void OnPointerDown(this Scroll_Item_SelectMagicItem self, PointerEventData pdata)
        {
            self.ClickTime = TimeHelper.ServerNow();
            self.IsDrag = false;
            self.IsClick = false;
            self.ShowTip(pdata.position).Coroutine();
        }

        private static async ETTask ShowTip(this Scroll_Item_SelectMagicItem self, Vector2 position)
        {
            long instanceId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(self.Time);
            if (self.IsDisposed || self.InstanceId != instanceId || self.IsDrag || self.IsClick)
            {
                return;
            }

            PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.magicId);

            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SkillTips);
            Vector2 localPoint;
            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, position, uiCamera, out localPoint);
            DlgSkillTips dlgSkillTips = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSkillTips>();
            dlgSkillTips.OnUpdateData(petMagicCardConfig.SkillId, new Vector3(localPoint.x + 30f, localPoint.y - 50f, 0f),
                ABAtlasTypes.RoleSkillIcon);

            self.IsClick = true;
        }

        private static void OnPointerUp(this Scroll_Item_SelectMagicItem self, PointerEventData pdata)
        {
            self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SkillTips);

            if (self.IsDrag == false && TimeHelper.ServerNow() - self.ClickTime <= self.Time && !self.IsClick)
            {
                self.OnSelectSkillItem?.Invoke(self.magicId);
            }

            self.IsClick = true;
        }

        private static void OnBeginDrag(this Scroll_Item_SelectMagicItem self, PointerEventData pdata)
        {
            self.ScrollRect.GetComponent<LoopVerticalScrollRect>().OnBeginDrag(pdata);
        }

        private static void OnDraging(this Scroll_Item_SelectMagicItem self, PointerEventData pdata)
        {
            self.IsDrag = true;

            self.ScrollRect.GetComponent<LoopVerticalScrollRect>().OnDrag(pdata);
        }

        private static void OnEndDrag(this Scroll_Item_SelectMagicItem self, PointerEventData pdata)
        {
            self.ScrollRect.GetComponent<LoopVerticalScrollRect>().OnEndDrag(pdata);
        }
    }
}