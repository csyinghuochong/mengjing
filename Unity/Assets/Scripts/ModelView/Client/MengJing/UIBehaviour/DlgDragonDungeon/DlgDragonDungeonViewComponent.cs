
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDragonDungeon))]
	[EnableMethod]
	public  class DlgDragonDungeonViewComponent : Entity,IAwake,IDestroy 
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
		
		public ES_DragonDungeonList ES_DragonDungeonList
		{
			get
			{
				ES_DragonDungeonList es = this.m_es_dragondungeonlist;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_DragonDungeonList.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_dragondungeonlist = this.AddChild<ES_DragonDungeonList, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_dragondungeonlist;
			}
		}
		
		public ES_DragonDungeonMy ES_DragonDungeonMy
		{
			get
			{
				ES_DragonDungeonMy es = this.m_es_dragondungeonmy;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_DragonDungeonMy.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_dragondungeonmy = this.AddChild<ES_DragonDungeonMy, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_dragondungeonmy;
			}
		}
		
		public ES_DragonDungeonShop ES_DragonDungeonShop
		{
			get
			{
				ES_DragonDungeonShop es = this.m_es_dragondungeonshop;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_DragonDungeonShop.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_dragondungeonshop = this.AddChild<ES_DragonDungeonShop, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_dragondungeonshop;
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

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_dragondungeonlist = null;
			this.m_es_dragondungeonmy = null;
			this.m_es_dragondungeonshop = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
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
		private EntityRef<ES_DragonDungeonList> m_es_dragondungeonlist = null;
		private EntityRef<ES_DragonDungeonMy> m_es_dragondungeonmy = null;
		private EntityRef<ES_DragonDungeonShop> m_es_dragondungeonshop = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		public Transform uiTransform = null;
	}
}
