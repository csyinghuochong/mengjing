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
		
		public UnityEngine.RectTransform EG_TypeListNodeRectTransform
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
		    		this.m_EG_TypeListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/ScrollView2/Viewport/EG_TypeListNode");
     			}
     			return this.m_EG_TypeListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PaiMaiBuyItemsLoopVerticalScrollRect
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
		    		this.m_E_PaiMaiBuyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_PaiMaiBuyItems");
     			}
     			return this.m_E_PaiMaiBuyItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_SearchButton
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
		    		this.m_E_Btn_SearchButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Search");
     			}
     			return this.m_E_Btn_SearchButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_SearchImage
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
		    		this.m_E_Btn_SearchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Search");
     			}
     			return this.m_E_Btn_SearchImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputFieldInputField
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
		    		this.m_E_InputFieldInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Right/E_InputField");
     			}
     			return this.m_E_InputFieldInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldImage
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
		    		this.m_E_InputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_InputField");
     			}
     			return this.m_E_InputFieldImage;
     		}
     	}

		public UnityEngine.RectTransform EG_ShowPageRectTransform
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
		    		this.m_EG_ShowPageRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_ShowPage");
     			}
     			return this.m_EG_ShowPageRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PageShowText
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
		    		this.m_E_Text_PageShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_ShowPage/E_Text_PageShow");
     			}
     			return this.m_E_Text_PageShowText;
     		}
     	}

		public UnityEngine.UI.Button E_NextPageBtnButton
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
		    		this.m_E_NextPageBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_ShowPage/E_NextPageBtn");
     			}
     			return this.m_E_NextPageBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_NextPageBtnImage
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
		    		this.m_E_NextPageBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_ShowPage/E_NextPageBtn");
     			}
     			return this.m_E_NextPageBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_PrePageBtnButton
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
		    		this.m_E_PrePageBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_ShowPage/E_PrePageBtn");
     			}
     			return this.m_E_PrePageBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_PrePageBtnImage
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
		    		this.m_E_PrePageBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_ShowPage/E_PrePageBtn");
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
			this.m_EG_TypeListNodeRectTransform = null;
			this.m_E_PaiMaiBuyItemsLoopVerticalScrollRect = null;
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

		private UnityEngine.RectTransform m_EG_TypeListNodeRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PaiMaiBuyItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_SearchButton = null;
		private UnityEngine.UI.Image m_E_Btn_SearchImage = null;
		private UnityEngine.UI.InputField m_E_InputFieldInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldImage = null;
		private UnityEngine.RectTransform m_EG_ShowPageRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_PageShowText = null;
		private UnityEngine.UI.Button m_E_NextPageBtnButton = null;
		private UnityEngine.UI.Image m_E_NextPageBtnImage = null;
		private UnityEngine.UI.Button m_E_PrePageBtnButton = null;
		private UnityEngine.UI.Image m_E_PrePageBtnImage = null;
		public Transform uiTransform = null;
	}
}
