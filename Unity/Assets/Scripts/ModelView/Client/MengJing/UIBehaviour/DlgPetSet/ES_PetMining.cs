using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_PetMining: Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
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

        public void DestroyWidget()
        {
            this.uiTransform = null;
        }
        
        
        private GameObject m_es_ButtonEditorTeam;
        private GameObject m_es_BuildingList;
        private GameObject m_es_ButtonRecord;
        private GameObject m_es_ImageMineDi;
        private GameObject m_es_PetMiningTeam;
        private GameObject m_es_ButtonTeamToggle;
        private GameObject m_es_Text_OccNumber;
        private GameObject m_es_Text_Chanchu_2;
        private GameObject m_es_Text_Chanchu_1;
        private GameObject m_es_UIPetOccupyItem;
        private GameObject m_es_ButtonReward;
        private GameObject m_es_ButtonReward_2;
        private GameObject m_es_UIPetMiningItem;
        private GameObject m_es_PetMiningNode;
        private GameObject m_es_PetMiningTeamButton;

        public List<PetMingPlayerInfo> PetMingPlayers = new List<PetMingPlayerInfo>();
        public List<KeyValuePairInt> PetMineExtend = new List<KeyValuePairInt>();
        
        public List<ES_PetMiningItem> ScrollItemPetMiningItemList = new List<ES_PetMiningItem>();

        public List<Image> TeamIconList = new List<Image>();    
        public List<Text> TeamTipList = new List<Text>();

        public List<GameObject> PetOccupyItemList = new List<GameObject>();
        
        public Transform uiTransform = null;
        
    }
    
}