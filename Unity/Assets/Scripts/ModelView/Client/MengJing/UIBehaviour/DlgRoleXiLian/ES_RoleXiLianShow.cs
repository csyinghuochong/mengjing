using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int CurrentItemType;
		public ItemInfo XilianBagInfo { get; set; }
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public ETCancellationToken ETCancellationToken;

		public Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"Left/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public LoopVerticalScrollRect E_EquipItemsLoopVerticalScrollRect
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
		    		this.m_E_EquipItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_EquipItems");
     			}
     			return this.m_E_EquipItemsLoopVerticalScrollRect;
     		}
     	}

		public ES_EquipSet ES_EquipSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_EquipSet es = this.m_es_equipset;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_EquipSet");
		    	   this.m_es_equipset = this.AddChild<ES_EquipSet,Transform>(subTrans);
     			}
     			return this.m_es_equipset;
     		}
     	}

		public Text E_Obj_EquipPropertyTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Obj_EquipPropertyTextText == null )
     			{
		    		this.m_E_Obj_EquipPropertyTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Obj_EquipPropertyText");
     			}
     			return this.m_E_Obj_EquipPropertyTextText;
     		}
     	}

		public RectTransform EG_EquipBaseSetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipBaseSetListRectTransform == null )
     			{
		    		this.m_EG_EquipBaseSetListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_EquipBaseSetList");
     			}
     			return this.m_EG_EquipBaseSetListRectTransform;
     		}
     	}

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public ES_CommonItem ES_CommonItem_Cost
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_CommonItem es = this.m_es_commonitem_cost;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem_Cost");
		    	   this.m_es_commonitem_cost = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_cost;
     		}
     	}

		public Text E_Text_CostNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CostNameText == null )
     			{
		    		this.m_E_Text_CostNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_CostName");
     			}
     			return this.m_E_Text_CostNameText;
     		}
     	}

		public Text E_Text_CostValueText
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
		    		this.m_E_Text_CostValueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_CostValue");
     			}
     			return this.m_E_Text_CostValueText;
     		}
     	}

		public Button E_XiLianButtonButton
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
		    		this.m_E_XiLianButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonButton;
     		}
     	}

		public Image E_XiLianButtonImage
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
		    		this.m_E_XiLianButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonImage;
     		}
     	}

		public Button E_XiLianTenButton
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
		    		this.m_E_XiLianTenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_XiLianTen");
     			}
     			return this.m_E_XiLianTenButton;
     		}
     	}

		public Image E_XiLianTenImage
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
		    		this.m_E_XiLianTenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_XiLianTen");
     			}
     			return this.m_E_XiLianTenImage;
     		}
     	}

		public Text E_NeedDiamondText
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
		    		this.m_E_NeedDiamondText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_XiLianTen/E_NeedDiamond");
     			}
     			return this.m_E_NeedDiamondText;
     		}
     	}

		public Text E_Lab_NumText
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
		    		this.m_E_Lab_NumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/Text_2 (1)/E_Lab_Num");
     			}
     			return this.m_E_Lab_NumText;
     		}
     	}

		public RectTransform EG_XiLianEffectRectTransform
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
		    		this.m_EG_XiLianEffectRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_XiLianEffect");
     			}
     			return this.m_EG_XiLianEffectRectTransform;
     		}
     	}

		public Text E_Text_TotalNumberText
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
		    		this.m_E_Text_TotalNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_TotalNumber");
     			}
     			return this.m_E_Text_TotalNumberText;
     		}
     	}

		public Button E_Btn_XiLianNumRewardButton
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
		    		this.m_E_Btn_XiLianNumRewardButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Btn_XiLianNumReward");
     			}
     			return this.m_E_Btn_XiLianNumRewardButton;
     		}
     	}

		public Image E_Btn_XiLianNumRewardImage
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
		    		this.m_E_Btn_XiLianNumRewardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Btn_XiLianNumReward");
     			}
     			return this.m_E_Btn_XiLianNumRewardImage;
     		}
     	}

		public Button E_Btn_XiLianExplainButton
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
		    		this.m_E_Btn_XiLianExplainButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Btn_XiLianExplain");
     			}
     			return this.m_E_Btn_XiLianExplainButton;
     		}
     	}

		public Image E_Btn_XiLianExplainImage
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
		    		this.m_E_Btn_XiLianExplainImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Btn_XiLianExplain");
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
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_EquipItemsLoopVerticalScrollRect = null;
			this.m_es_equipset = null;
			this.m_E_Obj_EquipPropertyTextText = null;
			this.m_EG_EquipBaseSetListRectTransform = null;
			this.m_es_commonitem = null;
			this.m_es_commonitem_cost = null;
			this.m_E_Text_CostNameText = null;
			this.m_E_Text_CostValueText = null;
			this.m_E_XiLianButtonButton = null;
			this.m_E_XiLianButtonImage = null;
			this.m_E_XiLianTenButton = null;
			this.m_E_XiLianTenImage = null;
			this.m_E_NeedDiamondText = null;
			this.m_E_Lab_NumText = null;
			this.m_EG_XiLianEffectRectTransform = null;
			this.m_E_Text_TotalNumberText = null;
			this.m_E_Btn_XiLianNumRewardButton = null;
			this.m_E_Btn_XiLianNumRewardImage = null;
			this.m_E_Btn_XiLianExplainButton = null;
			this.m_E_Btn_XiLianExplainImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private LoopVerticalScrollRect m_E_EquipItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_EquipSet> m_es_equipset = null;
		private Text m_E_Obj_EquipPropertyTextText = null;
		private RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_cost = null;
		private Text m_E_Text_CostNameText = null;
		private Text m_E_Text_CostValueText = null;
		private Button m_E_XiLianButtonButton = null;
		private Image m_E_XiLianButtonImage = null;
		private Button m_E_XiLianTenButton = null;
		private Image m_E_XiLianTenImage = null;
		private Text m_E_NeedDiamondText = null;
		private Text m_E_Lab_NumText = null;
		private RectTransform m_EG_XiLianEffectRectTransform = null;
		private Text m_E_Text_TotalNumberText = null;
		private Button m_E_Btn_XiLianNumRewardButton = null;
		private Image m_E_Btn_XiLianNumRewardImage = null;
		private Button m_E_Btn_XiLianExplainButton = null;
		private Image m_E_Btn_XiLianExplainImage = null;
		public Transform uiTransform = null;
	}
}
