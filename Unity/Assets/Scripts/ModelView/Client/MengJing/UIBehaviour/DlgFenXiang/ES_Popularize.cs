using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_Popularize : Entity,IAwake<Transform>,IDestroy 
	{
		public bool BePopularize;
		
		public Button E_ButtonOkButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOkButton == null )
     			{
		    		this.m_E_ButtonOkButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonOk");
     			}
     			return this.m_E_ButtonOkButton;
     		}
     	}

		public Image E_ButtonOkImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonOkImage == null )
     			{
		    		this.m_E_ButtonOkImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonOk");
     			}
     			return this.m_E_ButtonOkImage;
     		}
     	}

		public Button E_ButtonGetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetButton == null )
     			{
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public Image E_ButtonGetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonGetImage == null )
     			{
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public InputField E_InputField_CodeInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_CodeInputField == null )
     			{
		    		this.m_E_InputField_CodeInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"E_InputField_Code");
     			}
     			return this.m_E_InputField_CodeInputField;
     		}
     	}

		public Image E_InputField_CodeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputField_CodeImage == null )
     			{
		    		this.m_E_InputField_CodeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_InputField_Code");
     			}
     			return this.m_E_InputField_CodeImage;
     		}
     	}

		public RectTransform EG_BuildingListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_BuildingListRectTransform == null )
     			{
		    		this.m_EG_BuildingListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView_2/Viewport/EG_BuildingList");
     			}
     			return this.m_EG_BuildingListRectTransform;
     		}
     	}

		public RectTransform EG_UIPopularizeItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIPopularizeItemRectTransform == null )
     			{
		    		this.m_EG_UIPopularizeItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView_2/Viewport/EG_BuildingList/EG_UIPopularizeItem");
     			}
     			return this.m_EG_UIPopularizeItemRectTransform;
     		}
     	}

		public Text E_Text_Reward_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Reward_1Text == null )
     			{
		    		this.m_E_Text_Reward_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Reward_1");
     			}
     			return this.m_E_Text_Reward_1Text;
     		}
     	}

		public Text E_Text_Reward_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Reward_2Text == null )
     			{
		    		this.m_E_Text_Reward_2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Reward_2");
     			}
     			return this.m_E_Text_Reward_2Text;
     		}
     	}

		public Text E_Text_My_CodeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_My_CodeText == null )
     			{
		    		this.m_E_Text_My_CodeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_My_Code");
     			}
     			return this.m_E_Text_My_CodeText;
     		}
     	}

		public Button E_Text_Button_CopyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Button_CopyButton == null )
     			{
		    		this.m_E_Text_Button_CopyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Text_Button_Copy");
     			}
     			return this.m_E_Text_Button_CopyButton;
     		}
     	}

		public Text E_Text_Button_CopyText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Button_CopyText == null )
     			{
		    		this.m_E_Text_Button_CopyText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_Button_Copy");
     			}
     			return this.m_E_Text_Button_CopyText;
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
			this.m_E_ButtonOkButton = null;
			this.m_E_ButtonOkImage = null;
			this.m_E_ButtonGetButton = null;
			this.m_E_ButtonGetImage = null;
			this.m_E_InputField_CodeInputField = null;
			this.m_E_InputField_CodeImage = null;
			this.m_EG_BuildingListRectTransform = null;
			this.m_EG_UIPopularizeItemRectTransform = null;
			this.m_E_Text_Reward_1Text = null;
			this.m_E_Text_Reward_2Text = null;
			this.m_E_Text_My_CodeText = null;
			this.m_E_Text_Button_CopyButton = null;
			this.m_E_Text_Button_CopyText = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonOkButton = null;
		private Image m_E_ButtonOkImage = null;
		private Button m_E_ButtonGetButton = null;
		private Image m_E_ButtonGetImage = null;
		private InputField m_E_InputField_CodeInputField = null;
		private Image m_E_InputField_CodeImage = null;
		private RectTransform m_EG_BuildingListRectTransform = null;
		private RectTransform m_EG_UIPopularizeItemRectTransform = null;
		private Text m_E_Text_Reward_1Text = null;
		private Text m_E_Text_Reward_2Text = null;
		private Text m_E_Text_My_CodeText = null;
		private Button m_E_Text_Button_CopyButton = null;
		private Text m_E_Text_Button_CopyText = null;
		public Transform uiTransform = null;
	}
}
