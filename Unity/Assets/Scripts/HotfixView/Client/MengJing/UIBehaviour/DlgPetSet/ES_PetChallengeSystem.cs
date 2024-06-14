using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    [EntitySystemOf(typeof(ES_PetChallenge))]
    [FriendOfAttribute(typeof(ES_PetChallenge))]
    public static partial class ES_PetChallengeSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_PetChallenge self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;
            
            self.E_PetChallengeItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPetChallengeItemsRefresh);

            self.OnInitUI();
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_PetChallenge self)
        {
            self.DestroyWidget();
        }

        
        private static void OnPetChallengeItemsRefresh(this ES_PetChallenge self, Transform transform, int index)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int petfubenId = petComponentC.GetPetFuben();
            
            Log.Debug($"ES_PetChallenge.OnPetChallengeItemsRefresh:  {index}");
            Scroll_Item_PetChallengeItem scrollItemNPetChallengeItem=
                    self.ScrollItemPetChallengeItems[index].BindTrans(transform);
            
            bool locked = index > 0 && self.ShowPetFubenConfig[index].Id - petfubenId >= 2;
            scrollItemNPetChallengeItem.OnUpdateUI(self.ShowPetFubenConfig[index], index,  petComponentC.GetFubenStar(self.ShowPetFubenConfig[index].Id), locked).Coroutine();
            scrollItemNPetChallengeItem.SetClickHandler(self.OnClickChallengeItem);
        }
        
        public static void OnClickChallengeItem(this ES_PetChallenge self, int petfubenId)
        {
            Log.Debug($"ES_PetChallenge.OnClickChallengeItem:{petfubenId}");
            self.PetFubenId = petfubenId;
            foreach (var item in self.ScrollItemPetChallengeItems)
            {
                item.Value.SetSelected(petfubenId);
            }
        }
        
        public static void OnInitUI(this ES_PetChallenge self)
        {
            Log.Debug("ES_PetChallenge.OnInitUI");
            self.ShowPetFubenConfig.Clear();
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