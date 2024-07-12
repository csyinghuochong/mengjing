
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSeason))]
	[EnableMethod]
	public  class DlgSeasonViewComponent : Entity,IAwake,IDestroy 
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

		public ES_SeasonHome ES_SeasonHome
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SeasonHome es = this.m_es_seasonhome;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SeasonHome");
		    	   this.m_es_seasonhome = this.AddChild<ES_SeasonHome,Transform>(subTrans);
     			}
     			return this.m_es_seasonhome;
     		}
     	}

		public ES_SeasonTask ES_SeasonTask
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SeasonTask es = this.m_es_seasontask;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SeasonTask");
		    	   this.m_es_seasontask = this.AddChild<ES_SeasonTask,Transform>(subTrans);
     			}
     			return this.m_es_seasontask;
     		}
     	}

		public ES_SeasonJingHe ES_SeasonJingHe
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SeasonJingHe es = this.m_es_seasonjinghe;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SeasonJingHe");
		    	   this.m_es_seasonjinghe = this.AddChild<ES_SeasonJingHe,Transform>(subTrans);
     			}
     			return this.m_es_seasonjinghe;
     		}
     	}

		public ES_SeasonStore ES_SeasonStore
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SeasonStore es = this.m_es_seasonstore;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SeasonStore");
		    	   this.m_es_seasonstore = this.AddChild<ES_SeasonStore,Transform>(subTrans);
     			}
     			return this.m_es_seasonstore;
     		}
     	}

		public ES_SeasonTower ES_SeasonTower
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SeasonTower es = this.m_es_seasontower;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SeasonTower");
		    	   this.m_es_seasontower = this.AddChild<ES_SeasonTower,Transform>(subTrans);
     			}
     			return this.m_es_seasontower;
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
			this.m_es_seasonhome = null;
			this.m_es_seasontask = null;
			this.m_es_seasonjinghe = null;
			this.m_es_seasonstore = null;
			this.m_es_seasontower = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_SeasonHome> m_es_seasonhome = null;
		private EntityRef<ES_SeasonTask> m_es_seasontask = null;
		private EntityRef<ES_SeasonJingHe> m_es_seasonjinghe = null;
		private EntityRef<ES_SeasonStore> m_es_seasonstore = null;
		private EntityRef<ES_SeasonTower> m_es_seasontower = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
