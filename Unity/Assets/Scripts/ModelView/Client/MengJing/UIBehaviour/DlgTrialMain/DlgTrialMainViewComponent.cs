using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTrialMain))]
	[EnableMethod]
	public  class DlgTrialMainViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ButtonTiaozhanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTiaozhanButton == null )
     			{
		    		this.m_E_ButtonTiaozhanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonTiaozhan");
     			}
     			return this.m_E_ButtonTiaozhanButton;
     		}
     	}

		public Image E_ButtonTiaozhanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTiaozhanImage == null )
     			{
		    		this.m_E_ButtonTiaozhanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonTiaozhan");
     			}
     			return this.m_E_ButtonTiaozhanImage;
     		}
     	}

		public Text E_TextHurtText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextHurtText == null )
     			{
		    		this.m_E_TextHurtText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_TextHurt");
     			}
     			return this.m_E_TextHurtText;
     		}
     	}

		public Text E_TextCoundownText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextCoundownText == null )
     			{
		    		this.m_E_TextCoundownText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Top/E_TextCoundown");
     			}
     			return this.m_E_TextCoundownText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonTiaozhanButton = null;
			this.m_E_ButtonTiaozhanImage = null;
			this.m_E_TextHurtText = null;
			this.m_E_TextCoundownText = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonTiaozhanButton = null;
		private Image m_E_ButtonTiaozhanImage = null;
		private Text m_E_TextHurtText = null;
		private Text m_E_TextCoundownText = null;
		public Transform uiTransform = null;
	}
}
