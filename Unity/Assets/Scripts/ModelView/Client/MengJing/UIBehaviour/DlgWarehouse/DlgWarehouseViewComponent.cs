
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgWarehouse))]
	[EnableMethod]
	public  class DlgWarehouseViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Toggle E_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_1Toggle == null )
     			{
		    		this.m_E_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_1");
     			}
     			return this.m_E_1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_2Toggle == null )
     			{
		    		this.m_E_2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_2");
     			}
     			return this.m_E_2Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_3Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_3Toggle == null )
     			{
		    		this.m_E_3Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_3");
     			}
     			return this.m_E_3Toggle;
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

		public ES_RoleBag ES_RoleBag
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolebag == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleBag");
		    	   this.m_es_rolebag = this.AddChild<ES_RoleBag,Transform>(subTrans);
     			}
     			return this.m_es_rolebag;
     		}
     	}

		public ES_RoleProperty ES_RoleProperty
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_roleproperty == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleProperty");
		    	   this.m_es_roleproperty = this.AddChild<ES_RoleProperty,Transform>(subTrans);
     			}
     			return this.m_es_roleproperty;
     		}
     	}

		public ES_RoleGem ES_RoleGem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolegem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleGem");
		    	   this.m_es_rolegem = this.AddChild<ES_RoleGem,Transform>(subTrans);
     			}
     			return this.m_es_rolegem;
     		}
     	}

		public ES_RoleHuiShou ES_RoleHuiShou
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_rolehuishou == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleHuiShou");
		    	   this.m_es_rolehuishou = this.AddChild<ES_RoleHuiShou,Transform>(subTrans);
     			}
     			return this.m_es_rolehuishou;
     		}
     	}

		public ES_RoleQiangHua ES_RoleQiangHua
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_roleqianghua == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_RoleQiangHua");
		    	   this.m_es_roleqianghua = this.AddChild<ES_RoleQiangHua,Transform>(subTrans);
     			}
     			return this.m_es_roleqianghua;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_1Toggle = null;
			this.m_E_2Toggle = null;
			this.m_E_3Toggle = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_rolebag = null;
			this.m_es_roleproperty = null;
			this.m_es_rolegem = null;
			this.m_es_rolehuishou = null;
			this.m_es_roleqianghua = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_2Toggle = null;
		private UnityEngine.UI.Toggle m_E_3Toggle = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_RoleBag> m_es_rolebag = null;
		private EntityRef<ES_RoleProperty> m_es_roleproperty = null;
		private EntityRef<ES_RoleGem> m_es_rolegem = null;
		private EntityRef<ES_RoleHuiShou> m_es_rolehuishou = null;
		private EntityRef<ES_RoleQiangHua> m_es_roleqianghua = null;
		public Transform uiTransform = null;
	}
}
