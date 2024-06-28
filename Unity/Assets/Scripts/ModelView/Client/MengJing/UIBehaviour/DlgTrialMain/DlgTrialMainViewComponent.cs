
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgTrialMain))]
	[EnableMethod]
	public  class DlgTrialMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ButtonTiaozhanButton
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
		    		this.m_E_ButtonTiaozhanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonTiaozhan");
     			}
     			return this.m_E_ButtonTiaozhanButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonTiaozhanImage
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
		    		this.m_E_ButtonTiaozhanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonTiaozhan");
     			}
     			return this.m_E_ButtonTiaozhanImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextHurtText
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
		    		this.m_E_TextHurtText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_TextHurt");
     			}
     			return this.m_E_TextHurtText;
     		}
     	}

		public UnityEngine.UI.Text E_TextCoundownText
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
		    		this.m_E_TextCoundownText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/E_TextCoundown");
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

		private UnityEngine.UI.Button m_E_ButtonTiaozhanButton = null;
		private UnityEngine.UI.Image m_E_ButtonTiaozhanImage = null;
		private UnityEngine.UI.Text m_E_TextHurtText = null;
		private UnityEngine.UI.Text m_E_TextCoundownText = null;
		public Transform uiTransform = null;
	}
}
