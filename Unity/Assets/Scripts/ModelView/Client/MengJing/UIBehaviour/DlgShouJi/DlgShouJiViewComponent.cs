
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgShouJi))]
	[EnableMethod]
	public  class DlgShouJiViewComponent : Entity,IAwake,IDestroy 
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

		public ES_ShouJiList ES_ShouJiList
		{
			get
			{
				ES_ShouJiList es = this.m_es_shoujilist;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
							.LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ShouJiList.prefab");
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(false);
					this.m_es_shoujilist = this.AddChild<ES_ShouJiList, Transform>(go.transform);
				}

				return this.m_es_shoujilist;
			}
		}

		public ES_ShouJiTreasure ES_ShouJiTreasure
		{
			get
			{
				ES_ShouJiTreasure es = this.m_es_shoujitreasure;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
							.LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ShouJiTreasure.prefab");
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(false);
					this.m_es_shoujitreasure = this.AddChild<ES_ShouJiTreasure, Transform>(go.transform);
				}

				return this.m_es_shoujitreasure;
			}
		}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_shoujilist = null;
			this.m_es_shoujitreasure = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_ShouJiList> m_es_shoujilist = null;
		private EntityRef<ES_ShouJiTreasure> m_es_shoujitreasure = null;
		public Transform uiTransform = null;
	}
}
