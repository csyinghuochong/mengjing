
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetEgg))]
	[EnableMethod]
	public  class DlgPetEggViewComponent : Entity,IAwake,IDestroy 
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

        public ES_PetEggList ES_PetEggList
        {
            get
            {
                ES_PetEggList es = this.m_es_petegglist;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetEggList.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petegglist = this.AddChild<ES_PetEggList, Transform>(go.transform);
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
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetEggDuiHuan.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_peteggduihuan = this.AddChild<ES_PetEggDuiHuan, Transform>(go.transform);
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
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetEggChouKa.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_peteggchouka = this.AddChild<ES_PetEggChouKa, Transform>(go.transform);
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
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetHeXinChouKa.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_pethexinchouka = this.AddChild<ES_PetHeXinChouKa, Transform>(go.transform);
                }

                return this.m_es_pethexinchouka;
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
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_PetEggList> m_es_petegglist = null;
		private EntityRef<ES_PetEggDuiHuan> m_es_peteggduihuan = null;
		private EntityRef<ES_PetEggChouKa> m_es_peteggchouka = null;
		private EntityRef<ES_PetHeXinChouKa> m_es_pethexinchouka = null;
		public Transform uiTransform = null;
	}
}
