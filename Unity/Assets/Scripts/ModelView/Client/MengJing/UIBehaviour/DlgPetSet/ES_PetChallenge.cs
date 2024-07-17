using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_PetChallenge : Entity,IAwake<Transform>,IDestroy, IUILogic
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
        
        public LoopVerticalScrollRect E_PetChallengeItemsLoopVerticalScrollRect
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
                    this.m_E_PetChallengeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_C_VerticalLoop");
                }
                return this.m_E_PetChallengeItemsLoopVerticalScrollRect;
            }
        }
        
        public Text E_TextTimes
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                
                if( this.m_es_TextTimes == null )
                {
                    this.m_es_TextTimes = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TextTimes");
                }
                return this.m_es_TextTimes;
            }
        }

        public Text E_TextStar
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                
                if( this.m_es_TextStar == null )
                {
                    this.m_es_TextStar = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TextStar");
                }
                return this.m_es_TextStar;
            }
        }
        
        public EventTrigger E_ButtonReward
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                
                if( this.m_es_ButtonReward == null )
                {
                    this.m_es_ButtonReward = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"StartChestSet/ButtonReward");
                }
                return this.m_es_ButtonReward;
            }
        }
        
        public Button E_ButtonSet
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                
                if( this.m_es_ButtonSet == null )
                {
                    this.m_es_ButtonSet = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonSet");
                }
                return this.m_es_ButtonSet;
            }
        }
        
        public Button E_ButtonChallenge
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                
                if( this.m_es_ButtonChallenge == null )
                {
                    this.m_es_ButtonChallenge = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonChallenge");
                }
                return this.m_es_ButtonChallenge;
            }
        }
        
        public Transform E_FormationNode
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                
                if( this.m_es_FormationNode == null )
                {
                    this.m_es_FormationNode = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"FormationNode");
                }
                return this.m_es_FormationNode;
            }
        }
        
        public ES_PetFormationSet ES_PetFormationSet
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }

                ES_PetFormationSet es = this.m_es_petformationset;
                if( es ==null )
                {
                    Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"FormationNode/ES_PetFormationSet");
                    this.m_es_petformationset = this.AddChild<ES_PetFormationSet,Transform>(subTrans);
                }
                return this.m_es_petformationset;
            }
        }
        
        public void DestroyWidget()
        {
            this.m_es_TextTimes = null;
            this.m_es_TextStar = null;
            this.m_es_ButtonReward = null;
            this.m_es_ButtonSet = null;
            this.m_es_ButtonChallenge = null;
            this.m_es_FormationNode = null;
            this.m_es_petformationset = null;
            this.m_E_PetChallengeItemsLoopVerticalScrollRect = null;
            this.uiTransform = null;
        }

        private Text m_es_TextTimes;
        private Text m_es_TextStar;
        private EventTrigger m_es_ButtonReward;
        private Button m_es_ButtonSet;
        private Button m_es_ButtonChallenge;
        private Transform m_es_FormationNode;
        private EntityRef<ES_PetFormationSet> m_es_petformationset = null;

        public List<PetFubenConfig> ShowPetFubenConfig = new List<PetFubenConfig>();
        public Dictionary<int, EntityRef<Scroll_Item_PetChallengeItem>> ScrollItemPetChallengeItems;
        private LoopVerticalScrollRect m_E_PetChallengeItemsLoopVerticalScrollRect = null;
        public Transform uiTransform = null;
        
        public int PetFubenId;
        public int ShowReward;
    }
}

