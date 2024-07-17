using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanPasture))]
	[EnableMethod]
	public  class DlgJiaYuanPastureViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
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

		public ES_JiaYuanPasture_A ES_JiaYuanPasture_A
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_JiaYuanPasture_A es = this.m_es_jiayuanpasture_a;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_JiaYuanPasture_A");
		    	   this.m_es_jiayuanpasture_a = this.AddChild<ES_JiaYuanPasture_A,Transform>(subTrans);
     			}
     			return this.m_es_jiayuanpasture_a;
     		}
     	}

		public ES_JiaYuanPasture_B ES_JiaYuanPasture_B
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_JiaYuanPasture_B es = this.m_es_jiayuanpasture_b;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_JiaYuanPasture_B");
		    	   this.m_es_jiayuanpasture_b = this.AddChild<ES_JiaYuanPasture_B,Transform>(subTrans);
     			}
     			return this.m_es_jiayuanpasture_b;
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
			this.m_es_modelshow = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_jiayuanpasture_a = null;
			this.m_es_jiayuanpasture_b = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_JiaYuanPasture_A> m_es_jiayuanpasture_a = null;
		private EntityRef<ES_JiaYuanPasture_B> m_es_jiayuanpasture_b = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
