
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionKeJi))]
	[EnableMethod]
	public  class DlgUnionKeJiViewComponent : Entity,IAwake,IDestroy 
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

		public ES_UnionKeJiResearch ES_UnionKeJiResearch
		{
			get
			{
				ES_UnionKeJiResearch es = this.m_es_unionkejiresearch;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionKeJiResearch.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionkejiresearch = this.AddChild<ES_UnionKeJiResearch, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionkejiresearch;
			}
		}

		public ES_UnionKeJiLearn ES_UnionKeJiLearn
		{
			get
			{
				ES_UnionKeJiLearn es = this.m_es_unionkejilearn;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionKeJiLearn.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionkejilearn = this.AddChild<ES_UnionKeJiLearn, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionkejilearn;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_unionkejiresearch = null;
			this.m_es_unionkejilearn = null;
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
		private EntityRef<ES_UnionKeJiResearch> m_es_unionkejiresearch = null;
		private EntityRef<ES_UnionKeJiLearn> m_es_unionkejilearn = null;
		public Transform uiTransform = null;
	}
}
