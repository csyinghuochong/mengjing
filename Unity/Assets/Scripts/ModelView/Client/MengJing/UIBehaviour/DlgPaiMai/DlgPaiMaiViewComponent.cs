
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPaiMai))]
	[EnableMethod]
	public  class DlgPaiMaiViewComponent : Entity,IAwake,IDestroy 
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

        public ES_PaiMaiShop ES_PaiMaiShop
        {
            get
            {
                ES_PaiMaiShop es = this.m_es_paimaishop;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PaiMaiShop.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_paimaishop = this.AddChild<ES_PaiMaiShop, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_paimaishop;
            }
        }

        public ES_PaiMaiBuy ES_PaiMaiBuy
        {
            get
            {
                ES_PaiMaiBuy es = this.m_es_paimaibuy;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PaiMaiBuy.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_paimaibuy = this.AddChild<ES_PaiMaiBuy, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_paimaibuy;
            }
        }

        public ES_PaiMaiSell ES_PaiMaiSell
        {
            get
            {
                ES_PaiMaiSell es = this.m_es_paimaisell;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PaiMaiSell.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_paimaisell = this.AddChild<ES_PaiMaiSell, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_paimaisell;
            }
        }

        public ES_PaiMaiDuiHuan ES_PaiMaiDuiHuan
        {
            get
            {
                ES_PaiMaiDuiHuan es = this.m_es_paimaiduihuan;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PaiMaiDuiHuan.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_paimaiduihuan = this.AddChild<ES_PaiMaiDuiHuan, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_paimaiduihuan;
            }
        }
  
        public ES_StallSell ES_StallSell
        {
	        get
	        {
		        ES_StallSell es = this.m_es_StallSell;
		        if (es == null)
		        {
			        string path = "Assets/Bundles/UI/Common/ES_StallSell.prefab";
			        GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
			        GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
			        go.SetActive(true);
			        this.AssetList.Add(path);
			        this.m_es_StallSell = this.AddChild<ES_StallSell, Transform>(go.transform);
			        go.SetActive(false);
		        }
              
		        return this.m_es_StallSell;
	        }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_paimaishop = null;
			this.m_es_paimaibuy = null;
			this.m_es_paimaisell = null;
			this.m_es_paimaiduihuan = null;
			this.m_es_StallSell = null;
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
		private EntityRef<ES_PaiMaiShop> m_es_paimaishop = null;
		private EntityRef<ES_PaiMaiBuy> m_es_paimaibuy = null;
		private EntityRef<ES_PaiMaiSell> m_es_paimaisell = null;
		private EntityRef<ES_PaiMaiDuiHuan> m_es_paimaiduihuan = null;
		private EntityRef<ES_StallSell> m_es_StallSell = null;
		public Transform uiTransform = null;
	}
}
