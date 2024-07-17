using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EnableMethod]
    public class Scroll_Item_PetChallengeItem: Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetChallengeItem>
    {
        public long DataId {get;set;}
        private bool isCacheNode = false;
        public void SetCacheMode(bool isCache)
        {
            this.isCacheNode = isCache;
        }
        
        public Scroll_Item_PetChallengeItem BindTrans(Transform trans)
        {
            this.uiTransform = trans;
            return this;
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
                if (this.isCacheNode)
                {
                    if( this.m_es_ImageIcon == null )
                    {
                        this.m_es_ImageIcon = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Node_1/ImageIcon");
                    }
                    return this.m_es_ImageIcon;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Node_1/ImageIcon");
                }
            }
        }

        public Transform E_ImageDi
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_ImageDi == null )
                    {
                        this.m_es_ImageDi = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/ImageDi");
                    }
                    return this.m_es_ImageDi;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/ImageDi");
                }
            }
        }
        
        public Transform E_StartNode
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_StartNode == null )
                    {
                        this.m_es_StartNode = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/StartNode");
                    }
                    return this.m_es_StartNode;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/StartNode");
                }
            }
        }
        
        public Transform E_ImageSelect
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_ImageSelect == null )
                    {
                        this.m_es_ImageSelect = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/ImageSelect");
                    }
                    return this.m_es_ImageSelect;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/ImageSelect");
                }
            }
        }
        
        public Transform E_Start_2
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_Start_2 == null )
                    {
                        this.m_es_Start_2 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/StartNode/Start_2");
                    }
                    return this.m_es_Start_2;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/StartNode/Start_2");
                }
            }
        }

        public Transform E_Start_1
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_Start_1 == null )
                    {
                        this.m_es_Start_1 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/StartNode/Start_1");
                    }
                    return this.m_es_Start_1;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/StartNode/Start_1");
                }
            }
        }
        
        public Transform E_Start_0
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_Start_0 == null )
                    {
                        this.m_es_Start_0 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/StartNode/Start_0");
                    }
                    return this.m_es_Start_0;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/StartNode/Start_0");
                }
            }
        }
        
        public Text E_TextCombat
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_TextCombat == null )
                    {
                        this.m_es_TextCombat = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Node_1/TextCombat");
                    }
                    return this.m_es_TextCombat;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Node_1/TextCombat");
                }
            }
        }
        
        
        public Text E_TextLevel
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_TextLevel == null )
                    {
                        this.m_es_TextLevel = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Node_1/TextLevel");
                    }
                    return this.m_es_TextLevel;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Node_1/TextLevel");
                }
            }
        }
        
        public Transform E_Node_1
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_Node_1 == null )
                    {
                        this.m_es_Node_1 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1");
                    }
                    return this.m_es_Node_1;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1");
                }
            }
        }
        
        public Transform E_Node_2
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_Node_2 == null )
                    {
                        this.m_es_Node_2 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_2");
                    }
                    return this.m_es_Node_2;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_2");
                }
            }
        }
        
        public Transform E_ImageLine_1
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_ImageLine_1 == null )
                    {
                        this.m_es_ImageLine_1 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/ImageLine_1");
                    }
                    return this.m_es_ImageLine_1;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/ImageLine_1");
                }
            }
        }
        
        public Transform E_ImageLine_2
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if( this.m_es_ImageLine_2 == null )
                    {
                        this.m_es_ImageLine_2 = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/ImageLine_2");
                    }
                    return this.m_es_ImageLine_2;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Node_1/ImageLine_2");
                }
            }
        }
        
        public void DestroyWidget()
        {
            this.m_es_ImageIcon = null;
            this.m_es_ImageDi= null;
            this.m_es_StartNode= null;
            this.m_es_ImageSelect= null;
            this.m_es_Start_2= null;
            this.m_es_Start_1= null;
            this.m_es_Start_0= null;
            this.m_es_TextCombat= null;
            this.m_es_TextLevel= null;
            this.m_es_Node_1= null;
            this.m_es_Node_2 = null;
            this.m_es_ImageLine_1= null;
            this.m_es_ImageLine_2= null;
            
            this.uiTransform = null;
            this.DataId = 0;
        }
        
        private Image m_es_ImageIcon;
        private Transform m_es_ImageDi;
        private Transform m_es_StartNode;
        private Transform m_es_ImageSelect;
        private Transform m_es_Start_2;
        private Transform m_es_Start_1;
        private Transform m_es_Start_0;
        private Text m_es_TextCombat;
        private Text m_es_TextLevel;
        private Transform m_es_Node_1;
        private Transform m_es_Node_2;
        private Transform m_es_ImageLine_1;
        private Transform m_es_ImageLine_2;
        
        public Action<int> ClickHandler;
        public Transform uiTransform = null;
        public int PetFubenId;
    }
}