
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivitySingIn : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<string> AssetList = new();
		
		public ES_ActivitySingInFree ES_ActivitySingInFree
		{
			get
			{
				ES_ActivitySingInFree es = this.m_es_activitySingInFree;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_ActivitySingInFree.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_PanelRootRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_activitySingInFree = this.AddChild<ES_ActivitySingInFree, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_activitySingInFree;
			}
		}
		
		public ES_ActivitySingInVIP ES_ActivitySingInVip
		{
			get
			{
				ES_ActivitySingInVIP es = this.m_es_activitySingInPaid;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_ActivitySingInVIP.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_PanelRootRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_activitySingInPaid = this.AddChild<ES_ActivitySingInVIP, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_activitySingInPaid;
			}
		}
		
		public UnityEngine.UI.ToggleGroup E_TypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TypeSetToggleGroup == null )
     			{
		    		this.m_E_TypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_TypeSet");
     			}
     			return this.m_E_TypeSetToggleGroup;
     		}
     	}

		public UnityEngine.RectTransform EG_PanelRootRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PanelRootRectTransform == null )
     			{
		    		this.m_EG_PanelRootRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PanelRoot");
     			}
     			return this.m_EG_PanelRootRectTransform;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_es_activitySingInFree = null;
			this.m_es_activitySingInPaid = null;
			this.m_E_TypeSetToggleGroup = null;
			this.m_EG_PanelRootRectTransform = null;
			this.uiTransform = null;
			
			ResourcesLoaderComponent resourcesLoaderComponent = this.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < this.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(this.AssetList[i]);
			}
			this.AssetList.Clear();
			this.AssetList = null;
		}

		private EntityRef<ES_ActivitySingInFree> m_es_activitySingInFree = null;
		private EntityRef<ES_ActivitySingInVIP> m_es_activitySingInPaid = null;
		private UnityEngine.UI.ToggleGroup m_E_TypeSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_PanelRootRectTransform = null;
		public Transform uiTransform = null;
	}
}
