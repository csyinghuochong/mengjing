using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_PetMining: Entity,IAwake<Transform>,IDestroy
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

        
        public Button E_ButtonEditorTeam
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_ButtonEditorTeam == null )
                {
                    this.m_es_ButtonEditorTeam = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonEditorTeam");
                }
                return this.m_es_ButtonEditorTeam;
            }
        }
        
        public Transform E_BuildingList
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_BuildingList == null )
                {
                    this.m_es_BuildingList = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ScrollView_2/Viewport/BuildingList");
                }
                return this.m_es_BuildingList;
            }
        }

        public Button E_ButtonRecord
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_ButtonRecord == null )
                {
                    this.m_es_ButtonRecord = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonRecord");
                }
                return this.m_es_ButtonRecord;
            }
        }

        public Image E_ImageMineDi
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_ImageMineDi == null )
                {
                    this.m_es_ImageMineDi = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageMineDi");
                }
                return this.m_es_ImageMineDi;
            }
        }

        public Transform E_PetMiningTeam
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_PetMiningTeam == null )
                {
                    this.m_es_PetMiningTeam = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"PetMiningTeam");
                }
                return this.m_es_PetMiningTeam;
            }
        }

        public Button E_ButtonTeamToggle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_ButtonTeamToggle == null )
                {
                    this.m_es_ButtonTeamToggle = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonTeamToggle");
                }
                return this.m_es_ButtonTeamToggle;
            }
        }

        public Text E_Text_OccNumber
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_Text_OccNumber == null )
                {
                    this.m_es_Text_OccNumber = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Text_OccNumber");
                }
                return this.m_es_Text_OccNumber;
            }
        }
        
        public Text E_Text_Chanchu_2
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_Text_Chanchu_2 == null )
                {
                    this.m_es_Text_Chanchu_2 = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Text_Chanchu_2");
                }
                return this.m_es_Text_Chanchu_2;
            }
        }
        
        public Text E_Text_Chanchu_1
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_Text_Chanchu_1 == null )
                {
                    this.m_es_Text_Chanchu_1 = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Text_Chanchu_1");
                }
                return this.m_es_Text_Chanchu_1;
            }
        }

        public Button E_ButtonReward
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
                    this.m_es_ButtonReward = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonReward");
                }
                return this.m_es_ButtonReward;
            }
        }

        public Button E_ButtonReward_2
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_ButtonReward_2 == null )
                {
                    this.m_es_ButtonReward_2 = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"ButtonReward_2");
                }
                return this.m_es_ButtonReward_2;
            }
        }

        public Button E_PetMiningTeamButton
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_PetMiningTeamButton == null )
                {
                    this.m_es_PetMiningTeamButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"PetMiningTeamButton");
                }
                return this.m_es_PetMiningTeamButton;
            }
        }

        public Transform E_PetMiningItem
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_UIPetMiningItem == null )
                {
                    this.m_es_UIPetMiningItem = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ScrollView_1/Viewport/PetMiningNode/UIPetMiningItem");
                }
                return this.m_es_UIPetMiningItem;
            }
        }

        public Transform E_PetMiningNode
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_PetMiningNode == null )
                {
                    this.m_es_PetMiningNode = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ScrollView_1/Viewport/PetMiningNode");
                }
                return this.m_es_PetMiningNode;
            }
        }
        
        public ToggleGroup E_FunctionSetBtnToggleGroup
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_E_FunctionSetBtnToggleGroup == null )
                {
                    this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
                }
                return this.m_E_FunctionSetBtnToggleGroup;
            }
        }

        public Toggle E_Type1Toggle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_E_Type1Toggle == null )
                {
                    this.m_E_Type1Toggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type1");
                }
                return this.m_E_Type1Toggle;
            }
        }

        public Toggle E_Type2Toggle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_E_Type2Toggle == null )
                {
                    this.m_E_Type2Toggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type2");
                }
                return this.m_E_Type2Toggle;
            }
        }

        public Toggle E_Type3Toggle
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_E_Type3Toggle == null )
                {
                    this.m_E_Type3Toggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type3");
                }
                return this.m_E_Type3Toggle;
            }
        }

        public Transform E_UIPetOccupyItem
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_UIPetOccupyItem == null )
                {
                    this.m_es_UIPetOccupyItem = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"UIPetOccupyItem");
                }
                return this.m_es_UIPetOccupyItem;
            }
        }

        public void DestroyWidget()
        {
            this.m_es_ButtonEditorTeam = null;
            this.m_es_BuildingList= null;
            this.m_es_ButtonRecord= null;
            this.m_es_ImageMineDi= null;
            this.m_es_PetMiningTeam= null;
            this.m_es_ButtonTeamToggle= null;
            this.m_es_Text_OccNumber= null;
            this.m_es_Text_Chanchu_2= null;
            this.m_es_Text_Chanchu_1= null;
            this.m_es_UIPetOccupyItem= null;
            this.m_es_ButtonReward= null;
            this.m_es_ButtonReward_2= null;
            this.m_es_UIPetMiningItem= null;
            this.m_es_PetMiningNode= null;
            this.m_es_PetMiningTeamButton= null;
            this.m_E_FunctionSetBtnToggleGroup = null;
            this.m_E_Type1Toggle= null;
            this.m_E_Type2Toggle= null;
            this.m_E_Type3Toggle= null;
            
            this.uiTransform = null;
        }
        
        
        private Button    m_es_ButtonEditorTeam;
        private Transform m_es_BuildingList;
        private Button    m_es_ButtonRecord;
        private Image     m_es_ImageMineDi;
        private Transform m_es_PetMiningTeam;
        private Button    m_es_ButtonTeamToggle;
        private Text      m_es_Text_OccNumber;
        private Text      m_es_Text_Chanchu_2;
        private Text      m_es_Text_Chanchu_1;
        private Transform m_es_UIPetOccupyItem;
        private Button    m_es_ButtonReward;
        private Button    m_es_ButtonReward_2;
        private Transform m_es_UIPetMiningItem;
        private Transform m_es_PetMiningNode;
        private Button    m_es_PetMiningTeamButton;

        public List<PetMingPlayerInfo> PetMingPlayers = new List<PetMingPlayerInfo>();
        public List<KeyValuePairInt> PetMineExtend { get; set; }= new List<KeyValuePairInt>();
        public List<EntityRef<ES_PetMiningItem>> PetMiningItemList = new();

        
        private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
        private Toggle m_E_Type1Toggle = null;
        private Toggle m_E_Type2Toggle = null;
        private Toggle m_E_Type3Toggle = null;
        
        public List<Image> TeamIconList = new List<Image>();    
        public List<Text> TeamTipList = new List<Text>();

        public List<GameObject> PetOccupyItemList = new List<GameObject>();
        
        public Transform uiTransform = null;
        
    }
    
}