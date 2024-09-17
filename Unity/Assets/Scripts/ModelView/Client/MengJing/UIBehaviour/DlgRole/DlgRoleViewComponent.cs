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
     			ES_EquipSet es = this.m_es_equipset;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_EquipSet");
		    	   this.m_es_equipset = this.AddChild<ES_EquipSet,Transform>(subTrans);
     			}
     			return this.m_es_equipset;
     		}
     	}

		public Button E_ZodiacButton
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
		    		this.m_E_ZodiacButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Zodiac");
     			}
     			return this.m_E_ZodiacButton;
     		}
     	}

		public Image E_ZodiacImage
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
		    		this.m_E_ZodiacImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Zodiac");
     			}
     			return this.m_E_ZodiacImage;
     		}
     	}

		public RectTransform EG_SubViewRectTransform
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
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SubView");
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
     			ES_RoleBag es = this.m_es_rolebag;
     			if( es == null )

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
     			ES_RoleProperty es = this.m_es_roleproperty;
     			if( es == null )

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
     			ES_RoleGem es = this.m_es_rolegem;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleGem");
		    	   this.m_es_rolegem = this.AddChild<ES_RoleGem,Transform>(subTrans);
     			}
     			return this.m_es_rolegem;
     		}
     	}

		public ES_RoleHuiShou ES_RoleHuiShou
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RoleHuiShou es = this.m_es_rolehuishou;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleHuiShou");
		    	   this.m_es_rolehuishou = this.AddChild<ES_RoleHuiShou,Transform>(subTrans);
     			}
     			return this.m_es_rolehuishou;
     		}
     	}

		public ES_RoleQiangHua ES_RoleQiangHua
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RoleQiangHua es = this.m_es_roleqianghua;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleQiangHua");
		    	   this.m_es_roleqianghua = this.AddChild<ES_RoleQiangHua,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghua;
     		}
     	}

		public ToggleGroup E_FunctionSetBtnToggleGroup
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public Toggle E_Type_PropertyToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_PropertyToggle == null )
     			{
		    		this.m_E_Type_PropertyToggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_Property");
     			}
     			return this.m_E_Type_PropertyToggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_equipset = null;
			this.m_E_ZodiacButton = null;
			this.m_E_ZodiacImage = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_rolebag = null;
			this.m_es_roleproperty = null;
			this.m_es_rolegem = null;
			this.m_es_rolehuishou = null;
			this.m_es_roleqianghua = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_PropertyToggle = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_EquipSet> m_es_equipset = null;
		private Button m_E_ZodiacButton = null;
		private Image m_E_ZodiacImage = null;
		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_RoleBag> m_es_rolebag = null;
		private EntityRef<ES_RoleProperty> m_es_roleproperty = null;
		private EntityRef<ES_RoleGem> m_es_rolegem = null;
		private EntityRef<ES_RoleHuiShou> m_es_rolehuishou = null;
		private EntityRef<ES_RoleQiangHua> m_es_roleqianghua = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Toggle m_E_Type_PropertyToggle = null;
		public Transform uiTransform = null;
	}
}
