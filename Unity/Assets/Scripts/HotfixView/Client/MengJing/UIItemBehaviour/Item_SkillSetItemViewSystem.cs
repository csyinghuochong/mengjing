using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgSkillViewComponent))]
    [FriendOf(typeof(Scroll_Item_SkillSetItem))]
    [EntitySystemOf(typeof(Scroll_Item_SkillSetItem))]
    public static partial class Scroll_Item_SkillSetItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SkillSetItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SkillSetItem self)
        {
            self.DestroyWidget();
        }

        public static void BeginDrag(this Scroll_Item_SkillSetItem self, PointerEventData pdata)
        {
            int juexingid = 0;
            int occtwo = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;
            if (occtwo != 0)
            {
                OccupationTwoConfig occupationConfig = OccupationTwoConfigCategory.Instance.Get(occtwo);
                juexingid = occupationConfig.JueXingSkill[7];
            }

            if (juexingid == self.SkillPro.SkillID)
            {
                self.Img_SkillIconDi_Copy = null;
                return;
            }

            self.Img_SkillIconDi_Copy = UnityEngine.Object.Instantiate(self.E_Img_SkillIconDiImage.gameObject,
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSkill>().View.uiTransform, true);
            self.Img_SkillIconDi_Copy.transform.localScale = Vector3.one;
        }

        public static void Draging(this Scroll_Item_SkillSetItem self, PointerEventData pdata)
        {
            if (self.Img_SkillIconDi_Copy == null)
            {
                return;
            }

            RectTransform canvas = self.Img_SkillIconDi_Copy.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out self.localPoint);

            self.Img_SkillIconDi_Copy.transform.localPosition = new Vector3(self.localPoint.x, self.localPoint.y, 0f);
        }

        public static void EndDrag(this Scroll_Item_SkillSetItem self, PointerEventData pdata)
        {
            if (self.Img_SkillIconDi_Copy == null)
            {
                return;
            }

            RectTransform canvas = self.Img_SkillIconDi_Copy.transform.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (!name.Contains("Danger_Skill_Icon_"))
                {
                    continue;
                }

                int index = int.Parse(name.Substring(18, name.Length - 18));
                if (index >= 9)
                {
                    continue;
                }

                SkillNetHelper.SetSkillIdByPosition(self.Root(), self.SkillPro.SkillID, (int)SkillSetEnum.Skill, index).Coroutine();
                break;
            }

            if (self.Img_SkillIconDi_Copy != null)
            {
                UnityEngine.Object.Destroy(self.Img_SkillIconDi_Copy);
                self.Img_SkillIconDi_Copy = null;
            }
        }

        public static void OnUpdateUI(this Scroll_Item_SkillSetItem self, SkillPro skillPro)
        {
            self.E_Img_SkillIconEventTrigger.triggers.Clear();
            self.E_Img_SkillIconEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_Img_SkillIconEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.E_Img_SkillIconEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            self.SkillPro = skillPro;

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            SkillConfig skillWeaponConfig = SkillConfigCategory.Instance.Get(SkillHelp.GetWeaponSkill(skillPro.SkillID,
                UnitHelper.GetEquipType(self.Root()), skillSetComponent.SkillList));
            self.E_Lab_SkillNameText.text = skillWeaponConfig.SkillName;
            self.E_Lab_SkillLvText.text = skillWeaponConfig.SkillLv.ToString();
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillWeaponConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_Img_SkillIconImage.sprite = sp;

            self.canDrag = skillWeaponConfig.SkillType == (int)SkillTypeEnum.ActiveSkill;
        }
    }
}