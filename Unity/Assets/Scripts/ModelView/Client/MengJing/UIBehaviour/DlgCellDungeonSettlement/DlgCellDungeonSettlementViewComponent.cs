
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCellDungeonSettlement))]
	[EnableMethod]
	public  class DlgCellDungeonSettlementViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_closeButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_closeButtonButton == null )
     			{
		    		this.m_E_closeButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_closeButton");
     			}
     			return this.m_E_closeButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_closeButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_closeButtonImage == null )
     			{
		    		this.m_E_closeButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_closeButton");
     			}
     			return this.m_E_closeButtonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectEffectSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectEffectSetRectTransform == null )
     			{
		    		this.m_EG_SelectEffectSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SelectEffectSet");
     			}
     			return this.m_EG_SelectEffectSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Image E_Star_1_liangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_1_liangImage == null )
     			{
		    		this.m_E_Star_1_liangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_1_liang");
     			}
     			return this.m_E_Star_1_liangImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_2_liangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_2_liangImage == null )
     			{
		    		this.m_E_Star_2_liangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_2_liang");
     			}
     			return this.m_E_Star_2_liangImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_3_liangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_3_liangImage == null )
     			{
		    		this.m_E_Star_3_liangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_3_liang");
     			}
     			return this.m_E_Star_3_liangImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_1_OKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_1_OKImage == null )
     			{
		    		this.m_E_Star_1_OKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_1_OK");
     			}
     			return this.m_E_Star_1_OKImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_2_OKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_2_OKImage == null )
     			{
		    		this.m_E_Star_2_OKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_2_OK");
     			}
     			return this.m_E_Star_2_OKImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_3_OKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_3_OKImage == null )
     			{
		    		this.m_E_Star_3_OKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_3_OK");
     			}
     			return this.m_E_Star_3_OKImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ResultText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ResultText == null )
     			{
		    		this.m_E_Text_ResultText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Result");
     			}
     			return this.m_E_Text_ResultText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_expText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_expText == null )
     			{
		    		this.m_E_Text_expText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_exp");
     			}
     			return this.m_E_Text_expText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_goldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_goldText == null )
     			{
		    		this.m_E_Text_goldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_gold");
     			}
     			return this.m_E_Text_goldText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_closeButtonButton = null;
			this.m_E_closeButtonImage = null;
			this.m_EG_SelectEffectSetRectTransform = null;
			this.m_E_Star_1_liangImage = null;
			this.m_E_Star_2_liangImage = null;
			this.m_E_Star_3_liangImage = null;
			this.m_E_Star_1_OKImage = null;
			this.m_E_Star_2_OKImage = null;
			this.m_E_Star_3_OKImage = null;
			this.m_E_Text_ResultText = null;
			this.m_E_Text_expText = null;
			this.m_E_Text_goldText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_closeButtonButton = null;
		private UnityEngine.UI.Image m_E_closeButtonImage = null;
		private UnityEngine.RectTransform m_EG_SelectEffectSetRectTransform = null;
		private UnityEngine.UI.Image m_E_Star_1_liangImage = null;
		private UnityEngine.UI.Image m_E_Star_2_liangImage = null;
		private UnityEngine.UI.Image m_E_Star_3_liangImage = null;
		private UnityEngine.UI.Image m_E_Star_1_OKImage = null;
		private UnityEngine.UI.Image m_E_Star_2_OKImage = null;
		private UnityEngine.UI.Image m_E_Star_3_OKImage = null;
		private UnityEngine.UI.Text m_E_Text_ResultText = null;
		private UnityEngine.UI.Text m_E_Text_expText = null;
		private UnityEngine.UI.Text m_E_Text_goldText = null;
		public Transform uiTransform = null;
	}
}
