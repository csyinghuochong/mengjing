using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgWarehouse))]
	[EnableMethod]
	public  class DlgWarehouseViewComponent : Entity,IAwake,IDestroy 
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

		public ES_WarehouseRole ES_WarehouseRole
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_WarehouseRole es = this.m_es_warehouserole;
     			if( es == null )
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

		        ES_WarehouseAccount es = this.m_es_warehouseaccount;
     			if( es == null )
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

		        ES_WarehouseGem es = this.m_es_warehousegem;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_WarehouseGem");
		    	   this.m_es_warehousegem = this.AddChild<ES_WarehouseGem,Transform>(subTrans);
     			}
     			return this.m_es_warehousegem;
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
			this.m_es_warehouserole = null;
			this.m_es_warehouseaccount = null;
			this.m_es_warehousegem = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_WarehouseRole> m_es_warehouserole = null;
		private EntityRef<ES_WarehouseAccount> m_es_warehouseaccount = null;
		private EntityRef<ES_WarehouseGem> m_es_warehousegem = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
