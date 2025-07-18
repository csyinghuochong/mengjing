using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class PetBarUpgrade_Refresh : AEvent<Scene, PetBarUpgrade>
    {
        protected override async ETTask Run(Scene scene, PetBarUpgrade args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPetBar>()?.View.ES_PetBarSet.E_SkillTypeSetToggleGroup.OnSelectIndex(0);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(Scroll_Item_PetBarSetPetSelectItem))]
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
            self.E_SkillTypeSetToggleGroup.AddListener(self.OnSkillTypeSet);
            // self.E_ConfirmButton.AddListenerAsync(self.OnConfirm);
            self.E_ReSetButton.AddListener(self.OnReSet);

            self.ES_PetBarSetItem_1.E_PetBarSetIconButton.AddListener(() => self.OnClickPetIcon(1));
            self.ES_PetBarSetItem_1.E_LockButton.AddListener(() => self.OnClickPetIcon(1));
            self.ES_PetBarSetItem_1.E_TouchButton.AddListener(() => self.OnClickSet(1));
            self.ES_PetBarSetItem_1.E_AppearSkillButton.AddListener(() => self.OnClickSkill(1, 0, 0));
            self.ES_PetBarSetItem_1.E_ActiveSkill_0Button.AddListener(() => self.OnClickSkill(1, 1, 0));

            self.ES_PetBarSetItem_2.E_PetBarSetIconButton.AddListener(() => self.OnClickPetIcon(2));
            self.ES_PetBarSetItem_2.E_LockButton.AddListener(() => self.OnClickPetIcon(2));
            self.ES_PetBarSetItem_2.E_TouchButton.AddListener(() => self.OnClickSet(2));
            self.ES_PetBarSetItem_2.E_AppearSkillButton.AddListener(() => self.OnClickSkill(2, 0, 0));
            self.ES_PetBarSetItem_2.E_ActiveSkill_0Button.AddListener(() => self.OnClickSkill(2, 1, 0));

            self.ES_PetBarSetItem_3.E_PetBarSetIconButton.AddListener(() => self.OnClickPetIcon(3));
            self.ES_PetBarSetItem_3.E_LockButton.AddListener(() => self.OnClickPetIcon(3));
            self.ES_PetBarSetItem_3.E_TouchButton.AddListener(() => self.OnClickSet(3));
            self.ES_PetBarSetItem_3.E_AppearSkillButton.AddListener(() => self.OnClickSkill(3, 0, 0));
            self.ES_PetBarSetItem_3.E_ActiveSkill_0Button.AddListener(() => self.OnClickSkill(3, 1, 0));

            self.EG_PetPanelRectTransform.gameObject.SetActive(false);
            self.EG_SkillPanelRectTransform.gameObject.SetActive(false);
            self.EG_PetIconRectTransform.gameObject.SetActive(false);
            self.EG_SkillIconRectTransform.gameObject.SetActive(false);
            self.EG_PetSelectPanelRectTransform.gameObject.SetActive(false);
            self.E_Btn_PetSelectCloseButton.AddListener(() => { self.EG_PetSelectPanelRectTransform.gameObject.SetActive(false); });

            self.E_PlanSetToggleGroup.OnSelectIndex(self.Root().GetComponent<PetComponentC>().PetFightPlan);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarSet self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;

            self.DestroyWidget();
        }

        private static async ETTask OnPlanSet(this ES_PetBarSet self, int index)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
           
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();

            if (petComponentC.PetFightPlan != index)
            {
                if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetFightIndex) > 0)
                {
                    FlyTipComponent.Instance.ShowFlyTip("当前正在变身状态，稍后切换。");
                }
                else
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
            }

            // 复制一份
            foreach (PetBarInfo petBarInfo in self.PetFightList)
            {
                petBarInfo.Dispose();
            }

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
            // RolePetInfo rolePetInfo = petComponentC.GetPetInfoByID(self.PetFightList[0].PetId);
            // if (rolePetInfo != null)
            // {
            //     self.OnClickSkill(1, 0, 0);
            // }
            // else
            // {
            //     self.OnClickPetIcon(1);
            // }
            //
            // self.OnUpdateSelectedPetItem();
        }

        private static async ETTask OnConfirm(this ES_PetBarSet self)
        {
            int error = await PetNetHelper.RequestPetBarSet(self.Root(), self.PetFightList);
            if (error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("上阵成功！");
            }
        }

        private static void OnReSet(this ES_PetBarSet self)
        {
            foreach (PetBarInfo petBarInfo in self.PetFightList)
            {
                petBarInfo.PetId = 0;
                petBarInfo.AppearSkill = 0;
                petBarInfo.ActiveSkill.Clear();
            }

            self.OnConfirm().Coroutine();
            self.InitInfo();
        }

        #region 宠物

        private static void InitInfo(this ES_PetBarSet self)
        {
            self.ES_PetBarSetItem_1.OnInit(self.PetFightList[0]);
            self.ES_PetBarSetItem_2.OnInit(self.PetFightList[1]);
            self.ES_PetBarSetItem_3.OnInit(self.PetFightList[2]);
        }

        private static void OnClickSet(this ES_PetBarSet self, int petIndex)
        {
            self.PetBarIndex = petIndex;
            self.EG_PetPanelRectTransform.gameObject.SetActive(false);
            self.EG_SkillPanelRectTransform.gameObject.SetActive(false);

            self.ES_PetBarSetItem_1.E_HighlightImage.gameObject.SetActive(petIndex == 1);
            self.ES_PetBarSetItem_2.E_HighlightImage.gameObject.SetActive(petIndex == 2);
            self.ES_PetBarSetItem_3.E_HighlightImage.gameObject.SetActive(petIndex == 3);
        }
        
        private static void OnClickPetIcon(this ES_PetBarSet self, int petIndex)
        {
            self.PetBarIndex = petIndex;
            self.EG_PetPanelRectTransform.gameObject.SetActive(false);
            self.EG_SkillPanelRectTransform.gameObject.SetActive(false);

            self.ES_PetBarSetItem_1.E_HighlightImage.gameObject.SetActive(petIndex == 1);
            self.ES_PetBarSetItem_2.E_HighlightImage.gameObject.SetActive(petIndex == 2);
            self.ES_PetBarSetItem_3.E_HighlightImage.gameObject.SetActive(petIndex == 3);

            // self.E_PetTypeSetToggleGroup.OnSelectIndex(0);
            // self.OnUpdateSelectedPetItem();
            
            self.EG_PetSelectPanelRectTransform.gameObject.SetActive(true);
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                bool have = false;
                foreach (PetBarInfo petBarInfo in self.PetFightList)
                {
                    if (petBarInfo.PetId == rolePetInfos[i].Id)
                    {
                        have = true;
                        break;
                    }
                }

                if (have)
                {
                    continue;
                }
                
                self.ShowRolePetInfos.Add(rolePetInfos[i]);
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowRolePetInfos.Count; i++)
            {
                if (!self.ScrollItemPetbarSetPetSelectItems.ContainsKey(i))
                {
                    Scroll_Item_PetBarSetPetSelectItem item = self.AddChild<Scroll_Item_PetBarSetPetSelectItem>();
                    string path = "Assets/Bundles/UI/Item/Item_PetBarSetPetSelectItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_PetBarSetPetSelectItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemPetbarSetPetSelectItems.Add(i, item);
                }

                Scroll_Item_PetBarSetPetSelectItem scrollItemPetbarSetPetSelectItem = self.ScrollItemPetbarSetPetSelectItems[i];
                scrollItemPetbarSetPetSelectItem.uiTransform.gameObject.SetActive(true);
                scrollItemPetbarSetPetSelectItem.OnSelectPet = self.OnSelectPet;
                scrollItemPetbarSetPetSelectItem.OnInitData(self.ShowRolePetInfos[i]);
            }

            if (self.ScrollItemPetbarSetPetSelectItems.Count > self.ShowRolePetInfos.Count)
            {
                for (int i = self.ShowRolePetInfos.Count; i < self.ScrollItemPetbarSetPetSelectItems.Count; i++)
                {
                    Scroll_Item_PetBarSetPetSelectItem scrollItemPetbarSetPetSelectItem = self.ScrollItemPetbarSetPetSelectItems[i];
                    scrollItemPetbarSetPetSelectItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }

        private static void OnSelectPet(this ES_PetBarSet self, long petId)
        {
            for (int j = 0; j < self.PetFightList.Count; j++)
            {
                if (self.PetFightList[j].PetId == petId)
                {
                    self.PetFightList[j].PetId = 0;
                }
            }

            self.PetFightList[self.PetBarIndex - 1].PetId = petId;
            self.OnConfirm().Coroutine();
            self.InitInfo();
            self.EG_PetSelectPanelRectTransform.gameObject.SetActive(false);
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

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowRolePetInfos.Count; i++)
            {
                if (!self.ScrollItemPetbarSetPetItems.ContainsKey(i))
                {
                    Scroll_Item_PetbarSetPetItem item = self.AddChild<Scroll_Item_PetbarSetPetItem>();
                    string path = "Assets/Bundles/UI/Item/Item_PetbarSetPetItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_PetbarSetPetItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemPetbarSetPetItems.Add(i, item);
                }

                Scroll_Item_PetbarSetPetItem scrollItemPetbarSetPetItem = self.ScrollItemPetbarSetPetItems[i];
                scrollItemPetbarSetPetItem.uiTransform.gameObject.SetActive(true);
                scrollItemPetbarSetPetItem.E_TouchEventTrigger.gameObject.SetActive(false);
                scrollItemPetbarSetPetItem.E_TouchEventTrigger.triggers.Clear();
                scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                    (pdata) => { self.OnPetItemPointerDown(pdata as PointerEventData); });
                int i1 = i;
                scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.BeginDrag,
                    (pdata) => { self.OnPetItemBeginDrag(pdata as PointerEventData, i1); });
                scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.Drag,
                    (pdata) => { self.OnPetItemDraging(pdata as PointerEventData); });
                scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                    (pdata) => { self.OnPetItemPointerUp(pdata as PointerEventData, i1); });
                scrollItemPetbarSetPetItem.E_TouchEventTrigger.RegisterEvent(EventTriggerType.EndDrag,
                    (pdata) => { self.OnPetItemEndDrag(pdata as PointerEventData, i1); });
                scrollItemPetbarSetPetItem.E_TouchEventTrigger.gameObject.SetActive(true);
                scrollItemPetbarSetPetItem.OnInitUI(self.ShowRolePetInfos[i]);
            }

            if (self.ScrollItemPetbarSetPetItems.Count > self.ShowRolePetInfos.Count)
            {
                for (int i = self.ShowRolePetInfos.Count; i < self.ScrollItemPetbarSetPetItems.Count; i++)
                {
                    Scroll_Item_PetbarSetPetItem scrollItemPetbarSetPetItem = self.ScrollItemPetbarSetPetItems[i];
                    scrollItemPetbarSetPetItem.uiTransform.gameObject.SetActive(false);
                }
            }
            
            self.OnUpdateSelectedPetItem();
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

        private static void OnPetItemPointerDown(this ES_PetBarSet self, PointerEventData pdata)
        {
            // self.ClickTime = TimeHelper.ServerNow();
        }

        private static void OnPetItemBeginDrag(this ES_PetBarSet self, PointerEventData pdata, int index)
        {
            self.EG_PetIconRectTransform.gameObject.SetActive(true);
            Scroll_Item_PetbarSetPetItem item = self.ScrollItemPetbarSetPetItems[index];
            self.EG_PetIconRectTransform.Find("Icon").GetComponent<Image>().sprite = item.E_IconImage.sprite;

            // self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnBeginDrag(pdata);
        }

        private static void OnPetItemDraging(this ES_PetBarSet self, PointerEventData pdata)
        {
            Vector2 localPoint = new Vector3();
            RectTransform canvas = self.EG_PetIconRectTransform.transform.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            self.EG_PetIconRectTransform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);

            // self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnDrag(pdata);
        }

        private static void OnPetItemPointerUp(this ES_PetBarSet self, PointerEventData pdata, int index)
        {
            // if (TimeHelper.ServerNow() - self.ClickTime <= 200)
            // {
            //     Scroll_Item_PetbarSetPetItem item = self.ScrollItemPetbarSetPetItems[index];
            //     self.OnClickPetItem(item.PetId);
            // }
            //
            // self.ClickTime = 0;
        }

        private static void OnPetItemEndDrag(this ES_PetBarSet self, PointerEventData pdata, int index)
        {
            RectTransform canvas = self.EG_PetIconRectTransform.parent.parent.parent.GetComponent<RectTransform>();
            GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
            List<RaycastResult> results = new List<RaycastResult>();
            gr.Raycast(pdata, results);

            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i].gameObject.name;
                if (name != "E_PetBarSetIcon" && name != "E_Lock")
                {
                    continue;
                }

                name = results[i].gameObject.transform.parent.parent.name;
                int petBarSetIndex = int.Parse(name.Substring(17, name.Length - 17));

                if (petBarSetIndex != self.PetBarIndex)
                {
                    continue;
                }

                Scroll_Item_PetbarSetPetItem item = self.ScrollItemPetbarSetPetItems[index];
                for (int j = 0; j < self.PetFightList.Count; j++)
                {
                    if (self.PetFightList[j].PetId == item.PetId)
                    {
                        self.PetFightList[j].PetId = 0;
                    }
                }

                self.PetFightList[petBarSetIndex - 1].PetId = item.PetId;
                self.OnConfirm().Coroutine();
                self.InitInfo();
                self.OnUpdateSelectedPetItem();

                break;
            }

            self.EG_PetIconRectTransform.gameObject.SetActive(false);

            // self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnEndDrag(pdata);
        }

        #endregion

        #region 技能

        public static void OnSkillTypeSet(this ES_PetBarSet self, int index)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int nowPetbarId = petComponentC.PetBarConfigList[self.PetBarIndex - 1];
            self.ShowSKillIds.Clear();
            self.ActivatedSKillIds.Clear();
            foreach (int id in PetBarConfigCategory.Instance.PetBarGroupList[self.PetBarIndex])
            {
                PetBarConfig petBarConfig = PetBarConfigCategory.Instance.Get(id);

                foreach (int skillId in petBarConfig.ActiveSkills)
                {
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);

                    if (index == 1 && (skillConfig.SkillType == (int)SkillTypeEnum.PassiveSkill ||
                            skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkill ||
                            skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkillNoFight))
                    {
                        continue;
                    }

                    if (index == 2 && (skillConfig.SkillType != (int)SkillTypeEnum.PassiveSkill &&
                            skillConfig.SkillType != (int)SkillTypeEnum.PassiveAddProSkill &&
                            skillConfig.SkillType != (int)SkillTypeEnum.PassiveAddProSkillNoFight))
                    {
                        continue;
                    }

                    if (id <= nowPetbarId)
                    {
                        self.ActivatedSKillIds.Add(skillId);
                    }

                    self.ShowSKillIds.Add(skillId);
                }
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.ShowSKillIds.Count; i++)
            {
                if (!self.ScrollItemPetbarSetSkillItems.ContainsKey(i))
                {
                    Scroll_Item_PetbarSetSkillItem item = self.AddChild<Scroll_Item_PetbarSetSkillItem>();
                    string path = "Assets/Bundles/UI/Item/Item_PetbarSetSkillItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_PetbarSetSkillItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemPetbarSetSkillItems.Add(i, item);
                }

                Scroll_Item_PetbarSetSkillItem scrollItemPetbarSetSkillItem = self.ScrollItemPetbarSetSkillItems[i];
                scrollItemPetbarSetSkillItem.uiTransform.gameObject.SetActive(true);
                int skillId = self.ShowSKillIds[i];
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
                string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);
                scrollItemPetbarSetSkillItem.E_XuanZhongImage.gameObject.SetActive(false);
                scrollItemPetbarSetSkillItem.E_IconImage.sprite = sp;
                scrollItemPetbarSetSkillItem.E_NameText.text = skillConfig.SkillName;
                bool activated = self.ActivatedSKillIds.Contains(skillId);
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
                        if (petBarConfig.ActiveSkills.Contains(skillId))
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

                // 被动技能不能拖
                bool canDrag = !(!activated || skillConfig.SkillType == (int)SkillTypeEnum.PassiveSkill ||
                    skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkill ||
                    skillConfig.SkillType == (int)SkillTypeEnum.PassiveAddProSkillNoFight);

                int i1 = i;
                scrollItemPetbarSetSkillItem.E_IconEventTrigger.gameObject.SetActive(false);
                scrollItemPetbarSetSkillItem.E_IconEventTrigger.triggers.Clear();
                scrollItemPetbarSetSkillItem.E_IconEventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                    (pdata) => { self.OnSkillItemPointerDown(pdata as PointerEventData, skillId); });
                scrollItemPetbarSetSkillItem.E_IconEventTrigger.RegisterEvent(EventTriggerType.BeginDrag,
                    (pdata) => { self.OnSkillItemBeginDrag(pdata as PointerEventData, i1, canDrag); });
                scrollItemPetbarSetSkillItem.E_IconEventTrigger.RegisterEvent(EventTriggerType.Drag,
                    (pdata) => { self.OnSkillItemDraging(pdata as PointerEventData, canDrag); });
                scrollItemPetbarSetSkillItem.E_IconEventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                    (pdata) => { self.OnSkillItemPointerUp(pdata as PointerEventData); });
                scrollItemPetbarSetSkillItem.E_IconEventTrigger.RegisterEvent(EventTriggerType.EndDrag,
                    (pdata) => { self.OnSkillItemEndDrag(pdata as PointerEventData, skillId, canDrag); });
                scrollItemPetbarSetSkillItem.E_IconEventTrigger.gameObject.SetActive(true);
            }

            if (self.ScrollItemPetbarSetSkillItems.Count > self.ShowSKillIds.Count)
            {
                for (int i = self.ShowSKillIds.Count; i < self.ScrollItemPetbarSetSkillItems.Count; i++)
                {
                    Scroll_Item_PetbarSetSkillItem scrollItemPetbarSetSkillItem = self.ScrollItemPetbarSetSkillItems[i];
                    scrollItemPetbarSetSkillItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }

        private static void OnClickSkill(this ES_PetBarSet self, int petIndex, int skillType, int skillIndex)
        {
            self.PetBarIndex = petIndex;
            self.SkillType = skillType;
            self.SkillIndex = skillIndex;

            self.EG_PetPanelRectTransform.gameObject.SetActive(false);
            self.EG_SkillPanelRectTransform.gameObject.SetActive(true);

            self.ES_PetBarSetItem_1.E_HighlightImage.gameObject.SetActive(petIndex == 1);
            self.ES_PetBarSetItem_2.E_HighlightImage.gameObject.SetActive(petIndex == 2);
            self.ES_PetBarSetItem_3.E_HighlightImage.gameObject.SetActive(petIndex == 3);

            self.E_SkillTypeSetToggleGroup.OnSelectIndex(0);
        }
        
        private static void OnSkillItemPointerDown(this ES_PetBarSet self, PointerEventData pdata, int skillId)
        {
            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SkillTips);

            Vector2 localPoint;
            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            DlgSkillTips dlgSkillTips = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSkillTips>();
            dlgSkillTips.OnUpdateData(skillId, new Vector3(localPoint.x, localPoint.y - 300f, 0f), ABAtlasTypes.RoleSkillIcon);
        }

        private static void OnSkillItemBeginDrag(this ES_PetBarSet self, PointerEventData pdata, int index, bool canDrag)
        {
            self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SkillTips);

            if (canDrag)
            {
                self.EG_SkillIconRectTransform.gameObject.SetActive(true);
                Scroll_Item_PetbarSetSkillItem item = self.ScrollItemPetbarSetSkillItems[index];
                self.EG_SkillIconRectTransform.Find("mask/Icon").GetComponent<Image>().sprite = item.E_IconImage.sprite;
            }

            // self.E_PetbarSetSkillItemsLoopVerticalScrollRect.OnBeginDrag(pdata);
        }

        private static void OnSkillItemDraging(this ES_PetBarSet self, PointerEventData pdata, bool canDrag)
        {
            if (canDrag)
            {
                Vector2 localPoint = new Vector3();
                RectTransform canvas = self.EG_SkillIconRectTransform.parent.GetComponent<RectTransform>();
                Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
                self.EG_SkillIconRectTransform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
            }

            // self.E_PetbarSetSkillItemsLoopVerticalScrollRect.OnDrag(pdata);
        }

        private static void OnSkillItemPointerUp(this ES_PetBarSet self, PointerEventData pdata)
        {
            self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SkillTips);
        }

        private static void OnSkillItemEndDrag(this ES_PetBarSet self, PointerEventData pdata, int skillId, bool canDrag)
        {
            if (canDrag)
            {
                RectTransform canvas = self.EG_SkillIconRectTransform.parent.parent.parent.GetComponent<RectTransform>();
                GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
                List<RaycastResult> results = new List<RaycastResult>();
                gr.Raycast(pdata, results);

                for (int i = 0; i < results.Count; i++)
                {
                    string name = results[i].gameObject.name;
                    if (name != "E_AppearSkill" && name != "E_ActiveSkill_0")
                    {
                        continue;
                    }

                    string parentName = results[i].gameObject.transform.parent.name;
                    int petBarSetIndex = int.Parse(parentName.Substring(17, parentName.Length - 17));

                    if (petBarSetIndex != self.PetBarIndex)
                    {
                        continue;
                    }

                    PetBarInfo petBarInfo = self.PetFightList[petBarSetIndex - 1];
                    // 清除相同的技能
                    if (petBarInfo.AppearSkill == skillId)
                    {
                        petBarInfo.AppearSkill = 0;
                    }

                    for (int j = 0; j < petBarInfo.ActiveSkill.Count; j++)
                    {
                        if (petBarInfo.ActiveSkill[j] == skillId)
                        {
                            petBarInfo.ActiveSkill[j] = 0;
                        }
                    }

                    if (name == "E_AppearSkill")
                    {
                        petBarInfo.AppearSkill = skillId;
                    }
                    else
                    {
                        petBarInfo.ActiveSkill.Clear();
                        petBarInfo.ActiveSkill.Add(skillId);
                    }

                    self.OnConfirm().Coroutine();
                    self.InitInfo();

                    break;
                }
            }

            self.EG_SkillIconRectTransform.gameObject.SetActive(false);

            // self.E_PetbarSetPetItemsLoopVerticalScrollRect.OnEndDrag(pdata);
        }

        #endregion
    }
}
