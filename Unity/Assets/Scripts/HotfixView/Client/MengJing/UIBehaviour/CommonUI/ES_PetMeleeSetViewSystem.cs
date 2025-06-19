using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SelectMagicItem))]
    [FriendOf(typeof(Scroll_Item_SelectAssistPetItem))]
    [FriendOf(typeof(Scroll_Item_SelectMainPetItem))]
    [EntitySystemOf(typeof(ES_PetMeleeSet))]
    [FriendOfAttribute(typeof(ES_PetMeleeSet))]
    public static partial class ES_PetMeleeSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetMeleeSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMelee); });
            self.E_PlanSetToggleGroup.AddListener((index) => { self.OnPlanSet(index).Coroutine(); });

            self.E_SetMainButton.AddListener(self.OnSetMain);
            self.E_SetAssistButton.AddListener(self.OnSetAssist);
            self.E_SetMagicButton.AddListener(self.OnSetMagic);

            self.MainPetItem = self.EG_MainPetListRectTransform.GetChild(0).gameObject;
            self.AssistPetItem = self.EG_AssistPetListRectTransform.GetChild(0).gameObject;
            self.MagicItem = self.EG_MagicListRectTransform.GetChild(0).gameObject;
            self.InitItemList();

            self.E_SelectMainPetItemCloseButton.AddListener(self.OnSelectMainPetItemClose);
            self.E_SelectMainPetItemClose_2Button.AddListener(self.OnSelectMainPetItemClose);
            self.E_SelectMainPetItemConfirmButton.AddListener(self.OnSelectMainPetItemConfirm);
            self.E_SelectMainPetItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSelectMainPetItemsRefresh);
            self.EG_SelectMainPetItemPanelRectTransform.gameObject.SetActive(false);

            self.E_SelectAssistPetItemCloseButton.AddListener(self.OnSelectAssistPetItemClose);
            self.E_SelectAssistPetItemClose_2Button.AddListener(self.OnSelectAssistPetItemClose);
            self.E_SelectAssistPetItemConfirmButton.AddListener(self.OnSelectAssistPetItemConfirm);
            self.E_SelectAssistPetItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSelectAssistPetItemsRefresh);
            self.EG_SelectAssistPetItemPanelRectTransform.gameObject.SetActive(false);

            self.E_SelectMagicItemCloseButton.AddListener(self.OnSelectSkillItemClose);
            self.E_SelectMagicItemClose_2Button.AddListener(self.OnSelectSkillItemClose);
            self.E_SelectMagicItemConfirmButton.AddListener(self.OnSelectSkillItemConfirm);
            self.E_SelectMagicItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnSelectSkillItemsRefresh);
            self.EG_SelectMagicItemPanelRectTransform.gameObject.SetActive(false);

            self.E_PlanSetToggleGroup.OnSelectIndex(self.Root().GetComponent<PetComponentC>().PetMeleePlan);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetMeleeSet self)
        {
            self.DestroyWidget();
        }

        private static void InitItemList(this ES_PetMeleeSet self)
        {
            self.MainPetItemList.Add(self.MainPetItem);
            for (int i = 1; i < 6; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.MainPetItem, self.MainPetItem.transform.parent);
                self.MainPetItemList.Add(go);
            }

            self.AssistPetItemList.Add(self.AssistPetItem);
            for (int i = 1; i < 12; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.AssistPetItem, self.AssistPetItem.transform.parent);
                self.AssistPetItemList.Add(go);
            }

            self.MagicItemList.Add(self.MagicItem);
            for (int i = 1; i < 6; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(self.MagicItem, self.MagicItem.transform.parent);
                self.MagicItemList.Add(go);
            }
        }

        private static void RefreshItemList(this ES_PetMeleeSet self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            for (int i = 0; i < 6; i++)
            {
                Sprite sprite = null;
                if (i < self.PetMeleeInfo.MainPetList.Count)
                {
                    long petId = self.PetMeleeInfo.MainPetList[i];
                    RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(petId);
                    PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
                    sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                }

                GameObject go = self.MainPetItemList[i];
                if (sprite != null)
                {
                    go.transform.Find("Mask/Icon").gameObject.SetActive(true);
                    go.transform.Find("Mask/Icon").GetComponent<Image>().sprite = sprite;
                }
                else
                {
                    go.transform.Find("Mask/Icon").gameObject.SetActive(false);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                GameObject go = self.AssistPetItemList[i];
                if (i < self.PetMeleeInfo.AssistPetList.Count)
                {
                    int petTuJianConfigId = self.PetMeleeInfo.AssistPetList[i];
                    PetConfig petTuJianConfig = PetConfigCategory.Instance.Get(petTuJianConfigId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petTuJianConfig.HeadIcon.ToString());
                    Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    go.transform.Find("mask/Icon").gameObject.SetActive(true);
                    go.transform.Find("mask/Icon").GetComponent<Image>().sprite = sprite;
                }
                else
                {
                    go.transform.Find("mask/Icon").gameObject.SetActive(false);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                GameObject go = self.MagicItemList[i];
                GameObject icon = go.transform.Find("mask/Icon").gameObject;
                if (i < self.PetMeleeInfo.MagicList.Count)
                {
                    int magicConfigId = self.PetMeleeInfo.MagicList[i];
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(magicConfigId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, petMagicCardConfig.Icon.ToString());
                    Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    icon.gameObject.SetActive(true);
                    icon.GetComponent<Image>().sprite = sprite;

                    icon.GetComponent<EventTrigger>().triggers.Clear();
                    icon.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerDown,
                        (pdata) =>
                        {
                            PointerEventData p = pdata as PointerEventData;

                            self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SkillTips);
                            Vector2 localPoint;
                            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
                            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
                            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, p.position, uiCamera, out localPoint);
                            DlgSkillTips dlgSkillTips = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgSkillTips>();
                            dlgSkillTips.OnUpdateData(petMagicCardConfig.SkillId, new Vector3(localPoint.x, localPoint.y + 150f, 0f),
                                ABAtlasTypes.RoleSkillIcon);
                        });
                    icon.GetComponent<EventTrigger>().RegisterEvent(EventTriggerType.PointerUp,
                        (pdata) => { self.Root().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SkillTips); });
                }
                else
                {
                    icon.gameObject.SetActive(false);
                }
            }
        }

        private static async ETTask OnPlanSet(this ES_PetMeleeSet self, int index)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();

            if (petComponentC.PetMeleePlan != index)
            {
                int error = await PetNetHelper.RequestPetMeleePlan(self.Root(), MapTypeEnum.PetMelee, index);

                if (error == ErrorCode.ERR_Success)
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("宠物乱斗切换 {0}", index));
                    }
                }
            }

            // 复制一份
            if (self.PetMeleeInfo == null)
            {
                self.PetMeleeInfo = PetMeleeInfo.Create();
            }

            self.PetMeleeInfo.MainPetList.Clear();
            self.PetMeleeInfo.AssistPetList.Clear();
            self.PetMeleeInfo.MagicList.Clear();

            PetMeleeInfo petMeleeInfo = petComponentC.PetMeleeInfoList[petComponentC.PetMeleePlan];
            self.PetMeleeInfo.MainPetList.AddRange(petMeleeInfo.MainPetList);
            self.PetMeleeInfo.AssistPetList.AddRange(petMeleeInfo.AssistPetList);
            self.PetMeleeInfo.MagicList.AddRange(petMeleeInfo.MagicList);

            self.RefreshItemList();

            await ETTask.CompletedTask;
        }

        private static void OnSetMain(this ES_PetMeleeSet self)
        {
            self.EG_SelectMainPetItemPanelRectTransform.gameObject.SetActive(true);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(false);

            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;
            self.ShowMainPets.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                self.ShowMainPets.Add(rolePetInfos[i]);
            }

            self.SelectMainPets.Clear();
            self.SelectMainPets.AddRange(self.PetMeleeInfo.MainPetList);

            self.AddUIScrollItems(ref self.ScrollItemSelectMainPetItems, self.ShowMainPets.Count);
            self.E_SelectMainPetItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMainPets.Count);
            self.OnUpdateSelectMainPetItem();
        }

        private static void OnSelectMainPetItemClose(this ES_PetMeleeSet self)
        {
            self.EG_SelectMainPetItemPanelRectTransform.gameObject.SetActive(false);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(true);
        }

        private static void OnSelectMainPetItemConfirm(this ES_PetMeleeSet self)
        {
            self.PetMeleeInfo.MainPetList.Clear();
            self.PetMeleeInfo.MainPetList.AddRange(self.SelectMainPets);
            self.EG_SelectMainPetItemPanelRectTransform.gameObject.SetActive(false);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(true);
            self.OnConfirm().Coroutine();
        }

        private static void OnSelectMainPetItemsRefresh(this ES_PetMeleeSet self, Transform transform, int index)
        {
            foreach (Scroll_Item_SelectMainPetItem item in self.ScrollItemSelectMainPetItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_SelectMainPetItem scrollItemSelectMainPetItem = self.ScrollItemSelectMainPetItems[index].BindTrans(transform);
            scrollItemSelectMainPetItem.Refresh(self.ShowMainPets[index]);
            scrollItemSelectMainPetItem.OnSelectMainPetItem = self.OnSelectMainPetItem;
        }

        private static void OnSelectMainPetItem(this ES_PetMeleeSet self, long petId)
        {
            if (petId == 0)
            {
                return;
            }

            int maxNum = ConfigData.PetMeleeMainPetMaxNum;
            if (self.SelectMainPets.Contains(petId))
            {
                self.SelectMainPets.Remove(petId);
            }
            else
            {
                if (self.SelectMainPets.Count < maxNum)
                {
                    self.SelectMainPets.Add(petId);
                }
                else
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("主战宠物最多选{0}个！", maxNum));
                    }

                    return;
                }
            }

            List<long> copy = new List<long>();
            copy.AddRange(self.SelectMainPets);
            self.SelectMainPets.Clear();
            foreach (RolePetInfo rolePetInfo in self.ShowMainPets)
            {
                if (copy.Contains(rolePetInfo.Id))
                {
                    self.SelectMainPets.Add(rolePetInfo.Id);
                }
            }

            self.OnUpdateSelectMainPetItem();

            using (zstring.Block())
            {
                self.E_SelectMainPetItemNumText.text = zstring.Format("已经选择数量：{0}/{1}", self.SelectMainPets.Count, maxNum);
            }
        }

        private static void OnUpdateSelectMainPetItem(this ES_PetMeleeSet self)
        {
            foreach (Scroll_Item_SelectMainPetItem item in self.ScrollItemSelectMainPetItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                item.E_SelectedImage.gameObject.SetActive(self.SelectMainPets.Contains(item.PetId));
            }
        }

        private static void OnSetAssist(this ES_PetMeleeSet self)
        {
            self.EG_SelectAssistPetItemPanelRectTransform.gameObject.SetActive(true);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(false);

            self.ShowAssistPets.Clear();
            foreach (int id in self.Root().GetComponent<ChengJiuComponentC>().PetTuJianActives)
            {
                //[优先处理]梦境宠物上阵辅战不要出现这个宠物   2025/06/19/20:53
                if (id == 20003)
                {
                    continue;
                }

                self.ShowAssistPets.Add(id);
            }

            self.SelectAssistPets.Clear();
            self.SelectAssistPets.AddRange(self.PetMeleeInfo.AssistPetList);

            self.AddUIScrollItems(ref self.ScrollItemSelectAssistPetItems, self.ShowAssistPets.Count);
            self.E_SelectAssistPetItemsLoopVerticalScrollRect.SetVisible(true, self.ShowAssistPets.Count);
            self.OnUpdateSelectAssistPetItem();
        }

        private static void OnSelectAssistPetItemClose(this ES_PetMeleeSet self)
        {
            self.EG_SelectAssistPetItemPanelRectTransform.gameObject.SetActive(false);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(true);
        }

        private static void OnSelectAssistPetItemConfirm(this ES_PetMeleeSet self)
        {
            self.PetMeleeInfo.AssistPetList.Clear();
            self.PetMeleeInfo.AssistPetList.AddRange(self.SelectAssistPets);
            self.EG_SelectAssistPetItemPanelRectTransform.gameObject.SetActive(false);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(true);
            self.OnConfirm().Coroutine();
        }

        private static void OnSelectAssistPetItemsRefresh(this ES_PetMeleeSet self, Transform transform, int index)
        {
            foreach (Scroll_Item_SelectAssistPetItem item in self.ScrollItemSelectAssistPetItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_SelectAssistPetItem scrollItemSelectMainPetItem = self.ScrollItemSelectAssistPetItems[index].BindTrans(transform);
            scrollItemSelectMainPetItem.Refresh(self.ShowAssistPets[index]);
            scrollItemSelectMainPetItem.OnSelectAssistPetItem = self.OnSelectAssistPetItem;
        }

        private static void OnSelectAssistPetItem(this ES_PetMeleeSet self, int petTuJianConfigId)
        {
            if (petTuJianConfigId == 0)
            {
                return;
            }

            int maxNum = ConfigData.PetMeleeAssistPetMaxNum;
            if (self.SelectAssistPets.Contains(petTuJianConfigId))
            {
                self.SelectAssistPets.Remove(petTuJianConfigId);
            }
            else
            {
                if (self.SelectAssistPets.Count < maxNum)
                {
                    self.SelectAssistPets.Add(petTuJianConfigId);
                }
                else
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("辅战宠物最多选{0}个！", maxNum));
                    }

                    return;
                }
            }

            List<int> copy = new List<int>();
            copy.AddRange(self.SelectAssistPets);
            self.SelectAssistPets.Clear();
            foreach (int id in self.ShowAssistPets)
            {
                if (copy.Contains(id))
                {
                    self.SelectAssistPets.Add(id);
                }
            }

            self.OnUpdateSelectAssistPetItem();

            using (zstring.Block())
            {
                self.E_SelectAssistPetItemNumText.text = zstring.Format("已经选择数量：{0}/{1}", self.SelectAssistPets.Count, maxNum);
            }
        }

        private static void OnUpdateSelectAssistPetItem(this ES_PetMeleeSet self)
        {
            foreach (Scroll_Item_SelectAssistPetItem item in self.ScrollItemSelectAssistPetItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                item.E_SelectedImage.gameObject.SetActive(self.SelectAssistPets.Contains(item.PetTuJianConfigId));
            }
        }

        private static void OnSetMagic(this ES_PetMeleeSet self)
        {
            self.EG_SelectMagicItemPanelRectTransform.gameObject.SetActive(true);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(false);

            self.ShowMagics.Clear();
            self.ShowMagics.AddRange(ConfigData.PetMeleeMagicTest);

            self.SelectMagics.Clear();
            self.SelectMagics.AddRange(self.PetMeleeInfo.MagicList);

            self.AddUIScrollItems(ref self.ScrollItemSelectMagicItems, self.ShowMagics.Count);
            self.E_SelectMagicItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMagics.Count);
            self.OnUpdateSelectSkillItem();
        }

        private static void OnSelectSkillItemClose(this ES_PetMeleeSet self)
        {
            self.EG_SelectMagicItemPanelRectTransform.gameObject.SetActive(false);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(true);
        }

        private static void OnSelectSkillItemConfirm(this ES_PetMeleeSet self)
        {
            self.PetMeleeInfo.MagicList.Clear();
            self.PetMeleeInfo.MagicList.AddRange(self.SelectMagics);
            self.EG_SelectMagicItemPanelRectTransform.gameObject.SetActive(false);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMelee>().View.E_FunctionSetBtnToggleGroup.gameObject.SetActive(true);
            self.OnConfirm().Coroutine();
        }

        private static void OnSelectSkillItemsRefresh(this ES_PetMeleeSet self, Transform transform, int index)
        {
            foreach (Scroll_Item_SelectMagicItem item in self.ScrollItemSelectMagicItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_SelectMagicItem scrollItemSelectMagicItem = self.ScrollItemSelectMagicItems[index].BindTrans(transform);
            scrollItemSelectMagicItem.Refresh(self.ShowMagics[index]);
            scrollItemSelectMagicItem.OnSelectSkillItem = self.OnSelectSkillItem;
        }

        private static void OnSelectSkillItem(this ES_PetMeleeSet self, int skillId)
        {
            if (skillId == 0)
            {
                return;
            }

            int maxNum = ConfigData.PetMeleeSkillMaxNum;
            if (self.SelectMagics.Contains(skillId))
            {
                self.SelectMagics.Remove(skillId);
            }
            else
            {
                if (self.SelectMagics.Count < maxNum)
                {
                    self.SelectMagics.Add(skillId);
                }
                else
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("魔法卡最多选{0}个！", maxNum));
                    }

                    return;
                }
            }

            List<int> copy = new List<int>();
            copy.AddRange(self.SelectMagics);
            self.SelectMagics.Clear();
            foreach (int id in self.ShowMagics)
            {
                if (copy.Contains(id))
                {
                    self.SelectMagics.Add(id);
                }
            }

            self.OnUpdateSelectSkillItem();

            using (zstring.Block())
            {
                self.E_SelectMagicItemNumText.text = zstring.Format("已经选择数量：{0}/{1}", self.SelectMagics.Count, maxNum);
            }
        }

        private static void OnUpdateSelectSkillItem(this ES_PetMeleeSet self)
        {
            foreach (Scroll_Item_SelectMagicItem item in self.ScrollItemSelectMagicItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                item.E_SelectedImage.gameObject.SetActive(self.SelectMagics.Contains(item.magicId));
            }
        }

        private static async ETTask OnConfirm(this ES_PetMeleeSet self)
        {
            int error = await PetNetHelper.RequestPetMeleeSet(self.Root(), self.PetMeleeInfo);
            if (error == ErrorCode.ERR_Success)
            {
                self.RefreshItemList();
                FlyTipComponent.Instance.ShowFlyTip("设置成功！");
            }
        }
    }
}