
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionJingXuan))]
	[EnableMethod]
	public  class DlgUnionJingXuanViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_ImageButtonButton
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_ImageButton");
     			}
     			return this.m_E_ImageButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_ImageButtonImage
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_JingXuanItemsLoopVerticalScrollRect
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
		    		this.m_E_JingXuanItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_JingXuanItems");
     			}
     			return this.m_E_JingXuanItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_ButtonListRectTransform
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
		    		this.m_EG_ButtonListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_ButtonList");
     			}
     			return this.m_EG_ButtonListRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCancelButton
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
		    		this.m_E_ButtonCancelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_ButtonList/E_ButtonCancel");
     			}
     			return this.m_E_ButtonCancelButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCancelImage
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
		    		this.m_E_ButtonCancelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_ButtonList/E_ButtonCancel");
     			}
     			return this.m_E_ButtonCancelImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonConfirmButton
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
		    		this.m_E_ButtonConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_ButtonList/E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonConfirmImage
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
		    		this.m_E_ButtonConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_ButtonList/E_ButtonConfirm");
     			}
     			return this.m_E_ButtonConfirmImage;
     		}
     	}

		public UnityEngine.RectTransform EG_AlreadyJingXuanRectTransform
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
		    		this.m_EG_AlreadyJingXuanRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_AlreadyJingXuan");
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

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_JingXuanItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_ButtonListRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonCancelButton = null;
		private UnityEngine.UI.Image m_E_ButtonCancelImage = null;
		private UnityEngine.UI.Button m_E_ButtonConfirmButton = null;
		private UnityEngine.UI.Image m_E_ButtonConfirmImage = null;
		private UnityEngine.RectTransform m_EG_AlreadyJingXuanRectTransform = null;
		public Transform uiTransform = null;
	}
}
