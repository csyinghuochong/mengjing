using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_MonsterItem))]
    [FriendOf(typeof(Scroll_Item_PetMeleeLevelItem))]
    [FriendOf(typeof(DlgPetMeleeLevel))]
    public static class DlgPetMeleeLevelSystem
    {
        public static void RegisterUIEvent(this DlgPetMeleeLevel self)
        {
            self.View.E_CloseButton.AddListener(self.OnClose);
            self.View.E_PetMeleeButton.AddListener(self.OnPetMelee);

            self.View.E_SectionSetToggleGroup.AddListener(self.OnSectionSet);
            self.View.E_PetMeleeLevelItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetMeleeLevelItemsRefresh);

            self.View.E_Reward1EventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(1, pdata as PointerEventData).Coroutine(); });
            self.View.E_Reward1EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(1, pdata as PointerEventData).Coroutine(); });
            self.View.E_Reward2EventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(2, pdata as PointerEventData).Coroutine(); });
            self.View.E_Reward2EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(2, pdata as PointerEventData).Coroutine(); });
            self.View.E_Reward3EventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(3, pdata as PointerEventData).Coroutine(); });
            self.View.E_Reward3EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(3, pdata as PointerEventData).Coroutine(); });
            self.View.E_Reward4EventTrigger.RegisterEvent(EventTriggerType.PointerDown,
                (pdata) => { self.BeginDrag(4, pdata as PointerEventData).Coroutine(); });
            self.View.E_Reward4EventTrigger.RegisterEvent(EventTriggerType.PointerUp,
                (pdata) => { self.EndDrag(4, pdata as PointerEventData).Coroutine(); });

            self.View.E_ReceiveButton.AddListenerAsync(self.OnReceive);

            self.View.E_MonsterItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnMonsterItemsRefresh);

            self.View.E_EnterMapButton.AddListenerAsync(self.OnEnterMap);
        }

        public static void ShowWindow(this DlgPetMeleeLevel self, Entity contextData = null)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int petMeleeDungeonId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetMeleeDungeonId);
            int itemIndex = 0;
            if (petMeleeDungeonId == 0)
            {
                self.View.E_SectionSetToggleGroup.OnSelectIndex(0);
            }
            else
            {
                bool flag = false;
                for (int i = 0; i < ConfigData.PetMeleeSectionConfig.Count; i++)
                {
                    if (flag)
                    {
                        self.View.E_SectionSetToggleGroup.OnSelectIndex(i - 1);
                        break;
                    }

                    for (int j = 0; j < ConfigData.PetMeleeSectionConfig[i].Count; j++)
                    {
                        if (ConfigData.PetMeleeSectionConfig[i][j] == petMeleeDungeonId)
                        {
                            flag = true;
                            itemIndex = j;
                            break;
                        }
                    }
                }
            }

            self.OnLevel(self.ShowPetMeleeSceneIds[itemIndex]);

            self.OnUpdateStar();
        }

        private static void OnSectionSet(this DlgPetMeleeLevel self, int index)
        {
            self.ShowPetMeleeSceneIds = ConfigData.PetMeleeSectionConfig[index];

            self.AddUIScrollItems(ref self.ScrollItemPetMeleeLevelItems, self.ShowPetMeleeSceneIds.Count);
            self.View.E_PetMeleeLevelItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetMeleeSceneIds.Count);
        }

        private static void OnPetMeleeLevelItemsRefresh(this DlgPetMeleeLevel self, Transform transform, int index)
        {
            foreach (Scroll_Item_PetMeleeLevelItem item in self.ScrollItemPetMeleeLevelItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetMeleeLevelItem scrollItemPetMeleeLevelItem = self.ScrollItemPetMeleeLevelItems[index].BindTrans(transform);
            scrollItemPetMeleeLevelItem.OnInit(self.ShowPetMeleeSceneIds[index], index);
            scrollItemPetMeleeLevelItem.E_TouchButton.AddListener(() => self.OnLevel(self.ShowPetMeleeSceneIds[index]));
            scrollItemPetMeleeLevelItem.SetSelected(self.SelectIndex);
        }

        private static void OnMonsterItemsRefresh(this DlgPetMeleeLevel self, Transform transform, int index)
        {
            foreach (Scroll_Item_MonsterItem item in self.ScrollItemMonsterItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_MonsterItem scrollItemMonsterItem = self.ScrollItemMonsterItems[index].BindTrans(transform);
            scrollItemMonsterItem.Refresh(self.ShowMonsterIds[index]);
        }

        public static async ETTask BeginDrag(this DlgPetMeleeLevel self, int id, PointerEventData pdata)
        {
            if (!PetFubenRewardConfigCategory.Instance.Contain(id))
            {
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CountryTips);
            DlgCountryTips dlgCountryTips = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCountryTips>();
            Vector2 localPoint;
            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            PetMeleeFubenRewardConfig shouJiConfig = PetMeleeFubenRewardConfigCategory.Instance.Get(id);
            string rewards = shouJiConfig.RewardItems;
            dlgCountryTips.OnUpdateUI(rewards, new Vector3(localPoint.x, localPoint.y + 50f, 0f), 1);
        }

        public static async ETTask EndDrag(this DlgPetMeleeLevel self, int id, PointerEventData pdata)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CountryTips);

            if (!PetMeleeFubenRewardConfigCategory.Instance.Contain(id))
            {
                return;
            }

            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int totalStar = petComponentC.GetPetMeleeTotalStar();
            PetMeleeFubenRewardConfig rewardConfig = PetMeleeFubenRewardConfigCategory.Instance.Get(id);

            if (petComponentC.PetMeleeFubeRewardIds.Contains(id))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经领取");
                return;
            }

            if (rewardConfig.NeedStar > totalStar)
            {
                FlyTipComponent.Instance.ShowFlyTip("星星数量不够");
                return;
            }

            long instanceid = self.InstanceId;
            int errorCode = await PetNetHelper.RequestPetMeleeFubenReward(self.Root(), id);
            if (instanceid != self.InstanceId)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CountryTips);
                return;
            }

            if (errorCode == ErrorCode.ERR_Success)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_BaoXiangReward);
                DlgBaoXiangReward dlgBaoXiangReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgBaoXiangReward>();
                dlgBaoXiangReward.OnUpdateUI(rewardConfig.RewardItems);

                petComponentC.PetMeleeFubeRewardIds.Add(id);
                self.OnUpdateStar();
            }
            else
            {
                await PetNetHelper.RequestPetInfo(self.Root());
                self.OnUpdateStar();
            }

            await ETTask.CompletedTask;
        }

        private static void OnUpdateStar(this DlgPetMeleeLevel self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            int star = petComponent.GetPetMeleeTotalStar();
            self.View.E_RewardProgressImage.fillAmount = star <= 100 ? star / 100f : 1f;

            using (zstring.Block())
            {
                self.View.E_Reward1EventTrigger.GetComponentInChildren<Text>().text =
                        zstring.Format("{0}/{1}", star, PetMeleeFubenRewardConfigCategory.Instance.Get(1).NeedStar);
                self.View.E_Reward2EventTrigger.GetComponentInChildren<Text>().text =
                        zstring.Format("{0}/{1}", star, PetMeleeFubenRewardConfigCategory.Instance.Get(2).NeedStar);
                self.View.E_Reward3EventTrigger.GetComponentInChildren<Text>().text =
                        zstring.Format("{0}/{1}", star, PetMeleeFubenRewardConfigCategory.Instance.Get(3).NeedStar);
                self.View.E_Reward4EventTrigger.GetComponentInChildren<Text>().text =
                        zstring.Format("{0}/{1}", star, PetMeleeFubenRewardConfigCategory.Instance.Get(4).NeedStar);
            }

            self.View.E_Reward1EventTrigger.transform.Find("Image_1").gameObject.SetActive(!petComponent.PetMeleeFubeRewardIds.Contains(1));
            self.View.E_Reward1EventTrigger.transform.Find("Image_2").gameObject.SetActive(petComponent.PetMeleeFubeRewardIds.Contains(1));
            self.View.E_Reward2EventTrigger.transform.Find("Image_1").gameObject.SetActive(!petComponent.PetMeleeFubeRewardIds.Contains(2));
            self.View.E_Reward2EventTrigger.transform.Find("Image_2").gameObject.SetActive(petComponent.PetMeleeFubeRewardIds.Contains(2));
            self.View.E_Reward3EventTrigger.transform.Find("Image_1").gameObject.SetActive(!petComponent.PetMeleeFubeRewardIds.Contains(3));
            self.View.E_Reward3EventTrigger.transform.Find("Image_2").gameObject.SetActive(petComponent.PetMeleeFubeRewardIds.Contains(3));
            self.View.E_Reward4EventTrigger.transform.Find("Image_1").gameObject.SetActive(!petComponent.PetMeleeFubeRewardIds.Contains(4));
            self.View.E_Reward4EventTrigger.transform.Find("Image_2").gameObject.SetActive(petComponent.PetMeleeFubeRewardIds.Contains(4));
        }

        private static void OnClose(this DlgPetMeleeLevel self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMeleeLevel);
        }

        private static void OnPetMelee(this DlgPetMeleeLevel self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMelee).Coroutine();
        }

        private static void OnLevel(this DlgPetMeleeLevel self, int sceneId)
        {
            self.SelectIndex = sceneId;
            
            for (int i = 0; i < self.ScrollItemPetMeleeLevelItems.Count; i++)
            {
                Scroll_Item_PetMeleeLevelItem scrollItemPetMeleeLevelItem = self.ScrollItemPetMeleeLevelItems[i];
                if (scrollItemPetMeleeLevelItem.uiTransform != null)
                {
                    scrollItemPetMeleeLevelItem.SetSelected(sceneId);
                }
            }

            self.SceneId = sceneId;
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            self.View.E_LevelNameText.text = sceneConfig.Name;

            self.ShowMonsterIds.Clear();
            self.ShowMonsterIds = MapViewHelper.GetSceneShowMonsters(sceneId);

            self.AddUIScrollItems(ref self.ScrollItemMonsterItems, self.ShowMonsterIds.Count);
            self.View.E_MonsterItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMonsterIds.Count);

            self.View.ES_RewardList.Refresh(sceneConfig.RewardShow);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int petMeleeDungeonId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetMeleeDungeonId);

            if (sceneId <= petMeleeDungeonId)
            {
                if (self.Root().GetComponent<PetComponentC>().PetMeleeRewardIds.Contains(sceneId))
                {
                    self.View.E_ReceiveButton.gameObject.SetActive(false);
                    self.View.EG_ReceivedRectTransform.gameObject.SetActive(true);
                    self.View.E_EnterMapButton.gameObject.SetActive(true);
                }
                else
                {
                    self.View.E_ReceiveButton.gameObject.SetActive(true);
                    self.View.EG_ReceivedRectTransform.gameObject.SetActive(false);
                    self.View.E_EnterMapButton.gameObject.SetActive(false);
                }
            }
            else
            {
                self.View.E_ReceiveButton.gameObject.SetActive(false);
                self.View.EG_ReceivedRectTransform.gameObject.SetActive(false);
                self.View.E_EnterMapButton.gameObject.SetActive(true);
            }

            self.View.E_RightBGImage.gameObject.SetActive(true);
        }

        private static async ETTask OnEnterMap(this DlgPetMeleeLevel self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int petMeleeDungeonId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetMeleeDungeonId);
            if (petMeleeDungeonId == 0 && self.SceneId != ConfigData.PetMeleeSectionConfig[0][0])
            {
                FlyTipComponent.Instance.ShowFlyTip("请先通关前面的关卡");
                return;
            }

            if (petMeleeDungeonId != 0)
            {
                bool flag = false;
                int nextId = 0;
                foreach (List<int> list in ConfigData.PetMeleeSectionConfig)
                {
                    if (nextId != 0)
                    {
                        break;
                    }

                    foreach (int id in list)
                    {
                        if (id == petMeleeDungeonId)
                        {
                            flag = true;
                            continue;
                        }

                        if (flag)
                        {
                            nextId = id;
                            break;
                        }
                    }
                }

                if (nextId != 0 && self.SceneId > nextId)
                {
                    FlyTipComponent.Instance.ShowFlyTip("请先通关前面的关卡");
                    return;
                }
            }

            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            PetMeleeInfo petMeleeInfo = petComponentC.PetMeleeInfoList[petComponentC.PetMeleePlan];
            if (petMeleeInfo.MainPetList.Count == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("你未携带上阵宠物无法参与。");
                return;
            }

            long instanceid = self.InstanceId;  
            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.PetMelee, self.SceneId, FubenDifficulty.Normal, "0");
            if (instanceid!= self.InstanceId)
            {
                return; 
            }

            if (errorCode == ErrorCode.ERR_Success)
            {
                self.OnClose();
            }
        }

        private static async ETTask OnReceive(this DlgPetMeleeLevel self)
        {
            int error = await MapHelper.RequestPetMeleeReward(self.Root(), self.SceneId);
            if (error == ErrorCode.ERR_Success)
            {
                self.View.E_ReceiveButton.gameObject.SetActive(false);
                self.View.EG_ReceivedRectTransform.gameObject.SetActive(true);
                self.View.E_EnterMapButton.gameObject.SetActive(true);
            }
        }
    }
}