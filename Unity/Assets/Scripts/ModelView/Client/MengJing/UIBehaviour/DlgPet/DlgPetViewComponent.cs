
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPet))]
	[EnableMethod]
	public  class DlgPetViewComponent : Entity,IAwake,IDestroy 
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

		        public ES_PetList ES_PetList
        {
            get
            {
                ES_PetList es = this.m_es_petlist;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PetList.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_petlist = this.AddChild<ES_PetList, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_petlist;
            }
        }

        public ES_PetHeCheng ES_PetHeCheng
        {
            get
            {
                ES_PetHeCheng es = this.m_es_pethecheng;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PetHeCheng.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_pethecheng = this.AddChild<ES_PetHeCheng, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_pethecheng;
            }
        }

        public ES_PetXiLian ES_PetXiLian
        {
            get
            {
                ES_PetXiLian es = this.m_es_petxilian;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PetXiLian.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_petxilian = this.AddChild<ES_PetXiLian, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_petxilian;
            }
        }

        public ES_PetEcho ES_PetEcho
        {
            get
            {
	            ES_PetEcho es = this.m_es_petecho;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PetEcho.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_petecho = this.AddChild<ES_PetEcho, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_petecho;
            }
        }
        
        public ES_PetZhuangJia ES_PetZhuangJia
        {
	        get
	        {
		        ES_PetZhuangJia es = this.m_es_petezhuangjia;
		        if (es == null)
		        {
			        string path = "Assets/Bundles/UI/Common/ES_PetZhuangJia.prefab";
			        GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
			        GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
			        go.SetActive(true);
			        this.AssetList.Add(path);
			        this.m_es_petezhuangjia = this.AddChild<ES_PetZhuangJia, Transform>(go.transform);
			        go.SetActive(false);
		        }

		        return this.m_es_petezhuangjia;
	        }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_petlist = null;
			this.m_es_pethecheng = null;
			this.m_es_petxilian = null;
			this.m_es_petecho = null;
			this.m_es_petezhuangjia = null;
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
		private EntityRef<ES_PetList> m_es_petlist = null;
		private EntityRef<ES_PetHeCheng> m_es_pethecheng = null;
		private EntityRef<ES_PetXiLian> m_es_petxilian = null;
		private EntityRef<ES_PetEcho> m_es_petecho = null;
		private EntityRef<ES_PetZhuangJia> m_es_petezhuangjia = null;
		public Transform uiTransform = null;
	}
}
