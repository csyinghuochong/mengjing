
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgChengJiu))]
	[EnableMethod]
	public  class DlgChengJiuViewComponent : Entity,IAwake,IDestroy 
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
		
		public ES_ChengJiuPetTuJian ES_ChengJiuPetTuJian
		{
			get
			{
				ES_ChengJiuPetTuJian es = this.m_ES_ChengJiuPetTuJian;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
							.LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ChengJiuPetTuJian.prefab");
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(false);
					this.m_ES_ChengJiuPetTuJian = this.AddChild<ES_ChengJiuPetTuJian, Transform>(go.transform);
				}

				return this.m_ES_ChengJiuPetTuJian;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_ES_ChengJiuPetTuJian = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;

		private EntityRef<ES_ChengJiuPetTuJian> m_ES_ChengJiuPetTuJian = null;
		
		public Transform uiTransform = null;
	}
}
