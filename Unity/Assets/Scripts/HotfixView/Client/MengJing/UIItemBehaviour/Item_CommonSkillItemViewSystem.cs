using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonSkillItem))]
    [EntitySystemOf(typeof (Scroll_Item_CommonSkillItem))]
    public static partial class Scroll_Item_CommonSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CommonSkillItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CommonSkillItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdatePetSkill(this Scroll_Item_CommonSkillItem self, int skillId, string SkillAtlas = ABAtlasTypes.RoleSkillIcon,
        bool lockSkill = false, bool unactive = false, int haveNum = 1)
        {
            self.SkillId = skillId;
            if (!SkillConfigCategory.Instance.Contain(skillId))
            {
                return;
            }

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            if (string.IsNullOrEmpty(skillConfig.SkillIcon))
            {
                return;
            }

            string path = ABPathHelper.GetAtlasPath_2(SkillAtlas, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageIconImage.sprite = sp;
            self.SkillAtlas = SkillAtlas;
            self.addTip = string.Empty;
            self.UnActive = unactive;
            self.HaveSkillNum = haveNum;

            self.E_TextSkillNameText.text = skillConfig.SkillName;
            self.E_Image_LockImage.gameObject.SetActive(lockSkill);

            self.E_BorderImgImage.gameObject.SetActive(false);
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });
        }

        public static void OnUpdateUI(this Scroll_Item_CommonSkillItem self, int skillId, string SkillAtlas = ABAtlasTypes.RoleSkillIcon,
        bool lockSkill = false, string addtip = "")
        {
            self.SkillId = skillId;
            if (!SkillConfigCategory.Instance.Contain(skillId))
            {
                return;
            }

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            if (string.IsNullOrEmpty(skillConfig.SkillIcon))
            {
                return;
            }

            string path = ABPathHelper.GetAtlasPath_2(SkillAtlas, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageIconImage.sprite = sp;
            self.SkillAtlas = SkillAtlas;
            self.addTip = addtip;

            self.E_TextSkillNameText.text = skillConfig.SkillName;
            self.E_Image_LockImage.gameObject.SetActive(lockSkill);
            self.UnActive = false;
            self.HaveSkillNum = 1;

            self.E_BorderImgImage.gameObject.SetActive(false);
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });
        }

        public static async ETTask BeginDrag(this Scroll_Item_CommonSkillItem self, PointerEventData pdata)
        {
            // await self.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Chat);
            //
            // Vector2 localPoint;
            // RectTransform canvas = UIEventComponent.Instance.UILayers[(int)UILayer.Mid].gameObject.GetComponent<RectTransform>();
            // Camera uiCamera = self.DomainScene().GetComponent<UIComponent>().UICamera;
            // RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            // skillTips.GetComponent<UISkillTipsComponent>()
            //         .OnUpdateData(self.SkillId, new Vector3(localPoint.x, localPoint.y, 0f), self.SkillAtlas, self.addTip);
            //
            // if (self.UnActive)
            // {
            //     skillTips.GetComponent<UISkillTipsComponent>().ShowUnActive(self.SkillId, self.HaveSkillNum);
            // }
            await ETTask.CompletedTask;
        }

        public static void EndDrag(this Scroll_Item_CommonSkillItem self, PointerEventData pdata)
        {
            // self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_);
            // UIHelper.Remove(self.DomainScene(), UIType.UISkillTips);
            self.SelectAction?.Invoke(self.SkillId);
        }
    }
}