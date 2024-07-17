using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_PetQuickFightItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_PetQuickFightItem> 
	{
		public Action<long> ClickHandler;
		public long PetId;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_PetQuickFightItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_IconButton
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
     				if( this.m_E_IconButton == null )
     				{
		    			this.m_E_IconButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Icon");
     				}
     				return this.m_E_IconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Icon");
     			}
     		}
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

		public Button E_ButtonButton
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
     				if( this.m_E_ButtonButton == null )
     				{
		    			this.m_E_ButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button");
     				}
     				return this.m_E_ButtonButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button");
     			}
     		}
     	}

		public Image E_ButtonImage
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
     				if( this.m_E_ButtonImage == null )
     				{
		    			this.m_E_ButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button");
     				}
     				return this.m_E_ButtonImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button");
     			}
     		}
     	}

		public Text E_TextText
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
     				if( this.m_E_TextText == null )
     				{
		    			this.m_E_TextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Button/E_Text");
     				}
     				return this.m_E_TextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Button/E_Text");
     			}
     		}
     	}

		public Text E_TexTCdText
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
     				if( this.m_E_TexTCdText == null )
     				{
		    			this.m_E_TexTCdText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TexTCd");
     				}
     				return this.m_E_TexTCdText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TexTCd");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_IconButton = null;
			this.m_E_IconImage = null;
			this.m_E_ButtonButton = null;
			this.m_E_ButtonImage = null;
			this.m_E_TextText = null;
			this.m_E_TexTCdText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_IconButton = null;
		private Image m_E_IconImage = null;
		private Button m_E_ButtonButton = null;
		private Image m_E_ButtonImage = null;
		private Text m_E_TextText = null;
		private Text m_E_TexTCdText = null;
		public Transform uiTransform = null;
	}
}
