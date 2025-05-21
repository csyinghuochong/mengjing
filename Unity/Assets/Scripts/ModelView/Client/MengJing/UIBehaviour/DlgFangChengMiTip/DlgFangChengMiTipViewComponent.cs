
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFangChengMiTip))]
	[EnableMethod]
	public  class DlgFangChengMiTipViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_TitleText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleText == null )
     			{
		    		this.m_E_TitleText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Title");
     			}
     			return this.m_E_TitleText;
     		}
     	}

		public UnityEngine.UI.Text E_ContentText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ContentText == null )
     			{
		    		this.m_E_ContentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Content");
     			}
     			return this.m_E_ContentText;
     		}
     	}

		public UnityEngine.UI.Button E_TrueButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TrueButton == null )
     			{
		    		this.m_E_TrueButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_True");
     			}
     			return this.m_E_TrueButton;
     		}
     	}

		public UnityEngine.UI.Image E_TrueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TrueImage == null )
     			{
		    		this.m_E_TrueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_True");
     			}
     			return this.m_E_TrueImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TitleText = null;
			this.m_E_ContentText = null;
			this.m_E_TrueButton = null;
			this.m_E_TrueImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_TitleText = null;
		private UnityEngine.UI.Text m_E_ContentText = null;
		private UnityEngine.UI.Button m_E_TrueButton = null;
		private UnityEngine.UI.Image m_E_TrueImage = null;
		public Transform uiTransform = null;
	}
}
