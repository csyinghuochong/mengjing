using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

        private Text m_es_TextTimes;
        private Text m_es_TextStar;
        private EventTrigger m_es_ButtonReward;
        private ScrollRect m_es_ScrollRect;
        private RectTransform m_es_ChallengeListNode;
        private Button m_es_ButtonSet;
        private Button m_es_ButtonChallenge;
        private Transform m_es_FormationNode;
        public EntityRef<ES_PetFormationSet> m_E_PetFormationSet = null;

        public List<PetFubenConfig> ShowPetFubenConfig = new List<PetFubenConfig>();
        public Dictionary<int, Scroll_Item_PetChallengeItem> ScrollItemPetChallengeItems = new Dictionary<int, Scroll_Item_PetChallengeItem>();
        private UnityEngine.UI.LoopVerticalScrollRect m_E_PetChallengeItemsLoopVerticalScrollRect = null;
        public Transform uiTransform = null;
        
        public int PetFubenId;
        public int ShowReward;
    }
}

