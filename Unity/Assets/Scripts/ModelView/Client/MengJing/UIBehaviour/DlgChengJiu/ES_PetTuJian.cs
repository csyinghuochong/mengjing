using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetTuJian : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public GameObject[] PetZiZhiItemList = new GameObject[6];
		public List<EntityRef<Scroll_Item_PetTuJianItem>> uIPetTuJianItems = new();

		public List<int> ShowSkill = new List<int>();
		public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;

		public List<int> ShowSkin = new List<int>();
		public Dictionary<int, EntityRef<Scroll_Item_PetSkinIconItem>> ScrollItemPetSkinIconItems;
		
		public Text E_Text_PetNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetNameText == null )
     			{
		    		this.m_E_Text_PetNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Image (2)/E_Text_PetName");
     			}
     			return this.m_E_Text_PetNameText;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ModelShow es = this.m_es_modelshow;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public RectTransform EG_PetZiZhiItem1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem1RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem1");
     			}
     			return this.m_EG_PetZiZhiItem1RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem2RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem2");
     			}
     			return this.m_EG_PetZiZhiItem2RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem3RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem3");
     			}
     			return this.m_EG_PetZiZhiItem3RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem4RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem4");
     			}
     			return this.m_EG_PetZiZhiItem4RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem5RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem5");
     			}
     			return this.m_EG_PetZiZhiItem5RectTransform;
     		}
     	}

		public RectTransform EG_PetZiZhiItem6RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiItem6RectTransform == null )
     			{
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_PetSinIconItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetSinIconItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetSinIconItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"UIPetInfoShow/E_PetSinIconItems");
     			}
     			return this.m_E_PetSinIconItemsLoopVerticalScrollRect;
     		}
     	}

		public LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CommonSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"UIPetInfoShow/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_Image_ItemButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_ItemButtonButton == null )
     			{
		    		this.m_E_Image_ItemButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_ItemButton");
     			}
     			return this.m_E_Image_ItemButtonButton;
     		}
     	}

		public Image E_Image_ItemButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_ItemButtonImage == null )
     			{
		    		this.m_E_Image_ItemButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_ItemButton");
     			}
     			return this.m_E_Image_ItemButtonImage;
     		}
     	}

		public Button E_Image_EventTriggerButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_EventTriggerButton == null )
     			{
		    		this.m_E_Image_EventTriggerButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_EventTrigger");
     			}
     			return this.m_E_Image_EventTriggerButton;
     		}
     	}

		public Image E_Image_EventTriggerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_EventTriggerImage == null )
     			{
		    		this.m_E_Image_EventTriggerImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_EventTrigger");
     			}
     			return this.m_E_Image_EventTriggerImage;
     		}
     	}

		public EventTrigger E_Image_EventTriggerEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_EventTriggerEventTrigger == null )
     			{
		    		this.m_E_Image_EventTriggerEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_EventTrigger");
     			}
     			return this.m_E_Image_EventTriggerEventTrigger;
     		}
     	}

		public Image E_Image_ItemQualityImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_ItemQualityImage == null )
     			{
		    		this.m_E_Image_ItemQualityImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_ItemQuality");
     			}
     			return this.m_E_Image_ItemQualityImage;
     		}
     	}

		public Image E_Image_ItemIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_ItemIconImage == null )
     			{
		    		this.m_E_Image_ItemIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_ItemIcon");
     			}
     			return this.m_E_Image_ItemIconImage;
     		}
     	}

		public Text E_Label_ItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Label_ItemNumText == null )
     			{
		    		this.m_E_Label_ItemNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Label_ItemNum");
     			}
     			return this.m_E_Label_ItemNumText;
     		}
     	}

		public Text E_Label_ItemNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Label_ItemNameText == null )
     			{
		    		this.m_E_Label_ItemNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Label_ItemName");
     			}
     			return this.m_E_Label_ItemNameText;
     		}
     	}

		public Image E_Image_XuanZhongImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_XuanZhongImage == null )
     			{
		    		this.m_E_Image_XuanZhongImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_XuanZhong");
     			}
     			return this.m_E_Image_XuanZhongImage;
     		}
     	}

		public RectTransform EG_BuildingListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BuildingListRectTransform == null )
     			{
		    		this.m_EG_BuildingListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/ScrollView_2/Viewport/EG_BuildingList");
     			}
     			return this.m_EG_BuildingListRectTransform;
     		}
     	}

		public RectTransform EG_CommonPetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_CommonPetListRectTransform == null )
     			{
		    		this.m_EG_CommonPetListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/ScrollView_2/Viewport/EG_BuildingList/EG_CommonPetList");
     			}
     			return this.m_EG_CommonPetListRectTransform;
     		}
     	}

		public RectTransform EG_GodPetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_GodPetListRectTransform == null )
     			{
		    		this.m_EG_GodPetListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/ScrollView_2/Viewport/EG_BuildingList/EG_GodPetList");
     			}
     			return this.m_EG_GodPetListRectTransform;
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
			this.m_E_Text_PetNameText = null;
			this.m_es_modelshow = null;
			this.m_EG_PetZiZhiItem1RectTransform = null;
			this.m_EG_PetZiZhiItem2RectTransform = null;
			this.m_EG_PetZiZhiItem3RectTransform = null;
			this.m_EG_PetZiZhiItem4RectTransform = null;
			this.m_EG_PetZiZhiItem5RectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_E_PetSinIconItemsLoopVerticalScrollRect = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_E_Image_ItemButtonButton = null;
			this.m_E_Image_ItemButtonImage = null;
			this.m_E_Image_EventTriggerButton = null;
			this.m_E_Image_EventTriggerImage = null;
			this.m_E_Image_EventTriggerEventTrigger = null;
			this.m_E_Image_ItemQualityImage = null;
			this.m_E_Image_ItemIconImage = null;
			this.m_E_Label_ItemNumText = null;
			this.m_E_Label_ItemNameText = null;
			this.m_E_Image_XuanZhongImage = null;
			this.m_EG_BuildingListRectTransform = null;
			this.m_EG_CommonPetListRectTransform = null;
			this.m_EG_GodPetListRectTransform = null;
			this.uiTransform = null;
		}

		private Text m_E_Text_PetNameText = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private LoopVerticalScrollRect m_E_PetSinIconItemsLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private Button m_E_Image_ItemButtonButton = null;
		private Image m_E_Image_ItemButtonImage = null;
		private Button m_E_Image_EventTriggerButton = null;
		private Image m_E_Image_EventTriggerImage = null;
		private EventTrigger m_E_Image_EventTriggerEventTrigger = null;
		private Image m_E_Image_ItemQualityImage = null;
		private Image m_E_Image_ItemIconImage = null;
		private Text m_E_Label_ItemNumText = null;
		private Text m_E_Label_ItemNameText = null;
		private Image m_E_Image_XuanZhongImage = null;
		private RectTransform m_EG_BuildingListRectTransform = null;
		private RectTransform m_EG_CommonPetListRectTransform = null;
		private RectTransform m_EG_GodPetListRectTransform = null;
		public Transform uiTransform = null;
	}
}
