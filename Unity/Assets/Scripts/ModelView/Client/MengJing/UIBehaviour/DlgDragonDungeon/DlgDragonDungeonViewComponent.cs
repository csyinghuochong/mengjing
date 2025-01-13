
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDragonDungeon))]
	[EnableMethod]
	public  class DlgDragonDungeonViewComponent : Entity,IAwake,IDestroy 
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

		public ES_DragonDungeonList ES_DragonDungeonList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_DragonDungeonList es = this.m_es_dragondungeonlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_DragonDungeonList");
		    	   this.m_es_dragondungeonlist = this.AddChild<ES_DragonDungeonList,Transform>(subTrans);
     			}
     			return this.m_es_dragondungeonlist;
     		}
     	}

		public ES_DragonDungeonMy ES_DragonDungeonMy
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_DragonDungeonMy es = this.m_es_dragondungeonmy;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_DragonDungeonMy");
		    	   this.m_es_dragondungeonmy = this.AddChild<ES_DragonDungeonMy,Transform>(subTrans);
     			}
     			return this.m_es_dragondungeonmy;
     		}
     	}

		public ES_DragonDungeonShop ES_DragonDungeonShop
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_DragonDungeonShop es = this.m_es_dragondungeonshop;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_DragonDungeonShop");
		    	   this.m_es_dragondungeonshop = this.AddChild<ES_DragonDungeonShop,Transform>(subTrans);
     			}
     			return this.m_es_dragondungeonshop;
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
			this.m_es_dragondungeonlist = null;
			this.m_es_dragondungeonmy = null;
			this.m_es_dragondungeonshop = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_DragonDungeonList> m_es_dragondungeonlist = null;
		private EntityRef<ES_DragonDungeonMy> m_es_dragondungeonmy = null;
		private EntityRef<ES_DragonDungeonShop> m_es_dragondungeonshop = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
