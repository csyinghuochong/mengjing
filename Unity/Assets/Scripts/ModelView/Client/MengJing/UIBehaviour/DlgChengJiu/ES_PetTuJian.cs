
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetTuJian : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public GameObject[] PetZiZhiItemList = new GameObject[6];
		public List<Scroll_Item_PetTuJianItem> uIPetTuJianItems = new List<Scroll_Item_PetTuJianItem>();

		public List<int> ShowSkill = new List<int>();
		public Dictionary<int, Scroll_Item_CommonSkillItem> ScrollItemCommonSkillItems;

		public List<int> ShowSkin = new List<int>();
		public Dictionary<int, Scroll_Item_PetSkinIconItem> ScrollItemPetSkinIconItems;
		
		public UnityEngine.UI.Text E_Text_PetNameText
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
		    		this.m_E_Text_PetNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image (2)/E_Text_PetName");
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
     			if( this.m_es_modelshow == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem1RectTransform
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
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem1");
     			}
     			return this.m_EG_PetZiZhiItem1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem2RectTransform
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
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem2");
     			}
     			return this.m_EG_PetZiZhiItem2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem3RectTransform
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
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem3");
     			}
     			return this.m_EG_PetZiZhiItem3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem4RectTransform
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
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem4");
     			}
     			return this.m_EG_PetZiZhiItem4RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem5RectTransform
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
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem5");
     			}
     			return this.m_EG_PetZiZhiItem5RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiItem6RectTransform
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
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetSinIconItemsLoopVerticalScrollRect
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
		    		this.m_E_PetSinIconItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"UIPetInfoShow/E_PetSinIconItems");
     			}
     			return this.m_E_PetSinIconItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_CommonSkillItemsLoopVerticalScrollRect
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
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"UIPetInfoShow/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Image_ItemButtonButton
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
		    		this.m_E_Image_ItemButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_ItemButton");
     			}
     			return this.m_E_Image_ItemButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_Image_ItemButtonImage
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
		    		this.m_E_Image_ItemButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_ItemButton");
     			}
     			return this.m_E_Image_ItemButtonImage;
     		}
     	}

		public UnityEngine.UI.Button E_Image_EventTriggerButton
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
		    		this.m_E_Image_EventTriggerButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_EventTrigger");
     			}
     			return this.m_E_Image_EventTriggerButton;
     		}
     	}

		public UnityEngine.UI.Image E_Image_EventTriggerImage
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
		    		this.m_E_Image_EventTriggerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_EventTrigger");
     			}
     			return this.m_E_Image_EventTriggerImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Image_EventTriggerEventTrigger
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
		    		this.m_E_Image_EventTriggerEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_EventTrigger");
     			}
     			return this.m_E_Image_EventTriggerEventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_Image_ItemQualityImage
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
		    		this.m_E_Image_ItemQualityImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_ItemQuality");
     			}
     			return this.m_E_Image_ItemQualityImage;
     		}
     	}

		public UnityEngine.UI.Image E_Image_ItemIconImage
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
		    		this.m_E_Image_ItemIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_ItemIcon");
     			}
     			return this.m_E_Image_ItemIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Label_ItemNumText
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
		    		this.m_E_Label_ItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Label_ItemNum");
     			}
     			return this.m_E_Label_ItemNumText;
     		}
     	}

		public UnityEngine.UI.Text E_Label_ItemNameText
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
		    		this.m_E_Label_ItemNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Label_ItemName");
     			}
     			return this.m_E_Label_ItemNameText;
     		}
     	}

		public UnityEngine.UI.Image E_Image_XuanZhongImage
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
		    		this.m_E_Image_XuanZhongImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"UIPetInfoShow/Item_PetTuJianItem/E_Image_XuanZhong");
     			}
     			return this.m_E_Image_XuanZhongImage;
     		}
     	}

		public UnityEngine.RectTransform EG_BuildingListRectTransform
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
		    		this.m_EG_BuildingListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/ScrollView_2/Viewport/EG_BuildingList");
     			}
     			return this.m_EG_BuildingListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_CommonPetListRectTransform
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
		    		this.m_EG_CommonPetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/ScrollView_2/Viewport/EG_BuildingList/EG_CommonPetList");
     			}
     			return this.m_EG_CommonPetListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_GodPetListRectTransform
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
		    		this.m_EG_GodPetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"UIPetInfoShow/ScrollView_2/Viewport/EG_BuildingList/EG_GodPetList");
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

		private UnityEngine.UI.Text m_E_Text_PetNameText = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetSinIconItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Image_ItemButtonButton = null;
		private UnityEngine.UI.Image m_E_Image_ItemButtonImage = null;
		private UnityEngine.UI.Button m_E_Image_EventTriggerButton = null;
		private UnityEngine.UI.Image m_E_Image_EventTriggerImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Image_EventTriggerEventTrigger = null;
		private UnityEngine.UI.Image m_E_Image_ItemQualityImage = null;
		private UnityEngine.UI.Image m_E_Image_ItemIconImage = null;
		private UnityEngine.UI.Text m_E_Label_ItemNumText = null;
		private UnityEngine.UI.Text m_E_Label_ItemNameText = null;
		private UnityEngine.UI.Image m_E_Image_XuanZhongImage = null;
		private UnityEngine.RectTransform m_EG_BuildingListRectTransform = null;
		private UnityEngine.RectTransform m_EG_CommonPetListRectTransform = null;
		private UnityEngine.RectTransform m_EG_GodPetListRectTransform = null;
		public Transform uiTransform = null;
	}
}
