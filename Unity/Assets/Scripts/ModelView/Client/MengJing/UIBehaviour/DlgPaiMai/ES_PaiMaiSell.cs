using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PaiMaiSell : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_PaiMaiSellItem>> ScrollItemPaiMaiSellItems;
		public List<PaiMaiItemInfo> ShowPaiMaiItemInfos = new();
		public int CurrentItemType;

		public List<PaiMaiItemInfo> PaiMaiItemInfos = new();
		public long PaiMaiItemInfoId;
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public bool IsHoldDown;

		public ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public LoopVerticalScrollRect E_PaiMaiSellItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PaiMaiSellItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PaiMaiSellItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PaiMaiSellItems");
     			}
     			return this.m_E_PaiMaiSellItemsLoopVerticalScrollRect;
     		}
     	}

		public LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Btn_ShangJiaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShangJiaButton == null )
     			{
		    		this.m_E_Btn_ShangJiaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ShangJia");
     			}
     			return this.m_E_Btn_ShangJiaButton;
     		}
     	}

		public Image E_Btn_ShangJiaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ShangJiaImage == null )
     			{
		    		this.m_E_Btn_ShangJiaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ShangJia");
     			}
     			return this.m_E_Btn_ShangJiaImage;
     		}
     	}

		public Button E_Btn_XiaJiaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiaJiaButton == null )
     			{
		    		this.m_E_Btn_XiaJiaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_XiaJia");
     			}
     			return this.m_E_Btn_XiaJiaButton;
     		}
     	}

		public Image E_Btn_XiaJiaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiaJiaImage == null )
     			{
		    		this.m_E_Btn_XiaJiaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_XiaJia");
     			}
     			return this.m_E_Btn_XiaJiaImage;
     		}
     	}

		public Text E_Lab_ShengYuTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ShengYuTimeText == null )
     			{
		    		this.m_E_Lab_ShengYuTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Lab_ShengYuTime");
     			}
     			return this.m_E_Lab_ShengYuTimeText;
     		}
     	}

		public Text E_Text_SellTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_SellTimeText == null )
     			{
		    		this.m_E_Text_SellTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_SellTime");
     			}
     			return this.m_E_Text_SellTimeText;
     		}
     	}

		public Text E_PaiMaiGoldTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PaiMaiGoldTextText == null )
     			{
		    		this.m_E_PaiMaiGoldTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_PaiMaiGoldText");
     			}
     			return this.m_E_PaiMaiGoldTextText;
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
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_PaiMaiSellItemsLoopVerticalScrollRect = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_Btn_ShangJiaButton = null;
			this.m_E_Btn_ShangJiaImage = null;
			this.m_E_Btn_XiaJiaButton = null;
			this.m_E_Btn_XiaJiaImage = null;
			this.m_E_Lab_ShengYuTimeText = null;
			this.m_E_Text_SellTimeText = null;
			this.m_E_PaiMaiGoldTextText = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private LoopVerticalScrollRect m_E_PaiMaiSellItemsLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private Button m_E_Btn_ShangJiaButton = null;
		private Image m_E_Btn_ShangJiaImage = null;
		private Button m_E_Btn_XiaJiaButton = null;
		private Image m_E_Btn_XiaJiaImage = null;
		private Text m_E_Lab_ShengYuTimeText = null;
		private Text m_E_Text_SellTimeText = null;
		private Text m_E_PaiMaiGoldTextText = null;
		public Transform uiTransform = null;
	}
}
