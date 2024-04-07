
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgChengJiu))]
	[EnableMethod]
	public  class DlgChengJiuViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Toggle E_RewardToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RewardToggle == null )
     			{
		    		this.m_E_RewardToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Reward");
     			}
     			return this.m_E_RewardToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_ListToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ListToggle == null )
     			{
		    		this.m_E_ListToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_List");
     			}
     			return this.m_E_ListToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_JingLingToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingLingToggle == null )
     			{
		    		this.m_E_JingLingToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_JingLing");
     			}
     			return this.m_E_JingLingToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_TuJianToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TuJianToggle == null )
     			{
		    		this.m_E_TuJianToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_TuJian");
     			}
     			return this.m_E_TuJianToggle;
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

		public ES_ChengJiuReward ES_ChengJiuReward
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_chengjiureward == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_ChengJiuReward");
		    	   this.m_es_chengjiureward = this.AddChild<ES_ChengJiuReward,Transform>(subTrans);
     			}
     			return this.m_es_chengjiureward;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_RewardToggle = null;
			this.m_E_ListToggle = null;
			this.m_E_JingLingToggle = null;
			this.m_E_TuJianToggle = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_chengjiureward = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_RewardToggle = null;
		private UnityEngine.UI.Toggle m_E_ListToggle = null;
		private UnityEngine.UI.Toggle m_E_JingLingToggle = null;
		private UnityEngine.UI.Toggle m_E_TuJianToggle = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_ChengJiuReward> m_es_chengjiureward = null;
		public Transform uiTransform = null;
	}
}
