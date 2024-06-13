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
            Scroll_Item_PetChallengeItem scrollItemNPetChallengeItem=
                    self.ScrollItemPetChallengeItems[index].BindTrans(transform);

            scrollItemNPetChallengeItem.OnInitUI(self.ShowPetFubenConfig[index]);
            scrollItemNPetChallengeItem.SetAction(self.OnClickChallengeItem);
        }
        
        public static void OnClickChallengeItem(this ES_PetChallenge self, int petfubenId)
        {
            // self.PetFubenId = petfubenId;
            // for (int i = 0; i < self.ChallengeItemList.Count; i++)
            // {
            //     self.ChallengeItemList[i].SetSelected(petfubenId);
            // }
        }
        
        public static void OnInitUI(this ES_PetChallenge self)
        {
            self.ShowPetFubenConfig.Clear();
            
            List<PetFubenConfig> petFubenConfigs = PetFubenConfigCategory.Instance.GetAll().Values.ToList();
            
            for (int i = 0; i < petFubenConfigs.Count; i++)
            {
                self.ShowPetFubenConfig.Add( petFubenConfigs[i] );
            }

            self.AddUIScrollItems(ref self.ScrollItemPetChallengeItems, self.ShowPetFubenConfig.Count);
            self.E_PetChallengeItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPetFubenConfig.Count);
        }
    }

}