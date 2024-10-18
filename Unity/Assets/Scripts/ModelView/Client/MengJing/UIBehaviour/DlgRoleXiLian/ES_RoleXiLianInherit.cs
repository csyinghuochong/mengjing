using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RoleXiLianInherit : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		private EntityRef<ItemInfo> xilianBagInfo;
		public ItemInfo XilianBagInfo { get => this.xilianBagInfo; set => this.xilianBagInfo = value; }
		public ETCancellationToken ETCancellationToken;
		public List<int> InheritSkills = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		
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
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
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
     			if( es ==null )
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
     			if( es ==null)
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

		public Image E_ProgressBarImgImage
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
		    		this.m_E_ProgressBarImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ProgressBarImg");
     			}
     			return this.m_E_ProgressBarImgImage;
     		}
     	}

		public Text E_InheritTimesTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InheritTimesTextText == null )
     			{
		    		this.m_E_InheritTimesTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_InheritTimesText");
     			}
     			return this.m_E_InheritTimesTextText;
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
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_Obj_EquipPropertyTextText = null;
			this.m_EG_EquipBaseSetListRectTransform = null;
			this.m_es_commonitem = null;
			this.m_es_commonitem_cost = null;
			this.m_E_Text_CostNameText = null;
			this.m_E_Text_CostValueText = null;
			this.m_E_XiLianButtonButton = null;
			this.m_E_XiLianButtonImage = null;
			this.m_EG_XiLianEffectRectTransform = null;
			this.m_E_Lab_NumText = null;
			this.m_E_ProgressBarImgImage = null;
			this.m_E_InheritTimesTextText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private Text m_E_Obj_EquipPropertyTextText = null;
		private RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_CommonItem> m_es_commonitem_cost = null;
		private Text m_E_Text_CostNameText = null;
		private Text m_E_Text_CostValueText = null;
		private Button m_E_XiLianButtonButton = null;
		private Image m_E_XiLianButtonImage = null;
		private RectTransform m_EG_XiLianEffectRectTransform = null;
		private Text m_E_Lab_NumText = null;
		private Image m_E_ProgressBarImgImage = null;
		private Text m_E_InheritTimesTextText = null;
		public Transform uiTransform = null;
	}
}
