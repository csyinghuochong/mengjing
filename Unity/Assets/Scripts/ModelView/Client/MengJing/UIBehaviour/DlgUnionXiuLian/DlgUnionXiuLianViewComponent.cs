
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionXiuLian))]
	[EnableMethod]
	public  class DlgUnionXiuLianViewComponent : Entity,IAwake,IDestroy 
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

        public ES_UnionRoleXiuLian ES_UnionRoleXiuLian
        {
            get
            {
                ES_UnionRoleXiuLian es = this.m_es_unionrolexiulian;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_UnionRoleXiuLian.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_unionrolexiulian = this.AddChild<ES_UnionRoleXiuLian, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_unionrolexiulian;
            }
        }

        public ES_UnionPetXiuLian ES_UnionPetXiuLian
        {
            get
            {
                ES_UnionPetXiuLian es = this.m_es_unionpetxiulian;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_UnionPetXiuLian.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_unionpetxiulian = this.AddChild<ES_UnionPetXiuLian, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_unionpetxiulian;
            }
        }

        public ES_UnionBloodStone ES_UnionBloodStone
        {
            get
            {
                ES_UnionBloodStone es = this.m_es_unionbloodstone;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_UnionBloodStone.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_unionbloodstone = this.AddChild<ES_UnionBloodStone, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_unionbloodstone;
            }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_unionrolexiulian = null;
			this.m_es_unionpetxiulian = null;
			this.m_es_unionbloodstone = null;
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
		private EntityRef<ES_UnionRoleXiuLian> m_es_unionrolexiulian = null;
		private EntityRef<ES_UnionPetXiuLian> m_es_unionpetxiulian = null;
		private EntityRef<ES_UnionBloodStone> m_es_unionbloodstone = null;
		public Transform uiTransform = null;
	}
}
