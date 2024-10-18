using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SeasonJingHe : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Sprite OldSprite;
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public int JingHeId;
		public List<SeasonJingHeConfig> ShowSeasonJingHeConfigs;
		public Dictionary<int, EntityRef<Scroll_Item_SeasonJingHeItem>> ScrollItemSeasonJingHeItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		
		public Button E_Btn_TianFu_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Button == null )
     			{
		    		this.m_E_Btn_TianFu_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Button;
     		}
     	}

		public Image E_Btn_TianFu_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_1Image == null )
     			{
		    		this.m_E_Btn_TianFu_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"TitleSet/E_Btn_TianFu_1");
     			}
     			return this.m_E_Btn_TianFu_1Image;
     		}
     	}

		public Button E_Btn_TianFu_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Button == null )
     			{
		    		this.m_E_Btn_TianFu_2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Button;
     		}
     	}

		public Image E_Btn_TianFu_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_TianFu_2Image == null )
     			{
		    		this.m_E_Btn_TianFu_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"TitleSet/E_Btn_TianFu_2");
     			}
     			return this.m_E_Btn_TianFu_2Image;
     		}
     	}

		public LoopVerticalScrollRect E_SeasonJingHeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonJingHeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SeasonJingHeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SeasonJingHeItems");
     			}
     			return this.m_E_SeasonJingHeItemsLoopVerticalScrollRect;
     		}
     	}

		public Image E_JingHeImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingHeImgImage == null )
     			{
		    		this.m_E_JingHeImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_JingHeImg");
     			}
     			return this.m_E_JingHeImgImage;
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

		public ES_CostItem ES_CostItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_CostItem es = this.m_es_costitem;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CostItem");
		    	   this.m_es_costitem = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem;
     		}
     	}

		public Button E_OpenBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenBtnButton == null )
     			{
		    		this.m_E_OpenBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_OpenBtn");
     			}
     			return this.m_E_OpenBtnButton;
     		}
     	}

		public Image E_OpenBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_OpenBtnImage == null )
     			{
		    		this.m_E_OpenBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_OpenBtn");
     			}
     			return this.m_E_OpenBtnImage;
     		}
     	}

		public Button E_EquipBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipBtnButton == null )
     			{
		    		this.m_E_EquipBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_EquipBtn");
     			}
     			return this.m_E_EquipBtnButton;
     		}
     	}

		public Image E_EquipBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipBtnImage == null )
     			{
		    		this.m_E_EquipBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EquipBtn");
     			}
     			return this.m_E_EquipBtnImage;
     		}
     	}

		public Text E_NameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameTextText == null )
     			{
		    		this.m_E_NameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     			return this.m_E_NameTextText;
     		}
     	}

		public Text E_DesTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DesTextText == null )
     			{
		    		this.m_E_DesTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_DesText");
     			}
     			return this.m_E_DesTextText;
     		}
     	}

		public Button E_TakeOffBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeOffBtnButton == null )
     			{
		    		this.m_E_TakeOffBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_TakeOffBtn");
     			}
     			return this.m_E_TakeOffBtnButton;
     		}
     	}

		public Image E_TakeOffBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TakeOffBtnImage == null )
     			{
		    		this.m_E_TakeOffBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_TakeOffBtn");
     			}
     			return this.m_E_TakeOffBtnImage;
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
			this.m_E_Btn_TianFu_1Button = null;
			this.m_E_Btn_TianFu_1Image = null;
			this.m_E_Btn_TianFu_2Button = null;
			this.m_E_Btn_TianFu_2Image = null;
			this.m_E_SeasonJingHeItemsLoopVerticalScrollRect = null;
			this.m_E_JingHeImgImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_es_costitem = null;
			this.m_E_OpenBtnButton = null;
			this.m_E_OpenBtnImage = null;
			this.m_E_EquipBtnButton = null;
			this.m_E_EquipBtnImage = null;
			this.m_E_NameTextText = null;
			this.m_E_DesTextText = null;
			this.m_E_TakeOffBtnButton = null;
			this.m_E_TakeOffBtnImage = null;
			this.uiTransform = null;
		}

		private Button m_E_Btn_TianFu_1Button = null;
		private Image m_E_Btn_TianFu_1Image = null;
		private Button m_E_Btn_TianFu_2Button = null;
		private Image m_E_Btn_TianFu_2Image = null;
		private LoopVerticalScrollRect m_E_SeasonJingHeItemsLoopVerticalScrollRect = null;
		private Image m_E_JingHeImgImage = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private EntityRef<ES_CostItem> m_es_costitem = null;
		private Button m_E_OpenBtnButton = null;
		private Image m_E_OpenBtnImage = null;
		private Button m_E_EquipBtnButton = null;
		private Image m_E_EquipBtnImage = null;
		private Text m_E_NameTextText = null;
		private Text m_E_DesTextText = null;
		private Button m_E_TakeOffBtnButton = null;
		private Image m_E_TakeOffBtnImage = null;
		public Transform uiTransform = null;
	}
}
