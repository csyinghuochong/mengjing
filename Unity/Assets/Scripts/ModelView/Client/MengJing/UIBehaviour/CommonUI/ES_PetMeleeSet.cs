
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetMeleeSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public GameObject MainPetItem;
		public GameObject AssistPetItem;
		public GameObject SkillItem;
		public List<GameObject> MainPetItemList = new();
		public List<GameObject> AssistPetItemList = new();
		public List<GameObject> SkillItemList = new();
		public PetMeleeInfo PetMeleeInfo;
		public Dictionary<int, EntityRef<Scroll_Item_SelectMainPetItem>> ScrollItemSelectMainPetItems;
		public List<RolePetInfo> ShowMainPets = new();
		public Dictionary<int, EntityRef<Scroll_Item_SelectAssistPetItem>> ScrollItemSelectAssistPetItems;
		
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

		public UnityEngine.RectTransform EG_MainPetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainPetListRectTransform == null )
     			{
		    		this.m_EG_MainPetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MainPetList");
     			}
     			return this.m_EG_MainPetListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AssistPetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AssistPetListRectTransform == null )
     			{
		    		this.m_EG_AssistPetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_AssistPetList");
     			}
     			return this.m_EG_AssistPetListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillListRectTransform == null )
     			{
		    		this.m_EG_SkillListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_SkillList");
     			}
     			return this.m_EG_SkillListRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SetMainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetMainButton == null )
     			{
		    		this.m_E_SetMainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_SetMain");
     			}
     			return this.m_E_SetMainButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetMainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetMainImage == null )
     			{
		    		this.m_E_SetMainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SetMain");
     			}
     			return this.m_E_SetMainImage;
     		}
     	}

		public UnityEngine.UI.Button E_SetAssistButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetAssistButton == null )
     			{
		    		this.m_E_SetAssistButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_SetAssist");
     			}
     			return this.m_E_SetAssistButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetAssistImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetAssistImage == null )
     			{
		    		this.m_E_SetAssistImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SetAssist");
     			}
     			return this.m_E_SetAssistImage;
     		}
     	}

		public UnityEngine.UI.Button E_SetSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetSkillButton == null )
     			{
		    		this.m_E_SetSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_SetSkill");
     			}
     			return this.m_E_SetSkillButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetSkillImage == null )
     			{
		    		this.m_E_SetSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SetSkill");
     			}
     			return this.m_E_SetSkillImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectMainPetItemPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectMainPetItemPanelRectTransform == null )
     			{
		    		this.m_EG_SelectMainPetItemPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SelectMainPetItemPanel");
     			}
     			return this.m_EG_SelectMainPetItemPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SelectMainPetItemCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemCloseButton == null )
     			{
		    		this.m_E_SelectMainPetItemCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_SelectMainPetItemPanel/E_SelectMainPetItemClose");
     			}
     			return this.m_E_SelectMainPetItemCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMainPetItemCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemCloseImage == null )
     			{
		    		this.m_E_SelectMainPetItemCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_SelectMainPetItemPanel/E_SelectMainPetItemClose");
     			}
     			return this.m_E_SelectMainPetItemCloseImage;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMainPetItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemsImage == null )
     			{
		    		this.m_E_SelectMainPetItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_SelectMainPetItemPanel/E_SelectMainPetItems");
     			}
     			return this.m_E_SelectMainPetItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SelectMainPetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SelectMainPetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_SelectMainPetItemPanel/E_SelectMainPetItems");
     			}
     			return this.m_E_SelectMainPetItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_SelectMainPetItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemNumText == null )
     			{
		    		this.m_E_SelectMainPetItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_SelectMainPetItemPanel/E_SelectMainPetItemNum");
     			}
     			return this.m_E_SelectMainPetItemNumText;
     		}
     	}

		public UnityEngine.UI.Button E_SelectMainPetItemConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemConfirmButton == null )
     			{
		    		this.m_E_SelectMainPetItemConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_SelectMainPetItemPanel/E_SelectMainPetItemConfirm");
     			}
     			return this.m_E_SelectMainPetItemConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMainPetItemConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemConfirmImage == null )
     			{
		    		this.m_E_SelectMainPetItemConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_SelectMainPetItemPanel/E_SelectMainPetItemConfirm");
     			}
     			return this.m_E_SelectMainPetItemConfirmImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectAssistPetItemPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectAssistPetItemPanelRectTransform == null )
     			{
		    		this.m_EG_SelectAssistPetItemPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SelectAssistPetItemPanel");
     			}
     			return this.m_EG_SelectAssistPetItemPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SelectAssistPetItemCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemCloseButton == null )
     			{
		    		this.m_E_SelectAssistPetItemCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_SelectAssistPetItemPanel/E_SelectAssistPetItemClose");
     			}
     			return this.m_E_SelectAssistPetItemCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectAssistPetItemCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemCloseImage == null )
     			{
		    		this.m_E_SelectAssistPetItemCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_SelectAssistPetItemPanel/E_SelectAssistPetItemClose");
     			}
     			return this.m_E_SelectAssistPetItemCloseImage;
     		}
     	}

		public UnityEngine.UI.Image E_SelectAssistPetItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemsImage == null )
     			{
		    		this.m_E_SelectAssistPetItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_SelectAssistPetItemPanel/E_SelectAssistPetItems");
     			}
     			return this.m_E_SelectAssistPetItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SelectAssistPetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SelectAssistPetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_SelectAssistPetItemPanel/E_SelectAssistPetItems");
     			}
     			return this.m_E_SelectAssistPetItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_SelectAssistPetItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemNumText == null )
     			{
		    		this.m_E_SelectAssistPetItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_SelectAssistPetItemPanel/E_SelectAssistPetItemNum");
     			}
     			return this.m_E_SelectAssistPetItemNumText;
     		}
     	}

		public UnityEngine.UI.Button E_SelectAssistPetItemConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemConfirmButton == null )
     			{
		    		this.m_E_SelectAssistPetItemConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_SelectAssistPetItemPanel/E_SelectAssistPetItemConfirm");
     			}
     			return this.m_E_SelectAssistPetItemConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectAssistPetItemConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemConfirmImage == null )
     			{
		    		this.m_E_SelectAssistPetItemConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_SelectAssistPetItemPanel/E_SelectAssistPetItemConfirm");
     			}
     			return this.m_E_SelectAssistPetItemConfirmImage;
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
			this.m_EG_MainPetListRectTransform = null;
			this.m_EG_AssistPetListRectTransform = null;
			this.m_EG_SkillListRectTransform = null;
			this.m_E_SetMainButton = null;
			this.m_E_SetMainImage = null;
			this.m_E_SetAssistButton = null;
			this.m_E_SetAssistImage = null;
			this.m_E_SetSkillButton = null;
			this.m_E_SetSkillImage = null;
			this.m_EG_SelectMainPetItemPanelRectTransform = null;
			this.m_E_SelectMainPetItemCloseButton = null;
			this.m_E_SelectMainPetItemCloseImage = null;
			this.m_E_SelectMainPetItemsImage = null;
			this.m_E_SelectMainPetItemsLoopVerticalScrollRect = null;
			this.m_E_SelectMainPetItemNumText = null;
			this.m_E_SelectMainPetItemConfirmButton = null;
			this.m_E_SelectMainPetItemConfirmImage = null;
			this.m_EG_SelectAssistPetItemPanelRectTransform = null;
			this.m_E_SelectAssistPetItemCloseButton = null;
			this.m_E_SelectAssistPetItemCloseImage = null;
			this.m_E_SelectAssistPetItemsImage = null;
			this.m_E_SelectAssistPetItemsLoopVerticalScrollRect = null;
			this.m_E_SelectAssistPetItemNumText = null;
			this.m_E_SelectAssistPetItemConfirmButton = null;
			this.m_E_SelectAssistPetItemConfirmImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_PlanSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_MainPetListRectTransform = null;
		private UnityEngine.RectTransform m_EG_AssistPetListRectTransform = null;
		private UnityEngine.RectTransform m_EG_SkillListRectTransform = null;
		private UnityEngine.UI.Button m_E_SetMainButton = null;
		private UnityEngine.UI.Image m_E_SetMainImage = null;
		private UnityEngine.UI.Button m_E_SetAssistButton = null;
		private UnityEngine.UI.Image m_E_SetAssistImage = null;
		private UnityEngine.UI.Button m_E_SetSkillButton = null;
		private UnityEngine.UI.Image m_E_SetSkillImage = null;
		private UnityEngine.RectTransform m_EG_SelectMainPetItemPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_SelectMainPetItemCloseButton = null;
		private UnityEngine.UI.Image m_E_SelectMainPetItemCloseImage = null;
		private UnityEngine.UI.Image m_E_SelectMainPetItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SelectMainPetItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_SelectMainPetItemNumText = null;
		private UnityEngine.UI.Button m_E_SelectMainPetItemConfirmButton = null;
		private UnityEngine.UI.Image m_E_SelectMainPetItemConfirmImage = null;
		private UnityEngine.RectTransform m_EG_SelectAssistPetItemPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_SelectAssistPetItemCloseButton = null;
		private UnityEngine.UI.Image m_E_SelectAssistPetItemCloseImage = null;
		private UnityEngine.UI.Image m_E_SelectAssistPetItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SelectAssistPetItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_SelectAssistPetItemNumText = null;
		private UnityEngine.UI.Button m_E_SelectAssistPetItemConfirmButton = null;
		private UnityEngine.UI.Image m_E_SelectAssistPetItemConfirmImage = null;
		public Transform uiTransform = null;
	}
}
