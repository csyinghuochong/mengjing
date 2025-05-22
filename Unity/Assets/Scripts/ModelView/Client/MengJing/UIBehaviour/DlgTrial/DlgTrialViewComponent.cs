
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTrial))]
	[EnableMethod]
	public  class DlgTrialViewComponent : Entity,IAwake,IDestroy 
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

		public ES_TrialDungeon ES_TrialDungeon
		{
			get
			{
				ES_TrialDungeon es = this.m_es_trialdungeon;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_TrialDungeon.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_trialdungeon = this.AddChild<ES_TrialDungeon, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_trialdungeon;
			}
		}

		public ES_TrialRank ES_TrialRank
		{
			get
			{
				ES_TrialRank es = this.m_es_trialrank;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_TrialRank.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_trialrank = this.AddChild<ES_TrialRank, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_trialrank;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_trialdungeon = null;
			this.m_es_trialrank = null;
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
		private EntityRef<ES_TrialDungeon> m_es_trialdungeon = null;
		private EntityRef<ES_TrialRank> m_es_trialrank = null;
		public Transform uiTransform = null;
	}
}
