
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgBattle))]
	[EnableMethod]
	public  class DlgBattleViewComponent : Entity,IAwake,IDestroy 
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

        public ES_BattleEnter ES_BattleEnter
        {
            get
            {
                ES_BattleEnter es = this.m_es_battleenter;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_BattleEnter.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_battleenter = this.AddChild<ES_BattleEnter, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_battleenter;
            }
        }

        public ES_BattleTask ES_BattleTask
        {
            get
            {
                ES_BattleTask es = this.m_es_battletask;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_BattleTask.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_battletask = this.AddChild<ES_BattleTask, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_battletask;
            }
        }

        public ES_BattleShop ES_BattleShop
        {
            get
            {
                ES_BattleShop es = this.m_es_battleshop;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_BattleShop.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_battleshop = this.AddChild<ES_BattleShop, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_battleshop;
            }
        }
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_battleenter = null;
			this.m_es_battletask = null;
			this.m_es_battleshop = null;
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
		private EntityRef<ES_BattleEnter> m_es_battleenter = null;
		private EntityRef<ES_BattleTask> m_es_battletask = null;
		private EntityRef<ES_BattleShop> m_es_battleshop = null;
		public Transform uiTransform = null;
	}
}
