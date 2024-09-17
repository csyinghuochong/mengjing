using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgTowerOfSealJump))]
	[EnableMethod]
	public  class DlgTowerOfSealJumpViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_TipTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TipTextText == null )
     			{
		    		this.m_E_TipTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"CostPanel/E_TipText");
     			}
     			return this.m_E_TipTextText;
     		}
     	}

		public Button E_NoBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoBtnButton == null )
     			{
		    		this.m_E_NoBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"CostPanel/E_NoBtn");
     			}
     			return this.m_E_NoBtnButton;
     		}
     	}

		public Image E_NoBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NoBtnImage == null )
     			{
		    		this.m_E_NoBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"CostPanel/E_NoBtn");
     			}
     			return this.m_E_NoBtnImage;
     		}
     	}

		public Button E_YesBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YesBtnButton == null )
     			{
		    		this.m_E_YesBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"CostPanel/E_YesBtn");
     			}
     			return this.m_E_YesBtnButton;
     		}
     	}

		public Image E_YesBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_YesBtnImage == null )
     			{
		    		this.m_E_YesBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"CostPanel/E_YesBtn");
     			}
     			return this.m_E_YesBtnImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TipTextText = null;
			this.m_E_NoBtnButton = null;
			this.m_E_NoBtnImage = null;
			this.m_E_YesBtnButton = null;
			this.m_E_YesBtnImage = null;
			this.uiTransform = null;
		}

		private Text m_E_TipTextText = null;
		private Button m_E_NoBtnButton = null;
		private Image m_E_NoBtnImage = null;
		private Button m_E_YesBtnButton = null;
		private Image m_E_YesBtnImage = null;
		public Transform uiTransform = null;
	}
}
