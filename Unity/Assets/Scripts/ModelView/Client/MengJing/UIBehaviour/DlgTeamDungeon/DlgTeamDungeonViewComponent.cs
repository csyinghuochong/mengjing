using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTeamDungeon))]
	[EnableMethod]
	public  class DlgTeamDungeonViewComponent : Entity,IAwake,IDestroy 
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

		public ES_TeamDungeonList ES_TeamDungeonList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TeamDungeonList es = this.m_es_teamdungeonlist;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_TeamDungeonList");
		    	   this.m_es_teamdungeonlist = this.AddChild<ES_TeamDungeonList,Transform>(subTrans);
     			}
     			return this.m_es_teamdungeonlist;
     		}
     	}

		public ES_TeamDungeonMy ES_TeamDungeonMy
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TeamDungeonMy es = this.m_es_teamdungeonmy;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_TeamDungeonMy");
		    	   this.m_es_teamdungeonmy = this.AddChild<ES_TeamDungeonMy,Transform>(subTrans);
     			}
     			return this.m_es_teamdungeonmy;
     		}
     	}

		public ES_TeamDungeonShop ES_TeamDungeonShop
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_TeamDungeonShop es = this.m_es_teamdungeonshop;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_TeamDungeonShop");
		    	   this.m_es_teamdungeonshop = this.AddChild<ES_TeamDungeonShop,Transform>(subTrans);
     			}
     			return this.m_es_teamdungeonshop;
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
			this.m_es_teamdungeonlist = null;
			this.m_es_teamdungeonmy = null;
			this.m_es_teamdungeonshop = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_TeamDungeonList> m_es_teamdungeonlist = null;
		private EntityRef<ES_TeamDungeonMy> m_es_teamdungeonmy = null;
		private EntityRef<ES_TeamDungeonShop> m_es_teamdungeonshop = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
