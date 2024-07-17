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

		public RectTransform EG_Node1RectTransform
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
		    			this.m_EG_Node1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node1");
     				}
     				return this.m_EG_Node1RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node1");
     			}
     		}
     	}

		public Image E_BGImage
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
		    			this.m_E_BGImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/E_BG");
     				}
     				return this.m_E_BGImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/E_BG");
     			}
     		}
     	}

		public Button E_HeadIconButton
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
		    			this.m_E_HeadIconButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/Image (1)/Image (2)/E_HeadIcon");
     				}
     				return this.m_E_HeadIconButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/Image (1)/Image (2)/E_HeadIcon");
     			}
     		}
     	}

		public Image E_HeadIconImage
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
		    			this.m_E_HeadIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/Image (1)/Image (2)/E_HeadIcon");
     				}
     				return this.m_E_HeadIconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/Image (1)/Image (2)/E_HeadIcon");
     			}
     		}
     	}

		public Image E_HeadIconXiTongImage
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
		    			this.m_E_HeadIconXiTongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/E_HeadIconXiTong");
     				}
     				return this.m_E_HeadIconXiTongImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Node1/E_HeadIconXiTong");
     			}
     		}
     	}

		public Button E_NameButton
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
		    			this.m_E_NameButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/E_Name");
     				}
     				return this.m_E_NameButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/E_Name");
     			}
     		}
     	}

		public Text E_NameText
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
		    			this.m_E_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Name");
     				}
     				return this.m_E_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Name");
     			}
     		}
     	}

		public Button E_TextButton
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
		    			this.m_E_TextButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/E_Text");
     				}
     				return this.m_E_TextButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Node1/E_Text");
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
		    			this.m_E_TextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Text");
     				}
     				return this.m_E_TextText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Text");
     			}
     		}
     	}

		public Text E_SpeakText
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
		    			this.m_E_SpeakText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Speak");
     				}
     				return this.m_E_SpeakText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Speak");
     			}
     		}
     	}

		public Text E_LevelText
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
		    			this.m_E_LevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Level");
     				}
     				return this.m_E_LevelText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node1/E_Level");
     			}
     		}
     	}

		public RectTransform EG_Node2RectTransform
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
		    			this.m_EG_Node2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node2");
     				}
     				return this.m_EG_Node2RectTransform;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Node2");
     			}
     		}
     	}

		public Text E_SystemText
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
		    			this.m_E_SystemText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node2/E_System");
     				}
     				return this.m_E_SystemText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Node2/E_System");
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

		private RectTransform m_EG_Node1RectTransform = null;
		private Image m_E_BGImage = null;
		private Button m_E_HeadIconButton = null;
		private Image m_E_HeadIconImage = null;
		private Image m_E_HeadIconXiTongImage = null;
		private Button m_E_NameButton = null;
		private Text m_E_NameText = null;
		private Button m_E_TextButton = null;
		private Text m_E_TextText = null;
		private Text m_E_SpeakText = null;
		private Text m_E_LevelText = null;
		private RectTransform m_EG_Node2RectTransform = null;
		private Text m_E_SystemText = null;
		public Transform uiTransform = null;
	}
}
