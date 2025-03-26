
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgWelfare))]
	[EnableMethod]
	public  class DlgWelfareViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Toggle E_Type_0Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_0Toggle == null )
     			{
		    		this.m_E_Type_0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_0");
     			}
     			return this.m_E_Type_0Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_1Toggle == null )
     			{
		    		this.m_E_Type_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_1");
     			}
     			return this.m_E_Type_1Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_2Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_2Toggle == null )
     			{
		    		this.m_E_Type_2Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_2");
     			}
     			return this.m_E_Type_2Toggle;
     		}
     	}

        public ES_WelfareTask ES_WelfareTask
        {
            get
            {
                ES_WelfareTask es = this.m_es_welfaretask;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_WelfareTask.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_welfaretask = this.AddChild<ES_WelfareTask, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_welfaretask;
            }
        }

        public ES_WelfareDraw ES_WelfareDraw
        {
            get
            {
                ES_WelfareDraw es = this.m_es_welfaredraw;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_WelfareDraw.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_welfaredraw = this.AddChild<ES_WelfareDraw, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_welfaredraw;
            }
        }

        public ES_WelfareInvest ES_WelfareInvest
        {
            get
            {
                ES_WelfareInvest es = this.m_es_welfareinvest;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_WelfareInvest.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_welfareinvest = this.AddChild<ES_WelfareInvest, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_welfareinvest;
            }
        }

        public ES_WelfareDraw2 ES_WelfareDraw2
        {
            get
            {
                ES_WelfareDraw2 es = this.m_es_welfaredraw2;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_WelfareDraw2.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_welfaredraw2 = this.AddChild<ES_WelfareDraw2, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_welfaredraw2;
            }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_0Toggle = null;
			this.m_E_Type_1Toggle = null;
			this.m_E_Type_2Toggle = null;
			this.m_es_welfaretask = null;
			this.m_es_welfaredraw = null;
			this.m_es_welfareinvest = null;
			this.m_es_welfaredraw2 = null;
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
		private UnityEngine.UI.Toggle m_E_Type_0Toggle = null;
		private UnityEngine.UI.Toggle m_E_Type_1Toggle = null;
		private UnityEngine.UI.Toggle m_E_Type_2Toggle = null;
		private EntityRef<ES_WelfareTask> m_es_welfaretask = null;
		private EntityRef<ES_WelfareDraw> m_es_welfaredraw = null;
		private EntityRef<ES_WelfareInvest> m_es_welfareinvest = null;
		private EntityRef<ES_WelfareDraw2> m_es_welfaredraw2 = null;
		public Transform uiTransform = null;
	}
}
