using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_EquipmentIncreaseShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemEquipItems;
		public List<ItemInfo> ShowEquipBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemReelItems;
		public List<ItemInfo> ShowReelBagInfos { get; set; } = new();
		private EntityRef<ItemInfo> equipmentBagInfo;
		public ItemInfo EquipmentBagInfo { get => this.equipmentBagInfo; set => this.equipmentBagInfo = value; }
		private EntityRef<ItemInfo> reelBagInfo;
		public ItemInfo ReelBagInfo { get => this.equipmentBagInfo; set => this.equipmentBagInfo = value; }
		public int Page;
		
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

		public LoopVerticalScrollRect E_ReelItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReelItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ReelItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_ReelItems");
     			}
     			return this.m_E_ReelItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_IncreaseButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IncreaseButtonButton == null )
     			{
		    		this.m_E_IncreaseButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_IncreaseButton");
     			}
     			return this.m_E_IncreaseButtonButton;
     		}
     	}

		public Image E_IncreaseButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IncreaseButtonImage == null )
     			{
		    		this.m_E_IncreaseButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_IncreaseButton");
     			}
     			return this.m_E_IncreaseButtonImage;
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

		public RectTransform EG_IncreaseEffectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_IncreaseEffectRectTransform == null )
     			{
		    		this.m_EG_IncreaseEffectRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_IncreaseEffect");
     			}
     			return this.m_EG_IncreaseEffectRectTransform;
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
			this.m_E_EquipItemsLoopVerticalScrollRect = null;
			this.m_es_equipset = null;
			this.m_E_Obj_EquipPropertyTextText = null;
			this.m_EG_EquipBaseSetListRectTransform = null;
			this.m_es_commonitem = null;
			this.m_E_ReelItemsLoopVerticalScrollRect = null;
			this.m_E_IncreaseButtonButton = null;
			this.m_E_IncreaseButtonImage = null;
			this.m_E_Lab_NumText = null;
			this.m_EG_IncreaseEffectRectTransform = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private LoopVerticalScrollRect m_E_EquipItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_EquipSet> m_es_equipset = null;
		private Text m_E_Obj_EquipPropertyTextText = null;
		private RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private LoopVerticalScrollRect m_E_ReelItemsLoopVerticalScrollRect = null;
		private Button m_E_IncreaseButtonButton = null;
		private Image m_E_IncreaseButtonImage = null;
		private Text m_E_Lab_NumText = null;
		private RectTransform m_EG_IncreaseEffectRectTransform = null;
		public Transform uiTransform = null;
	}
}
