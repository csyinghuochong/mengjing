using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgHuoBiSet))]
	[EnableMethod]
	public  class DlgHuoBiSetViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_GoldSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_GoldSetRectTransform == null )
     			{
		    		this.m_EG_GoldSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_GoldSet");
     			}
     			return this.m_EG_GoldSetRectTransform;
     		}
     	}

		public Text E_GoldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GoldText == null )
     			{
		    		this.m_E_GoldText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_GoldSet/E_Gold");
     			}
     			return this.m_E_GoldText;
     		}
     	}

		public Button E_AddGoldButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddGoldButton == null )
     			{
		    		this.m_E_AddGoldButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_GoldSet/E_AddGold");
     			}
     			return this.m_E_AddGoldButton;
     		}
     	}

		public Image E_AddGoldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddGoldImage == null )
     			{
		    		this.m_E_AddGoldImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_GoldSet/E_AddGold");
     			}
     			return this.m_E_AddGoldImage;
     		}
     	}

		public RectTransform EG_ZuanShiSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ZuanShiSetRectTransform == null )
     			{
		    		this.m_EG_ZuanShiSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ZuanShiSet");
     			}
     			return this.m_EG_ZuanShiSetRectTransform;
     		}
     	}

		public Button E_AddZuanShiButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddZuanShiButton == null )
     			{
		    		this.m_E_AddZuanShiButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ZuanShiSet/E_AddZuanShi");
     			}
     			return this.m_E_AddZuanShiButton;
     		}
     	}

		public Image E_AddZuanShiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AddZuanShiImage == null )
     			{
		    		this.m_E_AddZuanShiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ZuanShiSet/E_AddZuanShi");
     			}
     			return this.m_E_AddZuanShiImage;
     		}
     	}

		public Text E_ZuanShiText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ZuanShiText == null )
     			{
		    		this.m_E_ZuanShiText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ZuanShiSet/E_ZuanShi");
     			}
     			return this.m_E_ZuanShiText;
     		}
     	}

		public RectTransform EG_RongYuRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RongYuRectTransform == null )
     			{
		    		this.m_EG_RongYuRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_RongYu");
     			}
     			return this.m_EG_RongYuRectTransform;
     		}
     	}

		public Text E_Lab_RongYuText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_RongYuText == null )
     			{
		    		this.m_E_Lab_RongYuText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_RongYu/E_Lab_RongYu");
     			}
     			return this.m_E_Lab_RongYuText;
     		}
     	}

		public RectTransform EG_JiaZuSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_JiaZuSetRectTransform == null )
     			{
		    		this.m_EG_JiaZuSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_JiaZuSet");
     			}
     			return this.m_EG_JiaZuSetRectTransform;
     		}
     	}

		public Text E_JiaZu_ZiJinText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JiaZu_ZiJinText == null )
     			{
		    		this.m_E_JiaZu_ZiJinText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_JiaZuSet/E_JiaZu_ZiJin");
     			}
     			return this.m_E_JiaZu_ZiJinText;
     		}
     	}

		public RectTransform EG_ZiJinSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ZiJinSetRectTransform == null )
     			{
		    		this.m_EG_ZiJinSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ZiJinSet");
     			}
     			return this.m_EG_ZiJinSetRectTransform;
     		}
     	}

		public Text E_Lab_ZiJinText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Lab_ZiJinText == null )
     			{
		    		this.m_E_Lab_ZiJinText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ZiJinSet/E_Lab_ZiJin");
     			}
     			return this.m_E_Lab_ZiJinText;
     		}
     	}

		public Button E_Btn_AddGoldButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddGoldButton == null )
     			{
		    		this.m_E_Btn_AddGoldButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ZiJinSet/E_Btn_AddGold");
     			}
     			return this.m_E_Btn_AddGoldButton;
     		}
     	}

		public Image E_Btn_AddGoldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_AddGoldImage == null )
     			{
		    		this.m_E_Btn_AddGoldImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ZiJinSet/E_Btn_AddGold");
     			}
     			return this.m_E_Btn_AddGoldImage;
     		}
     	}

		public RectTransform EG_WeiJingSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_WeiJingSetRectTransform == null )
     			{
		    		this.m_EG_WeiJingSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_WeiJingSet");
     			}
     			return this.m_EG_WeiJingSetRectTransform;
     		}
     	}

		public Text E_WeiJing_ZiJinText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_WeiJing_ZiJinText == null )
     			{
		    		this.m_E_WeiJing_ZiJinText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_WeiJingSet/E_WeiJing_ZiJin");
     			}
     			return this.m_E_WeiJing_ZiJinText;
     		}
     	}

		public Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public Button E_Close2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Close2Button == null )
     			{
		    		this.m_E_Close2Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Close2");
     			}
     			return this.m_E_Close2Button;
     		}
     	}

		public Image E_Close2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Close2Image == null )
     			{
		    		this.m_E_Close2Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Close2");
     			}
     			return this.m_E_Close2Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_GoldSetRectTransform = null;
			this.m_E_GoldText = null;
			this.m_E_AddGoldButton = null;
			this.m_E_AddGoldImage = null;
			this.m_EG_ZuanShiSetRectTransform = null;
			this.m_E_AddZuanShiButton = null;
			this.m_E_AddZuanShiImage = null;
			this.m_E_ZuanShiText = null;
			this.m_EG_RongYuRectTransform = null;
			this.m_E_Lab_RongYuText = null;
			this.m_EG_JiaZuSetRectTransform = null;
			this.m_E_JiaZu_ZiJinText = null;
			this.m_EG_ZiJinSetRectTransform = null;
			this.m_E_Lab_ZiJinText = null;
			this.m_E_Btn_AddGoldButton = null;
			this.m_E_Btn_AddGoldImage = null;
			this.m_EG_WeiJingSetRectTransform = null;
			this.m_E_WeiJing_ZiJinText = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_E_Close2Button = null;
			this.m_E_Close2Image = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_GoldSetRectTransform = null;
		private Text m_E_GoldText = null;
		private Button m_E_AddGoldButton = null;
		private Image m_E_AddGoldImage = null;
		private RectTransform m_EG_ZuanShiSetRectTransform = null;
		private Button m_E_AddZuanShiButton = null;
		private Image m_E_AddZuanShiImage = null;
		private Text m_E_ZuanShiText = null;
		private RectTransform m_EG_RongYuRectTransform = null;
		private Text m_E_Lab_RongYuText = null;
		private RectTransform m_EG_JiaZuSetRectTransform = null;
		private Text m_E_JiaZu_ZiJinText = null;
		private RectTransform m_EG_ZiJinSetRectTransform = null;
		private Text m_E_Lab_ZiJinText = null;
		private Button m_E_Btn_AddGoldButton = null;
		private Image m_E_Btn_AddGoldImage = null;
		private RectTransform m_EG_WeiJingSetRectTransform = null;
		private Text m_E_WeiJing_ZiJinText = null;
		private Button m_E_CloseButton = null;
		private Image m_E_CloseImage = null;
		private Button m_E_Close2Button = null;
		private Image m_E_Close2Image = null;
		public Transform uiTransform = null;
	}
}
