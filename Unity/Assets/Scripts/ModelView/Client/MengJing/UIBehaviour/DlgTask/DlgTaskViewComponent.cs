
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTask))]
	[EnableMethod]
	public  class DlgTaskViewComponent : Entity,IAwake,IDestroy 
	{
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

		public UnityEngine.UI.Toggle E_BagToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagToggle == null )
     			{
		    		this.m_E_BagToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Bag");
     			}
     			return this.m_E_BagToggle;
     		}
     	}

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

		public ES_TaskDetail ES_TaskDetail
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_taskdetail == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_TaskDetail");
		    	   this.m_es_taskdetail = this.AddChild<ES_TaskDetail,Transform>(subTrans);
     			}
     			return this.m_es_taskdetail;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_BagToggle = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_taskdetail = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_BagToggle = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_TaskDetail> m_es_taskdetail = null;
		public Transform uiTransform = null;
	}
}
