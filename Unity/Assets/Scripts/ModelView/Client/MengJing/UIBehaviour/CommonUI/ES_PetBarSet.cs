
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
		public int PetBarIndex;
		public int SkillType;
		public int SkillIndex;
		public Dictionary<int, EntityRef<Scroll_Item_PetbarSetSkillItem>> ScrollItemPetbarSetSkillItems;
		public List<int> ShowSKillIds = new();
		public List<int> ActivatedSKillIds = new();
		
		public Dictionary<int, EntityRef<Scroll_Item_PetbarSetPetItem>> ScrollItemPetbarSetPetItems;
		public List<RolePetInfo> ShowRolePetInfos = new();
		
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

		public UnityEngine.UI.LoopVerticalScrollRect E_PetbarSetPetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetbarSetPetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetbarSetPetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/EG_PetPanel/E_PetbarSetPetItems");
     			}
     			return this.m_E_PetbarSetPetItemsLoopVerticalScrollRect;
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

		public UnityEngine.UI.LoopVerticalScrollRect E_PetbarSetSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetbarSetSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetbarSetSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/EG_SkillPanel/E_PetbarSetSkillItems");
     			}
     			return this.m_E_PetbarSetSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ConfirmPetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmPetButton == null )
     			{
		    		this.m_E_ConfirmPetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ConfirmPet");
     			}
     			return this.m_E_ConfirmPetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmPetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmPetImage == null )
     			{
		    		this.m_E_ConfirmPetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ConfirmPet");
     			}
     			return this.m_E_ConfirmPetImage;
     		}
     	}

		public UnityEngine.UI.Image E_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_IconImage == null )
     			{
		    		this.m_E_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Icon");
     			}
     			return this.m_E_IconImage;
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
			this.m_E_PetbarSetPetItemsLoopVerticalScrollRect = null;
			this.m_EG_SkillPanelRectTransform = null;
			this.m_E_PetbarSetSkillItemsLoopVerticalScrollRect = null;
			this.m_E_ConfirmPetButton = null;
			this.m_E_ConfirmPetImage = null;
			this.m_E_IconImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_PlanSetToggleGroup = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_1 = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_2 = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_3 = null;
		private UnityEngine.RectTransform m_EG_PetPanelRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_PetTypeSetToggleGroup = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetbarSetPetItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_SkillPanelRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetbarSetSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ConfirmPetButton = null;
		private UnityEngine.UI.Image m_E_ConfirmPetImage = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		public Transform uiTransform = null;
	}
}
