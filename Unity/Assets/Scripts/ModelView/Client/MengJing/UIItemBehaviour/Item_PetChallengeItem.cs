using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EnableMethod]
    public class Scroll_Item_PetChallengeItem: Entity,IAwake,IDestroy,IUIScrollItem 
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

        public UnityEngine.GameObject E_ImageIcon
        {
            get
            {
                return null;
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
        
        private GameObject m_es_ImageIcon;
        private GameObject m_es_ImageDi;
        private GameObject m_es_StartNode;
        private GameObject m_es_ImageSelect;
        private GameObject m_es_Start_2;
        private GameObject m_es_Start_1;
        private GameObject m_es_Start_0;
        private GameObject m_es_TextCombat;
        private GameObject m_es_TextLevel;
        private GameObject m_es_Node_1;
        private GameObject m_es_Node_2;
        private GameObject m_es_ImageLine_1;
        private GameObject m_es_ImageLine_2;
        
        public Action<int> ClickHandler;
        public Transform uiTransform = null;
        public int PetFubenId;
    }
}