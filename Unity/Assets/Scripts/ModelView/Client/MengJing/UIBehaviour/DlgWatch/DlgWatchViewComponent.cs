
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgWatch))]
	[EnableMethod]
	public  class DlgWatchViewComponent : Entity,IAwake,IDestroy 
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

		public ES_WatchEquip ES_WatchEquip
		{
			get
			{
				ES_WatchEquip es = this.m_es_watchequip;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
							.LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WatchEquip.prefab");
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(false);
					this.m_es_watchequip = this.AddChild<ES_WatchEquip, Transform>(go.transform);
				}

				return this.m_es_watchequip;
			}
		}

		public ES_WatchPet ES_WatchPet
		{
			get
			{
				ES_WatchPet es = this.m_es_watchpet;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
							.LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WatchPet.prefab");
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(false);
					this.m_es_watchpet = this.AddChild<ES_WatchPet, Transform>(go.transform);
				}

				return this.m_es_watchpet;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_watchequip = null;
			this.m_es_watchpet = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_WatchEquip> m_es_watchequip = null;
		private EntityRef<ES_WatchPet> m_es_watchpet = null;
		public Transform uiTransform = null;
	}
}
