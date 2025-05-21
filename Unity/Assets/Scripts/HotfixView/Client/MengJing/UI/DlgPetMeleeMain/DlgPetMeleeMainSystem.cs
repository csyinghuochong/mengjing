using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterUnitCreate_UpdateDlgPetMeleeMain : AEvent<Scene, AfterUnitCreate>
    {
        protected override async ETTask Run(Scene scene, AfterUnitCreate args)
        {
            scene.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>()?.OnUnitNumUpdate();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class UnitRemove_UpdateDlgPetMeleeMain : AEvent<Scene, UnitRemove>
    {
        protected override async ETTask Run(Scene root, UnitRemove args)
        {
            root.GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>()?.OnUnitNumUpdate();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class PetMeleeDealCards_Refresh : AEvent<Scene, PetMeleeDealCards>
    {
        protected override async ETTask Run(Scene scene, PetMeleeDealCards args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>()?.DealCards(args.PetMeleeCards);

            await ETTask.CompletedTask;
        }
    }

    [Invoke(TimerInvokeType.UIPetMeleeMain)]
    public class UIPetMeleeMain : ATimer<DlgPetMeleeMain>
    {
        protected override void Run(DlgPetMeleeMain self)
        {
            try
            {
                self.OnTimer();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }

    [FriendOf(typeof(ES_PetMeleeCard))]
    [FriendOf(typeof(DlgPetMeleeMainViewComponent))]
    [FriendOf(typeof(Scroll_Item_PetMeleeItem))]
    [FriendOf(typeof(DlgPetMeleeMain))]
    public static class DlgPetMeleeMainSystem
    {
        public static void RegisterUIEvent(this DlgPetMeleeMain self)
        {
            self.View.E_TouchEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.View.E_TouchEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
            self.View.E_IconImage.gameObject.SetActive(false);
            self.View.E_RerurnButton.AddListener(self.OnRerurnButton);

            self.View.E_DisposeCardEventTrigger.RegisterEvent(EventTriggerType.PointerEnter, (pdata) =>
            {
                self.IsDisposeCard = true;
                self.View.E_DisposeCardEventTrigger.transform.Find("Image1").gameObject.SetActive(false);
                self.View.E_DisposeCardEventTrigger.transform.Find("Image2").gameObject.SetActive(true);
            });
            self.View.E_DisposeCardEventTrigger.RegisterEvent(EventTriggerType.PointerExit, (pdata) =>
            {
                self.IsDisposeCard = false;
                self.View.E_DisposeCardEventTrigger.transform.Find("Image1").gameObject.SetActive(true);
                self.View.E_DisposeCardEventTrigger.transform.Find("Image2").gameObject.SetActive(false);
            });

            self.View.E_CancelCardAreaEventTrigger.RegisterEvent(EventTriggerType.PointerEnter, (pdata) => { self.IsCancelCard = true; });
            self.View.E_CancelCardAreaEventTrigger.RegisterEvent(EventTriggerType.PointerExit, (pdata) => { self.IsCancelCard = false; });
            
            self.MapTypeEnum =  self.Root().GetComponent<MapComponent>().MapType;

            Unit unitmain = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.BattleCamp = unitmain.GetBattleCamp();

            self.View.E_JiFanToweText.text = self.BattleCamp == CampEnum.CampPlayer_1 ? "己方防御塔" : "敌方防御塔";
            self.View.E_DiRenToweText.text = self.BattleCamp == CampEnum.CampPlayer_1 ? "敌方防御塔" : "己方防御塔";
            
            self.InitCard().Coroutine();
            self.UpdateMoLi();
            self.OnPlayAnimation().Coroutine();
        }

        public static void ShowWindow(this DlgPetMeleeMain self, Entity contextData = null)
        {
            self.View.E_Image_3Image.gameObject.SetActive(false);
            self.View.E_Image_2Image.gameObject.SetActive(false);
            self.View.E_Image_1Image.gameObject.SetActive(false);
            self.View.E_CountdownTimeText.text = ((int)ConfigData.PetMeleeBattleMaxTime / 1000).ToString();

            self.OranginScale = self.View.E_DiRenHpImgImage.GetComponent<RectTransform>().rect.width;
            using (zstring.Block())
            {
                self.View.E_JiFanNumText.text = zstring.Format("召唤宠物数量：0/{0}", ConfigData.PetMeleeMaxPetsInLine);
                self.View.E_DiRenNumText.text = "召唤怪物数量：0";
            }

            GameObject GridCanvas = GameObject.Find("/GridCanvas");
            GameObject BackgroundImage = GridCanvas.transform.Find("Background Image").gameObject;
            GameObject CellIndicator = GridCanvas.transform.Find("Cell Indicator").gameObject;
            BackgroundImage.SetActive(false);
            CellIndicator.SetActive(false);

            self.View.E_DisposeCardEventTrigger.transform.Find("Image1").gameObject.SetActive(true);
            self.View.E_DisposeCardEventTrigger.transform.Find("Image2").gameObject.SetActive(false);
            self.View.E_CancelCardAreaImage.gameObject.SetActive(false);

            self.UpdatePetMeleeMoRPS();
        }

        public static void UpdatePetMeleeMoRPS(this DlgPetMeleeMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentS = unit.GetComponent<NumericComponentC>();
            //int num = numericComponentS.GetAsInt(NumericType.PetMeleeMoLi);
            int add = ConfigData.PetMeleeMoLiRPS * (int)(1 + numericComponentS.GetAsFloat(NumericType.PetMeleeMoLiAdd));

            using (zstring.Block())
            {
                self.View.E_MoLiRPSText.text = zstring.Format("恢复值：{0}点/每秒", add);
            }
        }

        public static void BeforeUnload(this DlgPetMeleeMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            self.PetMeleeCardInHand.Clear();
            self.PetMeleeCardInHand = null;
            self.PetMeleeCardPool.Clear();
            self.PetMeleeCardPool = null;
        }

        public static void OnUnitHpUpdate(this DlgPetMeleeMain self, Unit unit)
        {
            self.UpdatePetMeleeMoRPS();

            if (unit.Type == UnitType.Monster)
            {
                MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_62)
                {
                    NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
                    int nowHp = numericComponentC.GetAsInt(NumericType.Now_Hp);
                    if (nowHp < 0)
                    {
                        nowHp = 0;
                    }

                    int maxHp = numericComponentC.GetAsInt(NumericType.Now_MaxHp);
                    if (monsterConfig.MonsterCamp == CampEnum.CampPlayer_1) // 
                    {
                        using (zstring.Block())
                        {
                            self.View.E_JiFanHpTxtText.text = zstring.Format("{0}/{1}", nowHp, maxHp);
                            Vector2 size = self.View.E_JiFanHpImgImage.GetComponent<RectTransform>().sizeDelta;
                            size.x = nowHp * 1f / maxHp * self.OranginScale;
                            self.View.E_JiFanHpImgImage.GetComponent<RectTransform>().sizeDelta = size;
                        }
                    }
                    else 
                    {
                        using (zstring.Block())
                        {
                            self.View.E_DiRenHpTxtText.text = zstring.Format("{0}/{1}", nowHp, maxHp);
                            Vector2 size = self.View.E_DiRenHpImgImage.GetComponent<RectTransform>().sizeDelta;
                            size.x = nowHp * 1f / maxHp * self.OranginScale;
                            self.View.E_DiRenHpImgImage.GetComponent<RectTransform>().sizeDelta = size;
                        }
                    }
                }
            }
        }

        public static void OnUnitNumUpdate(this DlgPetMeleeMain self)
        {
            int JiFanNum = 0;
            int DiRenNum = 0;
            
            foreach (Unit unit in self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll())
            {
                if (unit.Type == UnitType.Pet)
                {
                    if (self.BattleCamp == unit.GetBattleCamp())
                    {
                        JiFanNum++;
                    }
                    else
                    {
                        DiRenNum++;
                    }
                }
                
                if (unit.Type == UnitType.Monster)
                {
                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                    if (monsterConfig.MonsterSonType != MonsterSonTypeEnum.Type_62)
                    {
                        if (self.BattleCamp == unit.GetBattleCamp())
                        {
                            JiFanNum++;
                        }
                        else
                        {
                            DiRenNum++;
                        }
                    }
                    else
                    {
                        self.OnUnitHpUpdate(unit);
                    }
                }
            }

            using (zstring.Block())
            {
                if (self.BattleCamp == CampEnum.CampPlayer_1)
                {
                    self.View.E_JiFanNumText.text = zstring.Format("召唤宠物数量：{0}/{1}", JiFanNum, ConfigData.PetMeleeMaxPetsInLine);
                    self.View.E_DiRenNumText.text = zstring.Format("召唤{0}数量：{1}", self.MapTypeEnum == MapTypeEnum.PetMelee ? "怪物" :"宠物",  DiRenNum);
                }
                else
                {
                    self.View.E_JiFanNumText.text = zstring.Format("召唤宠物数量：{0}", DiRenNum);
                    self.View.E_DiRenNumText.text = zstring.Format("召唤宠物数量：{0}/{1}", JiFanNum,  ConfigData.PetMeleeMaxPetsInLine);
                }
            }
        }

        private static void OnRerurnButton(this DlgPetMeleeMain self)
        {
            string tipStr = "是否强制退出战斗！";

            PopupTipHelp.OpenPopupTip(self.Root(), "", tipStr, () => { EnterMapHelper.RequestQuitFuben(self.Root()); }, null).Coroutine();
        }

        private static async ETTask InitCard(this DlgPetMeleeMain self)
        {
            self.AddCardToPool(ConfigData.PetMeleeCarInHandNum * 2);

            M2C_PetMeleeGetMyCards response = await PetNetHelper.PetMeleePetMeleeGetMyCardsRequest(self.Root(), self.MapTypeEnum);
            foreach (ES_PetMeleeCard card in self.PetMeleeCardInHand)
            {
                self.ReturnCardToPool(card);
            }

            self.PetMeleeCardInHand.Clear();

            self.DealCards(response.PetMeleeCardList);
        }

        public static void DealCards(this DlgPetMeleeMain self, List<PetMeleeCardInfo> cards)
        {
            FlyTipComponent.Instance.ShowFlyTip($"发放卡牌 {cards.Count} 张");

            NumericComponentC numericComponentC = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            foreach (PetMeleeCardInfo cardInfo in cards)
            {
                ES_PetMeleeCard esPetMeleeCard = self.GetCardFromPool();
                esPetMeleeCard.MapTypeEnum = self.MapTypeEnum;
                esPetMeleeCard.BattleCamp = self.BattleCamp;
                self.PetMeleeCardInHand.Add(esPetMeleeCard);
                esPetMeleeCard.InitCard(cardInfo);
                esPetMeleeCard.UpdateCostText(numericComponentC.GetAsInt(NumericType.PetMeleeMoLi));
            }

            self.ArrangeCards();
        }

        private static void ArrangeCards(this DlgPetMeleeMain self)
        {
            // 不用自动布局组件，后面可能会有卡牌的拖动、排序动画什么的
            for (int i = 0; i < self.PetMeleeCardInHand.Count; i++)
            {
                // 在这可以加一些卡牌的排序动画什么的
                ES_PetMeleeCard esPetMeleeCard = self.PetMeleeCardInHand[i];
                esPetMeleeCard.uiTransform.localPosition = new Vector3(-500f + i * 280f, 0, 0);
            }
        }

        private static void AddCardToPool(this DlgPetMeleeMain self, int num)
        {
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetMeleeCard.prefab");
            
            for (int i = 0; i < num; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(prefab, self.View.EG_CardPoolRectTransform);
                go.SetActive(false);
                ES_PetMeleeCard esPetMeleeCard = self.AddChild<ES_PetMeleeCard, Transform>(go.transform);
                esPetMeleeCard.BattleCamp = self.BattleCamp;
                esPetMeleeCard.MapTypeEnum = self.MapTypeEnum;
                self.PetMeleeCardPool.Add(esPetMeleeCard);
            }
        }
        
        private static ES_PetMeleeCard GetCardFromPool(this DlgPetMeleeMain self)
        {
            if (self.PetMeleeCardPool.Count == 0)
            {
                self.AddCardToPool(3);
            }

            ES_PetMeleeCard esPetMeleeCard = self.PetMeleeCardPool[^1];
            self.PetMeleeCardPool.RemoveAt(self.PetMeleeCardPool.Count - 1);
            esPetMeleeCard.uiTransform.SetParent(self.View.EG_CardInHandRectTransform);
            esPetMeleeCard.uiTransform.gameObject.SetActive(true);
            return esPetMeleeCard;
        }

        private static void ReturnCardToPool(this DlgPetMeleeMain self, ES_PetMeleeCard card)
        {
            self.PetMeleeCardPool.Add(card);
            card.uiTransform.SetParent(self.View.EG_CardPoolRectTransform);
            card.uiTransform.gameObject.SetActive(false);
        }

        public static void Stop(this DlgPetMeleeMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.IsGameOver = true;
        }

        private static void BeginDrag(this DlgPetMeleeMain self, PointerEventData pdata)
        {
            self.PreviousPressPosition = pdata.position;
        }

        private static void Drag(this DlgPetMeleeMain self, PointerEventData pdata)
        {
            float x = (self.PreviousPressPosition.x - pdata.position.x) * 0.05f;
            self.Root().CurrentScene().GetComponent<MJCameraComponent>().ApplyCameraPos_X(x, -10, 10);
            self.PreviousPressPosition = pdata.position;
        }

        public static void OnTimer(this DlgPetMeleeMain self)
        {
            // 镜头拉近效果
            // Camera camera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            // float passTime = Time.time - self.BeginTime;
            // float fieldOfView = 50f - (passTime / 10f) * 20;
            // fieldOfView = Math.Max(fieldOfView, 30);
            // camera.GetComponent<Camera>().fieldOfView = fieldOfView;
        }

        public static async ETTask OnPlayAnimation(this DlgPetMeleeMain self)
        {
            long instanceId = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            self.View.E_Image_3Image.gameObject.SetActive(true);
            self.BeginTime = Time.time;
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UIPetMeleeMain, self);
            self.View.E_Image_3Image.GetComponent<CanvasGroup>().DOFade(0f, 1f).SetEase(Ease.InOutQuad);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.View.E_Image_3Image.gameObject.SetActive(false);
            self.View.E_Image_2Image.gameObject.SetActive(true);
            self.View.E_Image_2Image.GetComponent<CanvasGroup>().DOFade(0f, 1f).SetEase(Ease.InOutQuad);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.View.E_Image_2Image.gameObject.SetActive(false);
            self.View.E_Image_1Image.gameObject.SetActive(true);
            self.View.E_Image_1Image.GetComponent<CanvasGroup>().DOFade(0f, 1f).SetEase(Ease.InOutQuad);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.View.E_Image_1Image.gameObject.SetActive(false);
            self.View.E_DiImage.gameObject.SetActive(false);
            await PetNetHelper.PetMeleeBeginRequest(self.Root(), self.MapTypeEnum);
            self.BeginCountdown().Coroutine();
        }

        public static async ETTask BeginCountdown(this DlgPetMeleeMain self)
        {
            long instanceId = self.InstanceId;
            int cdTime = (int)ConfigData.PetMeleeBattleMaxTime / 1000;

            for (int i = cdTime; i >= 0; i--)
            {
                if (instanceId != self.InstanceId)
                {
                    return;
                }

                if (self.IsGameOver)
                {
                    return;
                }

                if (i == 0)
                {
                    self.View.E_CountdownTimeText.text = i.ToString();
                }
                else
                {
                    self.View.E_CountdownTimeText.text = i.ToString();
                    await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
                }
            }
        }

        public static void UpdateMoLi(this DlgPetMeleeMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            using (zstring.Block())
            {
                self.View.E_MoLiTxtText.text =
                        zstring.Format("{0}/{1}", numericComponentC.GetAsInt(NumericType.PetMeleeMoLi), ConfigData.PetMeleeMoLiMax);
            }

            self.View.E_MoLiImgImage.fillAmount = numericComponentC.GetAsInt(NumericType.PetMeleeMoLi) * 1f / ConfigData.PetMeleeMoLiMax;

            float y = self.View.E_MoLiImgImage.GetComponent<RectTransform>().localPosition.y +
                    (numericComponentC.GetAsInt(NumericType.PetMeleeMoLi) * 1f / ConfigData.PetMeleeMoLiMax - 0.5f) *
                    self.View.E_MoLiImgImage.GetComponent<RectTransform>().sizeDelta.y;

            Vector2 pos = self.View.E_MoLiImgOnlineImage.GetComponent<RectTransform>().localPosition;
            pos.y = y;
            self.View.E_MoLiImgOnlineImage.GetComponent<RectTransform>().localPosition = pos;

            for (int i = 0; i < self.PetMeleeCardInHand.Count; i++)
            {
                ES_PetMeleeCard esPetMeleeCard = self.PetMeleeCardInHand[i];
                esPetMeleeCard.UpdateCostText(numericComponentC.GetAsInt(NumericType.PetMeleeMoLi));
            }
        }

        public static async ETTask UseCard(this DlgPetMeleeMain self, ES_PetMeleeCard card, float3 position, long targetUnitId)
        {
            int error = await PetNetHelper.PetMeleePlaceRequest(self.Root(), card.PetMeleeCardInfo.Id, position, targetUnitId, self.MapTypeEnum);

            if (error == ErrorCode.ERR_Success)
            {
                self.PetMeleeCardInHand.Remove(card);
                self.ReturnCardToPool(card);
                self.ArrangeCards();
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask DisposeCard(this DlgPetMeleeMain self, ES_PetMeleeCard card)
        {
            int error = await PetNetHelper.PetMeleeDisposeCardRequest(self.Root(), card.PetMeleeCardInfo.Id, self.MapTypeEnum);

            if (error == ErrorCode.ERR_Success)
            {
                self.PetMeleeCardInHand.Remove(card);
                self.ReturnCardToPool(card);
                self.ArrangeCards();
            }

            await ETTask.CompletedTask;
        }
    }
}