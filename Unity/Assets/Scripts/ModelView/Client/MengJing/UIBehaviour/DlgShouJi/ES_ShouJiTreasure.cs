﻿using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ShouJiTreasure : Entity,IAwake<Transform>,IDestroy 
	{
		public GameObject TypeListNode;
		public GameObject UIShouJiTreasureType;
		public GameObject ItemListNode;
		public GameObject UIShouJiTreasureItem;

		public List<EntityRef<UIShouJiTreasureItemComponent>> TreasureItemList = new();
		public List<EntityRef<UIShouJiTreasureTypeComponent>> TreasureTypeList = new();
		
		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem;
     			if( es ==null  )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ScrollView/Viewport/UIShouJiTreasureItem/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
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
			this.m_es_commonitem = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		public Transform uiTransform = null;
	}
}
