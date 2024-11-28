
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPet))]
	[EnableMethod]
	public  class DlgPetViewComponent : Entity,IAwake,IDestroy 
	{
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

        public ES_PetList ES_PetList
        {
            get
            {
                ES_PetList es = this.m_es_petlist;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetList.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petlist = this.AddChild<ES_PetList, Transform>(go.transform);
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
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetHeCheng.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_pethecheng = this.AddChild<ES_PetHeCheng, Transform>(go.transform);
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
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetXiLian.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petxilian = this.AddChild<ES_PetXiLian, Transform>(go.transform);
                }

                return this.m_es_petxilian;
            }
        }

        public ES_PetShouHu ES_PetShouHu
        {
            get
            {
                ES_PetShouHu es = this.m_es_petshouhu;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetShouHu.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petshouhu = this.AddChild<ES_PetShouHu, Transform>(go.transform);
                }

                return this.m_es_petshouhu;
            }
        }

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_petlist = null;
			this.m_es_pethecheng = null;
			this.m_es_petxilian = null;
			this.m_es_petshouhu = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_PetList> m_es_petlist = null;
		private EntityRef<ES_PetHeCheng> m_es_pethecheng = null;
		private EntityRef<ES_PetXiLian> m_es_petxilian = null;
		private EntityRef<ES_PetShouHu> m_es_petshouhu = null;
		public Transform uiTransform = null;
	}
}
