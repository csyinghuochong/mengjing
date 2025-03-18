using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgUnion))]
	[EnableMethod]
	public  class DlgUnionViewComponent : Entity,IAwake,IDestroy 
	{
		
		public List<string> AssetList = new();
		
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
		    		this.m_EG_SubViewNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubViewNode");
     			}
     			return this.m_EG_SubViewNodeRectTransform;
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

		public ES_UnionShow ES_UnionShow
		{
			get
			{
				ES_UnionShow es = this.m_es_unionshow;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionShow.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(false);
					this.AssetList.Add(path);
					this.m_es_unionshow = this.AddChild<ES_UnionShow, Transform>(go.transform);
				}

				return this.m_es_unionshow;
			}
		}

		public ES_UnionMy ES_UnionMy
		{
			get
			{
				ES_UnionMy es = this.m_es_unionmy;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionMy.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(false);
					this.AssetList.Add(path);
					this.m_es_unionmy = this.AddChild<ES_UnionMy, Transform>(go.transform);
				}

				return this.m_es_unionmy;
			}
		}
        
		public void DestroyWidget()
		{
			this.m_EG_SubViewNodeRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_unionshow = null;
			this.m_es_unionmy = null;
			this.uiTransform = null;
			
			ResourcesLoaderComponent resourcesLoaderComponent = this.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < this.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(this.AssetList[i]);
			}
			this.AssetList.Clear();
			this.AssetList = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewNodeRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_UnionShow> m_es_unionshow = null;
		private EntityRef<ES_UnionMy> m_es_unionmy = null;
        public Transform uiTransform = null;
	}
}
