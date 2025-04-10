﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_test : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_test>
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_test BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button EButton_SelectButton
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
     				if( this.m_EButton_SelectButton == null )
     				{
		    			this.m_EButton_SelectButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EButton_Select");
     				}
     				return this.m_EButton_SelectButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EButton_Select");
     			}
     		}
     	}

		public Image EButton_SelectImage
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
     				if( this.m_EButton_SelectImage == null )
     				{
		    			this.m_EButton_SelectImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EButton_Select");
     				}
     				return this.m_EButton_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EButton_Select");
     			}
     		}
     	}

		public Text ELabel_ContentText
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
     				if( this.m_ELabel_ContentText == null )
     				{
		    			this.m_ELabel_ContentText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ELabel_Content");
     				}
     				return this.m_ELabel_ContentText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"ELabel_Content");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_SelectButton = null;
			this.m_EButton_SelectImage = null;
			this.m_ELabel_ContentText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_EButton_SelectButton = null;
		private Image m_EButton_SelectImage = null;
		private Text m_ELabel_ContentText = null;
		public Transform uiTransform = null;
	}
}
