﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_RolePropertyTeShuItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_RolePropertyTeShuItem> 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_RolePropertyTeShuItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_IconImage
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
     				if( this.m_E_IconImage == null )
     				{
		    			this.m_E_IconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Icon");
     				}
     				return this.m_E_IconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Icon");
     			}
     		}
     	}

		public Text E_PropertyTypeText
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
     				if( this.m_E_PropertyTypeText == null )
     				{
		    			this.m_E_PropertyTypeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertyType");
     				}
     				return this.m_E_PropertyTypeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PropertyType");
     			}
     		}
     	}

		public Text E_ProTypeValueText
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
     				if( this.m_E_ProTypeValueText == null )
     				{
		    			this.m_E_ProTypeValueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ProTypeValue");
     				}
     				return this.m_E_ProTypeValueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ProTypeValue");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_IconImage = null;
			this.m_E_PropertyTypeText = null;
			this.m_E_ProTypeValueText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_IconImage = null;
		private Text m_E_PropertyTypeText = null;
		private Text m_E_ProTypeValueText = null;
		public Transform uiTransform = null;
	}
}
