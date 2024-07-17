using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PaiMaiBuy : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int PageIndex = 1;
		public int ItemType;
		public int ItemSubType;
		public List<PaiMaiItemInfo> ShowPaiMaiIteminfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_PaiMaiBuyItem>> ScrollItemPaiMaiBuyItems;
		public UITypeViewComponent UITypeViewComponent { get; set; }
		//当前用到的显示用的
		public List<PaiMaiItemInfo> PaiMaiIteminfos_Now = new();

		//-----------拍卖行缓存----------
		public Dictionary<int, List<PaiMaiItemInfo>> PaiMaiItemInfos_Consume = new();
		public Dictionary<int, List<PaiMaiItemInfo>> PaiMaiItemInfos_Material = new();
		public Dictionary<int, List<PaiMaiItemInfo>> PaiMaiItemInfos_Equipment = new();
		public Dictionary<int, List<PaiMaiItemInfo>> PaiMaiItemInfos_Gemstone = new();

		//记录下一页index
		public int MaxPage_Consume = 1;
		public int MaxPage_Material = 1;
		public int MaxPage_Equipment = 1;
		public int MaxPage_Gemstone = 1;

		public long SearchTime;

		public LoopVerticalScrollRect E_PaiMaiBuyItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PaiMaiBuyItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PaiMaiBuyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PaiMaiBuyItems");
     			}
     			return this.m_E_PaiMaiBuyItemsLoopVerticalScrollRect;
     		}
     	}

		public RectTransform EG_ItemListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ItemListNodeRectTransform == null )
     			{
		    		this.m_EG_ItemListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"E_PaiMaiBuyItems/EG_ItemListNode");
     			}
     			return this.m_EG_ItemListNodeRectTransform;
     		}
     	}

		public RectTransform EG_TypeListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TypeListNodeRectTransform == null )
     			{
		    		this.m_EG_TypeListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView2/Viewport/EG_TypeListNode");
     			}
     			return this.m_EG_TypeListNodeRectTransform;
     		}
     	}

		public Button E_Btn_SearchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SearchButton == null )
     			{
		    		this.m_E_Btn_SearchButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Search");
     			}
     			return this.m_E_Btn_SearchButton;
     		}
     	}

		public Image E_Btn_SearchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_SearchImage == null )
     			{
		    		this.m_E_Btn_SearchImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Search");
     			}
     			return this.m_E_Btn_SearchImage;
     		}
     	}

		public InputField E_InputFieldInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldInputField == null )
     			{
		    		this.m_E_InputFieldInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_InputField");
     			}
     			return this.m_E_InputFieldInputField;
     		}
     	}

		public Image E_InputFieldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldImage == null )
     			{
		    		this.m_E_InputFieldImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InputField");
     			}
     			return this.m_E_InputFieldImage;
     		}
     	}

		public RectTransform EG_ShowPageRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ShowPageRectTransform == null )
     			{
		    		this.m_EG_ShowPageRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ShowPage");
     			}
     			return this.m_EG_ShowPageRectTransform;
     		}
     	}

		public Text E_Text_PageShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PageShowText == null )
     			{
		    		this.m_E_Text_PageShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowPage/E_Text_PageShow");
     			}
     			return this.m_E_Text_PageShowText;
     		}
     	}

		public Button E_NextPageBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NextPageBtnButton == null )
     			{
		    		this.m_E_NextPageBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowPage/E_NextPageBtn");
     			}
     			return this.m_E_NextPageBtnButton;
     		}
     	}

		public Image E_NextPageBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NextPageBtnImage == null )
     			{
		    		this.m_E_NextPageBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowPage/E_NextPageBtn");
     			}
     			return this.m_E_NextPageBtnImage;
     		}
     	}

		public Button E_PrePageBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PrePageBtnButton == null )
     			{
		    		this.m_E_PrePageBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowPage/E_PrePageBtn");
     			}
     			return this.m_E_PrePageBtnButton;
     		}
     	}

		public Image E_PrePageBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PrePageBtnImage == null )
     			{
		    		this.m_E_PrePageBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowPage/E_PrePageBtn");
     			}
     			return this.m_E_PrePageBtnImage;
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
			this.m_E_PaiMaiBuyItemsLoopVerticalScrollRect = null;
			this.m_EG_ItemListNodeRectTransform = null;
			this.m_EG_TypeListNodeRectTransform = null;
			this.m_E_Btn_SearchButton = null;
			this.m_E_Btn_SearchImage = null;
			this.m_E_InputFieldInputField = null;
			this.m_E_InputFieldImage = null;
			this.m_EG_ShowPageRectTransform = null;
			this.m_E_Text_PageShowText = null;
			this.m_E_NextPageBtnButton = null;
			this.m_E_NextPageBtnImage = null;
			this.m_E_PrePageBtnButton = null;
			this.m_E_PrePageBtnImage = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_PaiMaiBuyItemsLoopVerticalScrollRect = null;
		private RectTransform m_EG_ItemListNodeRectTransform = null;
		private RectTransform m_EG_TypeListNodeRectTransform = null;
		private Button m_E_Btn_SearchButton = null;
		private Image m_E_Btn_SearchImage = null;
		private InputField m_E_InputFieldInputField = null;
		private Image m_E_InputFieldImage = null;
		private RectTransform m_EG_ShowPageRectTransform = null;
		private Text m_E_Text_PageShowText = null;
		private Button m_E_NextPageBtnButton = null;
		private Image m_E_NextPageBtnImage = null;
		private Button m_E_PrePageBtnButton = null;
		private Image m_E_PrePageBtnImage = null;
		public Transform uiTransform = null;
	}
}
