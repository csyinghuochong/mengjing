using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionKeJiResearch : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public long NeedTime;
		public int Position;
		public UnionInfo UnionMyInfo { get; set; }
		public List<EntityRef<ES_UnionKeJiResearchItem>> Items = new();
		
		public RectTransform EG_ContentRectTransform
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_EG_ContentRectTransform == null )
				{
					this.m_EG_ContentRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/Scroll View/Viewport/EG_Content");
				}
				return this.m_EG_ContentRectTransform;
			}
		}
		
		public UnityEngine.UI.Image E_ImageSelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelectImage == null )
     			{
		    		this.m_E_ImageSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ImageSelect");
     			}
     			return this.m_E_ImageSelectImage;
     		}
     	}

		public RectTransform EG_ProgressRectTransform
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_EG_ProgressRectTransform == null )
				{
					this.m_EG_ProgressRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Progress");
				}
				return this.m_EG_ProgressRectTransform;
			}
		}
		
		public UnityEngine.UI.Image E_ProgressBarImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProgressBarImgImage == null )
     			{
		    		this.m_E_ProgressBarImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_Progress/E_ProgressBarImg");
     			}
     			return this.m_E_ProgressBarImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_ProgressBarTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProgressBarTextText == null )
     			{
		    		this.m_E_ProgressBarTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_Progress/E_ProgressBarText");
     			}
     			return this.m_E_ProgressBarTextText;
     		}
     	}

		public UnityEngine.UI.Button E_QuickBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QuickBtnButton == null )
     			{
		    		this.m_E_QuickBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_Progress/E_QuickBtn");
     			}
     			return this.m_E_QuickBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_QuickBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QuickBtnImage == null )
     			{
		    		this.m_E_QuickBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_QuickBtn");
     			}
     			return this.m_E_QuickBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_HeadImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadImgImage == null )
     			{
		    		this.m_E_HeadImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_HeadImg");
     			}
     			return this.m_E_HeadImgImage;
     		}
     	}

		public UnityEngine.UI.Text E_NameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameTextText == null )
     			{
		    		this.m_E_NameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_NameText");
     			}
     			return this.m_E_NameTextText;
     		}
     	}

		public UnityEngine.UI.Text E_LvTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LvTextText == null )
     			{
		    		this.m_E_LvTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_LvText");
     			}
     			return this.m_E_LvTextText;
     		}
     	}

		public UnityEngine.UI.Text E_NeedUnionLvTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NeedUnionLvTextText == null )
     			{
		    		this.m_E_NeedUnionLvTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_NeedUnionLvText");
     			}
     			return this.m_E_NeedUnionLvTextText;
     		}
     	}

		public UnityEngine.UI.Image E_CostItemIconImage
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_CostItemIconImage == null )
				{
					this.m_E_CostItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_CostItemIcon");
				}
				return this.m_E_CostItemIconImage;
			}
		}

		public Text E_CostUnionGoldTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostUnionGoldTextText == null )
     			{
		    		this.m_E_CostUnionGoldTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_CostUnionGoldText");
     			}
     			return this.m_E_CostUnionGoldTextText;
     		}
     	}

		public Text E_NeedTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NeedTimeTextText == null )
     			{
		    		this.m_E_NeedTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NeedTimeText");
     			}
     			return this.m_E_NeedTimeTextText;
     		}
     	}

		public Button E_UpBtnButton
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_UpBtnButton == null )
				{
					this.m_E_UpBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_UpBtn");
				}
				return this.m_E_UpBtnButton;
			}
		}
		
		public Image E_StartBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnImage == null )
     			{
		    		this.m_E_StartBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_StartBtn");
     			}
     			return this.m_E_StartBtnImage;
     		}
     	}

		public Text E_NowAttributeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NowAttributeTextText == null )
     			{
		    		this.m_E_NowAttributeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NowAttributeText");
     			}
     			return this.m_E_NowAttributeTextText;
     		}
     	}
		
		public Text E_NextAttributeTextText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_NextAttributeTextText == null )
				{
					this.m_E_NextAttributeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NextAttributeText");
				}
				return this.m_E_NextAttributeTextText;
			}
		}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_EG_ContentRectTransform = null;
			this.m_E_ImageSelectImage = null;
			this.m_EG_ProgressRectTransform = null;
			this.m_E_ProgressBarImgImage = null;
			this.m_E_ProgressBarTextText = null;
			this.m_E_QuickBtnButton = null;
			this.m_E_QuickBtnImage = null;
			this.m_E_HeadImgImage = null;
			this.m_E_NameTextText = null;
			this.m_E_LvTextText = null;
			this.m_E_NeedUnionLvTextText = null;
			this.m_E_CostItemIconImage = null;
			this.m_E_CostUnionGoldTextText = null;
			this.m_E_NeedTimeTextText = null;
			this.m_E_UpBtnButton = null;
			this.m_E_StartBtnImage = null;
			this.m_E_NowAttributeTextText = null;
			this.m_E_NextAttributeTextText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_ContentRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private RectTransform m_EG_ProgressRectTransform = null;
		private UnityEngine.UI.Image m_E_ProgressBarImgImage = null;
		private UnityEngine.UI.Text m_E_ProgressBarTextText = null;
		private UnityEngine.UI.Button m_E_QuickBtnButton = null;
		private UnityEngine.UI.Image m_E_QuickBtnImage = null;
		private UnityEngine.UI.Image m_E_HeadImgImage = null;
		private UnityEngine.UI.Text m_E_NameTextText = null;
		private UnityEngine.UI.Text m_E_LvTextText = null;
		private UnityEngine.UI.Text m_E_NeedUnionLvTextText = null;
		private UnityEngine.UI.Image m_E_CostItemIconImage = null;
		private Text m_E_CostUnionGoldTextText = null;
		private Text m_E_NeedTimeTextText = null;
		private Button m_E_UpBtnButton = null;
		private Image m_E_StartBtnImage = null;
		private Text m_E_NowAttributeTextText = null;
		private Text m_E_NextAttributeTextText = null;
		public Transform uiTransform = null;
	}
}
