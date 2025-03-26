
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgDonation))]
	[EnableMethod]
	public  class DlgDonationViewComponent : Entity,IAwake,IDestroy 
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

        public ES_DonationShow ES_DonationShow
        {
            get
            {
                ES_DonationShow es = this.m_es_donationshow;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_DonationShow.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_donationshow = this.AddChild<ES_DonationShow, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_donationshow;
            }
        }

        public ES_DonationUnion ES_DonationUnion
        {
            get
            {
                ES_DonationUnion es = this.m_es_donationunion;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_DonationUnion.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_donationunion = this.AddChild<ES_DonationUnion, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_donationunion;
            }
        }

        public ES_RankUnion ES_RankUnion
        {
            get
            {
                ES_RankUnion es = this.m_es_rankunion;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RankUnion.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rankunion = this.AddChild<ES_RankUnion, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rankunion;
            }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_donationshow = null;
			this.m_es_donationunion = null;
			this.m_es_rankunion = null;
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
		private EntityRef<ES_DonationShow> m_es_donationshow = null;
		private EntityRef<ES_DonationUnion> m_es_donationunion = null;
		private EntityRef<ES_RankUnion> m_es_rankunion = null;
		public Transform uiTransform = null;
	}
}
