using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetList : Entity,IAwake<Transform>,IDestroy,IUILogic
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
		
		public UnityEngine.RectTransform EG_MaskRectTransform
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
		    		this.m_EG_MaskRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Mask");
     			}
     			return this.m_EG_MaskRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetListItemsLoopVerticalScrollRect
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
		    		this.m_E_PetListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_PetListItems");
     			}
     			return this.m_E_PetListItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_RightRectTransform
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
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetTip_YeShengRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetTip_YeShengRectTransform == null )
     			{
		    		this.m_EG_PetTip_YeShengRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetTip_YeSheng");
     			}
     			return this.m_EG_PetTip_YeShengRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetTip_BaoBaoRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetTip_BaoBaoRectTransform == null )
     			{
		    		this.m_EG_PetTip_BaoBaoRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetTip_BaoBao");
     			}
     			return this.m_EG_PetTip_BaoBaoRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetTip_BianYiRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetTip_BianYiRectTransform == null )
     			{
		    		this.m_EG_PetTip_BianYiRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetTip_BianYi");
     			}
     			return this.m_EG_PetTip_BianYiRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetTip_ShenShouRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetTip_ShenShouRectTransform == null )
     			{
		    		this.m_EG_PetTip_ShenShouRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetTip_ShenShou");
     			}
     			return this.m_EG_PetTip_ShenShouRectTransform;
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

		public UnityEngine.RectTransform EG_ImagePetStarRectTransform
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
		    		this.m_EG_ImagePetStarRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_ImagePetStar");
     			}
     			return this.m_EG_ImagePetStarRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonRNameButton
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
		    		this.m_E_ButtonRNameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/E_ButtonRName");
     			}
     			return this.m_E_ButtonRNameButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonRNameImage
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
		    		this.m_E_ButtonRNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ButtonRName");
     			}
     			return this.m_E_ButtonRNameImage;
     		}
     	}

		public UnityEngine.UI.Image E_PetHeXinItem0Image
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
		    		this.m_E_PetHeXinItem0Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_PetHeXinItem0");
     			}
     			return this.m_E_PetHeXinItem0Image;
     		}
     	}

		public UnityEngine.UI.Image E_PetHeXinItem1Image
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
		    		this.m_E_PetHeXinItem1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_PetHeXinItem1");
     			}
     			return this.m_E_PetHeXinItem1Image;
     		}
     	}

		public UnityEngine.UI.Image E_PetHeXinItem2Image
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
		    		this.m_E_PetHeXinItem2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_PetHeXinItem2");
     			}
     			return this.m_E_PetHeXinItem2Image;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonAddPointButton
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
		    		this.m_E_ButtonAddPointButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/E_ButtonAddPoint");
     			}
     			return this.m_E_ButtonAddPointButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonAddPointImage
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
		    		this.m_E_ButtonAddPointImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ButtonAddPoint");
     			}
     			return this.m_E_ButtonAddPointImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputFieldNameInputField
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
		    		this.m_E_InputFieldNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EG_Right/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldNameImage
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
		    		this.m_E_InputFieldNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameImage;
     		}
     	}

		public UnityEngine.RectTransform EG_ButtonNodeRectTransform
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
		    		this.m_EG_ButtonNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode");
     			}
     			return this.m_EG_ButtonNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChuZhanButton
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
		    		this.m_E_Btn_ChuZhanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_ChuZhan");
     			}
     			return this.m_E_Btn_ChuZhanButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChuZhanImage
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
		    		this.m_E_Btn_ChuZhanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_ChuZhan");
     			}
     			return this.m_E_Btn_ChuZhanImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_XiuXiButton
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
		    		this.m_E_Btn_XiuXiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_XiuXi");
     			}
     			return this.m_E_Btn_XiuXiButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_XiuXiImage
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
		    		this.m_E_Btn_XiuXiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_XiuXi");
     			}
     			return this.m_E_Btn_XiuXiImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_FangShengButton
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
		    		this.m_E_Btn_FangShengButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_FangSheng");
     			}
     			return this.m_E_Btn_FangShengButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_FangShengImage
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
		    		this.m_E_Btn_FangShengImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_ButtonNode/E_Btn_FangSheng");
     			}
     			return this.m_E_Btn_FangShengImage;
     		}
     	}

		public UnityEngine.RectTransform EG_AttributeNodeRectTransform
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
		    		this.m_EG_AttributeNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode");
     			}
     			return this.m_EG_AttributeNodeRectTransform;
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
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.RectTransform EG_PetZiZhiSetRectTransform
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
		    		this.m_EG_PetZiZhiSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet");
     			}
     			return this.m_EG_PetZiZhiSetRectTransform;
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
		    		this.m_EG_PetZiZhiItem1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem1");
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
		    		this.m_EG_PetZiZhiItem2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem2");
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
		    		this.m_EG_PetZiZhiItem3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem3");
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
		    		this.m_EG_PetZiZhiItem4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem4");
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
		    		this.m_EG_PetZiZhiItem5RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem5");
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
		    		this.m_EG_PetZiZhiItem6RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/EG_PetZiZhiItem6");
     			}
     			return this.m_EG_PetZiZhiItem6RectTransform;
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
		    		this.m_E_CommonSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetZiZhiSet/E_CommonSkillItems");
     			}
     			return this.m_E_CommonSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_PetPiFuSetRectTransform
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
		    		this.m_EG_PetPiFuSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet");
     			}
     			return this.m_EG_PetPiFuSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_PetSkinRawImageButton
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
		    		this.m_E_PetSkinRawImageButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PetSkinRawImage");
     			}
     			return this.m_E_PetSkinRawImageButton;
     		}
     	}

		public UnityEngine.UI.RawImage E_PetSkinRawImageRawImage
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
		    		this.m_E_PetSkinRawImageRawImage = UIFindHelper.FindDeepChild<UnityEngine.UI.RawImage>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PetSkinRawImage");
     			}
     			return this.m_E_PetSkinRawImageRawImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_PetSkinRawImageEventTrigger
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
		    		this.m_E_PetSkinRawImageEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PetSkinRawImage");
     			}
     			return this.m_E_PetSkinRawImageEventTrigger;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetSkinIconItemsLoopVerticalScrollRect
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
		    		this.m_E_PetSkinIconItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PetSkinIconItems");
     			}
     			return this.m_E_PetSkinIconItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonUseSkinButton
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
		    		this.m_E_ButtonUseSkinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_ButtonUseSkin");
     			}
     			return this.m_E_ButtonUseSkinButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonUseSkinImage
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
		    		this.m_E_ButtonUseSkinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_ButtonUseSkin");
     			}
     			return this.m_E_ButtonUseSkinImage;
     		}
     	}

		public UnityEngine.UI.Text E_PropertyShowTextText
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
		    		this.m_E_PropertyShowTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_PropertyShowText");
     			}
     			return this.m_E_PropertyShowTextText;
     		}
     	}

		public UnityEngine.UI.Image E_SkinJiHuoImage
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
		    		this.m_E_SkinJiHuoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_SkinJiHuo");
     			}
     			return this.m_E_SkinJiHuoImage;
     		}
     	}

		public UnityEngine.UI.Image E_SkinWeiJiHuoImage
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
		    		this.m_E_SkinWeiJiHuoImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/EG_PetPiFuSet/E_SkinWeiJiHuo");
     			}
     			return this.m_E_SkinWeiJiHuoImage;
     		}
     	}

		public UnityEngine.UI.Image E_PetProSetNodeImage
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
		    		this.m_E_PetProSetNodeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode");
     			}
     			return this.m_E_PetProSetNodeImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PetProSetItem_1RectTransform
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
		    		this.m_EG_PetProSetItem_1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetItem_1");
     			}
     			return this.m_EG_PetProSetItem_1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetProSetItem_2RectTransform
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
		    		this.m_EG_PetProSetItem_2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode/EG_PetProSetItem_2");
     			}
     			return this.m_EG_PetProSetItem_2RectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_PetProSetNode_1Image
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
		    		this.m_E_PetProSetNode_1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode/E_PetProSetNode_1");
     			}
     			return this.m_E_PetProSetNode_1Image;
     		}
     	}

		public UnityEngine.UI.Image E_PetProSetNode_2Image
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
		    		this.m_E_PetProSetNode_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_AttributeNode/E_PetProSetNode/E_PetProSetNode_2");
     			}
     			return this.m_E_PetProSetNode_2Image;
     		}
     	}

		public UnityEngine.RectTransform EG_PetHeXinSetRectTransform
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
		    		this.m_EG_PetHeXinSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet");
     			}
     			return this.m_EG_PetHeXinSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_ImageIconImage
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
		    		this.m_E_ImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ImageIcon");
     			}
     			return this.m_E_ImageIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextNameText
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
		    		this.m_E_TextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_TextName");
     			}
     			return this.m_E_TextNameText;
     		}
     	}

		public UnityEngine.UI.Text E_TextLevelText
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
		    		this.m_E_TextLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_TextLevel");
     			}
     			return this.m_E_TextLevelText;
     		}
     	}

		public UnityEngine.RectTransform EG_TextAttributeItemRectTransform
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
		    		this.m_EG_TextAttributeItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/EG_TextAttributeItem");
     			}
     			return this.m_EG_TextAttributeItemRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AttributeListNodeRectTransform
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
		    		this.m_EG_AttributeListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/EG_AttributeListNode");
     			}
     			return this.m_EG_AttributeListNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_PetHeXinListLoopVerticalScrollRect
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
		    		this.m_E_PetHeXinListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_PetHeXinList");
     			}
     			return this.m_E_PetHeXinListLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonEquipHeXinButton
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
		    		this.m_E_ButtonEquipHeXinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonEquipHeXin");
     			}
     			return this.m_E_ButtonEquipHeXinButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonEquipHeXinImage
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
		    		this.m_E_ButtonEquipHeXinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonEquipHeXin");
     			}
     			return this.m_E_ButtonEquipHeXinImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCloseHexinButton
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
		    		this.m_E_ButtonCloseHexinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonCloseHexin");
     			}
     			return this.m_E_ButtonCloseHexinButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseHexinImage
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
		    		this.m_E_ButtonCloseHexinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonCloseHexin");
     			}
     			return this.m_E_ButtonCloseHexinImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonHeXinHeChengButton
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
		    		this.m_E_ButtonHeXinHeChengButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonHeXinHeCheng");
     			}
     			return this.m_E_ButtonHeXinHeChengButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonHeXinHeChengImage
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
		    		this.m_E_ButtonHeXinHeChengImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonHeXinHeCheng");
     			}
     			return this.m_E_ButtonHeXinHeChengImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextTypeText
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
		    		this.m_E_TextTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_TextType");
     			}
     			return this.m_E_TextTypeText;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonEquipXieXiaButton
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
		    		this.m_E_ButtonEquipXieXiaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonEquipXieXia");
     			}
     			return this.m_E_ButtonEquipXieXiaButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonEquipXieXiaImage
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
		    		this.m_E_ButtonEquipXieXiaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_PetHeXinSet/E_ButtonEquipXieXia");
     			}
     			return this.m_E_ButtonEquipXieXiaImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PetAddPointRectTransform
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
		    		this.m_EG_PetAddPointRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint");
     			}
     			return this.m_EG_PetAddPointRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ShengYuNumText
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
		    		this.m_E_Lab_ShengYuNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_Lab_ShengYuNum");
     			}
     			return this.m_E_Lab_ShengYuNumText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ConfirmButton
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
		    		this.m_E_Btn_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_Btn_Confirm");
     			}
     			return this.m_E_Btn_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ConfirmImage
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
		    		this.m_E_Btn_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_Btn_Confirm");
     			}
     			return this.m_E_Btn_ConfirmImage;
     		}
     	}

		public UnityEngine.RectTransform EG_AddProperty_LiLiangRectTransform
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
		    		this.m_EG_AddProperty_LiLiangRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/EG_AddProperty_LiLiang");
     			}
     			return this.m_EG_AddProperty_LiLiangRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AddProperty_ZhiLiRectTransform
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
		    		this.m_EG_AddProperty_ZhiLiRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/EG_AddProperty_ZhiLi");
     			}
     			return this.m_EG_AddProperty_ZhiLiRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AddProperty_TiZhiRectTransform
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
		    		this.m_EG_AddProperty_TiZhiRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/EG_AddProperty_TiZhi");
     			}
     			return this.m_EG_AddProperty_TiZhiRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AddProperty_NaiLiRectTransform
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
		    		this.m_EG_AddProperty_NaiLiRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/EG_AddProperty_NaiLi");
     			}
     			return this.m_EG_AddProperty_NaiLiRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCloseAddPointButton
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
		    		this.m_E_ButtonCloseAddPointButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_ButtonCloseAddPoint");
     			}
     			return this.m_E_ButtonCloseAddPointButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCloseAddPointImage
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
		    		this.m_E_ButtonCloseAddPointImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/EG_PetAddPoint/E_ButtonCloseAddPoint");
     			}
     			return this.m_E_ButtonCloseAddPointImage;
     		}
     	}

		public UnityEngine.RectTransform EG_EquipSetRectTransform
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
		    		this.m_EG_EquipSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right/EG_EquipSet");
     			}
     			return this.m_EG_EquipSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_ImageExpValueImage
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
		    		this.m_E_ImageExpValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ImageExpValue");
     			}
     			return this.m_E_ImageExpValueImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PetNumberText
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
		    		this.m_E_Text_PetNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Text_PetNumber");
     			}
     			return this.m_E_Text_PetNumberText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PetLevelText
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
		    		this.m_E_Text_PetLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Text_PetLevel");
     			}
     			return this.m_E_Text_PetLevelText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PetExpText
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
		    		this.m_E_Text_PetExpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Text_PetExp");
     			}
     			return this.m_E_Text_PetExpText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PetPingFenText
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
		    		this.m_E_Text_PetPingFenText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Text_PetPingFen");
     			}
     			return this.m_E_Text_PetPingFenText;
     		}
     	}

		public UnityEngine.UI.Button E_ImageJinHuaButton
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
		    		this.m_E_ImageJinHuaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_ImageJinHua");
     			}
     			return this.m_E_ImageJinHuaButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageJinHuaImage
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
		    		this.m_E_ImageJinHuaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_ImageJinHua");
     			}
     			return this.m_E_ImageJinHuaImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_JinHuaText
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
		    		this.m_E_Lab_JinHuaText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_ImageJinHua/E_Lab_JinHua");
     			}
     			return this.m_E_Lab_JinHuaText;
     		}
     	}

		public UnityEngine.UI.Image E_JinHuaReddotImage
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
		    		this.m_E_JinHuaReddotImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_ImageJinHua/E_JinHuaReddot");
     			}
     			return this.m_E_JinHuaReddotImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageShouHuImage
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
		    		this.m_E_ImageShouHuImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/ImageJinHua (1)/E_ImageShouHu");
     			}
     			return this.m_E_ImageShouHuImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ShouHuText
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
		    		this.m_E_Text_ShouHuText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/ImageJinHua (1)/E_Text_ShouHu");
     			}
     			return this.m_E_Text_ShouHuText;
     		}
     	}

		public UnityEngine.UI.Button E_JiBanButton
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
		    		this.m_E_JiBanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_JiBan");
     			}
     			return this.m_E_JiBanButton;
     		}
     	}

		public UnityEngine.UI.Image E_JiBanImage
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
		    		this.m_E_JiBanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_JiBan");
     			}
     			return this.m_E_JiBanImage;
     		}
     	}

		public UnityEngine.UI.Button E_PetHeXinSuitButton
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
		    		this.m_E_PetHeXinSuitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_PetHeXinSuit");
     			}
     			return this.m_E_PetHeXinSuitButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetHeXinSuitImage
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
		    		this.m_E_PetHeXinSuitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ScrollView/Viewport/BtnListNode/E_PetHeXinSuit");
     			}
     			return this.m_E_PetHeXinSuitImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LvText == null )
     			{
		    		this.m_E_Text_LvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Text_Lv");
     			}
     			return this.m_E_Text_LvText;
     		}
     	}

		public UnityEngine.RectTransform EG_GameObject2RectTransform
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
		    		this.m_EG_GameObject2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_GameObject2");
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
			this.m_EG_PetTip_YeShengRectTransform = null;
			this.m_EG_PetTip_BaoBaoRectTransform = null;
			this.m_EG_PetTip_BianYiRectTransform = null;
			this.m_EG_PetTip_ShenShouRectTransform = null;
			this.m_es_modelshow = null;
			this.m_EG_ImagePetStarRectTransform = null;
			this.m_E_ButtonRNameButton = null;
			this.m_E_ButtonRNameImage = null;
			this.m_E_PetHeXinItem0Image = null;
			this.m_E_PetHeXinItem1Image = null;
			this.m_E_PetHeXinItem2Image = null;
			this.m_E_ButtonAddPointButton = null;
			this.m_E_ButtonAddPointImage = null;
			this.m_E_InputFieldNameInputField = null;
			this.m_E_InputFieldNameImage = null;
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
			this.m_E_Text_LvText = null;
			this.m_EG_GameObject2RectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_MaskRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetListItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetTip_YeShengRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetTip_BaoBaoRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetTip_BianYiRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetTip_ShenShouRectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.RectTransform m_EG_ImagePetStarRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonRNameButton = null;
		private UnityEngine.UI.Image m_E_ButtonRNameImage = null;
		private UnityEngine.UI.Image m_E_PetHeXinItem0Image = null;
		private UnityEngine.UI.Image m_E_PetHeXinItem1Image = null;
		private UnityEngine.UI.Image m_E_PetHeXinItem2Image = null;
		private UnityEngine.UI.Button m_E_ButtonAddPointButton = null;
		private UnityEngine.UI.Image m_E_ButtonAddPointImage = null;
		private UnityEngine.UI.InputField m_E_InputFieldNameInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldNameImage = null;
		private UnityEngine.RectTransform m_EG_ButtonNodeRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_ChuZhanButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChuZhanImage = null;
		private UnityEngine.UI.Button m_E_Btn_XiuXiButton = null;
		private UnityEngine.UI.Image m_E_Btn_XiuXiImage = null;
		private UnityEngine.UI.Button m_E_Btn_FangShengButton = null;
		private UnityEngine.UI.Image m_E_Btn_FangShengImage = null;
		private UnityEngine.RectTransform m_EG_AttributeNodeRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiSetRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem1RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem2RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem3RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem4RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem5RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetZiZhiItem6RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_CommonSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_PetPiFuSetRectTransform = null;
		private UnityEngine.UI.Button m_E_PetSkinRawImageButton = null;
		private UnityEngine.UI.RawImage m_E_PetSkinRawImageRawImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_PetSkinRawImageEventTrigger = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetSkinIconItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonUseSkinButton = null;
		private UnityEngine.UI.Image m_E_ButtonUseSkinImage = null;
		private UnityEngine.UI.Text m_E_PropertyShowTextText = null;
		private UnityEngine.UI.Image m_E_SkinJiHuoImage = null;
		private UnityEngine.UI.Image m_E_SkinWeiJiHuoImage = null;
		private UnityEngine.UI.Image m_E_PetProSetNodeImage = null;
		private UnityEngine.RectTransform m_EG_PetProSetItem_1RectTransform = null;
		private UnityEngine.RectTransform m_EG_PetProSetItem_2RectTransform = null;
		private UnityEngine.UI.Image m_E_PetProSetNode_1Image = null;
		private UnityEngine.UI.Image m_E_PetProSetNode_2Image = null;
		private UnityEngine.RectTransform m_EG_PetHeXinSetRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageIconImage = null;
		private UnityEngine.UI.Text m_E_TextNameText = null;
		private UnityEngine.UI.Text m_E_TextLevelText = null;
		private UnityEngine.RectTransform m_EG_TextAttributeItemRectTransform = null;
		private UnityEngine.RectTransform m_EG_AttributeListNodeRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetHeXinListLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonEquipHeXinButton = null;
		private UnityEngine.UI.Image m_E_ButtonEquipHeXinImage = null;
		private UnityEngine.UI.Button m_E_ButtonCloseHexinButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseHexinImage = null;
		private UnityEngine.UI.Button m_E_ButtonHeXinHeChengButton = null;
		private UnityEngine.UI.Image m_E_ButtonHeXinHeChengImage = null;
		private UnityEngine.UI.Text m_E_TextTypeText = null;
		private UnityEngine.UI.Button m_E_ButtonEquipXieXiaButton = null;
		private UnityEngine.UI.Image m_E_ButtonEquipXieXiaImage = null;
		private UnityEngine.RectTransform m_EG_PetAddPointRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_ShengYuNumText = null;
		private UnityEngine.UI.Button m_E_Btn_ConfirmButton = null;
		private UnityEngine.UI.Image m_E_Btn_ConfirmImage = null;
		private UnityEngine.RectTransform m_EG_AddProperty_LiLiangRectTransform = null;
		private UnityEngine.RectTransform m_EG_AddProperty_ZhiLiRectTransform = null;
		private UnityEngine.RectTransform m_EG_AddProperty_TiZhiRectTransform = null;
		private UnityEngine.RectTransform m_EG_AddProperty_NaiLiRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonCloseAddPointButton = null;
		private UnityEngine.UI.Image m_E_ButtonCloseAddPointImage = null;
		private UnityEngine.RectTransform m_EG_EquipSetRectTransform = null;
		private UnityEngine.UI.Image m_E_ImageExpValueImage = null;
		private UnityEngine.UI.Text m_E_Text_PetNumberText = null;
		private UnityEngine.UI.Text m_E_Text_PetLevelText = null;
		private UnityEngine.UI.Text m_E_Text_PetExpText = null;
		private UnityEngine.UI.Text m_E_Text_PetPingFenText = null;
		private UnityEngine.UI.Button m_E_ImageJinHuaButton = null;
		private UnityEngine.UI.Image m_E_ImageJinHuaImage = null;
		private UnityEngine.UI.Text m_E_Lab_JinHuaText = null;
		private UnityEngine.UI.Image m_E_JinHuaReddotImage = null;
		private UnityEngine.UI.Image m_E_ImageShouHuImage = null;
		private UnityEngine.UI.Text m_E_Text_ShouHuText = null;
		private UnityEngine.UI.Button m_E_JiBanButton = null;
		private UnityEngine.UI.Image m_E_JiBanImage = null;
		private UnityEngine.UI.Button m_E_PetHeXinSuitButton = null;
		private UnityEngine.UI.Image m_E_PetHeXinSuitImage = null;
		private UnityEngine.UI.Text m_E_Text_LvText = null;
		private UnityEngine.RectTransform m_EG_GameObject2RectTransform = null;
		public Transform uiTransform = null;
	}
}
