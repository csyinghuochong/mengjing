
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

		public ES_WarehouseRole ES_WarehouseRole
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_warehouserole == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WarehouseRole");
		    	   this.m_es_warehouserole = this.AddChild<ES_WarehouseRole,Transform>(subTrans);
     			}
     			return this.m_es_warehouserole;
     		}
     	}

		public ES_WarehouseAccount ES_WarehouseAccount
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_warehouseaccount == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WarehouseAccount");
		    	   this.m_es_warehouseaccount = this.AddChild<ES_WarehouseAccount,Transform>(subTrans);
     			}
     			return this.m_es_warehouseaccount;
     		}
     	}

		public ES_WarehouseGem ES_WarehouseGem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_warehousegem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WarehouseGem");
		    	   this.m_es_warehousegem = this.AddChild<ES_WarehouseGem,Transform>(subTrans);
     			}
     			return this.m_es_warehousegem;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_1Toggle = null;
			this.m_E_2Toggle = null;
			this.m_E_3Toggle = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_warehouserole = null;
			this.m_es_warehouseaccount = null;
			this.m_es_warehousegem = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_2Toggle = null;
		private UnityEngine.UI.Toggle m_E_3Toggle = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_WarehouseRole> m_es_warehouserole = null;
		private EntityRef<ES_WarehouseAccount> m_es_warehouseaccount = null;
		private EntityRef<ES_WarehouseGem> m_es_warehousegem = null;
		public Transform uiTransform = null;
	}
}
