using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgJiaYuanMenu))]
	[EnableMethod]
	public  class DlgJiaYuanMenuViewComponent : Entity,IAwake,IDestroy 
	{
		public Button E_ImageBgButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBgButton == null )
     			{
		    		this.m_E_ImageBgButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgButton;
     		}
     	}

		public Image E_ImageBgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBgImage == null )
     			{
		    		this.m_E_ImageBgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBg");
     			}
     			return this.m_E_ImageBgImage;
     		}
     	}

		public Button E_ImageBg_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBg_1Button == null )
     			{
		    		this.m_E_ImageBg_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_ImageBg_1");
     			}
     			return this.m_E_ImageBg_1Button;
     		}
     	}

		public Image E_ImageBg_1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageBg_1Image == null )
     			{
		    		this.m_E_ImageBg_1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ImageBg_1");
     			}
     			return this.m_E_ImageBg_1Image;
     		}
     	}

		public RectTransform EG_PositionSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PositionSetRectTransform == null )
     			{
		    		this.m_EG_PositionSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PositionSet");
     			}
     			return this.m_EG_PositionSetRectTransform;
     		}
     	}

		public Button E_Button_PlanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_PlanButton == null )
     			{
		    		this.m_E_Button_PlanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Plan");
     			}
     			return this.m_E_Button_PlanButton;
     		}
     	}

		public Image E_Button_PlanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_PlanImage == null )
     			{
		    		this.m_E_Button_PlanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Plan");
     			}
     			return this.m_E_Button_PlanImage;
     		}
     	}

		public Button E_Button_WatchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_WatchButton == null )
     			{
		    		this.m_E_Button_WatchButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Watch");
     			}
     			return this.m_E_Button_WatchButton;
     		}
     	}

		public Image E_Button_WatchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_WatchImage == null )
     			{
		    		this.m_E_Button_WatchImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Watch");
     			}
     			return this.m_E_Button_WatchImage;
     		}
     	}

		public Button E_Button_GatherButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_GatherButton == null )
     			{
		    		this.m_E_Button_GatherButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Gather");
     			}
     			return this.m_E_Button_GatherButton;
     		}
     	}

		public Image E_Button_GatherImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_GatherImage == null )
     			{
		    		this.m_E_Button_GatherImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Gather");
     			}
     			return this.m_E_Button_GatherImage;
     		}
     	}

		public Button E_Button_UprootButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UprootButton == null )
     			{
		    		this.m_E_Button_UprootButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Uproot");
     			}
     			return this.m_E_Button_UprootButton;
     		}
     	}

		public Image E_Button_UprootImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UprootImage == null )
     			{
		    		this.m_E_Button_UprootImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Uproot");
     			}
     			return this.m_E_Button_UprootImage;
     		}
     	}

		public Button E_Button_SellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_SellButton == null )
     			{
		    		this.m_E_Button_SellButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Sell");
     			}
     			return this.m_E_Button_SellButton;
     		}
     	}

		public Image E_Button_SellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_SellImage == null )
     			{
		    		this.m_E_Button_SellImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Sell");
     			}
     			return this.m_E_Button_SellImage;
     		}
     	}

		public Button E_Button_OpenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_OpenButton == null )
     			{
		    		this.m_E_Button_OpenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Open");
     			}
     			return this.m_E_Button_OpenButton;
     		}
     	}

		public Image E_Button_OpenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_OpenImage == null )
     			{
		    		this.m_E_Button_OpenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Open");
     			}
     			return this.m_E_Button_OpenImage;
     		}
     	}

		public Button E_Button_CleanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CleanButton == null )
     			{
		    		this.m_E_Button_CleanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Clean");
     			}
     			return this.m_E_Button_CleanButton;
     		}
     	}

		public Image E_Button_CleanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CleanImage == null )
     			{
		    		this.m_E_Button_CleanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_Button_Clean");
     			}
     			return this.m_E_Button_CleanImage;
     		}
     	}

		public Image E_ImageDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImageDiImage == null )
     			{
		    		this.m_E_ImageDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PositionSet/E_ImageDi");
     			}
     			return this.m_E_ImageDiImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImageBgButton = null;
			this.m_E_ImageBgImage = null;
			this.m_E_ImageBg_1Button = null;
			this.m_E_ImageBg_1Image = null;
			this.m_EG_PositionSetRectTransform = null;
			this.m_E_Button_PlanButton = null;
			this.m_E_Button_PlanImage = null;
			this.m_E_Button_WatchButton = null;
			this.m_E_Button_WatchImage = null;
			this.m_E_Button_GatherButton = null;
			this.m_E_Button_GatherImage = null;
			this.m_E_Button_UprootButton = null;
			this.m_E_Button_UprootImage = null;
			this.m_E_Button_SellButton = null;
			this.m_E_Button_SellImage = null;
			this.m_E_Button_OpenButton = null;
			this.m_E_Button_OpenImage = null;
			this.m_E_Button_CleanButton = null;
			this.m_E_Button_CleanImage = null;
			this.m_E_ImageDiImage = null;
			this.uiTransform = null;
		}

		private Button m_E_ImageBgButton = null;
		private Image m_E_ImageBgImage = null;
		private Button m_E_ImageBg_1Button = null;
		private Image m_E_ImageBg_1Image = null;
		private RectTransform m_EG_PositionSetRectTransform = null;
		private Button m_E_Button_PlanButton = null;
		private Image m_E_Button_PlanImage = null;
		private Button m_E_Button_WatchButton = null;
		private Image m_E_Button_WatchImage = null;
		private Button m_E_Button_GatherButton = null;
		private Image m_E_Button_GatherImage = null;
		private Button m_E_Button_UprootButton = null;
		private Image m_E_Button_UprootImage = null;
		private Button m_E_Button_SellButton = null;
		private Image m_E_Button_SellImage = null;
		private Button m_E_Button_OpenButton = null;
		private Image m_E_Button_OpenImage = null;
		private Button m_E_Button_CleanButton = null;
		private Image m_E_Button_CleanImage = null;
		private Image m_E_ImageDiImage = null;
		public Transform uiTransform = null;
	}
}
