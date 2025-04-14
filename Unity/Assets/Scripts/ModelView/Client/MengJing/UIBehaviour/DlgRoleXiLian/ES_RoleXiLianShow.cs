
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianShow : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int CurrentItemType;
		public long BagInfoID;
		private EntityRef<ItemInfo> xilianBagInfo;

		public ItemInfo XilianBagInfo
		{
			get => this.xilianBagInfo;
			set
			{
				this.xilianBagInfo = value;
				this.BagInfoID = value == null ? 0 : value.BagInfoID;
			}
		}
		
		public Dictionary<long, (ItemInfo, long)> EquipCombatChangeDic { get; set; }= new();

		public Dictionary<int, EntityRef<Scroll_Item_XiLianShowEquipItem>> ScrollItemXiLianShowEquipItems = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public ETCancellationToken ETCancellationToken;
		public List<string> AssetList { get; set; } = new();
		
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_EquipItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipItemsImage == null )
     			{
		    		this.m_E_EquipItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_EquipItems");
     			}
     			return this.m_E_EquipItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_EquipItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_EquipItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_EquipItems");
     			}
     			return this.m_E_EquipItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_XiLianShowEquipItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianShowEquipItemsScrollRect == null )
     			{
		    		this.m_E_XiLianShowEquipItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Left/E_XiLianShowEquipItems");
     			}
     			return this.m_E_XiLianShowEquipItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_XiLianShowEquipItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianShowEquipItemsImage == null )
     			{
		    		this.m_E_XiLianShowEquipItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_XiLianShowEquipItems");
     			}
     			return this.m_E_XiLianShowEquipItemsImage;
     		}
     	}

		public UnityEngine.RectTransform EG_XiLianInfoRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_XiLianInfoRectTransform == null )
     			{
		    		this.m_EG_XiLianInfoRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_XiLianInfo");
     			}
     			return this.m_EG_XiLianInfoRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_XuanZhonItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_XuanZhonItemRectTransform == null )
     			{
		    		this.m_EG_XuanZhonItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/EG_XuanZhonItem");
     			}
     			return this.m_EG_XuanZhonItemRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_XuanZhonItemItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XuanZhonItemItemQualityImage == null )
     			{
		    		this.m_E_XuanZhonItemItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/EG_XuanZhonItem/E_XuanZhonItemItemQuality");
     			}
     			return this.m_E_XuanZhonItemItemQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_XuanZhonItemItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XuanZhonItemItemIconImage == null )
     			{
		    		this.m_E_XuanZhonItemItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/EG_XuanZhonItem/E_XuanZhonItemItemIcon");
     			}
     			return this.m_E_XuanZhonItemItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_XuanZhonItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XuanZhonItemNameText == null )
     			{
		    		this.m_E_XuanZhonItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/EG_XuanZhonItem/E_XuanZhonItemName");
     			}
     			return this.m_E_XuanZhonItemNameText;
     		}
     	}

		public UnityEngine.UI.Text E_BatAddText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BatAddText == null )
     			{
		    		this.m_E_BatAddText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/EG_XuanZhonItem/E_BatAdd");
     			}
     			return this.m_E_BatAddText;
     		}
     	}

		public UnityEngine.UI.Image E_CombatUpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CombatUpImage == null )
     			{
		    		this.m_E_CombatUpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/EG_XuanZhonItem/E_CombatUp");
     			}
     			return this.m_E_CombatUpImage;
     		}
     	}

		public UnityEngine.UI.Image E_CombatDownImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CombatDownImage == null )
     			{
		    		this.m_E_CombatDownImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/EG_XuanZhonItem/E_CombatDown");
     			}
     			return this.m_E_CombatDownImage;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_XiLianShowEquipPropertyItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianShowEquipPropertyItemsScrollRect == null )
     			{
		    		this.m_E_XiLianShowEquipPropertyItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_XiLianShowEquipPropertyItems");
     			}
     			return this.m_E_XiLianShowEquipPropertyItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_XiLianShowEquipPropertyItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianShowEquipPropertyItemsImage == null )
     			{
		    		this.m_E_XiLianShowEquipPropertyItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_XiLianShowEquipPropertyItems");
     			}
     			return this.m_E_XiLianShowEquipPropertyItemsImage;
     		}
     	}

		public UnityEngine.UI.Text E_NeedDiamondText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NeedDiamondText == null )
     			{
		    		this.m_E_NeedDiamondText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_NeedDiamond");
     			}
     			return this.m_E_NeedDiamondText;
     		}
     	}

		public UnityEngine.UI.Button E_XiLianTenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianTenButton == null )
     			{
		    		this.m_E_XiLianTenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_XiLianTen");
     			}
     			return this.m_E_XiLianTenButton;
     		}
     	}

		public UnityEngine.UI.Image E_XiLianTenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianTenImage == null )
     			{
		    		this.m_E_XiLianTenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_XiLianTen");
     			}
     			return this.m_E_XiLianTenImage;
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
		    		this.m_E_CostItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_CostItemIcon");
     			}
     			return this.m_E_CostItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CostValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CostValueText == null )
     			{
		    		this.m_E_Text_CostValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_Text_CostValue");
     			}
     			return this.m_E_Text_CostValueText;
     		}
     	}

		public UnityEngine.UI.Button E_XiLianButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianButtonButton == null )
     			{
		    		this.m_E_XiLianButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_XiLianButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianButtonImage == null )
     			{
		    		this.m_E_XiLianButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_XiLianInfo/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_NumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_NumText == null )
     			{
		    		this.m_E_Lab_NumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/Text_2 (1)/E_Lab_Num");
     			}
     			return this.m_E_Lab_NumText;
     		}
     	}

		public UnityEngine.RectTransform EG_XiLianEffectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_XiLianEffectRectTransform == null )
     			{
		    		this.m_EG_XiLianEffectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_XiLianEffect");
     			}
     			return this.m_EG_XiLianEffectRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_TotalNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TotalNumberText == null )
     			{
		    		this.m_E_Text_TotalNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_TotalNumber");
     			}
     			return this.m_E_Text_TotalNumberText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiLianNumRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianNumRewardButton == null )
     			{
		    		this.m_E_Btn_XiLianNumRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_XiLianNumReward");
     			}
     			return this.m_E_Btn_XiLianNumRewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiLianNumRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianNumRewardImage == null )
     			{
		    		this.m_E_Btn_XiLianNumRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_XiLianNumReward");
     			}
     			return this.m_E_Btn_XiLianNumRewardImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiLianExplainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianExplainButton == null )
     			{
		    		this.m_E_Btn_XiLianExplainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_XiLianExplain");
     			}
     			return this.m_E_Btn_XiLianExplainButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiLianExplainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiLianExplainImage == null )
     			{
		    		this.m_E_Btn_XiLianExplainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_XiLianExplain");
     			}
     			return this.m_E_Btn_XiLianExplainImage;
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
			this.m_E_EquipItemsImage = null;
			this.m_E_EquipItemsLoopVerticalScrollRect = null;
			this.m_E_XiLianShowEquipItemsScrollRect = null;
			this.m_E_XiLianShowEquipItemsImage = null;
			this.m_EG_XiLianInfoRectTransform = null;
			this.m_EG_XuanZhonItemRectTransform = null;
			this.m_E_XuanZhonItemItemQualityImage = null;
			this.m_E_XuanZhonItemItemIconImage = null;
			this.m_E_XuanZhonItemNameText = null;
			this.m_E_BatAddText = null;
			this.m_E_CombatUpImage = null;
			this.m_E_CombatDownImage = null;
			this.m_E_XiLianShowEquipPropertyItemsScrollRect = null;
			this.m_E_XiLianShowEquipPropertyItemsImage = null;
			this.m_E_NeedDiamondText = null;
			this.m_E_XiLianTenButton = null;
			this.m_E_XiLianTenImage = null;
			this.m_E_CostItemIconImage = null;
			this.m_E_Text_CostValueText = null;
			this.m_E_XiLianButtonButton = null;
			this.m_E_XiLianButtonImage = null;
			this.m_E_Lab_NumText = null;
			this.m_EG_XiLianEffectRectTransform = null;
			this.m_E_Text_TotalNumberText = null;
			this.m_E_Btn_XiLianNumRewardButton = null;
			this.m_E_Btn_XiLianNumRewardImage = null;
			this.m_E_Btn_XiLianExplainButton = null;
			this.m_E_Btn_XiLianExplainImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_EquipItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_EquipItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.ScrollRect m_E_XiLianShowEquipItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_XiLianShowEquipItemsImage = null;
		private UnityEngine.RectTransform m_EG_XiLianInfoRectTransform = null;
		private UnityEngine.RectTransform m_EG_XuanZhonItemRectTransform = null;
		private UnityEngine.UI.Image m_E_XuanZhonItemItemQualityImage = null;
		private UnityEngine.UI.Image m_E_XuanZhonItemItemIconImage = null;
		private UnityEngine.UI.Text m_E_XuanZhonItemNameText = null;
		private UnityEngine.UI.Text m_E_BatAddText = null;
		private UnityEngine.UI.Image m_E_CombatUpImage = null;
		private UnityEngine.UI.Image m_E_CombatDownImage = null;
		private UnityEngine.UI.ScrollRect m_E_XiLianShowEquipPropertyItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_XiLianShowEquipPropertyItemsImage = null;
		private UnityEngine.UI.Text m_E_NeedDiamondText = null;
		private UnityEngine.UI.Button m_E_XiLianTenButton = null;
		private UnityEngine.UI.Image m_E_XiLianTenImage = null;
		private UnityEngine.UI.Image m_E_CostItemIconImage = null;
		private UnityEngine.UI.Text m_E_Text_CostValueText = null;
		private UnityEngine.UI.Button m_E_XiLianButtonButton = null;
		private UnityEngine.UI.Image m_E_XiLianButtonImage = null;
		private UnityEngine.UI.Text m_E_Lab_NumText = null;
		private UnityEngine.RectTransform m_EG_XiLianEffectRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_TotalNumberText = null;
		private UnityEngine.UI.Button m_E_Btn_XiLianNumRewardButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiLianNumRewardImage = null;
		private UnityEngine.UI.Button m_E_Btn_XiLianExplainButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiLianExplainImage = null;
		public Transform uiTransform = null;
	}
}
