
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanFood))]
	[EnableMethod]
	public  class DlgJiaYuanFoodViewComponent : Entity,IAwake,IDestroy 
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

        public ES_JiaYuanPurchase ES_JiaYuanPurchase
        {
            get
            {
                ES_JiaYuanPurchase es = this.m_es_jiayuanpurchase;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_JiaYuanPurchase.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_jiayuanpurchase = this.AddChild<ES_JiaYuanPurchase, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_jiayuanpurchase;
            }
        }

        private EntityRef<ES_JiaYuanCooking> m_es_jiayuancooking = null;

        public ES_JiaYuanCooking ES_JiaYuanCooking
        {
            get
            {
                ES_JiaYuanCooking es = this.m_es_jiayuancooking;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_JiaYuanCooking.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_jiayuancooking = this.AddChild<ES_JiaYuanCooking, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_jiayuancooking;
            }
        }

        private EntityRef<ES_JiaYuanCookbook> m_es_jiayuancookbook = null;

        public ES_JiaYuanCookbook ES_JiaYuanCookbook
        {
            get
            {
                ES_JiaYuanCookbook es = this.m_es_jiayuancookbook;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_JiaYuanCookbook.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_jiayuancookbook = this.AddChild<ES_JiaYuanCookbook, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_jiayuancookbook;
            }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_jiayuanpurchase = null;
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
		private EntityRef<ES_JiaYuanPurchase> m_es_jiayuanpurchase = null;
		public Transform uiTransform = null;
	}
}
