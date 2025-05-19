
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgActivity))]
	[EnableMethod]
	public  class DlgActivityViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Toggle E_Type_4Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_4Toggle == null )
     			{
		    		this.m_E_Type_4Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_4");
     			}
     			return this.m_E_Type_4Toggle;
     		}
     	}

        public ES_ActivityYueKa ES_ActivityYueKa
        {
            get
            {
                ES_ActivityYueKa es = this.m_es_activityyueka;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_ActivityYueKa.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_activityyueka = this.AddChild<ES_ActivityYueKa, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_activityyueka;
            }
        }

        public ES_ActivityMaoXian ES_ActivityMaoXian
        {
            get
            {
                ES_ActivityMaoXian es = this.m_es_activitymaoxian;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_ActivityMaoXian.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_activitymaoxian = this.AddChild<ES_ActivityMaoXian, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_activitymaoxian;
            }
        }

        public ES_ActivityToken ES_ActivityToken
        {
            get
            {
                ES_ActivityToken es = this.m_es_activitytoken;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_ActivityToken.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_activitytoken = this.AddChild<ES_ActivityToken, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_activitytoken;
            }
        }

        public ES_ActivityTeHui ES_ActivityTeHui
        {
            get
            {
                ES_ActivityTeHui es = this.m_es_activitytehui;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_ActivityTeHui.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_activitytehui = this.AddChild<ES_ActivityTeHui, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_activitytehui;
            }
        }

        public ES_ActivitySingleRecharge ES_ActivitySingleRecharge
        {
            get
            {
                ES_ActivitySingleRecharge es = this.m_es_activitysinglerecharge;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_ActivitySingleRecharge.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_activitysinglerecharge = this.AddChild<ES_ActivitySingleRecharge, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_activitysinglerecharge;
            }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_4Toggle = null;
			this.m_es_activityyueka = null;
			this.m_es_activitymaoxian = null;
			this.m_es_activitytoken = null;
			this.m_es_activitytehui = null;
			this.m_es_activitysinglerecharge = null;
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
		private UnityEngine.UI.Toggle m_E_Type_4Toggle = null;
		private EntityRef<ES_ActivityYueKa> m_es_activityyueka = null;
		private EntityRef<ES_ActivityMaoXian> m_es_activitymaoxian = null;
		private EntityRef<ES_ActivityToken> m_es_activitytoken = null;
		private EntityRef<ES_ActivityTeHui> m_es_activitytehui = null;
		private EntityRef<ES_ActivitySingleRecharge> m_es_activitysinglerecharge = null;
		public Transform uiTransform = null;
	}
}
