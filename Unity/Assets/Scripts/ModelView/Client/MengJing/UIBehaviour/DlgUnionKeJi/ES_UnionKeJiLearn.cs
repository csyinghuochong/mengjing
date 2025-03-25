using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionKeJiLearn : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int Position;
		public UnionInfo UnionMyInfo { get; set; }
		public UserInfo UserInfo { get; set; }
		public List<EntityRef<ES_UnionKeJiLearnItem>> Items = new();
		
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
		
		public Image E_HeadImgImage
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
		    		this.m_E_HeadImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_HeadImg");
     			}
     			return this.m_E_HeadImgImage;
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
     			if( this.m_E_NameTextText == null )
     			{
		    		this.m_E_NameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_NameText");
     			}
     			return this.m_E_NameTextText;
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
     			if( this.m_E_LvTextText == null )
     			{
		    		this.m_E_LvTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_LvText");
     			}
     			return this.m_E_LvTextText;
     		}
     	}

		public Text E_MaxLvTextText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_MaxLvTextText == null )
				{
					this.m_E_MaxLvTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_MaxLvText");
				}
				return this.m_E_MaxLvTextText;
			}
		}
		
		public Text E_PreTextText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_PreTextText == null )
				{
					this.m_E_PreTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_PreText");
				}
				return this.m_E_PreTextText;
			}
		}
		
		public Text E_CostPointTextText
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_CostPointTextText == null )
				{
					this.m_E_CostPointTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_CostPointText");
				}
				return this.m_E_CostPointTextText;
			}
		}
		
		public ES_CostList ES_CostList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_CostList es = this.m_es_costlist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CostList");
		    	   this.m_es_costlist = this.AddChild<ES_CostList,Transform>(subTrans);
     			}
     			return this.m_es_costlist;
     		}
     	}

		public Button E_ActiveBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActiveBtnButton == null )
     			{
		    		this.m_E_ActiveBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ActiveBtn");
     			}
     			return this.m_E_ActiveBtnButton;
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
					this.m_E_UpBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_UpBtn");
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
		    		this.m_E_StartBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_StartBtn");
     			}
     			return this.m_E_StartBtnImage;
     		}
     	}

		public Text E_AttributeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttributeTextText == null )
     			{
		    		this.m_E_AttributeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_AttributeText");
     			}
     			return this.m_E_AttributeTextText;
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
			this.m_E_HeadImgImage = null;
			this.m_E_NameTextText = null;
			this.m_E_LvTextText = null;
			this.m_E_MaxLvTextText = null;
			this.m_E_PreTextText = null;
			this.m_E_CostPointTextText = null;
			this.m_es_costlist = null;
			this.m_E_ActiveBtnButton = null;
			this.m_E_UpBtnButton = null;
			this.m_E_StartBtnImage = null;
			this.m_E_AttributeTextText = null;
			this.uiTransform = null;
		}
		
		private RectTransform m_EG_ContentRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageSelectImage = null;
		private Image m_E_HeadImgImage = null;
		private Text m_E_NameTextText = null;
		private Text m_E_LvTextText = null;
		private Text m_E_MaxLvTextText = null;
		private Text m_E_PreTextText = null;
		private Text m_E_CostPointTextText = null;
		private EntityRef<ES_CostList> m_es_costlist = null;
		private Button m_E_ActiveBtnButton = null;
		private Button m_E_UpBtnButton = null;
		private Image m_E_StartBtnImage = null;
		private Text m_E_AttributeTextText = null;
		public Transform uiTransform = null;
	}
}
