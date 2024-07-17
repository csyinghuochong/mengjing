using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgWelfare))]
	[EnableMethod]
	public  class DlgWelfareViewComponent : Entity,IAwake,IDestroy 
	{
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

		public ES_ActivityLogin ES_ActivityLogin
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ActivityLogin es = this.m_es_activitylogin;
     			if( es == null )
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

		        ES_WelfareTask es = this.m_es_welfaretask;
     			if( es == null )
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

		        ES_WelfareDraw es = this.m_es_welfaredraw;
     			if( es == null )
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

		        ES_WelfareInvest es = this.m_es_welfareinvest;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WelfareInvest");
		    	   this.m_es_welfareinvest = this.AddChild<ES_WelfareInvest,Transform>(subTrans);
     			}
     			return this.m_es_welfareinvest;
     		}
     	}

		public ES_WelfareDraw2 ES_WelfareDraw2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_WelfareDraw2 es = this.m_es_welfaredraw2;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WelfareDraw2");
		    	   this.m_es_welfaredraw2 = this.AddChild<ES_WelfareDraw2,Transform>(subTrans);
     			}
     			return this.m_es_welfaredraw2;
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

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_activitylogin = null;
			this.m_es_welfaretask = null;
			this.m_es_welfaredraw = null;
			this.m_es_welfareinvest = null;
			this.m_es_welfaredraw2 = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_ActivityLogin> m_es_activitylogin = null;
		private EntityRef<ES_WelfareTask> m_es_welfaretask = null;
		private EntityRef<ES_WelfareDraw> m_es_welfaredraw = null;
		private EntityRef<ES_WelfareInvest> m_es_welfareinvest = null;
		private EntityRef<ES_WelfareDraw2> m_es_welfaredraw2 = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
