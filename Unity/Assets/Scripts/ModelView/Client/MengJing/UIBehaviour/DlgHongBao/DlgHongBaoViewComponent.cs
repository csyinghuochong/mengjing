
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgHongBao))]
	[EnableMethod]
	public  class DlgHongBaoViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Button_BackButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_BackButton == null )
     			{
		    		this.m_E_Button_BackButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Back");
     			}
     			return this.m_E_Button_BackButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_BackImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_BackImage == null )
     			{
		    		this.m_E_Button_BackImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Back");
     			}
     			return this.m_E_Button_BackImage;
     		}
     	}

		public UnityEngine.RectTransform EG_JiaGeSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_JiaGeSetRectTransform == null )
     			{
		    		this.m_EG_JiaGeSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_JiaGeSet");
     			}
     			return this.m_EG_JiaGeSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_AmountText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_AmountText == null )
     			{
		    		this.m_E_Text_AmountText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_JiaGeSet/E_Text_Amount");
     			}
     			return this.m_E_Text_AmountText;
     		}
     	}

		public UnityEngine.UI.Button E_Button_OpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_OpenButton == null )
     			{
		    		this.m_E_Button_OpenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Button_Open");
     			}
     			return this.m_E_Button_OpenButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_OpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_OpenImage == null )
     			{
		    		this.m_E_Button_OpenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Button_Open");
     			}
     			return this.m_E_Button_OpenImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Button_BackButton = null;
			this.m_E_Button_BackImage = null;
			this.m_EG_JiaGeSetRectTransform = null;
			this.m_E_Text_AmountText = null;
			this.m_E_Button_OpenButton = null;
			this.m_E_Button_OpenImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Button_BackButton = null;
		private UnityEngine.UI.Image m_E_Button_BackImage = null;
		private UnityEngine.RectTransform m_EG_JiaGeSetRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_AmountText = null;
		private UnityEngine.UI.Button m_E_Button_OpenButton = null;
		private UnityEngine.UI.Image m_E_Button_OpenImage = null;
		public Transform uiTransform = null;
	}
}
