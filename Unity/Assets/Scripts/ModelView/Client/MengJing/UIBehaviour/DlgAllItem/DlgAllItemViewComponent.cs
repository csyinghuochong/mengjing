
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgAllItem))]
	[EnableMethod]
	public  class DlgAllItemViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_Button_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CloseButton == null )
     			{
		    		this.m_E_Button_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Button_Close");
     			}
     			return this.m_E_Button_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CloseImage == null )
     			{
		    		this.m_E_Button_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Button_Close");
     			}
     			return this.m_E_Button_CloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_ContentRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ContentRectTransform == null )
     			{
		    		this.m_EG_ContentRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Scroll View/Viewport/EG_Content");
     			}
     			return this.m_EG_ContentRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ItemButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemButton == null )
     			{
		    		this.m_E_ItemButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Scroll View/Viewport/EG_Content/E_Item");
     			}
     			return this.m_E_ItemButton;
     		}
     	}

		public UnityEngine.UI.Image E_ItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemImage == null )
     			{
		    		this.m_E_ItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Scroll View/Viewport/EG_Content/E_Item");
     			}
     			return this.m_E_ItemImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_Button_CloseButton = null;
			this.m_E_Button_CloseImage = null;
			this.m_EG_ContentRectTransform = null;
			this.m_E_ItemButton = null;
			this.m_E_ItemImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Button_CloseButton = null;
		private UnityEngine.UI.Image m_E_Button_CloseImage = null;
		private UnityEngine.RectTransform m_EG_ContentRectTransform = null;
		private UnityEngine.UI.Button m_E_ItemButton = null;
		private UnityEngine.UI.Image m_E_ItemImage = null;
		public Transform uiTransform = null;
	}
}
