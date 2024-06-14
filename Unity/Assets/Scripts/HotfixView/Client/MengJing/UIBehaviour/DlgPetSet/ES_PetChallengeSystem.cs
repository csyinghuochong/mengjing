using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{

    [EntitySystemOf(typeof(ES_PetChallenge))]
    [FriendOfAttribute(typeof(ES_PetChallenge))]
    [FriendOfAttribute(typeof(Scroll_Item_PetChallengeItem))]
    public static partial class ES_PetChallengeSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_PetChallenge self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;
            
            self.E_PetChallengeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetChallengeItemsRefresh);

            // self.m_es_ButtonSet.AddListener(() => { self.OnButtonSet().Coroutine(); } );
            // self.m_es_ButtonChallenge.AddListener(() => { self.OnButtonChallenge().Coroutine(); });
            //
            // self.m_es_ButtonReward.RegisterEvent(EventTriggerType.PointerDown, ( pdata) => { self.BeginDrag(pdata as PointerEventData).Coroutine(); });
            // self.m_es_ButtonReward.RegisterEvent(EventTriggerType.PointerUp, ( pdata) => { self.EndDrag(pdata as PointerEventData); });
            //
            // self.InitSubView();
            // self.OnUpdateStar();
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
            // self.m_E_PetFormationSet.OnUpdateFormation(SceneTypeEnum.PetDungeon,
            //     self.Root().GetComponent<PetComponentC>().PetFormations, false);
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