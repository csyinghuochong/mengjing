﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgNewYear))]
	[EnableMethod]
	public  class DlgNewYearViewComponent : Entity,IAwake,IDestroy 
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

		public ES_NewYearCollectionWord ES_NewYearCollectionWord
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_NewYearCollectionWord es = this.m_es_newyearcollectionword;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_NewYearCollectionWord");
		    	   this.m_es_newyearcollectionword = this.AddChild<ES_NewYearCollectionWord,Transform>(subTrans);
     			}
     			return this.m_es_newyearcollectionword;
     		}
     	}

		public ES_NewYearMonster ES_NewYearMonster
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_NewYearMonster es = this.m_es_newyearmonster;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_NewYearMonster");
		    	   this.m_es_newyearmonster = this.AddChild<ES_NewYearMonster,Transform>(subTrans);
     			}
     			return this.m_es_newyearmonster;
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
			this.m_es_newyearcollectionword = null;
			this.m_es_newyearmonster = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_NewYearCollectionWord> m_es_newyearcollectionword = null;
		private EntityRef<ES_NewYearMonster> m_es_newyearmonster = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
