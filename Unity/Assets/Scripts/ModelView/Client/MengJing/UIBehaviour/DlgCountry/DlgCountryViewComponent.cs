
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCountry))]
	[EnableMethod]
	public  class DlgCountryViewComponent : Entity,IAwake,IDestroy 
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

        public ES_CountryTask ES_CountryTask
        {
            get
            {
                ES_CountryTask es = this.m_es_countrytask;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_CountryTask.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_countrytask = this.AddChild<ES_CountryTask, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_countrytask;
            }
        }

        public ES_CountryHuoDong ES_CountryHuoDong
        {
            get
            {
                ES_CountryHuoDong es = this.m_es_countryhuodong;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_CountryHuoDong.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_countryhuodong = this.AddChild<ES_CountryHuoDong, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_countryhuodong;
            }
        }
        
        public ES_PetMatch ES_PetMatch
        {
	        get
	        {
		        ES_PetMatch es = this.m_es_petmatch;
		        if (es == null)
		        {
			        string path = "Assets/Bundles/UI/Common/ES_PetMatch.prefab";
			        GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
			        GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
			        go.SetActive(true);
			        this.AssetList.Add(path);
			        this.m_es_petmatch = this.AddChild<ES_PetMatch, Transform>(go.transform);
			        go.SetActive(false);
		        }

		        return this.m_es_petmatch;
	        }
        }

        public ES_ActivitySingIn ES_ActivitySingIn
        {
            get
            {
                ES_ActivitySingIn es = this.m_es_activitysingin;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_ActivitySingIn.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_activitysingin = this.AddChild<ES_ActivitySingIn, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_activitysingin;
            }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_countrytask = null;
			this.m_es_countryhuodong = null;
			this.m_es_activitysingin = null;
			this.m_es_petmatch = null;
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
		private EntityRef<ES_CountryTask> m_es_countrytask = null;
		private EntityRef<ES_CountryHuoDong> m_es_countryhuodong = null;
		private EntityRef<ES_ActivitySingIn> m_es_activitysingin = null;
		private EntityRef<ES_PetMatch> m_es_petmatch = null;
		public Transform uiTransform = null;
	}
}
