
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

		public UnityEngine.UI.Button E_ButtonRefuseButton
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
		    			this.m_E_ButtonRefuseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonRefuse");
     				}
     				return this.m_E_ButtonRefuseButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonRefuse");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonRefuseImage
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
		    			this.m_E_ButtonRefuseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonRefuse");
     				}
     				return this.m_E_ButtonRefuseImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonRefuse");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_ButtonAgreeButton
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
		    			this.m_E_ButtonAgreeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonAgree");
     				}
     				return this.m_E_ButtonAgreeButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonAgree");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ButtonAgreeImage
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
		    			this.m_E_ButtonAgreeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonAgree");
     				}
     				return this.m_E_ButtonAgreeImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonAgree");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_ImageIconImage
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
     				if( this.m_E_ImageIconImage == null )
     				{
		    			this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon");
     				}
     				return this.m_E_ImageIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextNameText
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
		    			this.m_E_TextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     				}
     				return this.m_E_TextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextName");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextLevelText
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
		    			this.m_E_TextLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLevel");
     				}
     				return this.m_E_TextLevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextLevel");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextCombatText
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
		    			this.m_E_TextCombatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextCombat");
     				}
     				return this.m_E_TextCombatText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextCombat");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextOccText
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
		    			this.m_E_TextOccText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextOcc");
     				}
     				return this.m_E_TextOccText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TextOcc");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_RootShowSetRectTransform
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
		    			this.m_EG_RootShowSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RootShowSet");
     				}
     				return this.m_EG_RootShowSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_RootShowSet");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonRefuseButton = null;
			this.m_E_ButtonRefuseImage = null;
			this.m_E_ButtonAgreeButton = null;
			this.m_E_ButtonAgreeImage = null;
			this.m_E_ImageIconImage = null;
			this.m_E_TextNameText = null;
			this.m_E_TextLevelText = null;
			this.m_E_TextCombatText = null;
			this.m_E_TextOccText = null;
			this.m_EG_RootShowSetRectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_E_ButtonRefuseButton = null;
		private UnityEngine.UI.Image m_E_ButtonRefuseImage = null;
		private UnityEngine.UI.Button m_E_ButtonAgreeButton = null;
		private UnityEngine.UI.Image m_E_ButtonAgreeImage = null;
		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		private UnityEngine.UI.Text m_E_TextLevelText = null;
		private UnityEngine.UI.Text m_E_TextCombatText = null;
		private UnityEngine.UI.Text m_E_TextOccText = null;
		private UnityEngine.RectTransform m_EG_RootShowSetRectTransform = null;
		public Transform uiTransform = null;
	}
}
