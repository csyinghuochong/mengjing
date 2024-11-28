
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSetting))]
	[EnableMethod]
	public  class DlgSettingViewComponent : Entity,IAwake,IDestroy 
	{
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

        public ES_SettingGame ES_SettingGame
        {
            get
            {
                ES_SettingGame es = this.m_es_settinggame;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SettingGame.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_settinggame = this.AddChild<ES_SettingGame, Transform>(go.transform);
                }

                return this.m_es_settinggame;
            }
        }

        public ES_SettingTitle ES_SettingTitle
        {
            get
            {
                ES_SettingTitle es = this.m_es_settingtitle;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SettingTitle.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_settingtitle = this.AddChild<ES_SettingTitle, Transform>(go.transform);
                }

                return this.m_es_settingtitle;
            }
        }

        public ES_SettingGuaJi ES_SettingGuaJi
        {
            get
            {
                ES_SettingGuaJi es = this.m_es_settingguaji;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SettingGuaJi.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_settingguaji = this.AddChild<ES_SettingGuaJi, Transform>(go.transform);
                }

                return this.m_es_settingguaji;
            }
        }

        public ES_FashionShow ES_FashionShow
        {
            get
            {
                ES_FashionShow es = this.m_es_fashionshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FashionShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_fashionshow = this.AddChild<ES_FashionShow, Transform>(go.transform);
                }

                return this.m_es_fashionshow;
            }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_settinggame = null;
			this.m_es_settingtitle = null;
			this.m_es_settingguaji = null;
			this.m_es_fashionshow = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_SettingGame> m_es_settinggame = null;
		private EntityRef<ES_SettingTitle> m_es_settingtitle = null;
		private EntityRef<ES_SettingGuaJi> m_es_settingguaji = null;
		private EntityRef<ES_FashionShow> m_es_fashionshow = null;
		public Transform uiTransform = null;
	}
}
