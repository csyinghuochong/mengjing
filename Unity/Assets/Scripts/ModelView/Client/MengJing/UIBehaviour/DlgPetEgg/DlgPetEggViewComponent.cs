
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetEgg))]
	[EnableMethod]
	public  class DlgPetEggViewComponent : Entity,IAwake,IDestroy 
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

        public ES_PetEggList ES_PetEggList
        {
            get
            {
                ES_PetEggList es = this.m_es_petegglist;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PetEggList.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_petegglist = this.AddChild<ES_PetEggList, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_petegglist;
            }
        }

        public ES_PetEggDuiHuan ES_PetEggDuiHuan
        {
            get
            {
                ES_PetEggDuiHuan es = this.m_es_peteggduihuan;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PetEggDuiHuan.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_peteggduihuan = this.AddChild<ES_PetEggDuiHuan, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_peteggduihuan;
            }
        }

        public ES_PetEggChouKa ES_PetEggChouKa
        {
            get
            {
                ES_PetEggChouKa es = this.m_es_peteggchouka;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PetEggChouKa.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_peteggchouka = this.AddChild<ES_PetEggChouKa, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_peteggchouka;
            }
        }

        public ES_PetHeXinChouKa ES_PetHeXinChouKa
        {
            get
            {
                ES_PetHeXinChouKa es = this.m_es_pethexinchouka;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_PetHeXinChouKa.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_pethexinchouka = this.AddChild<ES_PetHeXinChouKa, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_pethexinchouka;
            }
        }
        
        public ES_PetChouKa ES_PetChouKa
        {
	        get
	        {
		        ES_PetChouKa es = this.m_es_petchouka;
		        if (es == null)
		        {
			        string path = "Assets/Bundles/UI/Common/ES_PetChouKa.prefab";
			        GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
			        GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
			        go.SetActive(true);
			        this.AssetList.Add(path);
			        this.m_es_petchouka = this.AddChild<ES_PetChouKa, Transform>(go.transform);
			        go.SetActive(false);
		        }

		        return this.m_es_petchouka;
	        }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_petegglist = null;
			this.m_es_peteggduihuan = null;
			this.m_es_peteggchouka = null;
			this.m_es_pethexinchouka = null;
			this.m_es_petchouka = null;
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
		private EntityRef<ES_PetEggList> m_es_petegglist = null;
		private EntityRef<ES_PetEggDuiHuan> m_es_peteggduihuan = null;
		private EntityRef<ES_PetEggChouKa> m_es_peteggchouka = null;
		private EntityRef<ES_PetHeXinChouKa> m_es_pethexinchouka = null;
		private EntityRef<ES_PetChouKa> m_es_petchouka = null;
		public Transform uiTransform = null;
	}
}
