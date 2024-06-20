
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_Popularize : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public bool BePopularize;
		
		public UnityEngine.UI.Button E_ButtonOkButton
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
		    		this.m_E_ButtonOkButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonOk");
     			}
     			return this.m_E_ButtonOkButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonOkImage
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
		    		this.m_E_ButtonOkImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonOk");
     			}
     			return this.m_E_ButtonOkImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonGetButton
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
		    		this.m_E_ButtonGetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonGetImage
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
		    		this.m_E_ButtonGetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonGet");
     			}
     			return this.m_E_ButtonGetImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputField_CodeInputField
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
		    		this.m_E_InputField_CodeInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"E_InputField_Code");
     			}
     			return this.m_E_InputField_CodeInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputField_CodeImage
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
		    		this.m_E_InputField_CodeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_InputField_Code");
     			}
     			return this.m_E_InputField_CodeImage;
     		}
     	}

		public UnityEngine.RectTransform EG_BuildingListRectTransform
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
		    		this.m_EG_BuildingListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView_2/Viewport/EG_BuildingList");
     			}
     			return this.m_EG_BuildingListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_UIPopularizeItemRectTransform
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
		    		this.m_EG_UIPopularizeItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView_2/Viewport/EG_BuildingList/EG_UIPopularizeItem");
     			}
     			return this.m_EG_UIPopularizeItemRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Reward_1Text
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
		    		this.m_E_Text_Reward_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Reward_1");
     			}
     			return this.m_E_Text_Reward_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Reward_2Text
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
		    		this.m_E_Text_Reward_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Reward_2");
     			}
     			return this.m_E_Text_Reward_2Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_My_CodeText
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
		    		this.m_E_Text_My_CodeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_My_Code");
     			}
     			return this.m_E_Text_My_CodeText;
     		}
     	}

		public UnityEngine.UI.Button E_Text_Button_CopyButton
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
		    		this.m_E_Text_Button_CopyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Text_Button_Copy");
     			}
     			return this.m_E_Text_Button_CopyButton;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Button_CopyText
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
		    		this.m_E_Text_Button_CopyText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Text_Button_Copy");
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

		private UnityEngine.UI.Button m_E_ButtonOkButton = null;
		private UnityEngine.UI.Image m_E_ButtonOkImage = null;
		private UnityEngine.UI.Button m_E_ButtonGetButton = null;
		private UnityEngine.UI.Image m_E_ButtonGetImage = null;
		private UnityEngine.UI.InputField m_E_InputField_CodeInputField = null;
		private UnityEngine.UI.Image m_E_InputField_CodeImage = null;
		private UnityEngine.RectTransform m_EG_BuildingListRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIPopularizeItemRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_Reward_1Text = null;
		private UnityEngine.UI.Text m_E_Text_Reward_2Text = null;
		private UnityEngine.UI.Text m_E_Text_My_CodeText = null;
		private UnityEngine.UI.Button m_E_Text_Button_CopyButton = null;
		private UnityEngine.UI.Text m_E_Text_Button_CopyText = null;
		public Transform uiTransform = null;
	}
}
