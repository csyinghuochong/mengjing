using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgSelectServer))]
	[EnableMethod]
	public  class DlgSelectServerViewComponent : Entity,IAwake,IDestroy 
	{
		public LoopVerticalScrollRect E_SelectServerItem1LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectServerItem1LoopVerticalScrollRect == null )
     			{
		    		this.m_E_SelectServerItem1LoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SelectServerItem1");
     			}
     			return this.m_E_SelectServerItem1LoopVerticalScrollRect;
     		}
     	}

		public LoopVerticalScrollRect E_SelectServerItem2LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectServerItem2LoopVerticalScrollRect == null )
     			{
		    		this.m_E_SelectServerItem2LoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SelectServerItem2");
     			}
     			return this.m_E_SelectServerItem2LoopVerticalScrollRect;
     		}
     	}

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

		public void DestroyWidget()
		{
			this.m_E_SelectServerItem1LoopVerticalScrollRect = null;
			this.m_E_SelectServerItem2LoopVerticalScrollRect = null;
			this.m_E_ButtonCloseButton = null;
			this.m_E_ButtonCloseImage = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_SelectServerItem1LoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_SelectServerItem2LoopVerticalScrollRect = null;
		private Button m_E_ButtonCloseButton = null;
		private Image m_E_ButtonCloseImage = null;
		public Transform uiTransform = null;
	}
}
