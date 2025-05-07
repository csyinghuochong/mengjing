
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public List<PetBarInfo> PetFightList = new();
		public int PetBarIndex = 1;
		public int SkillType;
		public int SkillIndex;
		public Dictionary<int, EntityRef<Scroll_Item_PetbarSetSkillItem>> ScrollItemPetbarSetSkillItems = new();
		public List<int> ShowSKillIds = new();
		public List<int> ActivatedSKillIds = new();

		public Dictionary<int, EntityRef<Scroll_Item_PetbarSetPetItem>> ScrollItemPetbarSetPetItems = new();
		public List<RolePetInfo> ShowRolePetInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_PetBarSetPetSelectItem>> ScrollItemPetbarSetPetSelectItems = new();
		
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.UI.ToggleGroup E_PlanSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlanSetToggleGroup == null )
     			{
		    		this.m_E_PlanSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_PlanSet");
     			}
     			return this.m_E_PlanSetToggleGroup;
     		}
     	}

		public ES_PetBarSetItem ES_PetBarSetItem_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetBarSetItem es = this.m_es_petbarsetitem_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetBarSetItem_1");
		    	   this.m_es_petbarsetitem_1 = this.AddChild<ES_PetBarSetItem,Transform>(subTrans);
     			}
     			return this.m_es_petbarsetitem_1;
     		}
     	}

		public ES_PetBarSetItem ES_PetBarSetItem_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetBarSetItem es = this.m_es_petbarsetitem_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetBarSetItem_2");
		    	   this.m_es_petbarsetitem_2 = this.AddChild<ES_PetBarSetItem,Transform>(subTrans);
     			}
     			return this.m_es_petbarsetitem_2;
     		}
     	}

		public ES_PetBarSetItem ES_PetBarSetItem_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetBarSetItem es = this.m_es_petbarsetitem_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetBarSetItem_3");
		    	   this.m_es_petbarsetitem_3 = this.AddChild<ES_PetBarSetItem,Transform>(subTrans);
     			}
     			return this.m_es_petbarsetitem_3;
     		}
     	}

		public UnityEngine.RectTransform EG_PetPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetPanelRectTransform == null )
     			{
		    		this.m_EG_PetPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_PetPanel");
     			}
     			return this.m_EG_PetPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_PetTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetTypeSetToggleGroup == null )
     			{
		    		this.m_E_PetTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/EG_PetPanel/E_PetTypeSet");
     			}
     			return this.m_E_PetTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_PetbarSetPetItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetbarSetPetItemsScrollRect == null )
     			{
		    		this.m_E_PetbarSetPetItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/EG_PetPanel/E_PetbarSetPetItems");
     			}
     			return this.m_E_PetbarSetPetItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_PetbarSetPetItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetbarSetPetItemsImage == null )
     			{
		    		this.m_E_PetbarSetPetItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_PetPanel/E_PetbarSetPetItems");
     			}
     			return this.m_E_PetbarSetPetItemsImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillPanelRectTransform == null )
     			{
		    		this.m_EG_SkillPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillPanel");
     			}
     			return this.m_EG_SkillPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_SkillTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillTypeSetToggleGroup == null )
     			{
		    		this.m_E_SkillTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/EG_SkillPanel/E_SkillTypeSet");
     			}
     			return this.m_E_SkillTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_PetbarSetSkillItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetbarSetSkillItemsScrollRect == null )
     			{
		    		this.m_E_PetbarSetSkillItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Right/EG_SkillPanel/E_PetbarSetSkillItems");
     			}
     			return this.m_E_PetbarSetSkillItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_PetbarSetSkillItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetbarSetSkillItemsImage == null )
     			{
		    		this.m_E_PetbarSetSkillItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_SkillPanel/E_PetbarSetSkillItems");
     			}
     			return this.m_E_PetbarSetSkillItemsImage;
     		}
     	}

		public UnityEngine.UI.Button E_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmButton == null )
     			{
		    		this.m_E_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Confirm");
     			}
     			return this.m_E_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmImage == null )
     			{
		    		this.m_E_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Confirm");
     			}
     			return this.m_E_ConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button E_ReSetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetButton == null )
     			{
		    		this.m_E_ReSetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ReSet");
     			}
     			return this.m_E_ReSetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ReSetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReSetImage == null )
     			{
		    		this.m_E_ReSetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ReSet");
     			}
     			return this.m_E_ReSetImage;
     		}
     	}

		public UnityEngine.RectTransform EG_PetIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetIconRectTransform == null )
     			{
		    		this.m_EG_PetIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetIcon");
     			}
     			return this.m_EG_PetIconRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillIconRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillIconRectTransform == null )
     			{
		    		this.m_EG_SkillIconRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SkillIcon");
     			}
     			return this.m_EG_SkillIconRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_PetSelectPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetSelectPanelRectTransform == null )
     			{
		    		this.m_EG_PetSelectPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetSelectPanel");
     			}
     			return this.m_EG_PetSelectPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_PetSelectCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PetSelectCloseButton == null )
     			{
		    		this.m_E_Btn_PetSelectCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_PetSelectPanel/E_Btn_PetSelectClose");
     			}
     			return this.m_E_Btn_PetSelectCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_PetSelectCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PetSelectCloseImage == null )
     			{
		    		this.m_E_Btn_PetSelectCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PetSelectPanel/E_Btn_PetSelectClose");
     			}
     			return this.m_E_Btn_PetSelectCloseImage;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_PetBarSetPetSelectItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarSetPetSelectItemsScrollRect == null )
     			{
		    		this.m_E_PetBarSetPetSelectItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"EG_PetSelectPanel/E_PetBarSetPetSelectItems");
     			}
     			return this.m_E_PetBarSetPetSelectItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_PetBarSetPetSelectItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarSetPetSelectItemsImage == null )
     			{
		    		this.m_E_PetBarSetPetSelectItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_PetSelectPanel/E_PetBarSetPetSelectItems");
     			}
     			return this.m_E_PetBarSetPetSelectItemsImage;
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
			this.m_E_PlanSetToggleGroup = null;
			this.m_es_petbarsetitem_1 = null;
			this.m_es_petbarsetitem_2 = null;
			this.m_es_petbarsetitem_3 = null;
			this.m_EG_PetPanelRectTransform = null;
			this.m_E_PetTypeSetToggleGroup = null;
			this.m_E_PetbarSetPetItemsScrollRect = null;
			this.m_E_PetbarSetPetItemsImage = null;
			this.m_EG_SkillPanelRectTransform = null;
			this.m_E_SkillTypeSetToggleGroup = null;
			this.m_E_PetbarSetSkillItemsScrollRect = null;
			this.m_E_PetbarSetSkillItemsImage = null;
			this.m_E_ConfirmButton = null;
			this.m_E_ConfirmImage = null;
			this.m_E_ReSetButton = null;
			this.m_E_ReSetImage = null;
			this.m_EG_PetIconRectTransform = null;
			this.m_EG_SkillIconRectTransform = null;
			this.m_EG_PetSelectPanelRectTransform = null;
			this.m_E_Btn_PetSelectCloseButton = null;
			this.m_E_Btn_PetSelectCloseImage = null;
			this.m_E_PetBarSetPetSelectItemsScrollRect = null;
			this.m_E_PetBarSetPetSelectItemsImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_PlanSetToggleGroup = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_1 = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_2 = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_3 = null;
		private UnityEngine.RectTransform m_EG_PetPanelRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_PetTypeSetToggleGroup = null;
		private UnityEngine.UI.ScrollRect m_E_PetbarSetPetItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_PetbarSetPetItemsImage = null;
		private UnityEngine.RectTransform m_EG_SkillPanelRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_SkillTypeSetToggleGroup = null;
		private UnityEngine.UI.ScrollRect m_E_PetbarSetSkillItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_PetbarSetSkillItemsImage = null;
		private UnityEngine.UI.Button m_E_ConfirmButton = null;
		private UnityEngine.UI.Image m_E_ConfirmImage = null;
		private UnityEngine.UI.Button m_E_ReSetButton = null;
		private UnityEngine.UI.Image m_E_ReSetImage = null;
		private UnityEngine.RectTransform m_EG_PetIconRectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillIconRectTransform = null;
		private UnityEngine.RectTransform m_EG_PetSelectPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_PetSelectCloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_PetSelectCloseImage = null;
		private UnityEngine.UI.ScrollRect m_E_PetBarSetPetSelectItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_PetBarSetPetSelectItemsImage = null;
		public Transform uiTransform = null;
	}
}
