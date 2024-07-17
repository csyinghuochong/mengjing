using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_SettingTitleItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_SettingTitleItem>
	{
		public int Title;
		public UIXuLieZhenComponent UIXuLieZhenComponent { get; set; }
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_SettingTitleItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public Button E_ButtonActiviteButton
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
     				if( this.m_E_ButtonActiviteButton == null )
     				{
		    			this.m_E_ButtonActiviteButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonActivite");
     				}
     				return this.m_E_ButtonActiviteButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonActivite");
     			}
     		}
     	}

		public Image E_ButtonActiviteImage
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
     				if( this.m_E_ButtonActiviteImage == null )
     				{
		    			this.m_E_ButtonActiviteImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonActivite");
     				}
     				return this.m_E_ButtonActiviteImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonActivite");
     			}
     		}
     	}

		public Text E_Text_valueText
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
     				if( this.m_E_Text_valueText == null )
     				{
		    			this.m_E_Text_valueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_value");
     				}
     				return this.m_E_Text_valueText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_value");
     			}
     		}
     	}

		public Image E_RawImageImage
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
     				if( this.m_E_RawImageImage == null )
     				{
		    			this.m_E_RawImageImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"GameObject/E_RawImage");
     				}
     				return this.m_E_RawImageImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"GameObject/E_RawImage");
     			}
     		}
     	}

		public Text E_ObjGetTextText
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
     				if( this.m_E_ObjGetTextText == null )
     				{
		    			this.m_E_ObjGetTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ObjGetText");
     				}
     				return this.m_E_ObjGetTextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ObjGetText");
     			}
     		}
     	}

		public Text E_ChengHaoNameText
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
     				if( this.m_E_ChengHaoNameText == null )
     				{
		    			this.m_E_ChengHaoNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Name/E_ChengHaoName");
     				}
     				return this.m_E_ChengHaoNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Name/E_ChengHaoName");
     			}
     		}
     	}

		public RectTransform EG_UseSetRectTransform
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
     				if( this.m_EG_UseSetRectTransform == null )
     				{
		    			this.m_EG_UseSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_UseSet");
     				}
     				return this.m_EG_UseSetRectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_UseSet");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonActiviteButton = null;
			this.m_E_ButtonActiviteImage = null;
			this.m_E_Text_valueText = null;
			this.m_E_RawImageImage = null;
			this.m_E_ObjGetTextText = null;
			this.m_E_ChengHaoNameText = null;
			this.m_EG_UseSetRectTransform = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private Button m_E_ButtonActiviteButton = null;
		private Image m_E_ButtonActiviteImage = null;
		private Text m_E_Text_valueText = null;
		private Image m_E_RawImageImage = null;
		private Text m_E_ObjGetTextText = null;
		private Text m_E_ChengHaoNameText = null;
		private RectTransform m_EG_UseSetRectTransform = null;
		public Transform uiTransform = null;
	}
}
