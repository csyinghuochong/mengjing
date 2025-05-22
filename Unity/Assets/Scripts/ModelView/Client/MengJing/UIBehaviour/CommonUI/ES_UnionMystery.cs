
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionMystery : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public List<string> AssetList = new();
		
		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.RectTransform EG_SubViewNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewNodeRectTransform == null )
     			{
		    		this.m_EG_SubViewNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SubViewNode");
     			}
     			return this.m_EG_SubViewNodeRectTransform;
     		}
     	}

		public ES_UnionMystery_A ES_UnionMystery_A
		{
			get
			{
				ES_UnionMystery_A es = this.m_es_unionmystery_a;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionMystery_A.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionmystery_a = this.AddChild<ES_UnionMystery_A, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionmystery_a;
			}
		}

		public ES_UnionMystery_B ES_UnionMystery_B
		{
			get
			{
				ES_UnionMystery_B es = this.m_es_unionmystery_b;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionMystery_B.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionmystery_b = this.AddChild<ES_UnionMystery_B, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionmystery_b;
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
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_EG_SubViewNodeRectTransform = null;
			this.m_es_unionmystery_a = null;
			this.m_es_unionmystery_b = null;
			this.uiTransform = null;
			
			ResourcesLoaderComponent resourcesLoaderComponent = this.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < this.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(this.AssetList[i]);
			}
			this.AssetList.Clear();
			this.AssetList = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_SubViewNodeRectTransform = null;
		private EntityRef<ES_UnionMystery_A> m_es_unionmystery_a = null;
		private EntityRef<ES_UnionMystery_B> m_es_unionmystery_b = null;
		public Transform uiTransform = null;
	}
}
