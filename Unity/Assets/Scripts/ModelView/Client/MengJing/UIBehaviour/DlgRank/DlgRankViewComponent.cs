﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRank))]
	[EnableMethod]
	public  class DlgRankViewComponent : Entity,IAwake,IDestroy 
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

		public ES_RankShow ES_RankShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RankShow es = this.m_es_rankshow;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RankShow");
		    	   this.m_es_rankshow = this.AddChild<ES_RankShow,Transform>(subTrans);
     			}
     			return this.m_es_rankshow;
     		}
     	}

		public ES_RankPet ES_RankPet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RankPet es = this.m_es_rankpet;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RankPet");
		    	   this.m_es_rankpet = this.AddChild<ES_RankPet,Transform>(subTrans);
     			}
     			return this.m_es_rankpet;
     		}
     	}

		public ES_RankReward ES_RankReward
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RankReward es = this.m_es_rankreward;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RankReward");
		    	   this.m_es_rankreward = this.AddChild<ES_RankReward,Transform>(subTrans);
     			}
     			return this.m_es_rankreward;
     		}
     	}

		public ES_RankPetReward ES_RankPetReward
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_RankPetReward es = this.m_es_rankpetreward;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RankPetReward");
		    	   this.m_es_rankpetreward = this.AddChild<ES_RankPetReward,Transform>(subTrans);
     			}
     			return this.m_es_rankpetreward;
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
			this.m_es_rankshow = null;
			this.m_es_rankpet = null;
			this.m_es_rankreward = null;
			this.m_es_rankpetreward = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_RankShow> m_es_rankshow = null;
		private EntityRef<ES_RankPet> m_es_rankpet = null;
		private EntityRef<ES_RankReward> m_es_rankreward = null;
		private EntityRef<ES_RankPetReward> m_es_rankpetreward = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
