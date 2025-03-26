
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgEquipmentIncrease))]
	[EnableMethod]
	public  class DlgEquipmentIncreaseViewComponent : Entity,IAwake,IDestroy 
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

		public ES_EquipmentIncreaseShow ES_EquipmentIncreaseShow
		{
			get
			{
				string path = "Assets/Bundles/UI/Common/ES_EquipmentIncreaseShow.prefab";
				ES_EquipmentIncreaseShow es = this.m_es_equipmentincreaseshow;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_equipmentincreaseshow = this.AddChild<ES_EquipmentIncreaseShow, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_equipmentincreaseshow;
			}
		}

		public ES_EquipmentIncreaseTransfer ES_EquipmentIncreaseTransfer
		{
			get
			{
				string path = "Assets/Bundles/UI/Common/ES_EquipmentIncreaseTransfer.prefab";
				ES_EquipmentIncreaseTransfer es = this.m_es_equipmentincreasetransfer;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_equipmentincreasetransfer = this.AddChild<ES_EquipmentIncreaseTransfer, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_equipmentincreasetransfer;
			}
		}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_equipmentincreaseshow = null;
			this.m_es_equipmentincreasetransfer = null;
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
		private EntityRef<ES_EquipmentIncreaseShow> m_es_equipmentincreaseshow = null;
		private EntityRef<ES_EquipmentIncreaseTransfer> m_es_equipmentincreasetransfer = null;
		public Transform uiTransform = null;
	}
}
