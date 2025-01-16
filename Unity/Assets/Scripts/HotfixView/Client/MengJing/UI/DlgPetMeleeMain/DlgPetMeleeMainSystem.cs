using System.Collections;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
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
                self.Update();
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

            self.InitCard().Coroutine();

            self.StartTime = TimeInfo.Instance.ServerNow();
            self.ReadyTime = 10000; // 倒计时时间
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(1000, TimerInvokeType.UIPetMeleeMain, self);
            self.UpdateMoLi();
            self.View.E_IconImage.gameObject.SetActive(false);
            self.View.E_RerurnButton.AddListener(self.OnRerurnButton);
        }

        public static void ShowWindow(this DlgPetMeleeMain self, Entity contextData = null)
        {
            GameObject GridCanvas = GameObject.Find("/GridCanvas");
            GameObject BackgroundImage = GridCanvas.transform.Find("Background Image").gameObject;
            GameObject CellIndicator = GridCanvas.transform.Find("Cell Indicator").gameObject;
            BackgroundImage.SetActive(false);
            CellIndicator.SetActive(false);
        }

        public static void BeforeUnload(this DlgPetMeleeMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);

            self.PetMeleeCardInHand.Clear();
            self.PetMeleeCardInHand = null;
            self.PetMeleeCardPool.Clear();
            self.PetMeleeCardPool = null;
        }

        private static void OnRerurnButton(this DlgPetMeleeMain self)
        {
            string tipStr = "是否强制退出战斗！";

            PopupTipHelp.OpenPopupTip(self.Root(), "", tipStr, () => { EnterMapHelper.RequestQuitFuben(self.Root()); }, null).Coroutine();
        }

        private static async ETTask InitCard(this DlgPetMeleeMain self)
        {
            GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetMeleeCard.prefab");

            // 不用自动布局组件，后面可能会有卡牌的拖动、排序动画什么的
            for (int i = 0; i < ConfigData.PetMeleeCarInHandNum * 2; i++)
            {
                GameObject go = UnityEngine.Object.Instantiate(prefab, self.View.EG_CardPoolRectTransform);
                go.SetActive(false);
                ES_PetMeleeCard esPetMeleeCard = self.AddChild<ES_PetMeleeCard, Transform>(go.transform);
                self.PetMeleeCardPool.Add(esPetMeleeCard);
            }

            M2C_PetMeleeGetMyCards response = await PetNetHelper.PetMeleePetMeleeGetMyCardsRequest(self.Root());
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

            foreach (PetMeleeCardInfo cardInfo in cards)
            {
                ES_PetMeleeCard esPetMeleeCard = self.GetCardFromPool();
                self.PetMeleeCardInHand.Add(esPetMeleeCard);
                esPetMeleeCard.InitCard(cardInfo);
            }

            self.ArrangeCards();
        }

        private static void ArrangeCards(this DlgPetMeleeMain self)
        {
            for (int i = 0; i < self.PetMeleeCardInHand.Count; i++)
            {
                // 在这可以加一些卡牌的排序动画什么的
                ES_PetMeleeCard esPetMeleeCard = self.PetMeleeCardInHand[i];
                esPetMeleeCard.uiTransform.localPosition = new Vector3(-500f + i * 280f, 0, 0);
            }
        }

        private static ES_PetMeleeCard GetCardFromPool(this DlgPetMeleeMain self)
        {
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

        public static void StopTimer(this DlgPetMeleeMain self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
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

        public static void Update(this DlgPetMeleeMain self)
        {
            long nowTime = TimeInfo.Instance.ServerNow();
            if (!self.GameStart)
            {
                long leftTime = self.ReadyTime - (nowTime - self.StartTime);

                if (leftTime > 0)
                {
                    using (zstring.Block())
                    {
                        self.View.E_LeftTimeTextText.text = zstring.Format("{0}秒后战斗开始！", leftTime / 1000);
                    }

                    self.View.E_LeftTimeImgImage.fillAmount = leftTime * 1f / self.ReadyTime;
                }
                else
                {
                    FlyTipComponent.Instance.ShowFlyTip("一大波怪物正在来袭!!!");
                    PetNetHelper.PetMeleeBeginRequest(self.Root()).Coroutine();
                    self.View.EG_LeftTimeRectTransform.gameObject.SetActive(false);
                    self.StartTime = nowTime;
                    self.GameStart = true;
                }
            }
            else
            {
                long leftTime = ConfigData.PetMeleeBattleMaxTime - (nowTime - self.StartTime);
                using (zstring.Block())
                {
                    self.View.E_LeftTimeTextText.text = zstring.Format("{0}秒后战斗结束！", leftTime / 1000);
                }
            }
        }

        public static void UpdateMoLi(this DlgPetMeleeMain self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            using (zstring.Block())
            {
                self.View.E_MoLiText.text =
                        zstring.Format("{0}/{1}", numericComponentC.GetAsInt(NumericType.PetMeleeMoLi), ConfigData.PetMeleeMoLiMax);
            }

            self.View.E_MoLiImgImage.fillAmount = numericComponentC.GetAsInt(NumericType.PetMeleeMoLi) * 1f / ConfigData.PetMeleeMoLiMax;
        }

        public static async ETTask UseCard(this DlgPetMeleeMain self, ES_PetMeleeCard card, float3 position)
        {
            int error = await PetNetHelper.PetMeleePlaceRequest(self.Root(), card.PetMeleeCardInfo.Id, position);

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