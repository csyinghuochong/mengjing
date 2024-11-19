using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetbarSetSkillItem))]
    [FriendOf(typeof(Scroll_Item_PetbarSetPetItem))]
    [FriendOf(typeof(ES_PetBarSetItem))]
    [EntitySystemOf(typeof(ES_PetBarSet))]
    [FriendOfAttribute(typeof(ES_PetBarSet))]
    public static partial class ES_PetBarSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetBarSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_PlanSetToggleGroup.AddListener((index) => { self.OnPlanSet(index).Coroutine(); });
            self.E_PetTypeSetToggleGroup.AddListener(self.OnPetTypeSet);
            self.E_PetbarSetPetItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetBarSetItemsRefresh);
            self.E_ConfirmPetButton.AddListenerAsync(self.OnConfirmPet);
            self.E_PetbarSetSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetBarSetSkillsRefresh);
            self.E_ActivateSkillButton.AddListenerAsync(self.OnActivateSkill);
            self.E_EquipSkillButton.AddListenerAsync(self.OnEquipSkill);

            self.ES_PetBarSetItem_1.E_PetBarSetIconButton.AddListener(() => self.OnClickPetIcon(1));
            self.ES_PetBarSetItem_1.E_AppearSkillButton.AddListener(() => self.OnClickSkill(2, 0, 0));
            self.ES_PetBarSetItem_1.E_ActiveSkill_0Button.AddListener(() => self.OnClickSkill(3, 1, 0));

            self.ES_PetBarSetItem_2.E_PetBarSetIconButton.AddListener(() => self.OnClickPetIcon(2));
            self.ES_PetBarSetItem_2.E_AppearSkillButton.AddListener(() => self.OnClickSkill(2, 0, 0));
            self.ES_PetBarSetItem_2.E_ActiveSkill_0Button.AddListener(() => self.OnClickSkill(3, 1, 0));

            self.ES_PetBarSetItem_3.E_PetBarSetIconButton.AddListener(() => self.OnClickPetIcon(3));
            self.ES_PetBarSetItem_3.E_AppearSkillButton.AddListener(() => self.OnClickSkill(3, 0, 0));
            self.ES_PetBarSetItem_3.E_ActiveSkill_0Button.AddListener(() => self.OnClickSkill(3, 1, 0));

            self.EG_PetPanelRectTransform.gameObject.SetActive(false);
            self.EG_SkillPanelRectTransform.gameObject.SetActive(false);

            self.E_PlanSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarSet self)
        {
            self.DestroyWidget();
        }

        private static async ETTask OnPlanSet(this ES_PetBarSet self, int index)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();

            if (petComponentC.PetFightPlan != index)
            {
                int error = await PetNetHelper.RequestPetFightPlan(self.Root(), index);

                if (error == ErrorCode.ERR_Success)
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("宠物上阵切换 {0}", index));
                    }
                }
            }

            // 复制一份
            self.PetFightList.Clear();
            foreach (PetBarInfo info in petComponentC.GetNowPetFightList())
            {
                PetBarInfo petBarInfo = PetBarInfo.Create();
                petBarInfo.PetId = info.PetId;
                petBarInfo.PetBarId = info.PetBarId;
                petBarInfo.AppearSkill = info.AppearSkill;
                petBarInfo.ActiveSkill = new();
                petBarInfo.ActiveSkill.AddRange(info.ActiveSkill);

                self.PetFightList.Add(petBarInfo);
            }

            self.InitInfo();
            self.OnUpdateSelectedPetItem();
        }

        #region 宠物

        private static void InitInfo(this ES_PetBarSet self)
        {
            self.ES_PetBarSetItem_1.OnInit(self.PetFightList[0]);
            self.ES_PetBarSetItem_2.OnInit(self.PetFightList[1]);
            self.ES_PetBarSetItem_3.OnInit(self.PetFightList[2]);
        }

        private static void OnClickPetIcon(this ES_PetBarSet self, int index)
        {
            self.EG_PetPanelRectTransform.gameObject.SetActive(true);
            self.EG_SkillPanelRectTransform.gameObject.SetActive(false);

            self.E_PetTypeSetToggleGroup.OnSelectIndex(0);
            self.OnUpdateSelectedPetItem();
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
            self.OnUpdateSelectedPetItem();
        }

        private static void OnPetBarSetItemsRefresh(this ES_PetBarSet self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetbarSetPetItem item in self.ScrollItemPetbarSetPetItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_PetbarSetPetItem scrollItemPetbarSetPetItem = self.ScrollItemPetbarSetPetItems[index].BindTrans(transform);

            scrollItemPetbarSetPetItem.E_TouchEventTrigger.gameObject.SetActive(false);
            scrollItemPetbarSetPetItem.E_TouchEventTrigger.triggers.Clear();
            scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.OnPointerDown(pdata as PointerEventData); });
            scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.BeginDrag,
                (pdata) => { self.OnBeginDrag(pdata as PointerEventData, index); });
            scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.Drag,
                (pdata) => { self.OnDraging(pdata as PointerEventData); });
            scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.OnPointerUp(pdata as PointerEventData, index); });
            scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.EndDrag,
                (pdata) => { self.OnEndDrag(pdata as PointerEventData, index); });
            scrollItemPetbarSetPetItem.E_TouchEventTrigger.gameObject.SetActive(true);
            scrollItemPetbarSetPetItem.OnInitUI(self.ShowRolePetInfos[index]);
        }

        private static void OnUpdateSelectedPetItem(this ES_PetBarSet self)
        {
            // if (self.ScrollItemPetbarSetPetItems == null)
            // {
            //     return;
            // }
            //
            // foreach (Scroll_Item_PetbarSetPetItem item in self.ScrollItemPetbarSetPetItems.Values)
            // {
            //     if (item.uiTransform == null)
            //     {
            //         continue;
            //     }
            //
            //     item.E_XuanZhongImage.gameObject.SetActive(false);
            //     foreach (PetBarInfo petBarInfo in self.PetFightList)
            //     {
            //         if (petBarInfo.PetId == item.PetId)
            //         {
            //             item.E_XuanZhongImage.gameObject.SetActive(true);
            //             break;
            //         }
            //     }
            // }
        }

        private static void OnPointerDown(this ES_PetBarSet self, PointerEventData pdata)
        {
            // self.ClickTime = TimeHelper.ServerNow();
        }

        private static void OnBeginDrag(this ES_PetBarSet self, PointerEventData pdata, int index)
        {
            self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnBeginDrag(pdata);

            self.E_IconImage.gameObject.SetActive(true);
            Scroll_Item_PetbarSetPetItem item = self.ScrollItemPetbarSetPetItems[index];
            self.E_IconImage.sprite = item.E_IconImage.sprite;
        }

        private static void OnDraging(this ES_PetBarSet self, PointerEventData pdata)
        {
            Vector2 localPoint = new Vector3();
            RectTransform canvas = self.E_IconImage.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            self.E_IconImage.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);

            self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnDrag(pdata);
        }

        private static void OnPointerUp(this ES_PetBarSet self, PointerEventData pdata, int index)
        {
            // if (TimeHelper.ServerNow() - self.ClickTime <= 200)
            // {
            //     Scroll_Item_PetbarSetPetItem item = self.ScrollItemPetbarSetPetItems[index];
            //     self.OnClickPetItem(item.PetId);
            // }
            //
            // self.ClickTime = 0;
        }

        private static void OnEndDrag(this ES_PetBarSet self, PointerEventData pdata, int index)
        {
            RectTransform canvas = self.E_IconImage.transform.parent.parent.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (name != "E_PetBarSetIcon")
                {
                    continue;
                }

                name = results[i].gameObject.transform.parent.parent.name;
                int petBarSetIndex = int.Parse(name.Substring(17, name.Length - 17));
                Scroll_Item_PetbarSetPetItem item = self.ScrollItemPetbarSetPetItems[index];
                self.PetFightList[petBarSetIndex - 1].PetId = item.PetId;
                self.InitInfo();
                self.OnUpdateSelectedPetItem();

                break;
            }

            self.E_IconImage.gameObject.SetActive(false);

            self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnEndDrag(pdata);
        }

        private static async ETTask OnConfirmPet(this ES_PetBarSet self)
        {
            await PetNetHelper.RequestPetBarSet(self.Root(), self.PetFightList);

            await ETTask.CompletedTask;
        }

        #endregion

        #region 技能

        private static void OnClickSkill(this ES_PetBarSet self, int petIndex, int skillType, int skillIndex)
        {
            self.PetBarIndex = petIndex;
            self.SkillType = skillType;
            self.SkillIndex = skillIndex;

            self.EG_PetPanelRectTransform.gameObject.SetActive(false);
            self.EG_SkillPanelRectTransform.gameObject.SetActive(true);

            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int nowPetbarId = petComponentC.PetBarConfigList[petIndex - 1];
            self.ShowSKillIds.Clear();
            self.ActivatedSKillIds.Clear();
            foreach (int id in PetBarConfigCategory.Instance.PetBarGroupList[petIndex])
            {
                PetBarConfig petBarConfig = PetBarConfigCategory.Instance.Get(id);

                if (id <= nowPetbarId)
                {
                    self.ActivatedSKillIds.AddRange(petBarConfig.ActiveSkills);
                }

                self.ShowSKillIds.AddRange(petBarConfig.ActiveSkills);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetbarSetSkillItems, self.ShowSKillIds.Count);
            self.E_PetbarSetSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShowSKillIds.Count);
        }

        private static void OnShowSkill(this ES_PetBarSet self, RolePetInfo petInfo)
        {
            // self.E_PetbarSetPetItemsLoopVerticalScrollRect.gameObject.SetActive(false);
            // self.E_PetbarSetSkillItemsLoopVerticalScrollRect.gameObject.SetActive(true);
            // PetBarInfo petBarInfo = self.Root().GetComponent<PetComponentC>().PetFightList[0];
            // PetBarConfig petBarConfig = PetBarConfigCategory.Instance.Get(petBarInfo.PetBarId);
            // petBarConfig.ActiveSkills
        }

        private static void OnPetBarSetSkillsRefresh(this ES_PetBarSet self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetbarSetSkillItem item in self.ScrollItemPetbarSetSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_PetbarSetSkillItem scrollItemPetbarSetSkillItem = self.ScrollItemPetbarSetSkillItems[index].BindTrans(transform);
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(self.ShowSKillIds[index]);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            scrollItemPetbarSetSkillItem.E_XuanZhongImage.gameObject.SetActive(false);
            scrollItemPetbarSetSkillItem.E_IconImage.sprite = sp;
            scrollItemPetbarSetSkillItem.E_NameText.text = skillConfig.SkillName;
            bool activated = self.ActivatedSKillIds.Contains(self.ShowSKillIds[index]);
            CommonViewHelper.SetImageGray(self.Root(), scrollItemPetbarSetSkillItem.E_IconImage.gameObject, !activated);
            if (activated)
            {
                scrollItemPetbarSetSkillItem.E_LvText.gameObject.SetActive(false);
            }
            else
            {
                scrollItemPetbarSetSkillItem.E_LvText.gameObject.SetActive(true);
                int lv = 0;
                foreach (PetBarConfig petBarConfig in PetBarConfigCategory.Instance.GetAll().Values)
                {
                    if (petBarConfig.ActiveSkills.Contains(self.ShowSKillIds[index]))
                    {
                        lv = petBarConfig.Level;
                        break;
                    }
                }

                using (zstring.Block())
                {
                    scrollItemPetbarSetSkillItem.E_LvText.text = zstring.Format("{0}级激活", lv);
                }
            }
        }

        private static async ETTask OnActivateSkill(this ES_PetBarSet self)
        {
            await ETTask.CompletedTask;
        }

        private static async ETTask OnEquipSkill(this ES_PetBarSet self)
        {
            await ETTask.CompletedTask;
        }

        #endregion
    }
}