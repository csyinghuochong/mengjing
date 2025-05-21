
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgSkill))]
	[EnableMethod]
	public  class DlgSkillViewComponent : Entity,IAwake,IDestroy 
	{
		public List<string> AssetList = new();
		
		public UnityEngine.RectTransform EG_SubViewNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewNodeRectTransform == null )
     			{
		    		this.m_EG_SubViewNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubViewNode");
     			}
     			return this.m_EG_SubViewNodeRectTransform;
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
		    		this.m_E_Type_0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_0");
     			}
     			return this.m_E_Type_0Toggle;
     		}
     	}

        public ES_SkillLearn ES_SkillLearn
        {
            get
            {
                ES_SkillLearn es = this.m_es_skilllearn;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SkillLearn.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_skilllearn = this.AddChild<ES_SkillLearn, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_skilllearn;
            }
        }

        public ES_SkillSet ES_SkillSet
        {
            get
            {
                ES_SkillSet es = this.m_es_skillset;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SkillSet.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_skillset = this.AddChild<ES_SkillSet, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_skillset;
            }
        }

        public ES_SkillTianFu ES_SkillTianFu
        {
            get
            {
                ES_SkillTianFu es = this.m_es_skilltianfu;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SkillTianFu.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_skilltianfu = this.AddChild<ES_SkillTianFu, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_skilltianfu;
            }
        }

        public ES_SkillMake ES_SkillMake
        {
            get
            {
                ES_SkillMake es = this.m_es_skillmake;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SkillMake.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_skillmake = this.AddChild<ES_SkillMake, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_skillmake;
            }
        }

        public ES_SkillLifeShield ES_SkillLifeShield
        {
            get
            {
                ES_SkillLifeShield es = this.m_es_skilllifeshield;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_SkillLifeShield.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_skilllifeshield = this.AddChild<ES_SkillLifeShield, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_skilllifeshield;
            }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewNodeRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_0Toggle = null;
			this.m_es_skilllearn = null;
			this.m_es_skillset = null;
			this.m_es_skilltianfu = null;
			this.m_es_skillmake = null;
			this.m_es_skilllifeshield = null;
			this.uiTransform = null;
			
			ResourcesLoaderComponent resourcesLoaderComponent = this.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < this.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(this.AssetList[i]);
			}
			this.AssetList.Clear();
			this.AssetList = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewNodeRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_Type_0Toggle = null;
		private EntityRef<ES_SkillLearn> m_es_skilllearn = null;
		private EntityRef<ES_SkillSet> m_es_skillset = null;
		private EntityRef<ES_SkillTianFu> m_es_skilltianfu = null;
		private EntityRef<ES_SkillMake> m_es_skillmake = null;
		private EntityRef<ES_SkillLifeShield> m_es_skilllifeshield = null;
		public Transform uiTransform = null;
	}
}
