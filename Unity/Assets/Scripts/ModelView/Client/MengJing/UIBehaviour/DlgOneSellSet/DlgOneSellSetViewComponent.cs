
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgOneSellSet))]
	[EnableMethod]
	public  class DlgOneSellSetViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_OneSellSetRectTransform
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
		    		this.m_EG_OneSellSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_OneSellSet");
     			}
     			return this.m_EG_OneSellSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_OneSellButton
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
		    		this.m_E_Btn_OneSellButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_OneSell");
     			}
     			return this.m_E_Btn_OneSellButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_OneSellImage
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
		    		this.m_E_Btn_OneSellImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_OneSell");
     			}
     			return this.m_E_Btn_OneSellImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CloseButton
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
		    		this.m_E_Btn_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Btn_Close");
     			}
     			return this.m_E_Btn_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CloseImage
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
		    		this.m_E_Btn_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Btn_Close");
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

		private UnityEngine.RectTransform m_EG_OneSellSetRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_OneSellButton = null;
		private UnityEngine.UI.Image m_E_Btn_OneSellImage = null;
		private UnityEngine.UI.Button m_E_Btn_CloseButton = null;
		private UnityEngine.UI.Image m_E_Btn_CloseImage = null;
		public Transform uiTransform = null;
	}
}
