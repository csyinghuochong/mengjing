﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgWatch))]
	[EnableMethod]
	public  class DlgWatchViewComponent : Entity,IAwake,IDestroy 
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

		public ES_WatchEquip ES_WatchEquip
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_WatchEquip es = this.m_es_watchequip;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WatchEquip");
		    	   this.m_es_watchequip = this.AddChild<ES_WatchEquip,Transform>(subTrans);
     			}
     			return this.m_es_watchequip;
     		}
     	}

		public ES_WatchPet ES_WatchPet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_WatchPet es = this.m_es_watchpet;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WatchPet");
		    	   this.m_es_watchpet = this.AddChild<ES_WatchPet,Transform>(subTrans);
     			}
     			return this.m_es_watchpet;
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
			this.m_es_watchequip = null;
			this.m_es_watchpet = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_WatchEquip> m_es_watchequip = null;
		private EntityRef<ES_WatchPet> m_es_watchpet = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
