using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgActivity))]
	[EnableMethod]
	public  class DlgActivityViewComponent : Entity,IAwake,IDestroy 
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

		public ES_ActivityYueKa ES_ActivityYueKa
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ActivityYueKa es = this.m_es_activityyueka;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ActivityYueKa");
		    	   this.m_es_activityyueka = this.AddChild<ES_ActivityYueKa,Transform>(subTrans);
     			}
     			return this.m_es_activityyueka;
     		}
     	}

		public ES_ActivityMaoXian ES_ActivityMaoXian
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ActivityMaoXian es = this.m_es_activitymaoxian;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ActivityMaoXian");
		    	   this.m_es_activitymaoxian = this.AddChild<ES_ActivityMaoXian,Transform>(subTrans);
     			}
     			return this.m_es_activitymaoxian;
     		}
     	}

		public ES_ActivityToken ES_ActivityToken
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ActivityToken es = this.m_es_activitytoken;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ActivityToken");
		    	   this.m_es_activitytoken = this.AddChild<ES_ActivityToken,Transform>(subTrans);
     			}
     			return this.m_es_activitytoken;
     		}
     	}

		public ES_ActivityTeHui ES_ActivityTeHui
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ActivityTeHui es = this.m_es_activitytehui;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ActivityTeHui");
		    	   this.m_es_activitytehui = this.AddChild<ES_ActivityTeHui,Transform>(subTrans);
     			}
     			return this.m_es_activitytehui;
     		}
     	}

		public ES_ActivitySingleRecharge ES_ActivitySingleRecharge
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ActivitySingleRecharge es = this.m_es_activitysinglerecharge;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ActivitySingleRecharge");
		    	   this.m_es_activitysinglerecharge = this.AddChild<ES_ActivitySingleRecharge,Transform>(subTrans);
     			}
     			return this.m_es_activitysinglerecharge;
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

		public Toggle E_Type_4Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_4Toggle == null )
     			{
		    		this.m_E_Type_4Toggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_4");
     			}
     			return this.m_E_Type_4Toggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_activityyueka = null;
			this.m_es_activitymaoxian = null;
			this.m_es_activitytoken = null;
			this.m_es_activitytehui = null;
			this.m_es_activitysinglerecharge = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_4Toggle = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_ActivityYueKa> m_es_activityyueka = null;
		private EntityRef<ES_ActivityMaoXian> m_es_activitymaoxian = null;
		private EntityRef<ES_ActivityToken> m_es_activitytoken = null;
		private EntityRef<ES_ActivityTeHui> m_es_activitytehui = null;
		private EntityRef<ES_ActivitySingleRecharge> m_es_activitysinglerecharge = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Toggle m_E_Type_4Toggle = null;
		public Transform uiTransform = null;
	}
}
