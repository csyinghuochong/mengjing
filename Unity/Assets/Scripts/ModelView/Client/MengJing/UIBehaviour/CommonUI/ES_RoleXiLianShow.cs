
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
		public BagInfo XilianBagInfo;
		public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
		public List<BagInfo> ShowBagInfos = new();
		
		public UnityEngine.UI.Button E_ImageButtonButton
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

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

		public UnityEngine.UI.Toggle E_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_1Toggle == null )
     			{
		    		this.m_E_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_ItemTypeSet/E_1");
     			}
     			return this.m_E_1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_2Toggle == null )
     			{
		    		this.m_E_2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_ItemTypeSet/E_2");
     			}
     			return this.m_E_2Toggle;
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

		public ES_EquipSet ES_EquipSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipset == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_EquipSet");
		    	   this.m_es_equipset = this.AddChild<ES_EquipSet,Transform>(subTrans);
     			}
     			return this.m_es_equipset;
     		}
     	}

		public UnityEngine.UI.Text E_Obj_EquipPropertyTextText
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
		    		this.m_E_Obj_EquipPropertyTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Obj_EquipPropertyText");
     			}
     			return this.m_E_Obj_EquipPropertyTextText;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipBaseSetListRectTransform
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
		    		this.m_EG_EquipBaseSetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_EquipBaseSetList");
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
     			if( this.m_es_commonitem == null )
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
     			if( this.m_es_commonitem_cost == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem_Cost");
		    	   this.m_es_commonitem_cost = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem_cost;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CostNameText
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
		    		this.m_E_Text_CostNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_CostName");
     			}
     			return this.m_E_Text_CostNameText;
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
		    		this.m_E_Text_CostValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_CostValue");
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
		    		this.m_E_XiLianButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_XiLianButton");
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
		    		this.m_E_XiLianButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonImage;
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
		    		this.m_E_XiLianTenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_XiLianTen");
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
		    		this.m_E_XiLianTenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_XiLianTen");
     			}
     			return this.m_E_XiLianTenImage;
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
		    		this.m_E_NeedDiamondText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_XiLianTen/E_NeedDiamond");
     			}
     			return this.m_E_NeedDiamondText;
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
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_1Toggle = null;
			this.m_E_2Toggle = null;
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

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_2Toggle = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_EquipItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_EquipSet> m_es_equipset = null;
		private UnityEngine.UI.Text m_E_Obj_EquipPropertyTextText = null;
		private UnityEngine.RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_cost = null;
		private UnityEngine.UI.Text m_E_Text_CostNameText = null;
		private UnityEngine.UI.Text m_E_Text_CostValueText = null;
		private UnityEngine.UI.Button m_E_XiLianButtonButton = null;
		private UnityEngine.UI.Image m_E_XiLianButtonImage = null;
		private UnityEngine.UI.Button m_E_XiLianTenButton = null;
		private UnityEngine.UI.Image m_E_XiLianTenImage = null;
		private UnityEngine.UI.Text m_E_NeedDiamondText = null;
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
