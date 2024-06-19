
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

		public ES_RoleXiLianInherit ES_RoleXiLianInherit
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolexilianinherit == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleXiLianInherit");
		    	   this.m_es_rolexilianinherit = this.AddChild<ES_RoleXiLianInherit,Transform>(subTrans);
     			}
     			return this.m_es_rolexilianinherit;
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

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_rolexilianshow = null;
			this.m_es_rolexilianlevel = null;
			this.m_es_rolexilianskill = null;
			this.m_es_rolexiliantransfer = null;
			this.m_es_rolexilianinherit = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_RoleXiLianShow> m_es_rolexilianshow = null;
		private EntityRef<ES_RoleXiLianLevel> m_es_rolexilianlevel = null;
		private EntityRef<ES_RoleXiLianSkill> m_es_rolexilianskill = null;
		private EntityRef<ES_RoleXiLianTransfer> m_es_rolexiliantransfer = null;
		private EntityRef<ES_RoleXiLianInherit> m_es_rolexilianinherit = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
