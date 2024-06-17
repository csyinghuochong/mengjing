
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
     			if( this.m_es_seasonhome == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SeasonHome");
		    	   this.m_es_seasonhome = this.AddChild<ES_SeasonHome,Transform>(subTrans);
     			}
     			return this.m_es_seasonhome;
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

		public UnityEngine.UI.Toggle E_HomeToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HomeToggle == null )
     			{
		    		this.m_E_HomeToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Home");
     			}
     			return this.m_E_HomeToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_TaskToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TaskToggle == null )
     			{
		    		this.m_E_TaskToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Task");
     			}
     			return this.m_E_TaskToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_JingHeToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingHeToggle == null )
     			{
		    		this.m_E_JingHeToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_JingHe");
     			}
     			return this.m_E_JingHeToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_ShopToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShopToggle == null )
     			{
		    		this.m_E_ShopToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Shop");
     			}
     			return this.m_E_ShopToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_TowerToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TowerToggle == null )
     			{
		    		this.m_E_TowerToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Tower");
     			}
     			return this.m_E_TowerToggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_seasonhome = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_HomeToggle = null;
			this.m_E_TaskToggle = null;
			this.m_E_JingHeToggle = null;
			this.m_E_ShopToggle = null;
			this.m_E_TowerToggle = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_SeasonHome> m_es_seasonhome = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_HomeToggle = null;
		private UnityEngine.UI.Toggle m_E_TaskToggle = null;
		private UnityEngine.UI.Toggle m_E_JingHeToggle = null;
		private UnityEngine.UI.Toggle m_E_ShopToggle = null;
		private UnityEngine.UI.Toggle m_E_TowerToggle = null;
		public Transform uiTransform = null;
	}
}
