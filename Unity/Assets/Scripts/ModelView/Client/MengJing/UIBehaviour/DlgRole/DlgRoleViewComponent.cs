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
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_PropertyToggle = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_EquipSet> m_es_equipset = null;
		private Button m_E_ZodiacButton = null;
		private Image m_E_ZodiacImage = null;
		private RectTransform m_EG_SubViewRectTransform = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Toggle m_E_Type_PropertyToggle = null;
		public Transform uiTransform = null;
	}
}
