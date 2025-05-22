
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTower))]
	[EnableMethod]
	public  class DlgTowerViewComponent : Entity,IAwake,IDestroy 
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

		public ES_TowerDungeon ES_TowerDungeon
		{
			get
			{
				ES_TowerDungeon es = this.m_es_towerdungeon;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_TowerDungeon.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_towerdungeon = this.AddChild<ES_TowerDungeon, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_towerdungeon;
			}
		}

		public ES_TowerShop ES_TowerShop
		{
			get
			{
				ES_TowerShop es = this.m_es_towershop;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_TowerShop.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_towershop = this.AddChild<ES_TowerShop, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_towershop;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_towerdungeon = null;
			this.m_es_towershop = null;
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
		private EntityRef<ES_TowerDungeon> m_es_towerdungeon = null;
		private EntityRef<ES_TowerShop> m_es_towershop = null;
		public Transform uiTransform = null;
	}
}
