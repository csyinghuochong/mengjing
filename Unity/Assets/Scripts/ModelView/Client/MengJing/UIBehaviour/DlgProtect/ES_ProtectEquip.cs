using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ProtectEquip : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		private EntityRef<ItemInfo> xilianBagInfo;
		public ItemInfo XilianBagInfo { get => this.xilianBagInfo; set => this.xilianBagInfo = value; }
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
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
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

		public Button E_ButtonUnLockButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonUnLockButton == null )
     			{
		    		this.m_E_ButtonUnLockButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_ButtonUnLock");
     			}
     			return this.m_E_ButtonUnLockButton;
     		}
     	}

		public Image E_ButtonUnLockImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonUnLockImage == null )
     			{
		    		this.m_E_ButtonUnLockImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_ButtonUnLock");
     			}
     			return this.m_E_ButtonUnLockImage;
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
			this.m_E_XiLianButtonButton = null;
			this.m_E_XiLianButtonImage = null;
			this.m_E_ButtonUnLockButton = null;
			this.m_E_ButtonUnLockImage = null;
			this.m_E_Lab_NumText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private Text m_E_Obj_EquipPropertyTextText = null;
		private RectTransform m_EG_EquipBaseSetListRectTransform = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Button m_E_XiLianButtonButton = null;
		private Image m_E_XiLianButtonImage = null;
		private Button m_E_ButtonUnLockButton = null;
		private Image m_E_ButtonUnLockImage = null;
		private Text m_E_Lab_NumText = null;
		public Transform uiTransform = null;
	}
}
