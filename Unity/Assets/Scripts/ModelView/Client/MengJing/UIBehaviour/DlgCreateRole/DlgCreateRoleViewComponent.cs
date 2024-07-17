using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgCreateRole))]
	[EnableMethod]
	public  class DlgCreateRoleViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public RectTransform EG_OccShow_ZhanShiRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccShow_ZhanShiRectTransform == null )
     			{
		    		this.m_EG_OccShow_ZhanShiRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_OccShow_ZhanShi");
     			}
     			return this.m_EG_OccShow_ZhanShiRectTransform;
     		}
     	}

		public RectTransform EG_OccShow_FaShiRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccShow_FaShiRectTransform == null )
     			{
		    		this.m_EG_OccShow_FaShiRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_OccShow_FaShi");
     			}
     			return this.m_EG_OccShow_FaShiRectTransform;
     		}
     	}

		public RectTransform EG_OccShow_LieRenRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OccShow_LieRenRectTransform == null )
     			{
		    		this.m_EG_OccShow_LieRenRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_OccShow_LieRen");
     			}
     			return this.m_EG_OccShow_LieRenRectTransform;
     		}
     	}

		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public InputField E_CreateRoleNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleNameInputField == null )
     			{
		    		this.m_E_CreateRoleNameInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_CreateRoleName");
     			}
     			return this.m_E_CreateRoleNameInputField;
     		}
     	}

		public Image E_CreateRoleNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleNameImage == null )
     			{
		    		this.m_E_CreateRoleNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CreateRoleName");
     			}
     			return this.m_E_CreateRoleNameImage;
     		}
     	}

		public ToggleGroup E_FunctionSetBtnToggleGroup
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public Image E_Icon_1_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Icon_1_1Image == null )
     			{
		    		this.m_E_Icon_1_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_FunctionSetBtn/Type_0/Background/XuanZhong/E_Icon_1_1");
     			}
     			return this.m_E_Icon_1_1Image;
     		}
     	}

		public Image E_Icon_1_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Icon_1_2Image == null )
     			{
		    		this.m_E_Icon_1_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_FunctionSetBtn/Type_0/Background/WeiXuanZhong/E_Icon_1_2");
     			}
     			return this.m_E_Icon_1_2Image;
     		}
     	}

		public Image E_Icon_2_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Icon_2_1Image == null )
     			{
		    		this.m_E_Icon_2_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_FunctionSetBtn/Type_1/Background/XuanZhong/E_Icon_2_1");
     			}
     			return this.m_E_Icon_2_1Image;
     		}
     	}

		public Image E_Icon_2_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Icon_2_2Image == null )
     			{
		    		this.m_E_Icon_2_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_FunctionSetBtn/Type_1/Background/WeiXuanZhong/E_Icon_2_2");
     			}
     			return this.m_E_Icon_2_2Image;
     		}
     	}

		public Image E_Icon_3_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Icon_3_1Image == null )
     			{
		    		this.m_E_Icon_3_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_FunctionSetBtn/Type_2/Background/XuanZhong/E_Icon_3_1");
     			}
     			return this.m_E_Icon_3_1Image;
     		}
     	}

		public Image E_Icon_3_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Icon_3_2Image == null )
     			{
		    		this.m_E_Icon_3_2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_FunctionSetBtn/Type_2/Background/WeiXuanZhong/E_Icon_3_2");
     			}
     			return this.m_E_Icon_3_2Image;
     		}
     	}

		public Button E_CreateRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleButton == null )
     			{
		    		this.m_E_CreateRoleButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_CreateRole");
     			}
     			return this.m_E_CreateRoleButton;
     		}
     	}

		public Image E_CreateRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleImage == null )
     			{
		    		this.m_E_CreateRoleImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_CreateRole");
     			}
     			return this.m_E_CreateRoleImage;
     		}
     	}

		public Button E_RandomNameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RandomNameButton == null )
     			{
		    		this.m_E_RandomNameButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_RandomName");
     			}
     			return this.m_E_RandomNameButton;
     		}
     	}

		public Image E_RandomNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RandomNameImage == null )
     			{
		    		this.m_E_RandomNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RandomName");
     			}
     			return this.m_E_RandomNameImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_EG_OccShow_ZhanShiRectTransform = null;
			this.m_EG_OccShow_FaShiRectTransform = null;
			this.m_EG_OccShow_LieRenRectTransform = null;
			this.m_es_modelshow = null;
			this.m_E_CreateRoleNameInputField = null;
			this.m_E_CreateRoleNameImage = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Icon_1_1Image = null;
			this.m_E_Icon_1_2Image = null;
			this.m_E_Icon_2_1Image = null;
			this.m_E_Icon_2_2Image = null;
			this.m_E_Icon_3_1Image = null;
			this.m_E_Icon_3_2Image = null;
			this.m_E_CreateRoleButton = null;
			this.m_E_CreateRoleImage = null;
			this.m_E_RandomNameButton = null;
			this.m_E_RandomNameImage = null;
			this.uiTransform = null;
		}

		private Button m_E_CloseButton = null;
		private Image m_E_CloseImage = null;
		private RectTransform m_EG_OccShow_ZhanShiRectTransform = null;
		private RectTransform m_EG_OccShow_FaShiRectTransform = null;
		private RectTransform m_EG_OccShow_LieRenRectTransform = null;
		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private InputField m_E_CreateRoleNameInputField = null;
		private Image m_E_CreateRoleNameImage = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Image m_E_Icon_1_1Image = null;
		private Image m_E_Icon_1_2Image = null;
		private Image m_E_Icon_2_1Image = null;
		private Image m_E_Icon_2_2Image = null;
		private Image m_E_Icon_3_1Image = null;
		private Image m_E_Icon_3_2Image = null;
		private Button m_E_CreateRoleButton = null;
		private Image m_E_CreateRoleImage = null;
		private Button m_E_RandomNameButton = null;
		private Image m_E_RandomNameImage = null;
		public Transform uiTransform = null;
	}
}
