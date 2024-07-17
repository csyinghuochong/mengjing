using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgShouJiSelect))]
	[EnableMethod]
	public  class DlgShouJiSelectViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ButtonCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseButton == null )
     			{
		    		this.m_E_ButtonCloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseButton;
     		}
     	}

		public Image E_ButtonCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCloseImage == null )
     			{
		    		this.m_E_ButtonCloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonClose");
     			}
     			return this.m_E_ButtonCloseImage;
     		}
     	}

		public LoopVerticalScrollRect E_BagItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_BagItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_BagItems");
     			}
     			return this.m_E_BagItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonTunShiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTunShiButton == null )
     			{
		    		this.m_E_ButtonTunShiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonTunShi");
     			}
     			return this.m_E_ButtonTunShiButton;
     		}
     	}

		public Image E_ButtonTunShiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonTunShiImage == null )
     			{
		    		this.m_E_ButtonTunShiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonTunShi");
     			}
     			return this.m_E_ButtonTunShiImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.m_E_BagItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonTunShiButton = null;
			this.m_E_ButtonTunShiImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		private LoopVerticalScrollRect m_E_BagItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonTunShiButton = null;
		private Image m_E_ButtonTunShiImage = null;
		public Transform uiTransform = null;
	}
}
