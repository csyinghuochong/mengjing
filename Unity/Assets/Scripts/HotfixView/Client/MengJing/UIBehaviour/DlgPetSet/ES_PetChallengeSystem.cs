using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetChallenge))]
    [FriendOfAttribute(typeof(ES_PetChallenge))]
    [FriendOf(typeof(ES_PetFormationSet))]
    [FriendOfAttribute(typeof(Scroll_Item_PetChallengeItem))]
    public static partial class ES_PetChallengeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetChallenge self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_PetChallengeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetChallengeItemsRefresh);

            self.E_ButtonSet.AddListener(() => { self.OnButtonSet().Coroutine(); });
            self.E_ButtonChallenge.AddListener(() => { self.OnButtonChallenge().Coroutine(); });

            self.E_ButtonReward.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
            self.E_ButtonReward.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.EndDrag(pdata as PointerEventData).Coroutine(); });

            self.InitSubView();
            self.OnUpdateStar();
            self.InitItemList();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetChallenge self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonSet(this ES_PetChallenge self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetFormation);
            DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
            dlgPetFormation.OnInitUI(MapTypeEnum.PetDungeon, self.UpdateFormationSet);
        }

        public static void RequestFormationSet(this ES_PetChallenge self, long rolePetInfoId, int index, int operateType)
        {
            DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
            dlgPetFormation.OnDragFormationSet(rolePetInfoId, index, operateType);
        }

        public static void UpdateFormationSet(this ES_PetChallenge self)
        {
            self.ES_PetFormationSet.OnUpdateFormation(MapTypeEnum.PetDungeon,
                self.Root().GetComponent<PetComponentC>().PetFormations, false);
        }

        public static void InitSubView(this ES_PetChallenge self)
        {
            self.ES_PetFormationSet.DragEndHandler = self.RequestFormationSet;
            self.ES_PetFormationSet.OnUpdateFormation(MapTypeEnum.PetDungeon,
                self.Root().GetComponent<PetComponentC>().PetFormations, false);

            int sceneId = BattleHelper.GetSceneIdByType(MapTypeEnum.PetDungeon);
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            using (zstring.Block())
            {
                self.E_TextTimes.GetComponent<Text>().text =
                        zstring.Format("{0}/{1}", userInfoComponent.GetSceneFubenTimes(sceneId), sceneConfig.DayEnterNum);
            }
        }

        public static async ETTask BeginDrag(this ES_PetChallenge self, PointerEventData pdata)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            if (!PetFubenRewardConfigCategory.Instance.Contain(self.ShowReward))
            {
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CountryTips);
            DlgCountryTips dlgCountryTips = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCountryTips>();
            Vector2 localPoint;
            RectTransform canvas = self.Root().GetComponent<GlobalComponent>().NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);

            PetFubenRewardConfig shouJiConfig = PetFubenRewardConfigCategory.Instance.Get(self.ShowReward);
            string rewards = shouJiConfig.RewardItems;
            dlgCountryTips.OnUpdateUI(rewards, new Vector3(localPoint.x, localPoint.y + 50f, 0f), 1);
        }

        public static async ETTask EndDrag(this ES_PetChallenge self, PointerEventData pdata)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            int canRewardId = petComponent.GetCanRewardId();
            if (canRewardId == 0)
            {
                return;
            }

            long instanceid = self.InstanceId;
            int errorCode = await PetNetHelper.RequestPetFubenReward(self.Root());
            if (instanceid != self.InstanceId)
            {
                return;
            }

            if (errorCode == ErrorCode.ERR_Success)
            {
                petComponent.PetFubeRewardId = canRewardId;
                self.OnUpdateStar();
            }
            else
            {
                await PetNetHelper.RequestPetInfo(self.Root());
                self.OnUpdateStar();
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CountryTips);
        }

        public static async ETTask OnButtonChallenge(this ES_PetChallenge self)
        {
            bool locked = false;
            foreach (Scroll_Item_PetChallengeItem item in self.ScrollItemPetChallengeItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                if (item.PetFubenId == self.PetFubenId)
                {
                    locked = item.E_Node_2.gameObject.activeSelf;
                }
            }

            if (locked)
            {
                FlyTipComponent.Instance.ShowFlyTip("关卡未解锁！");
                return;
            }

            bool havepet = false;
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            for (int i = 0; i < petComponent.PetFormations.Count; i++)
            {
                if (petComponent.PetFormations[i] != 0)
                {
                    havepet = true;
                    break;
                }
            }

            if (!havepet)
            {
                FlyTipComponent.Instance.ShowFlyTip("请设置上阵宠物！");
                return;
            }

            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), (int)MapTypeEnum.PetDungeon,
                BattleHelper.GetSceneIdByType(MapTypeEnum.PetDungeon), 0, self.PetFubenId.ToString());
            if (errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetSet);
        }

        public static void OnUpdateStar(this ES_PetChallenge self)
        {
            List<PetFubenRewardConfig> petFubenRewardConfigs = PetFubenRewardConfigCategory.Instance.GetAll().Values.ToList();
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            int canrewardId = petComponent.GetCanRewardId();
            int fubenreward = petComponent.PetFubeRewardId;

            int rewardid = 0;
            if (fubenreward == 0 && canrewardId == 0)
            {
                rewardid = petFubenRewardConfigs[0].Id;
            }

            if (fubenreward == 0 && canrewardId != 0)
            {
                rewardid = canrewardId;
            }

            if (fubenreward != 0 && canrewardId == 0)
            {
                rewardid = fubenreward + 1;
            }

            if (fubenreward != 0 && canrewardId != 0)
            {
                rewardid = canrewardId;
            }

            if (!PetFubenRewardConfigCategory.Instance.Contain(rewardid))
            {
                self.ShowReward = 0;
                self.E_TextStar.GetComponent<Text>().text = string.Empty;
            }
            else
            {
                self.ShowReward = rewardid;
                PetFubenRewardConfig petFubenRewardConfig = PetFubenRewardConfigCategory.Instance.Get(rewardid);
                using (zstring.Block())
                {
                    self.E_TextStar.GetComponent<Text>().text = zstring.Format("{0}/{1}", petComponent.GetTotalStar(), petFubenRewardConfig.NeedStar);
                }
            }
        }

        private static void OnPetChallengeItemsRefresh(this ES_PetChallenge self, Transform transform, int index)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int petfubenId = petComponentC.GetPetFuben();

            using (zstring.Block())
            {
                Log.Debug(zstring.Format("self.uiTransform != null:  {0}", self.ShowPetFubenConfig[index].Id));
            }

            foreach (Scroll_Item_PetChallengeItem item in self.ScrollItemPetChallengeItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PetChallengeItem scrollItemNPetChallengeItem =
                    self.ScrollItemPetChallengeItems[index].BindTrans(transform);

            bool locked = index > 0 && self.ShowPetFubenConfig[index].Id - petfubenId >= 2;
            scrollItemNPetChallengeItem
                    .OnUpdateUI(self.ShowPetFubenConfig[index], index, petComponentC.GetFubenStar(self.ShowPetFubenConfig[index].Id), locked)
                    .Coroutine();
            scrollItemNPetChallengeItem.SetClickHandler(self.OnClickChallengeItem);
        }

        public static void OnClickChallengeItem(this ES_PetChallenge self, int petfubenId)
        {
            self.PetFubenId = petfubenId;
            foreach (Scroll_Item_PetChallengeItem item in self.ScrollItemPetChallengeItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                item.SetSelected(petfubenId);
            }
        }

        public static void InitItemList(this ES_PetChallenge self)
        {
            Log.Debug("ES_PetChallenge.OnInitUI");

            self.ShowPetFubenConfig.Clear();
            List<PetFubenConfig> petFubenConfigs = PetFubenConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < petFubenConfigs.Count; i++)
            {
                self.ShowPetFubenConfig.Add(petFubenConfigs[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemPetChallengeItems, petFubenConfigs.Count);
            self.E_PetChallengeItemsLoopVerticalScrollRect.SetVisible(true, petFubenConfigs.Count);
        }
    }
}