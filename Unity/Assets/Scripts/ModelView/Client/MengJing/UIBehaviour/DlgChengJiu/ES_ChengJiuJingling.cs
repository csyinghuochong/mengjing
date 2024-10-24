﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChengJiuJingling : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<JingLingConfig> ShowJingLing = new();
		public Dictionary<int, EntityRef<Scroll_Item_ChengJiuJinglingItem>> ScrollItemChengJiuJinglingItems;
		
		public LoopVerticalScrollRect E_ChengJiuJinglingItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ChengJiuJinglingItems");
     			}
     			return this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect;
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
			this.m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_ChengJiuJinglingItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
