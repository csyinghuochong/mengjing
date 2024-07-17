using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgCountryHuoDongJieShao))]
	[EnableMethod]
	public  class DlgCountryHuoDongJieShaoViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_TextTitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTitleText == null )
     			{
		    		this.m_E_TextTitleText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextTitle");
     			}
     			return this.m_E_TextTitleText;
     		}
     	}

		public Text E_TextJieShaoText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextJieShaoText == null )
     			{
		    		this.m_E_TextJieShaoText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TextJieShao");
     			}
     			return this.m_E_TextJieShaoText;
     		}
     	}

		public Button E_BtnCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCloseButton == null )
     			{
		    		this.m_E_BtnCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_BtnClose");
     			}
     			return this.m_E_BtnCloseButton;
     		}
     	}

		public Image E_BtnCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnCloseImage == null )
     			{
		    		this.m_E_BtnCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_BtnClose");
     			}
     			return this.m_E_BtnCloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TextTitleText = null;
			this.m_E_TextJieShaoText = null;
			this.m_E_BtnCloseButton = null;
			this.m_E_BtnCloseImage = null;
			this.uiTransform = null;
		}

		private Text m_E_TextTitleText = null;
		private Text m_E_TextJieShaoText = null;
		private Button m_E_BtnCloseButton = null;
		private Image m_E_BtnCloseImage = null;
		public Transform uiTransform = null;
	}
}
