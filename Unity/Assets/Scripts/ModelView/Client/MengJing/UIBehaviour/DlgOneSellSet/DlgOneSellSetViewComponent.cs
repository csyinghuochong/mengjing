using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgOneSellSet))]
	[EnableMethod]
	public  class DlgOneSellSetViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_OneSellSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_OneSellSetRectTransform == null )
     			{
		    		this.m_EG_OneSellSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_OneSellSet");
     			}
     			return this.m_EG_OneSellSetRectTransform;
     		}
     	}

		public Button E_Btn_OneSellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_OneSellButton == null )
     			{
		    		this.m_E_Btn_OneSellButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_OneSell");
     			}
     			return this.m_E_Btn_OneSellButton;
     		}
     	}

		public Image E_Btn_OneSellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_OneSellImage == null )
     			{
		    		this.m_E_Btn_OneSellImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_OneSell");
     			}
     			return this.m_E_Btn_OneSellImage;
     		}
     	}

		public Button E_Btn_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseButton == null )
     			{
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public Image E_Btn_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CloseImage == null )
     			{
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_OneSellSetRectTransform = null;
			this.m_E_Btn_OneSellButton = null;
			this.m_E_Btn_OneSellImage = null;
			this.m_E_Btn_CloseButton = null;
			this.m_E_Btn_CloseImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_OneSellSetRectTransform = null;
		private Button m_E_Btn_OneSellButton = null;
		private Image m_E_Btn_OneSellImage = null;
		private Button m_E_Btn_CloseButton = null;
		private Image m_E_Btn_CloseImage = null;
		public Transform uiTransform = null;
	}
}
