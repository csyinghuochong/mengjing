
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRole))]
	[EnableMethod]
	public  class DlgRoleViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_EquipSet ES_EquipSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_equipset == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipSet");
		    	   this.m_es_equipset = this.AddChild<ES_EquipSet,Transform>(subTrans);
     			}
     			return this.m_es_equipset;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_BagToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagToggle == null )
     			{
		    		this.m_E_BagToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Bag");
     			}
     			return this.m_E_BagToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_PropertyToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PropertyToggle == null )
     			{
		    		this.m_E_PropertyToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Property");
     			}
     			return this.m_E_PropertyToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_GemToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GemToggle == null )
     			{
		    		this.m_E_GemToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Gem");
     			}
     			return this.m_E_GemToggle;
     		}
     	}

		public UnityEngine.UI.Button E_ZodiacButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZodiacButton == null )
     			{
		    		this.m_E_ZodiacButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Zodiac");
     			}
     			return this.m_E_ZodiacButton;
     		}
     	}

		public UnityEngine.UI.Image E_ZodiacImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZodiacImage == null )
     			{
		    		this.m_E_ZodiacImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Zodiac");
     			}
     			return this.m_E_ZodiacImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SubViewRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewRectTransform == null )
     			{
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubView");
     			}
     			return this.m_EG_SubViewRectTransform;
     		}
     	}

		public ES_RoleBag ES_RoleBag
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolebag == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleBag");
		    	   this.m_es_rolebag = this.AddChild<ES_RoleBag,Transform>(subTrans);
     			}
     			return this.m_es_rolebag;
     		}
     	}

		public ES_RoleProperty ES_RoleProperty
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_roleproperty == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleProperty");
		    	   this.m_es_roleproperty = this.AddChild<ES_RoleProperty,Transform>(subTrans);
     			}
     			return this.m_es_roleproperty;
     		}
     	}

		public ES_RoleGem ES_RoleGem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolegem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleGem");
		    	   this.m_es_rolegem = this.AddChild<ES_RoleGem,Transform>(subTrans);
     			}
     			return this.m_es_rolegem;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_equipset = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_BagToggle = null;
			this.m_E_PropertyToggle = null;
			this.m_E_GemToggle = null;
			this.m_E_ZodiacButton = null;
			this.m_E_ZodiacImage = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_rolebag = null;
			this.m_es_roleproperty = null;
			this.m_es_rolegem = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_EquipSet> m_es_equipset = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_BagToggle = null;
		private UnityEngine.UI.Toggle m_E_PropertyToggle = null;
		private UnityEngine.UI.Toggle m_E_GemToggle = null;
		private UnityEngine.UI.Button m_E_ZodiacButton = null;
		private UnityEngine.UI.Image m_E_ZodiacImage = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_RoleBag> m_es_rolebag = null;
		private EntityRef<ES_RoleProperty> m_es_roleproperty = null;
		private EntityRef<ES_RoleGem> m_es_rolegem = null;
		public Transform uiTransform = null;
	}
}
