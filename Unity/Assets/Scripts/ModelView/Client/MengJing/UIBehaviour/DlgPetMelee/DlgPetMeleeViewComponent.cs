﻿
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPetMelee))]
	[EnableMethod]
	public  class DlgPetMeleeViewComponent : Entity,IAwake,IDestroy 
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

		public ES_PetMeleeSet ES_PetMeleeSet
		{
			get
			{
				ES_PetMeleeSet es = this.m_es_petMeleeSet;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
							.LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetMeleeSet.prefab");
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(false);
					this.m_es_petMeleeSet = this.AddChild<ES_PetMeleeSet, Transform>(go.transform);
				}

				return this.m_es_petMeleeSet;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_petMeleeSet = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_PetMeleeSet> m_es_petMeleeSet = null;
		public Transform uiTransform = null;
	}
}
