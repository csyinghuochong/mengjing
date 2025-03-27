using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{

    [EntitySystemOf(typeof(ES_CommonSkillItem))]
    [FriendOfAttribute(typeof(ES_CommonSkillItem))]
    public static partial class ES_CommonSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_CommonSkillItem self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;
            
            
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_CommonSkillItem self)
        {
            self.DestroyWidget();
        }

        // public static void OnUpdatePetSkill(this ES_CommonSkillItem self, int skillId, string SkillAtlas = ABAtlasTypes.RoleSkillIcon,
        // bool lockSkill = false, bool unactive = false, int haveNum = 1)
        // {
        //     self.SkillId = skillId;
        //     if (!SkillConfigCategory.Instance.Contain(skillId))
        //     {
        //         return;
        //     }
        //
        //     SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
        //     if (string.IsNullOrEmpty(skillConfig.SkillIcon))
        //     {
        //         return;
        //     }
        //
        //     string path = ABPathHelper.GetAtlasPath_2(SkillAtlas, skillConfig.SkillIcon);
        //     Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
        //
        //     self.E_ImageIconImage.sprite = sp;
        //     self.SkillAtlas = SkillAtlas;
        //     self.addTip = string.Empty;
        //     self.UnActive = unactive;
        //     self.HaveSkillNum = haveNum;
        //
        //     self.E_TextSkillNameText.text = skillConfig.SkillName;
        //     self.E_Image_LockImage.gameObject.SetActive(lockSkill);
        //
        //     self.E_BorderImgImage.gameObject.SetActive(false);
        //     self.E_ImageIconEventTrigger.triggers.Clear();
        //     self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
        //         (pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
        //     self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });
        // }


        public static void SetImageGray(this ES_CommonSkillItem self, bool gray)
        {
            CommonViewHelper.SetImageGray( self.Root(),  self.E_ImageIconImage.gameObject, gray);
        }

        public static void OnUpdateUI(this ES_CommonSkillItem self, int skillId, string SkillAtlas = ABAtlasTypes.RoleSkillIcon,
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
            self.E_ImageIconEventTrigger.triggers.Clear();
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData); });
        }

        private static async ETTask BeginDrag(this ES_CommonSkillItem self, PointerEventData pdata)
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

        public static void SetSelectAction(this ES_CommonSkillItem self, Action<int> action)
        {
            self.SelectAction = action;     
        }

        private static void EndDrag(this ES_CommonSkillItem self, PointerEventData pdata)
        {
            self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SkillTips);
            self.SelectAction?.Invoke(self.SkillId);
        }
    }
}