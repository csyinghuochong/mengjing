using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_PetChallenge : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy, IUILogic
    {
    
        public Transform UITransform
        {
            get
            {
                return this.uiTransform;
            }
            set
            {
                this.uiTransform = value;
            }
        }
        
        public UnityEngine.UI.LoopVerticalScrollRect E_PetChallengeItemsLoopVerticalScrollRect
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_E_PetChallengeItemsLoopVerticalScrollRect == null )
                {
                    this.m_E_PetChallengeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_C_VerticalLoop");
                }
                return this.m_E_PetChallengeItemsLoopVerticalScrollRect;
            }
        }
        
        public void DestroyWidget()
        {
            this.m_E_PetChallengeItemsLoopVerticalScrollRect = null;
            this.uiTransform = null;
        }

        public List<PetFubenConfig> ShowPetFubenConfig = new List<PetFubenConfig>();
        public Dictionary<int, Scroll_Item_PetChallengeItem> ScrollItemPetChallengeItems;
        private UnityEngine.UI.LoopVerticalScrollRect m_E_PetChallengeItemsLoopVerticalScrollRect = null;
        public Transform uiTransform = null;
    }
}

