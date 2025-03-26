
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanDaShi))]
	[EnableMethod]
	public  class DlgJiaYuanDaShiViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public ES_JiaYuanDaShiPro ES_JiaYuanDaShiPro
		{
			get
			{
				ES_JiaYuanDaShiPro es = this.m_es_jiayuandashipro;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_JiaYuanDaShiPro.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_jiayuandashipro = this.AddChild<ES_JiaYuanDaShiPro, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_jiayuandashipro;
			}
		}

		public ES_JiaYuanDaShiShow ES_JiaYuanDaShiShow
		{
			get
			{
				ES_JiaYuanDaShiShow es = this.m_es_jiayuandashishow;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_JiaYuanDaShiShow.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_jiayuandashishow = this.AddChild<ES_JiaYuanDaShiShow, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_jiayuandashishow;
			}
		}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_jiayuandashipro = null;
			this.m_es_jiayuandashishow = null;
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
		private EntityRef<ES_JiaYuanDaShiPro> m_es_jiayuandashipro = null;
		private EntityRef<ES_JiaYuanDaShiShow> m_es_jiayuandashishow = null;
		public Transform uiTransform = null;
	}
}
