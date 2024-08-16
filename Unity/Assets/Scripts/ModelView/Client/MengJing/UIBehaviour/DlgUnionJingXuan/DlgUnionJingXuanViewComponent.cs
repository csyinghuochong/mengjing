using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionJingXuan))]
	[EnableMethod]
	public  class DlgUnionJingXuanViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonButton == null )
     			{
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public Image E_ImageButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageButtonImage == null )
     			{
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public LoopVerticalScrollRect E_JingXuanItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JingXuanItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_JingXuanItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_JingXuanItems");
     			}
     			return this.m_E_JingXuanItemsLoopVerticalScrollRect;
     		}
     	}

		public RectTransform EG_ButtonListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ButtonListRectTransform == null )
     			{
		    		this.m_EG_ButtonListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ButtonList");
     			}
     			return this.m_EG_ButtonListRectTransform;
     		}
     	}

		public Button E_ButtonCancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCancelButton == null )
     			{
		    		this.m_E_ButtonCancelButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ButtonList/E_ButtonCancel");
     			}
     			return this.m_E_ButtonCancelButton;
     		}
     	}

		public Image E_ButtonCancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCancelImage == null )
     			{
		    		this.m_E_ButtonCancelImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ButtonList/E_ButtonCancel");
     			}
     			return this.m_E_ButtonCancelImage;
     		}
     	}

		public Button E_ButtonConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonConfirmButton == null )
     			{
		    		this.m_E_ButtonConfirmButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ButtonList/E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmButton;
     		}
     	}

		public Image E_ButtonConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonConfirmImage == null )
     			{
		    		this.m_E_ButtonConfirmImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ButtonList/E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmImage;
     		}
     	}

		public RectTransform EG_AlreadyJingXuanRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AlreadyJingXuanRectTransform == null )
     			{
		    		this.m_EG_AlreadyJingXuanRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_AlreadyJingXuan");
     			}
     			return this.m_EG_AlreadyJingXuanRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_JingXuanItemsLoopVerticalScrollRect = null;
			this.m_EG_ButtonListRectTransform = null;
			this.m_E_ButtonCancelButton = null;
			this.m_E_ButtonCancelImage = null;
			this.m_E_ButtonConfirmButton = null;
			this.m_E_ButtonConfirmImage = null;
			this.m_EG_AlreadyJingXuanRectTransform = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private LoopVerticalScrollRect m_E_JingXuanItemsLoopVerticalScrollRect = null;
		private RectTransform m_EG_ButtonListRectTransform = null;
		private Button m_E_ButtonCancelButton = null;
		private Image m_E_ButtonCancelImage = null;
		private Button m_E_ButtonConfirmButton = null;
		private Image m_E_ButtonConfirmImage = null;
		private RectTransform m_EG_AlreadyJingXuanRectTransform = null;
		public Transform uiTransform = null;
	}
}
