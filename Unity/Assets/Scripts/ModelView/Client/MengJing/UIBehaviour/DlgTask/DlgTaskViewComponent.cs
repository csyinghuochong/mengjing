
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTask))]
	[EnableMethod]
	public  class DlgTaskViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubView");
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

		public ES_TaskDetail ES_TaskDetail
		{
			get
			{
				ES_TaskDetail es = this.m_es_taskdetail;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_TaskDetail.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_taskdetail = this.AddChild<ES_TaskDetail, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_taskdetail;
			}
		}

		public ES_TaskGrowUp ES_TaskGrowUp
		{
			get
			{
				ES_TaskGrowUp es = this.m_es_taskgrowup;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_TaskGrowUp.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_taskgrowup = this.AddChild<ES_TaskGrowUp, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_taskgrowup;
			}
		}

		public ES_TaskShop ES_TaskShop
		{
			get
			{
				ES_TaskShop es = this.m_es_taskshop;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_TaskShop.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_taskshop = this.AddChild<ES_TaskShop, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_taskshop;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_taskdetail = null;
			this.m_es_taskgrowup = null;
			this.m_es_taskshop = null;
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
		private EntityRef<ES_TaskDetail> m_es_taskdetail = null;
		private EntityRef<ES_TaskGrowUp> m_es_taskgrowup = null;
		private EntityRef<ES_TaskShop> m_es_taskshop = null;
		public Transform uiTransform = null;
	}
}
