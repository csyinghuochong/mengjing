
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetHeCheng : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public RolePetInfo HeChengPet_Left;
		public RolePetInfo HeChengPet_Right;
		
		public UnityEngine.RectTransform EG_PetInfo1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetInfo1RectTransform == null )
     			{
		    		this.m_EG_PetInfo1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetInfo1");
     			}
     			return this.m_EG_PetInfo1RectTransform;
     		}
     	}

		public ES_PetInfoShow ES_PetInfoShow_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetInfoShow es = this.m_es_petinfoshow_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetInfo1/ES_PetInfoShow_1");
		    	   this.m_es_petinfoshow_1 = this.AddChild<ES_PetInfoShow,Transform>(subTrans);
     			}
     			return this.m_es_petinfoshow_1;
     		}
     	}

		public UnityEngine.RectTransform EG_PetInfo2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetInfo2RectTransform == null )
     			{
		    		this.m_EG_PetInfo2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_PetInfo2");
     			}
     			return this.m_EG_PetInfo2RectTransform;
     		}
     	}

		public ES_PetInfoShow ES_PetInfoShow_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetInfoShow es = this.m_es_petinfoshow_2;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetInfo2/ES_PetInfoShow_2");
		    	   this.m_es_petinfoshow_2 = this.AddChild<ES_PetInfoShow,Transform>(subTrans);
     			}
     			return this.m_es_petinfoshow_2;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HeChengButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HeChengButton == null )
     			{
		    		this.m_E_Btn_HeChengButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_HeCheng");
     			}
     			return this.m_E_Btn_HeChengButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HeChengImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HeChengImage == null )
     			{
		    		this.m_E_Btn_HeChengImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_HeCheng");
     			}
     			return this.m_E_Btn_HeChengImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_PreviewButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PreviewButton == null )
     			{
		    		this.m_E_Btn_PreviewButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_Preview");
     			}
     			return this.m_E_Btn_PreviewButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_PreviewImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PreviewImage == null )
     			{
		    		this.m_E_Btn_PreviewImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_Preview");
     			}
     			return this.m_E_Btn_PreviewImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_HeChengExplainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HeChengExplainButton == null )
     			{
		    		this.m_E_Btn_HeChengExplainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_HeChengExplain");
     			}
     			return this.m_E_Btn_HeChengExplainButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_HeChengExplainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_HeChengExplainImage == null )
     			{
		    		this.m_E_Btn_HeChengExplainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_HeChengExplain");
     			}
     			return this.m_E_Btn_HeChengExplainImage;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_EG_PetInfo1RectTransform = null;
			this.m_es_petinfoshow_1 = null;
			this.m_EG_PetInfo2RectTransform = null;
			this.m_es_petinfoshow_2 = null;
			this.m_E_Btn_HeChengButton = null;
			this.m_E_Btn_HeChengImage = null;
			this.m_E_Btn_PreviewButton = null;
			this.m_E_Btn_PreviewImage = null;
			this.m_E_Btn_HeChengExplainButton = null;
			this.m_E_Btn_HeChengExplainImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PetInfo1RectTransform = null;
		private EntityRef<ES_PetInfoShow> m_es_petinfoshow_1 = null;
		private UnityEngine.RectTransform m_EG_PetInfo2RectTransform = null;
		private EntityRef<ES_PetInfoShow> m_es_petinfoshow_2 = null;
		private UnityEngine.UI.Button m_E_Btn_HeChengButton = null;
		private UnityEngine.UI.Image m_E_Btn_HeChengImage = null;
		private UnityEngine.UI.Button m_E_Btn_PreviewButton = null;
		private UnityEngine.UI.Image m_E_Btn_PreviewImage = null;
		private UnityEngine.UI.Button m_E_Btn_HeChengExplainButton = null;
		private UnityEngine.UI.Image m_E_Btn_HeChengExplainImage = null;
		public Transform uiTransform = null;
	}
}
