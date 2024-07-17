using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_UnionKeJiResearchItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_UnionKeJiResearchItem>
	{
		public int Position;
		public Action<int> ClickAction;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_UnionKeJiResearchItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Image E_IconImgImage
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
     				if( this.m_E_IconImgImage == null )
     				{
		    			this.m_E_IconImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_IconImg");
     				}
     				return this.m_E_IconImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_IconImg");
     			}
     		}
     	}

		public Text E_NameTextText
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
     				if( this.m_E_NameTextText == null )
     				{
		    			this.m_E_NameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     				}
     				return this.m_E_NameTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     		}
     	}

		public Text E_LvTextText
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
     				if( this.m_E_LvTextText == null )
     				{
		    			this.m_E_LvTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LvText");
     				}
     				return this.m_E_LvTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LvText");
     			}
     		}
     	}

		public Image E_HighlightImgImage
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
     				if( this.m_E_HighlightImgImage == null )
     				{
		    			this.m_E_HighlightImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_HighlightImg");
     				}
     				return this.m_E_HighlightImgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_HighlightImg");
     			}
     		}
     	}

		public Button E_ClickBtnButton
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
     				if( this.m_E_ClickBtnButton == null )
     				{
		    			this.m_E_ClickBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ClickBtn");
     				}
     				return this.m_E_ClickBtnButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ClickBtn");
     			}
     		}
     	}

		public Image E_ClickBtnImage
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
     				if( this.m_E_ClickBtnImage == null )
     				{
		    			this.m_E_ClickBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ClickBtn");
     				}
     				return this.m_E_ClickBtnImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ClickBtn");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_IconImgImage = null;
			this.m_E_NameTextText = null;
			this.m_E_LvTextText = null;
			this.m_E_HighlightImgImage = null;
			this.m_E_ClickBtnButton = null;
			this.m_E_ClickBtnImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Image m_E_IconImgImage = null;
		private Text m_E_NameTextText = null;
		private Text m_E_LvTextText = null;
		private Image m_E_HighlightImgImage = null;
		private Button m_E_ClickBtnButton = null;
		private Image m_E_ClickBtnImage = null;
		public Transform uiTransform = null;
	}
}
