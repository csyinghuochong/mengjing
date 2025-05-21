
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSeason))]
	[EnableMethod]
	public  class DlgSeasonViewComponent : Entity,IAwake,IDestroy 
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

        public ES_SeasonHome ES_SeasonHome
        {
            get
            {
                ES_SeasonHome es = this.m_es_seasonhome;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SeasonHome.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_seasonhome = this.AddChild<ES_SeasonHome, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_seasonhome;
            }
        }

        public ES_SeasonTask ES_SeasonTask
        {
            get
            {
                ES_SeasonTask es = this.m_es_seasontask;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SeasonTask.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_seasontask = this.AddChild<ES_SeasonTask, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_seasontask;
            }
        }

        public ES_SeasonJingHe ES_SeasonJingHe
        {
            get
            {
                ES_SeasonJingHe es = this.m_es_seasonjinghe;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SeasonJingHe.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_seasonjinghe = this.AddChild<ES_SeasonJingHe, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_seasonjinghe;
            }
        }

        public ES_SeasonStore ES_SeasonStore
        {
            get
            {
                ES_SeasonStore es = this.m_es_seasonstore;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SeasonStore.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_seasonstore = this.AddChild<ES_SeasonStore, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_seasonstore;
            }
        }

        public ES_SeasonTower ES_SeasonTower
        {
            get
            {
                ES_SeasonTower es = this.m_es_seasontower;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SeasonTower.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_seasontower = this.AddChild<ES_SeasonTower, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_seasontower;
            }
        }
		
        public ES_SeasonBoss ES_SeasonBoss
        {
            get
            {
	            ES_SeasonBoss es = this.m_es_seasonboss;
                if (es == null)
                {
                    string path = "Assets/Bundles/UI/Common/ES_SeasonBoss.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_seasonboss = this.AddChild<ES_SeasonBoss, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_seasonboss;
            }
        }


        public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_seasonhome = null;
			this.m_es_seasontask = null;
			this.m_es_seasonjinghe = null;
			this.m_es_seasonstore = null;
			this.m_es_seasontower = null;
            this.m_es_seasonboss = null;
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
		private EntityRef<ES_SeasonHome> m_es_seasonhome = null;
		private EntityRef<ES_SeasonTask> m_es_seasontask = null;
		private EntityRef<ES_SeasonJingHe> m_es_seasonjinghe = null;
		private EntityRef<ES_SeasonStore> m_es_seasonstore = null;
		private EntityRef<ES_SeasonTower> m_es_seasontower = null;
        private EntityRef<ES_SeasonBoss> m_es_seasonboss = null;
        public Transform uiTransform = null;
	}
}
