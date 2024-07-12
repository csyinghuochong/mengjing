
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EnableMethod]
	public  class Scroll_Item_ChatItem : Entity,IAwake,IDestroy,IUIScrollItem<Scroll_Item_ChatItem>
	{
		public ChatInfo ChatInfo;
		public GameObject[] TitleList = new GameObject[ChannelEnum.Number];
		
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ChatItem BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.RectTransform EG_Node1RectTransform
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
     				if( this.m_EG_Node1RectTransform == null )
     				{
		    			this.m_EG_Node1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node1");
     				}
     				return this.m_EG_Node1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node1");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_BGImage
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
     				if( this.m_E_BGImage == null )
     				{
		    			this.m_E_BGImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node1/E_BG");
     				}
     				return this.m_E_BGImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node1/E_BG");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_HeadIconButton
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
     				if( this.m_E_HeadIconButton == null )
     				{
		    			this.m_E_HeadIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node1/Image (1)/Image (2)/E_HeadIcon");
     				}
     				return this.m_E_HeadIconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node1/Image (1)/Image (2)/E_HeadIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_HeadIconImage
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
     				if( this.m_E_HeadIconImage == null )
     				{
		    			this.m_E_HeadIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node1/Image (1)/Image (2)/E_HeadIcon");
     				}
     				return this.m_E_HeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node1/Image (1)/Image (2)/E_HeadIcon");
     			}
     		}
     	}

		public UnityEngine.UI.Image E_HeadIconXiTongImage
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
     				if( this.m_E_HeadIconXiTongImage == null )
     				{
		    			this.m_E_HeadIconXiTongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node1/E_HeadIconXiTong");
     				}
     				return this.m_E_HeadIconXiTongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Node1/E_HeadIconXiTong");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_NameButton
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
     				if( this.m_E_NameButton == null )
     				{
		    			this.m_E_NameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node1/E_Name");
     				}
     				return this.m_E_NameButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node1/E_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_NameText
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
     				if( this.m_E_NameText == null )
     				{
		    			this.m_E_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node1/E_Name");
     				}
     				return this.m_E_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node1/E_Name");
     			}
     		}
     	}

		public UnityEngine.UI.Button E_TextButton
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
     				if( this.m_E_TextButton == null )
     				{
		    			this.m_E_TextButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node1/E_Text");
     				}
     				return this.m_E_TextButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Node1/E_Text");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_TextText
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
		    			this.m_E_TextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node1/E_Text");
     				}
     				return this.m_E_TextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node1/E_Text");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_SpeakText
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
     				if( this.m_E_SpeakText == null )
     				{
		    			this.m_E_SpeakText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node1/E_Speak");
     				}
     				return this.m_E_SpeakText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node1/E_Speak");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_LevelText
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
     				if( this.m_E_LevelText == null )
     				{
		    			this.m_E_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node1/E_Level");
     				}
     				return this.m_E_LevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node1/E_Level");
     			}
     		}
     	}

		public UnityEngine.RectTransform EG_Node2RectTransform
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
     				if( this.m_EG_Node2RectTransform == null )
     				{
		    			this.m_EG_Node2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node2");
     				}
     				return this.m_EG_Node2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Node2");
     			}
     		}
     	}

		public UnityEngine.UI.Text E_SystemText
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
     				if( this.m_E_SystemText == null )
     				{
		    			this.m_E_SystemText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node2/E_System");
     				}
     				return this.m_E_SystemText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Node2/E_System");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_Node1RectTransform = null;
			this.m_E_BGImage = null;
			this.m_E_HeadIconButton = null;
			this.m_E_HeadIconImage = null;
			this.m_E_HeadIconXiTongImage = null;
			this.m_E_NameButton = null;
			this.m_E_NameText = null;
			this.m_E_TextButton = null;
			this.m_E_TextText = null;
			this.m_E_SpeakText = null;
			this.m_E_LevelText = null;
			this.m_EG_Node2RectTransform = null;
			this.m_E_SystemText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.RectTransform m_EG_Node1RectTransform = null;
		private UnityEngine.UI.Image m_E_BGImage = null;
		private UnityEngine.UI.Button m_E_HeadIconButton = null;
		private UnityEngine.UI.Image m_E_HeadIconImage = null;
		private UnityEngine.UI.Image m_E_HeadIconXiTongImage = null;
		private UnityEngine.UI.Button m_E_NameButton = null;
		private UnityEngine.UI.Text m_E_NameText = null;
		private UnityEngine.UI.Button m_E_TextButton = null;
		private UnityEngine.UI.Text m_E_TextText = null;
		private UnityEngine.UI.Text m_E_SpeakText = null;
		private UnityEngine.UI.Text m_E_LevelText = null;
		private UnityEngine.RectTransform m_EG_Node2RectTransform = null;
		private UnityEngine.UI.Text m_E_SystemText = null;
		public Transform uiTransform = null;
	}
}
