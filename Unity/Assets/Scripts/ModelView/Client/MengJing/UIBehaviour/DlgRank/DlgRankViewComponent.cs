
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRank))]
	[EnableMethod]
	public  class DlgRankViewComponent : Entity,IAwake,IDestroy 
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

        public ES_RankShow ES_RankShow
        {
            get
            {
                ES_RankShow es = this.m_es_rankshow;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RankShow.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.AssetList.Add(path);
                    this.m_es_rankshow = this.AddChild<ES_RankShow, Transform>(go.transform);
                }

                return this.m_es_rankshow;
            }
        }

        public ES_RankPet ES_RankPet
        {
            get
            {
                ES_RankPet es = this.m_es_rankpet;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RankPet.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.AssetList.Add(path);
                    this.m_es_rankpet = this.AddChild<ES_RankPet, Transform>(go.transform);
                }

                return this.m_es_rankpet;
            }
        }

        public ES_RankReward ES_RankReward
        {
            get
            {
                ES_RankReward es = this.m_es_rankreward;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RankReward.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.AssetList.Add(path);
                    this.m_es_rankreward = this.AddChild<ES_RankReward, Transform>(go.transform);
                }

                return this.m_es_rankreward;
            }
        }

        public ES_RankPetReward ES_RankPetReward
        {
            get
            {
                ES_RankPetReward es = this.m_es_rankpetreward;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RankPetReward.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.AssetList.Add(path);
                    this.m_es_rankpetreward = this.AddChild<ES_RankPetReward, Transform>(go.transform);
                }

                return this.m_es_rankpetreward;
            }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_rankshow = null;
			this.m_es_rankpet = null;
			this.m_es_rankreward = null;
			this.m_es_rankpetreward = null;
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
		private EntityRef<ES_RankShow> m_es_rankshow = null;
		private EntityRef<ES_RankPet> m_es_rankpet = null;
		private EntityRef<ES_RankReward> m_es_rankreward = null;
		private EntityRef<ES_RankPetReward> m_es_rankpetreward = null;
		public Transform uiTransform = null;
	}
}
