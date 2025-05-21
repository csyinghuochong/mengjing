
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRoleXiLian))]
	[EnableMethod]
	public  class DlgRoleXiLianViewComponent : Entity,IAwake,IDestroy 
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

        public ES_RoleXiLianShow ES_RoleXiLianShow
        {
            get
            {
                ES_RoleXiLianShow es = this.m_es_rolexilianshow;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleXiLianShow.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rolexilianshow = this.AddChild<ES_RoleXiLianShow, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rolexilianshow;
            }
        }

        public ES_RoleXiLianLevel ES_RoleXiLianLevel
        {
            get
            {
                ES_RoleXiLianLevel es = this.m_es_rolexilianlevel;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleXiLianLevel.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rolexilianlevel = this.AddChild<ES_RoleXiLianLevel, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rolexilianlevel;
            }
        }

        public ES_RoleXiLianSkill ES_RoleXiLianSkill
        {
            get
            {
                ES_RoleXiLianSkill es = this.m_es_rolexilianskill;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleXiLianSkill.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rolexilianskill = this.AddChild<ES_RoleXiLianSkill, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rolexilianskill;
            }
        }

        public ES_RoleXiLianTransfer ES_RoleXiLianTransfer
        {
            get
            {
                ES_RoleXiLianTransfer es = this.m_es_rolexiliantransfer;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleXiLianTransfer.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rolexiliantransfer = this.AddChild<ES_RoleXiLianTransfer, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rolexiliantransfer;
            }
        }

        public ES_RoleXiLianInherit ES_RoleXiLianInherit
        {
            get
            {
                ES_RoleXiLianInherit es = this.m_es_rolexilianinherit;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleXiLianInherit.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rolexilianinherit = this.AddChild<ES_RoleXiLianInherit, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rolexilianinherit;
            }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_rolexilianshow = null;
			this.m_es_rolexilianlevel = null;
			this.m_es_rolexilianskill = null;
			this.m_es_rolexiliantransfer = null;
			this.m_es_rolexilianinherit = null;
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
		private EntityRef<ES_RoleXiLianShow> m_es_rolexilianshow = null;
		private EntityRef<ES_RoleXiLianLevel> m_es_rolexilianlevel = null;
		private EntityRef<ES_RoleXiLianSkill> m_es_rolexilianskill = null;
		private EntityRef<ES_RoleXiLianTransfer> m_es_rolexiliantransfer = null;
		private EntityRef<ES_RoleXiLianInherit> m_es_rolexilianinherit = null;
		public Transform uiTransform = null;
	}
}
