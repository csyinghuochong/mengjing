using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRecharge))]
	[EnableMethod]
	public  class DlgRechargeViewComponent : Entity,IAwake,IDestroy 
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

		public LoopVerticalScrollRect E_RechargeItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RechargeItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RechargeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RechargeItems");
     			}
     			return this.m_E_RechargeItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonWeiXinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonWeiXinButton == null )
     			{
		    		this.m_E_ButtonWeiXinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonWeiXin");
     			}
     			return this.m_E_ButtonWeiXinButton;
     		}
     	}

		public Image E_ButtonWeiXinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonWeiXinImage == null )
     			{
		    		this.m_E_ButtonWeiXinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonWeiXin");
     			}
     			return this.m_E_ButtonWeiXinImage;
     		}
     	}

		public Button E_ButtonAliPayButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonAliPayButton == null )
     			{
		    		this.m_E_ButtonAliPayButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ButtonAliPay");
     			}
     			return this.m_E_ButtonAliPayButton;
     		}
     	}

		public Image E_ButtonAliPayImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonAliPayImage == null )
     			{
		    		this.m_E_ButtonAliPayImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ButtonAliPay");
     			}
     			return this.m_E_ButtonAliPayImage;
     		}
     	}

		public Image E_ImageSelect2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelect2Image == null )
     			{
		    		this.m_E_ImageSelect2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageSelect2");
     			}
     			return this.m_E_ImageSelect2Image;
     		}
     	}

		public Image E_ImageSelect1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageSelect1Image == null )
     			{
		    		this.m_E_ImageSelect1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageSelect1");
     			}
     			return this.m_E_ImageSelect1Image;
     		}
     	}

		public RectTransform EG_LoadingRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LoadingRectTransform == null )
     			{
		    		this.m_EG_LoadingRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_Loading");
     			}
     			return this.m_EG_LoadingRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_RechargeItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonWeiXinButton = null;
			this.m_E_ButtonWeiXinImage = null;
			this.m_E_ButtonAliPayButton = null;
			this.m_E_ButtonAliPayImage = null;
			this.m_E_ImageSelect2Image = null;
			this.m_E_ImageSelect1Image = null;
			this.m_EG_LoadingRectTransform = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageButtonButton = null;
		private Image m_E_ImageButtonImage = null;
		private LoopVerticalScrollRect m_E_RechargeItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonWeiXinButton = null;
		private Image m_E_ButtonWeiXinImage = null;
		private Button m_E_ButtonAliPayButton = null;
		private Image m_E_ButtonAliPayImage = null;
		private Image m_E_ImageSelect2Image = null;
		private Image m_E_ImageSelect1Image = null;
		private RectTransform m_EG_LoadingRectTransform = null;
		public Transform uiTransform = null;
	}
}
