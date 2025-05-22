
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgWarehouse))]
	[EnableMethod]
	public  class DlgWarehouseViewComponent : Entity,IAwake,IDestroy 
	{
		public List<string> AssetList = new();
		
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
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_SubView");
     			}
     			return this.m_EG_SubViewRectTransform;
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

        public ES_WarehouseRole ES_WarehouseRole
        {
            get
            {
                ES_WarehouseRole es = this.m_es_warehouserole;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_WarehouseRole.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_warehouserole = this.AddChild<ES_WarehouseRole, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_warehouserole;
            }
        }

        public ES_WarehouseAccount ES_WarehouseAccount
        {
            get
            {
                ES_WarehouseAccount es = this.m_es_warehouseaccount;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_WarehouseAccount.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_warehouseaccount = this.AddChild<ES_WarehouseAccount, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_warehouseaccount;
            }
        }

        public ES_WarehouseGem ES_WarehouseGem
        {
            get
            {
                ES_WarehouseGem es = this.m_es_warehousegem;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_WarehouseGem.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_warehousegem = this.AddChild<ES_WarehouseGem, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_warehousegem;
            }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_warehouserole = null;
			this.m_es_warehouseaccount = null;
			this.m_es_warehousegem = null;
			this.uiTransform = null;
			
			ResourcesLoaderComponent resourcesLoaderComponent = this.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < this.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(this.AssetList[i]);
			}
			this.AssetList.Clear();
			this.AssetList = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_WarehouseRole> m_es_warehouserole = null;
		private EntityRef<ES_WarehouseAccount> m_es_warehouseaccount = null;
		private EntityRef<ES_WarehouseGem> m_es_warehousegem = null;
		public Transform uiTransform = null;
	}
}
