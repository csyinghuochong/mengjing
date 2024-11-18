
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public long ClickTime;
		public bool IsDrag;
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

		public ES_PetBarSetItem ES_PetBarSetItem_0
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetBarSetItem es = this.m_es_petbarsetitem_0;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_PetBarSetItem_0");
		    	   this.m_es_petbarsetitem_0 = this.AddChild<ES_PetBarSetItem,Transform>(subTrans);
     			}
     			return this.m_es_petbarsetitem_0;
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
		    		this.m_E_PetTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_PetTypeSet");
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
		    		this.m_E_PetbarSetPetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_PetbarSetPetItems");
     			}
     			return this.m_E_PetbarSetPetItemsLoopVerticalScrollRect;
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
		    		this.m_E_PetbarSetSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Right/E_PetbarSetSkillItems");
     			}
     			return this.m_E_PetbarSetSkillItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ActivateSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivateSkillButton == null )
     			{
		    		this.m_E_ActivateSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ActivateSkill");
     			}
     			return this.m_E_ActivateSkillButton;
     		}
     	}

		public UnityEngine.UI.Image E_ActivateSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivateSkillImage == null )
     			{
		    		this.m_E_ActivateSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ActivateSkill");
     			}
     			return this.m_E_ActivateSkillImage;
     		}
     	}

		public UnityEngine.UI.Button E_EquipSkillButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipSkillButton == null )
     			{
		    		this.m_E_EquipSkillButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_EquipSkill");
     			}
     			return this.m_E_EquipSkillButton;
     		}
     	}

		public UnityEngine.UI.Image E_EquipSkillImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EquipSkillImage == null )
     			{
		    		this.m_E_EquipSkillImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_EquipSkill");
     			}
     			return this.m_E_EquipSkillImage;
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
			this.m_es_petbarsetitem_0 = null;
			this.m_es_petbarsetitem_1 = null;
			this.m_es_petbarsetitem_2 = null;
			this.m_E_PetTypeSetToggleGroup = null;
			this.m_E_PetbarSetPetItemsLoopVerticalScrollRect = null;
			this.m_E_ConfirmButton = null;
			this.m_E_ConfirmImage = null;
			this.m_E_PetbarSetSkillItemsLoopVerticalScrollRect = null;
			this.m_E_ActivateSkillButton = null;
			this.m_E_ActivateSkillImage = null;
			this.m_E_EquipSkillButton = null;
			this.m_E_EquipSkillImage = null;
			this.m_E_IconImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_PlanSetToggleGroup = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_0 = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_1 = null;
		private EntityRef<ES_PetBarSetItem> m_es_petbarsetitem_2 = null;
		private UnityEngine.UI.ToggleGroup m_E_PetTypeSetToggleGroup = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetbarSetPetItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ConfirmButton = null;
		private UnityEngine.UI.Image m_E_ConfirmImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_PetbarSetSkillItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ActivateSkillButton = null;
		private UnityEngine.UI.Image m_E_ActivateSkillImage = null;
		private UnityEngine.UI.Button m_E_EquipSkillButton = null;
		private UnityEngine.UI.Image m_E_EquipSkillImage = null;
		private UnityEngine.UI.Image m_E_IconImage = null;
		public Transform uiTransform = null;
	}
}
