
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSetting))]
	[EnableMethod]
	public  class DlgSettingViewComponent : Entity,IAwake,IDestroy 
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

		public ES_SettingGame ES_SettingGame
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SettingGame es = this.m_es_settinggame;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SettingGame");
		    	   this.m_es_settinggame = this.AddChild<ES_SettingGame,Transform>(subTrans);
     			}
     			return this.m_es_settinggame;
     		}
     	}

		public ES_SettingTitle ES_SettingTitle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SettingTitle es = this.m_es_settingtitle;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SettingTitle");
		    	   this.m_es_settingtitle = this.AddChild<ES_SettingTitle,Transform>(subTrans);
     			}
     			return this.m_es_settingtitle;
     		}
     	}

		public ES_SettingGuaJi ES_SettingGuaJi
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_SettingGuaJi es = this.m_es_settingguaji;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_SettingGuaJi");
		    	   this.m_es_settingguaji = this.AddChild<ES_SettingGuaJi,Transform>(subTrans);
     			}
     			return this.m_es_settingguaji;
     		}
     	}

		public ES_FashionShow ES_FashionShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_FashionShow es = this.m_es_fashionshow;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_FashionShow");
		    	   this.m_es_fashionshow = this.AddChild<ES_FashionShow,Transform>(subTrans);
     			}
     			return this.m_es_fashionshow;
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
			this.m_es_settinggame = null;
			this.m_es_settingtitle = null;
			this.m_es_settingguaji = null;
			this.m_es_fashionshow = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_SettingGame> m_es_settinggame = null;
		private EntityRef<ES_SettingTitle> m_es_settingtitle = null;
		private EntityRef<ES_SettingGuaJi> m_es_settingguaji = null;
		private EntityRef<ES_FashionShow> m_es_fashionshow = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
