
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgHuoBiSet))]
	[EnableMethod]
	public  class DlgHuoBiSetViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_TitleIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleIconImage == null )
     			{
		    		this.m_E_TitleIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"TopLeft/Title/E_TitleIcon");
     			}
     			return this.m_E_TitleIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_TitleTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleTextText == null )
     			{
		    		this.m_E_TitleTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"TopLeft/Title/E_TitleText");
     			}
     			return this.m_E_TitleTextText;
     		}
     	}

		public UnityEngine.UI.Image E_TitleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TitleImage == null )
     			{
		    		this.m_E_TitleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/E_Title");
     			}
     			return this.m_E_TitleImage;
     		}
     	}

		public UnityEngine.RectTransform EG_GoldSetRectTransform
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
		    		this.m_EG_GoldSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/EG_GoldSet");
     			}
     			return this.m_EG_GoldSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_GoldText
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
		    		this.m_E_GoldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/EG_GoldSet/E_Gold");
     			}
     			return this.m_E_GoldText;
     		}
     	}

		public UnityEngine.UI.Button E_AddGoldButton
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
		    		this.m_E_AddGoldButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/EG_GoldSet/E_AddGold");
     			}
     			return this.m_E_AddGoldButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddGoldImage
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
		    		this.m_E_AddGoldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/EG_GoldSet/E_AddGold");
     			}
     			return this.m_E_AddGoldImage;
     		}
     	}

		public UnityEngine.RectTransform EG_ZuanShiSetRectTransform
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
		    		this.m_EG_ZuanShiSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/EG_ZuanShiSet");
     			}
     			return this.m_EG_ZuanShiSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_AddZuanShiButton
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
		    		this.m_E_AddZuanShiButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/EG_ZuanShiSet/E_AddZuanShi");
     			}
     			return this.m_E_AddZuanShiButton;
     		}
     	}

		public UnityEngine.UI.Image E_AddZuanShiImage
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
		    		this.m_E_AddZuanShiImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/EG_ZuanShiSet/E_AddZuanShi");
     			}
     			return this.m_E_AddZuanShiImage;
     		}
     	}

		public UnityEngine.UI.Text E_ZuanShiText
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
		    		this.m_E_ZuanShiText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/EG_ZuanShiSet/E_ZuanShi");
     			}
     			return this.m_E_ZuanShiText;
     		}
     	}

		public UnityEngine.RectTransform EG_RongYuRectTransform
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
		    		this.m_EG_RongYuRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/EG_RongYu");
     			}
     			return this.m_EG_RongYuRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_RongYuText
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
		    		this.m_E_Lab_RongYuText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/EG_RongYu/E_Lab_RongYu");
     			}
     			return this.m_E_Lab_RongYuText;
     		}
     	}

		public UnityEngine.RectTransform EG_JiaZuSetRectTransform
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
		    		this.m_EG_JiaZuSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/EG_JiaZuSet");
     			}
     			return this.m_EG_JiaZuSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_JiaZu_ZiJinText
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
		    		this.m_E_JiaZu_ZiJinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/EG_JiaZuSet/E_JiaZu_ZiJin");
     			}
     			return this.m_E_JiaZu_ZiJinText;
     		}
     	}

		public UnityEngine.RectTransform EG_ZiJinSetRectTransform
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
		    		this.m_EG_ZiJinSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/EG_ZiJinSet");
     			}
     			return this.m_EG_ZiJinSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Lab_ZiJinText
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
		    		this.m_E_Lab_ZiJinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/EG_ZiJinSet/E_Lab_ZiJin");
     			}
     			return this.m_E_Lab_ZiJinText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_AddGoldButton
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
		    		this.m_E_Btn_AddGoldButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/EG_ZiJinSet/E_Btn_AddGold");
     			}
     			return this.m_E_Btn_AddGoldButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_AddGoldImage
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
		    		this.m_E_Btn_AddGoldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/EG_ZiJinSet/E_Btn_AddGold");
     			}
     			return this.m_E_Btn_AddGoldImage;
     		}
     	}

		public UnityEngine.RectTransform EG_WeiJingSetRectTransform
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
		    		this.m_EG_WeiJingSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Top/EG_WeiJingSet");
     			}
     			return this.m_EG_WeiJingSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_WeiJing_ZiJinText
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
		    		this.m_E_WeiJing_ZiJinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/EG_WeiJingSet/E_WeiJing_ZiJin");
     			}
     			return this.m_E_WeiJing_ZiJinText;
     		}
     	}

		public UnityEngine.UI.Button E_CloseButton
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
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
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
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.UI.Button E_Close2Button
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
		    		this.m_E_Close2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Top/E_Close2");
     			}
     			return this.m_E_Close2Button;
     		}
     	}

		public UnityEngine.Transform E_TopLeftTitle
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_TopLeftTitle == null )
				{
					this.m_E_TopLeftTitle = UIFindHelper.FindDeepChild<UnityEngine.Transform>(this.uiTransform.gameObject,"TopLeft/Title");
				}
				return this.m_E_TopLeftTitle;
			}
		}

		public UnityEngine.UI.Image E_Close2Image
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
		    		this.m_E_Close2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Top/E_Close2");
     			}
     			return this.m_E_Close2Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_TitleIconImage = null;
			this.m_E_TitleTextText = null;
			this.m_E_TitleImage = null;
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
			this.m_E_TopLeftTitle = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_TitleIconImage = null;
		private UnityEngine.UI.Text m_E_TitleTextText = null;
		private UnityEngine.UI.Image m_E_TitleImage = null;
		private UnityEngine.RectTransform m_EG_GoldSetRectTransform = null;
		private UnityEngine.UI.Text m_E_GoldText = null;
		private UnityEngine.UI.Button m_E_AddGoldButton = null;
		private UnityEngine.UI.Image m_E_AddGoldImage = null;
		private UnityEngine.RectTransform m_EG_ZuanShiSetRectTransform = null;
		private UnityEngine.UI.Button m_E_AddZuanShiButton = null;
		private UnityEngine.UI.Image m_E_AddZuanShiImage = null;
		private UnityEngine.UI.Text m_E_ZuanShiText = null;
		private UnityEngine.RectTransform m_EG_RongYuRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_RongYuText = null;
		private UnityEngine.RectTransform m_EG_JiaZuSetRectTransform = null;
		private UnityEngine.UI.Text m_E_JiaZu_ZiJinText = null;
		private UnityEngine.RectTransform m_EG_ZiJinSetRectTransform = null;
		private UnityEngine.UI.Text m_E_Lab_ZiJinText = null;
		private UnityEngine.UI.Button m_E_Btn_AddGoldButton = null;
		private UnityEngine.UI.Image m_E_Btn_AddGoldImage = null;
		private UnityEngine.RectTransform m_EG_WeiJingSetRectTransform = null;
		private UnityEngine.UI.Text m_E_WeiJing_ZiJinText = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.UI.Button m_E_Close2Button = null;
		private UnityEngine.UI.Image m_E_Close2Image = null;
		private UnityEngine.Transform m_E_TopLeftTitle = null;
		public Transform uiTransform = null;
	}
}
