﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTask))]
	[EnableMethod]
	public  class DlgTaskViewComponent : Entity,IAwake,IDestroy 
	{
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

		public ES_TaskDetail ES_TaskDetail
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TaskDetail es = this.m_es_taskdetail;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_TaskDetail");
		    	   this.m_es_taskdetail = this.AddChild<ES_TaskDetail,Transform>(subTrans);
     			}
     			return this.m_es_taskdetail;
     		}
     	}

		public ES_TaskGrowUp ES_TaskGrowUp
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TaskGrowUp es = this.m_es_taskgrowup;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_TaskGrowUp");
		    	   this.m_es_taskgrowup = this.AddChild<ES_TaskGrowUp,Transform>(subTrans);
     			}
     			return this.m_es_taskgrowup;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_taskdetail = null;
			this.m_es_taskgrowup = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_TaskDetail> m_es_taskdetail = null;
		private EntityRef<ES_TaskGrowUp> m_es_taskgrowup = null;
		public Transform uiTransform = null;
	}
}
