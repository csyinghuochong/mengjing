using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_WatchPet : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public GameObject[] PetHeXinItemList;
		public GameObject[] PetZiZhiItemList = new GameObject[6];
		public long ClickTime;
		public bool IsChange;
		public int PetHeXinSuit;
		public int PetSkinId;
		public RolePetInfo LastSelectItem;
		public Dictionary<int, EntityRef<Scroll_Item_PetListItem>> ScrollItemPetListItems;
		public List<RolePetInfo> ShowRolePetInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_PetSkinIconItem>> ScrollItemPetSkinIconItems;
		public int[] ShowPetSkins;
		public Dictionary<int, EntityRef<Scroll_Item_CommonSkillItem>> ScrollItemCommonSkillItems;
		public List<int> ShowPetSkills = new();
		public int UnactiveId;
		public int UnactiveNum;
		
		public int Position;
		public int Type;
		private EntityRef<ItemInfo> bagInfo;
		public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
		public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
		public List<ItemInfo> ShowBagInfos { get; set; } = new();
		
		public bool IsHoldDown;
		public List<int> PointList = new();
		public List<int> PointInit = new();
		public int PointRemain = 0;
		
		public RectTransform EG_MaskRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MaskRectTransform == null )
     			{
		    		this.m_EG_MaskRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Mask");
     			}
     			return this.m_EG_MaskRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_PetListItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetListItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_PetListItems");
     			}
     			return this.m_E_PetListItemsLoopVerticalScrollRect;
     		}
     	}

		public RectTransform EG_RightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightRectTransform == null )
     			{
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
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
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_Right/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public RectTransform EG_ImagePetStarRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ImagePetStarRectTransform == null )
     			{
		    		this.m_EG_ImagePetStarRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_ImagePetStar");
     			}
     			return this.m_EG_ImagePetStarRectTransform;
     		}
     	}

		public Button E_ButtonRNameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRNameButton == null )
     			{
		    		this.m_E_ButtonRNameButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/E_ButtonRName");
     			}
     			return this.m_E_ButtonRNameButton;
     		}
     	}

		public Image E_ButtonRNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonRNameImage == null )
     			{
		    		this.m_E_ButtonRNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_ButtonRName");
     			}
     			return this.m_E_ButtonRNameImage;
     		}
     	}

		public Image E_PetHeXinItem0Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinItem0Image == null )
     			{
		    		this.m_E_PetHeXinItem0Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_PetHeXinItem0");
     			}
     			return this.m_E_PetHeXinItem0Image;
     		}
     	}

		public Image E_PetHeXinItem1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinItem1Image == null )
     			{
		    		this.m_E_PetHeXinItem1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_PetHeXinItem1");
     			}
     			return this.m_E_PetHeXinItem1Image;
     		}
     	}

		public Image E_PetHeXinItem2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinItem2Image == null )
     			{
		    		this.m_E_PetHeXinItem2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_PetHeXinItem2");
     			}
     			return this.m_E_PetHeXinItem2Image;
     		}
     	}

		public InputField E_InputFieldNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldNameInputField == null )
     			{
		    		this.m_E_InputFieldNameInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"EG_Right/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameInputField;
     		}
     	}

		public Image E_InputFieldNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldNameImage == null )
     			{
		    		this.m_E_InputFieldNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameImage;
     		}
     	}

		public Button E_ButtonAddPointButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonAddPointButton == null )
     			{
		    		this.m_E_ButtonAddPointButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/E_ButtonAddPoint");
     			}
     			return this.m_E_ButtonAddPointButton;
     		}
     	}

		public Image E_ButtonAddPointImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonAddPointImage == null )
     			{
		    		this.m_E_ButtonAddPointImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_ButtonAddPoint");
     			}
     			return this.m_E_ButtonAddPointImage;
     		}
     	}

		public RectTransform EG_ButtonNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ButtonNodeRectTransform == null )
     			{
		    		this.m_EG_ButtonNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode");
     			}
     			return this.m_EG_ButtonNodeRectTransform;
     		}
     	}

		public Button E_Btn_ChuZhanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChuZhanButton == null )
     			{
		    		this.m_E_Btn_ChuZhanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_ChuZhan");
     			}
     			return this.m_E_Btn_ChuZhanButton;
     		}
     	}

		public Image E_Btn_ChuZhanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChuZhanImage == null )
     			{
		    		this.m_E_Btn_ChuZhanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_ChuZhan");
     			}
     			return this.m_E_Btn_ChuZhanImage;
     		}
     	}

		public Button E_Btn_XiuXiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiuXiButton == null )
     			{
		    		this.m_E_Btn_XiuXiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_XiuXi");
     			}
     			return this.m_E_Btn_XiuXiButton;
     		}
     	}

		public Image E_Btn_XiuXiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_XiuXiImage == null )
     			{
		    		this.m_E_Btn_XiuXiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_XiuXi");
     			}
     			return this.m_E_Btn_XiuXiImage;
     		}
     	}

		public Button E_Btn_FangShengButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_FangShengButton == null )
     			{
		    		this.m_E_Btn_FangShengButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_FangSheng");
     			}
     			return this.m_E_Btn_FangShengButton;
     		}
     	}

		public Image E_Btn_FangShengImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_FangShengImage == null )
     			{
		    		this.m_E_Btn_FangShengImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_FangSheng");
     			}
     			return this.m_E_Btn_FangShengImage;
     		}
     	}

		public RectTransform EG_AttributeNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AttributeNodeRectTransform == null )
     			{
		    		this.m_EG_AttributeNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode");
     			}
     			return this.m_EG_AttributeNodeRectTransform;
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public RectTransform EG_PetZiZhiSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetZiZhiSetRectTransform == null )
     			{
		    		this.m_EG_PetZiZhiSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet");
     			}
     			return this.m_EG_PetZiZhiSetRectTransform;
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
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem1");
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
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem2");
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
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem3");
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
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem4");
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
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem5");
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
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
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
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public RectTransform EG_PetPiFuSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetPiFuSetRectTransform == null )
     			{
		    		this.m_EG_PetPiFuSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet");
     			}
     			return this.m_EG_PetPiFuSetRectTransform;
     		}
     	}

		public Button E_PetSkinRawImageButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetSkinRawImageButton == null )
     			{
		    		this.m_E_PetSkinRawImageButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PetSkinRawImage");
     			}
     			return this.m_E_PetSkinRawImageButton;
     		}
     	}

		public RawImage E_PetSkinRawImageRawImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetSkinRawImageRawImage == null )
     			{
		    		this.m_E_PetSkinRawImageRawImage = UIFindHelper.FindDeepChild<RawImage>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PetSkinRawImage");
     			}
     			return this.m_E_PetSkinRawImageRawImage;
     		}
     	}

		public EventTrigger E_PetSkinRawImageEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetSkinRawImageEventTrigger == null )
     			{
		    		this.m_E_PetSkinRawImageEventTrigger = UIFindHelper.FindDeepChild<EventTrigger>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PetSkinRawImage");
     			}
     			return this.m_E_PetSkinRawImageEventTrigger;
     		}
     	}

		public LoopVerticalScrollRect E_PetSkinIconItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetSkinIconItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetSkinIconItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PetSkinIconItems");
     			}
     			return this.m_E_PetSkinIconItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonUseSkinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonUseSkinButton == null )
     			{
		    		this.m_E_ButtonUseSkinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_ButtonUseSkin");
     			}
     			return this.m_E_ButtonUseSkinButton;
     		}
     	}

		public Image E_ButtonUseSkinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonUseSkinImage == null )
     			{
		    		this.m_E_ButtonUseSkinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_ButtonUseSkin");
     			}
     			return this.m_E_ButtonUseSkinImage;
     		}
     	}

		public Text E_PropertyShowTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PropertyShowTextText == null )
     			{
		    		this.m_E_PropertyShowTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PropertyShowText");
     			}
     			return this.m_E_PropertyShowTextText;
     		}
     	}

		public Image E_SkinJiHuoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkinJiHuoImage == null )
     			{
		    		this.m_E_SkinJiHuoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_SkinJiHuo");
     			}
     			return this.m_E_SkinJiHuoImage;
     		}
     	}

		public Image E_SkinWeiJiHuoImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkinWeiJiHuoImage == null )
     			{
		    		this.m_E_SkinWeiJiHuoImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_SkinWeiJiHuo");
     			}
     			return this.m_E_SkinWeiJiHuoImage;
     		}
     	}

		public Image E_PetProSetNodeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetProSetNodeImage == null )
     			{
		    		this.m_E_PetProSetNodeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode");
     			}
     			return this.m_E_PetProSetNodeImage;
     		}
     	}

		public RectTransform EG_PetProSetItem_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetProSetItem_1RectTransform == null )
     			{
		    		this.m_EG_PetProSetItem_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetItem_1");
     			}
     			return this.m_EG_PetProSetItem_1RectTransform;
     		}
     	}

		public RectTransform EG_PetProSetItem_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetProSetItem_2RectTransform == null )
     			{
		    		this.m_EG_PetProSetItem_2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetItem_2");
     			}
     			return this.m_EG_PetProSetItem_2RectTransform;
     		}
     	}

		public Image E_PetProSetNode_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetProSetNode_1Image == null )
     			{
		    		this.m_E_PetProSetNode_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode/E_PetProSetNode_1");
     			}
     			return this.m_E_PetProSetNode_1Image;
     		}
     	}

		public Image E_PetProSetNode_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetProSetNode_2Image == null )
     			{
		    		this.m_E_PetProSetNode_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode/E_PetProSetNode_2");
     			}
     			return this.m_E_PetProSetNode_2Image;
     		}
     	}

		public RectTransform EG_PetHeXinSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetHeXinSetRectTransform == null )
     			{
		    		this.m_EG_PetHeXinSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet");
     			}
     			return this.m_EG_PetHeXinSetRectTransform;
     		}
     	}

		public Image E_ImageIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageIconImage == null )
     			{
		    		this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ImageIcon");
     			}
     			return this.m_E_ImageIconImage;
     		}
     	}

		public Text E_TextNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextNameText == null )
     			{
		    		this.m_E_TextNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_TextName");
     			}
     			return this.m_E_TextNameText;
     		}
     	}

		public Text E_TextLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextLevelText == null )
     			{
		    		this.m_E_TextLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_TextLevel");
     			}
     			return this.m_E_TextLevelText;
     		}
     	}

		public RectTransform EG_TextAttributeItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_TextAttributeItemRectTransform == null )
     			{
		    		this.m_EG_TextAttributeItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/EG_TextAttributeItem");
     			}
     			return this.m_EG_TextAttributeItemRectTransform;
     		}
     	}

		public RectTransform EG_AttributeListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AttributeListNodeRectTransform == null )
     			{
		    		this.m_EG_AttributeListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/EG_AttributeListNode");
     			}
     			return this.m_EG_AttributeListNodeRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_PetHeXinListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinListLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetHeXinListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_PetHeXinList");
     			}
     			return this.m_E_PetHeXinListLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonEquipHeXinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEquipHeXinButton == null )
     			{
		    		this.m_E_ButtonEquipHeXinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonEquipHeXin");
     			}
     			return this.m_E_ButtonEquipHeXinButton;
     		}
     	}

		public Image E_ButtonEquipHeXinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEquipHeXinImage == null )
     			{
		    		this.m_E_ButtonEquipHeXinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonEquipHeXin");
     			}
     			return this.m_E_ButtonEquipHeXinImage;
     		}
     	}

		public Button E_ButtonCloseHexinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseHexinButton == null )
     			{
		    		this.m_E_ButtonCloseHexinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonCloseHexin");
     			}
     			return this.m_E_ButtonCloseHexinButton;
     		}
     	}

		public Image E_ButtonCloseHexinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseHexinImage == null )
     			{
		    		this.m_E_ButtonCloseHexinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonCloseHexin");
     			}
     			return this.m_E_ButtonCloseHexinImage;
     		}
     	}

		public Button E_ButtonHeXinHeChengButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonHeXinHeChengButton == null )
     			{
		    		this.m_E_ButtonHeXinHeChengButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonHeXinHeCheng");
     			}
     			return this.m_E_ButtonHeXinHeChengButton;
     		}
     	}

		public Image E_ButtonHeXinHeChengImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonHeXinHeChengImage == null )
     			{
		    		this.m_E_ButtonHeXinHeChengImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonHeXinHeCheng");
     			}
     			return this.m_E_ButtonHeXinHeChengImage;
     		}
     	}

		public Text E_TextTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTypeText == null )
     			{
		    		this.m_E_TextTypeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_TextType");
     			}
     			return this.m_E_TextTypeText;
     		}
     	}

		public Button E_ButtonEquipXieXiaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEquipXieXiaButton == null )
     			{
		    		this.m_E_ButtonEquipXieXiaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonEquipXieXia");
     			}
     			return this.m_E_ButtonEquipXieXiaButton;
     		}
     	}

		public Image E_ButtonEquipXieXiaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonEquipXieXiaImage == null )
     			{
		    		this.m_E_ButtonEquipXieXiaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonEquipXieXia");
     			}
     			return this.m_E_ButtonEquipXieXiaImage;
     		}
     	}

		public RectTransform EG_PetAddPointRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetAddPointRectTransform == null )
     			{
		    		this.m_EG_PetAddPointRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint");
     			}
     			return this.m_EG_PetAddPointRectTransform;
     		}
     	}

		public Text E_Lab_ShengYuNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ShengYuNumText == null )
     			{
		    		this.m_E_Lab_ShengYuNumText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_Lab_ShengYuNum");
     			}
     			return this.m_E_Lab_ShengYuNumText;
     		}
     	}

		public Button E_Btn_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ConfirmButton == null )
     			{
		    		this.m_E_Btn_ConfirmButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_Btn_Confirm");
     			}
     			return this.m_E_Btn_ConfirmButton;
     		}
     	}

		public Image E_Btn_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ConfirmImage == null )
     			{
		    		this.m_E_Btn_ConfirmImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_Btn_Confirm");
     			}
     			return this.m_E_Btn_ConfirmImage;
     		}
     	}

		public RectTransform EG_AddProperty_LiLiangRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AddProperty_LiLiangRectTransform == null )
     			{
		    		this.m_EG_AddProperty_LiLiangRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/EG_AddProperty_LiLiang");
     			}
     			return this.m_EG_AddProperty_LiLiangRectTransform;
     		}
     	}

		public RectTransform EG_AddProperty_ZhiLiRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AddProperty_ZhiLiRectTransform == null )
     			{
		    		this.m_EG_AddProperty_ZhiLiRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/EG_AddProperty_ZhiLi");
     			}
     			return this.m_EG_AddProperty_ZhiLiRectTransform;
     		}
     	}

		public RectTransform EG_AddProperty_TiZhiRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AddProperty_TiZhiRectTransform == null )
     			{
		    		this.m_EG_AddProperty_TiZhiRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/EG_AddProperty_TiZhi");
     			}
     			return this.m_EG_AddProperty_TiZhiRectTransform;
     		}
     	}

		public RectTransform EG_AddProperty_NaiLiRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AddProperty_NaiLiRectTransform == null )
     			{
		    		this.m_EG_AddProperty_NaiLiRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/EG_AddProperty_NaiLi");
     			}
     			return this.m_EG_AddProperty_NaiLiRectTransform;
     		}
     	}

		public Button E_ButtonCloseAddPointButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseAddPointButton == null )
     			{
		    		this.m_E_ButtonCloseAddPointButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_ButtonCloseAddPoint");
     			}
     			return this.m_E_ButtonCloseAddPointButton;
     		}
     	}

		public Image E_ButtonCloseAddPointImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseAddPointImage == null )
     			{
		    		this.m_E_ButtonCloseAddPointImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_ButtonCloseAddPoint");
     			}
     			return this.m_E_ButtonCloseAddPointImage;
     		}
     	}

		public RectTransform EG_EquipSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_EquipSetRectTransform == null )
     			{
		    		this.m_EG_EquipSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_EquipSet");
     			}
     			return this.m_EG_EquipSetRectTransform;
     		}
     	}

		public Image E_ImageExpValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageExpValueImage == null )
     			{
		    		this.m_E_ImageExpValueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/E_ImageExpValue");
     			}
     			return this.m_E_ImageExpValueImage;
     		}
     	}

		public Text E_Text_PetNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetNumberText == null )
     			{
		    		this.m_E_Text_PetNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_Text_PetNumber");
     			}
     			return this.m_E_Text_PetNumberText;
     		}
     	}

		public Text E_Text_PetLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetLevelText == null )
     			{
		    		this.m_E_Text_PetLevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_Text_PetLevel");
     			}
     			return this.m_E_Text_PetLevelText;
     		}
     	}

		public Text E_Text_PetExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetExpText == null )
     			{
		    		this.m_E_Text_PetExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_Text_PetExp");
     			}
     			return this.m_E_Text_PetExpText;
     		}
     	}

		public Text E_Text_PetPingFenText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetPingFenText == null )
     			{
		    		this.m_E_Text_PetPingFenText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_Text_PetPingFen");
     			}
     			return this.m_E_Text_PetPingFenText;
     		}
     	}

		public Button E_ImageJinHuaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageJinHuaButton == null )
     			{
		    		this.m_E_ImageJinHuaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_ImageJinHua");
     			}
     			return this.m_E_ImageJinHuaButton;
     		}
     	}

		public Image E_ImageJinHuaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageJinHuaImage == null )
     			{
		    		this.m_E_ImageJinHuaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_ImageJinHua");
     			}
     			return this.m_E_ImageJinHuaImage;
     		}
     	}

		public Text E_Lab_JinHuaText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_JinHuaText == null )
     			{
		    		this.m_E_Lab_JinHuaText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_ImageJinHua/E_Lab_JinHua");
     			}
     			return this.m_E_Lab_JinHuaText;
     		}
     	}

		public Image E_JinHuaReddotImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JinHuaReddotImage == null )
     			{
		    		this.m_E_JinHuaReddotImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_ImageJinHua/E_JinHuaReddot");
     			}
     			return this.m_E_JinHuaReddotImage;
     		}
     	}

		public Image E_ImageShouHuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageShouHuImage == null )
     			{
		    		this.m_E_ImageShouHuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/ImageJinHua (1)/E_ImageShouHu");
     			}
     			return this.m_E_ImageShouHuImage;
     		}
     	}

		public Text E_Text_ShouHuText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ShouHuText == null )
     			{
		    		this.m_E_Text_ShouHuText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/ImageJinHua (1)/E_Text_ShouHu");
     			}
     			return this.m_E_Text_ShouHuText;
     		}
     	}

		public Text E_Text_Lv
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Text_Lv == null )
				{
					this.m_E_Text_Lv = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_Right/E_Text_Lv");
				}
				return this.m_E_Text_Lv;
			}
		}
		
		public Button E_JiBanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiBanButton == null )
     			{
		    		this.m_E_JiBanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_JiBan");
     			}
     			return this.m_E_JiBanButton;
     		}
     	}

		public Image E_JiBanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiBanImage == null )
     			{
		    		this.m_E_JiBanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_JiBan");
     			}
     			return this.m_E_JiBanImage;
     		}
     	}

		public Button E_PetHeXinSuitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinSuitButton == null )
     			{
		    		this.m_E_PetHeXinSuitButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_PetHeXinSuit");
     			}
     			return this.m_E_PetHeXinSuitButton;
     		}
     	}

		public Image E_PetHeXinSuitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHeXinSuitImage == null )
     			{
		    		this.m_E_PetHeXinSuitImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_PetHeXinSuit");
     			}
     			return this.m_E_PetHeXinSuitImage;
     		}
     	}

		public RectTransform EG_GameObject2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_GameObject2RectTransform == null )
     			{
		    		this.m_EG_GameObject2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_GameObject2");
     			}
     			return this.m_EG_GameObject2RectTransform;
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
			this.m_EG_MaskRectTransform = null;
			this.m_E_PetListItemsLoopVerticalScrollRect = null;
			this.m_EG_RightRectTransform = null;
			this.m_es_modelshow = null;
			this.m_EG_ImagePetStarRectTransform = null;
			this.m_E_ButtonRNameButton = null;
			this.m_E_ButtonRNameImage = null;
			this.m_E_PetHeXinItem0Image = null;
			this.m_E_PetHeXinItem1Image = null;
			this.m_E_PetHeXinItem2Image = null;
			this.m_E_InputFieldNameInputField = null;
			this.m_E_InputFieldNameImage = null;
			this.m_E_ButtonAddPointButton = null;
			this.m_E_ButtonAddPointImage = null;
			this.m_EG_ButtonNodeRectTransform = null;
			this.m_E_Btn_ChuZhanButton = null;
			this.m_E_Btn_ChuZhanImage = null;
			this.m_E_Btn_XiuXiButton = null;
			this.m_E_Btn_XiuXiImage = null;
			this.m_E_Btn_FangShengButton = null;
			this.m_E_Btn_FangShengImage = null;
			this.m_EG_AttributeNodeRectTransform = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_EG_PetZiZhiSetRectTransform = null;
			this.m_EG_PetZiZhiItem1RectTransform = null;
			this.m_EG_PetZiZhiItem2RectTransform = null;
			this.m_EG_PetZiZhiItem3RectTransform = null;
			this.m_EG_PetZiZhiItem4RectTransform = null;
			this.m_EG_PetZiZhiItem5RectTransform = null;
			this.m_EG_PetZiZhiItem6RectTransform = null;
			this.m_E_CommonSkillItemsLoopVerticalScrollRect = null;
			this.m_EG_PetPiFuSetRectTransform = null;
			this.m_E_PetSkinRawImageButton = null;
			this.m_E_PetSkinRawImageRawImage = null;
			this.m_E_PetSkinRawImageEventTrigger = null;
			this.m_E_PetSkinIconItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonUseSkinButton = null;
			this.m_E_ButtonUseSkinImage = null;
			this.m_E_PropertyShowTextText = null;
			this.m_E_SkinJiHuoImage = null;
			this.m_E_SkinWeiJiHuoImage = null;
			this.m_E_PetProSetNodeImage = null;
			this.m_EG_PetProSetItem_1RectTransform = null;
			this.m_EG_PetProSetItem_2RectTransform = null;
			this.m_E_PetProSetNode_1Image = null;
			this.m_E_PetProSetNode_2Image = null;
			this.m_EG_PetHeXinSetRectTransform = null;
			this.m_E_ImageIconImage = null;
			this.m_E_TextNameText = null;
			this.m_E_TextLevelText = null;
			this.m_EG_TextAttributeItemRectTransform = null;
			this.m_EG_AttributeListNodeRectTransform = null;
			this.m_E_PetHeXinListLoopVerticalScrollRect = null;
			this.m_E_ButtonEquipHeXinButton = null;
			this.m_E_ButtonEquipHeXinImage = null;
			this.m_E_ButtonCloseHexinButton = null;
			this.m_E_ButtonCloseHexinImage = null;
			this.m_E_ButtonHeXinHeChengButton = null;
			this.m_E_ButtonHeXinHeChengImage = null;
			this.m_E_TextTypeText = null;
			this.m_E_ButtonEquipXieXiaButton = null;
			this.m_E_ButtonEquipXieXiaImage = null;
			this.m_EG_PetAddPointRectTransform = null;
			this.m_E_Lab_ShengYuNumText = null;
			this.m_E_Btn_ConfirmButton = null;
			this.m_E_Btn_ConfirmImage = null;
			this.m_EG_AddProperty_LiLiangRectTransform = null;
			this.m_EG_AddProperty_ZhiLiRectTransform = null;
			this.m_EG_AddProperty_TiZhiRectTransform = null;
			this.m_EG_AddProperty_NaiLiRectTransform = null;
			this.m_E_ButtonCloseAddPointButton = null;
			this.m_E_ButtonCloseAddPointImage = null;
			this.m_EG_EquipSetRectTransform = null;
			this.m_E_ImageExpValueImage = null;
			this.m_E_Text_PetNumberText = null;
			this.m_E_Text_PetLevelText = null;
			this.m_E_Text_PetExpText = null;
			this.m_E_Text_PetPingFenText = null;
			this.m_E_ImageJinHuaButton = null;
			this.m_E_ImageJinHuaImage = null;
			this.m_E_Lab_JinHuaText = null;
			this.m_E_JinHuaReddotImage = null;
			this.m_E_ImageShouHuImage = null;
			this.m_E_Text_ShouHuText = null;
			this.m_E_JiBanButton = null;
			this.m_E_JiBanImage = null;
			this.m_E_PetHeXinSuitButton = null;
			this.m_E_PetHeXinSuitImage = null;
			this.m_E_Text_Lv = null;
			this.m_EG_GameObject2RectTransform = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_MaskRectTransform = null;
		private LoopVerticalScrollRect m_E_PetListItemsLoopVerticalScrollRect = null;
		private RectTransform m_EG_RightRectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private RectTransform m_EG_ImagePetStarRectTransform = null;
		private Button m_E_ButtonRNameButton = null;
		private Image m_E_ButtonRNameImage = null;
		private Image m_E_PetHeXinItem0Image = null;
		private Image m_E_PetHeXinItem1Image = null;
		private Image m_E_PetHeXinItem2Image = null;
		private InputField m_E_InputFieldNameInputField = null;
		private Image m_E_InputFieldNameImage = null;
		private Button m_E_ButtonAddPointButton = null;
		private Image m_E_ButtonAddPointImage = null;
		private RectTransform m_EG_ButtonNodeRectTransform = null;
		private Button m_E_Btn_ChuZhanButton = null;
		private Image m_E_Btn_ChuZhanImage = null;
		private Button m_E_Btn_XiuXiButton = null;
		private Image m_E_Btn_XiuXiImage = null;
		private Button m_E_Btn_FangShengButton = null;
		private Image m_E_Btn_FangShengImage = null;
		private RectTransform m_EG_AttributeNodeRectTransform = null;
		private ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private RectTransform m_EG_PetZiZhiSetRectTransform = null;
		private RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private RectTransform m_EG_PetPiFuSetRectTransform = null;
		private Button m_E_PetSkinRawImageButton = null;
		private RawImage m_E_PetSkinRawImageRawImage = null;
		private EventTrigger m_E_PetSkinRawImageEventTrigger = null;
		private LoopVerticalScrollRect m_E_PetSkinIconItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonUseSkinButton = null;
		private Image m_E_ButtonUseSkinImage = null;
		private Text m_E_PropertyShowTextText = null;
		private Image m_E_SkinJiHuoImage = null;
		private Image m_E_SkinWeiJiHuoImage = null;
		private Image m_E_PetProSetNodeImage = null;
		private RectTransform m_EG_PetProSetItem_1RectTransform = null;
		private RectTransform m_EG_PetProSetItem_2RectTransform = null;
		private Image m_E_PetProSetNode_1Image = null;
		private Image m_E_PetProSetNode_2Image = null;
		private RectTransform m_EG_PetHeXinSetRectTransform = null;
		private Image m_E_ImageIconImage = null;
		private Text m_E_TextNameText = null;
		private Text m_E_TextLevelText = null;
		private RectTransform m_EG_TextAttributeItemRectTransform = null;
		private RectTransform m_EG_AttributeListNodeRectTransform = null;
		private LoopVerticalScrollRect m_E_PetHeXinListLoopVerticalScrollRect = null;
		private Button m_E_ButtonEquipHeXinButton = null;
		private Image m_E_ButtonEquipHeXinImage = null;
		private Button m_E_ButtonCloseHexinButton = null;
		private Image m_E_ButtonCloseHexinImage = null;
		private Button m_E_ButtonHeXinHeChengButton = null;
		private Image m_E_ButtonHeXinHeChengImage = null;
		private Text m_E_TextTypeText = null;
		private Button m_E_ButtonEquipXieXiaButton = null;
		private Image m_E_ButtonEquipXieXiaImage = null;
		private RectTransform m_EG_PetAddPointRectTransform = null;
		private Text m_E_Lab_ShengYuNumText = null;
		private Button m_E_Btn_ConfirmButton = null;
		private Image m_E_Btn_ConfirmImage = null;
		private RectTransform m_EG_AddProperty_LiLiangRectTransform = null;
		private RectTransform m_EG_AddProperty_ZhiLiRectTransform = null;
		private RectTransform m_EG_AddProperty_TiZhiRectTransform = null;
		private RectTransform m_EG_AddProperty_NaiLiRectTransform = null;
		private Button m_E_ButtonCloseAddPointButton = null;
		private Image m_E_ButtonCloseAddPointImage = null;
		private RectTransform m_EG_EquipSetRectTransform = null;
		private Image m_E_ImageExpValueImage = null;
		private Text m_E_Text_PetNumberText = null;
		private Text m_E_Text_PetLevelText = null;
		private Text m_E_Text_PetExpText = null;
		private Text m_E_Text_PetPingFenText = null;
		private Button m_E_ImageJinHuaButton = null;
		private Image m_E_ImageJinHuaImage = null;
		private Text m_E_Lab_JinHuaText = null;
		private Image m_E_JinHuaReddotImage = null;
		private Image m_E_ImageShouHuImage = null;
		private Text m_E_Text_ShouHuText = null;
		private Text m_E_Text_Lv = null;
		private Button m_E_JiBanButton = null;
		private Image m_E_JiBanImage = null;
		private Button m_E_PetHeXinSuitButton = null;
		private Image m_E_PetHeXinSuitImage = null;
		private RectTransform m_EG_GameObject2RectTransform = null;
		public Transform uiTransform = null;
	}
}
