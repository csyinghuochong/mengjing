using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetHeCheng : Entity,IAwake<Transform>,IDestroy 
	{
		public RolePetInfo HeChengPet_Left;
		public RolePetInfo HeChengPet_Right;
		
		public RectTransform EG_PetInfo1RectTransform
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
		    		this.m_EG_PetInfo1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetInfo1");
     			}
     			return this.m_EG_PetInfo1RectTransform;
     		}
     	}

		public ES_PetHeChengInfoShow ES_PetHeChengInfoShow_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetHeChengInfoShow es = this.m_es_pethechenginfoshow_1;
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetInfo1/ES_PetHeChengInfoShow_1");
		    	   this.m_es_pethechenginfoshow_1 = this.AddChild<ES_PetHeChengInfoShow,Transform>(subTrans);
     			}
     			return this.m_es_pethechenginfoshow_1;
     		}
     	}

		public RectTransform EG_PetInfo2RectTransform
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
		    		this.m_EG_PetInfo2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetInfo2");
     			}
     			return this.m_EG_PetInfo2RectTransform;
     		}
     	}

		public ES_PetHeChengInfoShow ES_PetHeChengInfoShow_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}

		        ES_PetHeChengInfoShow es = this.m_es_pethechenginfoshow_2;
     			if( es ==null)
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_PetInfo2/ES_PetHeChengInfoShow_2");
		    	   this.m_es_pethechenginfoshow_2 = this.AddChild<ES_PetHeChengInfoShow,Transform>(subTrans);
     			}
     			return this.m_es_pethechenginfoshow_2;
     		}
     	}

		public Button E_Btn_HeChengButton
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
		    		this.m_E_Btn_HeChengButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_HeCheng");
     			}
     			return this.m_E_Btn_HeChengButton;
     		}
     	}

		public Image E_Btn_HeChengImage
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
		    		this.m_E_Btn_HeChengImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_HeCheng");
     			}
     			return this.m_E_Btn_HeChengImage;
     		}
     	}

		public Button E_Btn_PreviewButton
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
		    		this.m_E_Btn_PreviewButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Preview");
     			}
     			return this.m_E_Btn_PreviewButton;
     		}
     	}

		public Image E_Btn_PreviewImage
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
		    		this.m_E_Btn_PreviewImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Preview");
     			}
     			return this.m_E_Btn_PreviewImage;
     		}
     	}

		public Button E_Btn_HeChengExplainButton
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
		    		this.m_E_Btn_HeChengExplainButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_HeChengExplain");
     			}
     			return this.m_E_Btn_HeChengExplainButton;
     		}
     	}

		public Image E_Btn_HeChengExplainImage
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
		    		this.m_E_Btn_HeChengExplainImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_HeChengExplain");
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
			this.m_es_pethechenginfoshow_1 = null;
			this.m_EG_PetInfo2RectTransform = null;
			this.m_es_pethechenginfoshow_2 = null;
			this.m_E_Btn_HeChengButton = null;
			this.m_E_Btn_HeChengImage = null;
			this.m_E_Btn_PreviewButton = null;
			this.m_E_Btn_PreviewImage = null;
			this.m_E_Btn_HeChengExplainButton = null;
			this.m_E_Btn_HeChengExplainImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_PetInfo1RectTransform = null;
		private EntityRef<ES_PetHeChengInfoShow> m_es_pethechenginfoshow_1 = null;
		private RectTransform m_EG_PetInfo2RectTransform = null;
		private EntityRef<ES_PetHeChengInfoShow> m_es_pethechenginfoshow_2 = null;
		private Button m_E_Btn_HeChengButton = null;
		private Image m_E_Btn_HeChengImage = null;
		private Button m_E_Btn_PreviewButton = null;
		private Image m_E_Btn_PreviewImage = null;
		private Button m_E_Btn_HeChengExplainButton = null;
		private Image m_E_Btn_HeChengExplainImage = null;
		public Transform uiTransform = null;
	}
}
