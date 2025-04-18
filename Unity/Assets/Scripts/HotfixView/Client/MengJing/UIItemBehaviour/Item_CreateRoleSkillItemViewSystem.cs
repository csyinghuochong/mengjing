using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CreateRoleSkillItem))]
    [EntitySystemOf(typeof(Scroll_Item_CreateRoleSkillItem))]
    public static partial class Scroll_Item_CreateRoleSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CreateRoleSkillItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CreateRoleSkillItem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this Scroll_Item_CreateRoleSkillItem self, int skillId, string SkillAtlas = ABAtlasTypes.RoleSkillIcon,
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
            // self.E_Image_LockImage.gameObject.SetActive(lockSkill);
            self.UnActive = false;
            self.HaveSkillNum = 1;

            // self.E_BorderImgImage.gameObject.SetActive(false);
            self.E_ImageIconEventTrigger.triggers.Clear();
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });
        }

        private static async ETTask BeginDrag(this Scroll_Item_CreateRoleSkillItem self, PointerEventData pdata)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SkillTips);

            Vector2 localPoint;
            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            DlgSkillTips dlgSkillTips = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSkillTips>();
            dlgSkillTips.OnUpdateData(self.SkillId, new Vector3(localPoint.x, localPoint.y, 0f), self.SkillAtlas, self.addTip);

            if (self.UnActive)
            {
                dlgSkillTips.ShowUnActive(self.SkillId, self.HaveSkillNum);
            }

            await ETTask.CompletedTask;
        }

        private static void EndDrag(this Scroll_Item_CreateRoleSkillItem self, PointerEventData pdata)
        {
            self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SkillTips);
            self.SelectAction?.Invoke(self.SkillId);
        }
    }
}