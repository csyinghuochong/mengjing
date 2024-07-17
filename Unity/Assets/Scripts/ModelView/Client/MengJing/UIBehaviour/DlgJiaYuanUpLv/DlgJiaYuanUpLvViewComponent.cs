using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanUpLv))]
	[EnableMethod]
	public  class DlgJiaYuanUpLvViewComponent : Entity,IAwake,IDestroy 
	{
		public Image E_ImgGengDiIconImage
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
		    		this.m_E_ImgGengDiIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"TuDi/E_ImgGengDiIcon");
     			}
     			return this.m_E_ImgGengDiIconImage;
     		}
     	}

		public Text E_Lab_GengDiText
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
		    		this.m_E_Lab_GengDiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TuDi/E_Lab_GengDi");
     			}
     			return this.m_E_Lab_GengDiText;
     		}
     	}

		public Text E_Lab_RenKouText
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
		    		this.m_E_Lab_RenKouText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"People/E_Lab_RenKou");
     			}
     			return this.m_E_Lab_RenKouText;
     		}
     	}

		public Text E_JiaYuanNameText
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
		    		this.m_E_JiaYuanNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"BackDi_12/E_JiaYuanName");
     			}
     			return this.m_E_JiaYuanNameText;
     		}
     	}

		public Text E_JiaYuanLvText
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
		    		this.m_E_JiaYuanLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"JiaYuanUpLvSet/E_JiaYuanLv");
     			}
     			return this.m_E_JiaYuanLvText;
     		}
     	}

		public Image E_ImageExpValueImage
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
		    		this.m_E_ImageExpValueImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"JiaYuanUpLvSet/JiaYuanExp/E_ImageExpValue");
     			}
     			return this.m_E_ImageExpValueImage;
     		}
     	}

		public Text E_Text_ZiZhiValueText
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
		    		this.m_E_Text_ZiZhiValueText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"JiaYuanUpLvSet/JiaYuanExp/E_Text_ZiZhiValue");
     			}
     			return this.m_E_Text_ZiZhiValueText;
     		}
     	}

		public RectTransform EG_UpdateGetRectTransform
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
		    		this.m_EG_UpdateGetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_UpdateGet");
     			}
     			return this.m_EG_UpdateGetRectTransform;
     		}
     	}

		public Button E_Btn_ExchangeZiJinButton
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
		    		this.m_E_Btn_ExchangeZiJinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ExchangeZiJin");
     			}
     			return this.m_E_Btn_ExchangeZiJinButton;
     		}
     	}

		public Image E_Btn_ExchangeZiJinImage
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
		    		this.m_E_Btn_ExchangeZiJinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ExchangeZiJin");
     			}
     			return this.m_E_Btn_ExchangeZiJinImage;
     		}
     	}

		public Button E_Btn_ExchangeExpButton
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
		    		this.m_E_Btn_ExchangeExpButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ExchangeExp");
     			}
     			return this.m_E_Btn_ExchangeExpButton;
     		}
     	}

		public Image E_Btn_ExchangeExpImage
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
		    		this.m_E_Btn_ExchangeExpImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ExchangeExp");
     			}
     			return this.m_E_Btn_ExchangeExpImage;
     		}
     	}

		public Button E_Btn_UpLvButton
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
		    		this.m_E_Btn_UpLvButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_UpLv");
     			}
     			return this.m_E_Btn_UpLvButton;
     		}
     	}

		public Image E_Btn_UpLvImage
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
		    		this.m_E_Btn_UpLvImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_UpLv");
     			}
     			return this.m_E_Btn_UpLvImage;
     		}
     	}

		public Text E_JiaYuanUpHintText
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
		    		this.m_E_JiaYuanUpHintText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_JiaYuanUpHint");
     			}
     			return this.m_E_JiaYuanUpHintText;
     		}
     	}

		public Text E_ZiJinDuiHuanShowText
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
		    		this.m_E_ZiJinDuiHuanShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Image (1)/E_ZiJinDuiHuanShow");
     			}
     			return this.m_E_ZiJinDuiHuanShowText;
     		}
     	}

		public Text E_ExpDuiHuanShowText
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
		    		this.m_E_ExpDuiHuanShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Image (2)/E_ExpDuiHuanShow");
     			}
     			return this.m_E_ExpDuiHuanShowText;
     		}
     	}

		public Text E_ZiJinDuiHuanTextText
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
		    		this.m_E_ZiJinDuiHuanTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ZiJinDuiHuanText");
     			}
     			return this.m_E_ZiJinDuiHuanTextText;
     		}
     	}

		public Text E_ExpDuiHuanTextText
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
		    		this.m_E_ExpDuiHuanTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ExpDuiHuanText");
     			}
     			return this.m_E_ExpDuiHuanTextText;
     		}
     	}

		public Text E_ZiJinDuiHuanAddShowText
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
		    		this.m_E_ZiJinDuiHuanAddShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Image (3)/E_ZiJinDuiHuanAddShow");
     			}
     			return this.m_E_ZiJinDuiHuanAddShowText;
     		}
     	}

		public Text E_ExpDuiHuanAddShowText
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
		    		this.m_E_ExpDuiHuanAddShowText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Image (4)/E_ExpDuiHuanAddShow");
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

		private Image m_E_ImgGengDiIconImage = null;
		private Text m_E_Lab_GengDiText = null;
		private Text m_E_Lab_RenKouText = null;
		private Text m_E_JiaYuanNameText = null;
		private Text m_E_JiaYuanLvText = null;
		private Image m_E_ImageExpValueImage = null;
		private Text m_E_Text_ZiZhiValueText = null;
		private RectTransform m_EG_UpdateGetRectTransform = null;
		private Button m_E_Btn_ExchangeZiJinButton = null;
		private Image m_E_Btn_ExchangeZiJinImage = null;
		private Button m_E_Btn_ExchangeExpButton = null;
		private Image m_E_Btn_ExchangeExpImage = null;
		private Button m_E_Btn_UpLvButton = null;
		private Image m_E_Btn_UpLvImage = null;
		private Text m_E_JiaYuanUpHintText = null;
		private Text m_E_ZiJinDuiHuanShowText = null;
		private Text m_E_ExpDuiHuanShowText = null;
		private Text m_E_ZiJinDuiHuanTextText = null;
		private Text m_E_ExpDuiHuanTextText = null;
		private Text m_E_ZiJinDuiHuanAddShowText = null;
		private Text m_E_ExpDuiHuanAddShowText = null;
		public Transform uiTransform = null;
	}
}
