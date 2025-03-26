
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFenXiang))]
	[EnableMethod]
	public  class DlgFenXiangViewComponent : Entity,IAwake,IDestroy 
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

        public ES_FenXiangSet ES_FenXiangSet
        {
            get
            {
                ES_FenXiangSet es = this.m_es_fenxiangset;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_FenXiangSet.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_fenxiangset = this.AddChild<ES_FenXiangSet, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_fenxiangset;
            }
        }

        public ES_Popularize ES_Popularize
        {
            get
            {
                ES_Popularize es = this.m_es_popularize;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_Popularize.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_popularize = this.AddChild<ES_Popularize, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_popularize;
            }
        }

        public ES_Serial ES_Serial
        {
            get
            {
                ES_Serial es = this.m_es_serial;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_Serial.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_serial = this.AddChild<ES_Serial, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_serial;
            }
        }

        public ES_LunTan ES_LunTan
        {
            get
            {
                ES_LunTan es = this.m_es_luntan;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_LunTan.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_luntan = this.AddChild<ES_LunTan, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_luntan;
            }
        }

        public ES_FenXiangQQAddSet ES_FenXiangQQAddSet
        {
            get
            {
                ES_FenXiangQQAddSet es = this.m_es_fenxiangqqaddset;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_FenXiangQQAddSet.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_fenxiangqqaddset = this.AddChild<ES_FenXiangQQAddSet, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_fenxiangqqaddset;
            }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_fenxiangset = null;
			this.m_es_popularize = null;
			this.m_es_serial = null;
			this.m_es_luntan = null;
			this.m_es_fenxiangqqaddset = null;
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
		private EntityRef<ES_FenXiangSet> m_es_fenxiangset = null;
		private EntityRef<ES_Popularize> m_es_popularize = null;
		private EntityRef<ES_Serial> m_es_serial = null;
		private EntityRef<ES_LunTan> m_es_luntan = null;
		private EntityRef<ES_FenXiangQQAddSet> m_es_fenxiangqqaddset = null;
		public Transform uiTransform = null;
	}
}
