
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PaiMaiSell : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
		public List<BagInfo> ShowBagInfos = new();
		public Dictionary<int, Scroll_Item_PaiMaiSellItem> ScrollItemPaiMaiSellItems;
		public List<PaiMaiItemInfo> ShowPaiMaiItemInfos = new();
		public int CurrentItemType;

		public List<PaiMaiItemInfo> PaiMaiItemInfos = new();
		public long PaiMaiItemInfoId;
		public BagInfo BagInfo;
		public bool IsHoldDown;
		
		public UnityEngine.UI.ToggleGroup E_ItemTypeSetToggleGroup
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_ItemTypeAllSetToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeAllSetToggle == null )
     			{
		    		this.m_E_ItemTypeAllSetToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_ItemTypeSet/E_ItemTypeAllSet");
     			}
     			return this.m_E_ItemTypeAllSetToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_ItemTypeEquipSetToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeEquipSetToggle == null )
     			{
		    		this.m_E_ItemTypeEquipSetToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_ItemTypeSet/E_ItemTypeEquipSet");
     			}
     			return this.m_E_ItemTypeEquipSetToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_ItemTypeCostSetToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeCostSetToggle == null )
     			{
		    		this.m_E_ItemTypeCostSetToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_ItemTypeSet/E_ItemTypeCostSet");
     			}
     			return this.m_E_ItemTypeCostSetToggle;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PaiMaiSellItemsLoopVerticalScrollRect
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
		    		this.m_E_PaiMaiSellItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_PaiMaiSellItems");
     			}
     			return this.m_E_PaiMaiSellItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ShangJiaButton
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
		    		this.m_E_Btn_ShangJiaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_ShangJia");
     			}
     			return this.m_E_Btn_ShangJiaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ShangJiaImage
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
		    		this.m_E_Btn_ShangJiaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_ShangJia");
     			}
     			return this.m_E_Btn_ShangJiaImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiaJiaButton
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
		    		this.m_E_Btn_XiaJiaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_XiaJia");
     			}
     			return this.m_E_Btn_XiaJiaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiaJiaImage
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
		    		this.m_E_Btn_XiaJiaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_XiaJia");
     			}
     			return this.m_E_Btn_XiaJiaImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ShengYuTimeText
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
		    		this.m_E_Lab_ShengYuTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Lab_ShengYuTime");
     			}
     			return this.m_E_Lab_ShengYuTimeText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_SellTimeText
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
		    		this.m_E_Text_SellTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_SellTime");
     			}
     			return this.m_E_Text_SellTimeText;
     		}
     	}

		public UnityEngine.UI.Text E_PaiMaiGoldTextText
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
		    		this.m_E_PaiMaiGoldTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PaiMaiGoldText");
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
			this.m_E_ItemTypeAllSetToggle = null;
			this.m_E_ItemTypeEquipSetToggle = null;
			this.m_E_ItemTypeCostSetToggle = null;
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

		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_ItemTypeAllSetToggle = null;
		private UnityEngine.UI.Toggle m_E_ItemTypeEquipSetToggle = null;
		private UnityEngine.UI.Toggle m_E_ItemTypeCostSetToggle = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PaiMaiSellItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Btn_ShangJiaButton = null;
		private UnityEngine.UI.Image m_E_Btn_ShangJiaImage = null;
		private UnityEngine.UI.Button m_E_Btn_XiaJiaButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiaJiaImage = null;
		private UnityEngine.UI.Text m_E_Lab_ShengYuTimeText = null;
		private UnityEngine.UI.Text m_E_Text_SellTimeText = null;
		private UnityEngine.UI.Text m_E_PaiMaiGoldTextText = null;
		public Transform uiTransform = null;
	}
}
