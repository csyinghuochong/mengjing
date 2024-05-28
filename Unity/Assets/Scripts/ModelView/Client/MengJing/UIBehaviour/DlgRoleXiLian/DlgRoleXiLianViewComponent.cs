
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRoleXiLian))]
	[EnableMethod]
	public  class DlgRoleXiLianViewComponent : Entity,IAwake,IDestroy 
	{
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

		public ES_RoleXiLianShow ES_RoleXiLianShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolexilianshow == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleXiLianShow");
		    	   this.m_es_rolexilianshow = this.AddChild<ES_RoleXiLianShow,Transform>(subTrans);
     			}
     			return this.m_es_rolexilianshow;
     		}
     	}

		public ES_RoleXiLianLevel ES_RoleXiLianLevel
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolexilianlevel == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleXiLianLevel");
		    	   this.m_es_rolexilianlevel = this.AddChild<ES_RoleXiLianLevel,Transform>(subTrans);
     			}
     			return this.m_es_rolexilianlevel;
     		}
     	}

		public ES_RoleXiLianSkill ES_RoleXiLianSkill
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolexilianskill == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleXiLianSkill");
		    	   this.m_es_rolexilianskill = this.AddChild<ES_RoleXiLianSkill,Transform>(subTrans);
     			}
     			return this.m_es_rolexilianskill;
     		}
     	}

		public ES_RoleXiLianTransfer ES_RoleXiLianTransfer
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolexiliantransfer == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleXiLianTransfer");
		    	   this.m_es_rolexiliantransfer = this.AddChild<ES_RoleXiLianTransfer,Transform>(subTrans);
     			}
     			return this.m_es_rolexiliantransfer;
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

		public UnityEngine.UI.Toggle E_XiLianToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianToggle == null )
     			{
		    		this.m_E_XiLianToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_XiLian");
     			}
     			return this.m_E_XiLianToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_DaShiToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DaShiToggle == null )
     			{
		    		this.m_E_DaShiToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_DaShi");
     			}
     			return this.m_E_DaShiToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_SkillToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillToggle == null )
     			{
		    		this.m_E_SkillToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Skill");
     			}
     			return this.m_E_SkillToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_TransferToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TransferToggle == null )
     			{
		    		this.m_E_TransferToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Transfer");
     			}
     			return this.m_E_TransferToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_InheritToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InheritToggle == null )
     			{
		    		this.m_E_InheritToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Inherit");
     			}
     			return this.m_E_InheritToggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_rolexilianshow = null;
			this.m_es_rolexilianlevel = null;
			this.m_es_rolexilianskill = null;
			this.m_es_rolexiliantransfer = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_XiLianToggle = null;
			this.m_E_DaShiToggle = null;
			this.m_E_SkillToggle = null;
			this.m_E_TransferToggle = null;
			this.m_E_InheritToggle = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_RoleXiLianShow> m_es_rolexilianshow = null;
		private EntityRef<ES_RoleXiLianLevel> m_es_rolexilianlevel = null;
		private EntityRef<ES_RoleXiLianSkill> m_es_rolexilianskill = null;
		private EntityRef<ES_RoleXiLianTransfer> m_es_rolexiliantransfer = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_XiLianToggle = null;
		private UnityEngine.UI.Toggle m_E_DaShiToggle = null;
		private UnityEngine.UI.Toggle m_E_SkillToggle = null;
		private UnityEngine.UI.Toggle m_E_TransferToggle = null;
		private UnityEngine.UI.Toggle m_E_InheritToggle = null;
		public Transform uiTransform = null;
	}
}
