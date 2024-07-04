
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanUpLv))]
	[EnableMethod]
	public  class DlgJiaYuanUpLvViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_ImgGengDiIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImgGengDiIconImage == null )
     			{
		    		this.m_E_ImgGengDiIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"TuDi/E_ImgGengDiIcon");
     			}
     			return this.m_E_ImgGengDiIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_GengDiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_GengDiText == null )
     			{
		    		this.m_E_Lab_GengDiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"TuDi/E_Lab_GengDi");
     			}
     			return this.m_E_Lab_GengDiText;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_RenKouText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_RenKouText == null )
     			{
		    		this.m_E_Lab_RenKouText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"People/E_Lab_RenKou");
     			}
     			return this.m_E_Lab_RenKouText;
     		}
     	}

		public UnityEngine.UI.Text E_JiaYuanNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanNameText == null )
     			{
		    		this.m_E_JiaYuanNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackDi_12/E_JiaYuanName");
     			}
     			return this.m_E_JiaYuanNameText;
     		}
     	}

		public UnityEngine.UI.Text E_JiaYuanLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanLvText == null )
     			{
		    		this.m_E_JiaYuanLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"JiaYuanUpLvSet/E_JiaYuanLv");
     			}
     			return this.m_E_JiaYuanLvText;
     		}
     	}

		public UnityEngine.UI.Image E_ImageExpValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageExpValueImage == null )
     			{
		    		this.m_E_ImageExpValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"JiaYuanUpLvSet/JiaYuanExp/E_ImageExpValue");
     			}
     			return this.m_E_ImageExpValueImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ZiZhiValueText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ZiZhiValueText == null )
     			{
		    		this.m_E_Text_ZiZhiValueText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"JiaYuanUpLvSet/JiaYuanExp/E_Text_ZiZhiValue");
     			}
     			return this.m_E_Text_ZiZhiValueText;
     		}
     	}

		public UnityEngine.RectTransform EG_UpdateGetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UpdateGetRectTransform == null )
     			{
		    		this.m_EG_UpdateGetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UpdateGet");
     			}
     			return this.m_EG_UpdateGetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ExchangeZiJinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ExchangeZiJinButton == null )
     			{
		    		this.m_E_Btn_ExchangeZiJinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_ExchangeZiJin");
     			}
     			return this.m_E_Btn_ExchangeZiJinButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ExchangeZiJinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ExchangeZiJinImage == null )
     			{
		    		this.m_E_Btn_ExchangeZiJinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_ExchangeZiJin");
     			}
     			return this.m_E_Btn_ExchangeZiJinImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ExchangeExpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ExchangeExpButton == null )
     			{
		    		this.m_E_Btn_ExchangeExpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_ExchangeExp");
     			}
     			return this.m_E_Btn_ExchangeExpButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ExchangeExpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ExchangeExpImage == null )
     			{
		    		this.m_E_Btn_ExchangeExpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_ExchangeExp");
     			}
     			return this.m_E_Btn_ExchangeExpImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_UpLvButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_UpLvButton == null )
     			{
		    		this.m_E_Btn_UpLvButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Btn_UpLv");
     			}
     			return this.m_E_Btn_UpLvButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_UpLvImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_UpLvImage == null )
     			{
		    		this.m_E_Btn_UpLvImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Btn_UpLv");
     			}
     			return this.m_E_Btn_UpLvImage;
     		}
     	}

		public UnityEngine.UI.Text E_JiaYuanUpHintText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaYuanUpHintText == null )
     			{
		    		this.m_E_JiaYuanUpHintText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_JiaYuanUpHint");
     			}
     			return this.m_E_JiaYuanUpHintText;
     		}
     	}

		public UnityEngine.UI.Text E_ZiJinDuiHuanShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZiJinDuiHuanShowText == null )
     			{
		    		this.m_E_ZiJinDuiHuanShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image (1)/E_ZiJinDuiHuanShow");
     			}
     			return this.m_E_ZiJinDuiHuanShowText;
     		}
     	}

		public UnityEngine.UI.Text E_ExpDuiHuanShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpDuiHuanShowText == null )
     			{
		    		this.m_E_ExpDuiHuanShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image (2)/E_ExpDuiHuanShow");
     			}
     			return this.m_E_ExpDuiHuanShowText;
     		}
     	}

		public UnityEngine.UI.Text E_ZiJinDuiHuanTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZiJinDuiHuanTextText == null )
     			{
		    		this.m_E_ZiJinDuiHuanTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ZiJinDuiHuanText");
     			}
     			return this.m_E_ZiJinDuiHuanTextText;
     		}
     	}

		public UnityEngine.UI.Text E_ExpDuiHuanTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpDuiHuanTextText == null )
     			{
		    		this.m_E_ExpDuiHuanTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ExpDuiHuanText");
     			}
     			return this.m_E_ExpDuiHuanTextText;
     		}
     	}

		public UnityEngine.UI.Text E_ZiJinDuiHuanAddShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZiJinDuiHuanAddShowText == null )
     			{
		    		this.m_E_ZiJinDuiHuanAddShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image (3)/E_ZiJinDuiHuanAddShow");
     			}
     			return this.m_E_ZiJinDuiHuanAddShowText;
     		}
     	}

		public UnityEngine.UI.Text E_ExpDuiHuanAddShowText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpDuiHuanAddShowText == null )
     			{
		    		this.m_E_ExpDuiHuanAddShowText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image (4)/E_ExpDuiHuanAddShow");
     			}
     			return this.m_E_ExpDuiHuanAddShowText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImgGengDiIconImage = null;
			this.m_E_Lab_GengDiText = null;
			this.m_E_Lab_RenKouText = null;
			this.m_E_JiaYuanNameText = null;
			this.m_E_JiaYuanLvText = null;
			this.m_E_ImageExpValueImage = null;
			this.m_E_Text_ZiZhiValueText = null;
			this.m_EG_UpdateGetRectTransform = null;
			this.m_E_Btn_ExchangeZiJinButton = null;
			this.m_E_Btn_ExchangeZiJinImage = null;
			this.m_E_Btn_ExchangeExpButton = null;
			this.m_E_Btn_ExchangeExpImage = null;
			this.m_E_Btn_UpLvButton = null;
			this.m_E_Btn_UpLvImage = null;
			this.m_E_JiaYuanUpHintText = null;
			this.m_E_ZiJinDuiHuanShowText = null;
			this.m_E_ExpDuiHuanShowText = null;
			this.m_E_ZiJinDuiHuanTextText = null;
			this.m_E_ExpDuiHuanTextText = null;
			this.m_E_ZiJinDuiHuanAddShowText = null;
			this.m_E_ExpDuiHuanAddShowText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ImgGengDiIconImage = null;
		private UnityEngine.UI.Text m_E_Lab_GengDiText = null;
		private UnityEngine.UI.Text m_E_Lab_RenKouText = null;
		private UnityEngine.UI.Text m_E_JiaYuanNameText = null;
		private UnityEngine.UI.Text m_E_JiaYuanLvText = null;
		private UnityEngine.UI.Image m_E_ImageExpValueImage = null;
		private UnityEngine.UI.Text m_E_Text_ZiZhiValueText = null;
		private UnityEngine.RectTransform m_EG_UpdateGetRectTransform = null;
		private UnityEngine.UI.Button m_E_Btn_ExchangeZiJinButton = null;
		private UnityEngine.UI.Image m_E_Btn_ExchangeZiJinImage = null;
		private UnityEngine.UI.Button m_E_Btn_ExchangeExpButton = null;
		private UnityEngine.UI.Image m_E_Btn_ExchangeExpImage = null;
		private UnityEngine.UI.Button m_E_Btn_UpLvButton = null;
		private UnityEngine.UI.Image m_E_Btn_UpLvImage = null;
		private UnityEngine.UI.Text m_E_JiaYuanUpHintText = null;
		private UnityEngine.UI.Text m_E_ZiJinDuiHuanShowText = null;
		private UnityEngine.UI.Text m_E_ExpDuiHuanShowText = null;
		private UnityEngine.UI.Text m_E_ZiJinDuiHuanTextText = null;
		private UnityEngine.UI.Text m_E_ExpDuiHuanTextText = null;
		private UnityEngine.UI.Text m_E_ZiJinDuiHuanAddShowText = null;
		private UnityEngine.UI.Text m_E_ExpDuiHuanAddShowText = null;
		public Transform uiTransform = null;
	}
}
