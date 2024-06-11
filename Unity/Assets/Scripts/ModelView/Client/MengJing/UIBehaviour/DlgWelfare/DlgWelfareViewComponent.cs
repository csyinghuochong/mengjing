
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgWelfare))]
	[EnableMethod]
	public  class DlgWelfareViewComponent : Entity,IAwake,IDestroy 
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

		public ES_ActivityLogin ES_ActivityLogin
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_activitylogin == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ActivityLogin");
		    	   this.m_es_activitylogin = this.AddChild<ES_ActivityLogin,Transform>(subTrans);
     			}
     			return this.m_es_activitylogin;
     		}
     	}

		public ES_WelfareTask ES_WelfareTask
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_welfaretask == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WelfareTask");
		    	   this.m_es_welfaretask = this.AddChild<ES_WelfareTask,Transform>(subTrans);
     			}
     			return this.m_es_welfaretask;
     		}
     	}

		public ES_WelfareDraw ES_WelfareDraw
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_welfaredraw == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WelfareDraw");
		    	   this.m_es_welfaredraw = this.AddChild<ES_WelfareDraw,Transform>(subTrans);
     			}
     			return this.m_es_welfaredraw;
     		}
     	}

		public ES_WelfareInvest ES_WelfareInvest
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_welfareinvest == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WelfareInvest");
		    	   this.m_es_welfareinvest = this.AddChild<ES_WelfareInvest,Transform>(subTrans);
     			}
     			return this.m_es_welfareinvest;
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

		public UnityEngine.UI.Toggle E_0Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_0Toggle == null )
     			{
		    		this.m_E_0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_0");
     			}
     			return this.m_E_0Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_1Toggle == null )
     			{
		    		this.m_E_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_1");
     			}
     			return this.m_E_1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_2Toggle == null )
     			{
		    		this.m_E_2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_2");
     			}
     			return this.m_E_2Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_3Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_3Toggle == null )
     			{
		    		this.m_E_3Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_3");
     			}
     			return this.m_E_3Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_4Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_4Toggle == null )
     			{
		    		this.m_E_4Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_4");
     			}
     			return this.m_E_4Toggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_activitylogin = null;
			this.m_es_welfaretask = null;
			this.m_es_welfaredraw = null;
			this.m_es_welfareinvest = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_0Toggle = null;
			this.m_E_1Toggle = null;
			this.m_E_2Toggle = null;
			this.m_E_3Toggle = null;
			this.m_E_4Toggle = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_ActivityLogin> m_es_activitylogin = null;
		private EntityRef<ES_WelfareTask> m_es_welfaretask = null;
		private EntityRef<ES_WelfareDraw> m_es_welfaredraw = null;
		private EntityRef<ES_WelfareInvest> m_es_welfareinvest = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_0Toggle = null;
		private UnityEngine.UI.Toggle m_E_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_2Toggle = null;
		private UnityEngine.UI.Toggle m_E_3Toggle = null;
		private UnityEngine.UI.Toggle m_E_4Toggle = null;
		public Transform uiTransform = null;
	}
}
