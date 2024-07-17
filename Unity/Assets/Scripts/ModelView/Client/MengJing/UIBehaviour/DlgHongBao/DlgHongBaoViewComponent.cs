using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgHongBao))]
	[EnableMethod]
	public  class DlgHongBaoViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_Button_BackButton
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
		    		this.m_E_Button_BackButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Back");
     			}
     			return this.m_E_Button_BackButton;
     		}
     	}

		public Image E_Button_BackImage
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
		    		this.m_E_Button_BackImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Back");
     			}
     			return this.m_E_Button_BackImage;
     		}
     	}

		public RectTransform EG_JiaGeSetRectTransform
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
		    		this.m_EG_JiaGeSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_JiaGeSet");
     			}
     			return this.m_EG_JiaGeSetRectTransform;
     		}
     	}

		public Text E_Text_AmountText
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
		    		this.m_E_Text_AmountText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_JiaGeSet/E_Text_Amount");
     			}
     			return this.m_E_Text_AmountText;
     		}
     	}

		public Button E_Button_OpenButton
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
		    		this.m_E_Button_OpenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Button_Open");
     			}
     			return this.m_E_Button_OpenButton;
     		}
     	}

		public Image E_Button_OpenImage
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
		    		this.m_E_Button_OpenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Button_Open");
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

		private Button m_E_Button_BackButton = null;
		private Image m_E_Button_BackImage = null;
		private RectTransform m_EG_JiaGeSetRectTransform = null;
		private Text m_E_Text_AmountText = null;
		private Button m_E_Button_OpenButton = null;
		private Image m_E_Button_OpenImage = null;
		public Transform uiTransform = null;
	}
}
