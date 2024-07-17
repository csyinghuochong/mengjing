using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChengJiuTypeItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ChengJiuTypeItem>,IUILogic
	{
		public Action<int, int> ClickTaskSubTypeHandler;
		public int ChengJiuTypeId;
		public bool Selected;
		public List<int> ShowChapter = new();
		public Dictionary<int, EntityRef<Scroll_Item_ChengJiuTypeItemItem>> ScrollItemChengJiuTypeItemItems;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ChengJiuTypeItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ImageButtonButton
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
     				if( this.m_E_ImageButtonButton == null )
     				{
		    			this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     		}
     	}

		public Image E_ImageButtonImage
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
     				if( this.m_E_ImageButtonImage == null )
     				{
		    			this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     				}
     				return this.m_E_ImageButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     		}
     	}

		public Image E_CheckmarkImage
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
     				if( this.m_E_CheckmarkImage == null )
     				{
		    			this.m_E_CheckmarkImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Checkmark");
     				}
     				return this.m_E_CheckmarkImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Checkmark");
     			}
     		}
     	}

		public Text E_TaskTypeNameText
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
     				if( this.m_E_TaskTypeNameText == null )
     				{
		    			this.m_E_TaskTypeNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskTypeName");
     				}
     				return this.m_E_TaskTypeNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TaskTypeName");
     			}
     		}
     	}

		public LoopVerticalScrollRect E_ChengJiuTypeItemItemsLoopVerticalScrollRect
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
     				if( this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect == null )
     				{
		    			this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ChengJiuTypeItemItems");
     				}
     				return this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ChengJiuTypeItemItems");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_CheckmarkImage = null;
			this.m_E_TaskTypeNameText = null;
			this.m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private Image m_E_CheckmarkImage = null;
		private Text m_E_TaskTypeNameText = null;
		private LoopVerticalScrollRect m_E_ChengJiuTypeItemItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
