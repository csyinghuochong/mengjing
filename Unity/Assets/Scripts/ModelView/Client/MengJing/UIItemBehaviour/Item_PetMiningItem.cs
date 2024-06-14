using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    
    [EnableMethod]
    public class Scroll_Item_PetMiningItem: Entity,IAwake,IDestroy,IUIScrollItem 
    {
        
        public long DataId {get;set;}
        private bool isCacheNode = false;
        public void SetCacheMode(bool isCache)
        {
            this.isCacheNode = isCache;
        }
        
        public Scroll_Item_PetMiningItem BindTrans(Transform trans)
        {
            this.uiTransform = trans;
            return this;
        }
        
        public void DestroyWidget()
        {
            this.uiTransform = null;
            this.DataId = 0;
        }
        
        public Transform uiTransform = null;
    }
    
}