using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    
    [ChildOf]
    [EnableMethod]
    public class ES_PetMiningItem: Entity,IAwake<Transform>,IDestroy
    {
        
        public Text E_TextChanChu
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_TextChanChu == null )
                {
                    this.m_es_TextChanChu = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TextChanChu");
                }
                return this.m_es_TextChanChu;
            }
        }
        
        public Transform E_ImHeXinShow
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_ImHeXinShow == null )
                {
                    this.m_es_ImHeXinShow = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ImHeXinShow");
                }
                return this.m_es_ImHeXinShow;
            }
        }
        
        public Transform E_PetList
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_PetList == null )
                {
                    this.m_es_PetList = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"PetList");
                }
                return this.m_es_PetList;
            }
        }

        public Text E_TextMine
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_TextMine == null )
                {
                    this.m_es_TextMine = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TextMine");
                }
                return this.m_es_TextMine;
            }
        }

        public Image E_ImageIcon
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_ImageIcon == null )
                {
                    this.m_es_ImageIcon = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"ImageIcon");
                }
                return this.m_es_ImageIcon;
            }
        }

        public Text E_TextPlayer
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if( this.m_es_TextPlayer == null )
                {
                    this.m_es_TextPlayer = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TextPlayer");
                }
                return this.m_es_TextPlayer;
            }
        }

        
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

            this.m_es_TextChanChu = null;
            this.m_es_ImHeXinShow = null;
            this.m_es_PetList = null;
            this.m_es_TextMine = null;
            this.m_es_ImageIcon = null;
            this.m_es_TextPlayer = null;
            this.E_PetIconList = null;
            this.PetMingPlayerInfo = null;
            this.uiTransform = null;
        }
        
        
        private Text m_es_TextChanChu;
        private Transform m_es_ImHeXinShow;
        private Transform m_es_PetList;
        private Text m_es_TextMine;
        private Image m_es_ImageIcon;
        private Text m_es_TextPlayer;
        public Image[] E_PetIconList = new Image[5];
        public PetMingPlayerInfo PetMingPlayerInfo;
        public Transform uiTransform = null;
        
        public int MineType;
        public int Position;
    }
    
    
}