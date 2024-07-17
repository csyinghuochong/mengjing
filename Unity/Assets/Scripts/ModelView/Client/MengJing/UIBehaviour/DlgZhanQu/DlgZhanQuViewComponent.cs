using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgZhanQu))]
	[EnableMethod]
	public  class DlgZhanQuViewComponent : Entity,IAwake,IDestroy 
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

		public ES_ZhanQuLevel ES_ZhanQuLevel
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ZhanQuLevel es = this.m_es_zhanqulevel;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ZhanQuLevel");
		    	   this.m_es_zhanqulevel = this.AddChild<ES_ZhanQuLevel,Transform>(subTrans);
     			}
     			return this.m_es_zhanqulevel;
     		}
     	}

		public ES_ZhanQuCombat ES_ZhanQuCombat
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ZhanQuCombat es = this.m_es_zhanqucombat;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ZhanQuCombat");
		    	   this.m_es_zhanqucombat = this.AddChild<ES_ZhanQuCombat,Transform>(subTrans);
     			}
     			return this.m_es_zhanqucombat;
     		}
     	}

		public ES_FirstWin ES_FirstWin
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_FirstWin es = this.m_es_firstwin;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_FirstWin");
		    	   this.m_es_firstwin = this.AddChild<ES_FirstWin,Transform>(subTrans);
     			}
     			return this.m_es_firstwin;
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
			this.m_es_zhanqulevel = null;
			this.m_es_zhanqucombat = null;
			this.m_es_firstwin = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_ZhanQuLevel> m_es_zhanqulevel = null;
		private EntityRef<ES_ZhanQuCombat> m_es_zhanqucombat = null;
		private EntityRef<ES_FirstWin> m_es_firstwin = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
