using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRealName))]
	[EnableMethod]
	public  class DlgRealNameViewComponent : Entity,IAwake,IDestroy 
	{
		public InputField E_InputFieldNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldNameInputField == null )
     			{
		    		this.m_E_InputFieldNameInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"FangChenMiSet/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameInputField;
     		}
     	}

		public Image E_InputFieldNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldNameImage == null )
     			{
		    		this.m_E_InputFieldNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"FangChenMiSet/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameImage;
     		}
     	}

		public InputField E_InputFieldIDCardInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldIDCardInputField == null )
     			{
		    		this.m_E_InputFieldIDCardInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"FangChenMiSet/E_InputFieldIDCard");
     			}
     			return this.m_E_InputFieldIDCardInputField;
     		}
     	}

		public Image E_InputFieldIDCardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldIDCardImage == null )
     			{
		    		this.m_E_InputFieldIDCardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"FangChenMiSet/E_InputFieldIDCard");
     			}
     			return this.m_E_InputFieldIDCardImage;
     		}
     	}

		public Button E_RealName_BtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RealName_BtnButton == null )
     			{
		    		this.m_E_RealName_BtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"FangChenMiSet/E_RealName_Btn");
     			}
     			return this.m_E_RealName_BtnButton;
     		}
     	}

		public Image E_RealName_BtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RealName_BtnImage == null )
     			{
		    		this.m_E_RealName_BtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"FangChenMiSet/E_RealName_Btn");
     			}
     			return this.m_E_RealName_BtnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_InputFieldNameInputField = null;
			this.m_E_InputFieldNameImage = null;
			this.m_E_InputFieldIDCardInputField = null;
			this.m_E_InputFieldIDCardImage = null;
			this.m_E_RealName_BtnButton = null;
			this.m_E_RealName_BtnImage = null;
			this.uiTransform = null;
		}

		private InputField m_E_InputFieldNameInputField = null;
		private Image m_E_InputFieldNameImage = null;
		private InputField m_E_InputFieldIDCardInputField = null;
		private Image m_E_InputFieldIDCardImage = null;
		private Button m_E_RealName_BtnButton = null;
		private Image m_E_RealName_BtnImage = null;
		public Transform uiTransform = null;
	}
}
