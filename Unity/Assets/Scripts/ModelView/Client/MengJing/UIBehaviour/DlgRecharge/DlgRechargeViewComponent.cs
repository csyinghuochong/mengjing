
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgRecharge))]
	[EnableMethod]
	public  class DlgRechargeViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_E_ImageButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ImageButton");
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
		    		this.m_E_ImageButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ImageButton");
     			}
     			return this.m_E_ImageButtonImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ReChargeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ReChargeText == null )
     			{
		    		this.m_E_Text_ReChargeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/E_Text_ReCharge");
     			}
     			return this.m_E_Text_ReChargeText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RechargeItemsLoopVerticalScrollRect
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
		    		this.m_E_RechargeItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/E_RechargeItems");
     			}
     			return this.m_E_RechargeItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.RectTransform EG_LoadingRectTransform
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
		    		this.m_EG_LoadingRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_Loading");
     			}
     			return this.m_EG_LoadingRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonWeiXinButton
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
		    		this.m_E_ButtonWeiXinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Bottom/E_ButtonWeiXin");
     			}
     			return this.m_E_ButtonWeiXinButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonWeiXinImage
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
		    		this.m_E_ButtonWeiXinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_ButtonWeiXin");
     			}
     			return this.m_E_ButtonWeiXinImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonAliPayButton
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
		    		this.m_E_ButtonAliPayButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Bottom/E_ButtonAliPay");
     			}
     			return this.m_E_ButtonAliPayButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonAliPayImage
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
		    		this.m_E_ButtonAliPayImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_ButtonAliPay");
     			}
     			return this.m_E_ButtonAliPayImage;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelect2Image
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
		    		this.m_E_ImageSelect2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_ImageSelect2");
     			}
     			return this.m_E_ImageSelect2Image;
     		}
     	}

		public UnityEngine.UI.Image E_ImageSelect1Image
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
		    		this.m_E_ImageSelect1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/E_ImageSelect1");
     			}
     			return this.m_E_ImageSelect1Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageButtonButton = null;
			this.m_E_ImageButtonImage = null;
			this.m_E_Text_ReChargeText = null;
			this.m_E_RechargeItemsLoopVerticalScrollRect = null;
			this.m_EG_LoadingRectTransform = null;
			this.m_E_ButtonWeiXinButton = null;
			this.m_E_ButtonWeiXinImage = null;
			this.m_E_ButtonAliPayButton = null;
			this.m_E_ButtonAliPayImage = null;
			this.m_E_ImageSelect2Image = null;
			this.m_E_ImageSelect1Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ImageButtonButton = null;
		private UnityEngine.UI.Image m_E_ImageButtonImage = null;
		private UnityEngine.UI.Text m_E_Text_ReChargeText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RechargeItemsLoopVerticalScrollRect = null;
		private UnityEngine.RectTransform m_EG_LoadingRectTransform = null;
		private UnityEngine.UI.Button m_E_ButtonWeiXinButton = null;
		private UnityEngine.UI.Image m_E_ButtonWeiXinImage = null;
		private UnityEngine.UI.Button m_E_ButtonAliPayButton = null;
		private UnityEngine.UI.Image m_E_ButtonAliPayImage = null;
		private UnityEngine.UI.Image m_E_ImageSelect2Image = null;
		private UnityEngine.UI.Image m_E_ImageSelect1Image = null;
		public Transform uiTransform = null;
	}
}
