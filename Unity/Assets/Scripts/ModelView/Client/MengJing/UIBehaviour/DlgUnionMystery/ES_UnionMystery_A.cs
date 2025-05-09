﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionMystery_A : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<MysteryItemInfo> ShowMysteryItemInfos;
		public Dictionary<int, EntityRef<Scroll_Item_UnionMysteryItem_A>> ScrollItemUnionMysteryItemAs;
		
		public LoopVerticalScrollRect E_UnionMysteryItemAsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionMysteryItemAsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionMysteryItemAsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_UnionMysteryItemAs");
     			}
     			return this.m_E_UnionMysteryItemAsLoopVerticalScrollRect;
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
			this.m_E_UnionMysteryItemAsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_UnionMysteryItemAsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
