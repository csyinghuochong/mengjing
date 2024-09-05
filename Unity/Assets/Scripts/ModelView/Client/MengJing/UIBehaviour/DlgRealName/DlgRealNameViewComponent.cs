
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRealName))]
	[EnableMethod]
	public  class DlgRealNameViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.InputField E_InputFieldNameInputField
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
		    		this.m_E_InputFieldNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"FangChenMiSet/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldNameImage
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
		    		this.m_E_InputFieldNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"FangChenMiSet/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputFieldIDCardInputField
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
		    		this.m_E_InputFieldIDCardInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"FangChenMiSet/E_InputFieldIDCard");
     			}
     			return this.m_E_InputFieldIDCardInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldIDCardImage
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
		    		this.m_E_InputFieldIDCardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"FangChenMiSet/E_InputFieldIDCard");
     			}
     			return this.m_E_InputFieldIDCardImage;
     		}
     	}

		public UnityEngine.UI.Button E_RealName_BtnButton
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
		    		this.m_E_RealName_BtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"FangChenMiSet/E_RealName_Btn");
     			}
     			return this.m_E_RealName_BtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_RealName_BtnImage
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
		    		this.m_E_RealName_BtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"FangChenMiSet/E_RealName_Btn");
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

		private UnityEngine.UI.InputField m_E_InputFieldNameInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldNameImage = null;
		private UnityEngine.UI.InputField m_E_InputFieldIDCardInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldIDCardImage = null;
		private UnityEngine.UI.Button m_E_RealName_BtnButton = null;
		private UnityEngine.UI.Image m_E_RealName_BtnImage = null;
		public Transform uiTransform = null;
	}
}
