using System.Collections.Generic;
using System.Linq;
using ET.Server;
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
        private static void Awake(this ET.Client.ES_PetChallenge self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;
            
            self.E_PetChallengeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetChallengeItemsRefresh);

            self.E_ButtonSet.AddListener(() => { self.OnButtonSet().Coroutine(); } );
            self.E_ButtonChallenge.AddListener(() => { self.OnButtonChallenge().Coroutine(); });
            
            self.E_ButtonReward.RegisterEvent(EventTriggerType.PointerDown, ( pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
            self.E_ButtonReward.RegisterEvent(EventTriggerType.PointerUp, ( pdata) => { self.EndDrag(pdata as PointerEventData).Coroutine(); });
            
            self.InitSubView();
            self.OnUpdateStar();
            self.InitItemList();
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_PetChallenge self)
        {
            self.DestroyWidget();
        }

        public static  async ETTask OnButtonSet(this ES_PetChallenge self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetFormation);
            DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
            dlgPetFormation.OnInitUI(SceneTypeEnum.PetDungeon, self.UpdateFormationSet);
        }
        
        public static void RequestFormationSet(this ES_PetChallenge self, long rolePetInfoId, int index, int operateType)
        {
            DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
            dlgPetFormation.OnDragFormationSet(rolePetInfoId, index, operateType);
        }
        
        public static void UpdateFormationSet(this ES_PetChallenge self)
        {
            self.ES_PetFormationSet.OnUpdateFormation(SceneTypeEnum.PetDungeon,
                self.Root().GetComponent<PetComponentC>().PetFormations, false);
        }

        public static void InitSubView(this ES_PetChallenge self)
        {
            self.ES_PetFormationSet.DragEndHandler = self.RequestFormationSet;
            self.ES_PetFormationSet.OnUpdateFormation(SceneTypeEnum.PetDungeon,
                self.Root().GetComponent<PetComponentC>().PetFormations, false);

            int sceneId = BattleHelper.GetSceneIdByType(SceneTypeEnum.PetDungeon);
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneId);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            self.E_TextTimes.GetComponent<Text>().text = $"{userInfoComponent.GetSceneFubenTimes(sceneId)}/{sceneConfig.DayEnterNum}";
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
        
        public static async  ETTask EndDrag(this ES_PetChallenge self, PointerEventData pdata)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            int canRewardId = petComponent.GetCanRewardId();
            if (canRewardId == 0)
            {
                return;
            }

            long instanceid = self.InstanceId;
            int errorCode = await PetNetHelper.RequestPetFubenReward( self.Root() );
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
            foreach (var item in self.ScrollItemPetChallengeItems)
            {
                if (item.Value.uiTransform == null)
                {
                    continue;
                }

                if (item.Value.PetFubenId == self.PetFubenId)
                {
                    locked = item.Value.E_Node_2.gameObject.activeSelf;
                }
            }
            if (locked)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("关卡未解锁！");
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
                FlyTipComponent.Instance.SpawnFlyTipDi("请设置上阵宠物！");
                return;
            }

            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), (int)SceneTypeEnum.PetDungeon, BattleHelper.GetSceneIdByType(SceneTypeEnum.PetDungeon), 0, self.PetFubenId.ToString());
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
                self.E_TextStar.GetComponent<Text>().text = $"{petComponent.GetTotalStar()}/{petFubenRewardConfig.NeedStar}";
            }
        }
        
        private static void OnPetChallengeItemsRefresh(this ES_PetChallenge self, Transform transform, int index)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int petfubenId = petComponentC.GetPetFuben();
            
            Log.Debug($"self.uiTransform != null:  {self.ShowPetFubenConfig[index].Id}");
            Scroll_Item_PetChallengeItem scrollItemNPetChallengeItem=
                    self.ScrollItemPetChallengeItems[index].BindTrans(transform);
            
            bool locked = index > 0 && self.ShowPetFubenConfig[index].Id - petfubenId >= 2;
            scrollItemNPetChallengeItem.OnUpdateUI(self.ShowPetFubenConfig[index], index,  petComponentC.GetFubenStar(self.ShowPetFubenConfig[index].Id), locked).Coroutine();
            scrollItemNPetChallengeItem.SetClickHandler(self.OnClickChallengeItem);
        }
        
        public static void OnClickChallengeItem(this ES_PetChallenge self, int petfubenId)
        {
            self.PetFubenId = petfubenId;
            foreach (var item in self.ScrollItemPetChallengeItems)
            {
                if (item.Value.uiTransform == null)
                {
                    continue;
                }

                item.Value.SetSelected(petfubenId);
            }
        }
        
        public static void InitItemList(this ES_PetChallenge self)
        {
            Log.Debug("ES_PetChallenge.OnInitUI");
            self.ShowPetFubenConfig.Clear();
            self.ScrollItemPetChallengeItems.Clear();
            List<PetFubenConfig> petFubenConfigs = PetFubenConfigCategory.Instance.GetAll().Values.ToList();
            for (int i = 0; i < petFubenConfigs.Count; i++)
            {
                self.ShowPetFubenConfig.Add( petFubenConfigs[i] );
            }

            self.AddUIScrollItems(ref self.ScrollItemPetChallengeItems, petFubenConfigs.Count);
            self.E_PetChallengeItemsLoopVerticalScrollRect.SetVisible(true, petFubenConfigs.Count);
        }
    }

}