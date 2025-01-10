using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
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

            self.View.E_EnterMapButton.AddListener(self.OnEnterMap);
        }

        public static void ShowWindow(this DlgPetMeleeLevel self, Entity contextData = null)
        {
            self.View.E_SectionSetToggleGroup.OnSelectIndex(0);
            self.OnUpdateStar();
            self.View.E_RightBGImage.gameObject.SetActive(false);
        }

        private static void OnSectionSet(this DlgPetMeleeLevel self, int index)
        {
            self.ShowPetMeleeSceneIds = ConfigData.PetMeleeSectionConfig[index];

            self.AddUIScrollItems(ref self.ScrollItemPetMeleeLevelItems, self.ShowPetMeleeSceneIds.Count);
            self.View.E_PetMeleeLevelItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetMeleeSceneIds.Count);
        }

        private static void OnPetMeleeLevelItemsRefresh(this DlgPetMeleeLevel self, Transform transform, int index)
        {
            Scroll_Item_PetMeleeLevelItem scrollItemPetMeleeLevelItem = self.ScrollItemPetMeleeLevelItems[index].BindTrans(transform);
            scrollItemPetMeleeLevelItem.OnInit(self.ShowPetMeleeSceneIds[index], index);
            scrollItemPetMeleeLevelItem.E_TouchButton.AddListener(() => self.OnLevel(self.ShowPetMeleeSceneIds[index]));
        }

        private static void OnMonsterItemsRefresh(this DlgPetMeleeLevel self, Transform transform, int index)
        {
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
            self.View.E_RewardProgressImage.fillAmount = star / 100f;
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
            foreach (int posi in sceneConfig.CreateMonsterPosi)
            {
                MonsterPositionConfig monsterPositionConfig = MonsterPositionConfigCategory.Instance.Get(posi);
                foreach (int monsterId in monsterPositionConfig.MonsterID)
                {
                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);

                    if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_62)
                    {
                        continue;
                    }

                    if (self.ShowMonsterIds.Contains(monsterId))
                    {
                        continue;
                    }

                    self.ShowMonsterIds.Add(monsterId);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemMonsterItems, self.ShowMonsterIds.Count);
            self.View.E_MonsterItemsLoopVerticalScrollRect.SetVisible(true, self.ShowMonsterIds.Count);

            self.View.ES_RewardList.Refresh(sceneConfig.RewardShow);

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int petMeleeDungeonId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetMeleeDungeonId);

            if (sceneId <= petMeleeDungeonId)
            {
                self.View.E_EnterMapButton.gameObject.SetActive(false);
                if (self.Root().GetComponent<PetComponentC>().PetMeleeRewardIds.Contains(sceneId))
                {
                    self.View.E_ReceiveButton.gameObject.SetActive(false);
                    self.View.E_ReceivedText.gameObject.SetActive(true);
                }
                else
                {
                    self.View.E_ReceiveButton.gameObject.SetActive(true);
                    self.View.E_ReceivedText.gameObject.SetActive(false);
                }
            }
            else
            {
                self.View.E_EnterMapButton.gameObject.SetActive(true);
                self.View.E_ReceiveButton.gameObject.SetActive(false);
                self.View.E_ReceivedText.gameObject.SetActive(false);
            }

            self.View.E_RightBGImage.gameObject.SetActive(true);
        }

        private static void OnEnterMap(this DlgPetMeleeLevel self)
        {
            int firstId = 0;
            foreach (SceneConfig config in SceneConfigCategory.Instance.GetAll().Values)
            {
                if (config.MapType == SceneTypeEnum.PetMelee)
                {
                    firstId = config.Id;
                    break;
                }
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int petMeleeDungeonId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetMeleeDungeonId);
            if (petMeleeDungeonId == 0 && self.SceneId != firstId ||
                petMeleeDungeonId != 0 && self.SceneId > petMeleeDungeonId + 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先通关前面的关卡");
                return;
            }

            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            PetMeleeInfo petMeleeInfo = petComponentC.PetMeleeInfoList[petComponentC.PetMeleePlan];
            if (petMeleeInfo.MainPetList.Count == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("你未携带上阵宠物无法参与。");
                return;
            }

            EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.PetMelee, self.SceneId, FubenDifficulty.Normal, "0").Coroutine();
            self.OnClose();
        }

        private static async ETTask OnReceive(this DlgPetMeleeLevel self)
        {
            int error = await MapHelper.RequestPetMeleeReward(self.Root(), self.SceneId);
            if (error == ErrorCode.ERR_Success)
            {
                self.View.E_ReceiveButton.gameObject.SetActive(false);
                self.View.E_ReceivedText.gameObject.SetActive(true);
            }
        }
    }
}