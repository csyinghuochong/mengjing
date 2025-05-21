using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRole))]
	[EnableMethod]
	public  class DlgRoleViewComponent : Entity,IAwake,IDestroy 
	{
		public List<string> AssetList = new();
		
		public ES_EquipSet ES_EquipSet
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_EquipSet es = this.m_es_equipset;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Center/ES_EquipSet");
		    	   this.m_es_equipset = this.AddChild<ES_EquipSet,Transform>(subTrans);
     			}
     			return this.m_es_equipset;
     		}
     	}

		public UnityEngine.UI.Button E_ZodiacButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZodiacButton == null )
     			{
		    		this.m_E_ZodiacButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Zodiac");
     			}
     			return this.m_E_ZodiacButton;
     		}
     	}

		public UnityEngine.UI.Image E_ZodiacImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZodiacImage == null )
     			{
		    		this.m_E_ZodiacImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Zodiac");
     			}
     			return this.m_E_ZodiacImage;
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

		public UnityEngine.UI.Toggle E_Type_PropertyToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_PropertyToggle == null )
     			{
		    		this.m_E_Type_PropertyToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_Property");
     			}
     			return this.m_E_Type_PropertyToggle;
     		}
     	}

        public ES_RoleBag ES_RoleBag
        {
            get
            {
                ES_RoleBag es = this.m_es_rolebag;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleBag.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rolebag = this.AddChild<ES_RoleBag, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rolebag;
            }
        }

        public ES_RoleProperty ES_RoleProperty
        {
            get
            {
                ES_RoleProperty es = this.m_es_roleproperty;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleProperty.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleProperty.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_roleproperty = this.AddChild<ES_RoleProperty, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_roleproperty;
            }
        }

        public ES_RoleGem ES_RoleGem
        {
            get
            {
                ES_RoleGem es = this.m_es_rolegem;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleGem.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleGem.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rolegem = this.AddChild<ES_RoleGem, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rolegem;
            }
        }

        public ES_RoleHuiShou ES_RoleHuiShou
        {
            get
            {
                ES_RoleHuiShou es = this.m_es_rolehuishou;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleHuiShou.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleHuiShou.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_rolehuishou = this.AddChild<ES_RoleHuiShou, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_rolehuishou;
            }
        }

        public ES_RoleQiangHua ES_RoleQiangHua
        {
            get
            {
                ES_RoleQiangHua es = this.m_es_roleqianghua;
                if (es == null)
                {
	                string path = "Assets/Bundles/UI/Common/ES_RoleQiangHua.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleQiangHua.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_roleqianghua = this.AddChild<ES_RoleQiangHua, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_roleqianghua;
            }
        }
        
        public ES_RoleZodiac ES_RoleZodiac
        {
	        get
	        {
		        ES_RoleZodiac es = this.m_es_roleZodiac;
		        if (es == null)
		        {
			        string path = "Assets/Bundles/UI/Common/ES_RoleZodiac.prefab";
			        GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
					        .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleZodiac.prefab");
			        GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
			        go.SetActive(true);
			        this.AssetList.Add(path);
			        this.m_es_roleZodiac = this.AddChild<ES_RoleZodiac, Transform>(go.transform);
			        go.SetActive(false);
		        }

		        return this.m_es_roleZodiac;
	        }
        }
		
		public void DestroyWidget()
		{
			this.m_es_equipset = null;
			this.m_E_ZodiacButton = null;
			this.m_E_ZodiacImage = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_PropertyToggle = null;
			this.m_es_rolebag = null;
			this.m_es_roleproperty = null;
			this.m_es_rolegem = null;
			this.m_es_rolehuishou = null;
			this.m_es_roleqianghua = null;
			this.m_es_roleZodiac = null;
			this.uiTransform = null;
			
			ResourcesLoaderComponent resourcesLoaderComponent = this.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < this.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(this.AssetList[i]);
			}
			this.AssetList.Clear();
			this.AssetList = null;
		}

		private EntityRef<ES_EquipSet> m_es_equipset = null;
		private UnityEngine.UI.Button m_E_ZodiacButton = null;
		private UnityEngine.UI.Image m_E_ZodiacImage = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_Type_PropertyToggle = null;
		private EntityRef<ES_RoleBag> m_es_rolebag = null;
		private EntityRef<ES_RoleProperty> m_es_roleproperty = null;
		private EntityRef<ES_RoleGem> m_es_rolegem = null;
		private EntityRef<ES_RoleHuiShou> m_es_rolehuishou = null;
		private EntityRef<ES_RoleQiangHua> m_es_roleqianghua = null;
		private EntityRef<ES_RoleZodiac> m_es_roleZodiac = null;
		public Transform uiTransform = null;
	}
}
