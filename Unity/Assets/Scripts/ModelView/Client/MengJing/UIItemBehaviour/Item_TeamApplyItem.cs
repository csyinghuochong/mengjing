using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_TeamApplyItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_TeamApplyItem>
	{
		public TeamPlayerInfo TeamPlayerInfo;
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_TeamApplyItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ButtonRefuseButton
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
     				if( this.m_E_ButtonRefuseButton == null )
     				{
		    			this.m_E_ButtonRefuseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonRefuse");
     				}
     				return this.m_E_ButtonRefuseButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonRefuse");
     			}
     		}
     	}

		public Image E_ButtonRefuseImage
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
     				if( this.m_E_ButtonRefuseImage == null )
     				{
		    			this.m_E_ButtonRefuseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonRefuse");
     				}
     				return this.m_E_ButtonRefuseImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonRefuse");
     			}
     		}
     	}

		public Button E_ButtonAgreeButton
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
     				if( this.m_E_ButtonAgreeButton == null )
     				{
		    			this.m_E_ButtonAgreeButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonAgree");
     				}
     				return this.m_E_ButtonAgreeButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonAgree");
     			}
     		}
     	}

		public Image E_ButtonAgreeImage
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
     				if( this.m_E_ButtonAgreeImage == null )
     				{
		    			this.m_E_ButtonAgreeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonAgree");
     				}
     				return this.m_E_ButtonAgreeImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonAgree");
     			}
     		}
     	}

		public Text E_TextNameText
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
     				if( this.m_E_TextNameText == null )
     				{
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     		}
     	}

		public Text E_TextLevelText
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
     				if( this.m_E_TextLevelText == null )
     				{
		    			this.m_E_TextLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLevel");
     				}
     				return this.m_E_TextLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextLevel");
     			}
     		}
     	}

		public Text E_TextCombatText
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
     				if( this.m_E_TextCombatText == null )
     				{
		    			this.m_E_TextCombatText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextCombat");
     				}
     				return this.m_E_TextCombatText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextCombat");
     			}
     		}
     	}

		public Text E_TextOccText
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
     				if( this.m_E_TextOccText == null )
     				{
		    			this.m_E_TextOccText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextOcc");
     				}
     				return this.m_E_TextOccText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextOcc");
     			}
     		}
     	}

		public RectTransform EG_RootShowSetRectTransform
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
     				if( this.m_EG_RootShowSetRectTransform == null )
     				{
		    			this.m_EG_RootShowSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RootShowSet");
     				}
     				return this.m_EG_RootShowSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RootShowSet");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonRefuseButton = null;
			this.m_E_ButtonRefuseImage = null;
			this.m_E_ButtonAgreeButton = null;
			this.m_E_ButtonAgreeImage = null;
			this.m_E_TextNameText = null;
			this.m_E_TextLevelText = null;
			this.m_E_TextCombatText = null;
			this.m_E_TextOccText = null;
			this.m_EG_RootShowSetRectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ButtonRefuseButton = null;
		private Image m_E_ButtonRefuseImage = null;
		private Button m_E_ButtonAgreeButton = null;
		private Image m_E_ButtonAgreeImage = null;
		private Text m_E_TextNameText = null;
		private Text m_E_TextLevelText = null;
		private Text m_E_TextCombatText = null;
		private Text m_E_TextOccText = null;
		private RectTransform m_EG_RootShowSetRectTransform = null;
		public Transform uiTransform = null;
	}
}
