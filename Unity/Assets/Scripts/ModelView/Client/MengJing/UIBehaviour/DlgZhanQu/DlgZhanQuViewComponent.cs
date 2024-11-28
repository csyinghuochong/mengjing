
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgZhanQu))]
	[EnableMethod]
	public  class DlgZhanQuViewComponent : Entity,IAwake,IDestroy 
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

        public ES_ZhanQuLevel ES_ZhanQuLevel
        {
            get
            {
                ES_ZhanQuLevel es = this.m_es_zhanqulevel;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ZhanQuLevel.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_zhanqulevel = this.AddChild<ES_ZhanQuLevel, Transform>(go.transform);
                }

                return this.m_es_zhanqulevel;
            }
        }

        public ES_ZhanQuCombat ES_ZhanQuCombat
        {
            get
            {
                ES_ZhanQuCombat es = this.m_es_zhanqucombat;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ZhanQuCombat.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_zhanqucombat = this.AddChild<ES_ZhanQuCombat, Transform>(go.transform);
                }

                return this.m_es_zhanqucombat;
            }
        }

        public ES_FirstWin ES_FirstWin
        {
            get
            {
                ES_FirstWin es = this.m_es_firstwin;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FirstWin.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_firstwin = this.AddChild<ES_FirstWin, Transform>(go.transform);
                }

                return this.m_es_firstwin;
            }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_zhanqulevel = null;
			this.m_es_zhanqucombat = null;
			this.m_es_firstwin = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_ZhanQuLevel> m_es_zhanqulevel = null;
		private EntityRef<ES_ZhanQuCombat> m_es_zhanqucombat = null;
		private EntityRef<ES_FirstWin> m_es_firstwin = null;
		public Transform uiTransform = null;
	}
}
