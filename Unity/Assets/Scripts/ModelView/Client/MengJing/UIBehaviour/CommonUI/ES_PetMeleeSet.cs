
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetMeleeSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy
	{
		public GameObject MainPetItem;
		public GameObject AssistPetItem;
		public GameObject SkillItem;
		
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

		public UnityEngine.RectTransform EG_SetMainRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SetMainRectTransform == null )
     			{
		    		this.m_EG_SetMainRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SetMain");
     			}
     			return this.m_EG_SetMainRectTransform;
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
			this.m_EG_SetMainRectTransform = null;
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
		private UnityEngine.RectTransform m_EG_SetMainRectTransform = null;
		public Transform uiTransform = null;
	}
}
